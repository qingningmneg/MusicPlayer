﻿
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 颜色选择美化控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("颜色选择美化控件")]
    [DefaultProperty("ColorPicker")]
    [Designer(typeof(ColorExtDesigner))]
    public class ColorExt : Control
    {
        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private bool readOnly = false;
        /// <summary>
        /// 是否只读
        /// </summary>
        [DefaultValue(false)]
        [Description("是否只读")]
        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                if (this.readOnly == value)
                    return;
                this.readOnly = value;
            }
        }

        private bool borderShow = true;
        /// <summary>
        /// 是否显示边框
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示边框")]
        public bool BorderShow
        {
            get { return this.borderShow; }
            set
            {
                if (this.borderShow == value)
                    return;
                this.borderShow = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Invalidate();
            }
        }

        private ColorImageAligns colorImageAlign = ColorImageAligns.Right;
        /// <summary>
        /// 颜色图片位置
        /// </summary>
        [DefaultValue(ColorImageAligns.Right)]
        [Description("颜色图片位置")]
        public ColorImageAligns ColorImageAlign
        {
            get { return this.colorImageAlign; }
            set
            {
                if (this.colorImageAlign == value)
                    return;
                this.colorImageAlign = value;
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private ColorTextAligns colorTextAlign = ColorTextAligns.Right;
        /// <summary>
        /// 颜色文本位置
        /// </summary>
        [DefaultValue(ColorTextAligns.Right)]
        [Description("颜色文本位置")]
        public ColorTextAligns ColorTextAlign
        {
            get { return this.colorTextAlign; }
            set
            {
                if (this.colorTextAlign == value)
                    return;
                this.colorTextAlign = value;
                this.colorTextBox.TextAlign = (value == ColorTextAligns.Left) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
                if (this.ColorStyle == ColorStyles.ColorPanel)
                {
                    this.Invalidate();
                }
            }
        }

        private ColorStyles colorStyle = ColorStyles.Editor;
        /// <summary>
        /// 颜色输入框类型
        /// </summary>
        [DefaultValue(ColorStyles.Editor)]
        [Description("颜色输入框类型")]
        public ColorStyles ColorStyle
        {
            get { return this.colorStyle; }
            set
            {
                if (this.colorStyle == value)
                    return;
                this.colorStyle = value;
                this.UpdateColorStyle();
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private ColorPickerExt colorPicker = null;
        /// <summary>
        /// 颜色选择面板
        /// </summary>
        [Browsable(true)]
        [Description("颜色选择面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorPickerExt ColorPicker
        {
            get { return this.colorPicker; }
            set { this.colorPicker = value; }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        [DefaultValue(typeof(Color), "255,255,255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (this.colorTextBox != null)
                {
                    this.colorTextBox.BackColor = value;
                }
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "105, 105, 105")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                if (this.colorTextBox != null)
                {
                    this.colorTextBox.ForeColor = value;
                }
                this.Invalidate();
            }
        }

        protected override Cursor DefaultCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(130, 24);
            }
        }

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        protected bool activatedState = false;

        /// <summary>
        /// 背景图
        /// </summary>
        private static Image back_image = Resources.squaresback;

        /// <summary>
        /// 颜色面板显示状态
        /// </summary>
        private bool displayStatus = false;

        private ToolStripDropDown tsdd = null;

        private ToolStripControlHost tsch = null;

        private ColorExtTextBox colorTextBox = null;

        private int image_width = 18;

        private int image_height = 18;

        private int image_padding = 2;

        private int border = 1;

        /// <summary>
        /// 控件颜色存放
        /// </summary>
        private string colorstr = null;

        private Rectangle image_rect = Rectangle.Empty;
        private Rectangle color_rect = Rectangle.Empty;

        private float scale = 0f;

        #endregion

        public ColorExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.SuspendLayout();

            this.BackColor = Color.FromArgb(255, 255, 255);
            this.ForeColor = Color.FromArgb(105, 105, 105);
            this.Font = new Font("微软雅黑", 9);

            this.ColorPicker = new ColorPickerExt();

            this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };

            this.tsdd.Closed += new ToolStripDropDownClosedEventHandler(this.tsdd_Closed);
            this.ColorPicker.BottomBarConfirmClick += new ColorPickerExt.BottomBarIiemClickEventHandler(this.ColorPicker_ConfirmClick);
            this.ColorPicker.BottomBarClearClick += new ColorPickerExt.BottomBarIiemClickEventHandler(this.ColorPicker_ClearClick);
            this.ColorPicker.ColorValueChanged += new ColorPickerExt.ColorValueChangedEventHandler(this.ColorPicker_ValueChanged);

            this.colorTextBox = new ColorExtTextBox(this, this.DefaultSize.Height, this.image_width, this.image_padding, this.border);
            this.colorTextBox.BackColor = this.BackColor;
            this.colorTextBox.ForeColor = this.ForeColor;
            this.colorTextBox.ImeMode = ImeMode.Off;
            this.colorTextBox.TextAlign = HorizontalAlignment.Right;
            this.colorTextBox.TabStop = false;
            this.colorTextBox.Cursor = Cursors.Default;
            this.colorTextBox.BorderStyle = BorderStyle.None;
            this.colorTextBox.ForeColor = Color.FromArgb(105, 105, 105);
            this.colorTextBox.LostFocus += new EventHandler(this.colorTextBox_LostFocus);
            this.colorTextBox.TextChanged += new EventHandler(this.colorTextBox_TextChanged);
            this.Controls.Add(this.colorTextBox);

            this.ResumeLayout();

            this.UpdateLocationSize();
            this.Invalidate();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 控件激活状态虚线框
            if (this.ColorStyle == ColorStyles.ColorPanel && this.activatedState)
            {
                Pen backborder_pen = new Pen(this.BorderColor, 1);
                backborder_pen.DashStyle = DashStyle.Dash;
                Rectangle rect = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 4 - this.border, this.ClientRectangle.Height - 4 - this.border);
                g.DrawRectangle(backborder_pen, rect);
                backborder_pen.Dispose();
            }
            #endregion

            #region 图片、文本

            ImageAttributes back_image_ia = new ImageAttributes();//背景图平铺 
            back_image_ia.SetWrapMode(WrapMode.Tile);
            g.DrawImage(back_image, image_rect, 0, 0, image_rect.Width, image_rect.Height, GraphicsUnit.Pixel, back_image_ia);
            SolidBrush argb_sb = new SolidBrush(this.ColorPicker.ColorValue);
            g.FillRectangle(argb_sb, image_rect);
            argb_sb.Dispose();
            back_image_ia.Dispose();

            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                string argb_format = this.colorstr;
                SolidBrush color_sb = new SolidBrush(this.ForeColor);
                StringFormat color_sf = new StringFormat() { Alignment = (this.ColorTextAlign == ColorTextAligns.Left ? StringAlignment.Near : StringAlignment.Far), LineAlignment = StringAlignment.Center, Trimming = StringTrimming.None, FormatFlags = StringFormatFlags.NoWrap };
                g.DrawString(argb_format, this.Font, color_sb, new Rectangle(color_rect.X, color_rect.Y, color_rect.Width - 2, color_rect.Height), color_sf);
                color_sb.Dispose();
                color_sf.Dispose();
            }
            #endregion

            #region 边框
            if (this.BorderShow)
            {
                Pen backborder_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(backborder_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
                backborder_pen.Dispose();
            }
            #endregion

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                this.Invalidate();
            }
            else
            {
                this.colorTextBox.Select();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.ColorStyle == ColorStyles.ColorPanel)
            {
                this.Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.displayStatus == true)
            {
                this.tsdd.Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.ReadOnly)
                return true;

            if (this.activatedState)
            {
                #region Enter
                if (keyData == Keys.Enter)
                {
                    this.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2, 0));
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.ColorStyle == ColorStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.ColorStyle == ColorStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.Select();

            if (e.Button == MouseButtons.Left)
            {
                if (!this.displayStatus)
                {
                    this.CreateToolStripControlHost();
                    tsdd.Show(this.PointToScreen(new Point(0, this.Height + 2)));
                    this.ColorPicker.InitializeColor();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.UpdateLocationSize();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            int scale_height = (int)(this.DefaultSize.Height * DotsPerInchHelper.DPIScale.XScale);
            base.SetBoundsCore(x, y, width, scale_height, specified);
            this.Invalidate();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.ColorPicker != null)
                    this.ColorPicker.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 私有方法

        #region 颜色面板事件

        /// <summary>
        /// 颜色面板清除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPicker_ClearClick(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.Select();
            this.tsdd.Close();
        }

        /// <summary>
        /// 颜色面板确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPicker_ConfirmClick(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.Select();
            this.tsdd.Close();
        }

        /// <summary>
        /// 颜色面板值更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPicker_ValueChanged(object sender, EventArgs e)
        {
            this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
            this.UpdateLocalColorUI();
        }

        /// <summary>
        /// 隐藏颜色面板弹层事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsdd_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.displayStatus = false;
            this.Invalidate();
        }

        #endregion

        #region 日期输入框 事件

        private void colorTextBox_LostFocus(object sender, EventArgs e)
        {
            Color? color = this.ColorPicker.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.ColorPicker.UpdateDateValueNotInvalidate(color.Value);
            }
            else
            {
                this.SetLocalColorByColorPicker(this.ColorPicker.ColorValue);
                this.UpdateLocalColorUI();
            }
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            Color? color = this.ColorPicker.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.ColorPicker.UpdateDateValueNotInvalidate(color.Value);
            }
        }

        #endregion

        /// <summary>
        /// 更新ToolStripControlHost
        /// </summary>
        private void CreateToolStripControlHost()
        {
            if (this.scale != DotsPerInchHelper.DPIScale.XScale)
            {
                tsdd.Items.Clear();
                this.tsch = new ToolStripControlHost(this.ColorPicker) { Margin = Padding.Empty, Padding = Padding.Empty };
                tsdd.Items.Add(this.tsch);
            }
        }

        /// <summary>
        /// 更新颜色输入框Location、Size
        /// </summary>
        private void UpdateLocationSize()
        {
            int scale_image_width = (int)(this.image_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_image_height = (int)(this.image_height * DotsPerInchHelper.DPIScale.XScale);
            if (this.ColorImageAlign == ColorImageAligns.Right)
            {
                this.image_rect = new Rectangle(this.ClientRectangle.Right - scale_image_width - this.image_padding * 2, this.ClientRectangle.Y + (this.ClientRectangle.Height - scale_image_height) / 2, scale_image_width, scale_image_height);
                this.color_rect = new Rectangle(this.ClientRectangle.X + this.border, this.ClientRectangle.Y, this.ClientRectangle.Width - scale_image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);
            }
            else
            {
                this.image_rect = new Rectangle(this.ClientRectangle.X + this.image_padding + this.border, this.ClientRectangle.Y + (this.ClientRectangle.Height - scale_image_height) / 2, scale_image_width, scale_image_height);
                this.color_rect = new Rectangle(this.ClientRectangle.X + scale_image_width + this.image_padding * 2, this.ClientRectangle.Y, this.ClientRectangle.Width - scale_image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);
            }

            this.colorTextBox.Location = new Point(0, 0);
        }

        /// <summary>
        /// 更新颜色输入框功能类型
        /// </summary>
        private void UpdateColorStyle()
        {
            if (this.ColorStyle == ColorStyles.Editor)
            {
                this.colorTextBox.Enabled = true;
                this.colorTextBox.Visible = true;
            }
            else
            {
                this.colorTextBox.Enabled = false;
                this.colorTextBox.Visible = false;
            }

        }

        /// <summary>
        /// 设置控件颜色根据面板颜色
        /// </summary>
        /// <param name="color"></param>
        private void SetLocalColorByColorPicker(Color? color)
        {
            this.colorstr = String.Format("{0},{1},{2},{3}", color.Value.A, color.Value.R, color.Value.G, color.Value.B);
        }

        /// <summary>
        /// 更新颜色控件颜色UI
        /// </summary>
        private void UpdateLocalColorUI()
        {
            this.colorTextBox.Text = this.colorstr;

            this.Invalidate();
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 颜色图片位置
        /// </summary>
        [Description("颜色图片位置")]
        public enum ColorImageAligns
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 颜色文本位置
        /// </summary>
        [Description("颜色文本位置")]
        public enum ColorTextAligns
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 颜色输入框类型
        /// </summary>
        [Description("颜色输入框类型")]
        public enum ColorStyles
        {
            /// <summary>
            /// 可编辑
            /// </summary>
            Editor,
            /// <summary>
            /// 只能颜色面板选择
            /// </summary>
            ColorPanel
        }

        #endregion
    }

    /// <summary>
    /// 颜色文本输入框
    /// </summary>
    [ToolboxItem(false)]
    [Description("颜色文本输入框")]
    public class ColorExtTextBox : TextBox
    {
        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        #endregion

        #region 字段

        private ColorExt coloreExt = null;

        private int coloreExt_height;

        private int coloreExt_image_width = 0;

        private int coloreExt_image_padding = 0;

        private int coloreExt_border = 0;

        private int height_subtract = 6;

        private int top_padding = 3;

        private int left_padding = 2;

        #endregion

        #region 扩展

        private const int WM_RBUTTONDOWN = 0x0204;

        #endregion

        public ColorExtTextBox(ColorExt coloreExt, int coloreExt_height, int image_width, int image_padding, int border)
        {
            this.coloreExt = coloreExt;
            this.coloreExt_height = coloreExt_height;
            this.coloreExt_image_width = image_width;
            this.coloreExt_image_padding = image_padding;
            this.coloreExt_border = border;
        }

        #region 重写

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            switch (e.KeyCode)
            {
                #region Number
                case Keys.D0:
                case Keys.NumPad0:
                case Keys.D1:
                case Keys.NumPad1:
                case Keys.D2:
                case Keys.NumPad2:
                case Keys.D3:
                case Keys.NumPad3:
                case Keys.D4:
                case Keys.NumPad4:
                case Keys.D5:
                case Keys.NumPad5:
                case Keys.D6:
                case Keys.NumPad6:
                case Keys.D7:
                case Keys.NumPad7:
                case Keys.D8:
                case Keys.NumPad8:
                case Keys.D9:
                case Keys.NumPad9:
                case Keys.Oemcomma:
                case Keys.Left:
                case Keys.Right:
                case Keys.Back:
                case Keys.Control:
                case Keys.ControlKey:
                    {
                        e.SuppressKeyPress = false;
                        break;
                    }
                case Keys.A:
                case Keys.V:
                    {
                        if (e.Control)
                            e.SuppressKeyPress = false;
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.C:
                    {
                        if (e.Control)
                        {
                            this.SelectAll();
                            e.SuppressKeyPress = false;
                        }
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                #endregion
                default:
                    {
                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_RBUTTONDOWN)//WM_RBUTTONDOWN是为了不让出现鼠标菜单
                return;
            base.WndProc(ref m);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            int scale_height = (int)(this.coloreExt_height * DotsPerInchHelper.DPIScale.XScale);
            int scale_dateTextBox_zoom = (int)(this.height_subtract * DotsPerInchHelper.DPIScale.XScale);
            int scale_top_padding = (int)(this.top_padding * DotsPerInchHelper.DPIScale.XScale);
            int scale_left_padding = (int)(this.left_padding * DotsPerInchHelper.DPIScale.XScale);
            int scale_image_width = (int)(this.coloreExt_image_width * DotsPerInchHelper.DPIScale.XScale);

            width = this.coloreExt.Width - scale_image_width - this.coloreExt_image_padding * 2 - this.coloreExt_border * 2 - (int)(4 * DotsPerInchHelper.DPIScale.XScale);
            height = scale_height - scale_dateTextBox_zoom;
            if (this.coloreExt.ColorImageAlign == ColorExt.ColorImageAligns.Left)
            {
                x = scale_image_width + this.coloreExt_image_padding * 2 + this.coloreExt_border * 2;
                y = scale_top_padding;
            }
            else
            {
                x = this.coloreExt_border + scale_left_padding;
                y = scale_top_padding;
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion
    }

    /// <summary>
    /// 颜色面板美化控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("颜色面板美化控件")]
    [DefaultProperty("ColorValue")]
    [DefaultEvent("BottomBarConfirmClick")]
    [Designer(typeof(ColorPickerExtDesigner))]
    [TypeConverter(typeof(EmptyConverter))]
    public class ColorPickerExt : Control
    {
        #region 新增事件

        public delegate void ColorValueChangedEventHandler(object sender, ColorValueChangedEventArgs e);

        private event ColorValueChangedEventHandler colorValueChanged;
        /// <summary>
        /// 颜色值更改事件
        /// </summary>
        [Description("颜色值更改事件")]
        public event ColorValueChangedEventHandler ColorValueChanged
        {
            add { this.colorValueChanged += value; }
            remove { this.colorValueChanged -= value; }
        }

        public delegate void HtmlColorItemClickEventHandler(object sender, HtmlColorItemClickEventArgs e);

        private event HtmlColorItemClickEventHandler htmlColorItemClick;
        /// <summary>
        /// html颜色面板选项单击事件
        /// </summary>
        [Description("html颜色面板选项单击事件")]
        public event HtmlColorItemClickEventHandler HtmlColorItemClick
        {
            add { this.htmlColorItemClick += value; }
            remove { this.htmlColorItemClick -= value; }
        }

        public delegate void ColorItemClickEventHandler(object sender, ColorItemClickEventArgs e);

        private event ColorItemClickEventHandler themeColorItemClick;
        /// <summary>
        /// 主题颜色面板选项单击事件
        /// </summary>
        [Description("主题颜色面板选项单击事件")]
        public event ColorItemClickEventHandler ThemeColorItemClick
        {
            add { this.themeColorItemClick += value; }
            remove { this.themeColorItemClick -= value; }
        }

        private event ColorItemClickEventHandler standardColorItemClick;
        /// <summary>
        /// 标准颜色面板选项单击事件
        /// </summary>
        [Description("标准颜色面板选项单击事件")]
        public event ColorItemClickEventHandler StandardColorItemClick
        {
            add { this.standardColorItemClick += value; }
            remove { this.standardColorItemClick -= value; }
        }

        private event ColorItemClickEventHandler customColorItemClick;
        /// <summary>
        /// 自定义颜色面板选项单击事件
        /// </summary>
        [Description("自定义颜色面板选项单击事件")]
        public event ColorItemClickEventHandler CustomColorItemClick
        {
            add { this.customColorItemClick += value; }
            remove { this.customColorItemClick -= value; }
        }

        #region 底部选项

        public delegate void BottomBarIiemClickEventHandler(object sender, BottomBarIiemClickEventArgs e);

        private event BottomBarIiemClickEventHandler bottomBarCustomClick;
        /// <summary>
        ///自定义颜色单击事件
        /// </summary>
        [Description("自定义颜色单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarCustomClick
        {
            add { this.bottomBarCustomClick += value; }
            remove { this.bottomBarCustomClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarClearClick;
        /// <summary>
        ///清除单击事件
        /// </summary>
        [Description("清除单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarClearClick
        {
            add { this.bottomBarClearClick += value; }
            remove { this.bottomBarClearClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarConfirmClick;
        /// <summary>
        ///确认单击事件
        /// </summary>
        [Description("确认单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarConfirmClick
        {
            add { this.bottomBarConfirmClick += value; }
            remove { this.bottomBarConfirmClick -= value; }
        }
        #endregion

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged
        {
            add { base.BackgroundImageChanged += value; }
            remove { base.BackgroundImageChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged
        {
            add { base.BackgroundImageLayoutChanged += value; }
            remove { base.BackgroundImageLayoutChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add { base.TabIndexChanged += value; }
            remove { base.TabIndexChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { base.TabStopChanged += value; }
            remove { base.TabStopChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DockChanged
        {
            add { base.DockChanged += value; }
            remove { base.DockChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { base.FontChanged += value; }
            remove { base.FontChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { base.ForeColorChanged += value; }
            remove { base.ForeColorChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private bool colorReadOnly = false;
        /// <summary>
        /// 颜色面板是否只读
        /// </summary>
        [DefaultValue(false)]
        [Description("颜色面板是否只读")]
        public bool ColorReadOnly
        {
            get { return this.colorReadOnly; }
            set
            {
                if (this.colorReadOnly == value)
                    return;
                this.colorReadOnly = value;
                this.Invalidate();
            }
        }

        private bool colorInput = true;
        /// <summary>
        /// 是否允许颜色输入框输入
        /// </summary>
        [DefaultValue(true)]
        [Description("是否允许颜色输入框输入")]
        public bool ColorInput
        {
            get { return this.colorInput; }
            set
            {
                if (this.colorInput == value)
                    return;
                this.colorInput = value;
                this.colorTextBox.Enabled = value;
            }
        }

        private colorTypes colorType = colorTypes.Default;
        /// <summary>
        /// 颜色面板选中类型
        /// </summary>
        [DefaultValue(colorTypes.Default)]
        [Description("颜色面板选中类型")]
        public colorTypes ColorType
        {
            get { return this.colorType; }
            set
            {
                if (this.colorType == value)
                    return;
                this.colorType = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeColor = Color.FromArgb(158, 158, 158);
        /// <summary>
        /// 顶部按钮字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "158, 158, 158")]
        [Description("顶部按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TopBarBtnForeColor
        {
            get { return this.topBarBtnForeColor; }
            set
            {
                if (this.topBarBtnForeColor == value)
                    return;
                this.topBarBtnForeColor = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeSelectColor = Color.FromArgb(153, 204, 204);
        /// <summary>
        /// 顶部按钮字体颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("顶部按钮字体颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TopBarBtnForeSelectColor
        {
            get { return this.topBarBtnForeSelectColor; }
            set
            {
                if (this.topBarBtnForeSelectColor == value)
                    return;
                this.topBarBtnForeSelectColor = value;
                this.Invalidate();
            }
        }

        private Color themeTitleForeColor = Color.FromArgb(153, 204, 204);
        /// <summary>
        /// 主题颜色标题字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("主题颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color ThemeTitleForeColor
        {
            get { return this.themeTitleForeColor; }
            set
            {
                if (this.themeTitleForeColor == value)
                    return;
                this.themeTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color standardTitleForeColor = Color.FromArgb(153, 204, 204);
        /// <summary>
        /// 标准颜色标题字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("标准颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color StandardTitleForeColor
        {
            get { return this.standardTitleForeColor; }
            set
            {
                if (this.standardTitleForeColor == value)
                    return;
                this.standardTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color customTitleForeColor = Color.FromArgb(153, 204, 204);
        /// <summary>
        /// 自定义颜色标题字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("自定义颜色标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CustomTitleForeColor
        {
            get { return this.customTitleForeColor; }
            set
            {
                if (this.customTitleForeColor == value)
                    return;
                this.customTitleForeColor = value;
                this.Invalidate();
            }
        }

        private Color customSelectLineColor = Color.FromArgb(107, 142, 35);
        /// <summary>
        /// 自定义颜色选中颜色
        /// </summary>
        [DefaultValue(typeof(Color), "107, 142, 35")]
        [Description("自定义颜色选中颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CustomSelectLineColor
        {
            get { return this.customSelectLineColor; }
            set
            {
                if (this.customSelectLineColor == value)
                    return;
                this.customSelectLineColor = value;
                this.Invalidate();
            }
        }

        private Color currentTextForeColor = Color.FromArgb(105, 105, 105);
        /// <summary>
        /// 当前颜色字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "105, 105, 105")]
        [Description("当前颜色字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CurrentTextForeColor
        {
            get { return this.currentTextForeColor; }
            set
            {
                if (this.currentTextForeColor == value)
                    return;
                this.currentTextForeColor = value;
                this.Invalidate();
            }
        }

        #region 底部按钮
        private Color bottomBarBtnBackColor = Color.FromArgb(153, 204, 204);
        /// <summary>
        /// 底部按钮背景颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 204")]
        [Description("底部按钮背景颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackColor
        {
            get { return this.bottomBarBtnBackColor; }
            set
            {
                if (this.bottomBarBtnBackColor == value)
                    return;
                this.bottomBarBtnBackColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 底部按钮字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "255,255,255")]
        [Description("底部按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeColor
        {
            get { return this.bottomBarBtnForeColor; }
            set
            {
                if (this.bottomBarBtnForeColor == value)
                    return;
                this.bottomBarBtnForeColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnBackDisabledColor = Color.FromArgb(170, 192, 192, 192);
        /// <summary>
        /// 底部按钮背景颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "170, 192, 192, 192")]
        [Description("底部按钮背景颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackDisabledColor
        {
            get { return this.bottomBarBtnBackDisabledColor; }
            set
            {
                if (this.bottomBarBtnBackDisabledColor == value)
                    return;
                this.bottomBarBtnBackDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeDisabledColor = Color.FromArgb(170, 255, 255, 255);
        /// <summary>
        /// 底部按钮字体颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "170, 255, 255, 255")]
        [Description("底部按钮字体颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeDisabledColor
        {
            get { return this.bottomBarBtnForeDisabledColor; }
            set
            {
                if (this.bottomBarBtnForeDisabledColor == value)
                    return;
                this.bottomBarBtnForeDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnBackEnterColor = Color.FromArgb(200, 153, 204, 204);
        /// <summary>
        /// 底部按钮背景颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "200, 153, 204, 204")]
        [Description("底部按钮背景颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnBackEnterColor
        {
            get { return this.bottomBarBtnBackEnterColor; }
            set
            {
                if (this.bottomBarBtnBackEnterColor == value)
                    return;
                this.bottomBarBtnBackEnterColor = value;
                this.Invalidate();
            }
        }

        private Color bottomBarBtnForeEnterColor = Color.FromArgb(200, 255, 255, 255);
        /// <summary>
        /// 底部按钮字体颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "200,255,255,255")]
        [Description("底部按钮字体颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BottomBarBtnForeEnterColor
        {
            get { return this.bottomBarBtnForeEnterColor; }
            set
            {
                if (this.bottomBarBtnForeEnterColor == value)
                    return;
                this.bottomBarBtnForeEnterColor = value;
                this.Invalidate();
            }
        }

        #endregion

        private Color colorValue = Color.Empty;
        /// <summary>
        /// 颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("颜色")]
        [Editor(typeof(ColorEditorExt), typeof(System.Drawing.Design.UITypeEditor))]
        public Color ColorValue
        {
            get { return this.colorValue; }
            set
            {
                if (this.colorValue == value)
                    return;

                ColorValueChangedEventArgs arg = new ColorValueChangedEventArgs() { OldColorValue = this.colorValue, NewColorValue = value };

                this.colorValue = value;

                this.OnColorValueChanged(arg);
            }
        }

        #endregion

        #region  重写属性

        protected new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        [DefaultValue(typeof(Color), "255, 255, 255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// 控件默认内边距
        /// </summary>
        [DefaultValue(typeof(Padding), "5,5,5,5")]
        [Description("控件默认内边距")]
        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(5, 5, 5, 5);
            }
        }

        /// <summary>
        /// 控件默认大小
        /// </summary>
        [DefaultValue(typeof(Size), "465, 285")]
        [Description("控件默认大小")]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(465, 330);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return 0; }
            set { base.TabIndex = 0; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        [DefaultValue(DockStyle.None)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return DockStyle.None;
            }
            set
            {
                base.Dock = DockStyle.None;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 背景图
        /// </summary>
        private static Image back_image = Resources.squaresback;
        /// <summary>
        /// 滑块背景颜色
        /// </summary>
        private Color border_slide_back_color;
        /// <summary>
        /// 渐变框当前颜色
        /// </summary>
        private Color gradual_color;
        /// <summary>
        /// 原始颜色
        /// </summary>
        private Color defaultColorValue = Color.Empty;
        /// <summary>
        /// 当前颜色
        /// </summary>
        private Color currentValue = Color.Empty;
        /// <summary>
        /// 渐变框图片
        /// </summary>
        private Bitmap gradual_bmp;
        /// <summary>
        /// 渐变栏图片
        /// </summary>
        private Bitmap gradual_bar_bmp;
        /// <summary>
        /// 当前鼠标状态
        /// </summary>
        private ColorMoveStatuss colorMoveStatus = ColorMoveStatuss.Normal;
        /// <summary>
        /// 开始颜色对象
        /// </summary>
        private ColorClass ColorObject;
        /// <summary>
        /// 自定义标题颜色选中行号
        /// </summary>
        private int custom_select_row_index = 0;
        /// <summary>
        /// 自定义标题颜色选中列号
        /// </summary>
        private int custom_select_cel_index = 0;

        private static readonly StringFormat text_left_sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };
        private static readonly StringFormat text_center_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };
        private static readonly StringFormat text_right_sf = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };

        private int colorTextWidth = 100;

        private ColorPickerExtTextBox colorTextBox = null;

        /// <summary>
        /// 画笔管理
        /// </summary>
        private SolidBrushManage SolidBrushManageObject;

        #endregion

        public ColorPickerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.SuspendLayout();

            this.BackColor = Color.FromArgb(255, 255, 255);
            this.border_slide_back_color = Color.FromArgb(200, 255, 255, 255);

            this.ColorObject = new ColorClass(this);
            this.InitializeControlRectangle();

            this.SolidBrushManageObject = new SolidBrushManage(this);

            this.gradual_bmp = new Bitmap(this.ColorObject.GradualRect.Width, this.ColorObject.GradualRect.Height);
            this.gradual_bar_bmp = new Bitmap(this.ColorObject.GradualBarRect.Width, this.ColorObject.GradualBarRect.Height);
            this.Update_GradualBar_Image();

            this.colorTextBox = new ColorPickerExtTextBox(this);
            this.colorTextBox.BackColor = this.BackColor;
            this.colorTextBox.ForeColor = this.ForeColor;
            this.colorTextBox.ImeMode = ImeMode.Off;
            this.colorTextBox.TextAlign = HorizontalAlignment.Left;
            this.colorTextBox.TabStop = false;
            this.colorTextBox.Cursor = Cursors.Default;
            this.colorTextBox.BorderStyle = BorderStyle.None;
            this.colorTextBox.LostFocus += new EventHandler(this.colorTextBox_LostFocus);
            this.colorTextBox.TextChanged += new EventHandler(this.colorTextBox_TextChanged);
            this.Controls.Add(this.colorTextBox);

            this.ResumeLayout();

            this.UpdateLocationSize();
            this.InitializeColor();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 背景
            this.SolidBrushManageObject.common_sb.Color = this.BackColor;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, g.ClipBounds);
            #endregion

            #region 顶部按钮
            Color top_defaultcolorbtn_fore_color = (this.ColorType == colorTypes.Default) ? this.TopBarBtnForeSelectColor : this.TopBarBtnForeColor;
            this.SolidBrushManageObject.common_sb.Color = top_defaultcolorbtn_fore_color;
            g.DrawString(this.ColorObject.DefaultColorBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.DefaultColorBtn.Rect, text_center_sf);
            if (this.ColorType == colorTypes.Default)
            {
                g.DrawLines(this.SolidBrushManageObject.border_pen, new Point[] {
                new Point(this.ColorObject.ColorRect.X, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Left, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Left, this.ColorObject.DefaultColorBtn.Rect.Top),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Right, this.ColorObject.DefaultColorBtn.Rect.Top),
                new Point(this.ColorObject.DefaultColorBtn.Rect.Right, this.ColorObject.DefaultColorBtn.Rect.Bottom),
                new Point(this.ColorObject.ColorRect.Right, this.ColorObject.DefaultColorBtn.Rect.Bottom)});
            }

            Color top_htmlcolorbtn_fore_color = (this.ColorType == colorTypes.Html) ? this.TopBarBtnForeSelectColor : this.TopBarBtnForeColor;
            this.SolidBrushManageObject.common_sb.Color = top_htmlcolorbtn_fore_color;
            g.DrawString(this.ColorObject.HtmlColorBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.HtmlColorBtn.Rect, text_center_sf);
            if (this.ColorType == colorTypes.Html)
            {
                g.DrawLines(this.SolidBrushManageObject.border_pen, new Point[] {
                new Point(this.ColorObject.ColorRect.X, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Left, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Left, this.ColorObject.HtmlColorBtn.Rect.Top),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Right, this.ColorObject.HtmlColorBtn.Rect.Top),
                new Point(this.ColorObject.HtmlColorBtn.Rect.Right, this.ColorObject.HtmlColorBtn.Rect.Bottom),
                new Point(this.ColorObject.ColorRect.Right, this.ColorObject.HtmlColorBtn.Rect.Bottom)});
            }
            #endregion

            #region 颜色面板
            if (this.ColorType == colorTypes.Default)
            {
                #region 主题颜色
                this.SolidBrushManageObject.common_sb.Color = this.ThemeTitleForeColor;
                g.DrawString("主题颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ThemeTitleRect, text_left_sf);
                ColorItemClass theme_colors_item_enter = null;
                for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.ThemeColors[i, j];
                        g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ThemeColorsItem[i, j].Rect);
                        if (this.ColorObject.ThemeColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter)
                        {
                            theme_colors_item_enter = this.ColorObject.ThemeColorsItem[i, j];
                        }
                    }
                }
                if (theme_colors_item_enter != null)
                {
                    Rectangle rect = new Rectangle(theme_colors_item_enter.Rect.X - 1, theme_colors_item_enter.Rect.Y - 1, theme_colors_item_enter.Rect.Width + 1, theme_colors_item_enter.Rect.Height + 1);
                    g.DrawRectangle(this.SolidBrushManageObject.border_ts_pen, rect);
                }
                #endregion

                #region 标准颜色
                this.SolidBrushManageObject.common_sb.Color = this.StandardTitleForeColor;
                g.DrawString("标准颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.StandardTitleRect, text_left_sf);
                for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.StandardColors[i, j];
                        g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.StandardColorsItem[i, j].Rect);
                        if (this.ColorObject.StandardColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter)
                        {
                            Rectangle rect = new Rectangle(this.ColorObject.StandardColorsItem[i, j].Rect.X - 1, this.ColorObject.StandardColorsItem[i, j].Rect.Y - 1, this.ColorObject.StandardColorsItem[i, j].Rect.Width + 1, this.ColorObject.StandardColorsItem[i, j].Rect.Height + 1);
                            g.DrawRectangle(this.SolidBrushManageObject.border_ts_pen, rect);
                        }
                    }
                }
                #endregion
            }
            else if (this.ColorType == colorTypes.Html)
            {
                #region html颜色
                for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
                {
                    for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                    {
                        this.SolidBrushManageObject.common_sb.Color = ColorManage.HtmlColors[i].Colors[j];
                        g.FillPolygon(this.SolidBrushManageObject.common_sb, this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs);
                    }
                }
                #endregion
            }
            #endregion

            #region 自定义颜色
            this.SolidBrushManageObject.common_sb.Color = this.CustomTitleForeColor;
            g.DrawString("自定义颜色", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CustomTitleRect, text_left_sf);
            for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                {
                    //背景
                    g.DrawImage(back_image, this.ColorObject.CustomColorsItem[i, j].Rect, 0, 0, this.ColorObject.CustomColorsItem[i, j].Rect.Width, this.ColorObject.CustomColorsItem[i, j].Rect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);

                    this.SolidBrushManageObject.common_sb.Color = ColorManage.CustomColors[i, j];
                    g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CustomColorsItem[i, j].Rect);

                    Rectangle rect = new Rectangle(this.ColorObject.CustomColorsItem[i, j].Rect.X, this.ColorObject.CustomColorsItem[i, j].Rect.Y, this.ColorObject.CustomColorsItem[i, j].Rect.Width - 1, this.ColorObject.CustomColorsItem[i, j].Rect.Height - 1);
                    g.DrawRectangle((this.ColorObject.CustomColorsItem[i, j].MoveStatus == ColorItemMoveStatuss.Enter) ? this.SolidBrushManageObject.border_ts_pen : this.SolidBrushManageObject.border_pen, rect);

                    if (this.custom_select_row_index == i && this.custom_select_cel_index == j)
                    {
                        this.SolidBrushManageObject.common_pen.Color = this.CustomSelectLineColor;
                        float w = this.SolidBrushManageObject.common_pen.Width;
                        this.SolidBrushManageObject.common_pen.Width = 2;
                        g.DrawLine(this.SolidBrushManageObject.common_pen, new Point(this.ColorObject.CustomColorsItem[i, j].Rect.Left, this.ColorObject.CustomColorsItem[i, j].Rect.Bottom + 3), new Point(this.ColorObject.CustomColorsItem[i, j].Rect.Right, this.ColorObject.CustomColorsItem[i, j].Rect.Bottom + 3));
                        this.SolidBrushManageObject.common_pen.Width = w;
                    }
                }
            }
            #endregion

            #region Gradual
            Rectangle gradual_border_rect = new Rectangle(this.ColorObject.GradualRect.X - 1, this.ColorObject.GradualRect.Y - 1, this.ColorObject.GradualRect.Width + 1, this.ColorObject.GradualRect.Height + 1);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, gradual_border_rect);

            g.DrawImage(this.gradual_bmp, this.ColorObject.GradualRect);

            if (this.ColorObject.GradualSelectPoint != Point.Empty)
            {
                Rectangle point_rect_in = new Rectangle(this.ColorObject.GradualRect.X + this.ColorObject.GradualSelectPoint.X - 2, this.ColorObject.GradualRect.Y + this.ColorObject.GradualSelectPoint.Y - 2, 4, 4);
                Rectangle point_rect_out = new Rectangle(this.ColorObject.GradualRect.X + this.ColorObject.GradualSelectPoint.X - 3, this.ColorObject.GradualRect.Y + this.ColorObject.GradualSelectPoint.Y - 3, 6, 6);
                this.SolidBrushManageObject.common_pen.Color = Color.Black;
                g.DrawEllipse(this.SolidBrushManageObject.common_pen, point_rect_in);
                this.SolidBrushManageObject.common_pen.Color = Color.White;
                g.DrawEllipse(this.SolidBrushManageObject.common_pen, point_rect_out);
            }
            #endregion

            #region GradualBar
            g.DrawImage(this.gradual_bar_bmp, this.ColorObject.GradualBarRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.GradualBarRect);
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.GradualBarSlideRect);
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.GradualBarSlideRect);
            #endregion

            #region A
            //背景
            g.DrawImage(back_image, this.ColorObject.CurrentValue_A_Rect, 0, 0, this.ColorObject.CurrentValue_A_Rect.Width, this.ColorObject.CurrentValue_A_Rect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);
            //渐变      
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.FromArgb(byte.MaxValue, this.currentValue) };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_A_Rect);
            //边框  
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_A_Rect);
            //滑块背景
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_A_SlideRect);
            //滑块边框
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_A_SlideRect);
            //文本     
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle a_rect = new Rectangle(this.ColorObject.CurrentValue_A_Rect.Right + this.ColorObject.CurrentValue_A_SlideRect.Width, this.ColorObject.CurrentValue_A_Rect.Y, 20, this.ColorObject.CurrentValue_A_Rect.Height);
            g.DrawString("A", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, a_rect, text_right_sf);
            #endregion

            #region R
            //背景
            g.DrawImage(back_image, this.ColorObject.CurrentValue_R_Rect, 0, 0, this.ColorObject.CurrentValue_R_Rect.Width, this.ColorObject.CurrentValue_R_Rect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);
            //渐变      
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Red };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_R_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_R_Rect);
            //边框  
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_R_SlideRect);
            //滑块边框
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_R_SlideRect);
            //文本     
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle r_rect = new Rectangle(this.ColorObject.CurrentValue_R_Rect.Right + this.ColorObject.CurrentValue_R_SlideRect.Width, this.ColorObject.CurrentValue_R_Rect.Y, 20, this.ColorObject.CurrentValue_R_Rect.Height);
            g.DrawString("R", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, r_rect, text_right_sf);
            #endregion

            #region G
            //背景
            g.DrawImage(back_image, this.ColorObject.CurrentValue_G_Rect, 0, 0, this.ColorObject.CurrentValue_G_Rect.Width, this.ColorObject.CurrentValue_G_Rect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);
            //渐变      
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Green };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_G_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_G_Rect);
            //边框  
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_G_SlideRect);
            //滑块边框
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_G_SlideRect);
            //文本     
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle g_rect = new Rectangle(this.ColorObject.CurrentValue_G_Rect.Right + this.ColorObject.CurrentValue_G_SlideRect.Width, this.ColorObject.CurrentValue_G_Rect.Y, 20, this.ColorObject.CurrentValue_G_Rect.Height);
            g.DrawString("G", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, g_rect, text_right_sf);
            #endregion

            #region B
            //背景
            g.DrawImage(back_image, this.ColorObject.CurrentValue_B_Rect, 0, 0, this.ColorObject.CurrentValue_B_Rect.Width, this.ColorObject.CurrentValue_B_Rect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);
            //渐变      
            this.SolidBrushManageObject.argb_lgb.LinearColors = new Color[] { Color.Transparent, Color.Blue };
            g.FillRectangle(this.SolidBrushManageObject.argb_lgb, this.ColorObject.CurrentValue_B_Rect);
            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentValue_B_Rect);
            //边框  
            this.SolidBrushManageObject.common_sb.Color = this.border_slide_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentValue_B_SlideRect);
            //滑块边框
            g.DrawRectangle(this.SolidBrushManageObject.border_slide_pen, this.ColorObject.CurrentValue_B_SlideRect);
            //文本     
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            Rectangle b_rect = new Rectangle(this.ColorObject.CurrentValue_B_Rect.Right + this.ColorObject.CurrentValue_B_SlideRect.Width, this.ColorObject.CurrentValue_B_Rect.Y, 20, this.ColorObject.CurrentValue_B_Rect.Height);
            g.DrawString("B", this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, b_rect, text_right_sf);
            #endregion

            #region 当前颜色值
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            string newcolor_str = "当前颜色:";
            g.DrawString(newcolor_str, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CurrentColorTextRect, text_left_sf);
            Pen colortext_border_pen = new Pen(Color.FromArgb(192, 192, 192), 1);
            g.DrawRectangle(colortext_border_pen, new Rectangle(this.colorTextBox.Location.X - 3, this.colorTextBox.Location.Y - 4, this.colorTextBox.Size.Width + 4, this.colorTextBox.Height + 5));
            colortext_border_pen.Dispose();

            g.DrawImage(back_image, this.ColorObject.CurrentColorRect, 0, 0, this.ColorObject.CurrentColorRect.Width, this.ColorObject.CurrentColorRect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);
            if (this.currentValue != Color.Empty)
            {
                this.SolidBrushManageObject.common_sb.Color = Color.FromArgb(byte.MaxValue, this.currentValue);
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.CurrentColorRect.X, this.ColorObject.CurrentColorRect.Y, this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Height));
                this.SolidBrushManageObject.common_sb.Color = this.currentValue;
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Y, this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Height));
            }

            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.CurrentColorRect);
            g.DrawLine(this.SolidBrushManageObject.border_pen, new Point(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Y), new Point(this.ColorObject.CurrentColorRect.X + this.ColorObject.CurrentColorRect.Width / 2, this.ColorObject.CurrentColorRect.Bottom));
            #endregion

            #region 原始颜色值
            this.SolidBrushManageObject.common_sb.Color = this.CurrentTextForeColor;
            string oldcolor_str = this.ColorValue == Color.Empty ? "原始颜色:" : String.Format("原始颜色: {0},{1},{2},{3}", this.ColorValue.A, this.ColorValue.R, this.ColorValue.G, this.ColorValue.B);
            g.DrawString(oldcolor_str, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.OriginalColorTextRect, text_left_sf);

            g.DrawImage(back_image, this.ColorObject.OriginalColorRect, 0, 0, this.ColorObject.OriginalColorRect.Width, this.ColorObject.OriginalColorRect.Height, GraphicsUnit.Pixel, this.SolidBrushManageObject.back_image_ia);

            if (this.ColorValue != Color.Empty)
            {
                this.SolidBrushManageObject.common_sb.Color = Color.FromArgb(byte.MaxValue, this.ColorValue);
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.OriginalColorRect.X, this.ColorObject.OriginalColorRect.Y, this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Height));
                this.SolidBrushManageObject.common_sb.Color = this.ColorValue;
                g.FillRectangle(this.SolidBrushManageObject.common_sb, new Rectangle(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Y, this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Height));
            }

            g.DrawRectangle(this.SolidBrushManageObject.border_pen, this.ColorObject.OriginalColorRect);
            g.DrawLine(this.SolidBrushManageObject.border_pen, new Point(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Y), new Point(this.ColorObject.OriginalColorRect.X + this.ColorObject.OriginalColorRect.Width / 2, this.ColorObject.OriginalColorRect.Bottom));
            #endregion

            #region 底部按钮
            Color bottom_custom_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.CustomBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_custom_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.CustomBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_custom_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.CustomBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_custom_fore_color;
            g.DrawString(this.ColorObject.CustomBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.CustomBtn.Rect, text_center_sf);

            Color bottom_clear_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.ClearBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_clear_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.ClearBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_clear_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ClearBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_clear_fore_color;
            g.DrawString(this.ColorObject.ClearBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ClearBtn.Rect, text_center_sf);

            Color bottom_confirm_back_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnBackDisabledColor : (this.ColorObject.ConfirmBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnBackEnterColor : this.BottomBarBtnBackColor);
            Color bottom_confirm_fore_color = (this.ColorReadOnly || !this.Enabled) ? this.BottomBarBtnForeDisabledColor : (this.ColorObject.ConfirmBtn.MoveStatus == ColorItemMoveStatuss.Enter ? this.BottomBarBtnForeEnterColor : this.BottomBarBtnForeColor);
            this.SolidBrushManageObject.common_sb.Color = bottom_confirm_back_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, this.ColorObject.ConfirmBtn.Rect);
            this.SolidBrushManageObject.common_sb.Color = bottom_confirm_fore_color;
            g.DrawString(this.ColorObject.ConfirmBtn.Text, this.SolidBrushManageObject.text_font, this.SolidBrushManageObject.common_sb, this.ColorObject.ConfirmBtn.Rect, text_center_sf);
            #endregion

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            if (this.SolidBrushManageObject != null)
                this.SolidBrushManageObject.ReleaseSolidBrushs();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.ColorReadOnly)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Focus();

                Point point = this.PointToClient(Control.MousePosition);

                #region 顶部按钮
                if (this.ColorObject.DefaultColorBtn.Rect.Contains(point) && this.ColorType != colorTypes.Default)
                {
                    this.ColorType = colorTypes.Default;
                    this.Invalidate();
                }
                else if (this.ColorObject.HtmlColorBtn.Rect.Contains(point) && this.ColorType != colorTypes.Html)
                {
                    this.ColorType = colorTypes.Html;
                    this.Invalidate();
                }
                #endregion
                #region Theme
                if (this.colorMoveStatus == ColorMoveStatuss.ThemeDown)
                {
                    if (this.ColorObject.ThemeRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.ThemeColorsItem[i, j].Rect.Contains(point))
                                {
                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.ThemeColors[this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex, this.ColorObject.ThemeColorsItem[i, j].ColorColIndex]);
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.ThemeColors[this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex, this.ColorObject.ThemeColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnThemeColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.ThemeColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Standard
                if (this.colorMoveStatus == ColorMoveStatuss.StandardDown)
                {
                    if (this.ColorObject.StandardRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.StandardColorsItem[i, j].Rect.Contains(point))
                                {
                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.StandardColors[this.ColorObject.StandardColorsItem[i, j].ColorRowIndex, this.ColorObject.StandardColorsItem[i, j].ColorColIndex]);
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.StandardColors[this.ColorObject.StandardColorsItem[i, j].ColorRowIndex, this.ColorObject.StandardColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnStandardColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.StandardColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region html
                if (this.colorMoveStatus == ColorMoveStatuss.HtmlDown)
                {
                    GraphicsPath html_gp = new GraphicsPath();
                    Region html_r = new Region();
                    for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
                    {
                        for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                        {
                            bool isselect = false;
                            html_gp.Reset();
                            html_gp.AddPolygon(this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs);
                            html_r.MakeEmpty();
                            html_r.Union(html_gp);
                            if (html_r.IsVisible(point))
                            {
                                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                {
                                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                }

                                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, ColorManage.HtmlColors[i].Colors[j]);
                                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                this.UpdateColorText();

                                this.gradual_color = ColorManage.HtmlColors[i].Colors[j];
                                this.ColorObject.GradualSelectPoint = Point.Empty;
                                this.Update_Gradual_Image();

                                this.OnHtmlColorItemClick(new HtmlColorItemClickEventArgs() { Item = this.ColorObject.HtmlColorsItem[i].ColorsRects[j] });

                                this.Invalidate();
                                isselect = true;
                                break;
                            }
                            if (isselect)
                            {
                                break;
                            }
                        }
                    }
                    html_gp.Dispose();
                    html_r.Dispose();
                }
                #endregion
                #region Custom
                if (this.colorMoveStatus == ColorMoveStatuss.CustomDown)
                {
                    if (this.ColorObject.CustomRect.Contains(point))
                    {
                        for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(point))
                                {
                                    this.custom_select_row_index = i;
                                    this.custom_select_cel_index = j;

                                    if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                                    {
                                        this.ColorObject.CurrentValue_A_SlideValue = 255;
                                        this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    }

                                    this.currentValue = ColorManage.CustomColors[this.ColorObject.CustomColorsItem[i, j].ColorRowIndex, this.ColorObject.CustomColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.CurrentValue_A_SlideValue = this.currentValue.A;
                                    this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                                    this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                                    this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
                                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                                    this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                                    this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                                    this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                                    this.UpdateColorText();

                                    this.gradual_color = ColorManage.CustomColors[this.ColorObject.CustomColorsItem[i, j].ColorRowIndex, this.ColorObject.CustomColorsItem[i, j].ColorColIndex];
                                    this.ColorObject.GradualSelectPoint = Point.Empty;
                                    this.Update_Gradual_Image();

                                    this.OnCustomColorItemClick(new ColorItemClickEventArgs() { Item = this.ColorObject.CustomColorsItem[i, j] });

                                    this.Invalidate();
                                }
                            }
                        }
                    }
                }
                #endregion
                #region CustomBtn
                if (this.colorMoveStatus == ColorMoveStatuss.CustomDown)
                {
                    if (this.ColorObject.CustomBtn.Rect.Contains(point))
                    {
                        this.OnCustomClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.CustomBtn });
                    }
                }
                #endregion
                #region ClearBtn
                if (this.colorMoveStatus == ColorMoveStatuss.ClearDown)
                {
                    if (this.ColorObject.ClearBtn.Rect.Contains(point))
                    {
                        this.OnClearClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.ClearBtn });
                    }
                }
                #endregion
                #region ConfirmBtn
                if (this.colorMoveStatus == ColorMoveStatuss.ConfirmDown)
                {
                    if (this.ColorObject.ConfirmBtn.Rect.Contains(point))
                    {
                        this.OnConfirmClick(new BottomBarIiemClickEventArgs() { Item = this.ColorObject.ConfirmBtn });
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (this.ColorReadOnly)
                return;

            if (this.ColorObject.ColorRect.Contains(e.Location))
            {
                if (this.ColorType == colorTypes.Default)
                {
                    #region Theme
                    if (this.ColorObject.ThemeRect.Contains(e.Location))
                    {
                        this.colorMoveStatus = ColorMoveStatuss.ThemeDown;
                    }
                    #endregion
                    #region Standard
                    else if (this.ColorObject.StandardRect.Contains(e.Location))
                    {
                        this.colorMoveStatus = ColorMoveStatuss.StandardDown;
                    }
                    #endregion
                }
                else if (this.ColorType == colorTypes.Html)
                {
                    #region html
                    this.colorMoveStatus = ColorMoveStatuss.HtmlDown;
                    #endregion
                }
            }
            #region Custom
            else if (this.ColorObject.CustomRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.CustomDown;
                for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                {
                    for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                    {
                        if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(e.Location))
                        {
                            this.custom_select_row_index = i;
                            this.custom_select_cel_index = j;
                        }
                    }
                }
            }
            #endregion
            #region Gradual
            else if (this.ColorObject.GradualRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GradualDown;
                this.Calculate_GradualSelectPoint_Value(e.Location);

                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                {
                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                }

                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.gradual_bmp.GetPixel(this.ColorObject.GradualSelectPoint.X, this.ColorObject.GradualSelectPoint.Y));
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region GradualBar
            else if (this.ColorObject.GradualBarRect.Contains(e.Location) || this.ColorObject.GradualBarSlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GradualBarDown;
                this.Calculate_GradualBar_Value(e.Location);
                Color color = this.gradual_bar_bmp.GetPixel(this.ColorObject.GradualBarRect.Width / 2, this.ColorObject.GradualBarSlideValue);

                if (this.ColorObject.CurrentValue_A_SlideValue == 0)
                {
                    this.ColorObject.CurrentValue_A_SlideValue = 255;
                    this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                }

                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, color);
                this.gradual_color = color;
                this.ColorObject.GradualSelectPoint = Point.Empty;
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_GradualBar_Rect(this.ColorObject.GradualBarSlideValue);
                this.Update_Gradual_Image();
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region A
            else if (this.ColorObject.CurrentValue_A_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_A_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ADown;
                this.Calculate_A_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.currentValue);
                this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region R
            else if (this.ColorObject.CurrentValue_R_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_R_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.RDown;
                this.Calculate_R_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.ColorObject.CurrentValue_R_SlideValue, this.currentValue.G, this.currentValue.B);
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region G
            else if (this.ColorObject.CurrentValue_G_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_G_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.GDown;
                this.Calculate_G_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.ColorObject.CurrentValue_G_SlideValue, this.currentValue.B);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region B
            else if (this.ColorObject.CurrentValue_B_Rect.Contains(e.Location) || this.ColorObject.CurrentValue_B_SlideRect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.BDown;
                this.Calculate_B_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.currentValue.G, this.ColorObject.CurrentValue_B_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);
                this.Invalidate();
            }
            #endregion
            #region CustomBtn
            else if (this.ColorObject.CustomBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.CustomDown;
            }
            #endregion
            #region ClearBtn
            else if (this.ColorObject.ClearBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ClearDown;
            }
            #endregion
            #region ConfirmBtn
            else if (this.ColorObject.ConfirmBtn.Rect.Contains(e.Location))
            {
                this.colorMoveStatus = ColorMoveStatuss.ConfirmDown;
            }
            #endregion
            #region
            else
            {
                this.colorMoveStatus = ColorMoveStatuss.Normal;
            }
            #endregion

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            base.OnMouseDown(e);

            if (this.ColorReadOnly)
                return;

            this.colorMoveStatus = ColorMoveStatuss.Normal;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            base.OnMouseDown(e);

            if (this.ColorReadOnly)
                return;

            if (this.colorMoveStatus == ColorMoveStatuss.Normal)
            {
                bool isenter = false;
                #region 顶部按钮
                if (this.ColorObject.DefaultColorBtn.Rect.Contains(e.Location) || this.ColorObject.HtmlColorBtn.Rect.Contains(e.Location))
                {
                    isenter = true;
                }
                #endregion
                if (this.ColorType == colorTypes.Default)
                {
                    #region Theme
                    if (this.ColorObject.ThemeRect.Contains(e.Location))
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.ThemeColorsItem[i, j].Rect.Contains(e.Location))
                                {
                                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                                }
                                else
                                {
                                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                            {
                                this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                    #endregion
                    #region Standard
                    if (this.ColorObject.StandardRect.Contains(e.Location))
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                if (this.ColorObject.StandardColorsItem[i, j].Rect.Contains(e.Location))
                                {
                                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                                }
                                else
                                {
                                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
                        {
                            for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                            {
                                this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                    #endregion
                }
                #region Custom
                if (this.ColorObject.CustomRect.Contains(e.Location))
                {
                    for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                        {
                            if (this.ColorObject.CustomColorsItem[i, j].Rect.Contains(e.Location))
                            {
                                this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Enter;
                            }
                            else
                            {
                                this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                        {
                            this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                        }
                    }
                }
                #endregion
                #region CustomBtn
                if (this.ColorObject.CustomBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.CustomBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.CustomBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                #region ClearBtn
                if (this.ColorObject.ClearBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.ClearBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.ClearBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                #region ConfirmBtn
                if (this.ColorObject.ConfirmBtn.Rect.Contains(e.Location))
                {
                    this.ColorObject.ConfirmBtn.MoveStatus = ColorItemMoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.ColorObject.ConfirmBtn.MoveStatus = ColorItemMoveStatuss.Normal;
                }
                #endregion
                this.Cursor = isenter ? Cursors.Hand : Cursors.Default;
            }
            #region Gradual
            else if (this.colorMoveStatus == ColorMoveStatuss.GradualDown)
            {
                this.Calculate_GradualSelectPoint_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.gradual_bmp.GetPixel(this.ColorObject.GradualSelectPoint.X, this.ColorObject.GradualSelectPoint.Y));
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region GradualBar
            else if (this.colorMoveStatus == ColorMoveStatuss.GradualBarDown)
            {
                this.Calculate_GradualBar_Value(e.Location);
                Color color = this.gradual_bar_bmp.GetPixel(this.ColorObject.GradualBarRect.Width / 2, this.ColorObject.GradualBarSlideValue);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, color);
                this.gradual_color = color;
                this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
                this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
                this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;

                this.Update_GradualBar_Rect(this.ColorObject.GradualBarSlideValue);
                this.Update_Gradual_Image();
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region A
            else if (this.colorMoveStatus == ColorMoveStatuss.ADown)
            {
                this.Calculate_A_Value(e.Location);
                this.currentValue = Color.FromArgb(this.ColorObject.CurrentValue_A_SlideValue, this.currentValue);
                this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region R
            else if (this.colorMoveStatus == ColorMoveStatuss.RDown)
            {
                this.Calculate_R_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.ColorObject.CurrentValue_R_SlideValue, this.currentValue.G, this.currentValue.B);
                this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region G
            else if (this.colorMoveStatus == ColorMoveStatuss.GDown)
            {
                this.Calculate_G_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.ColorObject.CurrentValue_G_SlideValue, this.currentValue.B);
                this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion
            #region B
            else if (this.colorMoveStatus == ColorMoveStatuss.BDown)
            {
                this.Calculate_B_Value(e.Location);
                this.currentValue = Color.FromArgb(this.currentValue.A, this.currentValue.R, this.currentValue.G, this.ColorObject.CurrentValue_B_SlideValue);
                this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

                this.UpdateColorText();

                this.Invalidate();
            }
            #endregion

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeControlRectangle();
            this.Invalidate();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            int scale_width = (int)(this.DefaultSize.Width * DotsPerInchHelper.DPIScale.XScale);
            int scale_height = (int)(this.DefaultSize.Height * DotsPerInchHelper.DPIScale.YScale);

            base.SetBoundsCore(x, y, scale_width, scale_height, specified);
            this.Invalidate();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.SolidBrushManageObject != null)
                    this.SolidBrushManageObject.ReleaseSolidBrushs();
                if (this.gradual_bmp != null)
                    this.gradual_bmp.Dispose();
                if (this.gradual_bar_bmp != null)
                    this.gradual_bar_bmp.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 颜色值更改事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnColorValueChanged(ColorValueChangedEventArgs e)
        {
            if (this.colorValueChanged != null)
            {
                this.colorValueChanged(this, e);
            }
        }

        /// <summary>
        /// html颜色面板选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHtmlColorItemClick(HtmlColorItemClickEventArgs e)
        {
            if (this.htmlColorItemClick != null)
            {
                this.htmlColorItemClick(this, e);
            }
        }

        /// <summary>
        /// 主题颜色面板选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnThemeColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.themeColorItemClick != null)
            {
                this.themeColorItemClick(this, e);
            }
        }

        /// <summary>
        /// 标准颜色面板选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStandardColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.standardColorItemClick != null)
            {
                this.standardColorItemClick(this, e);
            }
        }

        /// <summary>
        /// 自定义颜色面板选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCustomColorItemClick(ColorItemClickEventArgs e)
        {
            if (this.customColorItemClick != null)
            {
                this.customColorItemClick(this, e);
            }
        }

        /// <summary>
        /// 自定义颜色单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCustomClick(BottomBarIiemClickEventArgs e)
        {
            ColorManage.CustomColors[this.custom_select_row_index, this.custom_select_cel_index] = this.currentValue;
            int row = ColorManage.CustomColors.GetLength(0);
            int cel = ColorManage.CustomColors.GetLength(1);

            if (this.custom_select_cel_index < cel - 1)
            {
                this.custom_select_cel_index += 1;
            }
            else if (this.custom_select_row_index == 0)
            {
                this.custom_select_row_index = 1;
                this.custom_select_cel_index = 0;
            }
            else if (this.custom_select_row_index == 1)
            {
                this.custom_select_row_index = 0;
                this.custom_select_cel_index = 0;
            }
            this.Invalidate();

            if (this.bottomBarCustomClick != null)
            {
                this.bottomBarCustomClick(this, e);
            }
        }

        /// <summary>
        /// 清除单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClearClick(BottomBarIiemClickEventArgs e)
        {
            this.ColorValue = Color.Empty;

            if (this.bottomBarClearClick != null)
            {
                this.bottomBarClearClick(this, e);
            }
        }

        /// <summary>
        /// 确认单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnConfirmClick(BottomBarIiemClickEventArgs e)
        {
            this.ColorValue = this.currentValue;

            if (this.bottomBarConfirmClick != null)
            {
                this.bottomBarConfirmClick(this, e);
            }
        }

        #endregion

        #region 私有方法

        #region 颜色输入框事件

        private void colorTextBox_LostFocus(object sender, EventArgs e)
        {
            Color? color = this.ValidColor(this.colorTextBox.Text);
            if (!color.HasValue)
            {
                this.UpdateColorText();
            }
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            Color? color = this.ValidColor(this.colorTextBox.Text);
            if (color.HasValue)
            {
                this.UpdateColorInputValue(color.Value);
            }
        }

        #endregion

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeControlRectangle()
        {
            #region

            int color_width = (int)(203 * DotsPerInchHelper.DPIScale.XScale);//颜色面板宽度
            int color_height = (int)(212 * DotsPerInchHelper.DPIScale.XScale);//颜色面板高度

            int top_btn_width = (int)(70 * DotsPerInchHelper.DPIScale.XScale);//头部按钮宽度
            int top_btn_height = (int)(20 * DotsPerInchHelper.DPIScale.XScale);//头部按钮高度

            int theme_title_height = (int)(30 * DotsPerInchHelper.DPIScale.XScale);// 主题颜色标题高度
            int theme_item_width = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//主题颜色选项宽度
            int theme_item_height = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//主题颜色选项高度

            int standard_title_height = (int)(30 * DotsPerInchHelper.DPIScale.XScale);//标准颜色标题高度
            int standard_item_width = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//标准颜色选项宽度
            int standard_item_height = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//标准颜色选项高度

            int html_item_side = (int)(8 * DotsPerInchHelper.DPIScale.XScale);//html颜色选项六边形边长

            int custom_title_height = (int)(30 * DotsPerInchHelper.DPIScale.XScale);//自定义颜色标题高度
            int custom_item_width = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//自定义颜色选项宽度
            int custom_item_height = (int)(14 * DotsPerInchHelper.DPIScale.XScale);//自定义颜色选项高度

            int gradual_width = (int)(200 * DotsPerInchHelper.DPIScale.XScale);//渐变框宽度
            int gradual_height = (int)(135 * DotsPerInchHelper.DPIScale.XScale);//渐变框高度

            int gradualbar_width = (int)(30 * DotsPerInchHelper.DPIScale.XScale);//渐变栏宽度
            int gradualbar_height = (int)(220 * DotsPerInchHelper.DPIScale.XScale);//渐变栏高度
            int gradualbar_slide_height = (int)(6 * DotsPerInchHelper.DPIScale.XScale);//渐变栏滑块高度

            int argb_width = (int)(180 * DotsPerInchHelper.DPIScale.XScale);//ARGB宽度
            int argb_height = (int)(12 * DotsPerInchHelper.DPIScale.XScale);// ARGB高度
            int argb_slide_width = (int)(6 * DotsPerInchHelper.DPIScale.XScale);//ARGB滑块宽度

            int current_text_height = (int)(20 * DotsPerInchHelper.DPIScale.XScale);//当前颜色文本高度

            int bottom_btn_width = (int)(50 * DotsPerInchHelper.DPIScale.XScale);//底部按钮宽度
            int bottom_btn_height = (int)(30 * DotsPerInchHelper.DPIScale.XScale);//底部按钮高度
            #endregion

            this.ColorObject.ColorRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top, color_width, color_height);

            int scale_colorRect_left_padding = (int)(10 * DotsPerInchHelper.DPIScale.XScale);
            this.ColorObject.DefaultColorBtn.Rect = new Rectangle(this.ColorObject.ColorRect.Left + scale_colorRect_left_padding, this.ClientRectangle.Y + this.Padding.Top, top_btn_width, top_btn_height);
            this.ColorObject.HtmlColorBtn.Rect = new Rectangle(this.ColorObject.DefaultColorBtn.Rect.Right, this.ClientRectangle.Y + this.Padding.Top, top_btn_width, top_btn_height);

            int theme_color_rect_width = theme_item_width * this.ColorObject.ThemeColorsItem.GetLength(0) + (theme_item_width / 2 * (this.ColorObject.ThemeColorsItem.GetLength(0) - 1));
            int theme_color_rect_height = theme_item_height * this.ColorObject.ThemeColorsItem.GetLength(1) + theme_item_height / 2;
            this.ColorObject.ThemeTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top + top_btn_height, theme_color_rect_width, theme_title_height);
            this.ColorObject.ThemeRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.ThemeTitleRect.Bottom, theme_color_rect_width, theme_color_rect_height);
            for (int i = 0; i < this.ColorObject.ThemeColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.ThemeColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * i;
                    int y = this.ColorObject.ThemeTitleRect.Bottom + theme_item_height * j + (j > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.ThemeColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.ThemeColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.ThemeColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.ThemeColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            int tandard_color_rect_width = standard_item_width * this.ColorObject.StandardColorsItem.GetLength(1) + (standard_item_width / 2 * (this.ColorObject.StandardColorsItem.GetLength(1) - 1));
            int tandard_color_rect_height = standard_item_height * this.ColorObject.StandardColorsItem.GetLength(0) + (standard_item_height / 2 * (this.ColorObject.StandardColorsItem.GetLength(0) - 1));
            this.ColorObject.StandardTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.ThemeRect.Bottom, tandard_color_rect_width, standard_title_height);
            this.ColorObject.StandardRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.StandardTitleRect.Bottom, tandard_color_rect_width, tandard_color_rect_height);
            for (int i = 0; i < this.ColorObject.StandardColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.StandardColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * j;
                    int y = this.ColorObject.StandardTitleRect.Bottom + theme_item_height * i + (i > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.StandardColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.StandardColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.StandardColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.StandardColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            int custom_color_rect_width = custom_item_width * this.ColorObject.CustomColorsItem.GetLength(1) + (custom_item_width / 2 * (this.ColorObject.CustomColorsItem.GetLength(1) - 1));
            int custom_color_rect_height = custom_item_height * this.ColorObject.CustomColorsItem.GetLength(0) + (custom_item_height / 2 * (this.ColorObject.CustomColorsItem.GetLength(0) - 1));
            this.ColorObject.CustomTitleRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.StandardRect.Bottom, tandard_color_rect_width, custom_title_height);
            this.ColorObject.CustomRect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ColorObject.CustomTitleRect.Bottom, tandard_color_rect_width, tandard_color_rect_height);
            for (int i = 0; i < this.ColorObject.CustomColorsItem.GetLength(0); i++)
            {
                for (int j = 0; j < this.ColorObject.CustomColorsItem.GetLength(1); j++)
                {
                    int x = this.ColorObject.ThemeRect.X + (theme_item_width / 2 + theme_item_width) * j;
                    int y = this.ColorObject.CustomTitleRect.Bottom + theme_item_height * i + (i > 0 ? theme_item_height / 2 : 0);
                    this.ColorObject.CustomColorsItem[i, j].Rect = new Rectangle(x, y, theme_item_width, theme_item_height);
                    this.ColorObject.CustomColorsItem[i, j].ColorRowIndex = i;
                    this.ColorObject.CustomColorsItem[i, j].ColorColIndex = j;
                    this.ColorObject.CustomColorsItem[i, j].MoveStatus = ColorItemMoveStatuss.Normal;
                }
            }

            double html_w = html_item_side * Math.Cos(2 * Math.PI / 360 * 30);
            double html_h = html_item_side * Math.Sin(2 * Math.PI / 360 * 30);
            double html_top = (int)(10 * DotsPerInchHelper.DPIScale.XScale);
            double html_left = (this.ColorObject.ColorRect.Width - (this.ColorObject.HtmlColorsItem[this.ColorObject.HtmlColorsItem.Count / 2].ColorsRects.Count * html_w * 2)) / 2;
            for (int i = 0; i < this.ColorObject.HtmlColorsItem.Count; i++)
            {
                int num = Math.Abs(this.ColorObject.HtmlColorsItem.Count / 2 - i);
                for (int j = 0; j < this.ColorObject.HtmlColorsItem[i].ColorsRects.Count; j++)
                {
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[0] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side)));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[1] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[2] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[3] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2 + html_w), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side + html_h));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[4] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h + html_item_side));
                    this.ColorObject.HtmlColorsItem[i].ColorsRects[j].pointfs[5] = new PointF((float)(this.ClientRectangle.Left + html_left + num * html_w + j * html_w * 2), (float)(this.ColorObject.DefaultColorBtn.Rect.Bottom + html_top + i * (html_h + html_item_side) + html_h));
                }
            }

            int scale_padding = (int)(5 * DotsPerInchHelper.DPIScale.XScale);
            this.ColorObject.GradualRect = new Rectangle(this.ColorObject.ThemeRect.Right + scale_padding * 2, this.ClientRectangle.Y + this.Padding.Top + scale_padding, gradual_width, gradual_height);
            this.ColorObject.GradualBarRect = new Rectangle(this.ColorObject.GradualRect.Right + scale_padding * 2, this.ClientRectangle.Y + this.Padding.Top + scale_padding, gradualbar_width, gradualbar_height);
            this.ColorObject.GradualBarSlideRect = new Rectangle(this.ColorObject.GradualBarRect.X, this.ColorObject.GradualBarRect.Y + gradualbar_slide_height / 2, this.ColorObject.GradualBarRect.Width, gradualbar_slide_height);

            this.ColorObject.CurrentValue_A_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.GradualRect.Bottom + scale_padding * 2, argb_width, argb_height);
            this.ColorObject.CurrentValue_A_SlideRect = new Rectangle(this.ColorObject.CurrentValue_A_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_A_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_A_Rect.Height);

            this.ColorObject.CurrentValue_R_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_A_Rect.Bottom + scale_padding * 2, argb_width, argb_height);
            this.ColorObject.CurrentValue_R_SlideRect = new Rectangle(this.ColorObject.CurrentValue_R_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_R_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_R_Rect.Height);

            this.ColorObject.CurrentValue_G_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_R_Rect.Bottom + scale_padding * 2, argb_width, argb_height);
            this.ColorObject.CurrentValue_G_SlideRect = new Rectangle(this.ColorObject.CurrentValue_G_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_G_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_G_Rect.Height);

            this.ColorObject.CurrentValue_B_Rect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_G_Rect.Bottom + scale_padding * 2, argb_width, argb_height);
            this.ColorObject.CurrentValue_B_SlideRect = new Rectangle(this.ColorObject.CurrentValue_B_Rect.Right - argb_slide_width / 2, this.ColorObject.CurrentValue_B_Rect.Y, argb_slide_width, this.ColorObject.CurrentValue_B_Rect.Height);

            this.ColorObject.CurrentColorRect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentValue_B_SlideRect.Bottom + scale_padding * 2, current_text_height * 2, current_text_height);
            this.ColorObject.CurrentColorTextRect = new Rectangle(this.ColorObject.CurrentColorRect.Right, this.ColorObject.CurrentValue_B_SlideRect.Bottom + scale_padding * 2, tandard_color_rect_width, current_text_height);

            this.ColorObject.OriginalColorRect = new Rectangle(this.ColorObject.GradualRect.X, this.ColorObject.CurrentColorRect.Bottom + scale_padding, current_text_height * 2, current_text_height);
            this.ColorObject.OriginalColorTextRect = new Rectangle(this.ColorObject.CurrentColorRect.Right, this.ColorObject.CurrentColorRect.Bottom + scale_padding, tandard_color_rect_width, current_text_height);

            this.ColorObject.ConfirmBtn.Rect = new Rectangle(this.ClientRectangle.Right - bottom_btn_width - scale_padding, this.ClientRectangle.Bottom - bottom_btn_height - scale_padding, bottom_btn_width, bottom_btn_height);
            this.ColorObject.ClearBtn.Rect = new Rectangle(this.ColorObject.ConfirmBtn.Rect.X - scale_padding - bottom_btn_width, this.ClientRectangle.Bottom - bottom_btn_height - scale_padding, bottom_btn_width, bottom_btn_height);
            this.ColorObject.CustomBtn.Rect = new Rectangle(this.ColorObject.ClearBtn.Rect.X - scale_padding - scale_padding * 4 - bottom_btn_width, this.ClientRectangle.Bottom - bottom_btn_height - scale_padding, bottom_btn_width + scale_padding * 4, bottom_btn_height);

        }

        /// <summary>
        /// 计算渐变框选中点坐标值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_GradualSelectPoint_Value(Point point)
        {
            int x = point.X - this.ColorObject.GradualRect.X;
            if (x < 0)
                x = 0;
            if (x > this.ColorObject.GradualRect.Width - 1)
                x = this.ColorObject.GradualRect.Width - 1;
            int y = point.Y - this.ColorObject.GradualRect.Y;
            if (y < 0)
                y = 0;
            if (y > this.ColorObject.GradualRect.Height - 1)
                y = this.ColorObject.GradualRect.Height - 1;
            this.ColorObject.GradualSelectPoint = new Point(x, y);
        }
        /// <summary>
        /// 计算渐变栏滑块值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_GradualBar_Value(Point point)
        {
            int sum = this.ColorObject.GradualBarRect.Height - 1;
            int s = (int)(sum * (point.Y - this.ColorObject.GradualBarRect.Y) / (float)this.ColorObject.GradualBarRect.Height);
            if (s < 0)
                s = 0;
            if (s > sum)
                s = sum;
            this.ColorObject.GradualBarSlideValue = s;
        }

        /// <summary>
        /// 计算A滑块值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_A_Value(Point point)
        {
            int a = (int)(255 * (point.X - this.ColorObject.CurrentValue_A_Rect.X) / (float)this.ColorObject.CurrentValue_A_Rect.Width);
            if (a < byte.MinValue)
                a = byte.MinValue;
            if (a > byte.MaxValue)
                a = byte.MaxValue;
            this.ColorObject.CurrentValue_A_SlideValue = a;
        }
        /// <summary>
        /// 计算R滑块值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_R_Value(Point point)
        {
            int r = (int)(255 * (point.X - this.ColorObject.CurrentValue_R_Rect.X) / (float)this.ColorObject.CurrentValue_R_Rect.Width);
            if (r < byte.MinValue)
                r = byte.MinValue;
            if (r > byte.MaxValue)
                r = byte.MaxValue;
            this.ColorObject.CurrentValue_R_SlideValue = r;
        }
        /// <summary>
        /// 计算G滑块值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_G_Value(Point point)
        {
            int g = (int)(255 * (point.X - this.ColorObject.CurrentValue_G_Rect.X) / (float)this.ColorObject.CurrentValue_G_Rect.Width);
            if (g < byte.MinValue)
                g = byte.MinValue;
            if (g > byte.MaxValue)
                g = byte.MaxValue;
            this.ColorObject.CurrentValue_G_SlideValue = g;
        }
        /// <summary>
        /// 计算B滑块值
        /// </summary>
        /// <param name="point"></param>
        private void Calculate_B_Value(Point point)
        {
            int b = (int)(255 * (point.X - this.ColorObject.CurrentValue_B_Rect.X) / (float)this.ColorObject.CurrentValue_B_Rect.Width);
            if (b < byte.MinValue)
                b = byte.MinValue;
            if (b > byte.MaxValue)
                b = byte.MaxValue;
            this.ColorObject.CurrentValue_B_SlideValue = b;
        }

        /// <summary>
        /// 渐变栏滑块调整
        /// </summary>
        /// <param name="s"></param>
        private void Update_GradualBar_Rect(int s)
        {
            float sum = this.ColorObject.GradualBarRect.Height - 1;
            this.ColorObject.GradualBarSlideRect.Y = (int)(this.ColorObject.GradualBarRect.Y + (this.ColorObject.GradualBarRect.Height * s / sum) - this.ColorObject.GradualBarSlideRect.Height / 2);
        }
        /// <summary>
        /// A滑块调整
        /// </summary>
        /// <param name="a"></param>
        private void Update_A_Rect(int a)
        {
            this.ColorObject.CurrentValue_A_SlideRect.X = (int)(this.ColorObject.CurrentValue_A_Rect.X + (this.ColorObject.CurrentValue_A_Rect.Width * a / 255f) - this.ColorObject.CurrentValue_A_SlideRect.Width / 2);
        }
        /// <summary>
        /// R滑块调整
        /// </summary>
        /// <param name="r"></param>
        private void Update_R_Rect(int r)
        {
            this.ColorObject.CurrentValue_R_SlideRect.X = (int)(this.ColorObject.CurrentValue_R_Rect.X + (this.ColorObject.CurrentValue_R_Rect.Width * r / 255f) - this.ColorObject.CurrentValue_R_SlideRect.Width / 2);
        }
        /// <summary>
        /// G滑块调整
        /// </summary>
        /// <param name="g"></param>
        private void Update_G_Rect(int g)
        {
            this.ColorObject.CurrentValue_G_SlideRect.X = (int)(this.ColorObject.CurrentValue_G_Rect.X + (this.ColorObject.CurrentValue_G_Rect.Width * g / 255f) - this.ColorObject.CurrentValue_G_SlideRect.Width / 2);
        }
        /// <summary>
        /// B滑块调整
        /// </summary>
        /// <param name="b"></param>
        private void Update_B_Rect(int b)
        {
            this.ColorObject.CurrentValue_B_SlideRect.X = (int)(this.ColorObject.CurrentValue_B_Rect.X + (this.ColorObject.CurrentValue_B_Rect.Width * b / 255f) - this.ColorObject.CurrentValue_B_SlideRect.Width / 2);
        }

        /// <summary>
        /// 更新渐变框图片
        /// </summary>
        private void Update_Gradual_Image()
        {
            Rectangle bmp_rect = new Rectangle(0, 0, this.gradual_bmp.Width, this.gradual_bmp.Height);
            Graphics g = Graphics.FromImage(this.gradual_bmp);

            this.SolidBrushManageObject.common_sb.Color = this.gradual_color;
            g.FillRectangle(this.SolidBrushManageObject.common_sb, bmp_rect);

            g.FillRectangle(this.SolidBrushManageObject.gradual_h_lgb, bmp_rect);
            g.FillRectangle(this.SolidBrushManageObject.gradual_v_lgb, bmp_rect);

            g.Dispose();
        }

        /// <summary>
        /// 更新渐变栏图片
        /// </summary>
        private void Update_GradualBar_Image()
        {
            Rectangle barbmp_rect = new Rectangle(0, 0, this.gradual_bar_bmp.Width, this.gradual_bar_bmp.Height);
            Graphics g = Graphics.FromImage(this.gradual_bar_bmp);
            LinearGradientBrush gradualbar_lgb = new LinearGradientBrush(this.ColorObject.GradualBarRect, Color.Transparent, Color.Transparent, 90) { InterpolationColors = new ColorBlend() { Colors = ColorManage.GradualBarcolors, Positions = ColorManage.GradualBarInterval } };
            g.FillRectangle(gradualbar_lgb, barbmp_rect);
            gradualbar_lgb.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 更新日期输入框Location、Size
        /// </summary>
        private void UpdateLocationSize()
        {
            this.colorTextBox.Location = new Point(0, 0);
        }

        /// <summary>
        /// 获取颜色输入框Rect
        /// </summary>
        /// <returns></returns>
        internal Rectangle GetColorTextBoxRect()
        {
            return new Rectangle(
                this.ColorObject.CurrentColorTextRect.X + (int)(60 * DotsPerInchHelper.DPIScale.XScale),
                this.ColorObject.CurrentColorTextRect.Y + (int)(3 * DotsPerInchHelper.DPIScale.XScale),
                (int)(colorTextWidth * DotsPerInchHelper.DPIScale.XScale),
                this.ColorObject.CurrentColorTextRect.Height
                );
        }

        /// <summary>
        /// 更新输入框颜色文本
        /// </summary>
        private void UpdateColorText()
        {
            this.colorTextBox.Text = String.Format("{0},{1},{2},{3}", this.ColorObject.CurrentValue_A_SlideValue, this.ColorObject.CurrentValue_R_SlideValue, this.ColorObject.CurrentValue_G_SlideValue, this.ColorObject.CurrentValue_B_SlideValue);
        }

        /// <summary>
        /// 修改颜色面板颜色值
        /// </summary>
        /// <param name="color"></param>
        private void UpdateColorInputValue(Color color)
        {
            this.ColorObject.CurrentValue_A_SlideValue = color.A;
            this.ColorObject.CurrentValue_R_SlideValue = color.R;
            this.ColorObject.CurrentValue_G_SlideValue = color.G;
            this.ColorObject.CurrentValue_B_SlideValue = color.B;

            this.Update_R_Rect(this.ColorObject.CurrentValue_A_SlideValue);
            this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
            this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
            this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

            this.gradual_color = color;
            this.ColorObject.GradualSelectPoint = Point.Empty;
            this.Update_Gradual_Image();

            this.Invalidate();
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化面板颜色
        /// </summary>
        public void InitializeColor()
        {
            this.currentValue = this.ColorValue;
            this.defaultColorValue = this.ColorValue;

            this.ColorObject.CurrentValue_A_SlideValue = this.currentValue.A;
            this.ColorObject.CurrentValue_R_SlideValue = this.currentValue.R;
            this.ColorObject.CurrentValue_G_SlideValue = this.currentValue.G;
            this.ColorObject.CurrentValue_B_SlideValue = this.currentValue.B;
            this.gradual_color = Color.FromArgb(byte.MaxValue, this.currentValue);
            this.ColorObject.GradualSelectPoint = Point.Empty;
            this.Update_Gradual_Image();
            this.Update_A_Rect(this.ColorObject.CurrentValue_A_SlideValue);
            this.Update_R_Rect(this.ColorObject.CurrentValue_R_SlideValue);
            this.Update_G_Rect(this.ColorObject.CurrentValue_G_SlideValue);
            this.Update_B_Rect(this.ColorObject.CurrentValue_B_SlideValue);

            this.UpdateColorText();
        }

        /// <summary>
        /// 验证颜色字符串是否有效
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color? ValidColor(string color)
        {
            color = color.Replace(" ", "");
            Color? color_tmp = null;
            string argb_reg = @"^((2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?),){2}((2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?),)?(2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?)$";//ARGB
            string h16_reg = @"^#([0-9a-fA-F]{6}[0-9a-fA-F]{8}|[0-9a-fA-F]{3}|[0-9a-fA-F]{4})$";//十六进制颜色
            if (Regex.IsMatch(color, argb_reg))
            {
                string[] color_arr = color.Split(',');
                if (color_arr.Length == 3)
                {
                    color_tmp = Color.FromArgb(255, int.Parse(color_arr[0]), int.Parse(color_arr[1]), int.Parse(color_arr[2]));
                }
                else if (color_arr.Length == 4)
                {
                    color_tmp = Color.FromArgb(int.Parse(color_arr[0]), int.Parse(color_arr[1]), int.Parse(color_arr[2]), int.Parse(color_arr[3]));
                }
            }
            else if (Regex.IsMatch(color, h16_reg))
            {
                color_tmp = ColorTranslator.FromHtml(color);
            }
            return color_tmp;
        }

        /// <summary>
        ///  更新颜色面板的颜色但不刷新颜色面板界面
        /// </summary>
        /// <param name="date"></param>
        public void UpdateDateValueNotInvalidate(Color color)
        {
            if (this.colorValue == color)
                return;

            ColorValueChangedEventArgs arg = new ColorValueChangedEventArgs() { OldColorValue = this.colorValue, NewColorValue = color };
            this.colorValue = color;

            this.OnColorValueChanged(arg);
        }

        #endregion

        #region  类

        /// <summary>
        /// 顶部选项
        /// </summary>
        [Description("顶部选项")]
        public class TopBarItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public TopBarItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            /// <summary>
            /// 顶部选项rect信息
            /// </summary>
            public Rectangle Rect;

            /// <summary>
            ///顶部选项文本
            /// </summary>
            public string Text;

        }

        /// <summary>
        /// 底部选项
        /// </summary>
        [Description("底部选项")]
        public class BottomBarItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public BottomBarItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            /// <summary>
            /// 底部选项rect信息
            /// </summary>
            public Rectangle Rect;

            /// <summary>
            ///底部选项文本
            /// </summary>
            public string Text;

            private ColorItemMoveStatuss moveStatus = ColorItemMoveStatuss.Normal;
            /// <summary>
            /// 底部选项鼠标状态
            /// </summary>
            [DefaultValue(ColorItemMoveStatuss.Normal)]
            [Description("底部选项鼠标状态")]
            public ColorItemMoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                    if (this.parent != null)
                    {
                        this.parent.Invalidate();
                    }
                }
            }

        }

        /// <summary>
        /// 颜色面板
        /// </summary>
        [Description("颜色面板")]
        public class ColorClass
        {
            public ColorPickerExt parent;

            public ColorClass(ColorPickerExt parent)
            {
                this.parent = parent;

                this.DefaultColorBtn = new TopBarItemClass(parent, this) { Text = "默认颜色" };
                this.HtmlColorBtn = new TopBarItemClass(parent, this) { Text = "Html颜色" };

                this.ThemeColorsItem = new ColorItemClass[ColorManage.ThemeColors.GetLength(0), ColorManage.ThemeColors.GetLength(1)];
                for (int i = 0; i < ColorManage.ThemeColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.ThemeColors.GetLength(1); j++)
                    {
                        this.ThemeColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }
                this.StandardColorsItem = new ColorItemClass[ColorManage.StandardColors.GetLength(0), ColorManage.StandardColors.GetLength(1)];
                for (int i = 0; i < ColorManage.StandardColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.StandardColors.GetLength(1); j++)
                    {
                        this.StandardColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }

                this.HtmlColorsItem = new List<HtmlColorsRectItem>();
                for (int i = 0; i < ColorManage.HtmlColors.Count; i++)
                {
                    HtmlColorsRectItem RectItem = new HtmlColorsRectItem();
                    for (int j = 0; j < ColorManage.HtmlColors[i].Colors.Count; j++)
                    {
                        RectItem.ColorsRects.Add(new HtmlColorsRectPointItem() { pointfs = new PointF[6] });
                    }
                    HtmlColorsItem.Add(RectItem);
                }

                this.CustomColorsItem = new ColorItemClass[ColorManage.CustomColors.GetLength(0), ColorManage.CustomColors.GetLength(1)];
                for (int i = 0; i < ColorManage.CustomColors.GetLength(0); i++)
                {
                    for (int j = 0; j < ColorManage.CustomColors.GetLength(1); j++)
                    {
                        this.CustomColorsItem[i, j] = new ColorItemClass(parent, this);
                    }
                }

                this.CustomBtn = new BottomBarItemClass(parent, this) { Text = "自定义颜色", MoveStatus = ColorItemMoveStatuss.Normal };
                this.ClearBtn = new BottomBarItemClass(parent, this) { Text = "清除", MoveStatus = ColorItemMoveStatuss.Normal };
                this.ConfirmBtn = new BottomBarItemClass(parent, this) { Text = "确定", MoveStatus = ColorItemMoveStatuss.Normal };
            }

            /// <summary>
            /// 默认颜色按钮
            /// </summary>
            public TopBarItemClass DefaultColorBtn;
            /// <summary>
            /// Html颜色按钮
            /// </summary>
            public TopBarItemClass HtmlColorBtn;

            /// <summary>
            /// 颜色面板rect信息
            /// </summary>
            public Rectangle ColorRect;

            /// <summary>
            /// 主题颜色标题rect信息
            /// </summary>
            public Rectangle ThemeTitleRect;
            /// <summary>
            /// 主题颜色rect信息
            /// </summary>
            public Rectangle ThemeRect;
            /// <summary>
            /// 主题颜色选项列表
            /// </summary>
            public ColorItemClass[,] ThemeColorsItem;

            /// <summary>
            /// 标准颜色标题rect信息
            /// </summary>
            public Rectangle StandardTitleRect;
            /// <summary>
            ///  标准颜色rect信息
            /// </summary>
            public Rectangle StandardRect;
            /// <summary>
            /// 标准颜色选项列表
            /// </summary>
            public ColorItemClass[,] StandardColorsItem;

            /// <summary>
            /// html颜色选项列表
            /// </summary>
            public List<HtmlColorsRectItem> HtmlColorsItem;

            /// <summary>
            /// 自定义颜色标题rect信息
            /// </summary>
            public Rectangle CustomTitleRect;
            /// <summary>
            ///  自定义颜色rect信息
            /// </summary>
            public Rectangle CustomRect;
            /// <summary>
            /// 自定义颜色选项列表
            /// </summary>
            public ColorItemClass[,] CustomColorsItem;

            /// <summary>
            /// 当前颜色文本rect信息
            /// </summary>
            public Rectangle CurrentColorTextRect;
            /// <summary>
            /// 当前颜色rect信息
            /// </summary>
            public Rectangle CurrentColorRect;
            /// <summary>
            /// 原始颜色文本rect信息
            /// </summary>
            public Rectangle OriginalColorTextRect;
            /// <summary>
            /// 原始颜色rect信息
            /// </summary>
            public Rectangle OriginalColorRect;

            /// <summary>
            /// 渐变框rect信息
            /// </summary>
            public Rectangle GradualRect;
            /// <summary>
            /// 渐变框选中坐标
            /// </summary>
            public Point GradualSelectPoint = Point.Empty;
            /// <summary>
            /// 渐变栏rect信息
            /// </summary>
            public Rectangle GradualBarRect;
            /// <summary>
            /// 渐变栏滑块rect信息
            /// </summary>
            public Rectangle GradualBarSlideRect;
            /// <summary>
            /// 渐变栏滑块值
            /// </summary>
            public int GradualBarSlideValue;

            /// <summary>
            /// 当前颜色A的rect信息
            /// </summary>
            public Rectangle CurrentValue_A_Rect;
            /// <summary>
            /// 当前颜色滑块的rect信息
            /// </summary>
            public Rectangle CurrentValue_A_SlideRect;
            /// <summary>
            /// 当前颜色A滑块的值
            /// </summary>
            public int CurrentValue_A_SlideValue;
            /// <summary>
            /// 当前颜色R的rect信息
            /// </summary>
            public Rectangle CurrentValue_R_Rect;
            /// <summary>
            /// 当前颜色R滑块的rect信息
            /// </summary>
            public Rectangle CurrentValue_R_SlideRect;
            /// <summary>
            /// 当前颜色R滑块的值
            /// </summary>
            public int CurrentValue_R_SlideValue;
            /// <summary>
            /// 当前颜色G的rect信息
            /// </summary>
            public Rectangle CurrentValue_G_Rect;
            /// <summary>
            /// 当前颜色G滑块的rect信息
            /// </summary>
            public Rectangle CurrentValue_G_SlideRect;
            /// <summary>
            /// 当前颜色G滑块的值
            /// </summary>
            public int CurrentValue_G_SlideValue;
            /// <summary>
            /// 当前颜色B的rect信息
            /// </summary>
            public Rectangle CurrentValue_B_Rect;
            /// <summary>
            /// 当前颜色B滑块的rect信息
            /// </summary>
            public Rectangle CurrentValue_B_SlideRect;
            /// <summary>
            /// 当前颜色B滑块的值
            /// </summary>
            public int CurrentValue_B_SlideValue;

            /// <summary>
            /// 底部自定义颜色按钮
            /// </summary>
            public BottomBarItemClass CustomBtn;
            /// <summary>
            /// 底部清除按钮
            /// </summary>
            public BottomBarItemClass ClearBtn;
            /// <summary>
            /// 底部确定按钮
            /// </summary>
            public BottomBarItemClass ConfirmBtn;
        }

        /// <summary>
        /// 颜色面板选项
        /// </summary>
        [Description("颜色面板选项")]
        public class ColorItemClass
        {
            public ColorPickerExt parent;
            public ColorClass ower;

            public ColorItemClass(ColorPickerExt parent, ColorClass ower)
            {
                this.parent = parent;
                this.ower = ower;
            }

            /// <summary>
            /// 选项rect信息
            /// </summary>
            public Rectangle Rect;
            /// <summary>
            ///颜色表行索引
            /// </summary>
            public int ColorRowIndex;
            /// <summary>
            ///颜色表列索引
            /// </summary>
            public int ColorColIndex;

            private ColorItemMoveStatuss moveStatus = ColorItemMoveStatuss.Normal;
            /// <summary>
            /// 选项鼠标状态
            /// </summary>
            [DefaultValue(ColorItemMoveStatuss.Normal)]
            [Description("选项鼠标状态")]
            public ColorItemMoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                    if (this.parent != null)
                    {
                        this.parent.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// html颜色集合
        /// </summary>
        [Description("html颜色集合")]
        public class HtmlColorsItem
        {
            public List<Color> Colors = new List<Color>();
        }

        /// <summary>
        /// html颜色选项集合
        /// </summary>
        [Description("html颜色选项集合")]
        public class HtmlColorsRectItem
        {
            public List<HtmlColorsRectPointItem> ColorsRects = new List<HtmlColorsRectPointItem>();
        }

        /// <summary>
        /// html颜色选项
        /// </summary>
        [Description("html颜色选项")]
        public class HtmlColorsRectPointItem
        {
            /// <summary>
            /// html六边形六个坐标
            /// </summary>
            public PointF[] pointfs;
        }

        /// <summary>
        /// 画笔管理
        /// </summary>
        [Description("画笔管理")]
        public class SolidBrushManage
        {
            private ColorPickerExt ower;

            public SolidBrushManage(ColorPickerExt ower)
            {
                this.ower = ower;
            }

            private Rectangle gradual_rect
            {
                get { return new Rectangle(0, 0, this.ower.ColorObject.GradualRect.Width - 1, this.ower.ColorObject.GradualRect.Height - 1); }
            }

            private Rectangle argb_lgb_rect
            {
                get { return new Rectangle(this.ower.ColorObject.CurrentValue_A_Rect.X - 1, 0, this.ower.ColorObject.CurrentValue_A_Rect.Width, this.ower.ColorObject.CurrentValue_A_Rect.Height); }
            }

            #region

            private ImageAttributes _back_image_ia = null;
            /// <summary>
            /// 背景图平铺
            /// </summary>
            public ImageAttributes back_image_ia
            {
                get
                {
                    if (this._back_image_ia == null)
                    {
                        this._back_image_ia = new ImageAttributes();
                        this.back_image_ia.SetWrapMode(WrapMode.Tile);
                    }
                    return this._back_image_ia;
                }
            }

            private LinearGradientBrush _gradual_h_lgb = null;
            /// <summary>
            /// 渐变框横向渐变画笔
            /// </summary>
            public LinearGradientBrush gradual_h_lgb
            {
                get
                {
                    if (this._gradual_h_lgb == null)
                        this._gradual_h_lgb = new LinearGradientBrush(this.gradual_rect, Color.White, Color.Transparent, 0f);
                    return this._gradual_h_lgb;
                }
            }

            private LinearGradientBrush _gradual_v_lgb = null;
            /// <summary>
            /// 渐变框纵向渐变画笔
            /// </summary>
            public LinearGradientBrush gradual_v_lgb
            {
                get
                {
                    if (this._gradual_v_lgb == null)
                        this._gradual_v_lgb = new LinearGradientBrush(this.gradual_rect, Color.Transparent, Color.Black, 90f);
                    return this._gradual_v_lgb;
                }
            }

            private LinearGradientBrush _argb_lgb = null;
            /// <summary>
            /// ARGB渐变画笔
            /// </summary>
            public LinearGradientBrush argb_lgb
            {
                get
                {
                    if (this._argb_lgb == null)
                        this._argb_lgb = new LinearGradientBrush(this.argb_lgb_rect, Color.Transparent, Color.Yellow, 0f);
                    return this._argb_lgb;
                }
            }

            private Pen _border_pen = null;
            /// <summary>
            /// 边框钢笔
            /// </summary>
            public Pen border_pen
            {
                get
                {
                    if (this._border_pen == null)
                        this._border_pen = new Pen(Color.FromArgb(100, 102, 102, 102), 1);
                    return this._border_pen;
                }
            }

            private Pen _border_ts_pen = null;
            /// <summary>
            /// 主题标准颜色选项边框钢笔
            /// </summary>
            public Pen border_ts_pen
            {
                get
                {
                    if (this._border_ts_pen == null)
                        this._border_ts_pen = new Pen(Color.FromArgb(255, 193, 7), 1);
                    return this._border_ts_pen;
                }
            }

            private Pen _border_slide_pen = null;
            /// <summary>
            /// 滑块边框钢笔
            /// </summary>
            public Pen border_slide_pen
            {
                get
                {
                    if (this._border_slide_pen == null)
                        this._border_slide_pen = new Pen(Color.FromArgb(200, 105, 105, 105), 1);
                    return this._border_slide_pen;
                }
            }

            private SolidBrush _common_sb = null;
            /// <summary>
            /// 通用随时更改颜色画笔
            /// </summary>
            public SolidBrush common_sb
            {
                get
                {
                    if (this._common_sb == null)
                        this._common_sb = new SolidBrush(Color.White);
                    return this._common_sb;
                }
            }

            private Pen _common_pen = null;
            /// <summary>
            /// 通用随时更改颜色钢笔
            /// </summary>
            public Pen common_pen
            {
                get
                {
                    if (this._common_pen == null)
                        this._common_pen = new Pen(Color.White, 1);
                    return this._common_pen;
                }
            }

            #endregion

            #region 字体

            private Font _text_font = null;
            /// <summary>
            /// 字体
            /// </summary>
            public Font text_font
            {
                get
                {
                    if (this._text_font == null)
                        this._text_font = new Font("微软雅黑", 9);
                    return this._text_font;
                }
            }

            #endregion


            /// <summary>
            /// 释放所有画笔、字体
            /// </summary>
            public void ReleaseSolidBrushs()
            {
                #region
                if (this._back_image_ia != null)
                {
                    this._back_image_ia.Dispose();
                    this._back_image_ia = null;
                }
                if (this.gradual_h_lgb != null)
                {
                    this._gradual_h_lgb.Dispose();
                    this._gradual_h_lgb = null;
                }
                if (this.gradual_v_lgb != null)
                {
                    this._gradual_v_lgb.Dispose();
                    this._gradual_v_lgb = null;
                }
                if (this.argb_lgb != null)
                {
                    this._argb_lgb.Dispose();
                    this._argb_lgb = null;
                }
                if (this.border_pen != null)
                {
                    this._border_pen.Dispose();
                    this._border_pen = null;
                }
                if (this.border_ts_pen != null)
                {
                    this._border_ts_pen.Dispose();
                    this._border_ts_pen = null;
                }
                if (this.border_slide_pen != null)
                {
                    this._border_slide_pen.Dispose();
                    this._border_slide_pen = null;
                }
                if (this.common_sb != null)
                {
                    this._common_sb.Dispose();
                    this._common_sb = null;
                }
                if (this.common_pen != null)
                {
                    this._common_pen.Dispose();
                    this._common_pen = null;
                }
                #endregion

                #region 字体
                if (this.text_font != null)
                {
                    this._text_font.Dispose();
                    this._text_font = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 颜色表管理
        /// </summary>
        [Description("颜色表管理")]
        public static class ColorManage
        {
            public static readonly Color[,] ThemeColors = new Color[10, 6] {
         { Color.FromArgb(255, 255, 255), Color.FromArgb(242, 242, 242), Color.FromArgb(216, 216, 216), Color.FromArgb(191, 191, 191), Color.FromArgb(165, 165, 165), Color.FromArgb(127, 127, 127) },
         { Color.FromArgb(0, 0, 0), Color.FromArgb(127, 127, 127), Color.FromArgb(89, 89, 89), Color.FromArgb(63, 63, 63), Color.FromArgb(38, 38, 38), Color.FromArgb(12, 12, 12) },
         { Color.FromArgb(238, 236, 225), Color.FromArgb(221, 217, 195), Color.FromArgb(196, 189, 151), Color.FromArgb(147, 137, 83), Color.FromArgb(73, 68, 41), Color.FromArgb(29, 27, 16) },
         { Color.FromArgb(31, 73, 125), Color.FromArgb(198, 217, 240), Color.FromArgb(141, 179, 226), Color.FromArgb(84, 141, 212), Color.FromArgb(23, 54, 93), Color.FromArgb(15, 36, 62) },
         { Color.FromArgb(79, 129, 189), Color.FromArgb(219, 229, 241), Color.FromArgb(184, 204, 228), Color.FromArgb(149, 179, 215), Color.FromArgb(54, 96, 146), Color.FromArgb(36, 64, 97) },
         { Color.FromArgb(192, 80, 77), Color.FromArgb(242, 220, 219), Color.FromArgb(229, 185, 183), Color.FromArgb(217, 150, 148), Color.FromArgb(149, 55, 52), Color.FromArgb(99, 36, 35) },
         { Color.FromArgb(155, 187, 89), Color.FromArgb(235, 241, 221), Color.FromArgb(215, 227, 188), Color.FromArgb(195, 214, 155), Color.FromArgb(118, 146, 60), Color.FromArgb(79, 97, 40) },
         { Color.FromArgb(128, 100, 162), Color.FromArgb(229, 224, 236), Color.FromArgb(204, 193, 217), Color.FromArgb(178, 162, 199), Color.FromArgb(95, 73, 122), Color.FromArgb(63, 49, 81) },
         { Color.FromArgb(75, 172, 198), Color.FromArgb(219, 238, 243), Color.FromArgb(183, 221, 232), Color.FromArgb(146, 205, 220), Color.FromArgb(49, 133, 155), Color.FromArgb(32, 88, 103) },
         { Color.FromArgb(247, 150, 70), Color.FromArgb(253, 234, 218), Color.FromArgb(251, 213, 181), Color.FromArgb(250, 192, 143), Color.FromArgb(227, 108, 9), Color.FromArgb(151, 72, 6) },
         };

            public static readonly Color[,] StandardColors = new Color[2, 10] {
         { Color.FromArgb(244, 67, 54), Color.FromArgb(233, 30, 99),Color.FromArgb(160, 115, 232), Color.FromArgb(156, 39, 176), Color.FromArgb(103, 58, 183), Color.FromArgb(63, 81, 181), Color.FromArgb(33, 150, 243), Color.FromArgb(33, 150, 243), Color.FromArgb(0, 188, 212),Color.FromArgb(158, 158, 158) },
         {Color.FromArgb(1, 255, 255), Color.FromArgb(0, 150, 136), Color.FromArgb(76, 175, 80), Color.FromArgb(139, 195, 74), Color.FromArgb(205, 220, 57), Color.FromArgb(255, 235, 59), Color.FromArgb(255, 193, 7), Color.FromArgb(255, 152, 0), Color.FromArgb(255, 87, 34),Color.FromArgb(121, 85, 72) }
         };

            public static Color[,] CustomColors = new Color[2, 10] {
         { Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0)},
         { Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0),Color.FromArgb(0, 0, 0,0)}
         };

            public static readonly Color[] GradualBarcolors = new Color[7] { Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 0) };
            public static readonly float[] GradualBarInterval = new float[7] { 0.0f, 0.17f, 0.33f, 0.50f, 0.67f, 0.83f, 1.0f };

            public static List<HtmlColorsItem> HtmlColors = new List<HtmlColorsItem>() {
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#003366"),ColorTranslator.FromHtml("#336699"),ColorTranslator.FromHtml("#3366cc"),ColorTranslator.FromHtml("#003399"),ColorTranslator.FromHtml("#000099"),ColorTranslator.FromHtml("#0000cc"),ColorTranslator.FromHtml("#000066")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#006666"),ColorTranslator.FromHtml("#006699"),ColorTranslator.FromHtml("#0099cc"),ColorTranslator.FromHtml("#0066cc"),ColorTranslator.FromHtml("#0033cc"),ColorTranslator.FromHtml("#0000ff"),ColorTranslator.FromHtml("#3333ff"),ColorTranslator.FromHtml("#333399") }},
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#669999"),ColorTranslator.FromHtml("#009999"),ColorTranslator.FromHtml("#33cccc"),ColorTranslator.FromHtml("#00ccff"),ColorTranslator.FromHtml("#0099ff"),ColorTranslator.FromHtml("#0066ff"),ColorTranslator.FromHtml("#3366ff"),ColorTranslator.FromHtml("#3333cc"),ColorTranslator.FromHtml("#666699")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#339966"),ColorTranslator.FromHtml("#00cc99"),ColorTranslator.FromHtml("#00ffcc"),ColorTranslator.FromHtml("#00ffff"),ColorTranslator.FromHtml("#33ccff"),ColorTranslator.FromHtml("#3399ff"),ColorTranslator.FromHtml("#6699ff"),ColorTranslator.FromHtml("#6666ff"),ColorTranslator.FromHtml("#6600ff"),ColorTranslator.FromHtml("#6600cc")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#339933"),ColorTranslator.FromHtml("#00cc66"),ColorTranslator.FromHtml("#00ff99"),ColorTranslator.FromHtml("#66ffcc"),ColorTranslator.FromHtml("#66ffff"),ColorTranslator.FromHtml("#66ccff"),ColorTranslator.FromHtml("#99ccff"),ColorTranslator.FromHtml("#9999ff"),ColorTranslator.FromHtml("#9966ff"),ColorTranslator.FromHtml("#9933ff"),ColorTranslator.FromHtml("#9900ff")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#006600"),ColorTranslator.FromHtml("#00cc00"),ColorTranslator.FromHtml("#00ff00"),ColorTranslator.FromHtml("#66ff99"),ColorTranslator.FromHtml("#99ffcc"),ColorTranslator.FromHtml("#ccffff"),ColorTranslator.FromHtml("#ccccff"),ColorTranslator.FromHtml("#cc99ff"),ColorTranslator.FromHtml("#cc66ff"),ColorTranslator.FromHtml("#cc33ff"),ColorTranslator.FromHtml("#cc00ff"),ColorTranslator.FromHtml("#9900cc")}},
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#003300"),ColorTranslator.FromHtml("#009933"),ColorTranslator.FromHtml("#33cc33"),ColorTranslator.FromHtml("#66ff66"),ColorTranslator.FromHtml("#99ff99"),ColorTranslator.FromHtml("#ccffcc"),ColorTranslator.FromHtml("#ffffff"),ColorTranslator.FromHtml("#ffccff"),ColorTranslator.FromHtml("#ff99ff"),ColorTranslator.FromHtml("#ff66ff"),ColorTranslator.FromHtml("#ff00ff"),ColorTranslator.FromHtml("#cc00cc"),ColorTranslator.FromHtml("#660066")} },
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#333300"),ColorTranslator.FromHtml("#009900"),ColorTranslator.FromHtml("#66ff33"),ColorTranslator.FromHtml("#99ff66"),ColorTranslator.FromHtml("#ccff99"),ColorTranslator.FromHtml("#ffffcc"),ColorTranslator.FromHtml("#ffcccc"),ColorTranslator.FromHtml("#ff99cc"),ColorTranslator.FromHtml("#ff66cc"),ColorTranslator.FromHtml("#ff33cc"),ColorTranslator.FromHtml("#cc0099"),ColorTranslator.FromHtml("#993399")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#336600"),ColorTranslator.FromHtml("#669900"),ColorTranslator.FromHtml("#99ff33"),ColorTranslator.FromHtml("#ccff66"),ColorTranslator.FromHtml("#ffff99"),ColorTranslator.FromHtml("#ffcc99"),ColorTranslator.FromHtml("#ff9999"),ColorTranslator.FromHtml("#ff6699"),ColorTranslator.FromHtml("#ff3399"),ColorTranslator.FromHtml("#cc3399"),ColorTranslator.FromHtml("#990099")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#666633"),ColorTranslator.FromHtml("#99cc00"),ColorTranslator.FromHtml("#ccff33"),ColorTranslator.FromHtml("#ffff66"),ColorTranslator.FromHtml("#ffcc66"),ColorTranslator.FromHtml("#ff9966"),ColorTranslator.FromHtml("#ff6666"),ColorTranslator.FromHtml("#ff0066"),ColorTranslator.FromHtml("#d60094"),ColorTranslator.FromHtml("#993366")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#a58800"),ColorTranslator.FromHtml("#cccc00"),ColorTranslator.FromHtml("#ffff00"),ColorTranslator.FromHtml("#ffcc00"),ColorTranslator.FromHtml("#ff9933"),ColorTranslator.FromHtml("#ff6600"),ColorTranslator.FromHtml("#ff0033"),ColorTranslator.FromHtml("#cc0066"),ColorTranslator.FromHtml("#660033")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#996633"),ColorTranslator.FromHtml("#cc9900"),ColorTranslator.FromHtml("#ff9900"),ColorTranslator.FromHtml("#cc6600"),ColorTranslator.FromHtml("#ff3300"),ColorTranslator.FromHtml("#ff0000"),ColorTranslator.FromHtml("#cc0000"),ColorTranslator.FromHtml("#990033")}} ,
                new HtmlColorsItem(){  Colors=  new List<Color>(){ ColorTranslator.FromHtml("#663300"),ColorTranslator.FromHtml("#996600"),ColorTranslator.FromHtml("#cc3300"),ColorTranslator.FromHtml("#993300"),ColorTranslator.FromHtml("#990000"),ColorTranslator.FromHtml("#800000"),ColorTranslator.FromHtml("#993333")}}
                };

        }

        /// <summary>
        /// 颜色值更改事件参数
        /// </summary>
        [Description("颜色值更改事件参数")]
        public class ColorValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 更改前颜色
            /// </summary>
            [Description("更改前颜色")]
            public Color OldColorValue { get; set; }
            /// <summary>
            /// 更改后颜色
            /// </summary>
            [Description("更改后颜色")]
            public Color NewColorValue { get; set; }
        }

        /// <summary>
        /// html选项单击事件参数
        /// </summary>
        [Description("html选项单击事件参数")]
        public class HtmlColorItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// html颜色面板选项
            /// </summary>
            [Description("html颜色面板选项")]
            public HtmlColorsRectPointItem Item { get; set; }
        }

        /// <summary>
        /// 颜色选项单击事件参数
        /// </summary>
        [Description("颜色选项单击事件参数")]
        public class ColorItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 颜色面板选项
            /// </summary>
            [Description("颜色面板选项")]
            public ColorItemClass Item { get; set; }
        }

        /// <summary>
        /// 底部选项单击事件参数
        /// </summary>
        [Description("底部选项单击事件参数")]
        public class BottomBarIiemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 底部选项
            /// </summary>
            [Description("底部选项")]
            public BottomBarItemClass Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鼠标在选项上状态
        /// </summary>
        [Description("鼠标在选项上状态")]
        public enum ColorItemMoveStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter
        }

        /// <summary>
        /// 鼠标状态
        /// </summary>
        [Description("鼠标状态")]
        public enum ColorMoveStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// Html颜色按下
            /// </summary>
            HtmlDown,
            /// <summary>
            /// 主题颜色按下
            /// </summary>
            ThemeDown,
            /// <summary>
            /// 标准颜色按下
            /// </summary>
            StandardDown,
            /// <summary>
            /// 渐变框按下
            /// </summary>
            GradualDown,
            /// <summary>
            /// 渐变栏按下
            /// </summary>
            GradualBarDown,
            /// <summary>
            /// A按下
            /// </summary>
            ADown,
            /// <summary>
            /// R按下
            /// </summary>
            RDown,
            /// <summary>
            /// G按下
            /// </summary>
            GDown,
            /// <summary>
            /// B按下
            /// </summary>
            BDown,
            /// <summary>
            /// 自定义颜色按下
            /// </summary>
            CustomDown,
            /// <summary>
            /// 清除按下
            /// </summary>
            ClearDown,
            /// <summary>
            /// 确认按下
            /// </summary>
            ConfirmDown
        }

        /// <summary>
        /// 颜色面板选中类型
        /// </summary>
        [Description("颜色面板选中类型")]
        public enum colorTypes
        {
            /// <summary>
            /// 默认颜色
            /// </summary>
            Default,
            /// <summary>
            ///Html颜色
            /// </summary>
            Html
        }

        #endregion
    }

    /// <summary>
    /// 颜色文本输入框
    /// </summary>
    [ToolboxItem(false)]
    [Description("颜色文本输入框")]
    public class ColorPickerExtTextBox : TextBox
    {
        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        #endregion

        #region 字段

        private ColorPickerExt colorePickerExt = null;

        #endregion

        #region 扩展

        private const int WM_RBUTTONDOWN = 0x0204;

        #endregion

        public ColorPickerExtTextBox(ColorPickerExt colorePickerExt)
        {
            this.colorePickerExt = colorePickerExt;
        }

        #region 重写

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            switch (e.KeyCode)
            {
                #region Number
                case Keys.D0:
                case Keys.NumPad0:
                case Keys.D1:
                case Keys.NumPad1:
                case Keys.D2:
                case Keys.NumPad2:
                case Keys.D3:
                case Keys.NumPad3:
                case Keys.D4:
                case Keys.NumPad4:
                case Keys.D5:
                case Keys.NumPad5:
                case Keys.D6:
                case Keys.NumPad6:
                case Keys.D7:
                case Keys.NumPad7:
                case Keys.D8:
                case Keys.NumPad8:
                case Keys.D9:
                case Keys.NumPad9:
                case Keys.Oemcomma:
                case Keys.Left:
                case Keys.Right:
                case Keys.Back:
                case Keys.Control:
                case Keys.ControlKey:
                    {
                        e.SuppressKeyPress = false;
                        break;
                    }
                case Keys.A:
                case Keys.V:
                    {
                        if (e.Control)
                            e.SuppressKeyPress = false;
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.C:
                    {
                        if (e.Control)
                        {
                            this.SelectAll();
                            e.SuppressKeyPress = false;
                        }
                        else
                            e.SuppressKeyPress = true;
                        break;
                    }
                #endregion
                default:
                    {
                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_RBUTTONDOWN)//WM_RBUTTONDOWN是为了不让出现鼠标菜单
                return;
            base.WndProc(ref m);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            Rectangle rect = this.colorePickerExt.GetColorTextBoxRect();
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;

            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion
    }

}
