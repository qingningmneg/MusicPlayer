
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
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// LabelExt控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("LabelExt控件")]
    [DefaultProperty("Text")]
    public class LabelExt : Control
    {
        #region 新增属性

        #region 滚动条

        private int scrollThickness = 10;
        /// <summary>
        /// 滚动条厚度
        /// </summary>
        [DefaultValue(10)]
        [Description("滚动条厚度")]
        public int ScrollThickness
        {
            get { return this.scrollThickness; }
            set
            {
                if (this.scrollThickness == value || value < 0)
                    return;
                this.scrollThickness = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollNormalBackColor = Color.FromArgb(68, 128, 128, 128);
        /// <summary>
        /// 滑条背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "68, 128, 128, 128")]
        [Description("滑条背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollNormalBackColor
        {
            get { return this.scrollNormalBackColor; }
            set
            {
                if (this.scrollNormalBackColor == value)
                    return;
                this.scrollNormalBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 滚动条滑块

        private int scrollSlideThickness = 10;
        /// <summary>
        /// 滑块条厚度
        /// </summary>
        [DefaultValue(10)]
        [Description("滑块条厚度")]
        public int ScrollSlideThickness
        {
            get { return this.scrollSlideThickness; }
            set
            {
                if (this.scrollSlideThickness == value || value < 0)
                    return;
                this.scrollSlideThickness = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollSlideNormalBackColor = Color.FromArgb(120, 64, 64, 64);
        /// <summary>
        /// 滑块背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "120, 64, 64, 64")]
        [Description("滑块背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollSlideNormalBackColor
        {
            get { return this.scrollSlideNormalBackColor; }
            set
            {
                if (this.scrollSlideNormalBackColor == value)
                    return;
                this.scrollSlideNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollSlideEnterBackColor = Color.FromArgb(160, 64, 64, 64);
        /// <summary>
        /// 滑块背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "160, 64, 64, 64")]
        [Description("滑块背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollSlideEnterBackColor
        {
            get { return this.scrollSlideEnterBackColor; }
            set
            {
                if (this.scrollSlideEnterBackColor == value)
                    return;
                this.scrollSlideEnterBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 滚动条按钮

        private bool scrollBtnShow = false;
        /// <summary>
        /// 是否显示按钮
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示按钮")]
        public bool ScrollBtnShow
        {
            get { return this.scrollBtnShow; }
            set
            {
                if (this.scrollBtnShow == value)
                    return;
                this.scrollBtnShow = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int scrollBtnHeight = 10;
        /// <summary>
        /// 按钮高度
        /// </summary>
        [DefaultValue(10)]
        [Description("/// 按钮高度")]
        public int ScrollBtnHeight
        {
            get { return this.scrollBtnHeight; }
            set
            {
                if (this.scrollBtnHeight == value || value < 0)
                    return;
                this.scrollBtnHeight = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollBtnNormalBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 按钮背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("按钮背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnNormalBackColor
        {
            get { return this.scrollBtnNormalBackColor; }
            set
            {
                if (this.scrollBtnNormalBackColor == value)
                    return;
                this.scrollBtnNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnEnterBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 按钮背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("按钮背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnEnterBackColor
        {
            get { return this.scrollBtnEnterBackColor; }
            set
            {
                if (this.scrollBtnEnterBackColor == value)
                    return;
                this.scrollBtnEnterBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnNormalForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 按钮颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("按钮颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnNormalForeColor
        {
            get { return this.scrollBtnNormalForeColor; }
            set
            {
                if (this.scrollBtnNormalForeColor == value)
                    return;
                this.scrollBtnNormalForeColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnEnterForeColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 按钮颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("按钮颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnEnterForeColor
        {
            get { return this.scrollBtnEnterForeColor; }
            set
            {
                if (this.scrollBtnEnterForeColor == value)
                    return;
                this.scrollBtnEnterForeColor = value;
                this.Invalidate();
            }
        }

        #endregion

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

        [Browsable(true)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        #endregion

        #region 字段

        #region 主容器

        /// <summary>
        /// 提示内容rect
        /// </summary>
        private RectangleF text_rect;
        /// <summary>
        /// 提示内容鼠标状态
        /// </summary>
        private MoveStatus text_status = MoveStatus.Normal;
        /// <summary>
        /// 提示内容真实rect
        /// </summary>
        private RectangleF text_reality_rect;


        #endregion

        #region 滚动条
        /// <summary>
        /// 滚动条
        /// </summary>
        private ScrollItem scroll = new ScrollItem();
        /// <summary>
        /// 滚动条滑块
        /// </summary>
        private ScrollItem scroll_slide = new ScrollItem();
        /// <summary>
        /// 滚动条上滚按钮
        /// </summary>
        private ScrollItem scroll_pre = new ScrollItem();
        /// <summary>
        /// 滚动条下滚按钮
        /// </summary>
        private ScrollItem scroll_next = new ScrollItem();
        #endregion

        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        private bool ismovedown = false;
        /// <summary>
        /// 鼠标按下的坐标
        /// </summary>
        private Point movedownpoint = Point.Empty;

        #endregion

        public LabelExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, true);

        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int scale_scrollThickness = (int)(this.ScrollThickness * DotsPerInchHelper.DPIScale.XScale);
            int scale_scrollSlideThickness = (int)(this.ScrollSlideThickness * DotsPerInchHelper.DPIScale.XScale);

            #region 背景
            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height));
            back_sb.Dispose();
            #endregion

            #region 提示信息文本
            SolidBrush text_sb = new SolidBrush(this.ForeColor);
            StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.Character };
            g.DrawString(this.Text, this.Font, text_sb, this.GetDisplayRectangle(), text_sf);
            text_sf.Dispose();
            text_sb.Dispose();
            #endregion

            #region 滚动条
            if (this.scroll.Rect.Height > this.scroll_slide.Rect.Height)
            {
                #region 画笔
                Pen scroll_normal_back_pen = new Pen(this.ScrollNormalBackColor, scale_scrollThickness);
                Pen scroll_slide_back_pen = new Pen(this.scroll_slide.Status == MoveStatus.Normal ? this.ScrollSlideNormalBackColor : this.ScrollSlideEnterBackColor, scale_scrollSlideThickness);

                SolidBrush scroll_pre_back_sb = new SolidBrush(this.scroll_pre.Status == MoveStatus.Normal ? this.ScrollBtnNormalBackColor : this.ScrollBtnEnterBackColor);
                Pen scroll_pre_pen = new Pen(this.scroll_pre.Status == MoveStatus.Normal ? this.ScrollBtnNormalForeColor : this.ScrollBtnEnterForeColor, scale_scrollThickness - 2) { EndCap = LineCap.Triangle };
                SolidBrush scroll_next_back_sb = new SolidBrush(this.scroll_next.Status == MoveStatus.Normal ? this.ScrollBtnNormalBackColor : this.ScrollBtnEnterBackColor);
                Pen scroll_next_pen = new Pen(this.scroll_next.Status == MoveStatus.Normal ? this.ScrollBtnNormalForeColor : this.ScrollBtnEnterForeColor, scale_scrollThickness - 2) { EndCap = LineCap.Triangle };

                #endregion

                #region 滚动条背景
                Point scroll_start_point = new Point((int)this.scroll.Rect.X + (int)(this.scroll.Rect.Width / 2f), (int)this.scroll.Rect.Y);
                Point scroll_end_point = new Point((int)this.scroll.Rect.X + (int)(this.scroll.Rect.Width / 2f), (int)this.scroll.Rect.Bottom);

                g.DrawLine(scroll_normal_back_pen, scroll_start_point, scroll_end_point);
                #endregion

                #region 滚动条按钮
                g.FillRectangle(scroll_pre_back_sb, this.scroll_pre.Rect);
                g.DrawLine(scroll_pre_pen, new PointF(this.scroll_pre.Rect.X + this.scroll_pre.Rect.Width / 2f, this.scroll_pre.Rect.Bottom - this.scroll_pre.Rect.Height / 3f), new PointF(this.scroll_pre.Rect.X + this.scroll_pre.Rect.Width / 2f, this.scroll_pre.Rect.Bottom - this.scroll_pre.Rect.Height / 3f - 1));

                g.FillRectangle(scroll_next_back_sb, this.scroll_next.Rect);
                g.DrawLine(scroll_next_pen, new PointF(this.scroll_next.Rect.X + this.scroll_next.Rect.Width / 2f, this.scroll_next.Rect.Y + this.scroll_pre.Rect.Height / 3f), new PointF(this.scroll_next.Rect.X + this.scroll_next.Rect.Width / 2f, this.scroll_next.Rect.Y + this.scroll_pre.Rect.Height / 3f + 1));

                #endregion

                #region  滚动条滑块
                Point scroll_slide_start_point = new Point((int)this.scroll_slide.Rect.X + (int)(this.scroll_slide.Rect.Width / 2f), (int)this.scroll_slide.Rect.Y);
                Point scroll_slide_end_point = new Point((int)this.scroll_slide.Rect.X + (int)(this.scroll_slide.Rect.Width / 2f), (int)this.scroll_slide.Rect.Bottom);

                g.DrawLine(scroll_slide_back_pen, scroll_slide_start_point, scroll_slide_end_point);
                #endregion

                #region 释放画笔
                scroll_normal_back_pen.Dispose();
                scroll_slide_back_pen.Dispose();
                if (scroll_pre_back_sb != null)
                    scroll_pre_back_sb.Dispose();
                if (scroll_pre_pen != null)
                    scroll_pre_pen.Dispose();
                if (scroll_next_back_sb != null)
                    scroll_next_back_sb.Dispose();
                if (scroll_next_pen != null)
                    scroll_next_pen.Dispose();
                #endregion
            }
            #endregion

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            #region 滚动条
            if (this.scroll_pre.Status != MoveStatus.Normal)
            {
                this.scroll_pre.Status = MoveStatus.Normal;
            }
            if (this.scroll_next.Status != MoveStatus.Normal)
            {
                this.scroll_next.Status = MoveStatus.Normal;
            }
            if (this.scroll_slide.Status != MoveStatus.Normal)
            {
                this.scroll_slide.Status = MoveStatus.Normal;
            }
            #endregion

            this.ismovedown = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.ismovedown = true;
            this.movedownpoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.ismovedown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool isreset = false;

            if (!ismovedown)
            {
                #region 滚动条
                #region  scroll
                if (this.scroll.Rect.Contains(e.Location))
                {
                    if (this.scroll.Status != MoveStatus.Enter)
                    {
                        this.scroll.Status = MoveStatus.Enter;
                        isreset = true;
                        this.Focus();
                    }
                }
                else
                {
                    if (this.scroll.Status != MoveStatus.Normal)
                    {
                        this.scroll.Status = MoveStatus.Normal;
                        isreset = true;
                        this.Focus();
                    }
                }
                #endregion
                #region scroll_pre
                if (this.scroll_pre.Rect.Contains(e.Location))
                {
                    if (this.scroll_pre.Status != MoveStatus.Enter)
                    {
                        this.scroll_pre.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_pre.Status != MoveStatus.Normal)
                    {
                        this.scroll_pre.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #region scroll_next
                if (this.scroll_next.Rect.Contains(e.Location))
                {
                    if (this.scroll_next.Status != MoveStatus.Enter)
                    {
                        this.scroll_next.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_next.Status != MoveStatus.Normal)
                    {
                        this.scroll_next.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #region scroll_slide
                if (this.scroll_slide.Rect.Contains(e.Location))
                {
                    if (this.scroll_slide.Status != MoveStatus.Enter)
                    {
                        this.scroll_slide.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_slide.Status != MoveStatus.Normal)
                    {
                        this.scroll_slide.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #endregion
                #region 文本
                if (this.text_rect.Contains(e.Location))
                {
                    if (this.text_status != MoveStatus.Enter)
                    {
                        this.text_status = MoveStatus.Enter;
                    }
                }
                else
                {
                    if (this.text_status != MoveStatus.Normal)
                    {
                        this.text_status = MoveStatus.Normal;
                    }
                }
                #endregion
            }

            if (this.ismovedown && this.scroll.Status == MoveStatus.Enter)
            {
                int offset = (int)((e.Location.Y - this.movedownpoint.Y));
                if (this.IsResetScroll(offset))
                {
                    this.movedownpoint = e.Location;
                    isreset = true;
                }
            }

            if (isreset)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                #region 上滚动
                if (this.scroll_pre.Status == MoveStatus.Enter)
                {
                    if (this.IsResetScroll(-1))
                    {
                        this.Invalidate();
                    }
                }
                #endregion
                #region 下滚动
                else if (this.scroll_next.Status == MoveStatus.Enter)
                {
                    if (this.IsResetScroll(1))
                    {
                        this.Invalidate();
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.scroll.Status == MoveStatus.Enter || this.text_status == MoveStatus.Enter)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                if (this.IsResetScroll(offset))
                {
                    this.Invalidate();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeRectangle();
            this.Invalidate();
        }

        #endregion
        #region 私有方法

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeRectangle()
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.Handle, out g, out hDC);

            int scale_scrollThickness = (int)(this.ScrollThickness * DotsPerInchHelper.DPIScale.XScale);
            int scale_scrollBtnHeight = (int)(this.ScrollBtnHeight * DotsPerInchHelper.DPIScale.XScale);

            StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.Character };
            SizeF text_size = g.MeasureString(this.Text, this.Font, (int)this.ClientRectangle.Width, text_sf);
            if (text_size.Height > this.ClientRectangle.Height)
            {
                text_size = g.MeasureString(this.Text, this.Font, (int)this.ClientRectangle.Width - scale_scrollThickness, text_sf);
                this.text_rect = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - scale_scrollThickness, this.ClientRectangle.Height);
            }
            else
            {
                this.text_rect = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            this.text_reality_rect = new RectangleF(text_rect.Location, text_size);
            text_sf.Dispose();

            if (this.ScrollBtnShow)
            {
                this.scroll_pre.Rect = new RectangleF(this.ClientRectangle.Right - scale_scrollThickness, this.ClientRectangle.Top, scale_scrollThickness, scale_scrollBtnHeight);
                this.scroll_next.Rect = new RectangleF(this.ClientRectangle.Right - scale_scrollThickness, this.ClientRectangle.Bottom - scale_scrollBtnHeight, scale_scrollThickness, scale_scrollBtnHeight);
            }
            else
            {
                this.scroll_pre.Rect = new RectangleF(0, this.ClientRectangle.Y, 0, 0);
                this.scroll_next.Rect = new RectangleF(this.ClientRectangle.Right - scale_scrollThickness, this.ClientRectangle.Bottom, 0, 0);
            }
            this.scroll.Rect = new RectangleF(this.ClientRectangle.Right - scale_scrollThickness, this.ClientRectangle.Y + this.scroll_pre.Rect.Height, scale_scrollThickness, this.ClientRectangle.Height - this.scroll_pre.Rect.Height - this.scroll_next.Rect.Height);
            float slide_h = (this.text_rect.Height / this.text_reality_rect.Height * this.scroll.Rect.Height);
            if (this.text_reality_rect.Height <= this.text_rect.Height)
            {
                slide_h = this.scroll.Rect.Height;
            }
            this.scroll_slide.Rect = new RectangleF(this.scroll.Rect.X, this.scroll_pre.Rect.Bottom, scale_scrollThickness, slide_h);

            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// 判断是否需要更新滚动条UI根据滚动条滑块偏移量
        /// </summary>
        /// <param name="offset">滚动条滑块偏移量</param>
        /// <returns>是否要刷新</returns>
        private bool IsResetScroll(int offset)
        {
            float y = this.scroll_slide.Rect.Y + offset;
            if (y < this.scroll.Rect.Y)
                y = this.scroll.Rect.Y;
            if (y > this.scroll.Rect.Bottom - this.scroll_slide.Rect.Height)
                y = this.scroll.Rect.Bottom - this.scroll_slide.Rect.Height;

            bool result = !(this.scroll_slide.Rect.Y == y);
            this.scroll_slide.Rect = new RectangleF(this.scroll_slide.Rect.X, y, this.scroll_slide.Rect.Width, this.scroll_slide.Rect.Height);
            return result;
        }

        /// <summary>
        /// 获取文本Y坐标
        /// </summary>
        /// <returns></returns>
        private int GetDisplayY()
        {
            float y = 0;
            if (this.scroll.Rect.Height > this.scroll_slide.Rect.Height)
            {
                y = -(this.scroll_slide.Rect.Y - this.scroll_pre.Rect.Bottom) / (this.scroll.Rect.Height - this.scroll_slide.Rect.Height) * (this.text_reality_rect.Height - this.text_rect.Height);
            }
            return (int)(this.text_rect.Y + y);
        }

        /// <summary>
        /// 获取文本rect
        /// </summary>
        /// <returns></returns>
        private Rectangle GetDisplayRectangle()
        {
            return new Rectangle(0, this.GetDisplayY(), (int)this.text_rect.Width, (int)this.text_reality_rect.Height);
        }

        #endregion

        #region 类

        /// <summary>
        /// 滚动条选项信息
        /// </summary>
        [Description("滚动条选项信息")]
        public class ScrollItem
        {
            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 选项rect
            /// </summary>
            public RectangleF Rect
            {
                get { return this.rect; }
                set { this.rect = value; }
            }

            private MoveStatus status = MoveStatus.Normal;
            /// <summary>
            /// 选项鼠标状态
            /// </summary>
            public MoveStatus Status
            {
                get { return this.status; }
                set { this.status = value; }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鼠标状态
        /// </summary>
        [Description("鼠标状态")]
        public enum MoveStatus
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

        #endregion
    }
}
