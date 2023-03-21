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
using Utils;

namespace Manager
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            btnGen.Enabled = false;
            btnCreate.Enabled = false;

            lvUsers.Columns.Add("No");
            lvUsers.Columns.Add("ID");
            lvUsers.Columns.Add("Username");
            lvUsers.Columns.Add("Password");

            lvUsers.Columns[0].Width = 30;
            lvUsers.Columns[1].Width = 30;
            lvUsers.Columns[2].Width = (lvUsers.Size.Width - 90) / 2 - 2;
            lvUsers.Columns[3].Width = (lvUsers.Size.Width - 90) / 2 - 2;

            ShowUsers();
        }

        private void ShowUsers()
        {
            DataTable dt_users = Program.g_db.GetAllUsers();

            if (dt_users == null || dt_users.Rows.Count == 0)
            {
                Program.log_info("No users.");
                return;
            }
            //Invoke(new Action(() =>
            //{
            lvUsers.Items.Clear();
            lvUsers.Refresh();
            for (int i = 0; i < dt_users.Rows.Count; i++)
            {
                ListViewItem lvI = new ListViewItem((i + 1).ToString());
                lvI.SubItems.Add(dt_users.Rows[i]["id"].ToString());
                lvI.SubItems.Add(dt_users.Rows[i]["user"].ToString());
                lvI.SubItems.Add(dt_users.Rows[i]["password"].ToString());

                lvUsers.Items.Add(lvI);
            }
            //}));
        }

        public void log(string msg, string logtype)
        {
            lb_last_log.Text = msg;
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            Generate("sugh");
        }

        private void Generate(string password)
        {
            string temp = txt_user.Text + "\n" + txt_pass.Text;
            string encrypted = StringCipher.Encrypt(temp, password);

            File.WriteAllText("base0.dat", encrypted);

            FileCipher.EncryptFile("base0.dat", "base.dat");
            File.Delete("base0.dat");
            //File.Encrypt("base.dat");
            MessageBox.Show("Encrypted file produced.");
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            if ((txt_user.Text + txt_pass.Text).Trim() == string.Empty)
                btnGen.Enabled = false;
            else
                btnGen.Enabled = true;
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            if ((txt_user.Text + txt_pass.Text).Trim() == string.Empty)
                btnGen.Enabled = false;
            else
                btnGen.Enabled = true;
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnGen.Enabled == true)
                    Generate("sugh");
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnGen.Enabled == true)
                    Generate("sugh");
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            if ((txt_username.Text + txt_password.Text).Trim() == string.Empty)
                btnCreate.Enabled = false;
            else
                btnCreate.Enabled = true;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if ((txt_username.Text + txt_password.Text).Trim() == string.Empty)
                btnCreate.Enabled = false;
            else
                btnCreate.Enabled = true;
        }

        private void CreateUser()
        {
            string _username = txt_username.Text;
            string _password = txt_password.Text;
            bool ret = Program.g_db.InsertUser(_username, _password);

            if (ret)
                MessageBox.Show("Create user success.");
            else
                MessageBox.Show("User is already existed.");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateUser();
            ShowUsers();
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnCreate.Enabled == true)
                    CreateUser();
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnCreate.Enabled == true)
                    CreateUser();
        }

        private void lvUsers_Resize(object sender, EventArgs e)
        {
            lvUsers.Columns[0].Width = 30;
            lvUsers.Columns[1].Width = 30;
            lvUsers.Columns[2].Width = (lvUsers.Size.Width - 90) / 2 - 2;
            lvUsers.Columns[3].Width = (lvUsers.Size.Width - 90) / 2 - 2;
        }

        private void lvUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvUsers.FocusedItem != null && lvUsers.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu m = new ContextMenu();

                    MenuItem editMenuItem = new MenuItem("Edit");
                    editMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        EditAction(sender, e);
                    };// your action here 
                    m.MenuItems.Add(editMenuItem);

                    MenuItem deleteMenuItem = new MenuItem("Delete");
                    deleteMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        DeleteAction(sender, e);
                    };// your action here 
                    m.MenuItems.Add(deleteMenuItem);

                    m.Show(lvUsers, new Point(e.X, e.Y));
                }
            }
        }

        private void DeleteAction(object sender, MouseEventArgs e)
        {
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;

            int id = int.Parse(ListViewControl.SelectedItems[0].SubItems[1].Text);

            Program.g_db.DeleteUser(id);
            ShowUsers();
        }

        private void EditAction(object sender, MouseEventArgs e)
        {
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;

            int id = int.Parse(ListViewControl.SelectedItems[0].SubItems[1].Text);

            frmEditUser dlg = new frmEditUser(id);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowUsers();
            }
        }
    }
}
