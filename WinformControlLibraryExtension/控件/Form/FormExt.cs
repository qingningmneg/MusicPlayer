

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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 扁平化窗体基类
    /// </summary>
    [Description("扁平化窗体基类")]
    public partial class FormExt : Form, IFormExt
    {
        #region 新增属性

        private bool screenMax = false;
        /// <summary>
        /// 最大化时是否覆盖任务栏
        /// </summary>
        [Description("最大化时是否覆盖任务栏")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ScreenMax
        {
            get
            {
                return this.screenMax;
            }
            set
            {
                if (this.screenMax == value)
                    return;

                this.screenMax = value;
            }
        }

        private ResizeTypes resizeType = ResizeTypes.CaptionDrag;
        /// <summary>
        /// 放大缩小模式
        /// </summary>
        [Description("放大缩小模式")]
        [DefaultValue(ResizeTypes.CaptionDrag)]
        [Browsable(true)]
        public ResizeTypes ResizeType
        {
            get
            {
                return this.resizeType;
            }
            set
            {
                if (this.resizeType == value)
                    return;

                this.resizeType = value;
            }
        }

        private bool moveEnabled = false;
        /// <summary>
        /// 是否启用界面移动功能
        /// </summary>
        [Description("是否启用界面移动功能")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool MoveEnabled
        {
            get
            {
                return this.moveEnabled;
            }
            set
            {
                if (this.moveEnabled == value)
                    return;

                this.moveEnabled = value;
            }
        }

        private bool captionEnabled = true;
        /// <summary>
        /// 是否启用标题栏和工具
        /// </summary>
        [Description("是否启用标题栏和工具")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool CaptionEnabled
        {
            get
            {
                return this.captionEnabled;
            }
            set
            {
                if (this.captionEnabled == value)
                    return;

                this.captionEnabled = value;
                this.CaptionBox.InitializeControlBox();
            }
        }

        private bool backgroundImageCaption = true;
        /// <summary>
        /// 标题栏是否包含背景图片
        /// </summary>
        [Description("标题栏是否包含背景图片")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool BackgroundImageCaption
        {
            get
            {
                return this.backgroundImageCaption;
            }
            set
            {
                if (this.backgroundImageCaption == value)
                    return;

                this.backgroundImageCaption = value;
                this.Invalidate();
            }
        }

        private bool borderEnabled = true;
        /// <summary>
        /// 是否启用边框宽度
        /// </summary>
        [Description("是否启用边框宽度")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool BorderEnabled
        {
            get
            {
                return this.borderEnabled;
            }
            set
            {
                if (this.borderEnabled == value)
                    return;

                this.borderEnabled = value;
                this.CaptionBox.InitializeControlBox();
            }
        }

        private Color borderColor = Color.FromArgb(137, 158, 136);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "137 ,158, 136")]
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

        private Color sizeGripColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 手柄颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("手柄颜色")]
        public Color SizeGripColor
        {
            get { return this.sizeGripColor; }
            set
            {
                if (this.sizeGripColor == value)
                    return;

                this.sizeGripColor = value;
                this.Invalidate();
            }
        }

        private TextOrientations textOrientation = TextOrientations.Center;
        /// <summary>
        /// 标题文本方位
        /// </summary>
        [Description("标题文本方位")]
        [DefaultValue(TextOrientations.Center)]
        [Browsable(true)]
        public TextOrientations TextOrientation
        {
            get
            {
                return this.textOrientation;
            }
            set
            {
                if (this.textOrientation == value)
                    return;

                this.textOrientation = value;
                this.Invalidate();
            }
        }

        public CaptionBoxClass captionBox;
        /// <summary>
        /// 标题栏
        /// </summary>
        [Description("标题栏")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CaptionBoxClass CaptionBox
        {
            get
            {
                if (this.captionBox == null)
                    this.captionBox = new CaptionBoxClass(this);
                return this.captionBox;
            }
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

        public new SizeGripStyle SizeGripStyle
        {
            get
            {
                return base.SizeGripStyle;
            }
            set
            {
                if (base.SizeGripStyle == value)
                    return;

                base.SizeGripStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = FormBorderStyle.None; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MaximizeBox
        {
            get
            {
                return base.MaximizeBox;
            }
            set
            {
                base.MaximizeBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MinimizeBox
        {
            get
            {
                return base.MinimizeBox;
            }
            set
            {
                base.MinimizeBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool HelpButton
        {
            get
            {
                return base.HelpButton;
            }
            set
            {
                base.HelpButton = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool ControlBox
        {
            get
            {
                return base.ControlBox;
            }
            set
            {
                base.ControlBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMargin
        {
            get
            {
                return base.AutoScrollMargin;
            }
            set
            {
                base.AutoScrollMargin = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMinSize
        {
            get
            {
                return base.AutoScrollMinSize;
            }
            set
            {
                base.AutoScrollMinSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 窗体是否激活
        /// </summary>
        private bool _active;

        /// <summary>
        /// 客户区是否按下
        /// </summary>
        private bool isdown = false;

        /// <summary>
        /// 客户区按下坐标
        /// </summary>
        private Point downpoint = Point.Empty;

        /// <summary>
        /// 提示信息
        /// </summary>
        protected static ToolTipExt tte;

        /// <summary>
        /// 透明边框分层窗体
        /// </summary>
        private LayerBoederForm lbForm = null;

        #endregion

        #region 扩展

        /// <summary>
        /// 允许最小化操作
        /// </summary>
        private const int WS_MINIMIZEBOX = 0x00020000;

        /// <summary>
        /// 此消息发送给窗口当它将要改变大小或位置
        /// </summary>
        private const int WM_GETMINMAXINFO = 0x24;

        /// <summary>
        /// 窗口状态
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            /// <summary>
            /// 窗口正常状态的坐标
            /// </summary>
            public Point reserved;
            /// <summary>
            /// 设置窗口最大化时的宽度、高度
            /// </summary>
            public Size maxSize;
            /// <summary>
            /// 设置窗口最大化时x坐标、y坐标
            /// </summary>
            public Point maxPosition;
            /// <summary>
            /// 设置窗口最小宽度、高度
            /// </summary>
            public Size minTrackSize;
            /// <summary>
            /// 设置窗口最大宽度、高度
            /// </summary>
            public Size maxTrackSize;
        }

        #endregion

        static FormExt()
        {
            tte = new ToolTipExt();
            tte.BackColor = Color.FromArgb(240, 240, 240);
            tte.ForeColor = Color.FromArgb(109, 109, 109);
        }

        public FormExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.VisibleChanged += this.fe_VisibleChanged;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(176, 197, 175);
            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.CaptionBox.InitializeControlBox();

            this.lbForm = new LayerBoederForm(this);
            this.lbForm.InvalidateLayer();
        }

        #region 重写

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.Style = cParms.Style | WS_MINIMIZEBOX;
                return cParms;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            this.DrawBackground(e.Graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            this.DrawCaption(g);
            this.DrawSizeGrip(g);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this._active = true;
            this.Invalidate();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            this._active = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int scale_captionBoxHeight = (int)(this.CaptionBox.Height * DotsPerInchHelper.DPIScale.YScale);

                if (this.CaptionEnabled && this.CaptionBox.Rect.Contains(e.Location))
                {
                    if (this.CaptionBox.ControlBoxRect.Contains(e.Location))
                    {
                        if (this.CaptionBox.CloseBtn.Enabled)
                        {
                            if (this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        if (this.CaptionBox.MaxBtn.Enabled)
                        {
                            if (this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        if (this.CaptionBox.MinBtn.Enabled)
                        {
                            if (this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                    }
                    else
                    {
                        this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Down;
                        this.isdown = true;
                        this.downpoint = Control.MousePosition;
                    }
                }
                else
                {
                    this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                }

                if (this.MoveEnabled)
                {
                    if (new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + scale_captionBoxHeight, this.ClientRectangle.Width, this.ClientRectangle.Height - scale_captionBoxHeight).Contains(e.Location))
                    {
                        this.isdown = true;
                        this.downpoint = Control.MousePosition;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.CaptionEnabled)
                {
                    if (this.CaptionBox.CloseBtn.Enabled && this.CaptionBox.CloseBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                    {
                        this.HideTip();
                        this.Close();
                        this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                        return;
                    }

                    if (this.CaptionBox.MaxBtn.Enabled && this.CaptionBox.MaxBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                    {
                        if (this.WindowState != FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                        this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                    }

                    if (this.CaptionBox.MinBtn.Enabled && this.CaptionBox.MinBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                    {
                        if (this.WindowState != FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                        this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                    }
                }

                this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                if (this.MoveEnabled)
                {
                    this.isdown = false;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            bool reset = false;
            string text = "";
            Point tip_point = Point.Empty;

            if (this.CaptionEnabled)
            {
                if (this.CaptionBox.CloseBtn.Enabled)
                {
                    if (this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.CloseBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            text = this.CaptionBox.CloseBtn.TipText1;
                            tip_point = new Point(this.CaptionBox.CloseBtn.Rect.X, this.CaptionBox.CloseBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.CloseBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (this.CaptionBox.MaxBtn.Enabled)
                {
                    if (this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.MaxBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            if (this.WindowState != FormWindowState.Maximized)
                            {
                                text = this.CaptionBox.MaxBtn.TipText1;
                            }
                            else
                            {
                                text = this.CaptionBox.MaxBtn.TipText2;
                            }
                            tip_point = new Point(this.CaptionBox.MaxBtn.Rect.X, this.CaptionBox.MaxBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.MaxBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (this.CaptionBox.MinBtn.Enabled)
                {
                    if (this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.MinBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            text = this.CaptionBox.MinBtn.TipText1;
                            tip_point = new Point(this.CaptionBox.MinBtn.Rect.X, this.CaptionBox.MinBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.MinBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (reset)
                {
                    this.ShowTip(text, tip_point);
                    this.Invalidate();
                }
            }

            if (this.WindowState != FormWindowState.Maximized && (this.MoveEnabled || this.CaptionBox.OperateStatus == ControlBoxOperateStatus.Down) && this.isdown)
            {
                Point point = new Point(Control.MousePosition.X - this.downpoint.X, Control.MousePosition.Y - this.downpoint.Y);
                this.downpoint = Control.MousePosition;
                this.Location = this.PointToScreen(point);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.CaptionBox.RecoverControlBoxStatus();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left && (this.ResizeType == ResizeTypes.Caption || this.ResizeType == ResizeTypes.CaptionDrag) && this.CaptionBox.Rect.Contains(e.Location) && !this.CaptionBox.ControlBoxRect.Contains(e.Location))
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.CaptionBox.InitializeControlBox();

            if (this.DesignMode)
                return;

            this.lbForm.Size = new Size(this.Size.Width + this.lbForm.borderThickness * 2, this.Size.Height + this.lbForm.borderThickness * 2);
            this.lbForm.InvalidateLayer();

        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            if (this.DesignMode)
                return;

            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                if (this.lbForm != null && this.lbForm.Visible)
                {
                    this.lbForm.Hide();
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                if (this.lbForm != null && this.lbForm.Visible == false)
                {
                    this.lbForm.Show(this);
                    this.lbForm.SetBounds(this.Location.X - this.lbForm.borderThickness, this.Location.Y - this.lbForm.borderThickness, this.Size.Width + this.lbForm.borderThickness * 2, this.Size.Height + this.lbForm.borderThickness * 2);
                    this.lbForm.InvalidateLayer();
                }
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            if (this.DesignMode)
                return;

            this.lbForm.Location = new Point(this.Location.X - this.lbForm.borderThickness, this.Location.Y - this.lbForm.borderThickness);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_GETMINMAXINFO:
                    {
                        if (!this.ScreenMax)
                        {
                            base.WndProc(ref m);
                            this.SetMinMaxInfo(ref m);
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        break;
                    }
                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 隐藏提示信息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HideTip()
        {
            if (tte.Active)
            {
                tte.Hide(this);
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ShowTip(string text, Point point)
        {
            if (!String.IsNullOrEmpty(text))
            {
                tte.Show(text, this, point);
            }
        }

        #endregion

        #region 私有方法

        private void fe_VisibleChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            FormExt f = (FormExt)sender;
            if (f.Visible)
            {
                if (this.lbForm.Visible == false)
                {
                    lbForm.Show(this);
                }
                this.lbForm.SetBounds(this.Location.X - this.lbForm.borderThickness, this.Location.Y - this.lbForm.borderThickness, this.Size.Width + this.lbForm.borderThickness * 2, this.Size.Height + this.lbForm.borderThickness * 2);
                this.lbForm.InvalidateLayer();
            }
            else
            {
                lbForm.Hide();
            }

        }

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBackground(Graphics g)
        {
            int scale_captionBoxHeight = (int)(this.CaptionBox.Height * DotsPerInchHelper.DPIScale.YScale);

            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.ClientRectangle);
            back_sb.Dispose();

            if (this.BackgroundImage != null)
            {
                int caption = this.CaptionEnabled ? scale_captionBoxHeight : 0;
                Rectangle rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
                if (this.BackgroundImageCaption == false)
                {
                    rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + caption, this.ClientRectangle.Width, this.ClientRectangle.Height - caption);
                }

                if (this.BackgroundImageLayout == ImageLayout.Zoom)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    int new_width = image_rect.Width;
                    int new_height = image_rect.Height;

                    if (image_rect.Width < rect.Width && image_rect.Height < rect.Height)
                    {
                        new_width = rect.Width;
                        new_height = (int)(new_width * ((float)image_rect.Height) / (float)image_rect.Width);
                    }
                    if (new_height > rect.Height)
                    {
                        new_height = rect.Height;
                        new_width = (int)(new_height * ((float)image_rect.Width) / (float)image_rect.Height);
                    }
                    if (new_width > rect.Width)
                    {
                        new_width = rect.Width;
                        new_height = (int)(new_width * ((float)image_rect.Height) / (float)image_rect.Width);
                    }
                    if (new_height > rect.Height)
                    {
                        new_height = rect.Height;
                        new_width = (int)(new_height * ((float)image_rect.Width) / (float)image_rect.Height);
                    }
                    image_rect = new Rectangle(0, 0, new_width, new_height);
                    Rectangle rect_tmp = new Rectangle(rect.X + (rect.Width - image_rect.Width) / 2, rect.Y + (rect.Height - image_rect.Height) / 2, image_rect.Width, image_rect.Height);
                    g.DrawImage(this.BackgroundImage, rect_tmp);
                }
                else if (this.BackgroundImageLayout == ImageLayout.Center)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    Rectangle rect_tmp = new Rectangle(rect.X + (rect.Width - image_rect.Width) / 2, rect.Y + (rect.Height - image_rect.Height) / 2, image_rect.Width, image_rect.Height);
                    g.DrawImage(this.BackgroundImage, rect_tmp);
                }
                else if (this.BackgroundImageLayout == ImageLayout.Tile)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    TextureBrush back_tb = new TextureBrush(this.BackgroundImage, image_rect);
                    g.FillRectangle(back_tb, rect);
                    back_tb.Dispose();
                }
                else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    g.DrawImage(this.BackgroundImage, rect, image_rect, GraphicsUnit.Pixel);
                }
                else if (this.BackgroundImageLayout == ImageLayout.None)
                {
                    g.DrawImage(this.BackgroundImage, rect.Location);
                }

            }

        }

        /// <summary>
        /// 绘制标题栏
        /// </summary>
        /// <param name="g"></param>
        private void DrawCaption(Graphics g)
        {
            if (this.CaptionEnabled)
            {
                int scale_captionBoxHeight = (int)(this.CaptionBox.Height * DotsPerInchHelper.DPIScale.YScale);

                if (this.CaptionBox.BackColor != Color.Empty)
                {
                    SolidBrush border_sb = new SolidBrush(this._active || this.DesignMode ? this.CaptionBox.BackColor : Color.FromArgb(100, this.CaptionBox.BackColor));
                    Rectangle rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, scale_captionBoxHeight);
                    g.FillRectangle(border_sb, rect);
                    border_sb.Dispose();
                }

                DrawControlBox(g);

                if (this.ShowIcon && this.Icon != null)
                {
                    InterpolationMode interpolationMode = g.InterpolationMode;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawIcon(this.Icon, this.CaptionBox.IconRect);
                    g.InterpolationMode = interpolationMode;
                }

                if (!String.IsNullOrEmpty(this.Text))
                {
                    StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
                    SolidBrush text_sb = new SolidBrush(this.ForeColor);
                    SizeF text_size = g.MeasureString(this.Text, this.Font, 1000, text_sf);

                    int w = (int)text_size.Width + 2;
                    if (w > (int)(this.ClientRectangle.Width - (this.ShowIcon ? this.CaptionBox.IconRect.Right : 2) - this.CaptionBox.ControlBoxRect.Width - 2))
                    {
                        w = (int)(this.ClientRectangle.Width - (this.ShowIcon ? this.CaptionBox.IconRect.Right : 2) - this.CaptionBox.ControlBoxRect.Width - 2);
                    }

                    int x = 0;
                    int y = (int)(this.ClientRectangle.Y + (scale_captionBoxHeight - text_size.Height) / 2);
                    Rectangle text_rect = Rectangle.Empty;
                    if (this.TextOrientation == TextOrientations.Left)
                    {
                        x = (int)(this.ShowIcon ? this.CaptionBox.IconRect.Right : this.ClientRectangle.X + 2);
                    }
                    else if (this.TextOrientation == TextOrientations.Center)
                    {
                        x = (int)(this.ClientRectangle.Width - text_size.Width) / 2;
                        if (x + text_size.Width > this.CaptionBox.ControlBoxRect.Left)
                        {
                            x = (int)(this.CaptionBox.ControlBoxRect.Left - text_size.Width);
                        }
                    }
                    else if (this.TextOrientation == TextOrientations.Right)
                    {
                        x = (int)(this.CaptionBox.ControlBoxRect.Left - text_size.Width);
                    }
                    text_rect = new Rectangle(x, y, w, (int)text_size.Width);

                    g.DrawString(this.Text, this.Font, text_sb, text_rect, text_sf);

                    text_sb.Dispose();
                    text_sf.Dispose();
                }
            }
        }

        /// <summary>
        /// 绘制标题栏按钮
        /// </summary>
        /// <param name="g"></param>
        private void DrawControlBox(Graphics g)
        {

            if (this.CaptionBox.CloseBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.CloseBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.CloseBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.CloseBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.CloseBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.CloseBtn.NormalForeColor);
                }
                else if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.CloseBtn.EnterBackColor;
                    textcolor = this.CaptionBox.CloseBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, DotsPerInchHelper.DPIScale.XScale >= 1.5f ? 2 : 1);
                g.FillRectangle(back_sb, this.CaptionBox.CloseBtn.Rect);

                int width = this.CaptionBox.CloseBtn.Rect.Width / 10 * 6;
                int x1 = this.CaptionBox.CloseBtn.Rect.X + (this.CaptionBox.CloseBtn.Rect.Width - width) / 2;
                int y1 = this.CaptionBox.CloseBtn.Rect.Y + (this.CaptionBox.CloseBtn.Rect.Height - width) / 2;
                int x2 = this.CaptionBox.CloseBtn.Rect.X + width + (this.CaptionBox.CloseBtn.Rect.Width - width) / 2;
                int y2 = this.CaptionBox.CloseBtn.Rect.Y + width + (this.CaptionBox.CloseBtn.Rect.Height - width) / 2;

                g.DrawLine(text_pen, new Point(x1, y1), new Point(x2, y2));
                g.DrawLine(text_pen, new Point(x1 + width, y1), new Point(x2 - width, y2));

                back_sb.Dispose();
                text_pen.Dispose();
            }

            if (this.CaptionBox.MaxBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.MaxBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.MaxBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.MaxBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.MaxBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.MaxBtn.NormalForeColor);
                }
                else if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.MaxBtn.EnterBackColor;
                    textcolor = this.CaptionBox.MaxBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, DotsPerInchHelper.DPIScale.XScale >= 1.5f ? 2 : 1);
                g.FillRectangle(back_sb, this.CaptionBox.MaxBtn.Rect);

                int width = this.CaptionBox.MaxBtn.Rect.Width / 10 * 6;
                int height = this.CaptionBox.MaxBtn.Rect.Width / 10 * 6;

                if (this.WindowState != FormWindowState.Maximized)
                {
                    int x1 = this.CaptionBox.MaxBtn.Rect.X + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;
                    int y1 = this.CaptionBox.MaxBtn.Rect.Y + (this.CaptionBox.MaxBtn.Rect.Height - height) / 2;
                    int x2 = this.CaptionBox.MaxBtn.Rect.X + width + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;

                    g.DrawRectangle(text_pen, new Rectangle(x1, y1, width, height));
                    g.DrawLine(text_pen, new Point(x1 + 1, y1 + 1), new Point(x2 - 1, y1 + 1));
                    g.DrawLine(text_pen, new Point(x1 + 1, y1 + 2), new Point(x2 - 1, y1 + 2));
                }
                else
                {
                    int len = 2;
                    width -= len;
                    height -= len;
                    int x1 = this.CaptionBox.MaxBtn.Rect.X + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;
                    int y1 = this.CaptionBox.MaxBtn.Rect.Y + (this.CaptionBox.MaxBtn.Rect.Height - height) / 2;
                    g.DrawRectangle(text_pen, new Rectangle(x1, y1, width, height));
                    g.DrawLine(text_pen, new Point(x1 + len, y1 - 1), new Point(x1 + len, y1 - len));
                    g.DrawLine(text_pen, new Point(x1 + len + 1, y1 - len), new Point(x1 + len + width, y1 - len));
                    g.DrawLine(text_pen, new Point(x1 + len + width, y1 - len + 1), new Point(x1 + len + width, y1 - len + height - 1));
                    g.DrawLine(text_pen, new Point(x1 + len + width, y1 - len + height), new Point(x1 + width + 1, y1 - len + height));
                }

                back_sb.Dispose();
                text_pen.Dispose();
            }

            if (this.CaptionBox.MinBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.MinBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.MinBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.MinBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.MinBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.MinBtn.NormalForeColor);
                }
                else if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.MinBtn.EnterBackColor;
                    textcolor = this.CaptionBox.MinBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, DotsPerInchHelper.DPIScale.XScale >= 1.5f ? 2 : 1);
                g.FillRectangle(back_sb, this.CaptionBox.MinBtn.Rect);

                int width = this.CaptionBox.MaxBtn.Rect.Width / 10 * 6;
                int x1 = this.CaptionBox.MinBtn.Rect.X + (this.CaptionBox.MinBtn.Rect.Width - width) / 2;
                int x2 = this.CaptionBox.MinBtn.Rect.X + width + (this.CaptionBox.MinBtn.Rect.Width - width) / 2;

                g.DrawLine(text_pen, new Point(x1, this.CaptionBox.MinBtn.Rect.Height / 5 * 3), new Point(x2, this.CaptionBox.MinBtn.Rect.Height / 5 * 3));

                back_sb.Dispose();
                text_pen.Dispose();
            }

        }

        /// <summary>
        /// 绘制标手柄
        /// </summary>
        /// <param name="g"></param>
        private void DrawSizeGrip(Graphics g)
        {
            if (this.SizeGripStyle == SizeGripStyle.Show && this.WindowState != FormWindowState.Maximized)
            {
                int rect_size = 12;
                int size = 2;
                int pd = 2;
                Rectangle rect = new Rectangle(this.ClientRectangle.Right - rect_size, this.ClientRectangle.Bottom - rect_size, rect_size, rect_size);
                Pen grip_pen = new Pen(this.SizeGripColor, 2);

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size), new Point(rect.Right - pd, rect.Bottom - pd - size));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 3, rect.Bottom - pd - size), new Point(rect.Right - pd - size * 2, rect.Bottom - pd - size));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 5, rect.Bottom - pd - size), new Point(rect.Right - pd - size * 4, rect.Bottom - pd - size));

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size * 3), new Point(rect.Right - pd, rect.Bottom - pd - size * 3));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 3, rect.Bottom - pd - size * 3), new Point(rect.Right - pd - size * 2, rect.Bottom - pd - size * 3));

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size * 5), new Point(rect.Right - pd, rect.Bottom - pd - size * 5));
            }
        }

        /// <summary>
        /// 设置窗体MINMAXINFO(最大化时是否覆盖任务栏)
        /// </summary>
        /// <param name="m"></param>
        private void SetMinMaxInfo(ref Message m)
        {
            MINMAXINFO minmax = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));

            if (MaximumSize != Size.Empty)
            {
                minmax.maxTrackSize = MaximumSize;
            }
            else
            {
                if (this.Parent == null)
                {
                    Rectangle rect = Screen.GetWorkingArea(this);
                    minmax.maxTrackSize = new Size(rect.Width, rect.Height);
                    minmax.maxPosition = new Point(rect.X, rect.Y);
                    minmax.maxSize = new Size(rect.Width, rect.Height);
                }
                else if (this.Parent != null)
                {
                    Rectangle rect = this.Parent.ClientRectangle;
                    minmax.maxTrackSize = new Size(rect.Width, rect.Height);
                    minmax.maxPosition = new Point(rect.X, rect.Y);
                    minmax.maxSize = new Size(rect.Width, rect.Height);
                }
            }

            if (MinimumSize != Size.Empty)
            {
                minmax.minTrackSize = MinimumSize;
            }
            else
            {
                int x = this.ClientRectangle.Right - 2 - this.CaptionBox.CloseBtn.Rect.Width;
                if (this.CaptionBox.CloseBtn.Enabled)
                {
                    x -= this.CaptionBox.CloseBtn.Rect.Width;
                }
                if (this.CaptionBox.MaxBtn.Enabled)
                {
                    x -= this.CaptionBox.MaxBtn.Rect.Width;
                }
                if (this.CaptionBox.MinBtn.Enabled)
                {
                    x -= this.CaptionBox.MinBtn.Rect.Width;
                }
                minmax.minTrackSize = new Size((this.ClientRectangle.Right - 2) - x, this.CaptionBox.Height);
            }

            Marshal.StructureToPtr(minmax, m.LParam, false);
        }

        #endregion

        #region 类

        /// <summary>
        /// 标题栏
        /// </summary>
        [Description("标题栏")]
        [TypeConverter(typeof(EmptyConverter))]
        public class CaptionBoxClass
        {
            #region 字段
            private FormExt owner = null;
            #endregion

            #region 属性

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// Rect
            /// </summary>
            [Description("Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle Rect
            {
                get
                {
                    return this.rect;
                }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private ControlBoxOperateStatus operateStatus = ControlBoxOperateStatus.Normal;
            /// <summary>
            /// 操作状态
            /// </summary>
            [Description("操作状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxOperateStatus OperateStatus
            {
                get { return this.operateStatus; }
                set
                {
                    if (this.operateStatus == value)
                        return;

                    this.operateStatus = value;
                }
            }

            private ControlBoxButton closeBtn = null;
            /// <summary>
            /// 关闭按钮
            /// </summary>
            [Description("关闭按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton CloseBtn
            {
                get { return this.closeBtn; }
            }

            private ControlBoxButton maxBtn = null;
            /// <summary>
            /// 最大化按钮
            /// </summary>
            [Description("最大化按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton MaxBtn
            {
                get { return this.maxBtn; }
            }

            private ControlBoxButton minBtn = null;
            /// <summary>
            /// 最小化按钮
            /// </summary>
            [Description("最小化按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton MinBtn
            {
                get { return this.minBtn; }
            }

            private int height = 24;
            /// <summary>
            /// 标题栏高度
            /// </summary>
            [Description("标题栏高度")]
            [DefaultValue(24)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public int Height
            {
                get
                {
                    return this.height;
                }
                set
                {
                    if (this.height == value)
                        return;

                    this.height = value;
                    this.InitializeControlBox();
                }
            }

            private Color backColor = Color.Empty;
            /// <summary>
            /// 标题栏颜色
            /// </summary>
            [Description("标题栏颜色")]
            [DefaultValue(typeof(Color), "Empty")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
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
                    this.owner.Invalidate();
                }
            }

            private int buttonSize = 18;
            /// <summary>
            /// 按钮Size
            /// </summary>
            [Description("按钮Size")]
            [DefaultValue(18)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public int ButtonSize
            {
                get { return this.buttonSize; }
                set
                {
                    if (this.buttonSize == value)
                        return;

                    this.buttonSize = value;
                    this.InitializeControlBox();
                }
            }

            private Rectangle iconRect = Rectangle.Empty;
            /// <summary>
            /// 图标Rect
            /// </summary>
            [Description("图标Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle IconRect
            {
                get { return this.iconRect; }
                set
                {
                    if (this.iconRect == value)
                        return;

                    this.iconRect = value;
                }
            }

            private Rectangle controlBoxRect = Rectangle.Empty;
            /// <summary>
            /// 按钮组Rect
            /// </summary>
            [Description("按钮组Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle ControlBoxRect
            {
                get { return this.controlBoxRect; }
                set
                {
                    if (this.controlBoxRect == value)
                        return;

                    this.controlBoxRect = value;
                }
            }

            #endregion

            public CaptionBoxClass(FormExt owner)
            {
                this.owner = owner;
                this.closeBtn = new ControlBoxButton(this) { TipText1 = "关闭", TipText2 = "关闭" };
                this.maxBtn = new ControlBoxButton(this) { TipText1 = "最大化", TipText2 = "向下还原" };
                this.minBtn = new ControlBoxButton(this) { TipText1 = "最小化", TipText2 = "最小化" };
            }

            #region 公开方法

            /// <summary>
            /// 初始化按钮信息
            /// </summary>
            public void InitializeControlBox()
            {
                if (this.owner.CaptionEnabled == false)
                    return;

                int scale_captionBoxHeight = (int)(this.Height * DotsPerInchHelper.DPIScale.YScale);
                int scale_buttonSize = (int)(this.ButtonSize * DotsPerInchHelper.DPIScale.YScale);
                int scale_right = (int)(2 * DotsPerInchHelper.DPIScale.XScale);
                Rectangle rect = this.owner.ClientRectangle;
                this.Rect = new Rectangle(rect.X, rect.Y, rect.Width, scale_captionBoxHeight);
                Rectangle controlBox_rect = new Rectangle(rect.X, rect.Y, rect.Width, scale_captionBoxHeight);
                int t = controlBox_rect.Y;
                int r = controlBox_rect.Right - scale_right;

                int size = scale_buttonSize;
                int with_sum = 0;
                if (size > scale_captionBoxHeight)
                {
                    size = scale_captionBoxHeight;
                }

                if (this.CloseBtn.Enabled)
                {
                    this.CloseBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.CloseBtn.Rect.Left;
                    with_sum += size;
                }
                if (this.MaxBtn.Enabled)
                {
                    this.MaxBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.MaxBtn.Rect.Left;
                    with_sum += size;
                }
                if (this.MinBtn.Enabled)
                {
                    this.MinBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.MinBtn.Rect.Left;
                    with_sum += size;
                }
                this.ControlBoxRect = new Rectangle(r, t, with_sum, size);

                if (this.owner.ShowIcon)
                {
                    this.IconRect = new Rectangle(2, rect.Y + (scale_captionBoxHeight - size) / 2, size, size);
                }

                this.owner.Invalidate();
            }

            /// <summary>
            /// 还原按钮默认鼠标状态
            /// </summary>
            public void RecoverControlBoxStatus()
            {
                bool reset = false;
                if (this.CloseBtn.Enabled && this.CloseBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.CloseBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                if (this.MaxBtn.Enabled && this.MaxBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.MaxBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                if (this.MinBtn.Enabled && this.MinBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.MinBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                this.OperateStatus = ControlBoxOperateStatus.Normal;
                if (reset)
                {
                    this.owner.Invalidate();
                    this.owner.HideTip();
                }
            }

            #endregion

        }

        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ControlBoxButton
        {
            #region 字段

            private CaptionBoxClass owner = null;

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用按钮
            /// </summary>
            [Description("是否启用按钮")]
            [DefaultValue(true)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.owner.InitializeControlBox();
                }
            }

            private string tipText1 = "";
            /// <summary>
            /// 按钮提示文本1
            /// </summary>
            [Description("按钮提示文本1")]
            [DefaultValue("")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public string TipText1
            {
                get { return this.tipText1; }
                set
                {
                    if (this.tipText1 == value)
                        return;

                    this.tipText1 = value;
                }
            }

            private string tipText2 = "";
            /// <summary>
            /// 按钮提示文本2
            /// </summary>
            [Description("按钮提示文本2")]
            [DefaultValue("")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public string TipText2
            {
                get { return this.tipText2; }
                set
                {
                    if (this.tipText2 == value)
                        return;

                    this.tipText2 = value;
                }
            }

            private ControlBoxMouseStatus mouseStatus = ControlBoxMouseStatus.Normal;
            /// <summary>
            /// 按钮鼠标状态
            /// </summary>
            [Description("按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxMouseStatus MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            private ControlBoxOperateStatus operateStatus = ControlBoxOperateStatus.Normal;
            /// <summary>
            /// 按钮操作状态
            /// </summary>
            [Description("按钮操作状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxOperateStatus OperateStatus
            {
                get { return this.operateStatus; }
                set
                {
                    if (this.operateStatus == value)
                        return;

                    this.operateStatus = value;
                }
            }

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// 按钮Rect
            /// </summary>
            [Description("按钮Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle Rect
            {
                get
                {
                    return this.rect;
                }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private Color normalBackColor = Color.Empty;
            /// <summary>
            /// 按钮背景颜色（默认）
            /// </summary>
            [Description("按钮背景颜色（默认）")]
            [DefaultValue(typeof(Color), "Empty")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalBackColor
            {
                get
                {
                    return this.normalBackColor;
                }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                }
            }

            private Color normalForeColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 按钮前景颜色（默认）
            /// </summary>
            [Description("按钮前景颜色（默认）")]
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalForeColor
            {
                get
                {
                    return this.normalForeColor;
                }
                set
                {
                    if (this.normalForeColor == value)
                        return;

                    this.normalForeColor = value;
                }
            }

            private Color enterBackColor = Color.FromArgb(100, 255, 255, 255);
            /// <summary>
            /// 按钮背景颜色（鼠标进入）
            /// </summary>
            [Description("按钮背景颜色（鼠标进入）")]
            [DefaultValue(typeof(Color), "100, 255,255,255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterBackColor
            {
                get
                {
                    return this.enterBackColor;
                }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                }
            }

            private Color enterForeColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 按钮前景颜色（鼠标进入）
            /// </summary>
            [Description("按钮前景颜色（鼠标进入）")]
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterForeColor
            {
                get
                {
                    return this.enterForeColor;
                }
                set
                {
                    if (this.enterForeColor == value)
                        return;

                    this.enterForeColor = value;
                }
            }

            #endregion

            public ControlBoxButton(CaptionBoxClass owner)
            {
                this.owner = owner;
            }

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 标题栏按钮鼠标状态
        /// </summary>
        [Description("标题栏按钮鼠标状态")]
        public enum ControlBoxMouseStatus
        {
            /// <summary>
            /// 默认
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter
        }

        /// <summary>
        /// 标题栏按钮操作状态
        /// </summary>
        [Description("标题栏按钮操作状态")]
        public enum ControlBoxOperateStatus
        {
            /// <summary>
            /// 默认
            /// </summary>
            Normal,
            /// <summary>
            /// 按下
            /// </summary>
            Down
        }

        /// <summary>
        /// 标题文本方位
        /// </summary>
        [Description("标题文本方位")]
        public enum TextOrientations
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 居中
            /// </summary>
            Center,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 放大缩小模式
        /// </summary>
        [Description("放大缩小模式")]
        public enum ResizeTypes
        {
            /// <summary>
            /// 无缩放
            /// </summary>
            NoResize,
            /// <summary>
            /// 鼠标拖动
            /// </summary>
            Drag,
            /// <summary>
            /// 标题栏双击
            /// </summary>
            Caption,
            /// <summary>
            /// 鼠标拖动、标题栏双击
            /// </summary>
            CaptionDrag
        }

        #endregion
    }

    /// <summary>
    /// 扁平化窗体边框分层窗体
    /// </summary>
    [Description("扁平化窗体边框分层窗体")]
    public class LayerBoederForm : Form
    {
        #region 字段

        /// <summary>
        /// 窗体句柄创建完成
        /// </summary>
        private bool isHandleCreate = false;

        /// <summary>
        /// 所属扁平化窗体
        /// </summary>
        private FormExt feForm = null;

        /// <summary>
        /// 边框阴影厚度
        /// </summary> 
        public int borderThickness = 10;

        /// <summary>
        /// 鼠标当前拉伸状态
        /// </summary>
        private StretchTypes stretchType = StretchTypes.None;

        /// <summary>
        /// 鼠标是否已按下
        /// </summary>
        bool mouseIsDown = false;

        /// <summary>
        /// 鼠标按下时的屏幕坐标
        /// </summary>
        Point startMouseDown = Point.Empty;

        /// <summary>
        /// 鼠标按下时宿主窗体的rect
        /// </summary>
        Rectangle feFormRect = Rectangle.Empty;

        #endregion

        #region 扩展

        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;


        /// <summary>
        /// 窗户是分层的窗户。如果窗口中有一个不能用这种风格类样式之一CS_OWNDC或CS_CLASSDC。Windows 8的：该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。
        /// </summary>
        private const int WS_EX_LAYERED = 0x80000;

        private const int WS_POPUP = unchecked((int)0x80000000);
        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CLIPSIBLINGS = 0x04000000;


        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATE = 0x0003;

        private const byte AC_SRC_OVER = 0;
        private const byte AC_SRC_ALPHA = 1;
        /// <summary>
        /// 使用pblend作为混合功能。如果显示模式为256色或更小，则此值的效果与ULW_OPAQUE的效果相同。
        /// </summary>
        private const Int32 ULW_ALPHA = 0x00000002;

        /// <summary>
        /// 该BLENDFUNCTION结构控制通过指定源和目的地的位图的混合函数共混。
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            /// <summary>
            /// 源混合操作。当前，唯一已定义的源和目标混合操作是AC_SRC_OVER。有关详细信息，请参见以下“备注”部分。
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// 必须为零。
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// 指定要在整个源位图上使用的Alpha透明度值。所述SourceConstantAlpha值与源位图任何每像素的alpha值组合。如果将SourceConstantAlpha设置为0，则假定图像是透明的。当您只想使用每像素Alpha值时，请将SourceConstantAlpha值设置为255（不透明）。
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// 该成员控制解释源位图和目标位图的方式。AlphaFormat具有以下值。
            /// AC_SRC_ALPHA	
            /// 当位图具有Alpha通道（即每像素alpha）时，将设置此标志。请注意，API使用预乘Alpha，这意味着位图中的红色，绿色和蓝色通道值必须预乘Alpha通道值。例如，如果Alpha通道值为x，则在调用之前，红色，绿色和蓝色通道必须乘以x并除以0xff。
            /// </summary>
            public byte AlphaFormat;
        }

        /// <summary>
        /// 检索句柄用于指定窗口的客户区或整个屏幕的设备上下文（DC）。您可以在后续的GDI函数中使用返回的句柄来绘制DC。设备上下文是一个不透明的数据结构，其值由GDI内部使用。
        /// </summary>
        /// <param name="hWnd">要获取其DC的窗口的句柄。如果此值为NULL，则GetDC检索整个屏幕的DC。</param>
        /// <returns>如果函数成功，则返回值是指定窗口的客户区DC的句柄。如果函数失败，则返回值为NULL。</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// 创建具有指定设备兼容的存储器设备上下文（DC）。
        /// </summary>
        /// <param name="hdc">现有DC的句柄。如果此句柄为NULL，则该函数将创建一个与应用程序当前屏幕兼容的内存DC。</param>
        /// <returns>如果函数成功，则返回值是内存DC的句柄。如果函数失败，则返回值为NULL。</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// 释放设备上下文（DC），释放它，以供其他应用程序使用。ReleaseDC功能的效果取决于DC的类型。它仅释放公共DC和窗口DC。它对班级或专用DC无效。
        /// </summary>
        /// <param name="hWnd">要释放其DC的窗口的句柄。</param>
        /// <param name="hDC">要释放的DC的句柄。</param>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// 删除指定的设备上下文（DC）。。
        /// </summary>
        /// <param name="hdc">设备上下文的句柄。</param>
        /// <returns></returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteDC(IntPtr hdc);

        /// <summary>
        /// 选择一个对象到指定的设备上下文（DC）。新对象将替换相同类型的先前对象。
        /// </summary>
        /// <param name="hdc">DC的句柄。</param>
        /// <param name="h">要选择的对象的句柄。必须使用以下功能之一创建指定的对象。
        /// CreateBitmap，CreateBitmapIndirect，CreateCompatibleBitmap，CreateDIBitmap，CreateDIBSection
        /// 位图只能选择到存储器DC中。单个位图不能同时选择到多个DC中。
        /// CreateBrushIndirect，CreateDIBPatternBrush，CreateDIBPatternBrushPt，CreateHatchBrush，CreatePatternBrush，CreateSolidBrush
        /// CreateFont，CreateFontIndirect
        /// 创建笔，创建笔间接
        /// CombineRgn，CreateEllipticRgn，CreateEllipticRgnIndirect，CreatePolygonRgn，CreateRectRgn，CreateRectRgnIndirect</param>
        /// <returns></returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

        /// <summary>
        /// 删除逻辑笔，刷子，字体，位图，区域或调色板，释放与该对象相关联的所有系统资源。删除对象后，指定的句柄不再有效。
        /// </summary>
        /// <param name="ho">逻辑笔，画笔，字体，位图，区域或调色板的句柄。</param>
        /// <returns></returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteObject(IntPtr ho);

        /// <summary>
        /// 更新分层窗口的位置，大小，形状，内容和半透明。
        /// </summary>
        /// <param name="hWnd">分层窗口的句柄。使用CreateWindowEx函数创建窗口时，可以通过指定WS_EX_LAYERED来创建分层窗口。Windows 8的：  该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。</param>
        /// <param name="hdcDst">屏幕DC的句柄。通过在调用函数时指定NULL可获得此句柄。当窗口内容更新时，它用于调色板颜色匹配。如果hdcDst为NULL，则将使用默认调色板。如果hdcSrc为NULL，则hdcDst必须为NULL。</param>
        /// <param name="pptDst">指向指定分层窗口的新屏幕位置的结构的指针。如果当前位置未更改，则pptDst可以为NULL。</param>
        /// <param name="psize">指向指定分层窗口新大小的结构的指针。如果窗口的大小未更改，则psize可以为NULL。如果hdcSrc为NULL，则psize必须为NULL。</param>
        /// <param name="hdcSrc">DC的句柄，用于定义分层窗口的表面。可以通过调用CreateCompatibleDC函数获得此句柄。如果窗口的形状和视觉上下文未更改，则hdcSrc可以为NULL。</param>
        /// <param name="pptSrc">指向指定设备上下文中层位置的结构的指针。如果hdcSrc为NULL，则pptSrc应该为NULL。</param>
        /// <param name="crKey">一个结构，用于指定在组成分层窗口时要使用的颜色键。要生成COLORREF，请使用RGB宏。</param>
        /// <param name="pblend">指向结构的指针，该结构指定组成分层窗口时要使用的透明度值。</param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        #endregion

        public LayerBoederForm(FormExt _feForm)
        {
            this.feForm = _feForm;
            this.Size = new Size(this.feForm.Bounds.Height + borderThickness * 2, this.feForm.Bounds.Height + borderThickness * 2);
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        #region 重写

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            isHandleCreate = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.Style |= WS_CLIPSIBLINGS | WS_VISIBLE;
                cParms.Style ^= WS_CLIPCHILDREN | WS_GROUP | WS_TABSTOP;
                cParms.ExStyle |= WS_EX_LAYERED;
                return cParms;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.mouseIsDown = true;
            this.startMouseDown = Control.MousePosition;
            this.feFormRect = this.feForm.Bounds;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.mouseIsDown = false;
            this.startMouseDown = Point.Empty;
            this.feFormRect = Rectangle.Empty;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.mouseIsDown == false)
            {
                this.Cursor = Cursors.Default;
            }

            this.mouseIsDown = false;
            this.startMouseDown = Point.Empty;
            this.feFormRect = Rectangle.Empty;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.mouseIsDown == false)
            {
                this.SetNCHITTEST(this.PointToClient(Control.MousePosition));
            }
            else
            {
                Point difference = new Point(Control.MousePosition.X - this.startMouseDown.X, Control.MousePosition.Y - this.startMouseDown.Y);
                if (difference.X != 0 || difference.Y != 0)
                {
                    if (this.stretchType == StretchTypes.LeftTop)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X + difference.X,
                            this.feFormRect.Y + difference.Y,
                            this.feFormRect.Width - difference.X,
                            this.feFormRect.Height - difference.Y,
                            BoundsSpecified.All
                        );
                    }
                    else if (this.stretchType == StretchTypes.RightTop)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X,
                            this.feFormRect.Y + difference.Y,
                            this.feFormRect.Width + difference.X,
                            this.feFormRect.Height - difference.Y,
                            BoundsSpecified.Y | BoundsSpecified.Height | BoundsSpecified.Width
                        );
                    }
                    else if (this.stretchType == StretchTypes.RightBottom)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X,
                            this.feFormRect.Y,
                            this.feFormRect.Width + difference.X,
                            this.feFormRect.Height + difference.Y,
                            BoundsSpecified.Size
                        );
                    }
                    else if (this.stretchType == StretchTypes.LeftBottom)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X + difference.X,
                            this.feFormRect.Y,
                            this.feFormRect.Width - -difference.X,
                            this.feFormRect.Height - +difference.Y,
                            BoundsSpecified.X | BoundsSpecified.Width | BoundsSpecified.Height
                        );
                    }
                    else if (this.stretchType == StretchTypes.Top)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X,
                            this.feFormRect.Y + difference.Y,
                            this.feFormRect.Width,
                            this.feFormRect.Height - difference.Y,
                            BoundsSpecified.Y | BoundsSpecified.Height
                        );
                    }
                    else if (this.stretchType == StretchTypes.Bottom)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X,
                            this.feFormRect.Y,
                            this.feFormRect.Width,
                            this.feFormRect.Height + difference.Y,
                            BoundsSpecified.Height
                        );
                    }
                    else if (this.stretchType == StretchTypes.Left)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X + difference.X,
                            this.feFormRect.Y,
                            this.feFormRect.Width - difference.X,
                            this.feFormRect.Height,
                            BoundsSpecified.X | BoundsSpecified.Width
                        );
                    }
                    else if (this.stretchType == StretchTypes.Right)
                    {
                        this.feForm.SetBounds(
                            this.feFormRect.X,
                            this.feFormRect.Y,
                            this.feFormRect.Width + difference.X,
                            this.feFormRect.Height,
                            BoundsSpecified.Width
                        );
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATE;
                if (this.feForm != null)
                {
                    this.feForm.Activate();
                }
                return;
            }
            base.WndProc(ref m);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 使分层控件的整个图面无效并导致重绘控件（Invalidate已失效）。
        /// </summary>
        public void InvalidateLayer()
        {
            if (this.isHandleCreate && this.Visible)
            {
                #region 绘制图片

                Color start = Color.FromArgb(40, 0, 0, 0);
                Color zhongjian = Color.FromArgb(10, 0, 0, 0);
                Color end = Color.FromArgb(0, 0, 0, 0);

                Rectangle rect = new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height);

                Bitmap bmp = new Bitmap(rect.Width, rect.Height);
                Graphics g = Graphics.FromImage(bmp);


                Rectangle left = new Rectangle(rect.X, rect.Y + this.borderThickness, this.borderThickness, rect.Height - this.borderThickness * 2);
                Rectangle right = new Rectangle(rect.Right - this.borderThickness, rect.Y + this.borderThickness, this.borderThickness, rect.Height - this.borderThickness * 2);
                Rectangle top = new Rectangle(rect.X + this.borderThickness, rect.Y, rect.Width - this.borderThickness * 2, this.borderThickness);
                Rectangle bottom = new Rectangle(rect.X + this.borderThickness, rect.Bottom - this.borderThickness, rect.Width - this.borderThickness * 2, this.borderThickness);

                Rectangle lefttop = new Rectangle(rect.X, rect.Y, this.borderThickness * 2, this.borderThickness * 2);
                Rectangle righttop = new Rectangle(rect.Right - this.borderThickness * 2, rect.Y, this.borderThickness * 2, this.borderThickness * 2);
                Rectangle rightbottom = new Rectangle(rect.Right - this.borderThickness * 2, rect.Bottom - this.borderThickness * 2, this.borderThickness * 2, this.borderThickness * 2);
                Rectangle leftbottom = new Rectangle(rect.X, rect.Bottom - this.borderThickness * 2, this.borderThickness * 2, this.borderThickness * 2);

                LinearGradientBrush left_brush = new LinearGradientBrush(left, Color.Transparent, Color.Transparent, 360);
                left_brush.InterpolationColors = new ColorBlend() { Positions = new float[] { 0.0f, 0.5f, 1.0f }, Colors = new Color[3] { end, zhongjian, start } };
                g.FillRectangle(left_brush, left);

                LinearGradientBrush right_brush = new LinearGradientBrush(right, Color.Transparent, Color.Transparent, 360);
                right_brush.InterpolationColors = new ColorBlend() { Positions = new float[] { 0.0f, 0.5f, 1.0f }, Colors = new Color[3] { start, zhongjian, end } };
                g.FillRectangle(right_brush, right);

                LinearGradientBrush top_brush = new LinearGradientBrush(top, Color.Transparent, Color.Transparent, 90);
                top_brush.InterpolationColors = new ColorBlend() { Positions = new float[] { 0.0f, 0.5f, 1.0f }, Colors = new Color[3] { end, zhongjian, start } };
                g.FillRectangle(top_brush, top);

                LinearGradientBrush bottom_brush = new LinearGradientBrush(bottom, Color.Transparent, Color.Transparent, 90);
                bottom_brush.InterpolationColors = new ColorBlend() { Positions = new float[] { 0.0f, 0.5f, 1.0f }, Colors = new Color[3] { start, zhongjian, end } };
                g.FillRectangle(bottom_brush, bottom);

                {
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddPie(lefttop, 0, 360);
                    PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath) { };
                    pathGradientBrush.Blend.Positions = new float[] { 0.0f, 0.3f, 0.7f };
                    pathGradientBrush.CenterColor = Color.FromArgb(20, 0, 0, 0);
                    pathGradientBrush.SurroundColors = new Color[] { end };
                    g.FillPie(pathGradientBrush, lefttop, 180, 90);
                    pathGradientBrush.Dispose();
                }

                {
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddPie(righttop, 0, 360);
                    PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                    pathGradientBrush.Blend.Positions = new float[] { 0.0f, 0.3f, 0.7f };
                    pathGradientBrush.CenterColor = Color.FromArgb(20, 0, 0, 0);
                    pathGradientBrush.SurroundColors = new Color[] { end };
                    g.FillPie(pathGradientBrush, righttop, 270, 90);
                    pathGradientBrush.Dispose();
                }

                {
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddPie(rightbottom, 0, 360);
                    PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                    pathGradientBrush.Blend.Positions = new float[] { 0.0f, 0.3f, 0.7f };
                    pathGradientBrush.CenterColor = Color.FromArgb(20, 0, 0, 0);
                    pathGradientBrush.SurroundColors = new Color[] { end };
                    g.FillPie(pathGradientBrush, rightbottom, 360, 90);
                    pathGradientBrush.Dispose();
                }

                {
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddPie(leftbottom, 0, 360);
                    PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                    pathGradientBrush.Blend.Positions = new float[] { 0.0f, 0.3f, 0.7f };
                    pathGradientBrush.CenterColor = Color.FromArgb(20, 0, 0, 0);
                    pathGradientBrush.SurroundColors = new Color[] { end };
                    g.FillPie(pathGradientBrush, leftbottom, 90, 90);
                    pathGradientBrush.Dispose();
                }


                // 绘制边框
                if (this.feForm.CaptionEnabled)
                {
                    Pen border_pen = new Pen(this.feForm.BorderColor, 1);
                    Rectangle border_rect = new Rectangle(this.borderThickness - 1, this.borderThickness - 1, this.Bounds.Width - this.borderThickness * 2 + 1, this.Bounds.Height - this.borderThickness * 2 + 1);
                    g.DrawRectangle(border_pen, border_rect);
                    border_pen.Dispose();
                }


                #region 释放

                if (left_brush != null)
                    left_brush.Dispose();
                if (right_brush != null)
                    right_brush.Dispose();
                if (top_brush != null)
                    top_brush.Dispose();
                if (bottom_brush != null)
                    bottom_brush.Dispose();

                g.Dispose();

                #endregion

                #endregion

                #region 把图片绘制到控件上

                IntPtr hdcDst = GetDC(this.Handle);
                IntPtr hdcSrc = CreateCompatibleDC(hdcDst);

                IntPtr newBitmap = bmp.GetHbitmap(Color.FromArgb(0));//创建一张位图
                IntPtr oldBitmap = SelectObject(hdcSrc, newBitmap);//位图绑定到DC设备上

                Point pptDst = new Point(this.Left, this.Top);
                Size psize = new Size(bmp.Width, bmp.Height);
                Point pptSrc = new Point(0, 0);

                BLENDFUNCTION pblend = new BLENDFUNCTION();
                pblend.BlendOp = AC_SRC_OVER;
                pblend.SourceConstantAlpha = 255;
                pblend.AlphaFormat = AC_SRC_ALPHA;
                pblend.BlendFlags = 0;

                UpdateLayeredWindow(this.Handle, hdcDst, ref pptDst, ref psize, hdcSrc, ref pptSrc, 0, ref pblend, ULW_ALPHA);

                SelectObject(hdcSrc, oldBitmap);

                if (newBitmap != IntPtr.Zero)
                {
                    DeleteObject(newBitmap);
                }

                ReleaseDC(this.Handle, hdcDst);
                DeleteDC(hdcSrc);

                if (bmp != null)
                {
                    bmp.Dispose();
                }
                #endregion 

            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置窗体鼠标NCHITTEST状态
        /// </summary>
        /// <param name="point">鼠标相对于控价的坐标</param>
        private void SetNCHITTEST(Point point)
        {
            if (this.WindowState == FormWindowState.Normal && (this.feForm.ResizeType == FormExt.ResizeTypes.Drag || this.feForm.ResizeType == FormExt.ResizeTypes.CaptionDrag))
            {
                int scale_borderThickness = (int)(this.borderThickness * DotsPerInchHelper.DPIScale.XScale);

                //左上
                if (point.X < scale_borderThickness && point.Y < scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNWSE)
                    {
                        this.Cursor = Cursors.SizeNWSE;
                    }
                    this.stretchType = StretchTypes.LeftTop;
                }
                //右下
                else if (point.X > this.ClientRectangle.Right - scale_borderThickness && point.Y > this.ClientRectangle.Bottom - scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNWSE)
                    {
                        this.Cursor = Cursors.SizeNWSE;
                    }
                    this.stretchType = StretchTypes.RightBottom;
                }
                //右上
                else if (point.X > this.ClientRectangle.Right - scale_borderThickness && point.Y < scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNESW)
                    {
                        this.Cursor = Cursors.SizeNESW;
                    }
                    this.stretchType = StretchTypes.RightTop;
                }
                //左下
                else if (point.X < scale_borderThickness && point.Y > this.ClientRectangle.Bottom - scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNESW)
                    {
                        this.Cursor = Cursors.SizeNESW;
                    }
                    this.stretchType = StretchTypes.LeftBottom;
                }
                //上
                else if (point.Y < scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNS)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    this.stretchType = StretchTypes.Top;
                }
                //下
                else if (point.Y > this.ClientRectangle.Bottom - scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeNS)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    this.stretchType = StretchTypes.Bottom;
                }
                //左
                else if (point.X < scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeWE)
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    this.stretchType = StretchTypes.Left;
                }
                //右
                else if (point.X > this.ClientRectangle.Right - scale_borderThickness)
                {
                    if (this.Cursor != Cursors.SizeWE)
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    this.stretchType = StretchTypes.Right;
                }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鼠标当前拉伸状态
        /// </summary>
        [Description("鼠标当前拉伸状态")]
        public enum StretchTypes
        {
            /// <summary>
            /// 禁止拉伸
            /// </summary>
            None,
            /// <summary>
            /// 允许往上拉伸
            /// </summary>
            Top,
            /// <summary>
            /// 允许往右拉伸
            /// </summary>
            Right,
            /// <summary>
            /// 允许往下拉伸
            /// </summary>
            Bottom,
            /// <summary>
            /// 允许往左拉伸
            /// </summary>
            Left,
            /// <summary>
            /// 允许往上、右、下、左拉伸
            /// </summary>
            Front,
            /// <summary>
            /// 允许往左上对角线拉伸
            /// </summary>
            LeftTop,
            /// <summary>
            /// 允许往右上对角线拉伸
            /// </summary>
            RightTop,
            /// <summary>
            /// 允许往左下对角线拉伸
            /// </summary>
            LeftBottom,
            /// <summary>
            /// 允许往右下对角线拉伸
            /// </summary>
            RightBottom,
        }

        #endregion

    }

    /// <summary>
    /// 扁平化窗体基类接口
    /// </summary>
    [Description("扁平化窗体基类接口")]
    public interface IFormExt
    {

    }

}

