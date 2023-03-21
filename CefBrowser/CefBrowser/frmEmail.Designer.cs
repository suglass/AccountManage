namespace CefBrowser
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webroMail = new CefSharp.WinForms.ChromiumWebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prgbar = new System.Windows.Forms.ProgressBar();
            this.btnLoad = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.60104F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 579);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(795, 523);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvSearchResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 265);
            this.panel1.TabIndex = 0;
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.GridLines = true;
            this.lvSearchResult.Location = new System.Drawing.Point(0, 0);
            this.lvSearchResult.MultiSelect = false;
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(795, 265);
            this.lvSearchResult.TabIndex = 0;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            this.lvSearchResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvSearchResult_MouseClick);
            this.lvSearchResult.Resize += new System.EventHandler(this.lvSearchResult_Resize);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webroMail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 254);
            this.panel2.TabIndex = 0;
            // 
            // webroMail
            // 
            this.webroMail.ActivateBrowserOnCreation = false;
            this.webroMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webroMail.Location = new System.Drawing.Point(0, 0);
            this.webroMail.MinimumSize = new System.Drawing.Size(20, 20);
            this.webroMail.Name = "webroMail";
            this.webroMail.Size = new System.Drawing.Size(795, 254);
            this.webroMail.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.prgbar);
            this.panel3.Controls.Add(this.btnLoad);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 44);
            this.panel3.TabIndex = 1;
            // 
            // prgbar
            // 
            this.prgbar.Location = new System.Drawing.Point(26, 11);
            this.prgbar.Name = "prgbar";
            this.prgbar.Size = new System.Drawing.Size(620, 23);
            this.prgbar.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(679, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Mails";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 579);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmail";
            this.Text = "Email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEmail_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmail_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ProgressBar prgbar;
        private CefSharp.WinForms.ChromiumWebBrowser webroMail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}