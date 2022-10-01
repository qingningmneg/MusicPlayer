
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
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 日期选择美化控件
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(DateExt), "控件.DateExt.bmp")]
    [Description("日期选择美化控件")]
    [DefaultProperty("DatePicker")]
    [Designer(typeof(DateExtDesigner))]
    public class DateExt : Control
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DoubleClick
        {
            add { base.DoubleClick += value; }
            remove { base.DoubleClick -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event MouseEventHandler MouseDoubleClick
        {
            add { base.MouseDoubleClick += value; }
            remove { base.MouseDoubleClick -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackColorChanged
        {
            add { base.BackColorChanged += value; }
            remove { base.BackColorChanged -= value; }
        }

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
                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                this.dateBody.selectElementItem = DateContentSelectedTypes.None;
                this.Invalidate();
            }
        }

        private DateOperateModes dateOperateMode = DateOperateModes.Editor;
        /// <summary>
        /// 日期操作模式
        /// </summary>
        [DefaultValue(DateOperateModes.Editor)]
        [Description("日期操作模式")]
        public DateOperateModes DateOperateMode
        {
            get { return this.dateOperateMode; }
            set
            {
                if (this.dateOperateMode == value)
                    return;

                this.dateOperateMode = value;
                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                this.dateBody.selectElementItem = DateContentSelectedTypes.None;
                this.Invalidate();
            }
        }

        private int borderThickness = 1;
        /// <summary>
        /// 边框厚度
        /// </summary>
        [DefaultValue(1)]
        [Description("边框厚度")]
        public int BorderThickness
        {
            get { return this.borderThickness; }
            set
            {
                if (this.borderThickness == value || value < 0)
                    return;

                this.borderThickness = value;
                this.Height = this.GetControlAutoHeight();
                this.InitializeControlElementRectangle();
            }
        }

        private Color borderColor = Color.DarkGray;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DarkGray")]
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

        private int datePadding = 2;
        /// <summary>
        /// 边框与内容内的距离
        /// </summary>
        [DefaultValue(2)]
        [Description("边框与内容内的距离")]
        public int DatePadding
        {
            get { return this.datePadding; }
            set
            {
                if (this.datePadding == value)
                    return;

                this.datePadding = value;
                this.Height = this.GetControlAutoHeight();
                this.InitializeControlElementRectangle();
            }
        }

        private bool clearButtonVisible = false;
        /// <summary>
        /// 是否显示清除按钮
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示清除按钮")]
        public bool ClearButtonVisible
        {
            get { return this.clearButtonVisible; }
            set
            {
                if (this.clearButtonVisible == value)
                    return;

                this.clearButtonVisible = value;
                this.UpdateDateBodyElements();
                this.InitializeControlElementRectangle();
            }
        }

        private ClearButtonAlignments clearButtonAlignment = ClearButtonAlignments.Far;
        /// <summary>
        /// 清除按钮对齐方式
        /// </summary>
        [DefaultValue(ClearButtonAlignments.Far)]
        [Description("清除按钮对齐方式")]
        public ClearButtonAlignments ClearButtonAlignment
        {
            get { return this.clearButtonAlignment; }
            set
            {
                if (this.clearButtonAlignment == value)
                    return;

                this.clearButtonAlignment = value;
                this.UpdateDateBodyElements();
                this.InitializeControlElementRectangle();
            }
        }

        private Color clearButtonColor = Color.Tomato;
        /// <summary>
        /// 清除按钮前景色
        /// </summary>
        [DefaultValue(typeof(Color), "Tomato")]
        [Description("清除按钮前景色")]
        public Color ClearButtonColor
        {
            get { return this.clearButtonColor; }
            set
            {
                if (this.clearButtonColor == value)
                    return;

                this.clearButtonColor = value;
                this.Invalidate();
            }
        }

        private DateSymbolFormats dateTextSymbolFormat = DateSymbolFormats.横线;
        /// <summary>
        /// 日期符号格式
        /// </summary>
        [DefaultValue(DateSymbolFormats.横线)]
        [Description("日期符号格式")]
        public DateSymbolFormats DateTextSymbolFormat
        {
            get { return this.dateTextSymbolFormat; }
            set
            {
                if (this.dateTextSymbolFormat == value)
                    return;

                this.dateTextSymbolFormat = value;
                this.UpdateDateSymbol();
            }
        }

        private Color dateTextSymbolColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 日期符号颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("日期符号颜色")]
        public Color DateTextSymbolColor
        {
            get { return this.dateTextSymbolColor; }
            set
            {
                if (this.dateTextSymbolColor == value)
                    return;

                this.dateTextSymbolColor = value;
                this.Invalidate();
            }
        }

        private bool dateTextWeek = false;
        /// <summary>
        /// 是否显示星期
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示星期")]
        public bool DateTextWeek
        {
            get { return this.dateTextWeek; }
            set
            {
                if (this.dateTextWeek == value)
                    return;

                this.dateTextWeek = value;
                this.UpdateDateSymbol();
            }
        }

        private Color dateTextWeekColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 星期文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("星期文本颜色")]
        public Color DateTextWeekColor
        {
            get { return this.dateTextWeekColor; }
            set
            {
                if (this.dateTextWeekColor == value)
                    return;

                this.dateTextWeekColor = value;
                this.Invalidate();
            }
        }

        private Image dateImage = null;
        /// <summary>
        /// 日期图片
        /// </summary>
        [DefaultValue(null)]
        [Description("日期图片")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image DateImage
        {
            get { return this.dateImage; }
            set
            {
                if (this.dateImage == value)
                    return;

                this.dateImage = value;
                if (this.disable_image_tmp != null)
                {
                    this.disable_image_tmp.Dispose();
                    this.disable_image_tmp = null;
                }

                this.Invalidate();
            }
        }

        private DateImageAligns dateImageAlign = DateImageAligns.Left;
        /// <summary>
        /// 日期图片对齐方式
        /// </summary>
        [DefaultValue(DateImageAligns.Left)]
        [Description("日期图片对齐方式")]
        public DateImageAligns DateImageAlign
        {
            get { return this.dateImageAlign; }
            set
            {
                if (this.dateImageAlign == value)
                    return;

                this.dateImageAlign = value;
                this.UpdateDateBodyElements();
                this.InitializeControlElementRectangle();
            }
        }

        private string dateNullTipText = "";
        /// <summary>
        /// 日期空值提示文本
        /// </summary>
        [DefaultValue("")]
        [Description("日期空值提示文本")]
        public string DateNullTipText
        {
            get { return this.dateNullTipText; }
            set
            {
                if (this.dateNullTipText == value)
                    return;

                this.dateNullTipText = value;
                this.Invalidate();
            }
        }

        private Color dateNullTipTextForeColor = Color.Tomato;
        /// <summary>
        /// 日期空值提示文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Tomato")]
        [Description("日期空值提示文本颜色")]
        public Color DateNullTipTextForeColor
        {
            get { return this.dateNullTipTextForeColor; }
            set
            {
                if (this.dateNullTipTextForeColor == value)
                    return;

                this.dateNullTipTextForeColor = value;
                this.Invalidate();
            }
        }

        private DateTextAligns dateTextAlign = DateTextAligns.Left;
        /// <summary>
        /// 日期文本对齐方式
        /// </summary>
        [DefaultValue(DateTextAligns.Left)]
        [Description("日期文本对齐方式")]
        public DateTextAligns DateTextAlign
        {
            get { return this.dateTextAlign; }
            set
            {
                if (this.dateTextAlign == value)
                    return;

                this.dateTextAlign = value;
                this.InitializeControlElementRectangle();
            }
        }

        private Color backNormalColor = Color.White;
        /// <summary>
        /// 日期背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("日期背景颜色（正常）")]
        public Color BackNormalColor
        {
            get { return this.backNormalColor; }
            set
            {
                if (this.backNormalColor == value)
                    return;

                this.backNormalColor = value;
                this.Invalidate();
            }
        }

        private Color backDisableColor = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// 日期背景颜色（禁用）
        /// </summary>
        [DefaultValue(typeof(Color), "240,240,240")]
        [Description("日期背景颜色（禁用）")]
        public Color BackDisableColor
        {
            get { return this.backDisableColor; }
            set
            {
                if (this.backDisableColor == value)
                    return;

                this.backDisableColor = value;
                this.Invalidate();
            }
        }

        private Color dateTextNormalForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 日期文本颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("日期文本颜色(正常)")]
        public Color DateTextNormalForeColor
        {
            get { return this.dateTextNormalForeColor; }
            set
            {
                if (this.dateTextNormalForeColor == value)
                    return;

                this.dateTextNormalForeColor = value;
                this.Invalidate();
            }
        }

        private Color dateTextDisableForeColor = Color.DimGray;
        /// <summary>
        /// 日期文本颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("日期文本颜色(禁用)")]
        public Color DateTextDisableForeColor
        {
            get { return this.dateTextDisableForeColor; }
            set
            {
                if (this.dateTextDisableForeColor == value)
                    return;

                this.dateTextDisableForeColor = value;
                this.Invalidate();
            }
        }

        private Color dateTextHighlightBackColor = Color.Empty;
        /// <summary>
        /// 日期文本背景颜色（高亮）（空值采用系统默认配置）
        /// </summary>
        [DefaultValue(typeof(Color), "")]
        [Description("日期文本背景颜色（高亮）（空值采用系统默认配置）")]
        public Color DateTextHighlightBackColor
        {
            get { return this.dateTextHighlightBackColor; }
            set
            {
                if (this.dateTextHighlightBackColor == value)
                    return;

                this.dateTextHighlightBackColor = value;
                this.Invalidate();
            }
        }

        private Color dateTextHighlightForeColor = Color.Empty;
        /// <summary>
        /// 日期文本颜色（高亮）（空值采用系统默认配置）
        /// </summary>
        [DefaultValue(typeof(Color), "")]
        [Description("日期文本颜色（高亮）（空值采用系统默认配置）")]
        public Color DateTextHighlightForeColor
        {
            get { return this.dateTextHighlightForeColor; }
            set
            {
                if (this.dateTextHighlightForeColor == value)
                    return;

                this.dateTextHighlightForeColor = value;
                this.Invalidate();
            }
        }

        private DatePickerExt datePicker = null;
        /// <summary>
        /// 日期选择面板
        /// </summary>
        [Browsable(true)]
        [Description("日期选择面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DatePickerExt DatePicker
        {
            get
            {
                if (this.datePicker == null)
                    this.datePicker = new DatePickerExt();
                return this.datePicker;
            }
            set
            {
                this.datePicker = value;
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
                return System.Windows.Forms.ImeMode.Close;
            }
        }

        public new Font Font
        {
            get { return base.Font; }
            set
            {
                if (base.Font == value)
                    return;

                base.Font = value;
                this.Height = this.GetControlAutoHeight();
                this.CalculationDateBodyElementSize();
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        protected bool activatedState = false;
        /// <summary>
        /// 时间文本与图片的间距
        /// </summary>
        private int image_value_space = 2;
        /// <summary>
        /// 存放生成禁用状态图片
        /// </summary>
        private Image disable_image_tmp = null;
        /// <summary>
        /// 当前鼠标按下的功能区
        /// </summary>
        private MouseDownAreaTypes mouseDownAreaType = MouseDownAreaTypes.None;
        /// <summary>
        /// 存放时间元素信息
        /// </summary>
        private DateBody dateBody = new DateBody();
        /// <summary>
        /// 日期面板显示状态
        /// </summary>
        private bool datePickerDisplayStatus = false;

        /// <summary>
        /// 日期控件内容允许选中的元素(已排好序)
        /// </summary>
        List<DateContentSelectedTypes> dateBodyElements = new List<DateContentSelectedTypes>();

        private ToolStripDropDown tsdd = null;

        private ToolStripControlHost tsch = null;

        #endregion

        public DateExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);

            this.SuspendLayout();

            this.Font = new Font("宋体", 9);

            this.DatePicker.BottomBarClearClick += this.datePicker_BottomBarClearClick;
            this.DatePicker.BottomBarNowClick += this.DatePicker_BottomBarNowClick;
            this.DatePicker.BottomBarConfirmClick += this.datePicker_BottomBarConfirmClick;
            this.DatePicker.DateValueChanged += this.DatePicker_DateValueChanged;
            this.DatePicker.DateFormatChanged += this.DatePicker_DateFormatChanged;

            this.ResumeLayout();

            this.UpdateDateBodyElements();
            this.SetDatePickerDateValueToText();
            this.UpdateDateSymbol();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 背景

            SolidBrush back_sb = new SolidBrush(this.Enabled ? this.BackNormalColor : this.BackDisableColor);
            g.FillRectangle(back_sb, this.ClientRectangle);
            back_sb.Dispose();

            #endregion

            #region 边框

            if (this.BorderThickness > 0)
            {
                Pen border_pen = new Pen(this.Enabled ? this.BorderColor : this.DateTextDisableForeColor, this.BorderThickness);
                RectangleF border_rect = ControlCommom.TransformRectangleF(this.ClientRectangle, this.BorderThickness);
                g.DrawRectangle(border_pen, border_rect.X, border_rect.Y, border_rect.Width, border_rect.Height);
                border_pen.Dispose();
            }

            #endregion

            #region 控件激活状态虚线框

            if (this.Enabled && !this.ReadOnly && this.activatedState && this.DateOperateMode == DateOperateModes.DropDown)
            {
                Pen activated_border_pen = new Pen(this.BorderColor, 1) { DashStyle = DashStyle.Dash };
                Rectangle rect = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 4 - 1, this.ClientRectangle.Height - 4 - 1);
                g.DrawRectangle(activated_border_pen, rect);
                activated_border_pen.Dispose();
            }

            #endregion

            Region source_c_region = g.Clip;
            Region content_region = new Region(this.dateBody.content_rect);
            g.Clip = content_region;

            #region 图片

            Image image = (this.DateImage != null) ? this.DateImage : Resources.date;
            if (this.Enabled)
            {
                g.DrawImage(image, this.dateBody.image_rect);
            }
            else
            {
                if (this.disable_image_tmp == null)
                {
                    this.disable_image_tmp = ImageCommom.CreateDisabledImage(image);
                }
                g.DrawImage(disable_image_tmp, this.dateBody.image_rect);
            }

            if (this.Enabled && !this.ReadOnly && this.DateOperateMode == DateOperateModes.Editor && this.dateBody.selectElementItem == DateContentSelectedTypes.Image)
            {
                Pen activated_border_pen = new Pen(this.BorderColor, 1) { DashStyle = DashStyle.Dash };
                RectangleF rect = new RectangleF(this.dateBody.image_rect.X, this.dateBody.image_rect.Y, this.dateBody.image_rect.Width - 1, this.dateBody.image_rect.Height - 1);
                g.DrawRectangle(activated_border_pen, rect.X, rect.Y, rect.Width, rect.Height);
                activated_border_pen.Dispose();
            }

            #endregion

            #region 清除按钮

            if (this.ClearButtonVisible)
            {
                Pen clear_btn_fore_pen = new Pen((this.Enabled == true && this.ReadOnly == false) ? this.ClearButtonColor : this.DateTextDisableForeColor, DotsPerInchHelper.DPIScale.XScale >= 1.5 ? 3 : 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float radius = this.dateBody.clear_btn_rect.Width / 2 * 2 / 3;
                PointF center = new PointF(this.dateBody.clear_btn_rect.X + this.dateBody.clear_btn_rect.Width / 2, this.dateBody.clear_btn_rect.Y + this.dateBody.clear_btn_rect.Height / 2);
                PointF[] lineArr = new PointF[] { ControlCommom.CalculatePointForAngle(center, radius, 225), ControlCommom.CalculatePointForAngle(center, radius, 45), ControlCommom.CalculatePointForAngle(center, radius, 135), ControlCommom.CalculatePointForAngle(center, radius, 315) };

                SmoothingMode source_sm = g.SmoothingMode;
                CompositingQuality source_cq = g.CompositingQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.DrawLine(clear_btn_fore_pen, lineArr[0], lineArr[1]);
                g.DrawLine(clear_btn_fore_pen, lineArr[2], lineArr[3]);

                g.SmoothingMode = source_sm;
                g.CompositingQuality = source_cq;

                clear_btn_fore_pen.Dispose();


                if (this.Enabled && !this.ReadOnly && this.DateOperateMode == DateOperateModes.Editor && this.dateBody.selectElementItem == DateContentSelectedTypes.ClearButton)
                {
                    Pen activated_border_pen = new Pen(this.BorderColor, 1) { DashStyle = DashStyle.Dash };
                    g.DrawRectangle(activated_border_pen, this.dateBody.clear_btn_rect.X, this.dateBody.clear_btn_rect.Y, this.dateBody.clear_btn_rect.Width, this.dateBody.clear_btn_rect.Height);
                    activated_border_pen.Dispose();
                }
            }

            #endregion

            g.Clip = source_c_region;
            content_region.Dispose();

            #region 文本

            if (this.DatePicker.DateValue.HasValue)
            {
                Region value_region = new Region(this.dateBody.value_rect);
                g.Clip = value_region;

                //日期高亮背景色
                if (this.Enabled && !(this.dateBody.selectElementItem == DateContentSelectedTypes.None || this.dateBody.selectElementItem == DateContentSelectedTypes.Image || this.dateBody.selectElementItem == DateContentSelectedTypes.ClearButton))
                {
                    RectangleF highlight_rect = RectangleF.Empty;
                    switch (this.dateBody.selectElementItem)
                    {
                        case DateContentSelectedTypes.Year:
                            {
                                highlight_rect = this.dateBody.year_rect;
                                break;
                            }
                        case DateContentSelectedTypes.Month:
                            {
                                highlight_rect = this.dateBody.month_rect;
                                break;
                            }
                        case DateContentSelectedTypes.Day:
                            {
                                highlight_rect = this.dateBody.day_rect;
                                break;
                            }
                        case DateContentSelectedTypes.Hour:
                            {
                                highlight_rect = this.dateBody.hour_rect;
                                break;
                            }
                        case DateContentSelectedTypes.Minute:
                            {
                                highlight_rect = this.dateBody.minute_rect;
                                break;
                            }
                        case DateContentSelectedTypes.Second:
                            {
                                highlight_rect = this.dateBody.second_rect;
                                break;
                            }
                    }
                    SolidBrush highlight_back_sb = new SolidBrush(this.DateTextHighlightBackColor != Color.Empty ? this.DateTextHighlightBackColor : SystemColors.Highlight);
                    g.FillRectangle(highlight_back_sb, highlight_rect);
                    highlight_back_sb.Dispose();
                }


                SolidBrush text_normal_sb = new SolidBrush(this.Enabled ? this.DateTextNormalForeColor : this.DateTextDisableForeColor);
                SolidBrush text_highlight_sb = new SolidBrush(this.Enabled ? (this.DateTextHighlightForeColor != Color.Empty ? this.DateTextHighlightForeColor : SystemColors.HighlightText) : this.DateTextDisableForeColor);
                SolidBrush separator_normal_sb = new SolidBrush(this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor);
                StringFormat text_ft = (StringFormat)StringFormat.GenericTypographic.Clone();
                text_ft.Alignment = StringAlignment.Far;
                text_ft.LineAlignment = StringAlignment.Center;


                if (this.IsContainDateEmbody(DateEmbody.Year))
                {
                    g.DrawString(this.dateBody.year_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Year ? text_highlight_sb : text_normal_sb), this.dateBody.year_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.year_unit_str, this.Font, new Rectangle((int)this.dateBody.year_unit_rect.X, (int)this.dateBody.year_unit_rect.Y, (int)this.dateBody.year_unit_rect.Width, (int)this.dateBody.year_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Month))
                {
                    g.DrawString(this.dateBody.month_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Month ? text_highlight_sb : text_normal_sb), this.dateBody.month_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.month_unit_str, this.Font, new Rectangle((int)this.dateBody.month_unit_rect.X, (int)this.dateBody.month_unit_rect.Y, (int)this.dateBody.month_unit_rect.Width, (int)this.dateBody.month_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                    else
                    {
                        g.DrawString(this.dateBody.yearmonth_str, this.Font, separator_normal_sb, this.dateBody.yearmonth_rect, StringFormat.GenericTypographic);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Day))
                {
                    g.DrawString(this.dateBody.day_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Day ? text_highlight_sb : text_normal_sb), this.dateBody.day_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.day_unit_str, this.Font, new Rectangle((int)this.dateBody.day_unit_rect.X, (int)this.dateBody.day_unit_rect.Y, (int)this.dateBody.day_unit_rect.Width, (int)this.dateBody.day_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                    else
                    {
                        g.DrawString(this.dateBody.monthday_str, this.Font, separator_normal_sb, this.dateBody.monthday_rect, StringFormat.GenericTypographic);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Hour))
                {
                    g.DrawString(this.dateBody.hour_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Hour ? text_highlight_sb : text_normal_sb), this.dateBody.hour_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.hour_unit_str, this.Font, new Rectangle((int)this.dateBody.hour_unit_rect.X, (int)this.dateBody.hour_unit_rect.Y, (int)this.dateBody.hour_unit_rect.Width, (int)this.dateBody.hour_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                    else
                    {
                        g.DrawString(this.dateBody.dayhour_str, this.Font, separator_normal_sb, this.dateBody.dayhour_rect, StringFormat.GenericTypographic);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Minute))
                {
                    g.DrawString(this.dateBody.minute_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Minute ? text_highlight_sb : text_normal_sb), this.dateBody.minute_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.minute_unit_str, this.Font, new Rectangle((int)this.dateBody.minute_unit_rect.X, (int)this.dateBody.minute_unit_rect.Y, (int)this.dateBody.minute_unit_rect.Width, (int)this.dateBody.minute_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                    else
                    {
                        g.DrawString(this.dateBody.hourminute_str, this.Font, separator_normal_sb, this.dateBody.hourminute_rect, StringFormat.GenericTypographic);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Second))
                {
                    g.DrawString(this.dateBody.second_str, this.Font, (this.dateBody.selectElementItem == DateContentSelectedTypes.Second ? text_highlight_sb : text_normal_sb), this.dateBody.second_rect, text_ft);
                    if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
                    {
                        TextRenderer.DrawText(g, this.dateBody.second_unit_str, this.Font, new Rectangle((int)this.dateBody.second_unit_rect.X, (int)this.dateBody.second_unit_rect.Y, (int)this.dateBody.second_unit_rect.Width, (int)this.dateBody.second_unit_rect.Height), this.Enabled ? this.DateTextSymbolColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                    }
                    else
                    {
                        g.DrawString(this.dateBody.minutesecond_str, this.Font, separator_normal_sb, this.dateBody.minutesecond_rect, StringFormat.GenericTypographic);
                    }
                }
                if (this.IsContainDateEmbody(DateEmbody.Week))
                {
                    g.DrawString(this.dateBody.secondweek_str, this.Font, separator_normal_sb, this.dateBody.secondweek_rect, StringFormat.GenericTypographic);
                    TextRenderer.DrawText(g, this.dateBody.week_str, this.Font, new Rectangle((int)this.dateBody.week_rect.X, (int)this.dateBody.week_rect.Y, (int)this.dateBody.week_rect.Width, (int)this.dateBody.week_rect.Height), this.Enabled ? this.DateTextWeekColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.PreserveGraphicsClipping);
                }

                text_normal_sb.Dispose();
                text_highlight_sb.Dispose();
                separator_normal_sb.Dispose();
                text_ft.Dispose();

                g.Clip = source_c_region;
                value_region.Dispose();
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(this.DateNullTipText))
                {
                    SizeF text_size = g.MeasureString(this.DateNullTipText, this.Font, int.MaxValue, StringFormat.GenericTypographic);
                    Region value_region = new Region(this.dateBody.value_rect);
                    g.Clip = value_region;

                    TextRenderer.DrawText(g, this.DateNullTipText, this.Font, new Rectangle((int)this.dateBody.value_rect.X, (int)this.dateBody.value_rect.Y, (int)this.dateBody.value_rect.Width, (int)this.dateBody.value_rect.Height), this.Enabled ? this.DateNullTipTextForeColor : this.DateTextDisableForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | (this.DateTextAlign == DateTextAligns.Left ? TextFormatFlags.Left : TextFormatFlags.Right));

                    g.Clip = source_c_region;
                    value_region.Dispose();
                }
            }
            #endregion

        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
            {
                this.Parent.SelectNextControl(this, true, false, true, true);
                return;
            }

            this.activatedState = true;

            if (this.DateOperateMode == DateOperateModes.Editor)
            {
                this.dateBody.selectElementItem = DateContentSelectedTypes.Image;

            }
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            if (this.datePickerDisplayStatus == true)
            {
                this.tsdd.Close();
            }
            this.VaildUnSelectedValue(this.dateBody.selectElementItem);
            this.dateBody.selectElementItem = DateContentSelectedTypes.None;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;
            if (this.ReadOnly)
                return;

            if (this.activatedState == false)
            {
                this.Select();
                this.activatedState = true;
            }
            if (!this.Focused)
            {
                this.Focus();
            }

            if (e.Button == MouseButtons.Left)
            {
                if (this.DateOperateMode == DateOperateModes.Editor)
                {
                    if (this.dateBody.content_rect.Contains(e.Location))
                    {
                        if (this.dateBody.image_rect.Contains(e.Location))
                        {
                            this.mouseDownAreaType = MouseDownAreaTypes.Image;
                        }
                        else if (this.ClearButtonVisible && this.dateBody.clear_btn_rect.Contains(e.Location))
                        {
                            this.mouseDownAreaType = MouseDownAreaTypes.ClearButton;
                        }
                        else if (this.DatePicker.DateValue.HasValue && this.dateBody.value_rect.Contains(e.Location))
                        {
                            this.mouseDownAreaType = MouseDownAreaTypes.DateText;

                            DateContentSelectedTypes tmp = DateContentSelectedTypes.None;
                            if (this.IsContainDateEmbody(DateEmbody.Year) &&
                                 (
                                  this.dateBody.year_rect.Contains(e.Location) ||
                                  (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.year_unit_rect.Contains(e.Location)) ||
                                  (this.DateTextSymbolFormat != DateSymbolFormats.单位 && this.IsContainDateEmbody(DateEmbody.Month) && this.dateBody.yearmonth_rect.Contains(e.Location))
                                  )
                                )
                            {
                                tmp = DateContentSelectedTypes.Year;
                            }
                            else if (this.IsContainDateEmbody(DateEmbody.Month) &&
                                       (
                                        this.dateBody.month_rect.Contains(e.Location) ||
                                        (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.month_unit_rect.Contains(e.Location)) ||
                                        (this.DateTextSymbolFormat != DateSymbolFormats.单位 && this.IsContainDateEmbody(DateEmbody.Day) && this.dateBody.monthday_rect.Contains(e.Location))
                                        )
                                    )
                            {
                                tmp = DateContentSelectedTypes.Month;
                            }
                            else if (this.IsContainDateEmbody(DateEmbody.Day) &&
                                       (
                                        this.dateBody.day_rect.Contains(e.Location) ||
                                        (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.day_rect.Contains(e.Location))
                                        )
                                     )
                            {
                                tmp = DateContentSelectedTypes.Day;
                            }
                            else if (this.IsContainDateEmbody(DateEmbody.Hour) &&
                                       (
                                         this.dateBody.hour_rect.Contains(e.Location) ||
                                        (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.hour_unit_rect.Contains(e.Location)) ||
                                        (this.DateTextSymbolFormat != DateSymbolFormats.单位 && this.IsContainDateEmbody(DateEmbody.Minute) && this.dateBody.hourminute_rect.Contains(e.Location))
                                        )
                                     )
                            {
                                tmp = DateContentSelectedTypes.Hour;
                            }
                            else if (this.IsContainDateEmbody(DateEmbody.Minute) &&
                                        (
                                         this.dateBody.minute_rect.Contains(e.Location) ||
                                        (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.minute_unit_rect.Contains(e.Location)) ||
                                        (this.DateTextSymbolFormat != DateSymbolFormats.单位 && this.IsContainDateEmbody(DateEmbody.Second) && this.dateBody.minutesecond_rect.Contains(e.Location))
                                        )
                                     )
                            {
                                tmp = DateContentSelectedTypes.Minute;
                            }
                            else if (this.IsContainDateEmbody(DateEmbody.Second) &&
                                        (
                                        this.dateBody.second_rect.Contains(e.Location) ||
                                        (this.DateTextSymbolFormat == DateSymbolFormats.单位 && this.dateBody.second_unit_rect.Contains(e.Location))
                                        )
                                    )
                            {
                                tmp = DateContentSelectedTypes.Second;
                            }

                            if (this.dateBody.selectElementItem != tmp)
                            {
                                if (!(this.dateBody.selectElementItem == DateContentSelectedTypes.None || this.dateBody.selectElementItem == DateContentSelectedTypes.Image))
                                {
                                    this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                }
                                this.dateBody.selectElementItem = tmp;
                                this.Invalidate();
                            }
                        }
                        else
                        {
                            this.mouseDownAreaType = MouseDownAreaTypes.Main;
                        }
                    }
                    else
                    {
                        this.mouseDownAreaType = MouseDownAreaTypes.Main;
                    }

                }
                else
                {
                    if (this.dateBody.content_rect.Contains(e.Location) && this.dateBody.clear_btn_rect.Contains(e.Location))
                    {
                        this.mouseDownAreaType = MouseDownAreaTypes.ClearButton;
                    }
                    else
                    {
                        this.mouseDownAreaType = MouseDownAreaTypes.Main;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.DateOperateMode == DateOperateModes.Editor)
                {
                    if (this.ClearButtonVisible && this.mouseDownAreaType == MouseDownAreaTypes.ClearButton && this.dateBody.content_rect.Contains(e.Location) && this.dateBody.clear_btn_rect.Contains(e.Location))
                    {
                        this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                        this.dateBody.selectElementItem = DateContentSelectedTypes.ClearButton;
                        this.DatePicker.DateValue = null;
                    }
                    else if (this.mouseDownAreaType == MouseDownAreaTypes.Image && this.dateBody.image_rect.Contains(e.Location))
                    {
                        this.ShowDatePicker();
                    }
                }
                else
                {
                    if (this.ClearButtonVisible && this.mouseDownAreaType == MouseDownAreaTypes.ClearButton && this.dateBody.content_rect.Contains(e.Location) && this.dateBody.clear_btn_rect.Contains(e.Location))
                    {
                        this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                        this.dateBody.selectElementItem = DateContentSelectedTypes.ClearButton;
                        this.DatePicker.DateValue = null;
                    }
                    else if (this.mouseDownAreaType == MouseDownAreaTypes.Main && this.ClientRectangle.Contains(e.Location))
                    {
                        this.ShowDatePicker();
                    }
                }

                this.mouseDownAreaType = MouseDownAreaTypes.None;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //取消系统键盘默认行为
            if (this.DesignMode == false && this.activatedState && (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Enter))
            {
                return false;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (this.DesignMode)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if (this.ReadOnly)
            {
                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        if (this.DateOperateMode == DateOperateModes.DropDown)
                        {
                            this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                            this.dateBody.selectElementItem = DateContentSelectedTypes.None;
                            this.Invalidate();
                        }
                        else
                        {
                            if (!this.DatePicker.DateValue.HasValue || this.dateBody.selectElementItem == DateContentSelectedTypes.None)
                            {
                                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                this.dateBody.selectElementItem = DateContentSelectedTypes.Image;
                                this.Invalidate();
                            }
                            else
                            {
                                int index = -1;
                                for (int i = 0; i < this.dateBodyElements.Count; i++)
                                {
                                    if (this.dateBodyElements[i] == this.dateBody.selectElementItem)
                                    {
                                        index = i;
                                        break;
                                    }
                                }

                                if (index > -1)
                                {
                                    index -= 1;
                                    if (index < 0)
                                    {
                                        index = this.dateBodyElements.Count - 1;
                                    }

                                    this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                    this.dateBody.selectElementItem = this.dateBodyElements[index];
                                    this.Invalidate();
                                }
                            }
                        }
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.DateOperateMode == DateOperateModes.DropDown)
                        {
                            this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                            this.dateBody.selectElementItem = DateContentSelectedTypes.None;
                            this.Invalidate();
                        }
                        else
                        {
                            if (!this.DatePicker.DateValue.HasValue || this.dateBody.selectElementItem == DateContentSelectedTypes.None)
                            {
                                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                this.dateBody.selectElementItem = DateContentSelectedTypes.Image;
                                this.Invalidate();
                            }
                            else
                            {
                                int index = -1;
                                for (int i = 0; i < this.dateBodyElements.Count; i++)
                                {
                                    if (this.dateBodyElements[i] == this.dateBody.selectElementItem)
                                    {
                                        index = i;
                                        break;
                                    }
                                }

                                if (index > -1)
                                {
                                    index += 1;
                                    if (index >= this.dateBodyElements.Count)
                                    {
                                        index = 0;
                                    }

                                    this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                    this.dateBody.selectElementItem = this.dateBodyElements[index];
                                    this.Invalidate();
                                }
                            }
                        }
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (this.dateBody.selectElementItem == DateContentSelectedTypes.Year)
                        {
                            //年验证
                            int year = int.Parse(this.dateBody.year_str) + 1;
                            year = Math.Min(year, 9999);
                            year = Math.Min(year, this.DatePicker.MaxValue.Year);
                            year = Math.Max(year, 1);
                            year = Math.Max(year, this.DatePicker.MinValue.Year);
                            //月验证
                            int month = int.Parse(this.dateBody.month_str);
                            int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                            int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                            if (ym_now_int > ym_max_int)
                            {
                                month = (year == this.DatePicker.MaxValue.Year) ? this.DatePicker.MaxValue.Month : 12;
                            }
                            if (ym_now_int < ym_min_int)
                            {
                                month = (year == this.DatePicker.MinValue.Year) ? this.DatePicker.MinValue.Month : 1;
                            }
                            //日验证
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str);
                            day = Math.Min(day, days);
                            ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (ymd_day_int > ymd_max_int)
                            {
                                day = (ym_now_int == ym_max_int) ? this.DatePicker.MaxValue.Day : days;
                            }
                            if (ymd_day_int < ymd_min_int)
                            {
                                day = (ym_now_int == ym_min_int) ? this.DatePicker.MinValue.Day : 1;
                            }

                            this.dateBody.year_str = year.ToString().PadLeft(4, '0');
                            this.dateBody.month_str = month.ToString().PadLeft(2, '0');
                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Month)
                        {
                            //月验证
                            int year = int.Parse(this.dateBody.year_str);
                            int month = int.Parse(this.dateBody.month_str) + 1;
                            if (month > 12)
                            {
                                month = 1;
                            }
                            int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                            int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                            if (ym_now_int > ym_max_int)
                            {
                                month = this.DatePicker.MaxValue.Month;
                            }
                            if (ym_now_int < ym_min_int)
                            {
                                month = this.DatePicker.MinValue.Month;
                            }
                            //日验证
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str);
                            day = Math.Min(day, days);
                            ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (ymd_day_int > ymd_max_int)
                            {
                                day = (ym_now_int == ym_max_int) ? this.DatePicker.MaxValue.Day : days;
                            }
                            if (ymd_day_int < ymd_min_int)
                            {
                                day = (ym_now_int == ym_min_int) ? this.DatePicker.MinValue.Day : 1;
                            }

                            this.dateBody.month_str = month.ToString().PadLeft(2, '0');
                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Day)
                        {
                            //日验证
                            int year = int.Parse(this.dateBody.year_str);
                            int month = int.Parse(this.dateBody.month_str);
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str) + 1;
                            int ymd_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (day > days)
                            {
                                day = 1;
                            }
                            if (ymd_now_int > ymd_max_int)
                            {
                                day = this.DatePicker.MaxValue.Day;
                            }
                            if (ymd_now_int < ymd_min_int)
                            {
                                day = this.DatePicker.MinValue.Day;
                            }

                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Hour)
                        {
                            int hour = int.Parse(this.dateBody.hour_str) + 1;
                            if (hour > 23)
                            {
                                hour = 0;
                            }

                            this.dateBody.hour_str = hour.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Minute)
                        {
                            int minute = int.Parse(this.dateBody.minute_str) + 1;
                            if (minute > 59)
                            {
                                minute = 0;
                            }

                            this.dateBody.minute_str = minute.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Second)
                        {
                            int second = int.Parse(this.dateBody.second_str) + 1;
                            if (second > 59)
                            {
                                second = 0;
                            }

                            this.dateBody.second_str = second.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Down:
                    {
                        if (this.dateBody.selectElementItem == DateContentSelectedTypes.Year)
                        {
                            //年验证
                            int year = int.Parse(this.dateBody.year_str) - 1;
                            year = Math.Min(year, 9999);
                            year = Math.Min(year, this.DatePicker.MaxValue.Year);
                            year = Math.Max(year, 1);
                            year = Math.Max(year, this.DatePicker.MinValue.Year);
                            //月验证
                            int month = int.Parse(this.dateBody.month_str);
                            int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                            int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                            if (ym_now_int > ym_max_int)
                            {
                                month = (year == this.DatePicker.MaxValue.Year) ? this.DatePicker.MaxValue.Month : 12;
                            }
                            if (ym_now_int < ym_min_int)
                            {
                                month = (year == this.DatePicker.MinValue.Year) ? this.DatePicker.MinValue.Month : 1;
                            }
                            //日验证
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str);
                            day = Math.Min(day, days);
                            ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (ymd_day_int > ymd_max_int)
                            {
                                day = (ym_now_int == ym_max_int) ? this.DatePicker.MaxValue.Day : days;
                            }
                            if (ymd_day_int < ymd_min_int)
                            {
                                day = (ym_now_int == ym_min_int) ? this.DatePicker.MinValue.Day : 1;
                            }

                            this.dateBody.year_str = year.ToString().PadLeft(4, '0');
                            this.dateBody.month_str = month.ToString().PadLeft(2, '0');
                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Month)
                        {
                            //月验证
                            int year = int.Parse(this.dateBody.year_str);
                            int month = int.Parse(this.dateBody.month_str) - 1;
                            if (month < 1)
                            {
                                month = 12;
                            }
                            int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                            int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                            if (ym_now_int > ym_max_int)
                            {
                                month = this.DatePicker.MaxValue.Month;
                            }
                            if (ym_now_int < ym_min_int)
                            {
                                month = this.DatePicker.MinValue.Month;
                            }
                            //日验证
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str);
                            day = Math.Min(day, days);
                            ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                            int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (ymd_day_int > ymd_max_int)
                            {
                                day = (ym_now_int == ym_max_int) ? this.DatePicker.MaxValue.Day : days;
                            }
                            if (ymd_day_int < ymd_min_int)
                            {
                                day = (ym_now_int == ym_min_int) ? this.DatePicker.MinValue.Day : 1;
                            }

                            this.dateBody.month_str = month.ToString().PadLeft(2, '0');
                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Day)
                        {
                            //日验证
                            int year = int.Parse(this.dateBody.year_str);
                            int month = int.Parse(this.dateBody.month_str);
                            int days = DateTime.DaysInMonth(year, month);
                            int day = int.Parse(this.dateBody.day_str) - 1;
                            int ymd_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                            int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                            int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                            if (day < 1)
                            {
                                day = days;
                            }
                            if (ymd_now_int > ymd_max_int)
                            {
                                day = this.DatePicker.MaxValue.Day;
                            }
                            if (ymd_now_int < ymd_min_int)
                            {
                                day = this.DatePicker.MinValue.Day;
                            }

                            this.dateBody.day_str = day.ToString().PadLeft(2, '0');
                            this.dateBody.week_str = this.GetWeekNameForDateTime(new DateTime(year, month, day));
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Hour)
                        {
                            int hour = int.Parse(this.dateBody.hour_str) - 1;
                            if (hour < 0)
                            {
                                hour = 23;
                            }

                            this.dateBody.hour_str = hour.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Minute)
                        {
                            int minute = int.Parse(this.dateBody.minute_str) - 1;
                            if (minute < 0)
                            {
                                minute = 59;
                            }

                            this.dateBody.minute_str = minute.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Second)
                        {
                            int second = int.Parse(this.dateBody.second_str) - 1;
                            if (second < 0)
                            {
                                second = 59;
                            }

                            this.dateBody.second_str = second.ToString().PadLeft(2, '0');
                            this.SetTextToDatePickerValue();
                        }
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D0:
                case Keys.NumPad0:
                    {
                        this.UpdateDateBodyValueByKeyboard(0);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D1:
                case Keys.NumPad1:
                    {
                        this.UpdateDateBodyValueByKeyboard(1);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D2:
                case Keys.NumPad2:
                    {
                        this.UpdateDateBodyValueByKeyboard(2);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D3:
                case Keys.NumPad3:
                    {
                        this.UpdateDateBodyValueByKeyboard(3);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D4:
                case Keys.NumPad4:
                    {
                        this.UpdateDateBodyValueByKeyboard(4);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D5:
                case Keys.NumPad5:
                    {
                        this.UpdateDateBodyValueByKeyboard(5);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D6:
                case Keys.NumPad6:
                    {
                        this.UpdateDateBodyValueByKeyboard(6);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D7:
                case Keys.NumPad7:
                    {
                        this.UpdateDateBodyValueByKeyboard(7);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D8:
                case Keys.NumPad8:
                    {
                        this.UpdateDateBodyValueByKeyboard(8);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.D9:
                case Keys.NumPad9:
                    {
                        this.UpdateDateBodyValueByKeyboard(9);
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Enter:
                    {
                        if (this.DateOperateMode == DateOperateModes.DropDown)
                        {

                            if (this.dateBody.selectElementItem == DateContentSelectedTypes.ClearButton)
                            {
                                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                this.DatePicker.DateValue = null;
                            }
                            else
                            {
                                this.ShowDatePicker();
                            }
                        }
                        else
                        {
                            if (this.dateBody.selectElementItem == DateContentSelectedTypes.ClearButton)
                            {
                                this.VaildUnSelectedValue(this.dateBody.selectElementItem);
                                this.DatePicker.DateValue = null;
                            }
                            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Image)
                            {
                                this.ShowDatePicker();
                            }
                        }


                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, this.GetControlAutoHeight(), specified);

            this.InitializeControlElementRectangle();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DateImage != null)
                {
                    this.DateImage = null;
                }
                if (this.disable_image_tmp != null)
                {
                    this.disable_image_tmp.Dispose();
                    this.disable_image_tmp = null;
                }
                if (this.DatePicker != null)
                {
                    this.DatePicker.Dispose();
                    this.DatePicker = null;
                }
                if (this.tsch != null)
                {
                    this.tsch.Dispose();
                    this.tsch = null;
                }
                if (this.tsdd != null)
                {
                    this.tsdd.Dispose();
                    this.tsdd = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 更新时间符号文本
        /// </summary>
        private void UpdateDateSymbol()
        {
            this.dateBody.year_unit_str = "";
            this.dateBody.yearmonth_str = "";
            this.dateBody.month_unit_str = "";
            this.dateBody.monthday_str = "";
            this.dateBody.day_unit_str = "";
            this.dateBody.dayhour_str = "";
            this.dateBody.hour_unit_str = "";
            this.dateBody.hourminute_str = "";
            this.dateBody.minute_unit_str = "";
            this.dateBody.minutesecond_str = "";
            this.dateBody.second_unit_str = "";
            this.dateBody.secondweek_str = "";
            this.dateBody.week_str = "";

            if (this.DateTextSymbolFormat == DateSymbolFormats.横线)
            {
                if (this.IsContainDateEmbody(DateEmbody.Month))
                {
                    this.dateBody.yearmonth_str = "-";
                }
                if (this.IsContainDateEmbody(DateEmbody.Day))
                {
                    this.dateBody.monthday_str = "-";
                }
                if (this.IsContainDateEmbody(DateEmbody.Hour))
                {
                    this.dateBody.dayhour_str = " ";
                }
                if (this.IsContainDateEmbody(DateEmbody.Minute))
                {
                    this.dateBody.hourminute_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Second))
                {
                    this.dateBody.minutesecond_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Week))
                {
                    this.dateBody.secondweek_str = " ";
                    this.dateBody.week_str = this.GetWeekNameForDateTime(this.DatePicker.DateValue);
                }
            }
            else if (this.DateTextSymbolFormat == DateSymbolFormats.斜杠)
            {
                if (this.IsContainDateEmbody(DateEmbody.Month))
                {
                    this.dateBody.yearmonth_str = "/";
                }
                if (this.IsContainDateEmbody(DateEmbody.Day))
                {
                    this.dateBody.monthday_str = "/";
                }
                if (this.IsContainDateEmbody(DateEmbody.Hour))
                {
                    this.dateBody.dayhour_str = " ";
                }
                if (this.IsContainDateEmbody(DateEmbody.Minute))
                {
                    this.dateBody.hourminute_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Second))
                {
                    this.dateBody.minutesecond_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Week))
                {
                    this.dateBody.secondweek_str = " ";
                    this.dateBody.week_str = this.GetWeekNameForDateTime(this.DatePicker.DateValue);
                }
            }
            else if (this.DateTextSymbolFormat == DateSymbolFormats.点)
            {
                if (this.IsContainDateEmbody(DateEmbody.Month))
                {
                    this.dateBody.yearmonth_str = ".";
                }
                if (this.IsContainDateEmbody(DateEmbody.Day))
                {
                    this.dateBody.monthday_str = ".";
                }
                if (this.IsContainDateEmbody(DateEmbody.Hour))
                {
                    this.dateBody.dayhour_str = " ";
                }
                if (this.IsContainDateEmbody(DateEmbody.Minute))
                {
                    this.dateBody.hourminute_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Second))
                {
                    this.dateBody.minutesecond_str = ":";
                }
                if (this.IsContainDateEmbody(DateEmbody.Week))
                {
                    this.dateBody.secondweek_str = " ";
                    this.dateBody.week_str = this.GetWeekNameForDateTime(this.DatePicker.DateValue);
                }

            }
            else if (this.DateTextSymbolFormat == DateSymbolFormats.单位)
            {
                if (this.IsContainDateEmbody(DateEmbody.Year))
                {
                    this.dateBody.year_unit_str = "年";
                }
                if (this.IsContainDateEmbody(DateEmbody.Month))
                {
                    this.dateBody.month_unit_str = "月";
                }
                if (this.IsContainDateEmbody(DateEmbody.Day))
                {
                    this.dateBody.day_unit_str = "日";
                }
                if (this.IsContainDateEmbody(DateEmbody.Hour))
                {
                    this.dateBody.dayhour_str = " ";
                    this.dateBody.hour_unit_str = "时";
                }
                if (this.IsContainDateEmbody(DateEmbody.Minute))
                {
                    this.dateBody.minute_unit_str = "分";
                }
                if (this.IsContainDateEmbody(DateEmbody.Second))
                {
                    this.dateBody.second_unit_str = "秒";
                }
                if (this.IsContainDateEmbody(DateEmbody.Week))
                {
                    this.dateBody.secondweek_str = " ";
                    this.dateBody.week_str = this.GetWeekNameForDateTime(this.DatePicker.DateValue);
                }
            }

            this.CalculationDateBodyElementSize();
        }

        /// <summary>
        /// 计算时间各部分元素的Size（一般由 this.Font、this.DateSymbolFormats、this.DatePicker.DateDisplayType 的更改触发）
        /// </summary>
        private void CalculationDateBodyElementSize()
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.Handle, out g, out hDC);


            this.dateBody.year_size = (!this.IsContainDateEmbody(DateEmbody.Year)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.year_str.Replace(" ", "").PadLeft(4, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.year_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.year_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.yearmonth_size = Size.Ceiling(g.MeasureString(this.dateBody.yearmonth_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.month_size = (!this.IsContainDateEmbody(DateEmbody.Month)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.month_str.Replace(" ", "").PadLeft(2, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.month_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.month_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.monthday_size = Size.Ceiling(g.MeasureString(this.dateBody.monthday_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.day_size = (!this.IsContainDateEmbody(DateEmbody.Day)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.day_str.Replace(" ", "").PadLeft(2, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.day_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.day_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.dayhour_size = Size.Ceiling(g.MeasureString(this.dateBody.dayhour_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.hour_size = (!this.IsContainDateEmbody(DateEmbody.Hour)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.hour_str.Replace(" ", "").PadLeft(2, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.hour_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.hour_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.hourminute_size = Size.Ceiling(g.MeasureString(this.dateBody.hourminute_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.minute_size = (!this.IsContainDateEmbody(DateEmbody.Minute)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.minute_str.Replace(" ", "").PadLeft(2, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.minute_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.minute_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.minutesecond_size = Size.Ceiling(g.MeasureString(this.dateBody.minutesecond_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.second_size = (!this.IsContainDateEmbody(DateEmbody.Second)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.second_str.Replace(" ", "").PadLeft(2, '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.second_unit_size = Size.Ceiling(g.MeasureString(this.dateBody.second_unit_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.secondweek_size = Size.Ceiling(g.MeasureString(this.dateBody.secondweek_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));
            this.dateBody.week_size = (!this.IsContainDateEmbody(DateEmbody.Week)) ? SizeF.Empty : Size.Ceiling(g.MeasureString(this.dateBody.week_str.Replace(' ', '0'), this.Font, int.MaxValue, StringFormat.GenericTypographic));

            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);

            this.InitializeControlElementRectangle();
        }

        /// <summary>
        /// 计算控件各部分元素的rect
        /// </summary>
        private void InitializeControlElementRectangle()
        {
            int scale_contentPadding = (int)(this.DatePadding * DotsPerInchHelper.DPIScale.XScale);
            int scale_image_value_padding = (int)(this.image_value_space * DotsPerInchHelper.DPIScale.XScale);
            int scale_image_width = (int)this.dateBody.year_size.Height;
            int scale_image_height = (int)this.dateBody.year_size.Height;
            int scale_clear_btn_width = this.ClearButtonVisible ? scale_image_width : 0;
            int scale_clear_btn_height = this.ClearButtonVisible ? scale_image_height : 0;

            this.dateBody.content_rect = new RectangleF(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 + scale_contentPadding * 2, this.ClientRectangle.Height - this.BorderThickness * 2 + scale_contentPadding * 2);

            if (this.DateImageAlign == DateImageAligns.Right)
            {
                this.dateBody.image_rect = new Rectangle(this.ClientRectangle.Right - this.BorderThickness - scale_contentPadding - scale_image_width, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_image_height) / 2f), scale_image_width, scale_image_height);
                if (this.ClearButtonVisible == false)
                {
                    this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                }
                else
                {
                    if (this.ClearButtonAlignment == ClearButtonAlignments.Near)
                    {
                        this.dateBody.clear_btn_rect = new Rectangle(this.ClientRectangle.Right - this.BorderThickness - scale_contentPadding - scale_image_width - scale_image_value_padding - scale_clear_btn_width, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_clear_btn_height) / 2f), scale_clear_btn_height, scale_clear_btn_width);
                        this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding - scale_clear_btn_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                    }
                    else
                    {
                        this.dateBody.clear_btn_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_clear_btn_height) / 2f), scale_clear_btn_width, scale_clear_btn_height);
                        this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding + scale_clear_btn_width + scale_image_value_padding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding - scale_clear_btn_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                    }
                }
            }
            else
            {
                this.dateBody.image_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_image_height) / 2f), scale_image_width, scale_image_height);
                if (this.ClearButtonVisible == false)
                {
                    this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding + scale_image_width + scale_image_value_padding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                }
                else
                {
                    if (this.ClearButtonAlignment == ClearButtonAlignments.Near)
                    {
                        this.dateBody.clear_btn_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding + scale_image_width + scale_image_value_padding, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_clear_btn_height) / 2f), scale_clear_btn_width, scale_clear_btn_height);
                        this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding + scale_image_width + scale_image_value_padding + scale_clear_btn_width + scale_image_value_padding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding - scale_clear_btn_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                    }
                    else
                    {
                        this.dateBody.clear_btn_rect = new Rectangle(this.ClientRectangle.Right - this.BorderThickness - scale_clear_btn_width - scale_contentPadding, this.ClientRectangle.Y + (int)((this.ClientRectangle.Height - scale_clear_btn_height) / 2f), scale_clear_btn_height, scale_clear_btn_width);
                        this.dateBody.value_rect = new Rectangle(this.ClientRectangle.X + this.BorderThickness + scale_contentPadding + scale_image_width + scale_image_value_padding, this.ClientRectangle.Y + this.BorderThickness + scale_contentPadding, this.ClientRectangle.Width - this.BorderThickness * 2 - scale_contentPadding * 2 - scale_image_width - scale_image_value_padding - scale_clear_btn_width - scale_image_value_padding, this.ClientRectangle.Height - this.BorderThickness * 2 - scale_contentPadding * 2);
                    }
                }
            }

            if (this.DateTextAlign == DateTextAligns.Left)
            {
                float x = this.dateBody.value_rect.Left;
                this.dateBody.year_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.year_size.Height) / 2f, this.dateBody.year_size.Width, this.dateBody.year_size.Height);
                x = this.dateBody.year_rect.Right;
                this.dateBody.year_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.year_unit_size.Height) / 2f, this.dateBody.year_unit_size.Width, this.dateBody.year_unit_size.Height);
                x = this.dateBody.year_unit_rect.Right;
                this.dateBody.yearmonth_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.yearmonth_size.Height) / 2f, this.dateBody.yearmonth_size.Width, this.dateBody.yearmonth_size.Height);
                x = this.dateBody.yearmonth_rect.Right;
                this.dateBody.month_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.month_size.Height) / 2f, this.dateBody.month_size.Width, this.dateBody.month_size.Height);
                x = this.dateBody.month_rect.Right;
                this.dateBody.month_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.month_unit_size.Height) / 2f, this.dateBody.month_unit_size.Width, this.dateBody.month_unit_size.Height);
                x = this.dateBody.month_unit_rect.Right;
                this.dateBody.monthday_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.monthday_size.Height) / 2f, this.dateBody.monthday_size.Width, this.dateBody.monthday_size.Height);
                x = this.dateBody.monthday_rect.Right;
                this.dateBody.day_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.day_size.Height) / 2f, this.dateBody.day_size.Width, this.dateBody.day_size.Height);
                x = this.dateBody.day_rect.Right;
                this.dateBody.day_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.day_unit_size.Height) / 2f, this.dateBody.day_unit_size.Width, this.dateBody.day_unit_size.Height);
                x = this.dateBody.day_unit_rect.Right;
                this.dateBody.dayhour_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.dayhour_size.Height) / 2f, this.dateBody.dayhour_size.Width, this.dateBody.dayhour_size.Height);
                x = this.dateBody.dayhour_rect.Right;
                this.dateBody.hour_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hour_size.Height) / 2f, this.dateBody.hour_size.Width, this.dateBody.hour_size.Height);
                x = this.dateBody.hour_rect.Right;
                this.dateBody.hour_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hour_unit_size.Height) / 2f, this.dateBody.hour_unit_size.Width, this.dateBody.hour_unit_size.Height);
                x = this.dateBody.hour_unit_rect.Right;
                this.dateBody.hourminute_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hourminute_size.Height) / 2f, this.dateBody.hourminute_size.Width, this.dateBody.hourminute_size.Height);
                x = this.dateBody.hourminute_rect.Right;
                this.dateBody.minute_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minute_size.Height) / 2f, this.dateBody.minute_size.Width, this.dateBody.minute_size.Height);
                x = this.dateBody.minute_rect.Right;
                this.dateBody.minute_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minute_unit_size.Height) / 2f, this.dateBody.minute_unit_size.Width, this.dateBody.minute_unit_size.Height);
                x = this.dateBody.minute_unit_rect.Right;
                this.dateBody.minutesecond_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minutesecond_size.Height) / 2f, this.dateBody.minutesecond_size.Width, this.dateBody.minutesecond_size.Height);
                x = this.dateBody.minutesecond_rect.Right;
                this.dateBody.second_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.second_size.Height) / 2f, this.dateBody.second_size.Width, this.dateBody.second_size.Height);
                x = this.dateBody.second_rect.Right;
                this.dateBody.second_unit_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.second_unit_size.Height) / 2f, this.dateBody.second_unit_size.Width, this.dateBody.second_unit_size.Height);
                x = this.dateBody.second_unit_rect.Right;
                this.dateBody.secondweek_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.secondweek_size.Height) / 2f, this.dateBody.secondweek_size.Width, this.dateBody.secondweek_size.Height);
                x = this.dateBody.secondweek_rect.Right;
                this.dateBody.week_rect = new RectangleF(x, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.week_size.Height) / 2f, this.dateBody.week_size.Width, this.dateBody.week_size.Height);
                x = this.dateBody.week_rect.Right;
            }
            else
            {
                float r = this.dateBody.value_rect.Right;
                this.dateBody.week_rect = new RectangleF(r - this.dateBody.week_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.week_size.Height) / 2f, this.dateBody.week_size.Width, this.dateBody.week_size.Height);
                r = this.dateBody.week_rect.X;
                this.dateBody.secondweek_rect = new RectangleF(r - this.dateBody.secondweek_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.secondweek_size.Height) / 2f, this.dateBody.secondweek_size.Width, this.dateBody.secondweek_size.Height);
                r = this.dateBody.secondweek_rect.X;
                this.dateBody.second_unit_rect = new RectangleF(r - this.dateBody.second_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.second_unit_size.Height) / 2f, this.dateBody.second_unit_size.Width, this.dateBody.second_unit_size.Height);
                r = this.dateBody.second_unit_rect.X;
                this.dateBody.second_rect = new RectangleF(r - this.dateBody.second_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.second_size.Height) / 2f, this.dateBody.second_size.Width, this.dateBody.second_size.Height);
                r = this.dateBody.second_rect.X;
                this.dateBody.minutesecond_rect = new RectangleF(r - this.dateBody.minutesecond_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minutesecond_size.Height) / 2f, this.dateBody.minutesecond_size.Width, this.dateBody.minutesecond_size.Height);
                r = this.dateBody.minutesecond_rect.X;
                this.dateBody.minute_unit_rect = new RectangleF(r - this.dateBody.minute_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minute_unit_size.Height) / 2f, this.dateBody.minute_unit_size.Width, this.dateBody.minute_unit_size.Height);
                r = this.dateBody.minute_unit_rect.X;
                this.dateBody.minute_rect = new RectangleF(r - this.dateBody.minute_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.minute_size.Height) / 2f, this.dateBody.minute_size.Width, this.dateBody.minute_size.Height);
                r = this.dateBody.minute_rect.X;
                this.dateBody.hourminute_rect = new RectangleF(r - this.dateBody.hourminute_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hourminute_size.Height) / 2f, this.dateBody.hourminute_size.Width, this.dateBody.hourminute_size.Height);
                r = this.dateBody.hourminute_rect.X;
                this.dateBody.hour_unit_rect = new RectangleF(r - this.dateBody.hour_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hour_unit_size.Height) / 2f, this.dateBody.hour_unit_size.Width, this.dateBody.hour_unit_size.Height);
                r = this.dateBody.hour_unit_rect.X;
                this.dateBody.hour_rect = new RectangleF(r - this.dateBody.hour_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.hour_size.Height) / 2f, this.dateBody.hour_size.Width, this.dateBody.hour_size.Height);
                r = this.dateBody.hour_rect.X;
                this.dateBody.dayhour_rect = new RectangleF(r - this.dateBody.dayhour_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.dayhour_size.Height) / 2f, this.dateBody.dayhour_size.Width, this.dateBody.dayhour_size.Height);
                r = this.dateBody.dayhour_rect.X;
                this.dateBody.day_unit_rect = new RectangleF(r - this.dateBody.day_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.day_unit_size.Height) / 2f, this.dateBody.day_unit_size.Width, this.dateBody.day_unit_size.Height);
                r = this.dateBody.day_unit_rect.X;
                this.dateBody.day_rect = new RectangleF(r - this.dateBody.day_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.day_size.Height) / 2f, this.dateBody.day_size.Width, this.dateBody.day_size.Height);
                r = this.dateBody.day_rect.X;
                this.dateBody.monthday_rect = new RectangleF(r - this.dateBody.monthday_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.monthday_size.Height) / 2f, this.dateBody.monthday_size.Width, this.dateBody.monthday_size.Height);
                r = this.dateBody.monthday_rect.X;
                this.dateBody.month_unit_rect = new RectangleF(r - this.dateBody.month_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.month_unit_size.Height) / 2f, this.dateBody.month_unit_size.Width, this.dateBody.month_unit_size.Height);
                r = this.dateBody.month_unit_rect.X;
                this.dateBody.month_rect = new RectangleF(r - this.dateBody.month_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.month_size.Height) / 2f, this.dateBody.month_size.Width, this.dateBody.month_size.Height);
                r = this.dateBody.month_rect.X;
                this.dateBody.yearmonth_rect = new RectangleF(r - this.dateBody.yearmonth_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.yearmonth_size.Height) / 2f, this.dateBody.yearmonth_size.Width, this.dateBody.yearmonth_size.Height);
                r = this.dateBody.yearmonth_rect.X;
                this.dateBody.year_unit_rect = new RectangleF(r - this.dateBody.year_unit_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.year_unit_size.Height) / 2f, this.dateBody.year_unit_size.Width, this.dateBody.year_unit_size.Height);
                r = this.dateBody.year_unit_rect.X;
                this.dateBody.year_rect = new RectangleF(r - this.dateBody.year_size.Width, this.dateBody.value_rect.Top + (this.dateBody.value_rect.Height - this.dateBody.year_size.Height) / 2f, this.dateBody.year_size.Width, this.dateBody.year_size.Height);
                r = this.dateBody.year_rect.X;
            }

            this.Invalidate();
        }

        /// <summary>
        /// 更新DatePicker源时间到控件文本上
        /// </summary>
        private void SetDatePickerDateValueToText()
        {
            if (this.DatePicker.DateValue == null)
            {
                this.dateBody.year_str = "";
                this.dateBody.month_str = "";
                this.dateBody.day_str = "";
                this.dateBody.hour_str = "";
                this.dateBody.minute_str = "";
                this.dateBody.second_str = "";
                this.dateBody.week_str = "";
            }
            else
            {
                this.dateBody.year_str = this.DatePicker.DateValue.Value.Year.ToString().PadLeft(4, '0');
                this.dateBody.month_str = this.DatePicker.DateValue.Value.Month.ToString().PadLeft(2, '0');
                this.dateBody.day_str = this.DatePicker.DateValue.Value.Day.ToString().PadLeft(2, '0');
                this.dateBody.hour_str = this.DatePicker.DateValue.Value.Hour.ToString().PadLeft(2, '0');
                this.dateBody.minute_str = this.DatePicker.DateValue.Value.Minute.ToString().PadLeft(2, '0');
                this.dateBody.second_str = this.DatePicker.DateValue.Value.Second.ToString().PadLeft(2, '0');
                if (this.DateTextWeek)
                {
                    this.dateBody.week_str = this.GetWeekNameForDateTime(this.DatePicker.DateValue);
                }
            }
        }

        /// <summary>
        /// 根据dateBody时间值更新日期面板DateValue 值触发值更改事件
        /// </summary>
        private void SetTextToDatePickerValue()
        {
            DateTime tmp = new DateTime(int.Parse(this.dateBody.year_str), int.Parse(this.dateBody.month_str), int.Parse(this.dateBody.day_str), int.Parse(this.dateBody.hour_str), int.Parse(this.dateBody.minute_str), int.Parse(this.dateBody.second_str));
            if (tmp != this.DatePicker.DateValue)
            {
                this.DatePicker.DateValue = tmp;
            }
            else
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 键盘数字键修改dateBody时间文本值
        /// </summary>
        /// <param name="number">键盘数字</param>
        private void UpdateDateBodyValueByKeyboard(int number)
        {
            if (this.dateBody.selectElementItem == DateContentSelectedTypes.Year)
            {
                if (this.dateBody.year_str.Length == 4)
                {
                    this.dateBody.year_str = number.ToString();
                }
                else if (this.dateBody.year_str.Length < 4)
                {
                    int tmp = int.Parse(this.dateBody.year_str + number.ToString());
                    if (1 > tmp || tmp > 9999)
                    {
                        this.dateBody.year_str = this.DatePicker.DateValue.Value.Year.ToString();
                    }
                    else
                    {
                        this.dateBody.year_str = this.dateBody.year_str + number.ToString();
                    }
                }
                if (this.dateBody.year_str.Length != 4)
                {
                    this.Invalidate();
                    return;
                }
                int year = int.Parse(this.dateBody.year_str);
                if (year < this.DatePicker.MinValue.Year)
                {
                    this.dateBody.year_str = this.DatePicker.MinValue.Year.ToString();
                }
                if (year > this.DatePicker.MaxValue.Year)
                {
                    this.dateBody.year_str = this.DatePicker.MaxValue.Year.ToString();
                }

                year = int.Parse(this.dateBody.year_str);
                int month = int.Parse(this.dateBody.month_str);
                int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                if (ym_now_int > ym_max_int)
                {
                    this.dateBody.month_str = DatePicker.MaxValue.Month.ToString();
                }
                if (ym_now_int < ym_min_int)
                {
                    this.dateBody.month_str = DatePicker.MinValue.Month.ToString();
                }


                month = int.Parse(this.dateBody.month_str);
                int days = DateTime.DaysInMonth(year, month);
                int day = int.Parse(this.dateBody.day_str);
                day = Math.Min(day, days);
                int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                if (ymd_day_int > ymd_max_int)
                {
                    day = this.DatePicker.MaxValue.Day;
                }
                if (ymd_day_int < ymd_min_int)
                {
                    day = this.DatePicker.MinValue.Day;
                }
                this.dateBody.day_str = day.ToString();

                this.SetTextToDatePickerValue();
            }
            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Month)
            {
                if (this.dateBody.month_str.Length == 2)
                {
                    this.dateBody.month_str = number.ToString();
                }
                else if (this.dateBody.month_str.Length == 1)
                {
                    int tmp = int.Parse(this.dateBody.month_str + number.ToString());
                    if (1 > tmp || tmp > 12)
                    {
                        this.dateBody.month_str = number.ToString();
                    }
                    else
                    {
                        this.dateBody.month_str = this.dateBody.month_str + number.ToString();
                    }
                }
                if (this.dateBody.month_str.Length != 2)
                {
                    this.Invalidate();
                    return;
                }
                int year = int.Parse(this.dateBody.year_str);
                int month = int.Parse(this.dateBody.month_str);
                int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));

                if (ym_min_int > ym_now_int || ym_now_int > ym_max_int)
                {
                    this.dateBody.month_str = this.DatePicker.DateValue.Value.Month.ToString();
                    this.Invalidate();
                    return;
                }

                month = int.Parse(this.dateBody.month_str);
                int days = DateTime.DaysInMonth(year, month);
                int day = int.Parse(this.dateBody.day_str);
                day = Math.Min(day, days);
                int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                if (ymd_day_int > ymd_max_int)
                {
                    day = this.DatePicker.MaxValue.Day;
                }
                if (ymd_day_int < ymd_min_int)
                {
                    day = this.DatePicker.MinValue.Day;
                }
                this.dateBody.day_str = day.ToString();

                this.SetTextToDatePickerValue();
            }
            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Day)
            {
                int year = int.Parse(this.dateBody.year_str);
                int month = int.Parse(this.dateBody.month_str);
                int days = DateTime.DaysInMonth(year, month);

                if (this.dateBody.day_str.Length == 2)
                {
                    this.dateBody.day_str = number.ToString();
                }
                else if (this.dateBody.day_str.Length == 1)
                {
                    int tmp = int.Parse(this.dateBody.day_str + number.ToString());
                    if (1 > tmp || tmp > days)
                    {
                        this.dateBody.day_str = number.ToString();
                    }
                    else
                    {
                        this.dateBody.day_str = this.dateBody.day_str + number.ToString();
                    }
                }

                if (this.dateBody.day_str.Length != 2)
                {
                    this.Invalidate();
                    return;
                }

                int day = int.Parse(this.dateBody.day_str);
                int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                if (1 > day || day > days || ymd_day_int < ymd_min_int || ymd_day_int > ymd_max_int)
                {
                    this.dateBody.day_str = this.DatePicker.DateValue.Value.Day.ToString();
                    this.Invalidate();
                    return;
                }

                this.SetTextToDatePickerValue();
            }
            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Hour)
            {
                if (this.dateBody.hour_str.Length == 2)
                {
                    this.dateBody.hour_str = number.ToString();
                }
                else if (this.dateBody.hour_str.Length == 1)
                {
                    this.dateBody.hour_str = this.dateBody.hour_str + number.ToString();
                }

                if (this.dateBody.hour_str.Length != 2)
                {
                    this.Invalidate();
                    return;
                }
                int tmp = int.Parse(this.dateBody.hour_str);
                if (0 > tmp || tmp > 23)
                {
                    this.dateBody.hour_str = number.ToString();
                    this.Invalidate();
                    return;
                }

                this.SetTextToDatePickerValue();
            }
            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Minute)
            {
                if (this.dateBody.minute_str.Length == 2)
                {
                    this.dateBody.minute_str = number.ToString();
                }
                else if (this.dateBody.minute_str.Length == 1)
                {
                    this.dateBody.minute_str = this.dateBody.minute_str + number.ToString();
                }

                if (this.dateBody.minute_str.Length != 2)
                {
                    this.Invalidate();
                    return;
                }
                int tmp = int.Parse(this.dateBody.minute_str);
                if (0 > tmp || tmp > 59)
                {
                    this.dateBody.minute_str = number.ToString();
                    this.Invalidate();
                    return;
                }

                this.SetTextToDatePickerValue();
            }
            else if (this.dateBody.selectElementItem == DateContentSelectedTypes.Second)
            {
                if (this.dateBody.second_str.Length == 2)
                {
                    this.dateBody.second_str = number.ToString();
                }
                else if (this.dateBody.second_str.Length == 1)
                {
                    this.dateBody.second_str = this.dateBody.second_str + number.ToString();
                }

                if (this.dateBody.second_str.Length != 2)
                {
                    this.Invalidate();
                    return;
                }
                int tmp = int.Parse(this.dateBody.second_str);
                if (0 > tmp || tmp > 59)
                {
                    this.dateBody.second_str = number.ToString();
                    this.Invalidate();
                    return;
                }

                this.SetTextToDatePickerValue();
            }
        }

        /// <summary>
        /// 文本由选中高亮到取消选中时验证时间
        /// </summary>
        /// <param name="type">时间文本选中高亮部分</param>
        private void VaildUnSelectedValue(DateContentSelectedTypes type)
        {
            switch (type)
            {
                case DateContentSelectedTypes.Year:
                    {
                        if (this.dateBody.year_str.Length == 2)
                        {
                            this.dateBody.year_str = DateTime.Now.Year.ToString().Substring(0, 2) + this.dateBody.year_str;
                        }

                        int year = int.Parse(this.dateBody.year_str);
                        if (this.DatePicker.MinValue.Year > year || year > this.DatePicker.MaxValue.Year)
                        {
                            this.dateBody.year_str = this.DatePicker.DateValue.Value.Year.ToString().PadLeft(4, '0');
                        }

                        year = int.Parse(this.dateBody.year_str);
                        int month = int.Parse(this.dateBody.month_str);
                        int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                        int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                        int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));
                        if (ym_now_int > ym_max_int)
                        {
                            this.dateBody.month_str = DatePicker.MaxValue.Month.ToString().PadLeft(2, '0');
                        }
                        if (ym_now_int < ym_min_int)
                        {
                            this.dateBody.month_str = DatePicker.MinValue.Month.ToString().PadLeft(2, '0');
                        }


                        month = int.Parse(this.dateBody.month_str);
                        int days = DateTime.DaysInMonth(year, month);
                        int day = int.Parse(this.dateBody.day_str);
                        day = Math.Min(day, days);
                        int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                        int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                        int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                        if (ymd_day_int > ymd_max_int)
                        {
                            day = this.DatePicker.MaxValue.Day;
                        }
                        if (ymd_day_int < ymd_min_int)
                        {
                            day = this.DatePicker.MinValue.Day;
                        }
                        this.dateBody.day_str = day.ToString().PadLeft(2, '0');


                        this.SetTextToDatePickerValue();

                        break;
                    }
                case DateContentSelectedTypes.Month:
                    {
                        int year = int.Parse(this.dateBody.year_str);
                        int month = int.Parse(this.dateBody.month_str);
                        int ym_now_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0'));
                        int ym_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMM"));
                        int ym_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMM"));

                        if (ym_now_int > ym_max_int || ym_now_int < ym_min_int)
                        {
                            this.dateBody.month_str = this.DatePicker.DateValue.Value.Month.ToString().PadLeft(2, '0');
                        }

                        month = int.Parse(this.dateBody.month_str);
                        int days = DateTime.DaysInMonth(year, month);
                        int day = int.Parse(this.dateBody.day_str);
                        day = Math.Min(day, days);
                        int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                        int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                        int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                        if (ymd_day_int > ymd_max_int)
                        {
                            day = this.DatePicker.MaxValue.Day;
                        }
                        if (ymd_day_int < ymd_min_int)
                        {
                            day = this.DatePicker.MinValue.Day;
                        }
                        this.dateBody.day_str = day.ToString().PadLeft(2, '0');


                        this.SetTextToDatePickerValue();
                        break;
                    }
                case DateContentSelectedTypes.Day:
                    {
                        int year = int.Parse(this.dateBody.year_str);
                        int month = int.Parse(this.dateBody.month_str);
                        int days = DateTime.DaysInMonth(year, month);
                        int day = int.Parse(this.dateBody.day_str);
                        int ymd_day_int = int.Parse("10" + year.ToString().PadLeft(4, '0') + month.ToString().PadLeft(2, '0') + day.ToString().PadLeft(2, '0'));
                        int ymd_max_int = int.Parse(this.DatePicker.MaxValue.ToString("10yyyyMMdd"));
                        int ymd_min_int = int.Parse(this.DatePicker.MinValue.ToString("10yyyyMMdd"));
                        if (1 > day || day > days || ymd_day_int < ymd_min_int || ymd_day_int > ymd_max_int)
                        {
                            this.dateBody.day_str = this.DatePicker.DateValue.Value.Day.ToString().PadLeft(2, '0');
                        }

                        this.SetTextToDatePickerValue();
                        break;
                    }
                case DateContentSelectedTypes.Hour:
                    {
                        int hour = int.Parse(this.dateBody.hour_str);
                        if (0 > hour || hour > 23)
                        {
                            this.dateBody.hour_str = this.DatePicker.DateValue.Value.Hour.ToString().PadLeft(2, '0');
                        }
                        if (this.dateBody.hour_str.Length == 1)
                        {
                            this.dateBody.hour_str = this.dateBody.hour_str.PadLeft(2, '0');
                        }

                        this.SetTextToDatePickerValue();
                        break;
                    }
                case DateContentSelectedTypes.Minute:
                    {
                        int minute = int.Parse(this.dateBody.minute_str);
                        if (0 > minute || minute > 59)
                        {
                            this.dateBody.minute_str = this.DatePicker.DateValue.Value.Minute.ToString().PadLeft(2, '0');
                        }
                        if (this.dateBody.minute_str.Length == 1)
                        {
                            this.dateBody.minute_str = this.dateBody.minute_str.PadLeft(2, '0');
                        }

                        this.SetTextToDatePickerValue();
                        break;
                    }
                case DateContentSelectedTypes.Second:
                    {
                        int second = int.Parse(this.dateBody.second_str);
                        if (0 > second || second > 59)
                        {
                            this.dateBody.second_str = this.DatePicker.DateValue.Value.Second.ToString().PadLeft(2, '0');
                        }
                        if (this.dateBody.second_str.Length == 1)
                        {
                            this.dateBody.second_str = this.dateBody.second_str.PadLeft(2, '0');
                        }

                        this.SetTextToDatePickerValue();
                        break;
                    }
            }
        }

        /// <summary>
        /// 更新日期控件内容允许选中的元素
        /// </summary>
        private void UpdateDateBodyElements()
        {
            List<DateContentSelectedTypes> tmp_start = new List<DateContentSelectedTypes>();
            List<DateContentSelectedTypes> itemList_tmp = new List<DateContentSelectedTypes>();
            List<DateContentSelectedTypes> tmp_end = new List<DateContentSelectedTypes>();
            if (this.DateImageAlign == DateImageAligns.Left)
            {
                tmp_start.Add(DateContentSelectedTypes.Image);
                if (this.ClearButtonVisible)
                {
                    if (this.ClearButtonAlignment == ClearButtonAlignments.Near)
                    {
                        tmp_start.Add(DateContentSelectedTypes.ClearButton);
                    }
                    else
                    {
                        tmp_end.Add(DateContentSelectedTypes.ClearButton);
                    }
                }
            }
            else
            {
                if (this.ClearButtonVisible)
                {
                    if (this.ClearButtonAlignment == ClearButtonAlignments.Near)
                    {
                        tmp_end.Add(DateContentSelectedTypes.ClearButton);
                        tmp_end.Add(DateContentSelectedTypes.Image);
                    }
                    else
                    {
                        tmp_start.Add(DateContentSelectedTypes.ClearButton);
                        tmp_end.Add(DateContentSelectedTypes.Image);
                    }
                }
                else
                {
                    tmp_end.Add(DateContentSelectedTypes.Image);
                }
            }

            foreach (DateContentSelectedTypes item in tmp_start)
            {
                itemList_tmp.Add(item);
            }
            if (this.IsContainDateEmbody(DateEmbody.Year))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Year);
            }
            if (this.IsContainDateEmbody(DateEmbody.Month))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Month);
            }
            if (this.IsContainDateEmbody(DateEmbody.Day))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Day);
            }
            if (this.IsContainDateEmbody(DateEmbody.Hour))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Hour);
            }
            if (this.IsContainDateEmbody(DateEmbody.Minute))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Minute);
            }
            if (this.IsContainDateEmbody(DateEmbody.Second))
            {
                itemList_tmp.Add(DateContentSelectedTypes.Second);
            }
            foreach (DateContentSelectedTypes item in tmp_end)
            {
                itemList_tmp.Add(item);
            }

            this.dateBodyElements = itemList_tmp;
        }

        /// <summary>
        /// 是否显示是否日期指定部分
        /// </summary>
        /// <param name="dateEmbody">日期指定部分</param>
        /// <returns></returns>
        private bool IsContainDateEmbody(DateEmbody dateEmbody)
        {
            switch (dateEmbody)
            {
                case DateEmbody.Year:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyy || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMM || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Month:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMM || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Day:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Hour:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Minute:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Second:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateEmbody.Week:
                    {
                        return (this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DatePicker.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss) && this.DateTextWeek;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 获取指定日期所属星期文本 
        /// </summary>
        /// <param name="date">指定日期</param>
        /// <returns></returns>
        private string GetWeekNameForDateTime(DateTime? date)
        {
            if (date == null)
            {
                return "";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Monday)
            {
                return "星期一";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Tuesday)
            {
                return "星期二";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Wednesday)
            {
                return "星期三";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Thursday)
            {
                return "星期四";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Friday)
            {
                return "星期五";
            }
            else if (date.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                return "星期六";
            }
            else
            {
                return "星期日";
            }
        }

        /// <summary>
        /// 根据字体计算控件高度
        /// </summary>
        /// <returns></returns>
        private int GetControlAutoHeight()
        {
            int scale_contentPadding = (int)(this.DatePadding * DotsPerInchHelper.DPIScale.XScale);
            int scale_height = (int)(this.Font.Height + this.BorderThickness * 2 + scale_contentPadding * 2);
            return scale_height;
        }

        #region 日期面板

        /// <summary>
        /// 隐藏日期面板弹层事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsdd_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.datePickerDisplayStatus = false;
            this.Invalidate();
            this.Select();
        }

        /// <summary>
        /// 日期面板清除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_BottomBarClearClick(object sender, EventArgs e)
        {
            this.tsdd.Close();
        }

        /// <summary>
        /// 日期面板现在时间事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_BottomBarNowClick(object sender, EventArgs e)
        {
            this.tsdd.Close();
        }

        /// <summary>
        /// 日期面板确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_BottomBarConfirmClick(object sender, EventArgs e)
        {
            this.tsdd.Close();
        }

        /// <summary>
        /// 日期面板时间值更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_DateValueChanged(object sender, EventArgs e)
        {
            if (!this.Enabled || this.ReadOnly)
            {
                this.dateBody.selectElementItem = DateContentSelectedTypes.None;
            }
            else
            {
                if (!this.DatePicker.DateValue.HasValue)
                {
                    if (this.dateBody.selectElementItem != DateContentSelectedTypes.None)
                    {
                        this.dateBody.selectElementItem = DateContentSelectedTypes.Image;
                    }
                    else
                    {
                        this.dateBody.selectElementItem = DateContentSelectedTypes.None;
                    }
                    this.UpdateDateBodyElements();
                }
            }
            this.SetDatePickerDateValueToText();
            this.InitializeControlElementRectangle();
        }

        /// <summary>
        /// 日期面板日期格式更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_DateFormatChanged(object sender, EventArgs e)
        {
            this.SetDatePickerDateValueToText();
            this.dateBody.selectElementItem = DateContentSelectedTypes.None;
            this.UpdateDateBodyElements();
            this.UpdateDateSymbol();
        }

        /// <summary>
        /// 显示日期面板
        /// </summary>
        private void ShowDatePicker()
        {
            if (!this.datePickerDisplayStatus)
            {
                if (this.tsdd == null)
                {
                    this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };
                    this.tsdd.Closed += this.tsdd_Closed;
                }
                if (this.tsch == null)
                {
                    this.tsch = new ToolStripControlHost(this.DatePicker) { Margin = Padding.Empty, Padding = Padding.Empty };
                    this.tsch.Size = this.DatePicker.Size;
                    tsdd.Items.Add(this.tsch);
                }

                Rectangle screen_rect = Screen.FromControl(this).WorkingArea;
                Point screen_control_point = this.PointToScreen(new Point(((this.DateImageAlign == DateImageAligns.Left) ? 0 : (this.ClientRectangle.Right - this.DatePicker.Size.Width)), this.Height + 2));
                if (screen_control_point.Y + this.DatePicker.Size.Height > screen_rect.Bottom)
                {
                    screen_control_point = new Point(screen_control_point.X, screen_control_point.Y - this.Height - 6 - this.DatePicker.Size.Height);
                }
                tsdd.Show(screen_control_point);
                this.DatePicker.InitializeViewForDateValue();
            }
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 存放时间元素信息
        /// </summary>
        internal class DateBody
        {
            /// <summary>
            /// 日期控件内容选中类型索引
            /// </summary>
            public DateContentSelectedTypes selectElementItem = DateContentSelectedTypes.None;

            /// <summary>
            /// 内容Rect
            /// </summary>
            public RectangleF content_rect = Rectangle.Empty;

            /// <summary>
            /// 图片Rect
            /// </summary>
            public RectangleF image_rect = Rectangle.Empty;

            /// <summary>
            /// 清除按钮Rect
            /// </summary>
            public RectangleF clear_btn_rect = RectangleF.Empty;

            /// <summary>
            /// 时间值Rect
            /// </summary>
            public RectangleF value_rect = RectangleF.Empty;



            /// <summary>
            /// 年文本
            /// </summary>
            public string year_str = "    ";
            /// <summary>
            /// 年文本Size
            /// </summary>
            public SizeF year_size = SizeF.Empty;
            /// <summary>
            /// 年文本Rect
            /// </summary>
            public RectangleF year_rect = RectangleF.Empty;


            /// <summary>
            /// 年单位文本
            /// </summary>
            public string year_unit_str = "";
            /// <summary>
            /// 年单位文本Size
            /// </summary>
            public SizeF year_unit_size = SizeF.Empty;
            /// <summary>
            /// 年单位文本Rect
            /// </summary>
            public RectangleF year_unit_rect = RectangleF.Empty;


            /// <summary>
            /// 年月分隔符文本
            /// </summary>
            public string yearmonth_str = "-";
            /// <summary>
            /// 年月分隔符文本Size
            /// </summary>
            public SizeF yearmonth_size = SizeF.Empty;
            /// <summary>
            /// 年月分隔符文本Rect
            /// </summary>
            public RectangleF yearmonth_rect = RectangleF.Empty;



            /// <summary>
            /// 月文本
            /// </summary>
            public string month_str = "  ";
            /// <summary>
            /// 月文本Size
            /// </summary>
            public SizeF month_size = SizeF.Empty;
            /// <summary>
            /// 月文本Rect
            /// </summary>
            public RectangleF month_rect = RectangleF.Empty;


            /// <summary>
            /// 月单位文本
            /// </summary>
            public string month_unit_str = "";
            /// <summary>
            /// 月单位文本Size
            /// </summary>
            public SizeF month_unit_size = SizeF.Empty;
            /// <summary>
            /// 月单位文本Rect
            /// </summary>
            public RectangleF month_unit_rect = RectangleF.Empty;



            /// <summary>
            /// 月日分隔符文本
            /// </summary>
            public string monthday_str = "-";
            /// <summary>
            /// 月日分隔符文本Size
            /// </summary>
            public SizeF monthday_size = SizeF.Empty;
            /// <summary>
            /// 月日分隔符文本Rect
            /// </summary>
            public RectangleF monthday_rect = RectangleF.Empty;



            /// <summary>
            /// 日文本
            /// </summary>
            public string day_str = "  ";
            /// <summary>
            /// 日文本Size
            /// </summary>
            public SizeF day_size = SizeF.Empty;
            /// <summary>
            /// 日文本Rect
            /// </summary>
            public RectangleF day_rect = RectangleF.Empty;



            /// <summary>
            /// 日单位文本
            /// </summary>
            public string day_unit_str = "";
            /// <summary>
            /// 日单位文本Size
            /// </summary>
            public SizeF day_unit_size = SizeF.Empty;
            /// <summary>
            /// 日单位文本Rect
            /// </summary>
            public RectangleF day_unit_rect = RectangleF.Empty;



            /// <summary>
            /// 日时分隔符文本
            /// </summary>
            public string dayhour_str = "";
            /// <summary>
            /// 日时分隔符文本Size
            /// </summary>
            public SizeF dayhour_size = SizeF.Empty;
            /// <summary>
            /// 日时分隔符文本Rect
            /// </summary>
            public RectangleF dayhour_rect = RectangleF.Empty;


            /// <summary>
            /// 时文本
            /// </summary>
            public string hour_str = "  ";
            /// <summary>
            /// 时文本Size
            /// </summary>
            public SizeF hour_size = SizeF.Empty;
            /// <summary>
            /// 时文本Rect
            /// </summary>
            public RectangleF hour_rect = RectangleF.Empty;



            /// <summary>
            /// 时单位文本
            /// </summary>
            public string hour_unit_str = "";
            /// <summary>
            /// 时单位文本Size
            /// </summary>
            public SizeF hour_unit_size = SizeF.Empty;
            /// <summary>
            /// 时单位文本Rect
            /// </summary>
            public RectangleF hour_unit_rect = RectangleF.Empty;



            /// <summary>
            /// 时分分隔符文本
            /// </summary>
            public string hourminute_str = "";
            /// <summary>
            /// 时分分隔符文本Size
            /// </summary>
            public SizeF hourminute_size = SizeF.Empty;
            /// <summary>
            /// 时分分隔符文本Rect
            /// </summary>
            public RectangleF hourminute_rect = RectangleF.Empty;



            /// <summary>
            /// 分文本
            /// </summary>
            public string minute_str = "  ";
            /// <summary>
            /// 分文本Size
            /// </summary>
            public SizeF minute_size = SizeF.Empty;
            /// <summary>
            /// 分文本Rect
            /// </summary>
            public RectangleF minute_rect = RectangleF.Empty;



            /// <summary>
            /// 分单位文本
            /// </summary>
            public string minute_unit_str = "";
            /// <summary>
            /// 分单位文本Size
            /// </summary>
            public SizeF minute_unit_size = SizeF.Empty;
            /// <summary>
            /// 分单位文本Rect
            /// </summary>
            public RectangleF minute_unit_rect = RectangleF.Empty;



            /// <summary>
            /// 分秒分隔符文本
            /// </summary>
            public string minutesecond_str = "";
            /// <summary>
            /// 分秒分隔符文本Size
            /// </summary>
            public SizeF minutesecond_size = SizeF.Empty;
            /// <summary>
            /// 分秒分隔符文本Rect
            /// </summary>
            public RectangleF minutesecond_rect = RectangleF.Empty;


            /// <summary>
            /// 秒文本
            /// </summary>
            public string second_str = "  ";
            /// <summary>
            /// 秒文本Size
            /// </summary>
            public SizeF second_size = SizeF.Empty;
            /// <summary>
            /// 秒文本Rect
            /// </summary>
            public RectangleF second_rect = RectangleF.Empty;



            /// <summary>
            /// 秒单位文本
            /// </summary>
            public string second_unit_str = "";
            /// <summary>
            /// 秒单位文本Size
            /// </summary>
            public SizeF second_unit_size = SizeF.Empty;
            /// <summary>
            /// 秒单位文本Rect
            /// </summary>
            public RectangleF second_unit_rect = RectangleF.Empty;



            /// <summary>
            /// 秒星期分隔符文本
            /// </summary>
            public string secondweek_str = "";
            /// <summary>
            /// 秒星期分隔符文本Size
            /// </summary>
            public SizeF secondweek_size = SizeF.Empty;
            /// <summary>
            /// 秒星期分隔符文本Rect
            /// </summary>
            public RectangleF secondweek_rect = RectangleF.Empty;



            /// <summary>
            /// 星期文本
            /// </summary>
            public string week_str = "";
            /// <summary>
            /// 星期文本Size
            /// </summary>
            public SizeF week_size = SizeF.Empty;
            /// <summary>
            /// 星期文本Rect
            /// </summary>
            public RectangleF week_rect = RectangleF.Empty;


        }

        #endregion

        #region 枚举

        /// <summary>
        /// 日期操作模式
        /// </summary>
        public enum DateOperateModes
        {
            /// <summary>
            /// 可编辑
            /// </summary>
            Editor,
            /// <summary>
            /// 只能日期面板选择
            /// </summary>
            DropDown
        }

        /// <summary>
        /// 日期图片位置
        /// </summary>
        public enum DateImageAligns
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
        /// 清除按钮对齐方式
        /// </summary>
        public enum ClearButtonAlignments
        {
            /// <summary>
            /// 靠近图片
            /// </summary>
            Near,
            /// <summary>
            ///远离图片
            /// </summary>
            Far
        }

        /// <summary>
        /// 日期文本位置
        /// </summary>
        public enum DateTextAligns
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
        /// 当前日期文本显示包含指定部分
        /// </summary>
        internal enum DateEmbody
        {
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 月
            /// </summary>
            Month,
            /// <summary>
            /// 日
            /// </summary>
            Day,
            /// <summary>
            /// 时
            /// </summary>
            Hour,
            /// <summary>
            /// 分
            /// </summary>
            Minute,
            /// <summary>
            /// 秒
            /// </summary>
            Second,
            /// <summary>
            /// 星期
            /// </summary>
            Week
        }

        /// <summary>
        /// 日期控件内容允许选中的元素
        /// </summary>
        internal enum DateContentSelectedTypes
        {
            /// <summary>
            /// 没选中
            /// </summary>
            None,
            /// <summary>
            /// 图标
            /// </summary>
            Image,
            /// <summary>
            /// 清除按钮
            /// </summary>
            ClearButton,
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 月
            /// </summary>
            Month,
            /// <summary>
            /// 日
            /// </summary>
            Day,
            /// <summary>
            /// 时
            /// </summary>
            Hour,
            /// <summary>
            /// 分
            /// </summary>
            Minute,
            /// <summary>
            /// 秒
            /// </summary>
            Second
        }

        /// <summary>
        ///日期符号格式
        /// </summary>
        public enum DateSymbolFormats
        {
            /// <summary>
            ///格式 yyyy-MM-dd HH:mm:ss
            /// </summary>
            横线,
            /// <summary>
            ///格式 yyyy/MM/dd HH:mm:ss
            /// </summary>
            斜杠,
            /// <summary>
            ///格式 yyyy.MM.dd HH:mm:ss
            /// </summary>
            点,
            /// <summary>
            ///格式 yyyy年MM月dd日 HH时mm分ss秒
            /// </summary>
            单位
        }

        /// <summary>
        ///当前鼠标按下的功能区
        /// </summary>
        internal enum MouseDownAreaTypes
        {
            /// <summary>
            /// 没有
            /// </summary>
            None,
            /// <summary>
            /// 整个控件
            /// </summary>
            Main,
            /// <summary>
            /// 图片
            /// </summary>
            Image,
            /// <summary>
            /// 清除按钮
            /// </summary>
            ClearButton,
            /// <summary>
            /// 日期文本
            /// </summary>
            DateText
        }

        #endregion

    }

    /// <summary>
    /// 日期面板美化控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("日期面板美化控件")]
    [DefaultProperty("DateValue")]
    [DefaultEvent("BottomBarConfirmClick")]
    [Designer(typeof(DatePickerExtDesigner))]
    [TypeConverter(typeof(EmptyConverter))]
    public class DatePickerExt : Control
    {
        #region 新增事件

        private event EventHandler bottomBarClearClick;
        /// <summary>
        /// 底部工具栏清除选中单击事件
        /// </summary>
        [Description("底部工具栏清除选中单击事件")]
        public event EventHandler BottomBarClearClick
        {
            add { this.bottomBarClearClick += value; }
            remove { this.bottomBarClearClick -= value; }
        }

        private event EventHandler bottomBarNowClick;
        /// <summary>
        /// 底部工具栏现在单击事件
        /// </summary>
        [Description("底部工具栏现在单击事件")]
        public event EventHandler BottomBarNowClick
        {
            add { this.bottomBarNowClick += value; }
            remove { this.bottomBarNowClick -= value; }
        }

        private event EventHandler bottomBarConfirmClick;
        /// <summary>
        /// 底部工具栏确认单击事件
        /// </summary>
        [Description("底部工具栏确认单击事件")]
        public event EventHandler BottomBarConfirmClick
        {
            add { this.bottomBarConfirmClick += value; }
            remove { this.bottomBarConfirmClick -= value; }
        }

        private event EventHandler dateValueChanged;
        /// <summary>
        /// 日期值更改事件
        /// </summary>
        [Description("日期值更改事件")]
        public event EventHandler DateValueChanged
        {
            add { this.dateValueChanged += value; }
            remove { this.dateValueChanged -= value; }
        }

        private event EventHandler dateFormatChanged;
        /// <summary>
        /// 日期显示格式更改事件
        /// </summary>
        [Description("日期显示格式更改事件")]
        public event EventHandler DateFormatChanged
        {
            add { this.dateFormatChanged += value; }
            remove { this.dateFormatChanged -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DockChanged
        {
            add { base.DockChanged += value; }
            remove { base.DockChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackColorChanged
        {
            add { base.BackColorChanged += value; }
            remove { base.BackColorChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DoubleClick
        {
            add { base.DoubleClick += value; }
            remove { base.DoubleClick -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event MouseEventHandler MouseDoubleClick
        {
            add { base.MouseDoubleClick += value; }
            remove { base.MouseDoubleClick -= value; }
        }
        #endregion

        #region 新增属性

        private DateFormats dateFormat = DateFormats.yyyyMMddHHmmss;
        /// <summary>
        /// 日期显示格式（自动截取到显示部分）
        /// </summary>
        [DefaultValue(DateFormats.yyyyMMddHHmmss)]
        [Description("日期显示格式（自动截取到显示部分）")]
        public DateFormats DateFormat
        {
            get { return this.dateFormat; }
            set
            {
                if (this.dateFormat == value)
                    return;

                this.dateFormat = value;

                if (this.DateFormat == DateFormats.yyyy)
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.Year_Year);
                }
                else if (this.DateFormat == DateFormats.yyyyMM)
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonth_Month);
                }
                else
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
                }

                this.Size = this.GetControlAutoSize();
                this.InitializeViewForDateValue();

                this.OnDateFormatChanged(new EventArgs());
            }
        }

        private bool dateReadOnly = false;
        /// <summary>
        /// 日期是否只读
        /// </summary>
        [DefaultValue(false)]
        [Description("日期是否只读")]
        public bool DateReadOnly
        {
            get { return this.dateReadOnly; }
            set
            {
                if (this.dateReadOnly == value)
                    return;

                this.dateReadOnly = value;
                this.InitializeViewForDateValue();
            }
        }

        private DateTime minValue = minDate;
        /// <summary>
        /// 最小日期(只比较日期部分)
        /// </summary>
        [DefaultValue(typeof(DateTime), "1753,1,1")]
        [Description("最小日期(只比较日期部分)")]
        public DateTime MinValue
        {
            get { return this.minValue; }
            set
            {
                if (this.minValue.Date == value.Date)
                    return;

                if (value.Date > this.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("“MinDate”应小于等于 'MaxValue' ");
                }
                if (this.dateValue.HasValue && value.Date > this.dateValue.Value.Date)
                {
                    throw new ArgumentOutOfRangeException("“MinDate”应小于等于 'DateValue'");
                }

                this.minValue = value.Date;
                this.UpdateYearMonthDayText();
                this.UpdateBottomText();
                this.Invalidate();
            }
        }

        private DateTime maxValue = maxDate;
        /// <summary>
        /// 最大日期(只比较日期部分)
        /// </summary>
        [DefaultValue(typeof(DateTime), "9998,12,31")]
        [Description("最大日期(只比较日期部分)")]
        public DateTime MaxValue
        {
            get { return this.maxValue; }
            set
            {
                if (this.maxValue.Date == value.Date)
                    return;

                if (value.Date < this.MinValue)
                {
                    throw new ArgumentOutOfRangeException("“MaxValue”应大于等于 'MinDate' ");
                }
                if (this.dateValue.HasValue && value.Date < this.dateValue.Value.Date)
                {
                    throw new ArgumentOutOfRangeException("“MaxDate”应大于等于 'DateValue'");
                }

                this.maxValue = value.Date;
                this.UpdateYearMonthDayText();
                this.UpdateBottomText();
                this.Invalidate();
            }
        }

        private DateTime? dateValue = null;
        /// <summary>
        /// 日期 (获取时自动根据 DateFormat 属性对日期时间进行截取)
        /// </summary>
        [DefaultValue(null)]
        [Description("日期 (获取时自动根据 DateFormat 属性对日期时间进行截取)")]
        public DateTime? DateValue
        {
            get
            {
                if (this.dateValue.HasValue == false)
                {
                    return this.dateValue;
                }
                else if (this.DateFormat == DateFormats.yyyy)
                {
                    return new DateTime(this.dateValue.Value.Year, 1, 1, 0, 0, 0);
                }
                else if (this.DateFormat == DateFormats.yyyyMM)
                {
                    return new DateTime(this.dateValue.Value.Year, this.dateValue.Value.Month, 1, 0, 0, 0);
                }
                else if (this.DateFormat == DateFormats.yyyyMMdd)
                {
                    return this.dateValue.Value.Date;
                }
                else if (this.DateFormat == DateFormats.yyyyMMddHH)
                {
                    return new DateTime(this.dateValue.Value.Year, this.dateValue.Value.Month, this.dateValue.Value.Day, this.dateValue.Value.Hour, 0, 0);
                }
                else if (this.DateFormat == DateFormats.yyyyMMddHHmm)
                {
                    return new DateTime(this.dateValue.Value.Year, this.dateValue.Value.Month, this.dateValue.Value.Day, this.dateValue.Value.Hour, this.dateValue.Value.Minute, 0);
                }
                else
                {
                    return this.dateValue.Value;
                }
            }
            set
            {
                if (this.dateValue == value)
                    return;

                if (value.HasValue && (this.MinValue > value.Value.Date || value.Value.Date > this.MaxValue))
                {
                    throw new ArgumentOutOfRangeException("“DateValue”应介于 'MinDate' 和 'MaxDate' 之间");
                }

                this.dateValue = value;

                this.InitializeViewForDateValue();

                this.OnDateValueChanged(new EventArgs());
            }
        }

        private Color activateColor = Color.Gray;
        /// <summary>
        /// 控件激活的虚线框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("控件激活的虚线框颜色")]
        public Color ActivateColor
        {
            get { return this.activateColor; }
            set
            {
                if (this.activateColor == value)
                    return;

                this.activateColor = value;
                this.Invalidate();
            }
        }

        private Color crossLineColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 分割线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("分割线颜色")]
        public Color CrossLineColor
        {
            get { return this.crossLineColor; }
            set
            {
                if (this.crossLineColor == value)
                    return;

                this.crossLineColor = value;
                this.Invalidate();
            }
        }


        private Color topBarBackColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 顶部工具栏背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("顶部工具栏背景颜色")]
        public Color TopBarBackColor
        {
            get { return this.topBarBackColor; }
            set
            {
                if (this.topBarBackColor == value)
                    return;

                this.topBarBackColor = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeNormalColor = Color.White;
        /// <summary>
        /// 顶部工具栏按钮字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("顶部工具栏按钮字体颜色(正常)")]
        public Color TopBarBtnForeNormalColor
        {
            get { return this.topBarBtnForeNormalColor; }
            set
            {
                if (this.topBarBtnForeNormalColor == value)
                    return;

                this.topBarBtnForeNormalColor = value;
                this.Invalidate();
            }
        }

        private Color topBarBtnForeEnterColor = Color.Gold;
        /// <summary>
        /// 顶部工具栏按钮字体颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "Gold")]
        [Description("顶部工具栏按钮字体颜色(鼠标进入)")]
        public Color TopBarBtnForeEnterColor
        {
            get { return this.topBarBtnForeEnterColor; }
            set
            {
                if (this.topBarBtnForeEnterColor == value)
                    return;

                this.topBarBtnForeEnterColor = value;
                this.Invalidate();
            }
        }


        private Color mainBarBackColor = Color.White;
        /// <summary>
        /// 主面板背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("主面板背景颜色")]
        public Color MainBarBackColor
        {
            get { return this.mainBarBackColor; }
            set
            {
                if (this.mainBarBackColor == value)
                    return;

                this.mainBarBackColor = value;
                this.Invalidate();
            }
        }

        private Color dateBackSelectedColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 日期面板日期背景颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("日期面板日期背景颜色(选中)")]
        public Color DateBackSelectedColor
        {
            get { return this.dateBackSelectedColor; }
            set
            {
                if (this.dateBackSelectedColor == value)
                    return;

                this.dateBackSelectedColor = value;
                this.Invalidate();
            }
        }

        private Color dateForeTitleColor = Color.DimGray;
        /// <summary>
        /// 日期面板日期标题字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("日期面板日期标题字体颜色")]
        public Color DateForeTitleColor
        {
            get { return this.dateForeTitleColor; }
            set
            {
                if (this.dateForeTitleColor == value)
                    return;

                this.dateForeTitleColor = value;
                this.Invalidate();
            }
        }

        private Color dateForeDisabledColor = Color.Silver;
        /// <summary>
        /// 日期面板日期字体颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "Silver")]
        [Description("日期面板日期字体颜色(禁用)")]
        public Color DateForeDisabledColor
        {
            get { return this.dateForeDisabledColor; }
            set
            {
                if (this.dateForeDisabledColor == value)
                    return;

                this.dateForeDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color dateForeUnCurrentColor = Color.SkyBlue;
        /// <summary>
        /// 日期面板非本月日期字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "SkyBlue")]
        [Description("日期面板非本月日期字体颜色(正常)")]
        public Color DateForeUnCurrentColor
        {
            get { return this.dateForeUnCurrentColor; }
            set
            {
                if (this.dateForeUnCurrentColor == value)
                    return;

                this.dateForeUnCurrentColor = value;
                this.Invalidate();
            }
        }

        private Color dateForeNormalColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 日期面板正常日期字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("日期面板正常日期字体颜色(正常)")]
        public Color DateForeNormalColor
        {
            get { return this.dateForeNormalColor; }
            set
            {
                if (this.dateForeNormalColor == value)
                    return;

                this.dateForeNormalColor = value;
                this.Invalidate();
            }
        }

        private Color dateBackEnterColor = Color.Gainsboro;
        /// <summary>
        /// 日期面板日期背景颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "Gainsboro")]
        [Description("日期面板日期背景颜色(鼠标进入)")]
        public Color DateBackEnterColor
        {
            get { return this.dateBackEnterColor; }
            set
            {
                if (this.dateBackEnterColor == value)
                    return;

                this.dateBackEnterColor = value;
                this.Invalidate();
            }
        }

        private Color dateForeSelectedColor = Color.White;
        /// <summary>
        /// 日期面板日期字体颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("日期面板日期字体颜色(选中)")]
        public Color DateForeSelectedColor
        {
            get { return this.dateForeSelectedColor; }
            set
            {
                if (this.dateForeSelectedColor == value)
                    return;

                this.dateForeSelectedColor = value;
                this.Invalidate();
            }
        }


        private Color scrollBackColor = Color.Silver;
        /// <summary>
        /// 滚动条背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Silver")]
        [Description("滚动条背景颜色")]
        public Color ScrollBackColor
        {
            get { return this.scrollBackColor; }
            set
            {
                if (this.scrollBackColor == value)
                    return;

                this.scrollBackColor = value;
                this.Invalidate();

            }
        }

        private Color scrollSlideColor = Color.Gray;
        /// <summary>
        /// 滚动条滑块颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("滚动条滑块颜色")]
        public Color ScrollSlideColor
        {
            get { return this.scrollSlideColor; }
            set
            {
                if (this.scrollSlideColor == value)
                    return;

                this.scrollSlideColor = value;
                this.Invalidate();
            }
        }


        private bool bottomBarMinMaxTipVisible = true;
        /// <summary>
        /// 是否显示最小值最大值限制提示信息
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示最小值最大值限制提示信息")]
        public bool BottomBarMinMaxTipVisible
        {
            get { return this.bottomBarMinMaxTipVisible; }
            set
            {
                if (this.bottomBarMinMaxTipVisible == value)
                    return;

                this.bottomBarMinMaxTipVisible = value;
                this.UpdateBottomText();
                this.Invalidate();
            }
        }

        private Color bottomBarMinMaxTipColor = Color.SandyBrown;
        /// <summary>
        /// 日期最小最大限制提示字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "SandyBrown")]
        [Description("日期最小最大限制提示字体颜色")]
        public Color BottomBarMinMaxTipColor
        {
            get { return this.bottomBarMinMaxTipColor; }
            set
            {
                if (this.bottomBarMinMaxTipColor == value)
                    return;

                this.bottomBarMinMaxTipColor = value;
                this.Invalidate();
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
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        /// <summary>
        /// 控件默认大小
        /// </summary>
        [DefaultValue(typeof(Size), "226, 298")]
        [Description("控件默认大小")]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(226, 298); ;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        private bool activatedState = false;
        /// <summary>
        /// 激活选项索引:
        /// 年面板.激活选项索引(年功能下：-2至14)(年月功能下： -3至14)(年月日功能下：-6至14)
        /// 月面板.激活选项索引(年月功能下： -3至14)(年月日功能下：-6至14)
        /// 日面板.激活选项索引(年月日功能下：-6至44)
        /// </summary>
        private int activatedIndex = 0;
        /// <summary>
        /// 激活选项区域
        /// </summary>
        private Rectangle? activatedrect = null;
        /// <summary>
        /// 激活选项是否显示
        /// </summary>
        private bool activatedVisible = false;

        /// <summary>
        /// 最小日期
        /// </summary>
        private static readonly DateTime minDate = new DateTime(1753, 1, 1).Date;
        /// <summary>
        /// 最大日期
        /// </summary>
        private static readonly DateTime maxDate = new DateTime(9998, 12, 31).Date;

        /// <summary>
        /// 顶部工具栏高度
        /// </summary>
        private readonly int topbar_rect_height = 36;
        /// <summary>
        /// 主体面板宽度
        /// </summary>
        private readonly int mainbar_rect_width = 226;
        /// <summary>
        /// 主体面板高度
        /// </summary>
        private readonly int mainbar_rect_height = 226;
        /// <summary>
        /// 底部工具栏高度
        /// </summary>
        private readonly int bottombar_rect_height = 36;
        /// <summary>
        /// 年选项宽度
        /// </summary>
        private readonly int year_item_rect_width = 66;
        /// <summary>
        /// 年选项高度
        /// </summary>
        private readonly int year_item_rect_height = 36;
        /// <summary>
        /// 月选项宽度
        /// </summary>
        private readonly int month_item_rect_width = 66;
        /// <summary>
        /// 月选项高度
        /// </summary>
        private readonly int month_item_rect_height = 36;
        /// <summary>
        /// 日选项宽度
        /// </summary>
        private readonly int day_item_rect_width = 30;
        /// <summary>
        /// 日选项高度
        /// </summary>
        private readonly int day_item_rect_height = 30;
        /// <summary>
        /// 日期面板和时间面板间隔
        /// </summary>
        private int date_time_rect_space = 2;
        /// <summary>
        /// 时间选项宽度
        /// </summary>
        private int time_item_rect_width = 50;
        /// <summary>
        /// 时间选项高度
        /// </summary>
        private int time_item_rect_height = 26;
        /// <summary>
        /// 时间滚动条厚度
        /// </summary>
        private int time_scroll_thickness = 9;

        /// <summary>
        /// 存放日期元素信息对象
        /// </summary>
        private DateBodyClass dateBody;
        /// <summary>
        /// 当前显示的日期面板
        /// </summary>
        private DateFormatsViews currentDateFormatsViews = DateFormatsViews.YearMonthDay_Day;
        /// <summary>
        /// 鼠标按下对象
        /// </summary>
        private object mousedownobject = null;
        /// <summary>
        /// 鼠标按下坐标
        /// </summary>
        private Point mousedownpoint = Point.Empty;

        /// <summary>
        /// 鼠标进入对象
        /// </summary>
        private object mouseenterobject = null;

        #endregion

        public DatePickerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);

            this.dateBody = new DateBodyClass();

            this.InitializeLayoutRectangle();
            this.InitializeViewForDateValue();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            StringFormat text_center_sf = (StringFormat)StringFormat.GenericTypographic.Clone();
            text_center_sf.Alignment = StringAlignment.Center;
            text_center_sf.LineAlignment = StringAlignment.Center;

            Pen common_crossline_pen = new Pen(this.CrossLineColor, 1);
            SolidBrush topbar_back_sb = new SolidBrush(this.TopBarBackColor);
            Pen topbar_btn_fore_normal_pen = new Pen(this.TopBarBtnForeNormalColor, (DotsPerInchHelper.DPIScale.XScale) >= 1.5 ? 2 : 1);
            Pen topbar_btn_fore_enter_pen = new Pen(this.TopBarBtnForeEnterColor, (DotsPerInchHelper.DPIScale.XScale) >= 1.5 ? 2 : 1);
            SolidBrush topbar_btn_fore_normal_sb = new SolidBrush(this.TopBarBtnForeNormalColor);
            SolidBrush topbar_btn_fore_enter_sb = new SolidBrush(this.TopBarBtnForeEnterColor);
            Font text_font = new Font("微软雅黑", 10);
            SolidBrush mainbar_back_sb = new SolidBrush(this.MainBarBackColor);
            SolidBrush item_fore_disabled_sb = new SolidBrush(this.DateForeDisabledColor);
            SolidBrush item_fore_uncurrent_sb = new SolidBrush(this.DateForeUnCurrentColor);
            SolidBrush item_fore_normal_sb = new SolidBrush(this.DateForeNormalColor);
            SolidBrush item_fore_selected_sb = new SolidBrush(this.DateForeSelectedColor);
            SolidBrush item_back_selected_sb = new SolidBrush(this.DateBackSelectedColor);
            SolidBrush item_back_enter_sb = new SolidBrush(this.DateBackEnterColor);
            SolidBrush daytitle_fore_sb = new SolidBrush(this.DateForeTitleColor);


            #region 顶部工具栏
            g.FillRectangle(topbar_back_sb, this.dateBody.TopBar_Rect);
            g.DrawLine(common_crossline_pen, this.dateBody.TopBar_Rect.X, this.dateBody.TopBar_Rect.Bottom - 1, this.dateBody.TopBar_Rect.Right, this.dateBody.TopBar_Rect.Bottom - 1);

            if (this.currentDateFormatsViews == DateFormatsViews.Year_Year)
            {
                g.DrawString(this.dateBody.TopBar_yearscope_btn.Text, text_font, topbar_btn_fore_normal_sb, this.dateBody.TopBar_yearscope_btn.Rect, text_center_sf);
            }

            if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year || this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month)
            {
                g.DrawString(this.dateBody.TopBar_monthyear_btn.Text, text_font, (this.mouseenterobject == this.dateBody.TopBar_monthyear_btn) ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb, this.dateBody.TopBar_monthyear_btn.Rect, text_center_sf);
            }

            if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day)
            {
                g.DrawString(this.dateBody.TopBar_month_btn.Text, text_font, (this.mouseenterobject == this.dateBody.TopBar_month_btn) ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb, this.dateBody.TopBar_month_btn.Rect, text_center_sf);
                g.DrawString(this.dateBody.TopBar_year_btn.Text, text_font, (this.mouseenterobject == this.dateBody.TopBar_year_btn) ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb, this.dateBody.TopBar_year_btn.Rect, text_center_sf);
            }

            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            {
                //上一年
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_prev_year_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_prev_year_btn.LineLeftPointArr);
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_prev_year_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_prev_year_btn.LineRightPointArr);
                //下一年
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_next_year_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_next_year_btn.LineLeftPointArr);
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_next_year_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_next_year_btn.LineRightPointArr);
            }

            if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day)
            {
                //上一月
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_prev_month_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_prev_month_btn.LineLeftPointArr);
                //下一月
                g.DrawLines((this.mouseenterobject == this.dateBody.TopBar_next_month_btn) ? topbar_btn_fore_enter_pen : topbar_btn_fore_normal_pen, this.dateBody.TopBar_next_month_btn.LineRightPointArr);
            }

            g.SmoothingMode = sm;

            string time_text = "";
            if (this.DateFormat == DateFormats.yyyyMMddHH)
            {
                time_text = string.Format("{0}", this.dateBody.selected_hour.ToString().PadLeft(2, '0'));
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmm)
            {
                time_text = string.Format("{0}:{1}", this.dateBody.selected_hour.ToString().PadLeft(2, '0'), this.dateBody.selected_minute.ToString().PadLeft(2, '0'));
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmmss)
            {
                time_text = string.Format("{0}:{1}:{2}", this.dateBody.selected_hour.ToString().PadLeft(2, '0'), this.dateBody.selected_minute.ToString().PadLeft(2, '0'), this.dateBody.selected_second.ToString().PadLeft(2, '0'));
            }
            g.DrawString(time_text, text_font, topbar_btn_fore_normal_sb, this.dateBody.TopBar_Time_Rect, text_center_sf);
            #endregion

            //主面板
            g.FillRectangle(mainbar_back_sb, this.dateBody.MainBar_Rect);

            //年面板
            if (this.IsContainEmbodyForCurrentView(DateElement.Year))
            {
                int select_date = (this.dateBody.selected_year == -1) ? -1 : this.dateBody.selected_year;
                for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
                {
                    string text = String.Format("{0}年", this.dateBody.YearMain_itemArr[i].Value.Substring(2, 4));
                    int tmp = int.Parse(this.dateBody.YearMain_itemArr[i].Value.Substring(2, 4));
                    //限制范围之外
                    if (this.MinValue.Year > tmp || tmp > this.MaxValue.Year)
                    {
                        g.DrawString(text, text_font, item_fore_disabled_sb, this.dateBody.YearMain_itemArr[i].Rect, text_center_sf);
                    }
                    //已选中
                    else if (tmp == select_date)
                    {
                        g.FillRectangle(item_back_selected_sb, this.dateBody.YearMain_itemArr[i].Rect);
                        g.DrawString(text, text_font, item_fore_selected_sb, this.dateBody.YearMain_itemArr[i].Rect, text_center_sf);
                    }
                    else
                    {
                        //鼠标进入
                        if (this.mouseenterobject == this.dateBody.YearMain_itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, this.dateBody.YearMain_itemArr[i].Rect);
                        }
                        g.DrawString(text, text_font, item_fore_normal_sb, this.dateBody.YearMain_itemArr[i].Rect, text_center_sf);
                    }
                }
            }
            //月面板
            if (this.IsContainEmbodyForCurrentView(DateElement.Month))
            {
                int ym_min_month = int.Parse(this.MinValue.ToString("10yyyyMM"));
                int ym_max_month = int.Parse(this.MaxValue.ToString("10yyyyMM"));
                int select_date = (this.dateBody.selected_month == -1) ? -1 : int.Parse(("10" + this.dateBody.selected_year.ToString().PadLeft(4, '0') + this.dateBody.selected_month.ToString().PadLeft(2, '0')));
                for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
                {
                    string text = String.Format("{0}月", this.dateBody.MonthMain_itemArr[i].Value.Substring(6, 2));
                    int ym_now_month = int.Parse(this.dateBody.MonthMain_itemArr[i].Value);
                    //限制范围之外
                    if (ym_min_month > ym_now_month || ym_now_month > ym_max_month)
                    {
                        g.DrawString(text, text_font, item_fore_disabled_sb, this.dateBody.MonthMain_itemArr[i].Rect, text_center_sf);
                    }
                    //已选中
                    else if (ym_now_month == select_date)
                    {
                        g.FillRectangle(item_back_selected_sb, this.dateBody.MonthMain_itemArr[i].Rect);
                        g.DrawString(text, text_font, item_fore_selected_sb, this.dateBody.MonthMain_itemArr[i].Rect, text_center_sf);
                    }
                    else
                    {
                        //鼠标进入
                        if (this.mouseenterobject == this.dateBody.MonthMain_itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, this.dateBody.MonthMain_itemArr[i].Rect);
                        }
                        g.DrawString(text, text_font, item_fore_normal_sb, this.dateBody.MonthMain_itemArr[i].Rect, text_center_sf);
                    }
                }
            }
            //日面板
            if (this.IsContainEmbodyForCurrentView(DateElement.Day))
            {
                for (int i = 0; i < this.dateBody.DayMain_titleArr.Length; i++)
                {
                    g.DrawString(this.dateBody.DayMain_titleArr[i].Text, text_font, daytitle_fore_sb, this.dateBody.DayMain_titleArr[i].Rect, text_center_sf);
                }

                int select_date = (this.dateBody.selected_day == -1) ? -1 : int.Parse("10" + this.dateBody.selected_year.ToString().PadLeft(4, '0') + this.dateBody.selected_month.ToString().PadLeft(2, '0') + this.dateBody.selected_day.ToString().PadLeft(2, '0'));
                for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
                {
                    string text = int.Parse(this.dateBody.DayMain_itemArr[i].Value.Substring(8, 2)).ToString();
                    int tmp = int.Parse(this.dateBody.DayMain_itemArr[i].Value);
                    if (this.dateBody.DayMain_itemArr[i].DayItemType == DayItemTypes.Disabled)
                    {
                        g.DrawString(text, text_font, item_fore_disabled_sb, this.dateBody.DayMain_itemArr[i].Rect, text_center_sf);
                    }
                    else if (tmp == select_date)
                    {
                        g.FillRectangle(item_back_selected_sb, this.dateBody.DayMain_itemArr[i].Rect);
                        g.DrawString(text, text_font, item_fore_selected_sb, this.dateBody.DayMain_itemArr[i].Rect, text_center_sf);
                    }
                    else if (this.dateBody.DayMain_itemArr[i].DayItemType == DayItemTypes.Normal)
                    {
                        if (this.mouseenterobject == this.dateBody.DayMain_itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, this.dateBody.DayMain_itemArr[i].Rect);
                        }
                        g.DrawString(text, text_font, item_fore_normal_sb, this.dateBody.DayMain_itemArr[i].Rect, text_center_sf);
                    }
                    else if (this.dateBody.DayMain_itemArr[i].DayItemType == DayItemTypes.UnCurrent)
                    {
                        if (this.mouseenterobject == this.dateBody.DayMain_itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, this.dateBody.DayMain_itemArr[i].Rect);
                        }
                        g.DrawString(text, text_font, item_fore_uncurrent_sb, this.dateBody.DayMain_itemArr[i].Rect, text_center_sf);
                    }
                }

            }
            //时间面板
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour))
            {
                //分割线
                ColorBlend splitter__cb = new ColorBlend();
                splitter__cb.Colors = new Color[] { Color.Transparent, this.CrossLineColor, this.CrossLineColor, Color.Transparent };
                splitter__cb.Positions = new float[] { 0.0f, 0.23f, 0.70f, 1.0f };
                LinearGradientBrush splitter_lgb = new LinearGradientBrush(new PointF(this.dateBody.TimeMain_Rect.X - this.date_time_rect_space, this.dateBody.TimeMain_Rect.Y), new PointF(this.dateBody.TimeMain_Rect.X - this.date_time_rect_space, this.dateBody.TimeMain_Rect.Bottom), Color.Transparent, Color.Transparent);
                splitter_lgb.InterpolationColors = splitter__cb;
                Pen splitter_pen = new Pen(splitter_lgb, this.date_time_rect_space);

                g.DrawLine(splitter_pen, new PointF(this.dateBody.TimeMain_Rect.X - this.date_time_rect_space, this.dateBody.TimeMain_Rect.Y), new PointF(this.dateBody.TimeMain_Rect.X - this.date_time_rect_space, this.dateBody.TimeMain_Rect.Bottom));

                splitter_pen.Dispose();
                splitter_lgb.Dispose();


                Region source_region = g.Clip;
                Region time_region = new Region(this.dateBody.TimeMain_Rect);
                g.Clip = time_region;

                int scale_timeScrollThickness = (int)(this.time_scroll_thickness * DotsPerInchHelper.DPIScale.YScale);
                Pen scroll_back_pen = new Pen(this.ScrollBackColor, scale_timeScrollThickness);
                Pen scroll_slide_pen = new Pen(this.ScrollSlideColor, scale_timeScrollThickness);
                //时
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_HourArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_HourArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Bottom + y < this.dateBody.TimeMain_Rect.Y || this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Y + y > this.dateBody.TimeMain_Rect.Bottom)
                        {
                            continue;
                        }
                        RectangleF item_rect = new RectangleF(this.dateBody.TimeMain_HourArea.itemArr[i].Rect.X, this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Y + y, this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Width, this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Height);
                        if (this.dateBody.TimeMain_HourArea.itemArr[i].Value == this.dateBody.selected_hour)
                        {
                            g.FillRectangle(item_back_selected_sb, item_rect);
                        }
                        else if (this.mouseenterobject == this.dateBody.TimeMain_HourArea.itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, item_rect);
                        }
                        g.DrawString(this.dateBody.TimeMain_HourArea.itemArr[i].Value.ToString().PadLeft(2, '0'), text_font, (this.dateBody.selected_hour == this.dateBody.TimeMain_HourArea.itemArr[i].Value) ? item_fore_selected_sb : item_fore_normal_sb, item_rect, text_center_sf);

                    }
                    this.DrawTimeScroll(g, this.dateBody.TimeMain_HourArea.Scroll, scroll_back_pen, scroll_slide_pen);
                }
                //分
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_MinuteArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_MinuteArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Bottom + y < this.dateBody.TimeMain_Rect.Y || this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Y + y > this.dateBody.TimeMain_Rect.Bottom)
                        {
                            continue;
                        }
                        RectangleF item_rect = new RectangleF(this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.X, this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Y + y, this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Width, this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Height);
                        if (this.dateBody.TimeMain_MinuteArea.itemArr[i].Value == this.dateBody.selected_minute)
                        {
                            g.FillRectangle(item_back_selected_sb, item_rect);
                        }
                        else if (this.mouseenterobject == this.dateBody.TimeMain_MinuteArea.itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, item_rect);
                        }

                        g.DrawString(this.dateBody.TimeMain_MinuteArea.itemArr[i].Value.ToString().PadLeft(2, '0'), text_font, (this.dateBody.selected_minute == this.dateBody.TimeMain_MinuteArea.itemArr[i].Value) ? item_fore_selected_sb : item_fore_normal_sb, item_rect, text_center_sf);

                    }
                    this.DrawTimeScroll(g, this.dateBody.TimeMain_MinuteArea.Scroll, scroll_back_pen, scroll_slide_pen);
                }
                //秒
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_SecondArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_SecondArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Bottom + y < this.dateBody.TimeMain_Rect.Y || this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Y + y > this.dateBody.TimeMain_Rect.Bottom)
                        {
                            continue;
                        }

                        RectangleF item_rect = new RectangleF(this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.X, this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Y + y, this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Width, this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Height);
                        if (this.dateBody.TimeMain_SecondArea.itemArr[i].Value == this.dateBody.selected_second)
                        {
                            g.FillRectangle(item_back_selected_sb, item_rect);
                        }
                        else if (this.mouseenterobject == this.dateBody.TimeMain_SecondArea.itemArr[i])
                        {
                            g.FillRectangle(item_back_enter_sb, item_rect);
                        }
                        g.DrawString(this.dateBody.TimeMain_SecondArea.itemArr[i].Value.ToString().PadLeft(2, '0'), text_font, (this.dateBody.selected_second == this.dateBody.TimeMain_SecondArea.itemArr[i].Value) ? item_fore_selected_sb : item_fore_normal_sb, item_rect, text_center_sf);

                    }
                    this.DrawTimeScroll(g, this.dateBody.TimeMain_SecondArea.Scroll, scroll_back_pen, scroll_slide_pen);
                }

                scroll_back_pen.Dispose();
                scroll_slide_pen.Dispose();

                g.Clip = source_region;
            }


            //底部工具栏边框
            g.FillRectangle(mainbar_back_sb, this.dateBody.BottomBar_Rect);
            g.DrawLine(common_crossline_pen, this.dateBody.BottomBar_Rect.X, this.dateBody.BottomBar_Rect.Y, this.dateBody.BottomBar_Rect.Right, this.dateBody.BottomBar_Rect.Y);

            if (this.BottomBarMinMaxTipVisible)
            {
                Pen bottombar_tip_line_pen = new Pen(this.CrossLineColor, (DotsPerInchHelper.DPIScale.XScale >= 1.5) ? 3 : 1);
                g.DrawLines(bottombar_tip_line_pen, this.dateBody.Bottombar_minmaxborder_lab.LinePointArr);
                bottombar_tip_line_pen.Dispose();

                SolidBrush bottombar_tip_sb = new SolidBrush(this.BottomBarMinMaxTipColor);
                g.DrawString(this.dateBody.Bottombar_mindate_lab.Text, text_font, bottombar_tip_sb, this.dateBody.Bottombar_mindate_lab.Rect.Location, StringFormat.GenericTypographic);
                g.DrawString(this.dateBody.Bottombar_maxdate_lab.Text, text_font, bottombar_tip_sb, this.dateBody.Bottombar_maxdate_lab.Rect.Location, StringFormat.GenericTypographic);
                bottombar_tip_sb.Dispose();
            }

            SmoothingMode sm2 = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(topbar_back_sb, ControlCommom.TransformCircular(this.dateBody.Bottombar_confirm_btn.Rect, 0, 4, 4, 0));
            g.FillRectangle(topbar_back_sb, this.dateBody.Bottombar_now_btn.Rect);
            g.FillPath(topbar_back_sb, ControlCommom.TransformCircular(this.dateBody.Bottombar_clear_btn.Rect, 4, 0, 0, 4));
            g.SmoothingMode = sm2;

            g.DrawString(this.dateBody.Bottombar_confirm_btn.Text, text_font, (this.mouseenterobject == this.dateBody.Bottombar_confirm_btn ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb), this.dateBody.Bottombar_confirm_btn.Rect, text_center_sf);
            g.DrawString(this.dateBody.Bottombar_now_btn.Text, text_font, (this.mouseenterobject == this.dateBody.Bottombar_now_btn ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb), this.dateBody.Bottombar_now_btn.Rect, text_center_sf);
            g.DrawString(this.dateBody.Bottombar_clear_btn.Text, text_font, (this.mouseenterobject == this.dateBody.Bottombar_clear_btn ? topbar_btn_fore_enter_sb : topbar_btn_fore_normal_sb), this.dateBody.Bottombar_clear_btn.Rect, text_center_sf);

            // 控件激活的虚线
            if (this.activatedState && this.activatedrect.HasValue && this.activatedVisible)
            {
                Pen activate_border_pen = new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash };
                g.DrawRectangle(activate_border_pen, this.activatedrect.Value.X, this.activatedrect.Value.Y, this.activatedrect.Value.Width - 1, this.activatedrect.Value.Height - 1);
                activate_border_pen.Dispose();
            }


            text_center_sf.Dispose();
            common_crossline_pen.Dispose();
            topbar_back_sb.Dispose();
            topbar_btn_fore_normal_pen.Dispose();
            topbar_btn_fore_enter_pen.Dispose();
            topbar_btn_fore_normal_sb.Dispose();
            topbar_btn_fore_enter_sb.Dispose();
            text_font.Dispose();
            mainbar_back_sb.Dispose();
            item_fore_disabled_sb.Dispose();
            item_fore_uncurrent_sb.Dispose();
            item_fore_normal_sb.Dispose();
            item_fore_selected_sb.Dispose();
            item_back_selected_sb.Dispose();
            item_back_enter_sb.Dispose();
            daytitle_fore_sb.Dispose();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
            {
                this.Parent.SelectNextControl(this, true, false, true, true);
                return;
            }

            this.SetCurrentDateFormatsViews(this.currentDateFormatsViews);
            this.activatedState = true;
            this.activatedVisible = true;
            this.mousedownobject = null;
            this.mousedownpoint = Point.Empty;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            this.activatedState = false;
            this.mousedownobject = null;
            this.mousedownpoint = Point.Empty;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.mousedownobject = null;
            this.mousedownpoint = Point.Empty;
            this.mouseenterobject = null;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;
            if (this.DateReadOnly)
                return;

            if (this.activatedState == false)
            {
                this.Select();
                this.activatedState = true;
            }
            if (!this.Focused)
            {
                this.Focus();
            }
            this.activatedVisible = false;

            if (e.Button == MouseButtons.Left)
            {
                // 上一年按钮
                if (this.dateBody.TopBar_prev_year_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_prev_year_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 上一月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_prev_month_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_prev_month_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                //年月按钮
                if (this.DateFormat == DateFormats.yyyyMM && this.dateBody.TopBar_monthyear_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_monthyear_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_month_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_month_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 年按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Month) && this.dateBody.TopBar_year_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_year_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 下一月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_next_month_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_next_month_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 下一年按钮
                if (this.dateBody.TopBar_next_year_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TopBar_next_year_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }

                // 年选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Year) && this.dateBody.YearMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.YearMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            this.mousedownobject = this.dateBody.YearMain_itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                // 月选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Month) && this.dateBody.MonthMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.MonthMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            this.mousedownobject = this.dateBody.MonthMain_itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                // 日选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Day) && this.dateBody.DayMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.DayMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            this.mousedownobject = this.dateBody.DayMain_itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                // 时选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_HourArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_HourArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.mousedownobject = this.dateBody.TimeMain_HourArea.itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //时滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TimeMain_HourArea.Scroll;
                    this.mousedownpoint = e.Location;
                    goto result;
                }
                //分选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_MinuteArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_MinuteArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.mousedownobject = this.dateBody.TimeMain_MinuteArea.itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //分滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TimeMain_MinuteArea.Scroll;
                    this.mousedownpoint = e.Location;
                    goto result;
                }
                //秒选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_SecondArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_SecondArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.mousedownobject = this.dateBody.TimeMain_SecondArea.itemArr[i];
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //秒滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.TimeMain_SecondArea.Scroll;
                    this.mousedownpoint = e.Location;
                    goto result;
                }

                // 清除按钮
                if (this.dateBody.Bottombar_clear_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.Bottombar_clear_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 现在按钮
                else if (this.dateBody.Bottombar_now_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.Bottombar_now_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                // 确认按钮
                else if (this.dateBody.Bottombar_confirm_btn.Rect.Contains(e.Location))
                {
                    this.mousedownobject = this.dateBody.Bottombar_confirm_btn;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
            }

        result:
            {

            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;
            if (this.DateReadOnly)
                return;

            if (e.Button == MouseButtons.Left)
            {
                // 上一年按钮
                if (this.dateBody.TopBar_prev_year_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_prev_year_btn)
                    {
                        this.TopBarPrevYearClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 上一月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_prev_month_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_prev_month_btn)
                    {
                        this.TopBarPrevMonthClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                //年月按钮
                if (this.DateFormat == DateFormats.yyyyMM && this.dateBody.TopBar_monthyear_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_monthyear_btn)
                    {
                        this.TopBarYearMonthClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_month_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_month_btn)
                    {
                        this.TopBarMonthClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 年按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Month) && this.dateBody.TopBar_year_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_year_btn)
                    {
                        this.TopBarYearClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 下一月按钮
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_next_month_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_next_month_btn)
                    {
                        this.TopBarNextMonthClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 下一年按钮
                if (this.dateBody.TopBar_next_year_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.TopBar_next_year_btn)
                    {
                        this.TopBarNextYearClick();
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }

                // 年选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Year) && this.dateBody.YearMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.YearMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.mousedownobject == this.dateBody.YearMain_itemArr[i] && this.dateBody.YearMain_itemArr[i].DayItemType == DayItemTypes.Normal)
                            {
                                this.YearMainItemClick(this.dateBody.YearMain_itemArr[i]);
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            this.activatedVisible = false;
                            goto result;
                        }
                    }
                }
                // 月选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Month) && this.dateBody.MonthMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.MonthMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.mousedownobject == this.dateBody.MonthMain_itemArr[i] && this.dateBody.MonthMain_itemArr[i].DayItemType == DayItemTypes.Normal)
                            {
                                this.MonthMainItemClick(this.dateBody.MonthMain_itemArr[i]);
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            this.activatedVisible = false;
                            goto result;
                        }
                    }
                }
                // 日选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Day) && this.dateBody.DayMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.DayMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.mousedownobject == this.dateBody.DayMain_itemArr[i] && (this.dateBody.DayMain_itemArr[i].DayItemType == DayItemTypes.Normal || this.dateBody.DayMain_itemArr[i].DayItemType == DayItemTypes.UnCurrent))
                            {
                                this.DayMainItemClick(this.dateBody.DayMain_itemArr[i]);
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            this.activatedVisible = false;
                            goto result;
                        }
                    }
                }
                // 时选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_HourArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_HourArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            if (this.mousedownobject == this.dateBody.TimeMain_HourArea.itemArr[i])
                            {
                                this.dateBody.selected_hour = this.dateBody.TimeMain_HourArea.itemArr[i].Value;
                                this.Invalidate();
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //时滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                //分选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_MinuteArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_MinuteArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            if (this.mousedownobject == this.dateBody.TimeMain_MinuteArea.itemArr[i])
                            {
                                this.dateBody.selected_minute = this.dateBody.TimeMain_MinuteArea.itemArr[i].Value;
                                this.Invalidate();
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //分滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }
                //秒选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_SecondArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_SecondArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            if (this.mousedownobject == this.dateBody.TimeMain_SecondArea.itemArr[i])
                            {
                                this.dateBody.selected_second = this.dateBody.TimeMain_SecondArea.itemArr[i].Value;
                                this.Invalidate();
                            }
                            this.mousedownobject = null;
                            this.mousedownpoint = Point.Empty;
                            goto result;
                        }
                    }
                }
                //秒滚动条
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Slide_Rect.Contains(e.Location))
                {
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    goto result;
                }

                // 清除按钮
                if (this.dateBody.Bottombar_clear_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.Bottombar_clear_btn)
                    {
                        this.OnBottomBarClearClick(new EventArgs());
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 现在按钮
                else if (this.dateBody.Bottombar_now_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.Bottombar_now_btn)
                    {
                        this.OnBottomBarNowClick(new EventArgs());
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }
                // 确认按钮
                else if (this.dateBody.Bottombar_confirm_btn.Rect.Contains(e.Location))
                {
                    if (this.mousedownobject == this.dateBody.Bottombar_confirm_btn)
                    {
                        this.OnBottomBarConfirmClick(new EventArgs());
                    }
                    this.mousedownobject = null;
                    this.mousedownpoint = Point.Empty;
                    this.activatedVisible = false;
                    goto result;
                }

                this.mousedownobject = null;
                this.mousedownpoint = Point.Empty;
            }

        result:
            {

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;
            if (this.DateReadOnly)
                return;

            // 时滚动条滚动
            if (this.mousedownobject == this.dateBody.TimeMain_HourArea.Scroll)
            {
                int offset = (int)((e.Location.Y - this.mousedownpoint.Y));
                if (this.dateBody.TimeMain_HourArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.mousedownpoint = e.Location;
                    this.Invalidate();
                    return;
                }
            }
            // 分滚动条滚动
            else if (this.mousedownobject == this.dateBody.TimeMain_MinuteArea.Scroll)
            {
                int offset = (int)((e.Location.Y - this.mousedownpoint.Y));
                if (this.dateBody.TimeMain_MinuteArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.mousedownpoint = e.Location;
                    this.Invalidate();
                    return;
                }
            }
            // 秒滚动条滚动
            else if (this.mousedownobject == this.dateBody.TimeMain_SecondArea.Scroll)
            {
                int offset = (int)((e.Location.Y - this.mousedownpoint.Y));
                if (this.dateBody.TimeMain_SecondArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.mousedownpoint = e.Location;
                    this.Invalidate();
                    return;
                }
            }
            //鼠标进入元素
            else
            {
                object mouseenterobject_tmp = null;

                // 顶部工具栏
                if (this.dateBody.TopBar_Date_Rect.Contains(e.Location))
                {
                    // 上一年按钮
                    if (this.dateBody.TopBar_prev_year_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_prev_year_btn;
                        goto result;
                    }
                    // 上一月按钮
                    if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_prev_month_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_prev_month_btn;
                        goto result;
                    }
                    // 月按钮
                    if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_month_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_month_btn;
                        goto result;
                    }
                    // 年按钮
                    if (this.IsContainEmbodyForCurrentFormat(DateElement.Month) && this.dateBody.TopBar_year_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_year_btn;
                        goto result;
                    }
                    // 下一月按钮
                    if (this.IsContainEmbodyForCurrentFormat(DateElement.Day) && this.dateBody.TopBar_next_month_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_next_month_btn;
                        goto result;
                    }
                    // 下一年按钮
                    if (this.dateBody.TopBar_next_year_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.TopBar_next_year_btn;
                        goto result;
                    }

                    goto result;
                }
                // 年选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Year) && this.dateBody.YearMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.YearMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            mouseenterobject_tmp = this.dateBody.YearMain_itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                // 月选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Month) && this.dateBody.MonthMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.MonthMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            mouseenterobject_tmp = this.dateBody.MonthMain_itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                // 日选项
                if (this.IsContainEmbodyForCurrentView(DateElement.Day) && this.dateBody.DayMain_Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
                    {
                        if (this.dateBody.DayMain_itemArr[i].Rect.Contains(e.Location))
                        {
                            mouseenterobject_tmp = this.dateBody.DayMain_itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                // 时选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_HourArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_HourArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_HourArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            mouseenterobject_tmp = this.dateBody.TimeMain_HourArea.itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                //时滚动条背景
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && this.dateBody.TimeMain_HourArea.Scroll.Scroll_Back_Rect.Contains(e.Location))
                {
                    mouseenterobject_tmp = null;
                    goto result;
                }
                //分选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_MinuteArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_MinuteArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            mouseenterobject_tmp = this.dateBody.TimeMain_MinuteArea.itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                //分滚动条背景
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Back_Rect.Contains(e.Location))
                {
                    mouseenterobject_tmp = null;
                    goto result;
                }
                //秒选项
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Rect.Contains(e.Location))
                {
                    int y = this.GetTimeItemsDisplayY(this.dateBody.TimeMain_SecondArea.Scroll);
                    for (int i = 0; i < this.dateBody.TimeMain_SecondArea.itemArr.Length; i++)
                    {
                        if (this.dateBody.TimeMain_SecondArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            mouseenterobject_tmp = this.dateBody.TimeMain_SecondArea.itemArr[i];
                            goto result;
                        }
                    }

                    goto result;
                }
                //秒滚动条背景
                if (this.IsContainEmbodyForCurrentFormat(DateElement.Second) && this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Back_Rect.Contains(e.Location))
                {
                    mouseenterobject_tmp = null;
                    goto result;
                }
                //底部工具栏
                if (this.dateBody.BottomBar_Rect.Contains(e.Location))
                {
                    // 清除按钮
                    if (this.dateBody.Bottombar_clear_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.Bottombar_clear_btn;
                        goto result;
                    }
                    // 现在按钮
                    if (this.dateBody.Bottombar_now_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.Bottombar_now_btn;
                        goto result;
                    }
                    // 确认按钮
                    if (this.dateBody.Bottombar_confirm_btn.Rect.Contains(e.Location))
                    {
                        mouseenterobject_tmp = this.dateBody.Bottombar_confirm_btn;
                        goto result;
                    }

                    goto result;
                }

            result:
                {
                    if (this.mouseenterobject != mouseenterobject_tmp)
                    {
                        this.mouseenterobject = mouseenterobject_tmp;
                        this.Invalidate();
                    }
                }
            }

        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;
            if (this.DateReadOnly)
                return;

            if (this.mousedownobject != null)
                return;

            // 时区域滚动
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour) && (this.dateBody.TimeMain_HourArea.Rect.Contains(e.Location) || this.dateBody.TimeMain_HourArea.Scroll.Scroll_Back_Rect.Contains(e.Location)))
            {
                int offset = e.Delta > 1 ? -3 : 3;
                if (this.dateBody.TimeMain_HourArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.Invalidate();
                }
                goto result;
            }
            // 分区域滚动
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && (this.dateBody.TimeMain_MinuteArea.Rect.Contains(e.Location) || this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Back_Rect.Contains(e.Location)))
            {
                int offset = e.Delta > 1 ? -2 : 2;
                if (this.dateBody.TimeMain_MinuteArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.Invalidate();
                }
                goto result;
            }
            // 秒区域滚动
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute) && (this.dateBody.TimeMain_SecondArea.Rect.Contains(e.Location) || this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Back_Rect.Contains(e.Location)))
            {
                int offset = e.Delta > 1 ? -2 : 2;
                if (this.dateBody.TimeMain_SecondArea.Scroll.IsResetScrollByOffset(offset))
                {
                    this.Invalidate();
                }
                goto result;
            }

        result:
            {

            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.activatedState)
            {
                switch (keyData)
                {
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Down:
                        {
                            this.ActivateIndexByKey(keyData);
                            return false;
                        }
                    case Keys.Enter:
                        {
                            this.ActivateIndexClick();
                            return false;
                        }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            Size size = this.GetControlAutoSize();
            base.SetBoundsCore(x, y, size.Width, size.Height, specified);
            this.InitializeLayoutRectangle();
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarClearClick(EventArgs e)
        {
            this.dateBody.selected_year = -1;
            this.dateBody.selected_month = -1;
            this.dateBody.selected_day = -1;
            this.dateBody.selected_hour = 0;
            this.dateBody.selected_minute = 0;
            this.dateBody.selected_second = 0;
            this.DateValue = null;

            if (this.bottomBarClearClick != null)
            {
                this.bottomBarClearClick(this, e);
            }

            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 现在
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarNowClick(EventArgs e)
        {
            DateTime now = DateTime.Now;

            if (this.DateFormat == DateFormats.yyyy)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.selected_year = now.Year;
                this.DateValue = new DateTime(this.dateBody.selected_year, 1, 1, 0, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMM)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.selected_year = now.Year;
                this.dateBody.selected_month = now.Month;
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, 1, 0, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMdd)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.current_display_month = now.Month;
                this.dateBody.selected_year = now.Year;
                this.dateBody.selected_month = now.Month;
                this.dateBody.selected_day = now.Day;
                this.dateBody.selected_hour = 0;
                this.dateBody.selected_minute = 0;
                this.dateBody.selected_second = 0;
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, 0, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHH)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.current_display_month = now.Month;
                this.dateBody.selected_year = now.Year;
                this.dateBody.selected_month = now.Month;
                this.dateBody.selected_day = now.Day;
                this.dateBody.selected_hour = now.Hour;
                this.dateBody.selected_minute = 0;
                this.dateBody.selected_second = 0;
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmm)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.current_display_month = now.Month;
                this.dateBody.selected_year = now.Year;
                this.dateBody.selected_month = now.Month;
                this.dateBody.selected_day = now.Day;
                this.dateBody.selected_hour = now.Hour;
                this.dateBody.selected_minute = now.Minute;
                this.dateBody.selected_second = 0;
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, this.dateBody.selected_minute, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmmss)
            {
                this.dateBody.current_display_year = now.Year;
                this.dateBody.current_display_month = now.Month;
                this.dateBody.selected_year = now.Year;
                this.dateBody.selected_month = now.Month;
                this.dateBody.selected_day = now.Day;
                this.dateBody.selected_hour = now.Hour;
                this.dateBody.selected_minute = now.Minute;
                this.dateBody.selected_second = now.Second;
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, this.dateBody.selected_minute, this.dateBody.selected_second);
            }

            if (this.bottomBarNowClick != null)
            {
                this.bottomBarNowClick(this, e);
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.UpdateBottomText();
            this.Invalidate();
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarConfirmClick(EventArgs e)
        {
            if (this.DateFormat == DateFormats.yyyy)
            {
                if (this.dateBody.selected_year == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, 1, 1, 0, 0, 0);
            }
            if (this.DateFormat == DateFormats.yyyyMM)
            {
                if (this.dateBody.selected_month == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, 1, 0, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMdd)
            {
                if (this.dateBody.selected_day == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, 0, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHH)
            {
                if (this.dateBody.selected_day == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, 0, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmm)
            {
                if (this.dateBody.selected_day == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, this.dateBody.selected_minute, 0);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmmss)
            {
                if (this.dateBody.selected_day == -1)
                {
                    return;
                }
                this.DateValue = new DateTime(this.dateBody.selected_year, this.dateBody.selected_month, this.dateBody.selected_day, this.dateBody.selected_hour, this.dateBody.selected_minute, this.dateBody.selected_second);
            }

            if (this.bottomBarConfirmClick != null)
            {
                this.bottomBarConfirmClick(this, e);
            }
        }

        /// <summary>
        /// 日期值更改
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDateValueChanged(EventArgs e)
        {
            if (this.dateValueChanged != null)
            {
                this.dateValueChanged(this, e);
            }
        }

        /// <summary>
        /// 日期显示格式更改
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDateFormatChanged(EventArgs e)
        {
            if (this.dateFormatChanged != null)
            {
                this.dateFormatChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 根据DateValue初始化画面并刷新画面
        /// </summary>
        public void InitializeViewForDateValue()
        {
            if (this.dateValue.HasValue)
            {
                if (this.DateFormat == DateFormats.yyyy || this.DateFormat == DateFormats.yyyyMM)
                {
                    if (this.dateBody.current_display_year == -1)
                    {
                        this.dateBody.current_display_year = this.dateValue.Value.Year;
                    }
                    this.dateBody.current_display_month = -1;
                }
                else
                {
                    this.dateBody.current_display_year = this.dateValue.Value.Year;
                    this.dateBody.current_display_month = this.dateValue.Value.Month;
                }

                this.dateBody.selected_year = this.dateValue.Value.Year;
                this.dateBody.selected_month = this.dateValue.Value.Month;
                this.dateBody.selected_day = this.dateValue.Value.Day;
                this.dateBody.selected_hour = this.dateValue.Value.Hour;
                this.dateBody.selected_minute = this.dateValue.Value.Minute;
                this.dateBody.selected_second = this.dateValue.Value.Second;
            }
            else
            {
                DateTime now = DateTime.Now;
                if (this.DateFormat == DateFormats.yyyy || this.DateFormat == DateFormats.yyyyMM)
                {
                    if (this.dateBody.current_display_year == -1)
                    {
                        this.dateBody.current_display_year = now.Year;
                    }
                    this.dateBody.current_display_month = -1;
                }
                else
                {
                    this.dateBody.current_display_year = now.Year;
                    this.dateBody.current_display_month = now.Month;
                }

                if (this.DateFormat == DateFormats.yyyy)
                {
                    this.dateBody.selected_year = -1;
                    this.dateBody.selected_month = -1;
                    this.dateBody.selected_day = -1;
                    this.dateBody.selected_hour = 0;
                    this.dateBody.selected_minute = 0;
                    this.dateBody.selected_second = 0;
                }
                else if (this.DateFormat == DateFormats.yyyyMM)
                {
                    this.dateBody.selected_year = now.Year;
                    this.dateBody.selected_month = -1;
                    this.dateBody.selected_day = -1;
                    this.dateBody.selected_hour = 0;
                    this.dateBody.selected_minute = 0;
                    this.dateBody.selected_second = 0;
                }
                else if (this.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss)
                {
                    this.dateBody.selected_year = now.Year;
                    this.dateBody.selected_month = now.Month;
                    this.dateBody.selected_day = -1;
                    this.dateBody.selected_hour = 0;
                    this.dateBody.selected_minute = 0;
                    this.dateBody.selected_second = 0;
                }
            }

            if (this.DateFormat == DateFormats.yyyy)
            {
                this.SetCurrentDateFormatsViews(DateFormatsViews.Year_Year);
            }
            else if (this.DateFormat == DateFormats.yyyyMM)
            {
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonth_Month);
            }
            else
            {
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.UpdateBottomText();
            this.AutoMiddleSelectedTimeItem();
            this.Invalidate();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeLayoutRectangle()
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.Handle, out g, out hDC);
            Font text_font = new Font("微软雅黑", 10);

            int scale_topbar_rect_height = (int)(this.topbar_rect_height * DotsPerInchHelper.DPIScale.YScale);

            int scale_year_rectf_item_width = (int)(this.year_item_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_year_rectf_item_height = (int)(this.year_item_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_month_rectf_item_width = (int)(this.month_item_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_month_rectf_item_height = (int)(this.month_item_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_date_rect_width = (int)(this.mainbar_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_date_rect_height = (int)(this.mainbar_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_day_rectf_item_width = (int)(this.day_item_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_day_rectf_item_height = (int)(this.day_item_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_time_rect_width = (int)(this.time_item_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_time_scroll_thickness = (int)(this.time_scroll_thickness * DotsPerInchHelper.DPIScale.XScale);

            int scale_bottombar_rect_height = (int)(this.bottombar_rect_height * DotsPerInchHelper.DPIScale.YScale);

            this.dateBody.TopBar_Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, scale_topbar_rect_height);
            this.dateBody.TopBar_Date_Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, scale_date_rect_width, scale_topbar_rect_height);
            this.dateBody.TopBar_Time_Rect = new Rectangle(scale_date_rect_width, this.ClientRectangle.Y, this.ClientRectangle.Width - scale_date_rect_width, scale_topbar_rect_height);
            this.dateBody.MainBar_Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + scale_topbar_rect_height, this.ClientRectangle.Width, scale_date_rect_height);
            this.dateBody.YearMain_Rect = new Rectangle(this.dateBody.MainBar_Rect.X, this.dateBody.MainBar_Rect.Y, scale_date_rect_width, scale_date_rect_height);
            this.dateBody.MonthMain_Rect = this.dateBody.YearMain_Rect;
            this.dateBody.DayMain_Rect = this.dateBody.YearMain_Rect;
            this.dateBody.TimeMain_Rect = new Rectangle(this.ClientRectangle.X + scale_date_rect_width + date_time_rect_space, this.ClientRectangle.Y + scale_topbar_rect_height, scale_date_rect_width, this.ClientRectangle.Height - scale_topbar_rect_height - scale_bottombar_rect_height);
            this.dateBody.BottomBar_Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Bottom - scale_bottombar_rect_height, this.ClientRectangle.Width, scale_bottombar_rect_height);

            #region 顶部工具栏
            int topbar_btn_rectf_width = (int)(24 * DotsPerInchHelper.DPIScale.XScale);
            float topbar_avg_w = topbar_btn_rectf_width / 3f;
            float topbar_avg_h = this.dateBody.TopBar_Date_Rect.Height / 6f;
            int scale_line_interval = (int)(3 * DotsPerInchHelper.DPIScale.XScale);

            #region 上一年
            this.dateBody.TopBar_prev_year_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X, this.dateBody.TopBar_Date_Rect.Y, topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_prev_year_btn.LineLeftPointArr = new Point[3];
            this.dateBody.TopBar_prev_year_btn.LineLeftPointArr[0] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w * 2 - scale_line_interval), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_prev_year_btn.LineLeftPointArr[1] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_prev_year_btn.LineLeftPointArr[2] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w * 2 - scale_line_interval), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 4));

            this.dateBody.TopBar_prev_year_btn.LineRightPointArr = new Point[3];
            this.dateBody.TopBar_prev_year_btn.LineRightPointArr[0] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w * 2), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_prev_year_btn.LineRightPointArr[1] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w + scale_line_interval), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_prev_year_btn.LineRightPointArr[2] = new Point((int)(this.dateBody.TopBar_prev_year_btn.Rect.X + topbar_avg_w * 2), (int)(this.dateBody.TopBar_prev_year_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            #region 上一月
            this.dateBody.TopBar_prev_month_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X + topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Y, topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Height);

            this.dateBody.TopBar_prev_month_btn.LineLeftPointArr = new Point[3];
            this.dateBody.TopBar_prev_month_btn.LineLeftPointArr[0] = new Point((int)(this.dateBody.TopBar_prev_month_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.dateBody.TopBar_prev_month_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_prev_month_btn.LineLeftPointArr[1] = new Point((int)(this.dateBody.TopBar_prev_month_btn.Rect.X + topbar_avg_w), (int)(this.dateBody.TopBar_prev_month_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_prev_month_btn.LineLeftPointArr[2] = new Point((int)(this.dateBody.TopBar_prev_month_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.dateBody.TopBar_prev_month_btn.Rect.Y + topbar_avg_h * 4));
            #endregion

            int scale_yearscope_btn_width = (int)(120 * DotsPerInchHelper.DPIScale.XScale);
            int scale_monthyear_btn_width = (int)(60 * DotsPerInchHelper.DPIScale.XScale);
            int scale_month_btn_width = (int)(37 * DotsPerInchHelper.DPIScale.XScale);
            this.dateBody.TopBar_yearscope_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X + (this.dateBody.TopBar_Date_Rect.Width - scale_yearscope_btn_width) / 2, this.dateBody.TopBar_Date_Rect.Y, scale_yearscope_btn_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_monthyear_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X + (this.dateBody.TopBar_Date_Rect.Width - scale_monthyear_btn_width) / 2, this.dateBody.TopBar_Date_Rect.Y, scale_monthyear_btn_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_month_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X + (this.dateBody.TopBar_Date_Rect.Width - (scale_month_btn_width + scale_monthyear_btn_width)) / 2, this.dateBody.TopBar_Date_Rect.Y, scale_month_btn_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_year_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.X + (this.dateBody.TopBar_Date_Rect.Width - (scale_month_btn_width + scale_monthyear_btn_width)) / 2 + scale_month_btn_width, this.dateBody.TopBar_Date_Rect.Y, scale_monthyear_btn_width, this.dateBody.TopBar_Date_Rect.Height);
            #region 下一月
            this.dateBody.TopBar_next_month_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.Right - topbar_btn_rectf_width - topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Y, topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Height);

            this.dateBody.TopBar_next_month_btn.LineRightPointArr = new Point[3];
            this.dateBody.TopBar_next_month_btn.LineRightPointArr[0] = new Point((int)(this.dateBody.TopBar_next_month_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.dateBody.TopBar_next_month_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_next_month_btn.LineRightPointArr[1] = new Point((int)(this.dateBody.TopBar_next_month_btn.Rect.Right - topbar_avg_w), (int)(this.dateBody.TopBar_next_month_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_next_month_btn.LineRightPointArr[2] = new Point((int)(this.dateBody.TopBar_next_month_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.dateBody.TopBar_next_month_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            #region 下一年
            this.dateBody.TopBar_next_year_btn.Rect = new Rectangle(this.dateBody.TopBar_Date_Rect.Right - topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Y, topbar_btn_rectf_width, this.dateBody.TopBar_Date_Rect.Height);

            this.dateBody.TopBar_next_year_btn.LineLeftPointArr = new Point[3];
            this.dateBody.TopBar_next_year_btn.LineLeftPointArr[0] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w * 2 + scale_line_interval), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_next_year_btn.LineLeftPointArr[1] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_next_year_btn.LineLeftPointArr[2] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w * 2 + scale_line_interval), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 4));

            this.dateBody.TopBar_next_year_btn.LineRightPointArr = new Point[3];
            this.dateBody.TopBar_next_year_btn.LineRightPointArr[0] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w * 2), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 2));
            this.dateBody.TopBar_next_year_btn.LineRightPointArr[1] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w - scale_line_interval), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 3));
            this.dateBody.TopBar_next_year_btn.LineRightPointArr[2] = new Point((int)(this.dateBody.TopBar_next_year_btn.Rect.Right - topbar_avg_w * 2), (int)(this.dateBody.TopBar_next_year_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            this.dateBody.TopBar_hour_rect = new Rectangle(this.dateBody.TimeMain_Rect.X + date_time_rect_space, this.dateBody.TopBar_Date_Rect.Y, scale_time_rect_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_minute_rect = new Rectangle(this.dateBody.TopBar_hour_rect.Right + scale_time_scroll_thickness, this.dateBody.TopBar_Date_Rect.Y, scale_time_rect_width, this.dateBody.TopBar_Date_Rect.Height);
            this.dateBody.TopBar_second_rect = new Rectangle(this.dateBody.TopBar_minute_rect.Right + scale_time_scroll_thickness, this.dateBody.TopBar_Date_Rect.Y, scale_time_rect_width, this.dateBody.TopBar_Date_Rect.Height);
            #endregion
            #region 年面板
            int year_col = 3;
            int year_row = 4;
            float year_space_width = (scale_date_rect_width - scale_year_rectf_item_width * year_col) / (float)(year_col + 1);
            float year_space_height = (scale_date_rect_height - scale_year_rectf_item_height * year_row) / (float)(year_row + 1);
            for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
            {
                float x = this.dateBody.YearMain_Rect.X + year_space_width + (i % year_col) * (scale_year_rectf_item_width + year_space_width);
                float y = this.dateBody.YearMain_Rect.Y + year_space_height + (i / year_col) * (scale_year_rectf_item_height + year_space_height);
                this.dateBody.YearMain_itemArr[i].Rect = new Rectangle((int)x, (int)y, scale_year_rectf_item_width, scale_year_rectf_item_height);
            }
            #endregion
            #region 月面板
            int month_col = 3;
            int month_row = 4;
            float month_space_width = (scale_date_rect_width - scale_month_rectf_item_width * month_col) / (float)(month_col + 1);
            float month_space_height = (scale_date_rect_height - scale_month_rectf_item_height * month_row) / (float)(month_row + 1);
            for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
            {
                float x = this.dateBody.MonthMain_Rect.X + month_space_width + (i % month_col) * (scale_month_rectf_item_width + month_space_width);
                float y = this.dateBody.MonthMain_Rect.Y + month_space_height + (i / month_col) * (scale_month_rectf_item_height + month_space_height);
                this.dateBody.MonthMain_itemArr[i].Rect = new Rectangle((int)x, (int)y, scale_month_rectf_item_width, scale_month_rectf_item_height);
            }
            #endregion
            #region 日面板

            int day_col = 7;
            int day_row = 7;

            float day_space_width = 1;
            float day_space_height = 1;
            float day_space_left = (scale_date_rect_width - scale_day_rectf_item_width * day_col - day_space_width * (day_col - 1)) / 2f;
            float day_space_top = (scale_date_rect_height - scale_day_rectf_item_height * day_row - day_space_height * (day_row - 1)) / 2f;

            //标题
            for (int i = 0; i < this.dateBody.DayMain_titleArr.Length; i++)
            {
                float x = this.dateBody.DayMain_Rect.X + day_space_left + (i % day_col) * (scale_day_rectf_item_width + day_space_width);
                float y = this.dateBody.DayMain_Rect.Y + day_space_top;
                this.dateBody.DayMain_titleArr[i].Rect = new Rectangle((int)x, (int)y, scale_day_rectf_item_width, scale_day_rectf_item_height);
            }

            for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
            {
                float x = this.dateBody.DayMain_Rect.X + day_space_left + (i % day_col) * (scale_day_rectf_item_width + day_space_width);
                float y = this.dateBody.DayMain_Rect.Y + scale_day_rectf_item_height + day_space_top + (i / day_col) * (scale_day_rectf_item_height + day_space_height);
                this.dateBody.DayMain_itemArr[i].Rect = new Rectangle((int)x, (int)y, scale_day_rectf_item_width, scale_day_rectf_item_height);
            }

            #endregion
            #region 时间面板
            int scale_time_item_height = (int)(this.time_item_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_timeScrollThickness = (int)(this.time_scroll_thickness * DotsPerInchHelper.DPIScale.YScale);
            int scale_item_w = (int)(this.time_item_rect_width * DotsPerInchHelper.DPIScale.YScale);

            #region 选项信息
            int item_y = this.dateBody.TimeMain_Rect.Y;

            #endregion

            #region 时分秒区域
            this.dateBody.TimeMain_HourArea.Rect = new RectangleF(this.dateBody.TimeMain_Rect.X, this.dateBody.TimeMain_Rect.Y, scale_item_w, this.dateBody.TimeMain_Rect.Height);
            this.dateBody.TimeMain_MinuteArea.Rect = new RectangleF(this.dateBody.TimeMain_Rect.X + scale_item_w + scale_timeScrollThickness, this.dateBody.TimeMain_Rect.Y, scale_item_w, this.dateBody.TimeMain_Rect.Height);
            this.dateBody.TimeMain_SecondArea.Rect = new RectangleF(this.dateBody.TimeMain_Rect.X + scale_item_w * 2f + scale_timeScrollThickness * 2, this.dateBody.TimeMain_Rect.Y, scale_item_w, this.dateBody.TimeMain_Rect.Height);
            #endregion

            #region 时分秒选项
            for (int i = 0; i < this.dateBody.TimeMain_HourArea.itemArr.Length; i++)
            {
                this.dateBody.TimeMain_HourArea.itemArr[i].Rect = new Rectangle((int)this.dateBody.TimeMain_HourArea.Rect.X, item_y, scale_item_w, scale_time_item_height);
                item_y += scale_time_item_height;
            }
            item_y = this.dateBody.TimeMain_Rect.Y;
            for (int i = 0; i < this.dateBody.TimeMain_MinuteArea.itemArr.Length; i++)
            {
                this.dateBody.TimeMain_MinuteArea.itemArr[i].Rect = new Rectangle((int)this.dateBody.TimeMain_MinuteArea.Rect.X, item_y, scale_item_w, scale_time_item_height);
                item_y += scale_time_item_height;
            }
            item_y = this.dateBody.TimeMain_Rect.Y;
            for (int i = 0; i < this.dateBody.TimeMain_SecondArea.itemArr.Length; i++)
            {
                this.dateBody.TimeMain_SecondArea.itemArr[i].Rect = new Rectangle((int)this.dateBody.TimeMain_SecondArea.Rect.X, item_y, scale_item_w, scale_time_item_height);
                item_y += scale_time_item_height;
            }
            #endregion

            #region 时分秒滚动条
            this.InitializeTimeScrollLayoutRectangle(this.dateBody.TimeMain_HourArea.Scroll, this.dateBody.TimeMain_HourArea.Rect, this.dateBody.TimeMain_HourArea.itemArr.Length, scale_time_item_height);
            this.InitializeTimeScrollLayoutRectangle(this.dateBody.TimeMain_MinuteArea.Scroll, this.dateBody.TimeMain_MinuteArea.Rect, this.dateBody.TimeMain_MinuteArea.itemArr.Length, scale_time_item_height);
            this.InitializeTimeScrollLayoutRectangle(this.dateBody.TimeMain_SecondArea.Scroll, this.dateBody.TimeMain_SecondArea.Rect, this.dateBody.TimeMain_SecondArea.itemArr.Length, scale_time_item_height);
            #endregion
            #endregion
            #region 底部工具栏
            int bottombar_btn_rectf_width = (int)(36 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_btn_rectf_height = (int)(28 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_space_width = (int)(2 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_space_right = (int)(3 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_time_width = (int)(26 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_btn_y = this.dateBody.BottomBar_Rect.Y + (this.dateBody.BottomBar_Rect.Height - bottombar_btn_rectf_height) / 2;

            int bottombar_tip_left_padding = (int)(5 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_tip_topbottom_padding = (int)(10 * DotsPerInchHelper.DPIScale.XScale);
            int bottombar_tip_border_width = (int)(6 * DotsPerInchHelper.DPIScale.XScale);
            this.dateBody.Bottombar_minmaxborder_lab.LinePointArr = new Point[4];
            this.dateBody.Bottombar_minmaxborder_lab.LinePointArr[0] = new Point(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding + bottombar_tip_border_width, this.dateBody.BottomBar_Rect.Y + bottombar_tip_topbottom_padding);
            this.dateBody.Bottombar_minmaxborder_lab.LinePointArr[1] = new Point(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding, this.dateBody.BottomBar_Rect.Y + bottombar_tip_topbottom_padding);
            this.dateBody.Bottombar_minmaxborder_lab.LinePointArr[2] = new Point(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding, this.dateBody.BottomBar_Rect.Bottom - bottombar_tip_topbottom_padding);
            this.dateBody.Bottombar_minmaxborder_lab.LinePointArr[3] = new Point(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding + bottombar_tip_border_width, this.dateBody.BottomBar_Rect.Bottom - bottombar_tip_topbottom_padding);

            Size bottombar_mindate_lab_size = g.MeasureString("9999-01-01", text_font, int.MaxValue, StringFormat.GenericTypographic).ToSize();
            this.dateBody.Bottombar_mindate_lab.Rect = new Rectangle(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding + bottombar_tip_border_width * 2, this.dateBody.BottomBar_Rect.Top + bottombar_tip_topbottom_padding - bottombar_mindate_lab_size.Height / 2, bottombar_mindate_lab_size.Width, bottombar_mindate_lab_size.Height);
            Size bottombar_maxdate_lab_size = g.MeasureString("9999-01-01", text_font, int.MaxValue, StringFormat.GenericTypographic).ToSize();
            this.dateBody.Bottombar_maxdate_lab.Rect = new Rectangle(this.dateBody.BottomBar_Rect.X + bottombar_tip_left_padding + bottombar_tip_border_width * 2, this.dateBody.BottomBar_Rect.Bottom - bottombar_tip_topbottom_padding - bottombar_maxdate_lab_size.Height / 2, bottombar_maxdate_lab_size.Width, bottombar_maxdate_lab_size.Height);

            this.dateBody.Bottombar_confirm_btn.Rect = new Rectangle(this.dateBody.BottomBar_Rect.Right - bottombar_space_right - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);
            this.dateBody.Bottombar_now_btn.Rect = new Rectangle(this.dateBody.Bottombar_confirm_btn.Rect.X - bottombar_space_width - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);
            this.dateBody.Bottombar_clear_btn.Rect = new Rectangle(this.dateBody.Bottombar_now_btn.Rect.X - bottombar_space_width - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);

            #endregion

            text_font.Dispose();
            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// 初始化时间滚动条布局
        /// </summary>
        /// <param name="scroll_obj">时间滚动条对象</param>
        /// <param name="display_rect">时间选项显示区域</param>
        /// <param name="item_count">时间选项总数</param>
        /// <param name="item_height">时间选项高度</param>
        private void InitializeTimeScrollLayoutRectangle(TimeAreaScrollClass scroll_obj, RectangleF display_rect, int item_count, int item_height)
        {
            int scale_timeScrollThickness = (int)(this.time_scroll_thickness * DotsPerInchHelper.DPIScale.YScale);

            scroll_obj.Owner_Display_Rect = new RectangleF(display_rect.X, display_rect.Y, display_rect.Width, display_rect.Height);
            scroll_obj.Owner_Content_Rect = new RectangleF(display_rect.X, display_rect.Y, display_rect.Width, item_count * item_height);

            scroll_obj.Scroll_Back_Rect = new RectangleF(display_rect.Right, display_rect.Y, scale_timeScrollThickness, display_rect.Height);
            float slide_h = scroll_obj.Owner_Display_Rect.Height * scroll_obj.Scroll_Back_Rect.Height / scroll_obj.Owner_Content_Rect.Height;
            if (scroll_obj.Owner_Content_Rect.Height <= scroll_obj.Owner_Display_Rect.Height)
            {
                slide_h = scroll_obj.Scroll_Back_Rect.Height;
            }
            scroll_obj.Scroll_Slide_Rect = new RectangleF(scroll_obj.Scroll_Back_Rect.X, scroll_obj.Scroll_Back_Rect.Y, scale_timeScrollThickness, slide_h);
        }

        /// <summary>
        /// 更新顶部画面文本信息
        /// </summary>
        private void UpdateTopText()
        {
            if (this.DateFormat == DateFormats.yyyy)
            {
                int start_year = GetStartYaer(this.dateBody.current_display_year);
                this.dateBody.TopBar_yearscope_btn.Text = String.Format("{0}年~{1}年", start_year.ToString().PadLeft(4, '0'), (start_year + 11).ToString().PadLeft(4, '0'));
                this.dateBody.TopBar_monthyear_btn.Text = "";
                this.dateBody.TopBar_month_btn.Text = "";
                this.dateBody.TopBar_year_btn.Text = "";
            }
            else if (this.DateFormat == DateFormats.yyyyMM)
            {

                this.dateBody.TopBar_yearscope_btn.Text = "";
                this.dateBody.TopBar_monthyear_btn.Text = this.dateBody.current_display_year + "年";
                this.dateBody.TopBar_month_btn.Text = "";
                this.dateBody.TopBar_year_btn.Text = "";
            }
            else
            {
                this.dateBody.TopBar_yearscope_btn.Text = "";
                this.dateBody.TopBar_monthyear_btn.Text = "";
                this.dateBody.TopBar_month_btn.Text = String.Format("{0}月", this.dateBody.current_display_month.ToString().PadLeft(2, '0'));
                this.dateBody.TopBar_year_btn.Text = String.Format("{0}年", this.dateBody.current_display_year.ToString().PadLeft(4, '0'));
            }
        }

        /// <summary>
        /// 更新年月日画面文本信息 
        /// </summary>
        private void UpdateYearMonthDayText()
        {
            // 年面板
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Year))
            {
                int start_year = GetStartYaer(this.dateBody.current_display_year);
                for (int i = 0; i < this.dateBody.YearMain_itemArr.Length; i++)
                {
                    int year = start_year + i;
                    this.dateBody.YearMain_itemArr[i].Value = "10" + (start_year + i).ToString().PadLeft(4, '0');
                    this.dateBody.YearMain_itemArr[i].DayItemType = (year < this.MinValue.Year || year > this.MaxValue.Year) ? DayItemTypes.Disabled : DayItemTypes.Normal;
                }
            }
            // 月面板
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Month))
            {
                int ym_min_month = int.Parse(this.MinValue.ToString("10yyyyMM"));
                int ym_max_month = int.Parse(this.MaxValue.ToString("10yyyyMM"));
                for (int i = 0; i < this.dateBody.MonthMain_itemArr.Length; i++)
                {
                    int ym_now_month = int.Parse("10" + this.dateBody.current_display_year.ToString().PadLeft(4, '0') + (i + 1).ToString().PadLeft(2, '0'));
                    this.dateBody.MonthMain_itemArr[i].Value = ym_now_month.ToString();
                    this.dateBody.MonthMain_itemArr[i].DayItemType = (ym_min_month > ym_now_month || ym_now_month > ym_max_month) ? DayItemTypes.Disabled : DayItemTypes.Normal;
                }
            }
            // 日面板
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Day))
            {
                int days = DateTime.DaysInMonth(this.dateBody.current_display_year, this.dateBody.current_display_month);//指定月份的总天数
                DateTime first_day = new DateTime(this.dateBody.current_display_year, this.dateBody.current_display_month, 1, 0, 0, 0);//指定年月的第一天
                int first_day_weekday = (int)(first_day.DayOfWeek);//指定日期为星期几
                if (first_day_weekday == 0)
                {
                    first_day_weekday = 7;
                }

                DateTime ymd_min = this.MinValue.Date;
                DateTime ymd_max = this.MaxValue.Date;
                for (int i = 0; i < this.dateBody.DayMain_itemArr.Length; i++)
                {
                    if (i < first_day_weekday)//绘制指定月份上一个月的日期
                    {
                        int day = -(first_day_weekday - i);
                        DateTime ymd_now = first_day.AddDays(day);
                        this.dateBody.DayMain_itemArr[i].Value = ymd_now.ToString("10yyyyMMdd");
                        this.dateBody.DayMain_itemArr[i].DayItemType = (ymd_min > ymd_now || ymd_now > ymd_max) ? DayItemTypes.Disabled : DayItemTypes.UnCurrent;
                    }
                    else if (i - first_day_weekday < days)//绘制指定月份的日期
                    {
                        int day = i - first_day_weekday;
                        DateTime ymd_now = first_day.AddDays(day).Date;
                        this.dateBody.DayMain_itemArr[i].Value = ymd_now.ToString("10yyyyMMdd");
                        this.dateBody.DayMain_itemArr[i].DayItemType = (ymd_min > ymd_now || ymd_now > ymd_max) ? DayItemTypes.Disabled : DayItemTypes.Normal;
                    }
                    else//绘制指定月份下一个月的日期
                    {
                        int day = i - first_day_weekday;
                        DateTime ymd_now = first_day.AddDays(day).Date;
                        this.dateBody.DayMain_itemArr[i].Value = ymd_now.ToString("10yyyyMMdd");
                        this.dateBody.DayMain_itemArr[i].DayItemType = (ymd_min > ymd_now || ymd_now > ymd_max) ? DayItemTypes.Disabled : DayItemTypes.UnCurrent;
                    }
                }
            }
        }

        /// <summary>
        /// 更新底部画面文本信息
        /// </summary>
        private void UpdateBottomText()
        {
            string strformat = "";
            if (this.DateFormat == DateFormats.yyyy)
            {
                strformat = "yyyy";
            }
            else if (this.DateFormat == DateFormats.yyyyMM)
            {
                strformat = "yyyy-MM";
            }
            else
            {
                strformat = "yyyy-MM-dd";
            }

            this.dateBody.Bottombar_mindate_lab.Text = this.MinValue.ToString(strformat);
            this.dateBody.Bottombar_maxdate_lab.Text = this.MaxValue.ToString(strformat);
        }

        /// <summary>
        /// 当前设置格式是否包含日期指定部分
        /// </summary>
        /// <param name="dateElement">日期指定部分</param>
        /// <returns></returns>
        private bool IsContainEmbodyForCurrentFormat(DateElement dateElement)
        {
            switch (dateElement)
            {
                case DateElement.Year:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyy || this.DateFormat == DatePickerExt.DateFormats.yyyyMM || this.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Month:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMM || this.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Day:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMdd || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Hour:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Minute:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Second:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 日期指定部分面板是否在当前面板显示  
        /// </summary>
        /// <param name="dateElement">日期指定部分面板</param>
        /// <returns></returns>
        private bool IsContainEmbodyForCurrentView(DateElement dateElement)
        {
            switch (dateElement)
            {
                case DateElement.Year:
                    {
                        return (this.currentDateFormatsViews == DateFormatsViews.Year_Year || this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year);
                    }
                case DateElement.Month:
                    {
                        return (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month || this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month);
                    }
                case DateElement.Day:
                    {
                        return (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day);
                    }
                case DateElement.Hour:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHH || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Minute:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmm || this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                case DateElement.Second:
                    {
                        return (this.DateFormat == DatePickerExt.DateFormats.yyyyMMddHHmmss);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 当前面板切换到指定面板
        /// </summary>
        /// <param name="view">指定面板</param>
        private void SetCurrentDateFormatsViews(DateFormatsViews view)
        {
            this.currentDateFormatsViews = view;
            if (this.currentDateFormatsViews == DateFormatsViews.Year_Year)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.YearMain_itemArr[0].Rect;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.YearMain_itemArr[0].Rect;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.MonthMain_itemArr[0].Rect;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.YearMain_itemArr[0].Rect;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.MonthMain_itemArr[0].Rect;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day)
            {
                this.activatedIndex = 0;
                this.activatedrect = this.dateBody.DayMain_itemArr[0].Rect;
            }
        }

        /// <summary>
        /// 让选中的时间选垂直项居中显示
        /// </summary>
        private void AutoMiddleSelectedTimeItem()
        {
            int scale_time_item_height = (int)(this.time_item_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int center_y = (int)(this.dateBody.TimeMain_Rect.Y + (this.dateBody.TimeMain_Rect.Height - scale_time_item_height) / 2f);

            if (this.IsContainEmbodyForCurrentFormat(DateElement.Hour))
            {
                if (this.dateBody.selected_hour > -1)
                {
                    int item_y = this.dateBody.TimeMain_HourArea.itemArr[this.dateBody.selected_hour].Rect.Y;
                    if (item_y > center_y)
                    {
                        float offset = ((item_y - center_y) * (this.dateBody.TimeMain_HourArea.Scroll.Scroll_Back_Rect.Height - this.dateBody.TimeMain_HourArea.Scroll.Scroll_Slide_Rect.Height) / (this.dateBody.TimeMain_HourArea.Scroll.Owner_Content_Rect.Height - this.dateBody.TimeMain_HourArea.Scroll.Owner_Display_Rect.Height)) + this.dateBody.TimeMain_HourArea.Scroll.Scroll_Back_Rect.Y - this.dateBody.TimeMain_HourArea.Scroll.Scroll_Slide_Rect.Y;
                        this.dateBody.TimeMain_HourArea.Scroll.IsResetScrollByOffset((int)offset);
                    }
                    else
                    {
                        this.dateBody.TimeMain_HourArea.Scroll.IsResetScrollByOffset(this.GetTimeItemsDisplayY(this.dateBody.TimeMain_HourArea.Scroll));
                    }
                }
            }
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Minute))
            {
                if (this.dateBody.selected_minute > -1)
                {
                    int item_y = this.dateBody.TimeMain_MinuteArea.itemArr[this.dateBody.selected_minute].Rect.Y;
                    if (item_y > center_y)
                    {
                        float offset = ((item_y - center_y) * (this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Back_Rect.Height - this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Slide_Rect.Height) / (this.dateBody.TimeMain_MinuteArea.Scroll.Owner_Content_Rect.Height - this.dateBody.TimeMain_MinuteArea.Scroll.Owner_Display_Rect.Height)) + this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Back_Rect.Y - this.dateBody.TimeMain_MinuteArea.Scroll.Scroll_Slide_Rect.Y;
                        this.dateBody.TimeMain_MinuteArea.Scroll.IsResetScrollByOffset((int)offset);
                    }
                    else
                    {
                        this.dateBody.TimeMain_MinuteArea.Scroll.IsResetScrollByOffset(this.GetTimeItemsDisplayY(this.dateBody.TimeMain_MinuteArea.Scroll));
                    }
                }
            }
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Second))
            {
                if (this.dateBody.selected_second > -1)
                {
                    int item_y = this.dateBody.TimeMain_SecondArea.itemArr[this.dateBody.selected_second].Rect.Y;
                    if (item_y > center_y)
                    {
                        float offset = ((item_y - center_y) * (this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Back_Rect.Height - this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Slide_Rect.Height) / (this.dateBody.TimeMain_SecondArea.Scroll.Owner_Content_Rect.Height - this.dateBody.TimeMain_SecondArea.Scroll.Owner_Display_Rect.Height)) + this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Back_Rect.Y - this.dateBody.TimeMain_SecondArea.Scroll.Scroll_Slide_Rect.Y;
                        this.dateBody.TimeMain_SecondArea.Scroll.IsResetScrollByOffset((int)offset);
                    }
                    else
                    {
                        this.dateBody.TimeMain_SecondArea.Scroll.IsResetScrollByOffset(this.GetTimeItemsDisplayY(this.dateBody.TimeMain_SecondArea.Scroll));
                    }
                }
            }
        }

        /// <summary>
        /// 键盘方向键更新激活索引
        /// </summary>
        /// <param name="key">键盘方向键 Keys.Left、Keys.Right、Keys.Up、Keys.Down</param>
        private void ActivateIndexByKey(Keys key)
        {
            int tmp = this.activatedIndex;
            if (this.currentDateFormatsViews == DateFormatsViews.Year_Year)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -2)
                    {
                        tmp = 14;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 14)
                    {
                        tmp = -2;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 14;
                    }
                    else if (tmp <= 2)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 11)
                    {
                        tmp -= 3;
                    }
                    else if (tmp <= 14)
                    {
                        tmp = 11;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 12)
                    {
                        tmp = -2;
                    }
                    else if (tmp >= 9)
                    {
                        tmp = 12;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 3;
                    }
                    else if (tmp >= -2)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 11)
                {
                    this.activatedrect = this.dateBody.YearMain_itemArr[tmp].Rect;
                }
                else if (tmp == 12)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 13)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 14)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -3)
                    {
                        tmp = 14;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 14)
                    {
                        tmp = -3;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 14;
                    }
                    else if (tmp <= 2)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 11)
                    {
                        tmp -= 3;
                    }
                    else if (tmp <= 14)
                    {
                        tmp = 11;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 12)
                    {
                        tmp = -3;
                    }
                    else if (tmp >= 9)
                    {
                        tmp = 12;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 3;
                    }
                    else if (tmp >= -3)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -3)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_monthyear_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 11)
                {
                    this.activatedrect = this.dateBody.YearMain_itemArr[tmp].Rect;
                }
                else if (tmp == 12)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 13)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 14)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -3)
                    {
                        tmp = 14;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 14)
                    {
                        tmp = -3;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 14;
                    }
                    else if (tmp <= 2)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 11)
                    {
                        tmp -= 3;
                    }
                    else if (tmp <= 14)
                    {
                        tmp = 11;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 12)
                    {
                        tmp = -3;
                    }
                    else if (tmp >= 9)
                    {
                        tmp = 12;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 3;
                    }
                    else if (tmp >= -3)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -3)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_monthyear_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 11)
                {
                    this.activatedrect = this.dateBody.MonthMain_itemArr[tmp].Rect;
                }
                else if (tmp == 12)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 13)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 14)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -6)
                    {
                        tmp = 14;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 14)
                    {
                        tmp = -6;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 14;
                    }
                    else if (tmp <= 2)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 11)
                    {
                        tmp -= 3;
                    }
                    else if (tmp <= 14)
                    {
                        tmp = 11;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 12)
                    {
                        tmp = -6;
                    }
                    else if (tmp >= 9)
                    {
                        tmp = 12;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 3;
                    }
                    else if (tmp >= -6)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -6)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -5)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_month_btn.Rect;
                }
                else if (tmp == -4)
                {
                    this.activatedrect = this.dateBody.TopBar_month_btn.Rect;
                }
                else if (tmp == -3)
                {
                    this.activatedrect = this.dateBody.TopBar_year_btn.Rect;
                }
                else if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_next_month_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 11)
                {
                    this.activatedrect = this.dateBody.YearMain_itemArr[tmp].Rect;
                }
                else if (tmp == 12)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 13)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 14)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -6)
                    {
                        tmp = 14;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 14)
                    {
                        tmp = -6;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 14;
                    }
                    else if (tmp <= 2)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 11)
                    {
                        tmp -= 3;
                    }
                    else if (tmp <= 14)
                    {
                        tmp = 11;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 12)
                    {
                        tmp = -6;
                    }
                    else if (tmp >= 9)
                    {
                        tmp = 12;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 3;
                    }
                    else if (tmp >= -6)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -6)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -5)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_month_btn.Rect;
                }
                else if (tmp == -4)
                {
                    this.activatedrect = this.dateBody.TopBar_month_btn.Rect;
                }
                else if (tmp == -3)
                {
                    this.activatedrect = this.dateBody.TopBar_year_btn.Rect;
                }
                else if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_next_month_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 11)
                {
                    this.activatedrect = this.dateBody.MonthMain_itemArr[tmp].Rect;
                }
                else if (tmp == 12)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 13)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 14)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day)
            {
                if (key == Keys.Left)
                {
                    tmp -= 1;
                    if (tmp < -6)
                    {
                        tmp = 44;
                    }
                }
                else if (key == Keys.Right)
                {
                    tmp += 1;
                    if (tmp > 44)
                    {
                        tmp = -6;
                    }
                }
                else if (key == Keys.Up)
                {
                    if (tmp <= -1)
                    {
                        tmp = 44;
                    }
                    else if (tmp <= 6)
                    {
                        tmp = -1;
                    }
                    else if (tmp <= 41)
                    {
                        tmp -= 7;
                    }
                    else if (tmp <= 44)
                    {
                        tmp = 41;
                    }
                }
                else if (key == Keys.Down)
                {
                    if (tmp >= 41)
                    {
                        tmp = -6;
                    }
                    else if (tmp >= 35)
                    {
                        tmp = 42;
                    }
                    else if (tmp >= 0)
                    {
                        tmp += 7;
                    }
                    else if (tmp >= -6)
                    {
                        tmp = 0;
                    }
                }

                if (tmp == -6)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_year_btn.Rect;
                }
                else if (tmp == -5)
                {
                    this.activatedrect = this.dateBody.TopBar_prev_month_btn.Rect;
                }
                else if (tmp == -4)
                {
                    this.activatedrect = this.dateBody.TopBar_month_btn.Rect;
                }
                else if (tmp == -3)
                {
                    this.activatedrect = this.dateBody.TopBar_year_btn.Rect;
                }
                else if (tmp == -2)
                {
                    this.activatedrect = this.dateBody.TopBar_next_month_btn.Rect;
                }
                else if (tmp == -1)
                {
                    this.activatedrect = this.dateBody.TopBar_next_year_btn.Rect;
                }
                else if (tmp >= 0 && tmp <= 41)
                {
                    this.activatedrect = this.dateBody.DayMain_itemArr[tmp].Rect;
                }
                else if (tmp == 42)
                {
                    this.activatedrect = this.dateBody.Bottombar_clear_btn.Rect;
                }
                else if (tmp == 43)
                {
                    this.activatedrect = this.dateBody.Bottombar_now_btn.Rect;
                }
                else if (tmp == 44)
                {
                    this.activatedrect = this.dateBody.Bottombar_confirm_btn.Rect;
                }
                this.activatedIndex = tmp;
            }

            this.activatedVisible = true;
            this.Invalidate();
        }

        /// <summary>
        ///指定激活选项单击
        /// </summary>
        /// <returns></returns>
        private void ActivateIndexClick()
        {
            int index = this.activatedIndex;

            if (this.currentDateFormatsViews == DateFormatsViews.Year_Year)
            {
                if (index == -2)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (0 <= index && index <= 11)
                {
                    this.YearMainItemClick(this.dateBody.YearMain_itemArr[index]);
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year)
            {
                if (index == -3)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -2)
                {
                    this.TopBarYearMonthClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (0 <= index && index <= 11)
                {
                    this.MonthMainItemClick(this.dateBody.YearMain_itemArr[index]);
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month)
            {
                if (index == -3)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -2)
                {
                    this.TopBarYearMonthClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (0 <= index && index <= 11)
                {
                    this.YearMainItemClick(this.dateBody.MonthMain_itemArr[index]);
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year)
            {
                if (index == -6)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -5)
                {
                    this.TopBarPrevMonthClick();
                }
                else if (index == -4)
                {
                    this.TopBarMonthClick();
                }
                else if (index == -3)
                {
                    this.TopBarYearClick();
                }
                else if (index == -2)
                {
                    this.TopBarNextMonthClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (0 <= index && index <= 11)
                {
                    this.YearMainItemClick(this.dateBody.YearMain_itemArr[index]);
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month)
            {
                if (index == -6)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -5)
                {
                    this.TopBarPrevMonthClick();
                }
                else if (index == -4)
                {
                    this.TopBarMonthClick();
                }
                else if (index == -3)
                {
                    this.TopBarYearClick();
                }
                else if (index == -2)
                {
                    this.TopBarNextMonthClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (0 <= index && index <= 11)
                {
                    this.MonthMainItemClick(this.dateBody.MonthMain_itemArr[index]);
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
                this.UpdateTopText();
                this.UpdateYearMonthDayText();
                this.Invalidate();
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Day)
            {
                if (index == -6)
                {
                    this.TopBarPrevYearClick();
                }
                else if (index == -5)
                {
                    this.TopBarPrevMonthClick();
                }
                else if (index == -4)
                {
                    this.TopBarMonthClick();
                }
                else if (index == -3)
                {
                    this.TopBarYearClick();
                }
                else if (index == -2)
                {
                    this.TopBarNextMonthClick();
                }
                else if (index == -1)
                {
                    this.TopBarNextYearClick();
                }
                else if (index <= 41)
                {
                    this.DayMainItemClick(this.dateBody.DayMain_itemArr[index]);
                }
                else if (index == 42)
                {
                    this.OnBottomBarClearClick(new EventArgs());
                }
                else if (index == 43)
                {
                    this.OnBottomBarNowClick(new EventArgs());
                }
                else if (index == 44)
                {
                    this.OnBottomBarConfirmClick(new EventArgs());
                }
            }
        }

        /// <summary>
        /// 根据设置获取控件大小
        /// </summary>
        /// <returns></returns>
        private Size GetControlAutoSize()
        {
            int scale_date_rect_width = (int)(this.mainbar_rect_width * DotsPerInchHelper.DPIScale.XScale);
            int scale_date_rect_height = (int)(this.mainbar_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_topbar_rect_height = (int)(this.topbar_rect_height * DotsPerInchHelper.DPIScale.YScale);
            int scale_bottombar_rect_height = (int)(this.bottombar_rect_height * DotsPerInchHelper.DPIScale.YScale);

            int scale_time_rect_width = 0;
            if (this.DateFormat == DateFormats.yyyyMMddHH)
            {
                scale_time_rect_width = date_time_rect_space + (int)((this.time_item_rect_width + this.time_scroll_thickness) * DotsPerInchHelper.DPIScale.XScale);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmm)
            {
                scale_time_rect_width = date_time_rect_space + (int)((this.time_item_rect_width + this.time_scroll_thickness) * 2 * DotsPerInchHelper.DPIScale.XScale);
            }
            else if (this.DateFormat == DateFormats.yyyyMMddHHmmss)
            {
                scale_time_rect_width = date_time_rect_space + (int)((this.time_item_rect_width + this.time_scroll_thickness) * 3 * DotsPerInchHelper.DPIScale.XScale);
            }

            return new Size(scale_date_rect_width + scale_time_rect_width, scale_topbar_rect_height + scale_date_rect_height + scale_bottombar_rect_height);
        }

        /// <summary>
        /// 获取指定年份的年面板第一个开始的年份
        /// </summary>
        /// <param name="year">指定年份</param>
        /// <returns></returns>
        private int GetStartYaer(int year)
        {
            return Math.Min(Math.Max(year - 4, 1), 9988);
        }

        /// <summary>
        /// 获取时间选项列表Rect的开始Y坐标
        /// </summary>
        /// <param name="scroll_obj"></param>
        /// <returns></returns>
        private int GetTimeItemsDisplayY(TimeAreaScrollClass scroll_obj)
        {
            float y = 0;
            if (scroll_obj.Scroll_Back_Rect.Height > scroll_obj.Scroll_Slide_Rect.Height)
            {
                y = -(scroll_obj.Scroll_Slide_Rect.Y - scroll_obj.Scroll_Back_Rect.Y) / (scroll_obj.Scroll_Back_Rect.Height - scroll_obj.Scroll_Slide_Rect.Height) * (scroll_obj.Owner_Content_Rect.Height - scroll_obj.Owner_Display_Rect.Height);
            }
            return (int)(y);
        }

        /// <summary>
        /// 绘制时间滚动条
        /// </summary>
        /// <param name="g"></param>
        /// <param name="scroll_obj">时间滚动条对象</param>
        /// <param name="scroll_back_pen">滚动条背景画笔</param>
        /// <param name="scroll_slide_pen">滚动条滑块画笔</param>
        private void DrawTimeScroll(Graphics g, TimeAreaScrollClass scroll_obj, Pen scroll_back_pen, Pen scroll_slide_pen)
        {
            if (scroll_obj.Scroll_Back_Rect.Height > scroll_obj.Scroll_Slide_Rect.Height)
            {
                // 滚动条背景
                PointF scroll_start_point = new PointF(scroll_obj.Scroll_Back_Rect.X + scroll_back_pen.Width / 2f, scroll_obj.Scroll_Back_Rect.Y);
                PointF scroll_end_point = new PointF(scroll_obj.Scroll_Back_Rect.X + scroll_back_pen.Width / 2f, scroll_obj.Scroll_Back_Rect.Bottom);
                g.DrawLine(scroll_back_pen, scroll_start_point, scroll_end_point);

                //  滚动条滑块
                PointF scroll_slide_start_point = new PointF(scroll_obj.Scroll_Slide_Rect.X + scroll_back_pen.Width / 2f, scroll_obj.Scroll_Slide_Rect.Y);
                PointF scroll_slide_end_point = new PointF(scroll_obj.Scroll_Slide_Rect.X + scroll_back_pen.Width / 2f, scroll_obj.Scroll_Slide_Rect.Bottom);
                g.DrawLine(scroll_slide_pen, scroll_slide_start_point, scroll_slide_end_point);
            }
        }

        /// <summary>
        /// 上一年
        /// </summary>
        /// <param name="e"></param>
        private void TopBarPrevYearClick()
        {
            if (this.DateFormat == DateFormats.yyyy)
            {
                this.dateBody.current_display_year -= 12;
            }
            else
            {
                this.dateBody.current_display_year -= 1;
            }
            if (this.dateBody.current_display_year < 1)
            {
                this.dateBody.current_display_year = 1;
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 上一月
        /// </summary>
        /// <param name="e"></param>
        private void TopBarPrevMonthClick()
        {
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Day))
            {
                DateTime tmp = new DateTime(this.dateBody.current_display_year, this.dateBody.current_display_month, 1).AddMonths(-1);
                this.dateBody.current_display_month = tmp.Month;
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 年月切换面板
        /// </summary>
        /// <param name="e"></param>
        private void TopBarYearMonthClick()
        {
            if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year)
            {
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonth_Month);
            }
            else
            {
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonth_Year);
            }

            this.Invalidate();
        }
        /// <summary>
        /// 显示月面板
        /// </summary>
        /// <param name="e"></param>
        private void TopBarMonthClick()
        {
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Day))
            {
                if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month)
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
                }
                else
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Month);
                }
            }

            this.Invalidate();
        }
        /// <summary>
        /// 显示年面板
        /// </summary>
        /// <param name="e"></param>
        private void TopBarYearClick()
        {
            if (this.IsContainEmbodyForCurrentFormat(DateElement.Day))
            {
                if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year)
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
                }
                else
                {
                    this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Year);
                }
            }

            this.Invalidate();
        }
        /// <summary>
        /// 下一月
        /// </summary>
        /// <param name="e"></param>
        private void TopBarNextMonthClick()
        {
            DateTime tmp = new DateTime(this.dateBody.current_display_year, this.dateBody.current_display_month, 1).AddMonths(1);
            this.dateBody.current_display_month = tmp.Month;

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 下一年
        /// </summary>
        /// <param name="e"></param>
        private void TopBarNextYearClick()
        {
            if (this.DateFormat == DateFormats.yyyy)
            {
                this.dateBody.current_display_year += 12;
            }
            else
            {
                this.dateBody.current_display_year += 1;
            }
            if (this.dateBody.current_display_year > 9999)
            {
                this.dateBody.current_display_year = 9999;
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 年面板年选项单击
        /// </summary>
        /// <param name="e"></param>
        private void YearMainItemClick(DateItemClass e)
        {
            if (this.currentDateFormatsViews == DateFormatsViews.Year_Year)
            {
                this.dateBody.selected_year = int.Parse(e.Value.Substring(2, 4));
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Year)
            {
                this.dateBody.current_display_year = int.Parse(e.Value.Substring(2, 4));
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonth_Month);
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Year)
            {
                this.dateBody.current_display_year = int.Parse(e.Value.Substring(2, 4));
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 月面板月选项单击
        /// </summary>
        /// <param name="e"></param>
        private void MonthMainItemClick(DateItemClass e)
        {
            if (this.currentDateFormatsViews == DateFormatsViews.YearMonth_Month)
            {
                this.dateBody.selected_year = int.Parse(e.Value.Substring(2, 4));
                this.dateBody.selected_month = int.Parse(e.Value.Substring(6, 2));
            }
            else if (this.currentDateFormatsViews == DateFormatsViews.YearMonthDay_Month)
            {
                this.dateBody.current_display_month = int.Parse(e.Value.Substring(6, 2));
                this.SetCurrentDateFormatsViews(DateFormatsViews.YearMonthDay_Day);
            }

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }
        /// <summary>
        /// 日月面板日选项单击
        /// </summary>
        /// <param name="e"></param>
        private void DayMainItemClick(DateItemClass e)
        {
            this.dateBody.selected_year = int.Parse(e.Value.Substring(2, 4));
            this.dateBody.selected_month = int.Parse(e.Value.Substring(6, 2));
            this.dateBody.selected_day = int.Parse(e.Value.Substring(8, 2));

            this.UpdateTopText();
            this.UpdateYearMonthDayText();
            this.Invalidate();
        }

        #endregion

        #region 类

        /// <summary>
        /// 日期存放信息
        /// </summary>]
        internal class DateBodyClass
        {
            public DateBodyClass()
            {
                this.TopBar_prev_year_btn = new TopBarItemClass();
                this.TopBar_prev_month_btn = new TopBarItemClass();
                this.TopBar_yearscope_btn = new TopBarItemClass();
                this.TopBar_monthyear_btn = new TopBarItemClass();
                this.TopBar_month_btn = new TopBarItemClass();
                this.TopBar_year_btn = new TopBarItemClass();
                this.TopBar_next_month_btn = new TopBarItemClass();
                this.TopBar_next_year_btn = new TopBarItemClass();
                this.Bottombar_minmaxborder_lab = new BottomBarItemClass();
                this.Bottombar_mindate_lab = new BottomBarItemClass();
                this.Bottombar_maxdate_lab = new BottomBarItemClass();

                this.YearMain_itemArr = new DateItemClass[12];
                for (int i = 0; i < this.YearMain_itemArr.Length; i++)
                {
                    this.YearMain_itemArr[i] = new DateItemClass();
                }

                this.MonthMain_itemArr = new DateItemClass[12];
                for (int i = 0; i < this.MonthMain_itemArr.Length; i++)
                {
                    this.MonthMain_itemArr[i] = new DateItemClass();
                }

                string[] days_titles = new string[] { "日", "一", "二", "三", "四", "五", "六" };
                this.DayMain_titleArr = new DayTitleItemClass[days_titles.Length];
                for (int i = 0; i < this.DayMain_titleArr.Length; i++)
                {
                    this.DayMain_titleArr[i] = new DayTitleItemClass() { Text = days_titles[i] };
                }

                this.DayMain_itemArr = new DateItemClass[42];
                for (int i = 0; i < this.DayMain_itemArr.Length; i++)
                {
                    this.DayMain_itemArr[i] = new DateItemClass();
                }

                this.TimeMain_HourArea = new TimeAreaClass(24);
                this.TimeMain_MinuteArea = new TimeAreaClass(60);
                this.TimeMain_SecondArea = new TimeAreaClass(60);

                this.Bottombar_clear_btn = new BottomBarItemClass() { Text = "清除" };
                this.Bottombar_now_btn = new BottomBarItemClass() { Text = "现在" };
                this.Bottombar_confirm_btn = new BottomBarItemClass() { Text = "确认" };

                this.current_display_year = -1;
                this.current_display_month = -1;
            }

            #region 顶部工具栏

            /// <summary>
            /// 顶部工具栏rect
            /// </summary>
            public Rectangle TopBar_Rect { get; set; }

            /// <summary>
            /// 顶部工具栏日期rect
            /// </summary>
            public Rectangle TopBar_Date_Rect { get; set; }
            /// <summary>
            /// 顶部工具栏.上一年按钮
            /// </summary>
            internal TopBarItemClass TopBar_prev_year_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.上一月按钮
            /// </summary>
            internal TopBarItemClass TopBar_prev_month_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.年范围描述
            /// </summary>
            internal TopBarItemClass TopBar_yearscope_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.年、月面板年按钮
            /// </summary>
            internal TopBarItemClass TopBar_monthyear_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.月按钮
            /// </summary>
            internal TopBarItemClass TopBar_month_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.年按钮
            /// </summary>
            internal TopBarItemClass TopBar_year_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.下一月按钮
            /// </summary>
            internal TopBarItemClass TopBar_next_month_btn { get; set; }
            /// <summary>
            /// 顶部工具栏.下一年按钮
            /// </summary>
            internal TopBarItemClass TopBar_next_year_btn { get; set; }

            /// <summary>
            /// 顶部工具栏时间rect
            /// </summary>
            public Rectangle TopBar_Time_Rect { get; set; }
            /// <summary>
            ///  时标题rect
            /// </summary>
            public Rectangle TopBar_hour_rect { get; set; }
            /// <summary>
            ///  分标题rect
            /// </summary>
            public Rectangle TopBar_minute_rect { get; set; }
            /// <summary>
            ///  秒标题rect
            /// </summary>
            public Rectangle TopBar_second_rect { get; set; }

            #endregion

            #region 主面板

            /// <summary>
            /// 主面板.rect
            /// </summary>
            public Rectangle MainBar_Rect { get; set; }

            /// <summary>
            /// 年面板.rect
            /// </summary>
            public Rectangle YearMain_Rect { get; set; }
            /// <summary>
            /// 年面板.选项列表
            /// </summary>
            internal DateItemClass[] YearMain_itemArr { get; set; }

            /// <summary>
            /// 月面板.rect
            /// </summary>
            public Rectangle MonthMain_Rect { get; set; }
            /// <summary>
            /// 月面板.选项列表
            /// </summary>
            internal DateItemClass[] MonthMain_itemArr { get; set; }

            /// <summary>
            /// 日面板.rect
            /// </summary>
            internal Rectangle DayMain_Rect { get; set; }
            /// <summary>
            /// 日面板.标题列表
            /// </summary>
            internal DayTitleItemClass[] DayMain_titleArr { get; set; }
            /// <summary>
            /// 日面板.选项列表
            /// </summary>
            internal DateItemClass[] DayMain_itemArr { get; set; }

            /// <summary>
            ///  时间面板rect
            /// </summary>
            public Rectangle TimeMain_Rect { get; set; }
            /// <summary>
            /// 时间面板时区域
            /// </summary>
            internal TimeAreaClass TimeMain_HourArea { get; set; }
            /// <summary>
            /// 时间面板分区域
            /// </summary>
            internal TimeAreaClass TimeMain_MinuteArea { get; set; }
            /// <summary>
            /// 时间面板秒区域
            /// </summary>
            internal TimeAreaClass TimeMain_SecondArea { get; set; }

            #endregion

            #region 底部工具栏
            /// <summary>
            /// 底部工具栏rect
            /// </summary>
            public Rectangle BottomBar_Rect { get; set; }
            /// <summary>
            /// 底部工具栏最小时间最大时间线
            /// </summary>
            internal BottomBarItemClass Bottombar_minmaxborder_lab { get; set; }
            /// <summary>
            /// 底部工具栏最小时间文本
            /// </summary>
            internal BottomBarItemClass Bottombar_mindate_lab { get; set; }
            /// <summary>
            /// 底部工具栏最大时间文本
            /// </summary>
            internal BottomBarItemClass Bottombar_maxdate_lab { get; set; }
            /// <summary>
            /// 底部工具栏清除按钮
            /// </summary>
            internal BottomBarItemClass Bottombar_clear_btn { get; set; }
            /// <summary>
            /// 底部工具栏现在按钮
            /// </summary>
            internal BottomBarItemClass Bottombar_now_btn { get; set; }
            /// <summary>
            /// 底部工具栏确认按钮
            /// </summary>
            internal BottomBarItemClass Bottombar_confirm_btn { get; set; }

            #endregion

            #region 临时存放

            /// <summary>
            /// 已选择年
            /// </summary>
            public int selected_year { get; set; }
            /// <summary>
            /// 已选择月
            /// </summary>
            public int selected_month { get; set; }
            /// <summary>
            /// 已选择日
            /// </summary>
            public int selected_day { get; set; }
            /// <summary>
            /// 已选择时
            /// </summary>
            public int selected_hour { get; set; }
            /// <summary>
            /// 已选择分
            /// </summary>
            public int selected_minute { get; set; }
            /// <summary>
            /// 已选择秒
            /// </summary>
            public int selected_second { get; set; }

            /// <summary>
            /// 当前年份面板(画面上切换到指定年份的日期提供用户选择)
            /// </summary>
            public int current_display_year { get; set; }
            /// <summary>
            /// 当前月份面板(画面上切换到指定月份的日期提供用户选择)
            /// </summary>
            public int current_display_month { get; set; }

            #endregion
        }

        /// <summary>
        /// 顶部工具栏面板选项
        /// </summary>
        internal class TopBarItemClass
        {
            /// <summary>
            /// 顶部工具栏选项rect
            /// </summary>
            public Rectangle Rect { get; set; }

            /// <summary>
            /// 顶部工具栏选项文本
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// 顶部工具栏选项按钮图形路径
            /// </summary>
            public Point[] LineLeftPointArr { get; set; }

            /// <summary>
            /// 顶部工具栏选项按钮图形路径
            /// </summary>
            public Point[] LineRightPointArr { get; set; }

        }

        /// <summary>
        /// 年、月、日 选项
        /// </summary>
        internal class DateItemClass
        {
            public DateItemClass()
            {
                this.DayItemType = DayItemTypes.Normal;
            }

            /// <summary>
            /// 选项rect
            /// </summary>]
            public Rectangle Rect { get; set; }

            /// <summary>
            /// 年、月、日 选项值(存储格式：[10yyyy]、[10yyyyMM]、[10yyyyMMdd] )
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// 日选项类型(只适用日选项)
            /// </summary>
            internal DayItemTypes DayItemType { get; set; }
        }

        /// <summary>
        /// 日期标题
        /// </summary>
        internal class DayTitleItemClass
        {
            /// <summary>
            /// 日标题.rect
            /// </summary>]
            public Rectangle Rect { get; set; }

            /// <summary>
            /// 日标题.文本
            /// </summary>
            public string Text { get; set; }

        }

        /// <summary>
        /// 时间面板指定区域
        /// </summary>
        internal class TimeAreaClass
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="itemcount">选项数量</param>
            public TimeAreaClass(int itemcount)
            {
                this.itemArr = new TimeAreaItemClass[itemcount];
                for (int i = 0; i < this.itemArr.Length; i++)
                {
                    this.itemArr[i] = new TimeAreaItemClass() { Value = i };
                }
                this.Scroll = new TimeAreaScrollClass();
            }

            /// <summary>
            ///  区域Rect
            /// </summary>
            public RectangleF Rect { get; set; }

            /// <summary>
            /// 区域选项列表
            /// </summary>
            internal TimeAreaItemClass[] itemArr { get; set; }

            /// <summary>
            /// 区域滚动条
            /// </summary>
            internal TimeAreaScrollClass Scroll { get; set; }
        }

        /// <summary>
        /// 时间选项
        /// </summary>
        internal class TimeAreaItemClass
        {
            /// <summary>
            /// 选项rect
            /// </summary>
            public Rectangle Rect { get; set; }

            /// <summary>
            /// 选项值
            /// </summary>
            public int Value { get; set; }
        }

        /// <summary>
        /// 时间滚动条
        /// </summary>
        internal class TimeAreaScrollClass
        {
            #region 属性

            /// <summary>
            /// 滚动条背景.rect
            /// </summary>
            public RectangleF Scroll_Back_Rect { get; set; }

            /// <summary>
            /// 滚动条滑块.rect
            /// </summary>
            public RectangleF Scroll_Slide_Rect { get; set; }

            /// <summary>
            /// 内容显示区rect
            /// </summary>
            public RectangleF Owner_Display_Rect { get; set; }

            /// <summary>
            /// 内容真实区rect
            /// </summary>
            public RectangleF Owner_Content_Rect { get; set; }

            #endregion

            #region 公开方法

            /// <summary>
            /// 判断是否需要更新滚动条UI根据滚动条滑块偏移量
            /// </summary>
            /// <param name="offset">滚动条滑块偏移量</param>
            /// <returns>是否要刷新</returns>
            public bool IsResetScrollByOffset(int offset)
            {
                float y = this.Scroll_Slide_Rect.Y + offset;
                if (y < this.Scroll_Back_Rect.Y)
                    y = this.Scroll_Back_Rect.Y;
                if (y > this.Scroll_Back_Rect.Bottom - this.Scroll_Slide_Rect.Height)
                    y = this.Scroll_Back_Rect.Bottom - this.Scroll_Slide_Rect.Height;

                if (this.Scroll_Slide_Rect.Y != y)
                {
                    this.Scroll_Slide_Rect = new RectangleF(this.Scroll_Slide_Rect.X, y, this.Scroll_Slide_Rect.Width, this.Scroll_Slide_Rect.Height);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            #endregion
        }

        /// <summary>
        /// 底部工具栏面板选项
        /// </summary>
        internal class BottomBarItemClass
        {
            /// <summary>
            /// 底部工具栏选项rect
            /// </summary>
            public Rectangle Rect { get; set; }

            /// <summary>
            ///底部工具栏选项文本
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// 底部工具栏选项按钮图形路径
            /// </summary>
            public Point[] LinePointArr { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 组成日期的元素
        /// </summary>
        internal enum DateElement
        {
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 月
            /// </summary>
            Month,
            /// <summary>
            /// 日
            /// </summary>
            Day,
            /// <summary>
            /// 时
            /// </summary>
            Hour,
            /// <summary>
            /// 分
            /// </summary>
            Minute,
            /// <summary>
            /// 秒
            /// </summary>
            Second
        }

        /// <summary>
        /// 日期显示格式 
        /// </summary>
        public enum DateFormats
        {
            /// <summary>
            /// 年
            /// </summary>
            yyyy,
            /// <summary>
            /// 年月
            /// </summary>
            yyyyMM,
            /// <summary>
            /// 年月日
            /// </summary>
            yyyyMMdd,
            /// <summary>
            /// 年月日时
            /// </summary>
            yyyyMMddHH,
            /// <summary>
            /// 年月日时分
            /// </summary>
            yyyyMMddHHmm,
            /// <summary>
            /// 年月日时分秒
            /// </summary>
            yyyyMMddHHmmss
        }

        /// <summary>
        /// 在指定显示功能类型下面板显示状态
        /// </summary>
        internal enum DateFormatsViews
        {
            /// <summary>
            /// 年功能中(年面板)
            /// </summary>
            Year_Year,
            /// <summary>
            /// 年月功能中(年面板)
            /// </summary>
            YearMonth_Year,
            /// <summary>
            /// 年月功能中(月面板)
            /// </summary>
            YearMonth_Month,
            /// <summary>
            /// 年月日功能中(年面板)
            /// </summary>
            YearMonthDay_Year,
            /// <summary>
            /// 年月日功能中(月面板)
            /// </summary>
            YearMonthDay_Month,
            /// <summary>
            /// 年月日功能中(日面板)
            /// </summary>
            YearMonthDay_Day
        }

        /// <summary>
        /// 日选项类型
        /// </summary>
        internal enum DayItemTypes
        {
            /// <summary>
            /// 不在最大最小值范围的日期
            /// </summary>
            Disabled,
            /// <summary>
            /// 在日期最大最小值范围,但非本月的日期
            /// </summary>
            UnCurrent,
            /// <summary>
            /// 在日期最大最小值范围,本月的日期
            /// </summary>
            Normal
        }

        #endregion
    }

}
