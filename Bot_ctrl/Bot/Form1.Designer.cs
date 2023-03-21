namespace Bot
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEdtUser = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnImportUA = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnManageGrp = new System.Windows.Forms.Button();
            this.btnImportAcc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_last_log = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.77366F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 435);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 435);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEdtUser);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnImportUA);
            this.panel2.Controls.Add(this.btnLog);
            this.panel2.Controls.Add(this.btnManageGrp);
            this.panel2.Controls.Add(this.btnImportAcc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 94);
            this.panel2.TabIndex = 1;
            // 
            // btnEdtUser
            // 
            this.btnEdtUser.Location = new System.Drawing.Point(483, 14);
            this.btnEdtUser.Name = "btnEdtUser";
            this.btnEdtUser.Size = new System.Drawing.Size(89, 40);
            this.btnEdtUser.TabIndex = 7;
            this.btnEdtUser.Text = "Setting";
            this.btnEdtUser.UseVisualStyleBackColor = true;
            this.btnEdtUser.Click += new System.EventHandler(this.btnEdtUser_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(116, 62);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(724, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(489, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(23, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnImportUA
            // 
            this.btnImportUA.Location = new System.Drawing.Point(253, 14);
            this.btnImportUA.Name = "btnImportUA";
            this.btnImportUA.Size = new System.Drawing.Size(89, 40);
            this.btnImportUA.TabIndex = 2;
            this.btnImportUA.Text = "Import User-Agents";
            this.btnImportUA.UseVisualStyleBackColor = true;
            this.btnImportUA.Click += new System.EventHandler(this.btnImportUA_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(369, 14);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(89, 40);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "Show Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnManageGrp
            // 
            this.btnManageGrp.Location = new System.Drawing.Point(137, 14);
            this.btnManageGrp.Name = "btnManageGrp";
            this.btnManageGrp.Size = new System.Drawing.Size(89, 40);
            this.btnManageGrp.TabIndex = 1;
            this.btnManageGrp.Text = "Manage Groups";
            this.btnManageGrp.UseVisualStyleBackColor = true;
            this.btnManageGrp.Click += new System.EventHandler(this.btnManageGrp_Click);
            // 
            // btnImportAcc
            // 
            this.btnImportAcc.Location = new System.Drawing.Point(23, 14);
            this.btnImportAcc.Name = "btnImportAcc";
            this.btnImportAcc.Size = new System.Drawing.Size(89, 40);
            this.btnImportAcc.TabIndex = 0;
            this.btnImportAcc.Text = "Import Accounts";
            this.btnImportAcc.UseVisualStyleBackColor = true;
            this.btnImportAcc.Click += new System.EventHandler(this.btnImportAcc_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_last_log);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 544);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(758, 14);
            this.panel3.TabIndex = 2;
            // 
            // txt_last_log
            // 
            this.txt_last_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_last_log.Location = new System.Drawing.Point(0, 0);
            this.txt_last_log.Name = "txt_last_log";
            this.txt_last_log.ReadOnly = true;
            this.txt_last_log.Size = new System.Drawing.Size(758, 20);
            this.txt_last_log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embedded";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnManageGrp;
        private System.Windows.Forms.Button btnImportAcc;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnImportUA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_last_log;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnEdtUser;
    }
}

