using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Search;
using MimeKit;
using System.IO;
using System.Data;
using CefBrowser;

namespace MailHelper
{
    partial class MailChecker
    {
        public List<string> Save_email_attachments(MimeKit.MimeMessage message, string path)
        {
            List<string> w_lst_filename = new List<string>();

            try
            {
                foreach (MimeEntity attachment in message.Attachments)
                {
                    string fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                    Program.log_info($"Attach file name - {fileName}");

                    string type = Path.GetExtension(fileName);
                    Program.log_info($"Attach file extension - {type}");

                    /*if (type != ConstEnv.MAIL_ATTACH_TYPE_PDF && type != ConstEnv.MAIL_ATTACH_TYPE_CSV)
                        continue;*/

                    /*if (!type.Equals(ConstEnv.MAIL_ATTACH_TYPE_CSV, StringComparison.InvariantCultureIgnoreCase) && !type.Equals(ConstEnv.MAIL_ATTACH_TYPE_PDF, StringComparison.InvariantCultureIgnoreCase))
                        continue;*/

                    using (var stream = File.Create(path + fileName))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;

                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;

                            part.Content.DecodeTo(stream);
                        }
                    }

                    w_lst_filename.Add(path + fileName);
                }
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }

            return w_lst_filename;
        }

        public List<string> Save_Mail_html_Content(MimeMessage message, string path)
        {
            string base64 = "";
            string[] lines;

            List<string> lst_txt_contents = new List<string>();

            try
            {
                Program.log_info($"message.BodyParts.Count() = {message.BodyParts.Count()}");

                /*if (message.BodyParts.Count() != 1)
                    return "";*/

                int idx_part = 1;

                foreach (var part in message.BodyParts)
                {
                    Program.log_info($"part.ContentType.ToString() = {part.ContentType.ToString()}");

                    if (part.ContentType.ToString() != "Content-Type: text/html; charset=\"UTF-8\"")
                    {
                        continue;
                    }

                    string part_str = part.ToString();
                    lines = part_str.Split('\n');

                    Program.log_info($"lines.Length = {lines.Length}");

                    int k = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] == "\r")
                        {
                            k++;

                            if (k == 1)
                                continue;

                            break;
                        }
                        if (k == 0)
                            continue;

                        base64 += (base64.Length == 0) ? lines[i] : "\n" + lines[i];
                    }
                    
                    if (base64 != "")
                    {
                        Program.log_info("base64 is not blank.");

                        byte[] decodedBytes = Convert.FromBase64String(base64);
                        string decodedText = Encoding.UTF8.GetString(decodedBytes);
                        lst_txt_contents.Add(decodedText);

                        Save_into_file(decodedText, idx_part, path);
                        idx_part++;
                    }
                }                
            }
            catch (Exception ex)
            {
                Program.log_error(ex.Message);
            }
            return lst_txt_contents;
        }

        private void Save_into_file(string content, int part_id, string abs_path)
        {
            string abs_fpath = "";

            string fname = "html_content_" + part_id.ToString() + ".txt";

            int i = 1;
            while (true)
            {
                abs_fpath = Path.Combine(abs_path, fname);
                if (!File.Exists(abs_fpath))
                    break;
                fname = "html_content_" + part_id.ToString() + "_" + i.ToString() + ".txt";
                i++;
            }

            File.WriteAllText(abs_fpath, content);
        }        
    }
}
