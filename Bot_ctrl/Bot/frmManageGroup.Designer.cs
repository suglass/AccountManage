namespace Bot
{
    partial class frmManageGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageGroup));
            this.txt_group_name = new System.Windows.Forms.TextBox();
            this.btnCreateGrp = new System.Windows.Forms.Button();
            this.btnDelGrp = new System.Windows.Forms.Button();
            this.cbxGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_group_name
            // 
            this.txt_group_name.Location = new System.Drawing.Point(49, 43);
            this.txt_group_name.Name = "txt_group_name";
            this.txt_group_name.Size = new System.Drawing.Size(144, 20);
            this.txt_group_name.TabIndex = 0;
            this.txt_group_name.TextChanged += new System.EventHandler(this.txt_group_name_TextChanged);
            // 
            // btnCreateGrp
            // 
            this.btnCreateGrp.Location = new System.Drawing.Point(268, 43);
            this.btnCreateGrp.Name = "btnCreateGrp";
            this.btnCreateGrp.Size = new System.Drawing.Size(123, 23);
            this.btnCreateGrp.TabIndex = 1;
            this.btnCreateGrp.Text = "Create Group";
            this.btnCreateGrp.UseVisualStyleBackColor = true;
            this.btnCreateGrp.Click += new System.EventHandler(this.btnCreateGrp_Click);
            // 
            // btnDelGrp
            // 
            this.btnDelGrp.Location = new System.Drawing.Point(268, 97);
            this.btnDelGrp.Name = "btnDelGrp";
            this.btnDelGrp.Size = new System.Drawing.Size(123, 23);
            this.btnDelGrp.TabIndex = 2;
            this.btnDelGrp.Text = "Delete Group";
            this.btnDelGrp.UseVisualStyleBackColor = true;
            this.btnDelGrp.Click += new System.EventHandler(this.btnDelGrp_Click);
            // 
            // cbxGroup
            // 
            this.cbxGroup.FormattingEnabled = true;
            this.cbxGroup.Location = new System.Drawing.Point(49, 98);
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.Size = new System.Drawing.Size(144, 21);
            this.cbxGroup.TabIndex = 3;
            this.cbxGroup.TextChanged += new System.EventHandler(this.cbxGroup_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input group name to create";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select group to delete";
            // 
            // frmManageGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 147);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxGroup);
            this.Controls.Add(this.btnDelGrp);
            this.Controls.Add(this.btnCreateGrp);
            this.Controls.Add(this.txt_group_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(451, 186);
            this.MinimumSize = new System.Drawing.Size(451, 186);
            this.Name = "frmManageGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Group";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmManageGroup_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_group_name;
        private System.Windows.Forms.Button btnCreateGrp;
        private System.Windows.Forms.Button btnDelGrp;
        private System.Windows.Forms.ComboBox cbxGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}