using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule
{
    public class FetchParam
    {
        public string folder_path;
        public UniqueId idx_mail;

        public FetchParam(string folder, UniqueId index)
        {
            folder_path = folder;
            idx_mail = index;
        }
        public FetchParam()
        {
            folder_path = "";
            idx_mail = UniqueId.MinValue;
        }
    }
}
