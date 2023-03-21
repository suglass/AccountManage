using CefSharp;
using DbHelper.DbBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class Form1 : Form
    {
        private enum ExpandState
        {
            Expanded,
            Expanding,
            Collapsing,
            Collapsed,
        }

        // The expanding panels' current states.
        private List<ExpandState> ExpandStates;

        // The Panels to expand and collapse.
        private List<TableLayoutPanel> ExpandPanels;

        // The expand/collapse buttons.
        private List<Button> ExpandButtons;
        List<string> lstr_grp_names;

        private List<CheckBox> m_lst_GroupCheckBoxes;
        //private List<int> m_lst_nGrpChBxItemCheckedNum;

        private List<CheckBox> m_lst_UserCheckBoxes;

        private const int ExpansionPerTick = 350;

        private System.Windows.Forms.Timer tmrExpand;
        //private Timer tmrCollapse;

        public Form1()
        {
            InitializeComponent();
            Program.log_info("App opened.");

            m_lst_GroupCheckBoxes = new List<CheckBox>();
            m_lst_UserCheckBoxes = new List<CheckBox>();
            //m_lst_nGrpChBxItemCheckedNum = new List<int>();

            tmrExpand = new System.Windows.Forms.Timer();
            tmrExpand.Tick += new EventHandler(tmrExpand_Tick);

            btnDelete.Enabled = false;
            btnExport.Enabled = false;
            ConfigUI();
        }

        public void ConfigUIContent()
        {
            string keyword = textBox1.Text.Trim();

            m_lst_GroupCheckBoxes.Clear();
            m_lst_UserCheckBoxes.Clear();

            btnDelete.Enabled = false;
            btnExport.Enabled = false;

            flowLayoutPanel1.Controls.Clear();

            ExpandStates = new List<ExpandState>();

            ExpandPanels = new List<TableLayoutPanel>();

            ExpandButtons = new List<Button>();

            Label line = new Label();
            line.AutoSize = false;
            line.BorderStyle = BorderStyle.FixedSingle;
            line.Height = 1;
            line.Width = flowLayoutPanel1.Width - 10;

            lstr_grp_names = Program.g_db.GetGroupNames();

            // Set expander button Tag properties to give indexes
            // into these arrays and display expanded images.
            for (int i = 0; i < lstr_grp_names.Count; i++)
            {
                List<InstAccount> lst_accs = Program.g_db.GetAccountsByGroup(lstr_grp_names[i]);

                Button button = new Button();
                button.Tag = i;
                button.Image = Properties.Resources.minus;
                button.MouseClick += new MouseEventHandler(btnExpander_MouseClicked);
                button.Tag = "btnexp:" + lstr_grp_names[i];
                button.Size = new System.Drawing.Size(20, 20);
                button.Margin = new System.Windows.Forms.Padding(7);
                ExpandButtons.Add(button);
                button.Enabled = lst_accs.Count == 0 ? false : true;

                TableLayoutPanel group_panel = new TableLayoutPanel();
                group_panel.RowCount = lst_accs.Count;
                group_panel.ColumnCount = 1;
                group_panel.Tag = "group_panel:" + lstr_grp_names[i];
                group_panel.CellPaint += tableLayoutPanel_CellPaint;

                for (int j = 0; j < lst_accs.Count; j++)
                    group_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));

                for (int k = 0; k < lst_accs.Count; k++)
                {
                    InstAccount acc = lst_accs[k];

                    string str_tag_base = "acc_panel:" + acc.id.ToString();

                    TableLayoutPanel panel = new TableLayoutPanel();
                    panel.RowCount = 1;
                    panel.ColumnCount = 6;
                    panel.Tag = str_tag_base;

                    CheckBox chkbx = new CheckBox();
                    chkbx.Checked = false;
                    chkbx.MouseClick += new MouseEventHandler(chkbox_MouseClicked);
                    chkbx.Tag = "chk:" + acc.id.ToString();
                    chkbx.Margin = new System.Windows.Forms.Padding(5);
                    m_lst_UserCheckBoxes.Add(chkbx);

                    Label lb_username = new Label();
                    lb_username.Text = acc.username;
                    lb_username.Font = new Font("Microsoft Sans Serif", 12);
                    lb_username.Size = new System.Drawing.Size(150, 23);
                    lb_username.Margin = new System.Windows.Forms.Padding(5);

                    Label lb_emailaddr = new Label();
                    lb_emailaddr.Text = acc.emailaddr;
                    lb_emailaddr.Font = new Font("Microsoft Sans Serif", 12);
                    lb_emailaddr.Size = new System.Drawing.Size(200, 23);
                    lb_emailaddr.Margin = new System.Windows.Forms.Padding(5);

                    Button btnEdit = new Button();
                    btnEdit.Text = "EDIT";
                    btnEdit.Tag = "btnedt:" + acc.id.ToString();
                    btnEdit.Size = new System.Drawing.Size(60, 23);
                    btnEdit.MouseClick += new MouseEventHandler(btnEdit_MouseClicked);
                    btnEdit.Margin = new System.Windows.Forms.Padding(5);
                    //btnEdit.BackColor = Color.White;

                    Button btnBro = new Button();
                    btnBro.Text = "Browser";
                    btnBro.Tag = "btnbro:" + acc.id.ToString();
                    btnBro.Size = new System.Drawing.Size(60, 23);
                    btnBro.MouseClick += new MouseEventHandler(btnBro_MouseClicked);
                    btnBro.Margin = new System.Windows.Forms.Padding(5);

                    /*Button btnEmail = new Button();
                    btnEmail.Text = "EMAIL";
                    btnEmail.Tag = "btneml:" + acc.id.ToString();
                    btnEmail.Size = new System.Drawing.Size(60, 23);
                    btnEmail.MouseClick += new MouseEventHandler(btnEml_MouseClicked);
                    btnEmail.Margin = new System.Windows.Forms.Padding(5);*/

                    /*panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 160));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 160));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));*/

                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 110F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 150F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));

                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));

                    panel.Controls.Add(chkbx, 0, 0);
                    panel.Controls.Add(lb_username, 1, 0);
                    panel.Controls.Add(lb_emailaddr, 2, 0);
                    panel.Controls.Add(btnEdit, 3, 0);
                    panel.Controls.Add(btnBro, 4, 0);

                    panel.Dock = System.Windows.Forms.DockStyle.Fill;
                    panel.Size = new System.Drawing.Size(730, 30);

                    //panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                    group_panel.Controls.Add(panel, 0, k);
                }

                group_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                group_panel.Dock = System.Windows.Forms.DockStyle.Fill;
                group_panel.Size = new System.Drawing.Size(730, 35 * lst_accs.Count);
                group_panel.MaximumSize = new System.Drawing.Size(730, 35 * lst_accs.Count);
                //group_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                group_panel.BackColor = Color.White;

                ExpandPanels.Add(group_panel);
                ExpandStates.Add(ExpandState.Expanded);
            }

            for (int i = 0; i < lstr_grp_names.Count; i++)
            {
                TableLayoutPanel btn_panel = new TableLayoutPanel();
                btn_panel.RowCount = 1;
                btn_panel.ColumnCount = 3;
                btn_panel.CellPaint += tableLayoutPanel_CellPaint;

                CheckBox chkbx = new CheckBox();
                chkbx.Checked = false;
                chkbx.MouseClick += new MouseEventHandler(chkboxgrp_MouseClicked);
                chkbx.Tag = "chk:" + lstr_grp_names[i];
                m_lst_GroupCheckBoxes.Add(chkbx);

                Label lb_group_name = new Label();
                lb_group_name.Margin = new System.Windows.Forms.Padding(3);
                int group_accounts_count = Program.g_db.GetAccountsByGroup(lstr_grp_names[i]).Count;
                lb_group_name.Text = lstr_grp_names[i] + " ( " + group_accounts_count.ToString() + " accounts )";
                lb_group_name.Font = new Font("Microsoft Sans Serif", 12);
                lb_group_name.Size = new System.Drawing.Size(600, 23);

                btn_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                btn_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 500F));
                btn_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));

                //btn_panel.Dock = System.Windows.Forms.DockStyle.Fill;
                //btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                btn_panel.Size = new System.Drawing.Size(730, 30);
                btn_panel.Controls.Add(chkbx, 0, 0);
                btn_panel.Controls.Add(lb_group_name, 1, 0);
                btn_panel.Controls.Add(ExpandButtons[i], 2, 0);
                //btn_panel.BackColor = Color.DarkGray;

                flowLayoutPanel1.Controls.Add(btn_panel);
                //flowLayoutPanel1.Controls.Add(line);
                flowLayoutPanel1.Controls.Add(ExpandPanels[i]);
            }
        }

        public void ConfigSearchUIContent(string keyword)
        {
            m_lst_GroupCheckBoxes.Clear();
            m_lst_UserCheckBoxes.Clear();

            flowLayoutPanel1.Controls.Clear();

            //ExpandPanels = new List<TableLayoutPanel>();

            Label line = new Label();
            line.AutoSize = false;
            line.BorderStyle = BorderStyle.FixedSingle;
            line.Height = 1;
            line.Width = flowLayoutPanel1.Width - 10;

            lstr_grp_names = Program.g_db.GetGroupNames();

            // Set expander button Tag properties to give indexes
            // into these arrays and display expanded images.
            for (int i = 0; i < lstr_grp_names.Count; i++)
            {
                List<InstAccount> lst_accs = Program.g_db.GetAccountsByGroup(lstr_grp_names[i]);

                for (int k = 0; k < lst_accs.Count; k++)
                {
                    InstAccount acc = lst_accs[k];

                    if (acc.username.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) == -1 &&
                        acc.emailaddr.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) == -1)
                        continue;

                    string str_tag_base = "acc_panel:" + acc.id.ToString();

                    TableLayoutPanel panel = new TableLayoutPanel();
                    panel.RowCount = 1;
                    panel.ColumnCount = 5;
                    panel.Tag = str_tag_base;

                    CheckBox chkbx = new CheckBox();
                    chkbx.Checked = false;
                    chkbx.MouseClick += new MouseEventHandler(chkbox_MouseClicked);
                    chkbx.Tag = "chk:" + acc.id.ToString();
                    chkbx.Margin = new System.Windows.Forms.Padding(5);
                    m_lst_UserCheckBoxes.Add(chkbx);

                    Label lb_username = new Label();
                    lb_username.Text = acc.username;
                    lb_username.Font = new Font("Microsoft Sans Serif", 12);
                    lb_username.Size = new System.Drawing.Size(150, 23);
                    lb_username.Margin = new System.Windows.Forms.Padding(5);

                    Label lb_emailaddr = new Label();
                    lb_emailaddr.Text = acc.emailaddr;
                    lb_emailaddr.Font = new Font("Microsoft Sans Serif", 12);
                    lb_emailaddr.Size = new System.Drawing.Size(200, 23);
                    lb_emailaddr.Margin = new System.Windows.Forms.Padding(5);

                    Button btnEdit = new Button();
                    btnEdit.Text = "EDIT";
                    btnEdit.Tag = "btnedt:" + acc.id.ToString();
                    btnEdit.Size = new System.Drawing.Size(60, 23);
                    btnEdit.MouseClick += new MouseEventHandler(btnEdit_MouseClicked);
                    btnEdit.Margin = new System.Windows.Forms.Padding(5);
                    //btnEdit.BackColor = Color.White;

                    Button btnBro = new Button();
                    btnBro.Text = "Browser";
                    btnBro.Tag = "btnbro:" + acc.id.ToString();
                    btnBro.Size = new System.Drawing.Size(60, 23);
                    btnBro.MouseClick += new MouseEventHandler(btnBro_MouseClicked);
                    btnBro.Margin = new System.Windows.Forms.Padding(5);

                    /*Button btnEmail = new Button();
                    btnEmail.Text = "EMAIL";
                    btnEmail.Tag = "btneml:" + acc.id.ToString();
                    btnEmail.Size = new System.Drawing.Size(60, 23);
                    btnEmail.MouseClick += new MouseEventHandler(btnEml_MouseClicked);
                    btnEmail.Margin = new System.Windows.Forms.Padding(5);*/

                    /*panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 160));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 160));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));*/

                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 110F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 150F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));

                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));

                    panel.Controls.Add(chkbx, 0, 0);
                    panel.Controls.Add(lb_username, 1, 0);
                    panel.Controls.Add(lb_emailaddr, 2, 0);
                    panel.Controls.Add(btnEdit, 3, 0);
                    panel.Controls.Add(btnBro, 4, 0);

                    //panel.Dock = System.Windows.Forms.DockStyle.Fill;
                    panel.Size = new System.Drawing.Size(730, 30);

                    //panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }

        public void ConfigUI()
        {
            string keyword = textBox1.Text.Trim();

            if (keyword == string.Empty)
                ConfigUIContent();
            else
                ConfigSearchUIContent(keyword);
        }

        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
        }
        public void btnExpander_MouseClicked(object sender, EventArgs e)
        {
            Button btnExpander = sender as Button;
            if (!btnExpander.Tag.ToString().Trim().StartsWith("btnexp:"))
                return;

            // Get this panel's current expand
            //  state and set its new state.
            string grp_name = tag_info(btnExpander.Tag.ToString());
            int index = lstr_grp_names.IndexOf(grp_name);

            if (Program.g_db.GetAccountsByGroup(grp_name).Count == 0)
            {
                tmrExpand.Enabled = false;
                if (ExpandButtons[index].Image == Properties.Resources.minus)
                {
                    ExpandStates[index] = ExpandState.Collapsed;
                    ExpandButtons[index].Image = Properties.Resources.minus;
                }
                else
                {
                    ExpandStates[index] = ExpandState.Expanded;
                    ExpandButtons[index].Image = Properties.Resources.plus;
                }
                    
                return;
            }

            ExpandState old_state = ExpandStates[index];
            if ((old_state == ExpandState.Collapsed) ||
                (old_state == ExpandState.Collapsing))
            {
                // Was collapsed/collapsing. Start expanding.
                ExpandStates[index] = ExpandState.Expanding;
                ExpandButtons[index].Image = Properties.Resources.minus;
            }
            else
            {
                // Was expanded/expanding. Start collapsing.
                ExpandStates[index] = ExpandState.Collapsing;
                ExpandButtons[index].Image = Properties.Resources.plus;
            }

            // Make sure the timer is enabled.
            tmrExpand.Enabled = true;
        }

        private void tmrExpand_Tick(object sender, EventArgs e)
        {
            // Determines whether we need more adjustments.
            bool not_done = false;

            for (int i = 0; i < ExpandPanels.Count; i++)
            {
                // See if this panel needs adjustment.
                if (ExpandStates[i] == ExpandState.Expanding)
                {
                    // Expand.
                    TableLayoutPanel pan = ExpandPanels[i];
                    /*int plus_value = ExpansionPerTick;
                    if (pan.Height + ExpansionPerTick > pan.MaximumSize.Height)
                        plus_value = pan.MaximumSize.Height - pan.Height;
                    int new_height = pan.Height + plus_value;*/

                    //int new_height = pan.Height + ExpansionPerTick;

                    int new_height = pan.MaximumSize.Height;

                    if (new_height <= pan.MaximumSize.Height)
                    {
                        // This one is done.
                        new_height = pan.MaximumSize.Height;
                    }
                    else
                    {
                        // This one is not done.
                        not_done = true;
                    }

                    // Set the new height.
                    pan.Height = new_height;
                }
                else if (ExpandStates[i] == ExpandState.Collapsing)
                {
                    // Collapse.
                    TableLayoutPanel pan = ExpandPanels[i];
                    /*int minus_value = ExpansionPerTick;
                    if (pan.Height - ExpansionPerTick < pan.MinimumSize.Height)
                        minus_value = pan.Height - pan.MinimumSize.Height;
                    int new_height = pan.Height - minus_value;*/

                    //int new_height = pan.Height - ExpansionPerTick;

                    int new_height = pan.MinimumSize.Height;

                    if (new_height <= pan.MinimumSize.Height)
                    {
                        // This one is done.
                        new_height = pan.MinimumSize.Height;
                    }
                    else
                    {
                        // This one is not done.
                        not_done = true;
                    }

                    // Set the new height.
                    pan.Height = new_height;
                }
            }

            // If we are done, disable the timer.
            tmrExpand.Enabled = not_done;
        }
        public void btnEdit_MouseClicked(object sender, EventArgs e)
        {
            Button btnEdit = sender as Button;
            if (!btnEdit.Tag.ToString().Trim().StartsWith("btnedt:"))
                return;

            int acc_id = int.Parse(tag_info(btnEdit.Tag.ToString().Trim()));
            frmEdit dlg = new frmEdit(acc_id);
            dlg.ShowDialog();
        }

        public void btnBro_MouseClicked(object sender, EventArgs e)
        {
            Button btnBro = sender as Button;
            if (!btnBro.Tag.ToString().Trim().StartsWith("btnbro:"))
                return;

            int acc_id = int.Parse(tag_info(btnBro.Tag.ToString().Trim()));
            //InstAccount acc = Program.g_db.GetAccountById(acc_id);

            //string str_chr_data_path = acc_id.ToString() + "_" + acc.emailaddr;
            //string user_agent = Program.g_db.GetUserAgentFromAccId(acc_id);
            //string proxy = Program.g_db.GetProxyFromAccId(acc_id);

            /*if (user_agent == string.Empty)
            {
                user_agent = Program.g_db.SetRandomUserAgentToAcc(acc_id);
            }*/

            /*frmBrowser dlg = new frmBrowser(acc_id);
            dlg.Show();*/

            //string arguments = acc.id.ToString() + " " + acc.username + " " + acc.userpass;

            //string temp = user_agent + "\n" + proxy;
            /*string path = Path.Combine(ConstEnv.PATH_TEMP, acc.id.ToString() + "_" + acc.username + ".txt");

            if (!Directory.Exists(ConstEnv.PATH_TEMP))
                Directory.CreateDirectory(ConstEnv.PATH_TEMP);

            File.WriteAllText(path, temp);*/
            string converter_path = $"CefBrowser.exe";
            string arguments = acc_id.ToString();

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = arguments;
            start.FileName = converter_path;
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;

            Program.log_info($"start CefBrowser");

            Process proc = Process.Start(start);

            /*new Thread((ThreadStart)(() =>
            {
                InstBot bot = new InstBot(user_agent, proxy, str_chr_data_path);
                await bot.Start();              
            })).Start();*/
        }

        /*public void btnEml_MouseClicked(object sender, EventArgs e)
        {
            Button btnEml = sender as Button;
            if (!btnEml.Tag.ToString().Trim().StartsWith("btneml:"))
                return;

            int acc_id = int.Parse(tag_info(btnEml.Tag.ToString().Trim()));
            InstAccount acc = Program.g_db.GetAccountById(acc_id);

            frmEmail dlg = new frmEmail(acc_id);
            dlg.Show();
        }*/

        public void chkbox_MouseClicked(object sender, EventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;
            if (!chkbox.Tag.ToString().Trim().StartsWith("chk:"))
                return;

            int acc_id = int.Parse(tag_info(chkbox.Tag.ToString()));
            string group_name = Program.g_db.GetAccountById(acc_id).group_name;

            int total_num = 0;
            int checked_num = 0;
            int unchecked_num = 0;

            int entire_checked_count = 0;

            foreach (CheckBox item in m_lst_UserCheckBoxes)
            {
                if (item.Checked)
                    entire_checked_count++;
                int sub_acc_id = int.Parse(tag_info(item.Tag.ToString()));
                string sub_group_name = Program.g_db.GetAccountById(sub_acc_id).group_name;
                if (sub_group_name == group_name)
                {
                    total_num++;
                    if (item.Checked)
                        checked_num++;
                    else
                        unchecked_num++;
                }
            }

            if (entire_checked_count == 0)
            {
                btnDelete.Enabled = false;
                btnExport.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnExport.Enabled = true;
            }

            if (total_num == checked_num)
            {
                foreach (CheckBox grp_item in m_lst_GroupCheckBoxes)
                {
                    string chk_group_name = tag_info(grp_item.Tag.ToString());
                    if (chk_group_name == group_name)
                    {
                        grp_item.Checked = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (CheckBox grp_item in m_lst_GroupCheckBoxes)
                {
                    string chk_group_name = tag_info(grp_item.Tag.ToString());
                    if (chk_group_name == group_name)
                    {
                        grp_item.Checked = false;
                        break;
                    }
                }
            }
        }
        public void chkboxgrp_MouseClicked(object sender, EventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;
            if (!chkbox.Tag.ToString().Trim().StartsWith("chk:"))
                return;

            string group_name = tag_info(chkbox.Tag.ToString());

            foreach (CheckBox item in m_lst_UserCheckBoxes)
            {
                int acc_id = int.Parse(tag_info(item.Tag.ToString()));
                InstAccount acc = Program.g_db.GetAccountById(acc_id);
                if (acc.group_name == group_name)
                {
                    if (chkbox.Checked)
                        item.Checked = true;
                    else
                        item.Checked = false;
                }
            }

            int entire_checked_count = 0;
            foreach (CheckBox item in m_lst_UserCheckBoxes)
            {
                if (item.Checked)
                    entire_checked_count++;
            }

            if (entire_checked_count == 0)
            {
                btnDelete.Enabled = false;
                btnExport.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnExport.Enabled = true;
            }
        }
        public void show_log_window()
        {
            Program.g_log_frm.Show();
            Program.g_log_frm.Activate();
        }

        public void log(string msg, string logtype)
        {
            txt_last_log.Text = msg;
            Program.g_full_log += "\n" + msg;
            if (Program.g_log_frm != null)
                Program.g_log_frm.update_log();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Program.show_log_window();
        }

        private void btnManageGrp_Click(object sender, EventArgs e)
        {
            frmManageGroup grp_dlg = new frmManageGroup();
            grp_dlg.ShowDialog();            
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }
        }

        private string tag_info(string text)
        {
            try
            {
                string[] parts = text.Split(':');
                return parts[1];
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return string.Empty;
        }

        private void btnImportAcc_Click(object sender, EventArgs e)
        {
            frmImportAccounts acc_dlg = new frmImportAccounts();
            acc_dlg.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
            Program.g_setting.Save();
        }

        private void btnImportUA_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a file containing user-agents";
                dlg.Filter = "TXT files|*.txt|All files|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Program.log_info($"Account file selected: {dlg.FileName}");
                    ImportUserAgents(dlg.FileName);
                    MessageBox.Show("Import Success.");
                }
            }
            catch (Exception ex)
            {
                Program.log_error(ex.Message + "\n" + ex.StackTrace, true);
            }
        }

        private void ImportUserAgents(string filename)
        {
            List<string> lstr_user_agents = File.ReadAllLines(filename).ToList();

            foreach (string line in lstr_user_agents)
            {
                string temp = line.Trim();
                if (temp.EndsWith("\n"))
                    temp = line.Substring(0, temp.Length - 1);
                if (temp == string.Empty)
                    continue;
                Program.g_db.InsertUserAgent(temp);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConfigUI();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfigUI();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.close_log_window();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> lst_ret = new List<string>();

            foreach (CheckBox item in m_lst_UserCheckBoxes)
            {
                string ret = string.Empty;

                if (item.Checked == false)
                    continue;
                int acc_id = int.Parse(tag_info(item.Tag.ToString()));
                InstAccount acc = Program.g_db.GetAccountById(acc_id);

                ret = acc.username + ";" + acc.userpass + ";" + acc.proxy;
                if (acc.emailaddr != string.Empty)
                    ret = ret + ";" + acc.emailaddr + ";" + acc.emailpass;
                lst_ret.Add(ret);
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TXT files|*.txt";
            dialog.Title = "Save the Accounts";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;

                try
                {
                    File.WriteAllLines(filename, lst_ret);
                    MessageBox.Show($"{lst_ret.Count} Accounts saved successfully.", "Save Result");
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    MessageBox.Show($"Check if file is opened. Then try again.", "Error");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (CheckBox item in m_lst_UserCheckBoxes)
            {
                if (item.Checked == false)
                    continue;
                int acc_id = int.Parse(tag_info(item.Tag.ToString()));
                Program.g_db.DeleteAccountByID(acc_id);
            }
            ConfigUI();
        }

        private void btnEdtUser_Click(object sender, EventArgs e)
        {
            frmEditUser dlg = new frmEditUser();
            dlg.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ConfigUI();
        }
    }
}
