
/**版权******************************************************************

            版权：  唧唧复唧唧木兰当户织
            作者：  唧唧复唧唧木兰当户织
            博客：  https://www.cnblogs.com/tlmbem/
        源码地址：  https://www.cnblogs.com/tlmbem/
            描述：  授权使用在 https://www.cnblogs.com/tlmbem/ 上有介绍，禁止删除下面的木兰诗。
            日期：  2020-10-28
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 提示信息窗口
    /// </summary>
    [Description("提示信息窗口")]
    public sealed class MessageBoxExt
    {
        #region 属性

        private static MessageBoxExtStyles _styles = new MessageBoxExtStyles();
        /// <summary>
        /// 提示信息窗口样式配置
        /// </summary>
        [Description("提示信息窗口样式配置")]
        public static MessageBoxExtStyles Styles
        {
            get
            {
                if (_styles == null)
                    _styles = new MessageBoxExtStyles();

                return _styles;
            }
            set
            {
                _styles = value;
            }
        }

        #endregion

        #region 公开方法

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, String.Empty, MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons)
        {
            return Show(owner, text, caption, buttons, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton)
        {
            return Show(owner, text, caption, buttons, icon, defaultButton, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton, MessageBoxExtStyles styles)
        {
            return Show(owner, text, caption, buttons, icon, defaultButton, styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton, MessageBoxExtStyles styles, Image customImage)
        {
            if (styles == null)
            {
                styles = Styles;
            }

            FormExt sfe = new FormExt();
            LabelExt label = new LabelExt();

            int text_captionBoxHeight = (int)(sfe.CaptionBox.Height * DotsPerInchHelper.DPIScale.XScale);
            Size scale_ico_size = new Size((int)(32 * DotsPerInchHelper.DPIScale.XScale), (int)(32 * DotsPerInchHelper.DPIScale.YScale));
            int scale_margin = (int)(6 * DotsPerInchHelper.DPIScale.XScale);//文本、图标边距
            int scale_btn_width = (int)(75 * DotsPerInchHelper.DPIScale.XScale);
            int scale_btn_height = (int)(24 * DotsPerInchHelper.DPIScale.YScale);
            int scale_btn_interval = (int)(10 * DotsPerInchHelper.DPIScale.XScale);

            Size scale_win_maxsize = new Size((int)(900 * DotsPerInchHelper.DPIScale.XScale), (int)(600 * DotsPerInchHelper.DPIScale.YScale));
            Size scale_win_minsize = new Size((int)(200 * DotsPerInchHelper.DPIScale.XScale), (int)(100 * DotsPerInchHelper.DPIScale.YScale));
            if (buttons == MessageBoxExtButtons.YesNoCancel || buttons == MessageBoxExtButtons.AbortRetryIgnore)
            {
                scale_win_minsize = new Size((int)(285 * DotsPerInchHelper.DPIScale.XScale), (int)(100 * DotsPerInchHelper.DPIScale.YScale));
            }

            Rectangle ico_rect = Rectangle.Empty;
            Rectangle text_rect = Rectangle.Empty;
            Rectangle btn_rect = Rectangle.Empty;

            Bitmap bmp = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bmp);
            Size text_size = Size.Ceiling(g.MeasureString(text, sfe.Font, int.MaxValue));
            g.Dispose();
            bmp.Dispose();

            Size win_size = Size.Empty;
            if (icon != MessageBoxExtIcon.None)
            {
                ico_rect = new Rectangle(scale_margin, text_captionBoxHeight + scale_margin, scale_ico_size.Width, scale_ico_size.Height);
                text_rect = new Rectangle(scale_margin + scale_ico_size.Width + scale_margin, text_captionBoxHeight + scale_margin, text_size.Width, text_size.Height);

                if (text_rect.Width > scale_win_maxsize.Width - scale_margin - scale_ico_size.Width - scale_margin - scale_margin)
                {
                    text_rect.Width = scale_win_maxsize.Width - scale_margin - scale_ico_size.Width - scale_margin - scale_margin;
                }
                if (text_rect.Width < scale_win_minsize.Width - scale_margin - scale_ico_size.Width - scale_margin - scale_margin)
                {
                    text_rect.Width = scale_win_minsize.Width - scale_margin - scale_ico_size.Width - scale_margin - scale_margin;
                }

                if (text_rect.Height > scale_win_maxsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight)
                {
                    text_rect.Height = scale_win_maxsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight;
                }
                if (text_rect.Height < scale_win_minsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight)
                {
                    text_rect.Height = scale_win_minsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight;
                }

                btn_rect = new Rectangle(scale_margin, text_rect.Bottom + scale_margin, scale_ico_size.Width + scale_margin + text_rect.Width, scale_btn_height);
                win_size = new Size(text_rect.Right + scale_margin, btn_rect.Bottom + scale_margin);
            }
            else
            {
                text_rect = new Rectangle(scale_margin, text_captionBoxHeight + scale_margin, text_size.Width, text_size.Height);

                if (text_rect.Width > scale_win_maxsize.Width - scale_margin - scale_margin)
                {
                    text_rect.Width = scale_win_maxsize.Width - scale_margin - scale_margin;
                }
                if (text_rect.Width < scale_win_minsize.Width - scale_margin - scale_margin)
                {
                    text_rect.Width = scale_win_minsize.Width - scale_margin - scale_margin;
                }

                if (text_rect.Height > scale_win_maxsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight)
                {
                    text_rect.Height = scale_win_maxsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight;
                }
                if (text_rect.Height < scale_win_minsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight)
                {
                    text_rect.Height = scale_win_minsize.Height - scale_margin - scale_btn_height - scale_margin - scale_margin - text_captionBoxHeight;
                }

                btn_rect = new Rectangle(scale_margin, text_rect.Bottom + scale_margin, scale_margin + text_rect.Width + scale_margin, scale_btn_height);
                win_size = new Size(text_rect.Right + scale_margin, btn_rect.Bottom + scale_margin);
            }

            sfe.BorderColor = styles.BorderColor;
            sfe.ShowInTaskbar = false;
            sfe.ShowIcon = false;
            sfe.ResizeType = FormExt.ResizeTypes.NoResize;
            sfe.StartPosition = FormStartPosition.CenterParent;
            sfe.TextOrientation = FormExt.TextOrientations.Left;
            sfe.Size = win_size;
            sfe.Text = caption;
            sfe.BackColor = styles.BackColor;
            sfe.CaptionBox.CloseBtn.Enabled = styles.CloseEnable;
            sfe.CaptionBox.MaxBtn.Enabled = false;
            sfe.CaptionBox.MinBtn.Enabled = false;
            sfe.CaptionBox.BackColor = styles.CaptionBackColor;
            sfe.ForeColor = styles.CaptionTextColor;
            sfe.SizeGripStyle = SizeGripStyle.Hide;

            label.Text = text;
            label.ForeColor = styles.TextColor;

            if (icon != MessageBoxExtIcon.None)
            {
                PictureBox ico_pb = new PictureBox() { Size = scale_ico_size, BackgroundImageLayout = ImageLayout.Zoom,  BackgroundImage = GetIco(icon, customImage)};
                sfe.Controls.Add(ico_pb);
                ico_pb.SetBounds(ico_rect.X, ico_rect.Y, ico_rect.Width, ico_rect.Height);
            }
            sfe.Controls.Add(label);
            label.SetBounds(text_rect.X, text_rect.Y, text_rect.Width, text_rect.Height);


            List<MessageBoxExtButton> btnList = new List<MessageBoxExtButton>();
            if (buttons == MessageBoxExtButtons.OK)
            {
                MessageBoxExtButton ok_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "确定" : styles.Button1Text, OK_Click, scale_btn_width, scale_btn_height, 0, styles);
                ok_btn.Location = new Point((int)((btn_rect.Width - ok_btn.Width) / 2),btn_rect.Y);

                sfe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);
            }
            else if (buttons == MessageBoxExtButtons.OKCancel)
            {
                MessageBoxExtButton ok_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "确定" : styles.Button1Text, OK_Click, scale_btn_width, scale_btn_height, 0, styles);
                ok_btn.Location = new Point(
                    btn_rect.X+(int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2),
                    btn_rect.Y);

                sfe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton cancel_btn = CreateButton(sfe, styles.Button2Text == String.Empty ? "取消" : styles.Button2Text, Cancel_Click, scale_btn_width, scale_btn_height, 1, styles);
                cancel_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2) + cancel_btn.Width + scale_btn_interval,
                    btn_rect.Y);

                sfe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.YesNo)
            {
                MessageBoxExtButton ok_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "是" : styles.Button1Text, OK_Click, scale_btn_width, scale_btn_height, 0, styles);
                ok_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2),
                    btn_rect.Y);

                sfe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton cancel_btn = CreateButton(sfe, styles.Button2Text == String.Empty ? "否" : styles.Button2Text, No_Click, scale_btn_width, scale_btn_height, 1, styles);
                cancel_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2) + cancel_btn.Width + scale_btn_interval,
                    btn_rect.Y);

                sfe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.YesNoCancel)
            {
                MessageBoxExtButton ok_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "是" : styles.Button1Text, OK_Click, scale_btn_width, scale_btn_height, 0, styles);
                ok_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2),
                     btn_rect.Y);

                sfe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton no_btn = CreateButton(sfe, styles.Button2Text == String.Empty ? "否" : styles.Button2Text, No_Click, scale_btn_width, scale_btn_height, 1, styles);
                no_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2) + no_btn.Width + scale_btn_interval,
                    btn_rect.Y);

                sfe.Controls.Add(no_btn);
                btnList.Add(no_btn);

                MessageBoxExtButton cancel_btn = CreateButton(sfe, styles.Button3Text == String.Empty ? "取消" : styles.Button3Text, Cancel_Click, scale_btn_width, scale_btn_height, 2, styles);
                cancel_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2) + cancel_btn.Width * 2 + scale_btn_interval * 2,
                    btn_rect.Y);

                sfe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.RetryCancel)
            {
                MessageBoxExtButton retry_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "重试" : styles.Button1Text, Retry_Click, scale_btn_width, scale_btn_height, 0, styles);
                retry_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2),
                    btn_rect.Y);

                sfe.Controls.Add(retry_btn);
                btnList.Add(retry_btn);

                MessageBoxExtButton cancel_btn = CreateButton(sfe, styles.Button2Text == String.Empty ? "取消" : styles.Button2Text, Cancel_Click, scale_btn_width, scale_btn_height, 1, styles);
                cancel_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 2 - scale_btn_interval) / 2) + cancel_btn.Width + scale_btn_interval,
                    btn_rect.Y);

                sfe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.AbortRetryIgnore)
            {
                MessageBoxExtButton abort_btn = CreateButton(sfe, styles.Button1Text == String.Empty ? "中止" : styles.Button1Text, Abort_Click, scale_btn_width, scale_btn_height, 0, styles);
                abort_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2),
                    btn_rect.Y);

                sfe.Controls.Add(abort_btn);
                btnList.Add(abort_btn);

                MessageBoxExtButton retry_btn = CreateButton(sfe, styles.Button2Text == String.Empty ? "重试" : styles.Button2Text, Retry_Click, scale_btn_width, scale_btn_height, 1, styles);
                retry_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2) + retry_btn.Width + scale_btn_interval,
                    btn_rect.Y);

                sfe.Controls.Add(retry_btn);
                btnList.Add(retry_btn);

                MessageBoxExtButton ignore_btn = CreateButton(sfe, styles.Button3Text == String.Empty ? "忽略" : styles.Button3Text, Ignore_Click, scale_btn_width, scale_btn_height, 2, styles);
                ignore_btn.Location = new Point(
                    btn_rect.X + (int)((btn_rect.Width - scale_btn_width * 3 - scale_btn_interval * 2) / 2) + ignore_btn.Width * 2 + scale_btn_interval * 2,
                    btn_rect.Y);

                sfe.Controls.Add(ignore_btn);
                btnList.Add(ignore_btn);
            }

            if (defaultButton == MessageBoxExtDefaultButton.Button1)
            {
                if (btnList[0] != null)
                {
                    btnList[0].Focus();
                    btnList[0].Select();
                }
            }
            else if (defaultButton == MessageBoxExtDefaultButton.Button2)
            {

                if (btnList[1] != null)
                {
                    btnList[0].Focus();
                    btnList[1].Select();
                }
            }
            else if (defaultButton == MessageBoxExtDefaultButton.Button3)
            {

                if (btnList[2] != null)
                {
                    btnList[0].Focus();
                    btnList[2].Select();
                }
            }

            sfe.ShowDialog(owner);

            if (sfe.Tag == null)
            {
                return DialogResult.None;
            }
            return (DialogResult)sfe.Tag;
        }

        #endregion

        #region 私有方法

        private static void OK_Click(object sender, EventArgs e)
        {
            FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
            fe.Tag = DialogResult.OK;
            fe.Hide();
            fe.Dispose();
        }

        private static void Yes_Click(object sender, EventArgs e)
        {
            FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
            fe.Tag = DialogResult.Yes;
            fe.Hide();
            fe.Dispose();
        }

        private static void No_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.No;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Cancel_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Cancel;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Abort_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Abort;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Retry_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Retry;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Ignore_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Ignore;
                fe.Hide();
                fe.Dispose();
            }
        }

        /// <summary>
        /// 创建按钮控件
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="text"></param>
        /// <param name="handler"></param>
        /// <param name="btn_w"></param>
        /// <param name="btn_h"></param>
        /// <returns></returns>
        private static MessageBoxExtButton CreateButton(FormExt fe, string text, EventHandler handler, int btn_w, int btn_h, int tabIndex, MessageBoxExtStyles style)
        {
            MessageBoxExtButton btn = new MessageBoxExtButton();
            btn.Text = text;
            btn.Size = new Size(btn_w, btn_h);
            btn.TabIndex = tabIndex;
            btn.TabStop = true;
            btn.Tag = fe;
            btn.BackColor = style.ButtonBackColor;
            btn.BackEnterColor = style.ButtonBackEnterColor;
            btn.ForeColor = style.ButtonTextColor;
            btn.Click += handler;
            return btn;
        }

        /// <summary>
        /// 获取图标图片
        /// </summary>
        /// <param name="ico">图标类别</param>
        /// <param name="image">自定义图片</param>
        /// <returns></returns>
        private static Image GetIco(MessageBoxExtIcon ico, Image image)
        {
            if (ico == MessageBoxExtIcon.Warning)
            {
                return global::WinformControlLibraryExtension.Resources.message_warning;
            }

            else if (ico == MessageBoxExtIcon.Question)
            {
                return global::WinformControlLibraryExtension.Resources.message_question;
            }
            else if (ico == MessageBoxExtIcon.Error)
            {
                return global::WinformControlLibraryExtension.Resources.message_error;
            }
            else if (ico == MessageBoxExtIcon.Custom)
            {
                return image;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        public class MessageBoxExtButton : Control
        {
            #region 属性

            /// <summary>
            /// 边框颜色
            /// </summary>
            [Description("边框颜色")]
            private Color borderColor = Color.White;
            internal Color BorderColor
            {
                get
                {
                    return this.borderColor;
                }
                set
                {
                    if (this.borderColor == value)
                        return;

                    this.borderColor = value;
                    this.Invalidate();
                }
            }

            /// <summary>
            /// 背景颜色（鼠标进入）
            /// </summary>
            [Description("背景颜色（鼠标进入）")]
            private Color backEnterColor = Color.White;
            internal Color BackEnterColor
            {
                get
                {
                    return this.backEnterColor;
                }
                set
                {
                    if (this.backEnterColor == value)
                        return;

                    this.backEnterColor = value;
                    this.Invalidate();
                }
            }

            #endregion

            #region 字段

            /// <summary>
            /// 控件Tab状态
            /// </summary>
            private bool tabStatus = false;
            /// <summary>
            /// 鼠标是否进入
            /// </summary>
            private bool isEnter = false;

            #endregion

            #region 重写

            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);

                this.tabStatus = true;
                this.Invalidate();
            }

            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);

                this.tabStatus = false;
                this.Invalidate();
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);

                this.isEnter = true;
                this.Invalidate();
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);

                this.isEnter = false;
                this.Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;

                #region 背景

                SolidBrush back_sb = new SolidBrush(this.isEnter ? this.BackEnterColor : this.BackColor);
                g.FillRectangle(back_sb, this.ClientRectangle);
                back_sb.Dispose();

                #endregion

                #region 文本

                int padding = 2;
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                StringFormat text_sf = new StringFormat() { FormatFlags = StringFormatFlags.NoWrap, Trimming = StringTrimming.None, LineAlignment = StringAlignment.Center };
                Size text_size = Size.Ceiling(g.MeasureString(this.Text, this.Font, this.Width - padding * 2, text_sf));

                Rectangle text_rect = new Rectangle(
                    this.ClientRectangle.X + padding + (this.ClientRectangle.Width - padding * 2 - text_size.Width) / 2,
                     this.ClientRectangle.Y + padding + (this.ClientRectangle.Height - padding * 2 - text_size.Height) / 2,
                     text_size.Width,
                     text_size.Height
                     );
                g.DrawString(this.Text, this.Font, text_sb, text_rect, text_sf);

                text_sb.Dispose();
                text_sf.Dispose();

                #endregion

                #region tab边框
                if (this.tabStatus)
                {
                    Pen tabborder_pen = new Pen(Color.FromArgb(150, this.BorderColor), 1);
                    tabborder_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawRectangle(tabborder_pen, new Rectangle(this.ClientRectangle.X + padding, this.ClientRectangle.Y + padding, this.ClientRectangle.Width - padding * 2 - 1, this.ClientRectangle.Height - padding * 2 - 1));
                    tabborder_pen.Dispose();
                }
                #endregion
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (this.DesignMode)
                {
                    return base.ProcessDialogKey(keyData);
                }

                if (this.tabStatus)
                {
                    #region Enter
                    if (keyData == Keys.Enter)
                    {
                        this.InvokeOnClick(this, (EventArgs)(new MouseEventArgs(MouseButtons.Left, 1, this.ClientRectangle.X + this.ClientRectangle.Width / 2, this.ClientRectangle.Y + this.ClientRectangle.Height / 2, 0)));

                        return false;
                    }
                    #endregion
                }

                return base.ProcessDialogKey(keyData);
            }

            #endregion

        }

        #endregion

    }

    #region 类

    /// <summary>
    /// 提示框样式
    /// </summary>
    [Description("提示框样式")]
    public class MessageBoxExtStyles
    {

        private bool closeEnable =false;
        /// <summary>
        /// 弹窗是否显示关闭按钮
        /// </summary>
        [Description("弹窗是否显示关闭按钮")]
        public bool CloseEnable
        {
            get
            {
                return this.closeEnable;
            }
            set
            {
                if (this.closeEnable == value)
                    return;

                this.closeEnable = value;
            }
        }

        private Color borderColor = Color.FromArgb(137, 158, 136);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor == value)
                    return;

                this.borderColor = value;
            }
        }

        private Color backColor = Color.White;
        /// <summary>
        /// 背景颜色
        /// </summary>
        [Description("背景颜色")]
        public Color BackColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                if (this.backColor == value)
                    return;

                this.backColor = value;
            }
        }

        private Color captionBackColor = Color.FromArgb(137, 165, 136);
        /// <summary>
        /// 标题栏背景颜色
        /// </summary>
        [Description("标题栏背景颜色")]
        public Color CaptionBackColor
        {
            get
            {
                return this.captionBackColor;
            }
            set
            {
                if (this.captionBackColor == value)
                    return;

                this.captionBackColor = value;
            }
        }

        private Color captionTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 标题文本颜色
        /// </summary>
        [Description("标题文本颜色")]
        public Color CaptionTextColor
        {
            get
            {
                return this.captionTextColor;
            }
            set
            {
                if (this.captionTextColor == value)
                    return;

                this.captionTextColor = value;
            }
        }

        private Color textColor = Color.Gray;
        /// <summary>
        /// 信息文本颜色
        /// </summary>
        [Description("信息文本颜色")]
        public Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                if (this.textColor == value)
                    return;

                this.textColor = value;
            }
        }

        private Color buttonBackColor = Color.FromArgb(137, 165, 136);
        /// <summary>
        /// 按钮背景颜色
        /// </summary>
        [Description("按钮背景颜色")]
        public Color ButtonBackColor
        {
            get
            {
                return this.buttonBackColor;
            }
            set
            {
                if (this.buttonBackColor == value)
                    return;

                this.buttonBackColor = value;
            }
        }

        private Color buttonBackEnterColor = Color.FromArgb(123, 148, 122);
        /// <summary>
        /// 按钮背景颜色(鼠标进入)
        /// </summary>
        [Description("按钮背景颜色(鼠标进入)")]
        public Color ButtonBackEnterColor
        {
            get
            {
                return this.buttonBackEnterColor;
            }
            set
            {
                if (this.buttonBackEnterColor == value)
                    return;

                this.buttonBackEnterColor = value;
            }
        }

        private Color buttonTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 按钮文本颜色
        /// </summary>
        [Description("按钮文本颜色")]
        public Color ButtonTextColor
        {
            get
            {
                return this.buttonTextColor;
            }
            set
            {
                if (this.buttonTextColor == value)
                    return;

                this.buttonTextColor = value;
            }
        }

        private string button1Text = String.Empty;
        /// <summary>
        /// Button1自定义文本
        /// </summary>
        [Description("Button1自定义文本")]
        public string Button1Text
        {
            get
            {
                return this.button1Text;
            }
            set
            {
                if (this.button1Text == value)
                    return;

                this.button1Text = value.Trim();
            }
        }

        private string button2Text = String.Empty;
        /// <summary>
        /// Button2自定义文本
        /// </summary>
        [Description("Button2自定义文本")]
        public string Button2Text
        {
            get
            {
                return this.button2Text;
            }
            set
            {
                if (this.button2Text == value)
                    return;

                this.button2Text = value.Trim();
            }
        }

        private string button3Text = String.Empty;
        /// <summary>
        /// Button3自定义文本
        /// </summary>
        [Description("Button3自定义文本")]
        public string Button3Text
        {
            get
            {
                return this.button3Text;
            }
            set
            {
                if (this.button3Text == value)
                    return;

                this.button3Text = value.Trim();
            }
        }

    }

    #endregion

    #region 枚举

    /// <summary>
    /// 提示按钮类型
    /// </summary>
    [Description("提示按钮类型")]
    public enum MessageBoxExtButtons
    {
        /// <summary>
        /// 消息框包含“确定”按钮。
        /// </summary>
        OK = 0,
        /// <summary>
        /// 消息框包含“确定”和“取消”按钮。
        /// </summary>
        OKCancel = 1,
        /// <summary>
        /// 消息框包含“中止”、“重试”和“忽略”按钮。
        /// </summary>
        AbortRetryIgnore = 2,
        /// <summary>
        /// 消息框包含“是”、“否”和“取消”按钮。
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// 消息框包含“是”和“否”按钮。
        /// </summary>
        YesNo = 4,
        /// <summary>
        /// 消息框包含“重试”和“取消”按钮。
        /// </summary>
        RetryCancel = 5
    }

    /// <summary>
    /// 提示框图标（32x32）
    /// </summary>
    [Description("提示框图标（32x32）")]
    public enum MessageBoxExtIcon
    {
        /// <summary>
        /// 不包含符号
        /// </summary>
        None = 0,
        /// <summary>
        /// 疑问
        /// </summary>
        Question,
        /// <summary>
        /// 错区
        /// </summary>
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }

    /// <summary>
    /// 默认激活按钮
    /// </summary>
    [Description("默认激活按钮")]
    public enum MessageBoxExtDefaultButton
    {
        /// <summary>
        /// 第一个按钮
        /// </summary>
        Button1,
        /// <summary>
        /// 第二个按钮
        /// </summary>
        Button2,
        /// <summary>
        /// 第三个按钮
        /// </summary>
        Button3
    }

    #endregion

}
