using DbHelper.DbBase;
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
    public partial class frmEdit : Form
    {
        public InstAccount m_acc;

        public frmEdit(int _acc_id)
        {
            InitializeComponent();
            m_acc = Program.g_db.GetAccountById(_acc_id);

            /*txt_username.PlaceHolderText = "User Name";
            txt_userpass.PlaceHolderText = "User Password";
            txt_proxy.PlaceHolderText = "Proxy";
            txt_emailaddr.PlaceHolderText = "Email Address";
            txt_emailpass.PlaceHolderText = "Email Password";
            txt_deviceID.PlaceHolderText = "Device ID";
            txt_user_agent.PlaceHolderText = "User-Agent";
            txt_UUID.PlaceHolderText = "UUID";
            txt_screen_size.PlaceHolderText = "Screen Size";*/

            txt_username.Text = m_acc.username;
            txt_userpass.Text = m_acc.userpass;
            txt_proxy.Text = m_acc.proxy;
            txt_emailaddr.Text = m_acc.emailaddr;
            txt_emailpass.Text = m_acc.emailpass;
            txt_deviceID.Text = m_acc.deviceid;
            txt_user_agent.Text = m_acc.user_agent;
            txt_UUID.Text = m_acc.deviceid;
            txt_screen_size.Text = m_acc.screensize;
        }

        private void btnGenUA_Click(object sender, EventArgs e)
        {
            txt_user_agent.Text = Program.g_db.SetRandomUserAgentToAcc(m_acc.id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == string.Empty || txt_userpass.Text == string.Empty || txt_proxy.Text == string.Empty || txt_emailaddr.Text == string.Empty || txt_emailpass.Text == string.Empty)
            {
                MessageBox.Show("Empty value is existed.");
                return;
            }

            string[] vals = txt_proxy.Text.Replace(" ", "").Split(':');
            if (vals.Length != 2 && vals.Length != 4)
            {
                MessageBox.Show("Invalid proxy.");
                return;
            }

            Program.g_db.UpdateAccount(m_acc.id, txt_username.Text.Trim(), txt_userpass.Text.Trim(), txt_emailaddr.Text.Trim(), txt_emailpass.Text.Trim(), txt_proxy.Text.Replace(" ", ""), txt_user_agent.Text);
            MessageBox.Show("Account info Saved.");
            this.Close();
        }

        private void frmEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.g_main_frm.BeginInvoke(new Action(() => { Program.g_main_frm.ConfigUI(); }));
        }
    }
}
