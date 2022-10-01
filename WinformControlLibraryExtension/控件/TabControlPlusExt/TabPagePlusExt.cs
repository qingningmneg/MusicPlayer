
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
using System.Collections;
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
    /// TabPagePlusExt(TabPage增强版)
    /// </summary>
    [Description("TabPagePlusExt(TabPage增强版)")]
    [ToolboxItem(false)]
    [DefaultProperty("Text")]
    [Designer(typeof(TabPagePlusExtDesigner))]
    public class TabPagePlusExt : Panel
    {
        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler AutoSizeChanged
        {
            add
            {
                base.AutoSizeChanged += value;
            }
            remove
            {
                base.AutoSizeChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DockChanged
        {
            add
            {
                base.DockChanged += value;
            }
            remove
            {
                base.DockChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add
            {
                base.MarginChanged += value;
            }
            remove
            {
                base.MarginChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Resize
        {
            add
            {
                base.Resize += value;
            }
            remove
            {
                base.Resize -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Move
        {
            add
            {
                base.Move += value;
            }
            remove
            {
                base.Move -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler LocationChanged
        {
            add
            {
                base.LocationChanged += value;
            }
            remove
            {
                base.LocationChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add
            {
                base.TabIndexChanged += value;
            }
            remove
            {
                base.TabIndexChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add
            {
                base.TabStopChanged += value;
            }
            remove
            {
                base.TabStopChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add
            {
                base.FontChanged += value;
            }
            remove
            {
                base.FontChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add
            {
                base.ForeColorChanged += value;
            }
            remove
            {
                base.ForeColorChanged -= value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler VisibleChanged
        {
            add
            {
                base.VisibleChanged += value;
            }
            remove
            {
                base.VisibleChanged -= value;
            }
        }

        #endregion

        #region 新增事件

        #region TabItem图标

        public delegate void TabItemIcoDrawAfterEventHandler(object sender, TabItemIcoDrawAfterEventArgs e);
        private event TabItemIcoDrawAfterEventHandler tabItemIcoDrawAfter;
        /// <summary>
        /// TabItem图标绘制后事件
        /// </summary>
        [Description("TabItem图标绘制后事件")]
        [Category("杂项_选项图标")]
        public event TabItemIcoDrawAfterEventHandler TabItemIcoDrawAfter
        {
            add { this.tabItemIcoDrawAfter += value; }
            remove { this.tabItemIcoDrawAfter -= value; }
        }

        #endregion

        #region TabItem关闭按钮

        public delegate void TabItemCloseButtonCloseingEventHandler(object sender, TabItemCloseButtonCloseingEventArgs e);
        private event TabItemCloseButtonCloseingEventHandler tabItemCloseButtonCloseing;
        /// <summary>
        /// TabItem关闭时事件
        /// </summary>
        [Description("TabItem关闭时事件")]
        [Category("杂项_选项关闭按钮")]
        public event TabItemCloseButtonCloseingEventHandler TabItemCloseButtonCloseing
        {
            add { this.tabItemCloseButtonCloseing += value; }
            remove { this.tabItemCloseButtonCloseing -= value; }
        }

        public delegate void TabCloseButtonClosedEventHandler(object sender, TabItemCloseButtonClosedEventArgs e);
        private event TabCloseButtonClosedEventHandler tabItemCloseButtonClosed;
        /// <summary>
        /// TabItem关闭后事件
        /// </summary>
        [Description("TabItem关闭后事件")]
        [Category("杂项_选项关闭按钮")]
        public event TabCloseButtonClosedEventHandler TabItemCloseButtonClosed
        {
            add { this.tabItemCloseButtonClosed += value; }
            remove { this.tabItemCloseButtonClosed -= value; }
        }

        public delegate void TabItemCloseButtonDrawEventHandler(object sender, TabItemCloseButtonDrawBeforeEventArgs e);
        private event TabItemCloseButtonDrawEventHandler tabItemCloseButtonDrawBefore;
        /// <summary>
        /// TabItem关闭按钮绘制前事件
        /// </summary>
        [Description("TabItem关闭按钮绘制前事件")]
        [Category("杂项_选项关闭按钮")]
        public event TabItemCloseButtonDrawEventHandler TabItemCloseButtonDrawBefore
        {
            add { this.tabItemCloseButtonDrawBefore += value; }
            remove { this.tabItemCloseButtonDrawBefore -= value; }
        }

        #endregion

        #endregion

        #region 新增属性

        #region TabItem

        private bool tabItemEnabled = true;
        /// <summary>
        /// TabItem启用状态
        /// </summary>
        [Description("TabItem启用状态")]
        [Category("杂项_选项")]
        [DefaultValue(true)]
        public bool TabItemEnabled
        {
            get { return this.tabItemEnabled; }
            set
            {
                if (this.tabItemEnabled == value)
                    return;

                this.tabItemEnabled = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.OnTabItemEnabledChanged(new TabControlPlusExt.TabItemOperatedEventArgs(this));
                    tabControl.Invalidate();
                }
            }
        }

        private TabItemAutoWidthMode tabItemAutoWidth = TabItemAutoWidthMode.Auto;
        /// <summary>
        /// TabItem是否为自动宽度
        /// </summary>
        [Description("TabItem是否为自动宽度")]
        [Category("杂项_选项")]
        [DefaultValue(TabItemAutoWidthMode.Auto)]
        public TabItemAutoWidthMode TabItemAutoWidth
        {
            get { return this.tabItemAutoWidth; }
            set
            {
                if (this.tabItemAutoWidth == value)
                    return;

                this.tabItemAutoWidth = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }
        }

        private int tabItemAutoWidthMin = -1;
        /// <summary>
        /// TabItem自动宽度最小宽度(-1表示采用通用设置)
        /// </summary>
        [Description("TabItem自动宽度最小宽度(-1表示采用通用设置)")]
        [Category("杂项_选项")]
        [DefaultValue(-1)]
        public int TabItemAutoWidthMin
        {
            get { return this.tabItemAutoWidthMin; }
            set
            {
                if (this.tabItemAutoWidthMin == value || value < -1)
                    return;

                this.tabItemAutoWidthMin = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }
        }

        private int tabItemFixedWidth = -1;
        /// <summary>
        /// TabItem固定宽度(-1表示采用通用设置)
        /// </summary>
        [Description("TabItem固定宽度(-1表示采用通用设置)")]
        [Category("杂项_选项")]
        [DefaultValue(-1)]
        public int TabItemFixedWidth
        {
            get { return this.tabItemFixedWidth; }
            set
            {
                if (this.tabItemFixedWidth == value || value < -1)
                    return;

                this.tabItemFixedWidth = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }
        }

        private BackGauge tabItemMargin = new BackGauge(-1, -1);
        /// <summary>
        /// TabItem外边距(-1, -1表示采用通用设置)
        /// </summary>
        [Description("TabItem外边距(-1, -1表示采用通用设置)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(BackGauge), "-1, -1")]
        public BackGauge TabItemMargin
        {
            get { return this.tabItemMargin; }
            set
            {
                if (this.tabItemMargin == value || value.Left < -1 || value.Right < -1)
                    return;

                this.tabItemMargin = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }
        }

        private BackGauge tabItemPadding = new BackGauge(-1, -1);
        /// <summary>
        /// TabItem内边距(-1, -1表示采用通用设置)
        /// </summary>
        [Description("TabItem内边距(-1, -1表示采用通用设置)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(BackGauge), "-1, -1")]
        public BackGauge TabItemPadding
        {
            get { return this.tabItemPadding; }
            set
            {
                if (this.tabItemPadding == value || value.Left < -1 || value.Right < -1)
                    return;

                this.tabItemPadding = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }
        }

        private bool tabItemTextVerticalLayout = false;
        /// <summary>
        /// TabItem文本是否垂直布局(限于左右两边)
        /// </summary>
        [Description("TabItem文本是否垂直布局(限于左右两边)")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemTextVerticalLayout
        {
            get { return this.tabItemTextVerticalLayout; }
            set
            {
                if (this.tabItemTextVerticalLayout == value)
                    return;

                this.tabItemTextVerticalLayout = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    if (tabControl.MenuBarAlignment == TabControlPlusExt.MenuBarAlignments.Left || tabControl.MenuBarAlignment == TabControlPlusExt.MenuBarAlignments.Right)
                    {
                        tabControl.InitializeRectangle();
                        tabControl.Invalidate();
                    }
                }
            }
        }

        private bool tabItemTextEllipsisCharacter = false;
        /// <summary>
        /// TabItem文本超出范围是否使用省略号代替
        /// </summary>
        [Description("TabItem文本超出范围是否使用省略号代替")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemTextEllipsisCharacter
        {
            get { return this.tabItemTextEllipsisCharacter; }
            set
            {
                if (this.tabItemTextEllipsisCharacter == value)
                    return;

                this.tabItemTextEllipsisCharacter = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemBackNormalColor = Color.Empty;
        /// <summary>
        /// TabItem背景颜色(正常)
        /// </summary>
        [Description("TabItem背景颜色(正常)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemBackNormalColor
        {
            get { return this.tabItemBackNormalColor; }
            set
            {
                if (this.tabItemBackNormalColor == value)
                    return;

                this.tabItemBackNormalColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemBackEnterColor = Color.Empty;
        /// <summary>
        /// TabItem背景颜色(鼠标进入)
        /// </summary>
        [Description("TabItem背景颜色(鼠标进入)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemBackEnterColor
        {
            get { return this.tabItemBackEnterColor; }
            set
            {
                if (this.tabItemBackEnterColor == value)
                    return;

                this.tabItemBackEnterColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemBackSelectedColor = Color.Empty;
        /// <summary>
        /// TabItem背景颜色(选中)
        /// </summary>
        [Description("TabItem背景颜色(选中)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemBackSelectedColor
        {
            get { return this.tabItemBackSelectedColor; }
            set
            {
                if (this.tabItemBackSelectedColor == value)
                    return;

                this.tabItemBackSelectedColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemBackDisableColor = Color.Empty;
        /// <summary>
        /// TabItem背景颜色(禁用)
        /// </summary>
        [Description("TabItem背景颜色(禁用)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemBackDisableColor
        {
            get { return this.tabItemBackDisableColor; }
            set
            {
                if (this.tabItemBackDisableColor == value)
                    return;

                this.tabItemBackDisableColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemTextNormalColor = Color.Empty;
        /// <summary>
        /// TabItem文本颜色(正常)
        /// </summary>
        [Description("TabItem文本颜色(正常)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemTextNormalColor
        {
            get { return this.tabItemTextNormalColor; }
            set
            {
                if (this.tabItemTextNormalColor == value)
                    return;

                this.tabItemTextNormalColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemTextEnterColor = Color.Empty;
        /// <summary>
        /// TabItem文本颜色(鼠标进入)
        /// </summary>
        [Description("TabItem文本颜色(鼠标进入)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemTextEnterColor
        {
            get { return this.tabItemTextEnterColor; }
            set
            {
                if (this.tabItemTextEnterColor == value)
                    return;

                this.tabItemTextEnterColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemTextSelectedColor = Color.Empty;
        /// <summary>
        /// TabItem文本颜色(选中)
        /// </summary>
        [Description("TabItem文本颜色(选中)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemTextSelectedColor
        {
            get { return this.tabItemTextSelectedColor; }
            set
            {
                if (this.tabItemTextSelectedColor == value)
                    return;

                this.tabItemTextSelectedColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        private Color tabItemTextDisableColor = Color.Empty;
        /// <summary>
        /// TabItem文本颜色(禁用)
        /// </summary>
        [Description("TabItem文本颜色(禁用)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "")]
        public Color TabItemTextDisableColor
        {
            get { return this.tabItemTextDisableColor; }
            set
            {
                if (this.tabItemTextDisableColor == value)
                    return;

                this.tabItemTextDisableColor = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }
            }
        }

        #endregion

        #region TabItem图标

        private TabItemIcoVisibles tabItemIcoVisible = TabItemIcoVisibles.Auto;
        /// <summary>
        /// TabItem图标是否显示
        /// </summary>
        [Description("TabItem图标是否显示")]
        [Category("杂项_图标")]
        [DefaultValue(TabItemIcoVisibles.Auto)]
        public TabItemIcoVisibles TabItemIcoVisible
        {
            get { return this.tabItemIcoVisible; }
            set
            {
                if (this.tabItemIcoVisible == value)
                    return;

                this.tabItemIcoVisible = value;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }

            }
        }

        private Image tabItemIcoImage = null;
        /// <summary>
        /// TabItem图标
        /// </summary>
        [Description("TabItem图标")]
        [Category("杂项_图标")]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image TabItemIcoImage
        {
            get { return this.tabItemIcoImage; }
            set
            {
                if (this.tabItemIcoImage == value)
                    return;

                this.tabItemIcoImage = value;
                this.tabItemIcoImageDisable = null;
                if (this.Parent != null && this.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                    tabControl.Invalidate();
                }

            }
        }

        private Image tabItemIcoImageDisable = null;
        /// <summary>
        /// TabItem图标(禁用)
        /// </summary>
        [Description("TabItem图标(禁用)")]
        [Category("杂项_图标")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image TabItemIcoImageDisable
        {
            get
            {
                if (this.tabItemIcoImageDisable == null && this.tabItemIcoImage != null)
                {
                    this.tabItemIcoImageDisable = ImageCommom.CreateDisabledImage(this.tabItemIcoImage);
                }
                return this.tabItemIcoImageDisable;
            }
        }

        #endregion

        #region TabItem自定义按钮

        private TabItemCustomButtonCollection tabItemCustomButtonCollection;
        /// <summary>
        /// TabItem自定义按钮集合
        /// </summary>
        [Description("TabItem自定义按钮集合")]
        [Category("杂项_自定义按钮")]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabItemCustomButtonCollection TabItemCustomButtons
        {
            get
            {
                if (this.tabItemCustomButtonCollection == null)
                    this.tabItemCustomButtonCollection = new TabItemCustomButtonCollection(this);
                return this.tabItemCustomButtonCollection;
            }
        }

        #endregion

        #region TabItem关闭按钮

        private TabItemCloseButtonClass tabItemCloseButton;
        /// <summary>
        /// TabItem关闭按钮
        /// </summary>
        [Description("TabItem关闭按钮")]
        [Category("杂项_关闭按钮")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabItemCloseButtonClass TabItemCloseButton
        {
            get
            {
                if (this.tabItemCloseButton == null)
                    this.tabItemCloseButton = new TabItemCloseButtonClass(this);
                return this.tabItemCloseButton;
            }
        }

        #endregion

        #region 用于临时存储运行信息

        /// <summary>
        /// 选项rect（包含:外边距、内边距、内容）
        /// </summary>
        [Description("选项rect（包含:外边距、内边距、内容）")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF M_Rect { get; set; }

        /// <summary>
        /// 选项rect（包含:内边距、内容）
        /// </summary>
        [Description("选项rect（包含:内边距、内容）")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF P_Rect { get; set; }

        /// <summary>
        /// 选项rect（只包含:内容）
        /// </summary>
        [Description("选项rect（只包含:内容）")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF C_Rect { get; set; }

        /// <summary>
        /// 选项Size（只包含:内容）
        /// </summary>
        [Description("选项Size（只包含:内容）")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Size Rect_C_Size { get; set; }

        /// <summary>
        /// 选项GraphicsPath(一般用选项的NoClipPaddingBounds范围生成)
        /// </summary>
        [Description("选项GraphicsPath(一般用选项的NoClipPaddingBounds范围生成)")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal GraphicsPath P_GP { get; set; }

        #region 图标

        /// <summary>
        /// 选项图标Size
        /// </summary>
        [Description("选项图标Size")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Size Ico_C_Size { get; set; }

        /// <summary>
        /// 选项图标rect(不包括内外边距)
        /// </summary>
        [Description("选项图标rect(不包括内外边距)")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF Ico_C_Rect { get; set; }

        /// <summary>
        /// 选项图标rect(包括外边距)
        /// </summary>
        [Description("选项图标rect(包括外边距)")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF Ico_M_Rect { get; set; }

        #endregion

        #region 文本

        /// <summary>
        /// 下拉框选项文本Size
        /// </summary>
        [Description("下拉框选项文本Size")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Size Text_DropDown_Size { get; set; }

        /// <summary>
        /// 选项文本Size
        /// </summary>
        [Description("选项文本Size")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal SizeF Text_C_Size { get; set; }

        /// <summary>
        /// 选项文本rect(排除外边距、边框、内边距)
        /// </summary>
        [Description("选项文本rect(排除外边距、边框、内边距)")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF Text_C_Rect { get; set; }

        private string textVerticalLayoutTmp = "";
        /// <summary>
        /// 文本的垂直布局字符串
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextVerticalLayoutTmp
        {
            get { return this.textVerticalLayoutTmp; }
        }

        #endregion

        /// <summary>
        /// 选项鼠标状态
        /// </summary>
        [Description("选项鼠标状态")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal TabControlPlusExt.MouseStatuss MouseStatus { get; set; }

        #region 下拉面板

        private DropDownPanelItemMouseStatuss dropDownPanelItem_mouseStatus = DropDownPanelItemMouseStatuss.Normal;
        /// <summary>
        /// 下拉面板选项鼠标状态
        /// </summary>
        [Description("下拉面板选项鼠标状态")]
        [DefaultValue(DropDownPanelItemMouseStatuss.Normal)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal DropDownPanelItemMouseStatuss DropDownPanelItem_MouseStatus
        {
            get { return this.dropDownPanelItem_mouseStatus; }
            set
            {
                if (this.dropDownPanelItem_mouseStatus == value)
                    return;

                this.dropDownPanelItem_mouseStatus = value;
            }
        }

        private RectangleF dropDownPanelItem_Rect = RectangleF.Empty;
        /// <summary>
        /// 下拉面板选项Rect
        /// </summary>
        [Description("下拉面板选项Rect")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RectangleF DropDownPanelItem_Rect
        {
            get { return this.dropDownPanelItem_Rect; }
            set
            {
                if (this.dropDownPanelItem_Rect == value)
                    return;

                this.dropDownPanelItem_Rect = value;
            }
        }


        #endregion
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
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text == value)
                    return;

                base.Text = value;
                this.UpdatVerticalLayoutText();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AutoSizeMode AutoSizeMode
        {
            get { return base.AutoSizeMode; }
            set { base.AutoSizeMode = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Point Location
        {
            get { return base.Location; }
            set { base.Location = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size PreferredSize
        {
            get { return base.PreferredSize; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        #endregion

        #region 构造

        public TabPagePlusExt()
        {
            this.BackColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">TabItem文本</param>
        public TabPagePlusExt(string text) : this()
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">TabItem名称（可用于索引,必须唯一）</param>
        /// <param name="text">TabItem文本</param>
        public TabPagePlusExt(string key, string text) : this()
        {
            this.Name = key;
            this.Text = text;
        }

        #endregion

        #region 重写

        /// <summary>
        /// 重写子控件集合
        /// </summary>
        /// <returns></returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TabPagePlusExtControlsCollection(this);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Parent != null && this.Parent is TabControlPlusExt && this.Parent.IsHandleCreated)
            {
                TabControlPlusExt control = (TabControlPlusExt)this.Parent;
                control.InitializeRectangle();
                control.Invalidate();
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.Parent != null && this.Parent is TabControlPlusExt && this.Parent.IsHandleCreated)
            {
                Rectangle display_rect = ((TabControlPlusExt)this.Parent).PageMainDisplayRectangle;
                base.SetBoundsCore(display_rect.X, display_rect.Y, display_rect.Width, display_rect.Height, BoundsSpecified.All);
            }
            else
            {
                base.SetBoundsCore(x, y, width, height, specified);
            }
        }

        public override string ToString()
        {
            return "TabPagePlusExt: {" + this.Text + "}";
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.P_GP != null)
                {
                    this.P_GP.Dispose();
                }
                if (this.TabItemIcoImage != null)
                {
                    this.TabItemIcoImage = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        //TabItem图标
        internal protected virtual void OnItemIcoDrawAfter(TabItemIcoDrawAfterEventArgs e)
        {
            if (this.tabItemIcoDrawAfter != null && this.Parent != null && this.Parent is TabControlPlusExt)
            {
                Region source_c_region = e.Graphics.Clip;
                Region item_ico_c_region = source_c_region.Clone();//选项图标绘图区(C)
                item_ico_c_region.Intersect(e.TabPage.Ico_C_Rect);
                e.Graphics.Clip = item_ico_c_region;

                this.tabItemIcoDrawAfter(this.Parent, e);

                e.Graphics.Clip = source_c_region;
                item_ico_c_region.Dispose();
            }
        }

        //TabItem关闭按钮
        internal protected virtual void OnTabItemCloseButtonCloseing(TabItemCloseButtonCloseingEventArgs e)
        {
            if (this.tabItemCloseButtonCloseing != null && this.Parent != null && this.Parent is TabControlPlusExt)
            {
                this.tabItemCloseButtonCloseing(this.Parent, e);
            }
        }

        internal protected virtual void OnTabItemCloseButtonClosed(TabItemCloseButtonClosedEventArgs e)
        {
            if (this.tabItemCloseButtonClosed != null && this.Parent != null && this.Parent is TabControlPlusExt)
            {
                this.tabItemCloseButtonClosed(this.Parent, e);
            }
        }

        internal protected virtual void OnTabItemCloseButtonDrawBefore(TabItemCloseButtonDrawBeforeEventArgs e)
        {
            if (this.tabItemCloseButtonDrawBefore != null && this.Parent != null && this.Parent is TabControlPlusExt)
            {
                Region source_c_region = e.Graphics.Clip;
                Region item_close_c_region = source_c_region.Clone();//选项关闭按钮绘图区(C)
                item_close_c_region.Intersect(e.ClipContentBounds);
                e.Graphics.Clip = item_close_c_region;

                this.tabItemCloseButtonDrawBefore(this, e);

                e.Graphics.Clip = source_c_region;
                item_close_c_region.Dispose();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 更新垂直方向文本
        /// </summary>
        private void UpdatVerticalLayoutText()
        {
            string text_tmp = "";
            for (int j = 0; j < this.Text.Length; j++)
            {
                text_tmp += this.Text[j];
                if (j < this.Text.Length - 1)
                {
                    text_tmp += "\r\n";
                }
            }
            this.textVerticalLayoutTmp = text_tmp;

            if (this.Parent != null && this.Parent is TabControlPlusExt)
            {
                TabControlPlusExt tabControl = (TabControlPlusExt)this.Parent;
                tabControl.InitializeRectangle();
                tabControl.Invalidate();
            }
        }

        #endregion

        #region 类

        #region  TabPage

        /// <summary>
        /// TabPagePlusExt子控件集合
        /// </summary>
        [ComVisible(false)]
        public class TabPagePlusExtControlsCollection : Control.ControlCollection
        {
            public TabPagePlusExtControlsCollection(TabPagePlusExt owner) : base(owner)
            {

            }

            public override void Add(Control value)
            {
                if (value is TabPagePlusExt)
                {
                    throw new ArgumentException("TabPagePlusExt的子控件不能为TabPagePlusExt类型");
                }

                base.Add(value);
            }
        }

        #endregion

        #region TabItem自定义按钮

        /// <summary>
        /// TabItem自定义按钮集合
        /// </summary>
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class TabItemCustomButtonCollection : IList, ICollection, IEnumerable
        {
            #region 字段

            /// <summary>
            /// TabItem自定义按钮集合
            /// </summary>
            private ArrayList tabItemCustomButtonList = new ArrayList();

            /// <summary>
            /// 自定义按钮所属TabPage
            /// </summary>
            private TabPagePlusExt owner;

            #endregion

            /// <summary>
            /// 
            /// </summary>
            /// <param name="owner">自定义按钮所属TabPage</param>
            public TabItemCustomButtonCollection(TabPagePlusExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                TabItemCustomButtonClass[] listArray = new TabItemCustomButtonClass[this.tabItemCustomButtonList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (TabItemCustomButtonClass)this.tabItemCustomButtonList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.tabItemCustomButtonList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.tabItemCustomButtonList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            public int Add(object value)
            {
                if (!(value is TabItemCustomButtonClass))
                {
                    throw new ArgumentException("TabItemCustomButtonClass");
                }
                return this.Add((TabItemCustomButtonClass)value);
            }

            public int Add(TabItemCustomButtonClass item)
            {
                item.SetOwner(this.owner);
                this.tabItemCustomButtonList.Add(item);
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
                return this.Count - 1;
            }

            public void Clear()
            {
                this.tabItemCustomButtonList.Clear();
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is TabItemCustomButtonClass)
                {
                    return this.Contains((TabItemCustomButtonClass)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is TabItemCustomButtonClass)
                {
                    return this.tabItemCustomButtonList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is TabItemCustomButtonClass))
                {
                    throw new ArgumentException("TabItemCustomButtonClass");
                }
                this.Remove((TabItemCustomButtonClass)value);
            }

            public void Remove(TabItemCustomButtonClass item)
            {
                this.tabItemCustomButtonList.Remove(item);
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            public void RemoveAt(int index)
            {
                this.tabItemCustomButtonList.RemoveAt(index);
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            public TabItemCustomButtonClass this[int index]
            {
                get
                {
                    return (TabItemCustomButtonClass)this.tabItemCustomButtonList[index];
                }
                set
                {
                    TabItemCustomButtonClass item = (TabItemCustomButtonClass)value;
                    item.SetOwner(this.owner);
                    this.tabItemCustomButtonList[index] = item;
                    if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                    {
                        TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                        tabControl.InitializeRectangle();
                        tabControl.Invalidate();
                    }
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.tabItemCustomButtonList[index];
                }
                set
                {
                    TabItemCustomButtonClass item = (TabItemCustomButtonClass)value;
                    this.tabItemCustomButtonList[index] = item;
                    if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                    {
                        TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                        tabControl.InitializeRectangle();
                        tabControl.Invalidate();
                    }
                }
            }

            #endregion

        }

        /// <summary>
        /// TabItem自定义按钮
        /// </summary>
        [TypeConverter(typeof(EmptyConverter))]
        public class TabItemCustomButtonClass
        {
            #region 新增事件

            public delegate void TabItemCustomButtonEventHandler(object sender, TabItemCustomButttonOperatedEventArgs e);
            private event TabItemCustomButtonEventHandler tabItemCustomButtonClick;
            /// <summary>
            /// TabItem自定义按钮单击事件
            /// </summary>
            [Description("TabItem自定义按钮单击事件")]
            [Category("杂项_选项自定义按钮")]
            public event TabItemCustomButtonEventHandler TabItemCustomButtonClick
            {
                add { this.tabItemCustomButtonClick += value; }
                remove { this.tabItemCustomButtonClick -= value; }
            }

            private event TabItemCustomButtonEventHandler tabItemCustomButtonCheckedChanged;
            /// <summary>
            /// TabItem自定义按钮checked更改事件
            /// </summary>
            [Description("TabItem自定义按钮checked更改事件")]
            [Category("杂项_选项自定义按钮")]
            public event TabItemCustomButtonEventHandler TabItemCustomButtonCheckedChanged
            {
                add { this.tabItemCustomButtonCheckedChanged += value; }
                remove { this.tabItemCustomButtonCheckedChanged -= value; }
            }

            public delegate void TabItemCusomButtonDrawAfterEventHandler(object sender, TabItemCustomButtonDrawAfterEventArgs e);
            private event TabItemCusomButtonDrawAfterEventHandler tabItemCusomButtonDrawAfter;
            /// <summary>
            /// TabItem自定义按钮绘制后事件
            /// </summary>
            [Description("TabItem自定义按钮绘制后事件")]
            [Category("杂项_选项自定义按钮")]
            public event TabItemCusomButtonDrawAfterEventHandler TabItemCusomButtonDrawAfter
            {
                add { this.tabItemCusomButtonDrawAfter += value; }
                remove { this.tabItemCusomButtonDrawAfter -= value; }
            }

            #endregion

            #region 字段

            /// <summary>
            /// TabItem自定义按钮所属TabPage
            /// </summary>
            private TabPagePlusExt owner;

            #endregion

            #region 属性

            private string name = "";
            /// <summary>
            /// 按钮名称
            /// </summary>
            [Description("按钮名称")]
            [DefaultValue("")]
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name == value)
                        return;

                    this.name = value;
                }
            }

            private bool visible = true;
            /// <summary>
            /// 按钮是否显示
            /// </summary>
            [Description("按钮是否显示")]
            [DefaultValue(true)]
            public bool Visible
            {
                get { return this.visible; }
                set
                {
                    if (this.visible == value)
                        return;

                    this.visible = value;
                    this.InitializeInvalidate();
                }
            }

            private bool enabled = true;
            /// <summary>
            /// 按钮使用状态
            /// </summary>
            [Description("按钮使用状态")]
            [DefaultValue(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.Invalidate();
                }
            }

            private bool checkButton = false;
            /// <summary>
            /// 按钮是否为check按钮
            /// </summary>
            [Description("按钮是否为check按钮")]
            [DefaultValue(false)]
            public bool CheckButton
            {
                get { return this.checkButton; }
                set
                {
                    if (this.checkButton == value)
                        return;

                    this.checkButton = value;
                    this.Invalidate();
                }
            }

            private bool _checked = false;
            /// <summary>
            /// 按钮为check按钮时是否选中
            /// </summary>
            [Description("按钮为check按钮时是否选中")]
            [DefaultValue(false)]
            public bool Checked
            {
                get { return this._checked; }
                set
                {
                    if (this._checked == value)
                        return;

                    this._checked = value;

                    if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                    {
                        TabPagePlusExt tab_page = (TabPagePlusExt)this.owner;
                        this.OnTabItemCustomButtonCheckedChanged(new TabItemCustomButttonOperatedEventArgs(tab_page, this));
                    }

                    this.Invalidate();
                }
            }

            private string tipText = "";
            /// <summary>
            /// 按钮提示文本
            /// </summary>
            [Description("按钮提示文本")]
            [DefaultValue("")]
            [Browsable(true)]
            public string TipText
            {
                get { return this.tipText; }
                set
                {
                    if (this.tipText == value)
                        return;

                    this.tipText = value;
                }
            }

            private BackGauge margin = new BackGauge(2, 2);
            /// <summary>
            /// 按钮左右外边距
            /// </summary>
            [Description("按钮左右外边距")]
            [DefaultValue(typeof(BackGauge), "2,2")]
            public BackGauge Margin
            {
                get { return this.margin; }
                set
                {
                    if (this.margin == value || value.Left < 0 || value.Right < 0)
                        return;

                    this.margin = value;
                    this.InitializeInvalidate();
                }
            }

            private Size size = new Size(14, 14);
            /// <summary>
            /// 按钮Size
            /// </summary>
            [DefaultValue(typeof(Size), "14, 14")]
            [Description("按钮Size")]
            public Size Size
            {
                get { return this.size; }
                set
                {
                    if (this.size == value || value.Width < 0 || value.Height < 0)
                        return;

                    this.size = value;
                    this.InitializeInvalidate();
                }
            }

            private Image tabItemCustomButtonNormalImage = null;
            /// <summary>
            /// 按钮图片(正常)
            /// </summary>
            [Description("按钮图片(正常)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image TabItemCustomButtonNormalImage
            {
                get
                {
                    return this.tabItemCustomButtonNormalImage;
                }
                set
                {
                    if (this.tabItemCustomButtonNormalImage == value)
                        return;

                    this.tabItemCustomButtonNormalImage = value;
                    this.tabItemCustomButtonDisableImage = null;
                    this.Invalidate();
                }
            }

            private Image tabItemCustomButtonDisableImage = null;
            /// <summary>
            /// 按钮图片(禁用)
            /// </summary>
            [Description("按钮图片(禁用)")]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Image TabItemCustomButtonDisableImage
            {
                get
                {
                    if (this.tabItemCustomButtonDisableImage == null && this.tabItemCustomButtonNormalImage != null)
                    {
                        this.tabItemCustomButtonDisableImage = ImageCommom.CreateDisabledImage(this.tabItemCustomButtonNormalImage);
                    }
                    return this.tabItemCustomButtonDisableImage;
                }
            }

            private Image tabItemCustomButtonEnterImage = null;
            /// <summary>
            /// 按钮图片(鼠标进入)
            /// </summary>
            [Description("按钮图片(鼠标进入)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image TabItemCustomButtonEnterImage
            {
                get
                {
                    return this.tabItemCustomButtonEnterImage;
                }
                set
                {
                    if (this.tabItemCustomButtonEnterImage == value)
                        return;

                    this.tabItemCustomButtonEnterImage = value;
                    this.Invalidate();
                }
            }

            private Image tabItemCustomButtonCheckedNormalImage = null;
            /// <summary>
            /// 按钮图片(已选中正常)
            /// </summary>
            [Description("按钮图片(已选中正常)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image TabItemCustomButtonCheckedNormalImage
            {
                get
                {
                    return this.tabItemCustomButtonCheckedNormalImage;
                }
                set
                {
                    if (this.tabItemCustomButtonCheckedNormalImage == value)
                        return;

                    this.tabItemCustomButtonCheckedNormalImage = value;
                    this.tabItemCustomButtonCheckedDisableImage = null;
                    this.Invalidate();
                }
            }

            private Image tabItemCustomButtonCheckedDisableImage = null;
            /// <summary>
            /// 按钮图片(已选中禁用)
            /// </summary>
            [Description("按钮图片(已选中禁用)")]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Image TabItemCustomButtonCheckedDisableImage
            {
                get
                {
                    if (this.tabItemCustomButtonCheckedDisableImage == null && this.tabItemCustomButtonCheckedNormalImage != null)
                    {
                        this.tabItemCustomButtonCheckedDisableImage = ImageCommom.CreateDisabledImage(this.tabItemCustomButtonCheckedNormalImage);
                    }
                    return this.tabItemCustomButtonCheckedDisableImage;
                }
            }

            private Image tabItemCustomButtonCheckedEnterImage = null;
            /// <summary>
            /// 按钮图片(已选中鼠标进入)
            /// </summary>
            [Description("按钮图片(已选中鼠标进入)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image TabItemCustomButtonCheckedEnterImage
            {
                get
                {
                    return this.tabItemCustomButtonCheckedEnterImage;
                }
                set
                {
                    if (this.tabItemCustomButtonCheckedEnterImage == value)
                        return;

                    this.tabItemCustomButtonCheckedEnterImage = value;
                    this.Invalidate();
                }
            }

            #region 用于临时存储运行信息

            /// <summary>
            /// 按钮rect（包含:外边距、内边距、内容）
            /// </summary>
            [Description("按钮rect（包含:外边距、内边距、内容）")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF M_Rect { get; set; }

            /// <summary>
            /// 按钮rect（只包含:内容）
            /// </summary>
            [Description("按钮rect（只包含:内容）")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF C_Rect { get; set; }

            private object data = null;
            /// <summary>
            /// 自定义保存数据
            /// </summary>
            [Description("自定义保存数据")]
            [DefaultValue(null)]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public object Data
            {
                get { return this.data; }
                set
                {
                    this.data = value;
                }
            }

            private TabControlPlusExt.MouseStatuss mouseStatus = TabControlPlusExt.MouseStatuss.Normal;
            /// <summary>
            /// 按钮鼠标状态
            /// </summary>
            [DefaultValue(TabControlPlusExt.MouseStatuss.Normal)]
            [Description("按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal TabControlPlusExt.MouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            #endregion

            #endregion

            public TabItemCustomButtonClass()
            {

            }

            #region 虚方法

            internal protected virtual void OnTabItemCustomButtonClick(TabItemCustomButttonOperatedEventArgs e)
            {
                if (this.tabItemCustomButtonClick != null && this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    this.tabItemCustomButtonClick(this.owner.Parent, e);
                }
            }

            internal protected virtual void OnTabItemCustomButtonCheckedChanged(TabItemCustomButttonOperatedEventArgs e)
            {
                if (this.tabItemCustomButtonCheckedChanged != null && this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    this.tabItemCustomButtonCheckedChanged(this.owner.Parent, e);
                }
            }

            internal protected virtual void OnTabItemCusomButtonDrawAfter(TabItemCustomButtonDrawAfterEventArgs e)
            {
                if (this.tabItemCusomButtonDrawAfter != null && this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    Region source_c_region = e.Graphics.Clip;
                    Region item_btn_c_region = source_c_region.Clone();//选项自定义按钮绘图区(C)
                    item_btn_c_region.Intersect(e.ClipContentBounds);
                    e.Graphics.Clip = item_btn_c_region;

                    this.tabItemCusomButtonDrawAfter(this.owner.Parent, e);

                    e.Graphics.Clip = source_c_region;
                    item_btn_c_region.Dispose();
                }
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 设置自定义按钮所属的TabPage
            /// </summary>
            /// <param name="owner">设置自定义按钮所属的TabPage</param>
            internal void SetOwner(TabPagePlusExt owner)
            {
                this.owner = owner;
            }

            /// <summary>
            /// 控件重新初始化和重绘
            /// </summary>
            private void InitializeInvalidate()
            {
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            /// <summary>
            /// 控件重绘
            /// </summary>
            private void Invalidate()
            {
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.Invalidate();
                }
            }

            #endregion

        }

        #endregion

        #region TabItem关闭按钮

        /// <summary>
        /// TabItem关闭按钮
        /// </summary>
        [TypeConverter(typeof(EmptyConverter))]
        public class TabItemCloseButtonClass
        {
            #region 字段

            /// <summary>
            /// TabItem关闭按钮所属TabPage
            /// </summary>
            private TabPagePlusExt owner;

            #endregion

            /// <summary>
            /// TabItem关闭按钮所属TabPage
            /// </summary>
            /// <param name="_owner"></param>
            public TabItemCloseButtonClass(TabPagePlusExt _owner)
            {
                this.owner = _owner;
            }

            #region 属性

            private TabItemCloseButtonVisibles visible = TabItemCloseButtonVisibles.Auto;
            /// <summary>
            /// TabItem关闭按钮是否显示(Auto表示采用控件通用设置)
            /// </summary>
            [Description("TabItem关闭按钮是否显示(Auto表示采用控件通用设置)")]
            [DefaultValue(TabItemCloseButtonVisibles.Auto)]
            public TabItemCloseButtonVisibles Visible
            {
                get { return this.visible; }
                set
                {
                    if (this.visible == value)
                        return;

                    this.visible = value;
                    this.InitializeInvalidate();
                }
            }

            private bool enabled = true;
            /// <summary>
            /// TabItem使用状态是否已启动
            /// </summary>
            [Description("TabItem使用状态是否已启动")]
            [DefaultValue(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.Invalidate();
                }
            }

            private Color backNormalColor = Color.Empty;
            /// <summary>
            /// TabItem按钮背景颜色(正常)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮背景颜色(正常)")]
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

            private Color backEnterColor = Color.Empty;
            /// <summary>
            /// TabItem按钮背景颜色(鼠标进入)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮背景颜色(鼠标进入)")]
            public Color BackEnterColor
            {
                get { return this.backEnterColor; }
                set
                {
                    if (this.backEnterColor == value)
                        return;

                    this.backEnterColor = value;
                    this.Invalidate();
                }
            }

            private Color backDisableColor = Color.Empty;
            /// <summary>
            /// TabItem按钮背景颜色(禁用)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮背景颜色(禁用)")]
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

            private Color foreNormalColor = Color.Empty;
            /// <summary>
            /// TabItem按钮前景颜色(正常)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮前景颜色(正常)")]
            public Color ForeNormalColor
            {
                get { return this.foreNormalColor; }
                set
                {
                    if (this.foreNormalColor == value)
                        return;

                    this.foreNormalColor = value;
                    this.Invalidate();
                }
            }

            private Color foreEnterColor = Color.Empty;
            /// <summary>
            /// TabItem按钮前景颜色(鼠标进入)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮前景颜色(鼠标进入)")]
            public Color ForeEnterColor
            {
                get { return this.foreEnterColor; }
                set
                {
                    if (this.foreEnterColor == value)
                        return;

                    this.foreEnterColor = value;
                    this.Invalidate();
                }
            }

            private Color foreDisableColor = Color.Empty;
            /// <summary>
            /// TabItem按钮前景颜色(禁用)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description("TabItem按钮前景颜色(禁用)")]
            public Color ForeDisableColor
            {
                get { return this.foreDisableColor; }
                set
                {
                    if (this.foreDisableColor == value)
                        return;

                    this.foreDisableColor = value;
                    this.Invalidate();
                }
            }

            #region 用于临时存储运行信息

            /// <summary>
            /// 选项关闭按钮rect(包括外边距)
            /// </summary>
            [Description("选项关闭按钮rect(包括外边距)")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF M_Rect { get; set; }

            /// <summary>
            /// 选项关闭按钮rect(不包括内外边距)
            /// </summary>
            [Description("选项关闭按钮rect(不包括内外边距)")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF C_Rect { get; set; }

            private object data = null;
            /// <summary>
            /// 自定义保存数据
            /// </summary>
            [Description("自定义保存数据")]
            [DefaultValue(null)]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public object Data
            {
                get { return this.data; }
                set
                {
                    this.data = value;
                }
            }

            private TabControlPlusExt.MouseStatuss mouseStatus = TabControlPlusExt.MouseStatuss.Normal;
            /// <summary>
            /// 选项关闭按钮鼠标状态
            /// </summary>
            [Description("选项关闭按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal TabControlPlusExt.MouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set { this.mouseStatus = value; }
            }

            #endregion

            #endregion

            #region 私有方法

            /// <summary>
            /// 控件重新初始化和重绘
            /// </summary>
            private void InitializeInvalidate()
            {
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            /// <summary>
            /// 控件重绘
            /// </summary>
            private void Invalidate()
            {
                if (this.owner != null && this.owner.Parent != null && this.owner.Parent is TabControlPlusExt)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner.Parent;
                    tabControl.Invalidate();
                }
            }

            #endregion

        }

        #endregion

        #endregion

        #region 枚举

        /// <summary>
        /// TabItem自动宽度模式
        /// </summary>
        public enum TabItemAutoWidthMode
        {
            /// <summary>
            /// 采用控件通用设置
            /// </summary>
            [Description("采用控件通用设置")]
            Auto,
            /// <summary>
            /// 显示
            /// </summary>
            [Description("显示")]
            True,
            /// <summary>
            /// 不显示
            /// </summary>
            [Description("不显示")]
            False
        }

        /// <summary>
        /// TabItem图标是否显示
        /// </summary>
        public enum TabItemIcoVisibles
        {
            /// <summary>
            /// 采用控件通用设置
            /// </summary>
            [Description("采用控件通用设置")]
            Auto,
            /// <summary>
            /// 显示
            /// </summary>
            [Description("显示")]
            True,
            /// <summary>
            /// 不显示
            /// </summary>
            [Description("不显示")]
            False
        }

        /// <summary>
        /// TabItem关闭按钮是否显示
        /// </summary>
        public enum TabItemCloseButtonVisibles
        {
            /// <summary>
            /// 采用控件通用设置
            /// </summary>
            [Description("采用控件通用设置")]
            Auto,
            /// <summary>
            /// 显示
            /// </summary>
            [Description("显示")]
            True,
            /// <summary>
            /// 不显示
            /// </summary>
            [Description("不显示")]
            False
        }

        /// <summary>
        ///下拉面板选项鼠标状态
        /// </summary>
        internal enum DropDownPanelItemMouseStatuss
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

        #region 事件参数类

        #region TabItem图标

        /// <summary>
        /// TabItem图标绘制后事件参数
        /// </summary>
        public class TabItemIcoDrawAfterEventArgs : EventArgs
        {
            /// <summary>
            /// 图标所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 图标Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ClipContentBounds { get; }

            /// <summary>
            /// 图标Rectangle（包含非剪辑区）（包含:外边距、内容）
            /// </summary>
            public RectangleF NoClipMarginBounds { get; }

            /// <summary>
            /// 图标Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">图标所属的TabPage</param>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）</param>
            /// <param name="clipContentBounds">图标Rectangle（排除非剪辑区）（只包含:内容）</param>
            /// <param name="noClipMarginBounds">图标Rectangle（包含非剪辑区）（包含:外边距、内容）</param>
            /// <param name="noClipContentBounds">图标Rectangle（包含非剪辑区）（只包含:内容）</param>
            public TabItemIcoDrawAfterEventArgs(TabPagePlusExt tabPage, DotsPerInch dPIScale, Graphics graphics, RectangleF clipContentBounds, RectangleF noClipMarginBounds, RectangleF noClipContentBounds)
            {
                this.TabPage = tabPage;
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.ClipContentBounds = clipContentBounds;
                this.NoClipMarginBounds = noClipMarginBounds;
                this.NoClipContentBounds = noClipContentBounds;
            }

        }

        #endregion

        #region TabItem自定义按钮

        /// <summary>
        /// TabItem自定义按钮操作事件参数
        /// </summary>
        public class TabItemCustomButttonOperatedEventArgs : EventArgs
        {
            /// <summary>
            /// 自定义按钮所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 自定义按钮
            /// </summary>
            public TabItemCustomButtonClass CustomButton { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">当前单击的TabPageBaseExt</param>
            /// <param name="customButton">当前单击的自定义按钮</param>
            public TabItemCustomButttonOperatedEventArgs(TabPagePlusExt tabPage, TabItemCustomButtonClass customButton)
            {
                this.TabPage = tabPage;
                this.CustomButton = customButton;
            }

        }

        /// <summary>
        /// TabItem自定义按钮绘制后事件参数
        /// </summary>
        public class TabItemCustomButtonDrawAfterEventArgs : EventArgs
        {
            /// <summary>
            /// 自定义按钮所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 自定义按钮
            /// </summary>
            public TabItemCustomButtonClass CustomButton { get; }

            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 自定义按钮Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ClipContentBounds { get; }

            /// <summary>
            /// 自定义按钮图标Rectangle（包含非剪辑区）（包含:外边距、内容）
            /// </summary>
            public RectangleF NoClipMarginBounds { get; }

            /// <summary>
            /// 自定义按钮图标Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">自定义按钮所属的TabPage</param>
            /// <param name="customButton">自定义按钮</param>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）</param>
            /// <param name="clipContentBounds">自定义按钮Rectangle（排除非剪辑区）（只包含:内容</param>
            /// <param name="noClipMarginBounds">自定义按钮图标Rectangle（包含非剪辑区）（包含:外边距、内容）</param>
            /// <param name="noClipContentBounds">自定义按钮图标Rectangle（包含非剪辑区）（只包含:内容）</param>
            public TabItemCustomButtonDrawAfterEventArgs(TabPagePlusExt tabPage, TabItemCustomButtonClass customButton, DotsPerInch dPIScale, Graphics graphics, RectangleF clipContentBounds, RectangleF noClipMarginBounds, RectangleF noClipContentBounds)
            {
                this.TabPage = tabPage;
                this.CustomButton = customButton;
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.ClipContentBounds = clipContentBounds;
                this.NoClipMarginBounds = noClipMarginBounds;
                this.NoClipContentBounds = noClipContentBounds;
            }

        }

        #endregion

        #region TabItem关闭按钮

        /// <summary>
        /// TabItem关闭时事件参数
        /// </summary>
        public class TabItemCloseButtonCloseingEventArgs : CancelEventArgs
        {
            /// <summary>
            /// 关闭按钮所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 关闭按钮
            /// </summary>
            public TabItemCloseButtonClass CloseButton { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">关闭按钮所属的TabPage</param>
            /// <param name="closeButton">关闭按钮</param>
            /// <param name="cancel">是否取消关闭</param>
            public TabItemCloseButtonCloseingEventArgs(TabPagePlusExt tabPage, TabItemCloseButtonClass closeButton, bool cancel)
            {
                this.TabPage = tabPage;
                this.CloseButton = closeButton;
                this.Cancel = cancel;
            }

        }

        /// <summary>
        /// TabItem关闭后事件参数
        /// </summary>
        public class TabItemCloseButtonClosedEventArgs : EventArgs
        {
            /// <summary>
            /// 关闭按钮所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 关闭按钮
            /// </summary>
            public TabItemCloseButtonClass CloseButton { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">关闭按钮所属的TabPage</param>
            /// <param name="closeButton">关闭按钮</param>
            public TabItemCloseButtonClosedEventArgs(TabPagePlusExt tabPage, TabItemCloseButtonClass closeButton)
            {
                this.TabPage = tabPage;
                this.CloseButton = closeButton;
            }

        }

        /// <summary>
        /// TabItem关闭按钮绘制前事件参数
        /// </summary>
        public class TabItemCloseButtonDrawBeforeEventArgs : EventArgs
        {
            /// <summary>
            /// 关闭按钮所属的TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 关闭按钮背景颜色画笔（会自动释放）
            /// </summary>
            public SolidBrush BackgroudBrush { get; }

            /// <summary>
            /// 关闭按钮前景颜色画笔（会自动释放）
            /// </summary>
            public Pen ForePen { get; }

            /// <summary>
            /// 关闭按钮图标Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ClipContentBounds { get; }

            /// <summary>
            /// 关闭按钮图标Rectangle（包含非剪辑区）（包含:外边距、内容）
            /// </summary>
            public RectangleF NoClipMarginBounds { get; }

            /// <summary>
            /// 关闭按钮图标Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 关闭按钮绘制是否已处理完毕 (True 将会跳过控件的默认绘制)
            /// </summary>
            public bool Finish { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">关闭按钮所属的TabPage</param>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面（可绘制区域为:ClipContentBounds）</param>
            /// <param name="backgroudBrush">关闭按钮背景颜色画笔（会自动释放）</param>
            /// <param name="forePen">关闭按钮前景颜色画笔（会自动释放）</param>
            /// <param name="clipContentBounds">关闭按钮图标Rectangle（排除非剪辑区）（只包含:内容）</param>
            /// <param name="noClipMarginBounds">关闭按钮图标Rectangle（包含非剪辑区）（包含:外边距、内容）</param>
            /// <param name="noClipContentBounds">关闭按钮图标Rectangle（包含非剪辑区）（但排除外边距、边框、内边距）</param>
            /// <param name="finish">关闭按钮绘制是否已处理完毕 (True 将会跳过控件的默认绘制)</param>
            public TabItemCloseButtonDrawBeforeEventArgs(TabPagePlusExt tabPage, DotsPerInch dPIScale, Graphics graphics, SolidBrush backgroudBrush, Pen forePen, RectangleF clipContentBounds, RectangleF noClipMarginBounds, RectangleF noClipContentBounds, bool finish)
            {
                this.TabPage = tabPage;
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.BackgroudBrush = backgroudBrush;
                this.ForePen = forePen;
                this.ClipContentBounds = clipContentBounds;
                this.NoClipMarginBounds = noClipMarginBounds;
                this.NoClipContentBounds = noClipContentBounds;
                this.Finish = finish;
            }

        }

        #endregion

        #endregion
    }

}
