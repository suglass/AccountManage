using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class frmManageGroup : Form
    {
        public frmManageGroup()
        {
            InitializeComponent();

            btnDelGrp.Enabled = false;
            btnCreateGrp.Enabled = false;
            
            List<string> lstr_group_names = Program.g_db.GetGroupNames();
            foreach(string group_name in lstr_group_names)
            {
                cbxGroup.Items.Add(group_name);
            }
        }

        private void cbxGroup_TextChanged(object sender, EventArgs e)
        {
            if (cbxGroup.SelectedIndex < 0)
            {
                btnDelGrp.Enabled = false;
            }
            else
            {
                cbxGroup.Text = cbxGroup.SelectedText;
                btnDelGrp.Enabled = true;
            }
        }

        private void txt_group_name_TextChanged(object sender, EventArgs e)
        {
            if (txt_group_name.Text.Trim() == string.Empty)
                btnCreateGrp.Enabled = false;
            else
                btnCreateGrp.Enabled = true;
        }

        private void frmManageGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.g_main_frm.BeginInvoke(new Action(() => { Program.g_main_frm.ConfigUI(); }));
        }

        private void btnCreateGrp_Click(object sender, EventArgs e)
        {
            string grp_name = txt_group_name.Text.Trim();
            bool ret = Program.g_db.InsertGroup(grp_name);
            if (ret)
            {
                MessageBox.Show($"Group {grp_name} is added.");
                this.Close();
            }
            else
                MessageBox.Show($"Group {grp_name} add failed. Already exist.");
        }

        private void btnDelGrp_Click(object sender, EventArgs e)
        {
            string group_name = cbxGroup.Text;
            Program.g_db.DeleteGroup(group_name);
            MessageBox.Show($"Group {group_name} deleted.");
            this.Close();
        }
    }
}
