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
    public partial class frmLog : Form
    {
        private int cGrip = 12;      // Grip size
        private int cCaption = 32;   // Caption bar height;

        public frmLog()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            cCaption = panel4.Height;
            picClose.SetFocusBackgroundColor(Color.FromArgb(64, 64, 64));
            picMax.SetFocusBackgroundColor(Color.FromArgb(64, 64, 64));
            picClean.SetFocusBackgroundColor(Color.FromArgb(64, 64, 64));
            rtbLog.WordWrap = false;
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            update_log();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        public void update_log()
        {
            BeginInvoke(new Action(() =>
            {
                rtbLog.Text = Program.g_full_log;
                rtbLog.SelectionStart = rtbLog.Text.Length;
                rtbLog.ScrollToCaret();
            }));
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.g_show_log_frm = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.g_full_log = "";
            update_log();
        }

        private void picMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                picMax.Image = Properties.Resources.restore16;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                picMax.Image = Properties.Resources.max16;
            }
        }
    }
}
