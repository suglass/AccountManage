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
    public partial class frmEditUser : Form
    {
        public frmEditUser()
        {
            InitializeComponent();
            string _user;
            string _pass;
            Program.g_db.GetUser(Program.g_user_id, out _user, out _pass);
            txt_user.Text = _user;
            txt_pass.Text = _pass;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            string user = txt_user.Text;
            string pass = txt_pass.Text;

            Program.g_db.UpdateUser(user, pass);
            MessageBox.Show("Save success.");
            this.Close();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnSave.Enabled == true)
                    Save();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            if (txt_user.Text.Trim() == string.Empty)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }
    }
}
