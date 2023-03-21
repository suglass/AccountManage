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
    public partial class frmSign : Form
    {
        public frmSign()
        {
            InitializeComponent();

            /*chkbxSignup.Checked = false;
            txt_signup_pass.Enabled = false;
            txt_signup_user.Enabled = false;*/
        }

        /*private void chkbxSignup_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbxSignup.Checked)
            {
                txt_signup_pass.Enabled = true;
                txt_signup_user.Enabled = true;
                txt_signin_user.Enabled = false;
                txt_signin_pass.Enabled = false;
                btnSubmit.Text = "Sign Up";
            }
            else
            {
                txt_signup_pass.Enabled = false;
                txt_signup_user.Enabled = false;
                txt_signin_user.Enabled = true;
                txt_signin_pass.Enabled = true;
                btnSubmit.Text = "Sign In";
            }
        }*/

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SignIn();
            /*if (btnSubmit.Text == "Sign In")
            {
                SignIn();
            }
            else if (btnSubmit.Text == "Sign Up")
            {
                SignUp();
            }
            else
            {
                MessageBox.Show("Neither In Nor Up");
            }*/
        }

        /*private void SignUp()
        {
            if (txt_signup_user.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Input username correctly.");
                return;
            }

            string strUser = txt_signup_user.Text;
            string strPass = txt_signup_pass.Text;
            bool ret = Program.g_db.InsertUser(strUser, strPass);
            if (ret)
                MessageBox.Show("Sign Up success.");
            else
                MessageBox.Show("Sign Up failed. User is existed already.");
        }*/

        private void SignIn()
        {
            if (txt_signin_user.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Input username correctly.");
                return;
            }

            string strUser = txt_signin_user.Text;
            string strPass = txt_signin_pass.Text;

            int ret = Program.g_db.VerifyUser(strUser, strPass);

            if (ret == ConstEnv.VERIFY_InvalidPass)
            {
                MessageBox.Show("Invalid password.");
                return;
            }
            else if (ret == ConstEnv.VERIFY_NoUser)
            {
                MessageBox.Show("User is not existed.");
                return;
            }
            else if (ret == ConstEnv.VERIFY_SUCCESS)
            {
                Program.g_user_id = Program.g_db.GetUserId(strUser);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Unknown verify return value.");
                return;
            }
        }

        private void txt_signin_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SignIn();
        }

        private void txt_signin_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SignIn();
        }

        /*private void txt_signup_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SignUp();
        }

        private void txt_signup_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SignUp();
        }*/
    }
}
