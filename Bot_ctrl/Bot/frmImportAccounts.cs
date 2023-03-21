using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class frmImportAccounts : Form
    {
        public frmImportAccounts()
        {
            InitializeComponent();

            List<string> lstr_group_names = Program.g_db.GetGroupNames();
            foreach (string group_name in lstr_group_names)
            {
                cbxGrpImportAcc.Items.Add(group_name);
            }
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ret = false;
            string group_name = cbxGrpImportAcc.Text;

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a file containing e-mail address";
                dlg.Filter = "TXT files|*.txt|All files|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Program.log_info($"Account file selected: {dlg.FileName}");
                    ret = load_accounts(dlg.FileName, group_name);
                }
            }
            catch (Exception ex)
            {
                Program.log_error(ex.Message + "\n" + ex.StackTrace, true);
            }

            if (ret)
            {
                MessageBox.Show("Accounts loaded.");
                this.Close();
            }
            else
                MessageBox.Show("Import accounts failed.");
        }

        private bool load_accounts(string filename, string group_name)
        {
            List<string> lstr_accs = File.ReadAllLines(filename).ToList();

            if (lstr_accs.Count == 0)
            {
                Program.log_error("The file does not contain any lines.", true);
                return false;
            }
            foreach (string s in lstr_accs)
            {
                string line = s;
                if (line.EndsWith("\n"))
                    line = line.Substring(0, line.Length - 1);
                string[] x = line.Split(';');
                if (x.Length != 6 && x.Length != 3)
                {
                    Program.log_error("The file contains a invalid line. -> " + line, true);
                    return false;
                }

                if (x[2].Split(':').Length != 2 && x[2].Split(':').Length != 4)
                {
                    Program.log_error("The file contains a invalid proxy type. -> " + line, true);
                    return false;
                }
                if (x.Length == 6 && x[3].Split(':').Length != 2)
                {
                    Program.log_error("The file contains a invalid mail server. -> " + line, true);
                    return false;
                }
            }

            foreach(string s in lstr_accs)
            {
                string line = s;
                if (line.EndsWith("\n"))
                    line = line.Substring(0, line.Length - 1);
                Program.g_db.InsertAccount(line, group_name);
            }
            return true;
        }

        private void cbxGrpImportAcc_TextChanged(object sender, EventArgs e)
        {
            if (cbxGrpImportAcc.SelectedIndex < 0)
            {
                button1.Enabled = false;
            }
            else
            {
                cbxGrpImportAcc.Text = cbxGrpImportAcc.SelectedText;
                button1.Enabled = true;
            }
        }

        private void frmImportAccounts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.g_main_frm.BeginInvoke(new Action(() => { Program.g_main_frm.ConfigUI(); }));
        }
    }
}
