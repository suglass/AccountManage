namespace Bot
{
    partial class frmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_userpass = new System.Windows.Forms.TextBox();
            this.txt_proxy = new System.Windows.Forms.TextBox();
            this.txt_emailaddr = new System.Windows.Forms.TextBox();
            this.txt_emailpass = new System.Windows.Forms.TextBox();
            this.txt_deviceID = new System.Windows.Forms.TextBox();
            this.txt_screen_size = new System.Windows.Forms.TextBox();
            this.txt_user_agent = new System.Windows.Forms.TextBox();
            this.txt_UUID = new System.Windows.Forms.TextBox();
            this.btnGenUA = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(44, 30);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(187, 20);
            this.txt_username.TabIndex = 0;
            // 
            // txt_userpass
            // 
            this.txt_userpass.Location = new System.Drawing.Point(254, 30);
            this.txt_userpass.Name = "txt_userpass";
            this.txt_userpass.Size = new System.Drawing.Size(187, 20);
            this.txt_userpass.TabIndex = 1;
            // 
            // txt_proxy
            // 
            this.txt_proxy.Location = new System.Drawing.Point(44, 70);
            this.txt_proxy.Name = "txt_proxy";
            this.txt_proxy.Size = new System.Drawing.Size(397, 20);
            this.txt_proxy.TabIndex = 2;
            // 
            // txt_emailaddr
            // 
            this.txt_emailaddr.Location = new System.Drawing.Point(44, 110);
            this.txt_emailaddr.Name = "txt_emailaddr";
            this.txt_emailaddr.Size = new System.Drawing.Size(187, 20);
            this.txt_emailaddr.TabIndex = 3;
            // 
            // txt_emailpass
            // 
            this.txt_emailpass.Location = new System.Drawing.Point(254, 110);
            this.txt_emailpass.Name = "txt_emailpass";
            this.txt_emailpass.Size = new System.Drawing.Size(187, 20);
            this.txt_emailpass.TabIndex = 4;
            // 
            // txt_deviceID
            // 
            this.txt_deviceID.Location = new System.Drawing.Point(44, 150);
            this.txt_deviceID.Name = "txt_deviceID";
            this.txt_deviceID.ReadOnly = true;
            this.txt_deviceID.Size = new System.Drawing.Size(397, 20);
            this.txt_deviceID.TabIndex = 5;
            // 
            // txt_screen_size
            // 
            this.txt_screen_size.Location = new System.Drawing.Point(44, 270);
            this.txt_screen_size.Name = "txt_screen_size";
            this.txt_screen_size.ReadOnly = true;
            this.txt_screen_size.Size = new System.Drawing.Size(397, 20);
            this.txt_screen_size.TabIndex = 6;
            // 
            // txt_user_agent
            // 
            this.txt_user_agent.Location = new System.Drawing.Point(44, 190);
            this.txt_user_agent.Name = "txt_user_agent";
            this.txt_user_agent.ReadOnly = true;
            this.txt_user_agent.Size = new System.Drawing.Size(397, 20);
            this.txt_user_agent.TabIndex = 7;
            // 
            // txt_UUID
            // 
            this.txt_UUID.Location = new System.Drawing.Point(44, 230);
            this.txt_UUID.Name = "txt_UUID";
            this.txt_UUID.ReadOnly = true;
            this.txt_UUID.Size = new System.Drawing.Size(397, 20);
            this.txt_UUID.TabIndex = 8;
            // 
            // btnGenUA
            // 
            this.btnGenUA.Location = new System.Drawing.Point(44, 310);
            this.btnGenUA.Name = "btnGenUA";
            this.btnGenUA.Size = new System.Drawing.Size(238, 23);
            this.btnGenUA.TabIndex = 9;
            this.btnGenUA.Text = "Generate New User-Agent ETC";
            this.btnGenUA.UseVisualStyleBackColor = true;
            this.btnGenUA.Click += new System.EventHandler(this.btnGenUA_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 363);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenUA);
            this.Controls.Add(this.txt_UUID);
            this.Controls.Add(this.txt_user_agent);
            this.Controls.Add(this.txt_screen_size);
            this.Controls.Add(this.txt_deviceID);
            this.Controls.Add(this.txt_emailpass);
            this.Controls.Add(this.txt_emailaddr);
            this.Controls.Add(this.txt_proxy);
            this.Controls.Add(this.txt_userpass);
            this.Controls.Add(this.txt_username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(503, 402);
            this.MinimumSize = new System.Drawing.Size(503, 402);
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Account";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEdit_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_userpass;
        private System.Windows.Forms.TextBox txt_proxy;
        private System.Windows.Forms.TextBox txt_emailaddr;
        private System.Windows.Forms.TextBox txt_emailpass;
        private System.Windows.Forms.TextBox txt_deviceID;
        private System.Windows.Forms.TextBox txt_screen_size;
        private System.Windows.Forms.TextBox txt_user_agent;
        private System.Windows.Forms.TextBox txt_UUID;
        private System.Windows.Forms.Button btnGenUA;
        private System.Windows.Forms.Button btnSave;
    }
}