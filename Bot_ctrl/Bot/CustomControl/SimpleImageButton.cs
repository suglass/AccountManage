using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public class SimpleImageButton : PictureBox
    {
        private bool m_is_focused = false;
        private Point m_original_location = new Point();
        private Color m_focus_bk_color = Color.LightYellow;
        public SimpleImageButton()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                m_is_focused = true;
                UpdateImage();
            });
            this.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                m_is_focused = false;
                UpdateImage();
            });
            this.MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                m_original_location = this.Location;
                this.Left += 1;
                this.Top += 1;
                UpdateImage();
            });
            this.MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                this.Location = m_original_location;
                UpdateImage();
            });
            /*this.EnabledChanged += new EventHandler((object sender, EventArgs e) =>
            {
                if(this.Enabled)
                {
                    this.BackColor = Color.Transparent;
                    this.BorderStyle = BorderStyle.None;
                    this.Image = (Image)Resources.ResourceManager.GetObject()
                }
                else
                {

                }
            });*/
        }
        private void InitializeComponent()
        {
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
        }
        public void SetFocusBackgroundColor(Color color)
        {
            m_focus_bk_color = color;
            Invalidate();
        }
        private void UpdateImage()
        {
            if (m_is_focused)
            {
                this.BackColor = m_focus_bk_color;
                //this.BorderStyle = BorderStyle.FixedSingle;
                this.BorderStyle = BorderStyle.None;
            }
            else
            {
                this.BackColor = Color.Transparent;
                this.BorderStyle = BorderStyle.None;
            }
            Invalidate();
        }
    }
}
