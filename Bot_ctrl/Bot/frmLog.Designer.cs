using CustomControl;

namespace Bot
{
    partial class frmLog
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
            this.panel0 = new CustomControl.TransPanel();
            this.panel2 = new CustomControl.TransPanel();
            this.panel5 = new CustomControl.TransPanel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panel4 = new CustomControl.TransPanel();
            this.transPanel1 = new CustomControl.TransPanel();
            this.picMax = new CustomControl.SimpleImageButton();
            this.picClose = new CustomControl.SimpleImageButton();
            this.transPanel2 = new CustomControl.TransPanel();
            this.picClean = new CustomControl.SimpleImageButton();
            this.panel1 = new CustomControl.TransPanel();
            this.panel0.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.transPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.transPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClean)).BeginInit();
            this.SuspendLayout();
            // 
            // panel0
            // 
            this.panel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel0.Controls.Add(this.panel2);
            this.panel0.Controls.Add(this.panel1);
            this.panel0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel0.Location = new System.Drawing.Point(3, 3);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(494, 494);
            this.panel0.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 484);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rtbLog);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 32);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel5.Size = new System.Drawing.Size(494, 452);
            this.panel5.TabIndex = 3;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Info;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(10, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(474, 452);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel4.Controls.Add(this.transPanel1);
            this.panel4.Controls.Add(this.transPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(494, 32);
            this.panel4.TabIndex = 2;
            // 
            // transPanel1
            // 
            this.transPanel1.Controls.Add(this.picMax);
            this.transPanel1.Controls.Add(this.picClose);
            this.transPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.transPanel1.Location = new System.Drawing.Point(443, 0);
            this.transPanel1.Name = "transPanel1";
            this.transPanel1.Size = new System.Drawing.Size(51, 32);
            this.transPanel1.TabIndex = 0;
            // 
            // picMax
            // 
            this.picMax.BackColor = System.Drawing.Color.Transparent;
            this.picMax.Image = global::Bot.Properties.Resources.max16;
            this.picMax.Location = new System.Drawing.Point(6, 8);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(16, 16);
            this.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMax.TabIndex = 2;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bot.Properties.Resources.close16;
            this.picClose.Location = new System.Drawing.Point(28, 8);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(16, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // transPanel2
            // 
            this.transPanel2.Controls.Add(this.picClean);
            this.transPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.transPanel2.Location = new System.Drawing.Point(0, 0);
            this.transPanel2.Name = "transPanel2";
            this.transPanel2.Size = new System.Drawing.Size(32, 32);
            this.transPanel2.TabIndex = 0;
            // 
            // picClean
            // 
            this.picClean.BackColor = System.Drawing.Color.Transparent;
            this.picClean.Image = global::Bot.Properties.Resources.trash_16x16;
            this.picClean.Location = new System.Drawing.Point(10, 8);
            this.picClean.Name = "picClean";
            this.picClean.Size = new System.Drawing.Size(16, 16);
            this.picClean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClean.TabIndex = 2;
            this.picClean.TabStop = false;
            this.picClean.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 10);
            this.panel1.TabIndex = 0;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panel0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmLog";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLog_FormClosing);
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.panel0.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.transPanel1.ResumeLayout(false);
            this.transPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.transPanel2.ResumeLayout(false);
            this.transPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClean)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TransPanel panel0;
        private TransPanel panel1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private TransPanel panel2;
        private TransPanel panel5;
        private TransPanel panel4;
        private TransPanel transPanel1;
        private TransPanel transPanel2;
        private SimpleImageButton picClose;
        private SimpleImageButton picMax;
        private SimpleImageButton picClean;
    }
}