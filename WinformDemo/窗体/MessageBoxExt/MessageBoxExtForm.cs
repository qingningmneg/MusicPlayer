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
    public partial class MessageBoxExtForm : Form
    {
        public MessageBoxExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"OK", "提示", MessageBoxExtButtons.OK);
            this.label2.Text = da.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"OKCancel", "提示", MessageBoxExtButtons.OKCancel, MessageBoxExtIcon.Error);
            this.label2.Text = da.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"YesNo", "提示", MessageBoxExtButtons.YesNo, MessageBoxExtIcon.Question);
            this.label2.Text = da.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"YesNoCancel", "提示", MessageBoxExtButtons.YesNoCancel, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button3);
            this.label2.Text = da.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"RetryCancel", "提示", MessageBoxExtButtons.RetryCancel, MessageBoxExtIcon.Custom, MessageBoxExtDefaultButton.Button2, null, global::WinformDemo.Properties.Resources.message_custom);
            this.label2.Text = da.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxExtStyles style = new MessageBoxExtStyles()
            {
                BorderColor = Color.SteelBlue,
                ButtonBackColor = Color.LightSkyBlue,
                ButtonBackEnterColor = Color.SteelBlue,
                CaptionBackColor = Color.LightSkyBlue
            };
            DialogResult da = MessageBoxExt.Show(this, @"AbortRetryIgnore", "提示", MessageBoxExtButtons.AbortRetryIgnore, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, style);
            this.label2.Text = da.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBoxExtStyles style = new MessageBoxExtStyles()
            {
                 CloseEnable=true,
                BorderColor = Color.SteelBlue,
                ButtonBackColor = Color.LightSkyBlue,
                ButtonBackEnterColor = Color.SteelBlue,
                CaptionBackColor = Color.LightSkyBlue,
                Button1Text = "同意",
                Button2Text = "不同意"
            };
            DialogResult da = MessageBoxExt.Show(this, @"
Label label = new Label();
            label.AutoSize = false;
            label.Text = text;
            label.ForeColor = styles.TextColor;
            label.ImageAlign = ContentAlignment.MiddleLeft;
            label.TextAlign = ContentAlignment.MiddleCenter;
            if (icon != MessageBoxExtIcon.None)
            {
                label.Image = GetIco(icon, customImage);
            }
            label.SetBounds(fe.ClientRectangle.X + text_padding, fe.ClientRectangle.Y + text_padding + fe.CaptionBox.Height, (int)text_sizef.Width, (int)text_sizef.Height);
            fe.Controls.Add(label);



            List<MessageBoxExtButton> btnList = new List<MessageBoxExtButton>();
            if (buttons == MessageBoxExtButtons.OK)
            {
                MessageBoxExtButton ok_btn = CreateButton(fe, styles.Button1Text == String.Empty ? 确定 : styles.Button1Text, OK_Click, btn_w, btn_h, 0, styles);
                ok_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - ok_btn.Width) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

            fe.Controls.Add(ok_btn);
            btnList.Add(ok_btn);
            ", "提示", MessageBoxExtButtons.YesNo, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button1, style);
            this.label2.Text = da.ToString();
        }
    }
}
