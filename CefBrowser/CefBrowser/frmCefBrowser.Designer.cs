namespace CefBrowser
{
    partial class frmCefBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCefBrowser));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmail = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnInstagram = new System.Windows.Forms.Button();
            this.btnNavigate = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_last_log = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnPass);
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Controls.Add(this.btnInstagram);
            this.panel1.Controls.Add(this.btnNavigate);
            this.panel1.Controls.Add(this.txt_url);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 54);
            this.panel1.TabIndex = 1;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(736, 16);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(67, 23);
            this.btnEmail.TabIndex = 8;
            this.btnEmail.Text = "EMAIL";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 42);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(778, 7);
            this.progressBar1.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(27, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(436, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(660, 16);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(67, 23);
            this.btnPass.TabIndex = 4;
            this.btnPass.Text = "Password";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(585, 16);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(67, 23);
            this.btnUser.TabIndex = 3;
            this.btnUser.Text = "Username";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnInstagram
            // 
            this.btnInstagram.Location = new System.Drawing.Point(482, 16);
            this.btnInstagram.Name = "btnInstagram";
            this.btnInstagram.Size = new System.Drawing.Size(79, 23);
            this.btnInstagram.TabIndex = 2;
            this.btnInstagram.Text = "Go Instagram";
            this.btnInstagram.UseVisualStyleBackColor = true;
            this.btnInstagram.Click += new System.EventHandler(this.btnInstagram_Click);
            // 
            // btnNavigate
            // 
            this.btnNavigate.Location = new System.Drawing.Point(402, 16);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(27, 23);
            this.btnNavigate.TabIndex = 1;
            this.btnNavigate.Text = ">>";
            this.btnNavigate.UseVisualStyleBackColor = true;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(61, 17);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(328, 20);
            this.txt_url.TabIndex = 0;
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_last_log);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 433);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 14);
            this.panel2.TabIndex = 2;
            // 
            // txt_last_log
            // 
            this.txt_last_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_last_log.Location = new System.Drawing.Point(0, 0);
            this.txt_last_log.Name = "txt_last_log";
            this.txt_last_log.ReadOnly = true;
            this.txt_last_log.Size = new System.Drawing.Size(828, 20);
            this.txt_last_log.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 364);
            this.panel3.TabIndex = 3;
            // 
            // frmCefBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCefBrowser";
            this.Text = "Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBrowser_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnInstagram;
        private System.Windows.Forms.Button btnNavigate;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_last_log;
        private System.Windows.Forms.Panel panel3;
    }
}