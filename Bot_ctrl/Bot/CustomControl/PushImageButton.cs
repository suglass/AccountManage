using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bot.Properties;

namespace CustomControl
{
    public class PushImageButton : PictureBox
    {
        private bool m_is_focused = false;
        private Point m_original_location = new Point();

        private bool _Pushed = false;
        public bool Pushed
        {
            get { return _Pushed; }
            set
            {
                _Pushed = value;
                Enabled = !_Pushed;
                UpdateImage();
            }
        }

        private Image _ImageNormal = null;
        public Image ImageNormal
        {
            set
            {
                _ImageNormal = value;
                UpdateImage();
            }
        }
        private Image _ImageFocus = null;
        public Image ImageFocus
        {
            set { _ImageFocus = value; }
        }
        private Image _ImagePush = null;
        public Image ImagePush
        {
            set
            {
                ImagePush = value;
                UpdateImage();
            }
        }
        private void InitializeComponent()
        {
            this.Size = new System.Drawing.Size(90, 90);
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.TabIndex = 0;
            this.TabStop = false;
        }
        private void UpdateImage()
        {
            if (m_is_focused && _ImageFocus != null)
            {
                if (this.Size != _ImageFocus.Size)
                    this.Size = _ImageFocus.Size;
                this.Image = _ImageFocus;
            }
            else
            {
                if (_Pushed && _ImagePush != null)
                {
                    if (this.Size != _ImagePush.Size)
                        this.Size = _ImagePush.Size;
                    this.Image = _ImagePush;
                }
                else if (_ImageNormal != null)
                {
                    if (this.Size != _ImageNormal.Size)
                        this.Size = _ImageNormal.Size;
                    this.Image = _ImageNormal;
                }
            }
            Invalidate();
        }
        public PushImageButton()
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
                this.Left += 3;
                this.Top += 3;
                UpdateImage();
            });
            this.MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                this.Location = m_original_location;
                //Pushed = !Pushed;
                UpdateImage();
            });
        }
        public void SetImages(string image_base_src_name)
        {
            try
            {
                _ImageNormal = (Image)Resources.ResourceManager.GetObject(image_base_src_name);
                _ImageFocus = (Image)Resources.ResourceManager.GetObject(image_base_src_name + "_f");
                _ImagePush = (Image)Resources.ResourceManager.GetObject(image_base_src_name + "_s");
                UpdateImage();
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Exception Error ({0}): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, exception.Message));
            }
        }
    }
}
