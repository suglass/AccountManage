using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class frmEditUser : Form
    {
        public int m_user_id;
        public frmEditUser(int _user_id)
        {
            InitializeComponent();
            m_user_id = _user_id;

            string _user;
            string _pass;
            Program.g_db.GetUser(_user_id, out _user, out _pass);
            txt_username.Text = _user;
            txt_password.Text = _pass;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            string user = txt_username.Text;
            string pass = txt_password.Text;

            Program.g_db.UpdateUser(user, pass, m_user_id);
            MessageBox.Show("Save success.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            if (txt_username.Text.Trim() == string.Empty)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnSave.Enabled == true)
                    Save();
        }
    }
}
