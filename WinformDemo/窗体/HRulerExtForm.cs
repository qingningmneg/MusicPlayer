using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class HRulerExtForm : Form
    {
        public HRulerExtForm()
        {
            InitializeComponent();
        }

        private void HRulerExtForm_Load(object sender, EventArgs e)
        {
            this.panel3.Size = new Size(300, 300);
            this.hRulerExt1.RealityWidth = this.panel3.Size.Width;
            this.hRulerExt1.DisplayWidth = this.panel3.Size.Width;
            this.hRulerExt1.MasterStartPoint = this.panel3.Location.X;
            this.vRulerExt1.RealityHeight = this.panel3.Size.Height;
            this.vRulerExt1.DisplayHeight = this.panel3.Size.Height;
            this.vRulerExt1.MasterStartPoint = this.panel3.Location.Y;

            this.panel3.MouseWheel += this.Panel3_MouseWheel;
            this.panel2.MouseWheel += this.Panel3_MouseWheel;
            this.panel3.Paint += Panel3_Paint;
            this.panel3.Resize += Panel3_Resize;
        }

        private void Panel3_Resize(object sender, EventArgs e)
        {
            this.panel3.Invalidate();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            string str = "可以鼠标移动缩放";
            Size text_size = e.Graphics.MeasureString(str,this.panel3.Font,int.MaxValue).ToSize();
            SolidBrush text_sb = new SolidBrush(Color.White);
            e.Graphics.DrawString(str, this.panel3.Font, text_sb,(this.panel3.ClientRectangle.Width-text_size.Width)/2, (this.panel3.ClientRectangle.Height - text_size.Height) / 2);
            text_sb.Dispose();
        }

        private void Panel3_MouseWheel(object sender, MouseEventArgs e)
        {
            Size si = this.panel3.Size;
            int value = e.Delta / 120 * 4;
            Size tmp = new Size(this.panel3.Width+ value, this.panel3.Height+ value);
            tmp = new Size(Math.Max(100, tmp.Width),Math.Max(100,tmp.Height));
            tmp = new Size(Math.Min(300, tmp.Width), Math.Min(300, tmp.Height));


            this.panel3.Size = tmp;
            this.panel3.Location=new Point(this.panel3.Location.X - (si.Width- tmp.Width) / 2, this.panel3.Location.Y - (si.Height - tmp.Height) / 2);
            this.hRulerExt1.MasterStartPoint = this.panel3.Location.X;
            this.vRulerExt1.MasterStartPoint = this.panel3.Location.Y;
            this.hRulerExt1.DisplayWidth = tmp.Width;
            this.vRulerExt1.DisplayHeight = tmp.Height;
        }

        bool isdown = false;
        Point control_point = Point.Empty;
        Point downpoint = Point.Empty;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isdown = true;
                downpoint = Control.MousePosition;
                control_point = this.panel3.Location;

            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isdown = false;
                downpoint = Point.Empty;
                control_point = Point.Empty;
            }
        }

        private void panel3_Leave(object sender, EventArgs e)
        {
            this.isdown = false;
            downpoint = Point.Empty;
            control_point = Point.Empty;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isdown)
            {
                Point current = Control.MousePosition;

                Point tmp = new Point(this.control_point.X+current.X - this.downpoint.X, this.control_point.Y+current.Y - this.downpoint.Y);

                tmp = new Point(Math.Max(0,tmp.X),Math.Max(0,tmp.Y));

                tmp = new Point(Math.Min(this.panel2.Width- this.panel3.Width, tmp.X), Math.Min(this.panel2.Height - this.panel3.Height, tmp.Y));

                this.panel3.Location = tmp;
                this.hRulerExt1.MasterStartPoint = tmp.X;
                this.vRulerExt1.MasterStartPoint = tmp.Y;
            }
          
        }
    }
}
