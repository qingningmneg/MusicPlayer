
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// TabControlPlusExt(TabControl增强版)
    /// </summary> 
    [Description("TabControlPlusExt(TabControl增强版)")]
    [ToolboxItem(true)]
    [DefaultProperty("TabPages")]
    [DefaultEvent("SelectedIndexChanged")]
    [Designer(typeof(TabControlPlusExtDesigner))]
    public class TabControlPlusExt : Control
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

        #endregion

        #region 新增事件

        #region 菜单背景

        public delegate void MenuBarDrawBackgroundBeforeEventHandler(object sender, MenuBarDrawBackgroundBeforeEventArgs e);
        private event MenuBarDrawBackgroundBeforeEventHandler menuBarDrawBackgroundBefore;
        /// <summary>
        /// 菜单背景绘制前事件
        /// </summary>
        [Description("菜单背景绘制前事件")]
        [Category("杂项_菜单")]
        public event MenuBarDrawBackgroundBeforeEventHandler MenuBarDrawBackgroundBefore
        {
            add { this.menuBarDrawBackgroundBefore += value; }
            remove { this.menuBarDrawBackgroundBefore -= value; }
        }

        public delegate void MenuBarDrawBackgroundAfterEventHandler(object sender, MenuBarDrawBackgroundAfterEventArgs e);
        private event MenuBarDrawBackgroundAfterEventHandler menuBarDrawBackgroundAfter;
        /// <summary>
        /// 菜单背景绘制后事件
        /// </summary>
        [Description("菜单背景绘制后事件")]
        [Category("杂项_菜单")]
        public event MenuBarDrawBackgroundAfterEventHandler MenuBarDrawBackgroundAfter
        {
            add { this.menuBarDrawBackgroundAfter += value; }
            remove { this.menuBarDrawBackgroundAfter -= value; }
        }

        #endregion

        #region 导航栏

        public delegate void NavigationButtonOperatingEventHandler(object sender, NavigationButtonOperatingEventArgs e);
        private event NavigationButtonOperatingEventHandler navigationButtonOperating;
        /// <summary>
        /// 导航按钮点击时事件
        /// </summary>
        [Description("导航按钮点击时事件")]
        [Category("杂项_导航栏")]
        public event NavigationButtonOperatingEventHandler NavigationButtonOperating
        {
            add { this.navigationButtonOperating += value; }
            remove { this.navigationButtonOperating -= value; }
        }

        public delegate void NavigationButtonOperatedEventHandler(object sender, NavigationButtonOperatedEventArgs e);
        private event NavigationButtonOperatedEventHandler navigationButtonOperated;
        /// <summary>
        /// 导航按钮点击后事件
        /// </summary>
        [Description("导航按钮点击后事件")]
        [Category("杂项_导航栏")]
        public event NavigationButtonOperatedEventHandler NavigationButtonOperated
        {
            add { this.navigationButtonOperated += value; }
            remove { this.navigationButtonOperated -= value; }
        }

        #endregion

        #region TabItem

        public delegate void TabItemOperatingEventHandler(object sender, TabItemOperatingEventArgs e);
        public delegate void TabItemOperatedEventHandler(object sender, TabItemOperatedEventArgs e);

        private event TabItemOperatingEventHandler tabItemDeselecting;
        /// <summary>
        /// TabItem取消选中事件
        /// </summary>
        [Description("TabItem取消选中事件")]
        [Category("杂项_选项")]
        public event TabItemOperatingEventHandler TabItemDeselecting
        {
            add { this.tabItemDeselecting += value; }
            remove { this.tabItemDeselecting -= value; }
        }

        private event TabItemOperatedEventHandler tabItemDeselected;
        /// <summary>
        /// TabItem取消选后事件
        /// </summary>
        [Description("TabItem取消选后事件")]
        [Category("杂项_选项")]
        public event TabItemOperatedEventHandler TabItemDeselected
        {
            add { this.tabItemDeselected += value; }
            remove { this.tabItemDeselected -= value; }
        }

        private event TabItemOperatingEventHandler tabItemSelecting;
        /// <summary>
        /// TabItem选中时事件
        /// </summary>
        [Description("TabItem选中时事件")]
        [Category("杂项_选项")]
        public event TabItemOperatingEventHandler TabItemSelecting
        {
            add { this.tabItemSelecting += value; }
            remove { this.tabItemSelecting -= value; }
        }

        private event TabItemOperatedEventHandler tabItemSelected;
        /// <summary>
        /// TabItem选中后事件
        /// </summary>
        [Description("TabItem选中后事件")]
        [Category("杂项_选项")]
        public event TabItemOperatedEventHandler TabItemSelected
        {
            add { this.tabItemSelected += value; }
            remove { this.tabItemSelected -= value; }
        }

        private event TabItemOperatedEventHandler selectedIndexChanged;
        /// <summary>
        /// TabItem选中索引更改后事件
        /// </summary>
        [Description("TabItem选中索引更改后事件")]
        [Category("杂项_选项")]
        public event TabItemOperatedEventHandler SelectedIndexChanged
        {
            add { this.selectedIndexChanged += value; }
            remove { this.selectedIndexChanged -= value; }
        }

        private event TabItemOperatedEventHandler tabItemEnabledChanged;
        /// <summary>
        /// TabItem启用状态更改事件
        /// </summary>
        [Description("TabItem启用状态更改事件")]
        [Category("杂项_选项")]
        public event TabItemOperatedEventHandler TabItemEnabledChanged
        {
            add { this.tabItemEnabledChanged += value; }
            remove { this.tabItemEnabledChanged -= value; }
        }

        public delegate void TabItemInterchangeingEventHandler(object sender, TabItemInterchangeingEventArgs e);
        private event TabItemInterchangeingEventHandler tabItemInterchangeing;
        /// <summary>
        /// 两个TabItem位置互换时事件
        /// </summary>
        [Description("两个TabItem位置互换时事件")]
        [Category("杂项_选项")]
        public event TabItemInterchangeingEventHandler TabItemInterchangeing
        {
            add { this.tabItemInterchangeing += value; }
            remove { this.tabItemInterchangeing -= value; }
        }

        public delegate void TabItemInterchangedEventHandler(object sender, TabItemInterchangedEventArgs e);
        private event TabItemInterchangedEventHandler tabItemInterchanged;
        /// <summary>
        /// 两个TabItem位置互换后事件
        /// </summary>
        [Description("两个TabItem位置互换后事件")]
        [Category("杂项_选项")]
        public event TabItemInterchangedEventHandler TabItemInterchanged
        {
            add { this.tabItemInterchanged += value; }
            remove { this.tabItemInterchanged -= value; }
        }

        public delegate void TabItemDrawBackgroundAfterEventHandler(object sender, TabItemDrawBackgroundAfterEventArgs e);
        private event TabItemDrawBackgroundAfterEventHandler tabItemDrawBackgroundAfter;
        /// <summary>
        /// TabItem背景绘制后事件
        /// </summary>
        [Description("TabItem背景绘制后事件")]
        [Category("杂项_选项")]
        public event TabItemDrawBackgroundAfterEventHandler TabItemDrawBackgroundAfter
        {
            add { this.tabItemDrawBackgroundAfter += value; }
            remove { this.tabItemDrawBackgroundAfter -= value; }
        }

        public delegate void TabItemCreateCustomPathBeforeEventHandler(object sender, TabItemCreateCustomPathBeforeEventArgs e);
        private event TabItemCreateCustomPathBeforeEventHandler tabItemCreateCustomPathBefore;
        /// <summary>
        /// TabItem生成选项自定义路径事件
        /// </summary>
        [Description("TabItem生成选项自定义路径事件")]
        [Category("杂项_选项")]
        public event TabItemCreateCustomPathBeforeEventHandler TabItemCreateCustomPathBefore
        {
            add { this.tabItemCreateCustomPathBefore += value; }
            remove { this.tabItemCreateCustomPathBefore -= value; }
        }

        #endregion

        #endregion

        #region 新增属性

        #region  菜单

        private MenuBarAlignments menuBarAlignment = MenuBarAlignments.Top;
        /// <summary>
        /// 菜单区域出现的位置
        /// </summary>
        [Description("菜单区域出现的位置")]
        [Category("杂项_菜单")]
        [DefaultValue(MenuBarAlignments.Top)]
        public MenuBarAlignments MenuBarAlignment
        {
            get { return this.menuBarAlignment; }
            set
            {
                if (this.menuBarAlignment == value)
                    return;

                this.menuBarAlignment = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Padding menuBarPadding = new Padding(0, 0, 0, 0);
        /// <summary>
        /// 菜单区域内边距
        /// </summary>
        [Description("菜单区域内边距")]
        [Category("杂项_菜单")]
        [DefaultValue(typeof(Padding), "0,0,0,0")]
        public Padding MenuBarPadding
        {
            get { return this.menuBarPadding; }
            set
            {
                if (this.menuBarPadding == value || value.Left < 0 || value.Right < 0 || value.Top < 0 || value.Bottom < 0)
                    return;

                this.menuBarPadding = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color menuBarBackNormalColor = Color.FromArgb(250, 247, 240);
        /// <summary>
        /// 菜单背景颜色(正常)
        /// </summary>
        [Description("菜单背景颜色(正常)")]
        [Category("杂项_菜单")]
        [DefaultValue(typeof(Color), "250, 247, 240")]
        public Color MenuBarBackNormalColor
        {
            get { return this.menuBarBackNormalColor; }
            set
            {
                if (this.menuBarBackNormalColor == value)
                    return;

                this.menuBarBackNormalColor = value;
                this.Invalidate();
            }
        }

        private Color menuBarBackDisableColor = Color.FromArgb(250, 247, 240);
        /// <summary>
        /// 菜单背景颜色(禁用)
        /// </summary>
        [Description("菜单背景颜色(禁用)")]
        [Category("杂项_菜单")]
        [DefaultValue(typeof(Color), "250, 247, 240")]
        public Color MenuBarBackDisableColor
        {
            get { return this.menuBarBackDisableColor; }
            set
            {
                if (this.menuBarBackDisableColor == value)
                    return;

                this.menuBarBackDisableColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 全局自定义按钮

        private GlobalCustomButttonCollection globalCustomButttonCollection;
        /// <summary>
        /// 全局自定义按钮集合
        /// </summary>
        [Description("全局自定义按钮集合")]
        [Category("杂项_全局自定义按钮")]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GlobalCustomButttonCollection GlobalCustomButttons
        {
            get
            {
                if (this.globalCustomButttonCollection == null)
                    this.globalCustomButttonCollection = new GlobalCustomButttonCollection(this);
                return this.globalCustomButttonCollection;
            }
        }

        #endregion

        #region 导航栏

        private bool navigationVisible = true;
        /// <summary>
        /// 是否显示导航栏
        /// </summary>
        [Description("是否显示导航栏")]
        [Category("杂项_导航栏")]
        [DefaultValue(true)]
        public bool NavigationVisible
        {
            get { return this.navigationVisible; }
            set
            {
                if (this.navigationVisible == value)
                    return;

                this.navigationVisible = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private NavigationButtonClass navigationPrevButton;
        /// <summary>
        /// 上一个按钮
        /// </summary>
        [Description("上一个按钮")]
        [Category("杂项_导航栏")]
        [TypeConverter(typeof(EmptyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NavigationButtonClass NavigationPrevButton
        {
            get
            {
                if (this.navigationPrevButton == null)
                    this.navigationPrevButton = new NavigationButtonClass(this);

                return this.navigationPrevButton;
            }
            set { this.navigationPrevButton = value; }
        }

        private NavigationButtonClass navigationNextButton;
        /// <summary>
        /// 下一个按钮
        /// </summary>
        [Description("下一个按钮")]
        [Category("杂项_导航栏")]
        [TypeConverter(typeof(EmptyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NavigationButtonClass NavigationNextButton
        {
            get
            {
                if (this.navigationNextButton == null)
                    this.navigationNextButton = new NavigationButtonClass(this);

                return this.navigationNextButton;
            }
            set { this.navigationNextButton = value; }
        }

        #endregion

        #region TabItem

        private bool tabItemDisableActivation = false;
        /// <summary>
        /// 是否允许切换到已禁用的TabItem
        /// </summary>
        [Description("是否允许切换到已禁用的TabItem")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemDisableActivation
        {
            get { return this.tabItemDisableActivation; }
            set
            {
                if (this.tabItemDisableActivation == value)
                    return;

                this.tabItemDisableActivation = value;
            }
        }

        private bool tabItemInterchangeEnabled = false;
        /// <summary>
        /// 是否启用通过鼠标交换TabItem位置
        /// </summary>
        [Description("是否启用通过鼠标交换TabItem位置")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemInterchangeEnabled
        {
            get { return this.tabItemInterchangeEnabled; }
            set
            {
                if (this.tabItemInterchangeEnabled == value)
                    return;

                this.tabItemInterchangeEnabled = value;
            }
        }

        private bool tabItemVerticalLayout = false;
        /// <summary>
        /// TabItem是否纵向布局(限于左右两边)
        /// </summary>
        [Description("TabItem是否纵向布局(限于左右两边)")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemVerticalLayout
        {
            get { return this.tabItemVerticalLayout; }
            set
            {
                if (this.tabItemVerticalLayout == value)
                    return;

                this.tabItemVerticalLayout = value;
                if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    this.InitializeRectangle();
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 在tabitem显示的总区域中要显示的第一个tabitem的索引
        /// </summary>
        [Description("在tabitem显示的总区域中要显示的第一个tabitem的索引")]
        [Category("杂项_选项")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TabItemFirstIndex
        {
            get { return this.menubar_items_start_index; }
        }

        private Size tabItemSize = new Size(160, 24);
        /// <summary>
        /// TabItemSize（通用）
        /// </summary>
        [Description("TabItemSize（通用）")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Size), "160, 24")]
        public Size TabItemSize
        {
            get { return this.tabItemSize; }
            set
            {
                if (this.tabItemSize == value || value.Width < 0 || value.Height < 0)
                    return;

                this.tabItemSize = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private BackGauge tabItemMargin = new BackGauge(0, 0);
        /// <summary>
        /// TabItem左右外边距（通用）
        /// </summary>
        [Description("TabItem左右外边距（通用）")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(BackGauge), "0, 0")]
        public BackGauge TabItemMargin
        {
            get { return this.tabItemMargin; }
            set
            {
                if (this.tabItemMargin == value || value.Left < 0 || value.Right < 0)
                    return;

                this.tabItemMargin = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private BackGauge tabItemPadding = new BackGauge(2, 2);
        /// <summary>
        /// TabItem左右内边距（通用）
        /// </summary>
        [Description("TabItem左右内边距（通用）")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(BackGauge), "2, 2")]
        public BackGauge TabItemPadding
        {
            get { return this.tabItemPadding; }
            set
            {
                if (this.tabItemPadding == value || value.Left < 0 || value.Right < 0)
                    return;

                this.tabItemPadding = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int tabItemContentOffset = 0;
        /// <summary>
        /// TabItem内容上下方向布局偏移量
        /// </summary>
        [Description("TabItem内容上下方向布局偏移量")]
        [Category("杂项_选项")]
        [DefaultValue(0)]
        public int TabItemContentOffset
        {
            get { return this.tabItemContentOffset; }
            set
            {
                if (this.tabItemContentOffset == value)
                    return;

                this.tabItemContentOffset = value;

                this.UpdateEveryOneTabItemRectangle();
                this.Invalidate();
            }
        }

        private bool tabItemAutoWidth = false;
        /// <summary>
        /// TabItem自动宽度（通用）
        /// </summary>
        [Description("TabItem自动宽度（通用）")]
        [Category("杂项_选项")]
        [DefaultValue(false)]
        public bool TabItemAutoWidth
        {
            get { return this.tabItemAutoWidth; }
            set
            {
                if (this.tabItemAutoWidth == value)
                    return;

                this.tabItemAutoWidth = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int tabItemAutoWidthMin = 70;
        /// <summary>
        /// TabItem自动宽度模式下最小宽度（通用）
        /// </summary>
        [Description("TabItem自动宽度模式下最小宽度（通用）")]
        [Category("杂项_选项")]
        [DefaultValue(70)]
        public int TabItemAutoWidthMin
        {
            get { return this.tabItemAutoWidthMin; }
            set
            {
                if (this.tabItemAutoWidthMin == value || value < 0)
                    return;

                this.tabItemAutoWidthMin = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private RoundedCorner tabItemRoundedCorner = new RoundedCorner(6, 6, 0, 0);
        /// <summary>
        /// TabItem圆角
        /// </summary>
        [Description("TabItem圆角")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(RoundedCorner), "6, 6, 0, 0")]
        public RoundedCorner TabItemRoundedCorner
        {
            get { return this.tabItemRoundedCorner; }
            set
            {
                if (this.tabItemRoundedCorner == value || value.LeftTop < 0 || value.RightTop < 0 || value.LeftBottom < 0 || value.RightBottom < 0)
                    return;

                this.tabItemRoundedCorner = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private bool tabItemRoundedAntiAlias = true;
        /// <summary>
        /// TabItem是否启用圆角抗锯齿功能
        /// </summary>
        [Description("TabItem是否启用圆角抗锯齿功能")]
        [Category("杂项_选项")]
        [DefaultValue(true)]
        public bool TabItemRoundedAntiAlias
        {
            get { return this.tabItemRoundedAntiAlias; }
            set
            {
                if (this.tabItemRoundedAntiAlias == value)
                    return;

                this.tabItemRoundedAntiAlias = value;
                this.Invalidate();
            }
        }

        private StringAlignment tabItemTextAlignment = StringAlignment.Near;
        /// <summary>
        /// TabItem文本对齐方式
        /// </summary>
        [Description("TabItem文本对齐方式")]
        [Category("杂项_选项")]
        [DefaultValue(StringAlignment.Near)]
        public StringAlignment TabItemTextAlignment
        {
            get { return this.tabItemTextAlignment; }
            set
            {
                if (this.tabItemTextAlignment == value)
                    return;

                this.tabItemTextAlignment = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        /// <summary>
        /// TabItem字体
        /// </summary>
        [Description("TabItem字体")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Font), "宋体, 9pt")]
        public Font TabItemFont
        {
            get { return this.Font; }
            set
            {
                if (this.Font == value)
                    return;

                this.Font = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color tabItemBackNormalColor = Color.FromArgb(176, 197, 175);
        /// <summary>
        /// TabItem背景颜色(正常)
        /// </summary>
        [Description("TabItem背景颜色(正常)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "176, 197, 175")]
        public Color TabItemBackNormalColor
        {
            get { return this.tabItemBackNormalColor; }
            set
            {
                if (this.tabItemBackNormalColor == value)
                    return;

                this.tabItemBackNormalColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemBackEnterColor = Color.FromArgb(144, 169, 143);
        /// <summary>
        /// TabItem背景颜色(鼠标进入)
        /// </summary>
        [Description("TabItem背景颜色(鼠标进入)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "144, 169, 143")]
        public Color TabItemBackEnterColor
        {
            get { return this.tabItemBackEnterColor; }
            set
            {
                if (this.tabItemBackEnterColor == value)
                    return;

                this.tabItemBackEnterColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemBackSelectedColor = Color.FromArgb(144, 169, 143);
        /// <summary>
        /// TabItem背景颜色(选中)
        /// </summary>
        [Description("TabItem背景颜色(选中)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "144, 169, 143")]
        public Color TabItemBackSelectedColor
        {
            get { return this.tabItemBackSelectedColor; }
            set
            {
                if (this.tabItemBackSelectedColor == value)
                    return;

                this.tabItemBackSelectedColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemBackDisableColor = Color.FromArgb(206, 226, 206);
        /// <summary>
        /// TabItem背景颜色(禁用)
        /// </summary>
        [Description("TabItem背景颜色(禁用)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "206, 226, 206")]
        public Color TabItemBackDisableColor
        {
            get { return this.tabItemBackDisableColor; }
            set
            {
                if (this.tabItemBackDisableColor == value)
                    return;

                this.tabItemBackDisableColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemTextNormalColor = Color.White;
        /// <summary>
        /// TabItem文本颜色(正常)
        /// </summary>
        [Description("TabItem文本颜色(正常)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "White")]
        public Color TabItemTextNormalColor
        {
            get { return this.tabItemTextNormalColor; }
            set
            {
                if (this.tabItemTextNormalColor == value)
                    return;

                this.tabItemTextNormalColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemTextEnterColor = Color.White;
        /// <summary>
        /// TabItem文本颜色(鼠标进入)
        /// </summary>
        [Description("TabItem文本颜色(鼠标进入)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "White")]
        public Color TabItemTextEnterColor
        {
            get { return this.tabItemTextEnterColor; }
            set
            {
                if (this.tabItemTextEnterColor == value)
                    return;

                this.tabItemTextEnterColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemTextSelectedColor = Color.White;
        /// <summary>
        /// TabItem文本颜色(选中)
        /// </summary>
        [Description("TabItem文本颜色(选中)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "White")]
        public Color TabItemTextSelectedColor
        {
            get { return this.tabItemTextSelectedColor; }
            set
            {
                if (this.tabItemTextSelectedColor == value)
                    return;

                this.tabItemTextSelectedColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemTextDisableColor = Color.White;
        /// <summary>
        /// TabItem文本颜色(禁用)
        /// </summary>
        [Description("TabItem文本颜色(禁用)")]
        [Category("杂项_选项")]
        [DefaultValue(typeof(Color), "White")]
        public Color TabItemTextDisableColor
        {
            get { return this.tabItemTextDisableColor; }
            set
            {
                if (this.tabItemTextDisableColor == value)
                    return;

                this.tabItemTextDisableColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region TabItem图标

        private bool tabItemIcoVisible = false;
        /// <summary>
        /// TabItem图标是否显示(通用)
        /// </summary>
        [Description("TabItem图标是否显示(通用)")]
        [Category("杂项_选项图标")]
        [DefaultValue(false)]
        public bool TabItemIcoVisible
        {
            get { return this.tabItemIcoVisible; }
            set
            {
                if (this.tabItemIcoVisible == value)
                    return;

                this.tabItemIcoVisible = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Size tabItemIcoSize = new Size(14, 14);
        /// <summary>
        /// TabItem图标Size
        /// </summary>
        [Description("TabItem图标Size")]
        [Category("杂项_选项图标")]
        [DefaultValue(typeof(Size), "14, 14")]
        public Size TabItemIcoSize
        {
            get { return this.tabItemIcoSize; }
            set
            {
                if (this.tabItemIcoSize == value || value.Width < 0 || value.Height < 0)
                    return;

                this.tabItemIcoSize = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private BackGauge tabItemIcoMargin = new BackGauge(0, 1);
        /// <summary>
        /// TabItem图标外边距
        /// </summary>
        [Description("TabItem图标外边距")]
        [Category("杂项_选项图标")]
        [DefaultValue(typeof(BackGauge), "0, 1")]
        public BackGauge TabItemIcoMargin
        {
            get { return this.tabItemIcoMargin; }
            set
            {
                if (this.tabItemIcoMargin == value || value.Left < 0 || value.Right < 0)
                    return;

                this.tabItemIcoMargin = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        #endregion

        #region TabItem关闭按钮

        private bool tabItemCloseButtonVisible = true;
        /// <summary>
        /// TabItem关闭按钮是否显示（通用）
        /// </summary>
        [Description("TabItem关闭按钮是否显示（通用）")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(true)]
        public bool TabItemCloseButtonVisible
        {
            get { return this.tabItemCloseButtonVisible; }
            set
            {
                if (this.tabItemCloseButtonVisible == value)
                    return;

                this.tabItemCloseButtonVisible = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private TabItemColseButtonAlignments tabItemCloseButtonAlignment = TabItemColseButtonAlignments.Right;
        /// <summary>
        /// TabItem关闭按钮显示位置
        /// </summary>
        [Description("TabItem关闭按钮显示位置")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(TabItemColseButtonAlignments.Right)]
        public TabItemColseButtonAlignments TabItemCloseButtonAlignment
        {
            get { return this.tabItemCloseButtonAlignment; }
            set
            {
                if (this.tabItemCloseButtonAlignment == value)
                    return;

                this.tabItemCloseButtonAlignment = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Size tabItemCloseButtonSize = new Size(12, 12);
        /// <summary>
        /// TabItem关闭按钮Size
        /// </summary>
        [Description("TabItem关闭按钮Size")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Size), "12, 12")]
        public Size TabItemCloseButtonSize
        {
            get { return this.tabItemCloseButtonSize; }
            set
            {
                if (this.tabItemCloseButtonSize == value || value.Width < 0 || value.Height < 0)
                    return;

                this.tabItemCloseButtonSize = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private BackGauge tabItemCloseButtonMargin = new BackGauge(1, 0);
        /// <summary>
        /// TabItem关闭按钮外边距
        /// </summary>
        [Description("TabItem关闭按钮外边距")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(BackGauge), "1, 0")]
        public BackGauge TabItemCloseButtonMargin
        {
            get { return this.tabItemCloseButtonMargin; }
            set
            {
                if (this.tabItemCloseButtonMargin == value || value.Left < 0 || value.Right < 0)
                    return;

                this.tabItemCloseButtonMargin = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonBackNormalColor = Color.Empty;
        /// <summary>
        /// TabItem按钮背景颜色(正常)
        /// </summary>
        [Description("TabItem按钮背景颜色(正常)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonBackNormalColor
        {
            get { return this.tabItemCloseButtonBackNormalColor; }
            set
            {
                if (this.tabItemCloseButtonBackNormalColor == value)
                    return;

                this.tabItemCloseButtonBackNormalColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonBackEnterColor = Color.Empty;
        /// <summary>
        /// TabItem按钮背景颜色(鼠标进入)
        /// </summary>
        [Description("TabItem按钮背景颜色(鼠标进入)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonBackEnterColor
        {
            get { return this.tabItemCloseButtonBackEnterColor; }
            set
            {
                if (this.tabItemCloseButtonBackEnterColor == value)
                    return;

                this.tabItemCloseButtonBackEnterColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonBackDisableColor = Color.Empty;
        /// <summary>
        /// TabItem按钮背景颜色(禁用)
        /// </summary>
        [Description("TabItem按钮背景颜色(禁用)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonBackDisableColor
        {
            get { return this.tabItemCloseButtonBackDisableColor; }
            set
            {
                if (this.tabItemCloseButtonBackDisableColor == value)
                    return;

                this.tabItemCloseButtonBackDisableColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonForeNormalColor = Color.White;
        /// <summary>
        /// TabItem按钮前景颜色(正常)
        /// </summary>
        [Description("TabItem按钮前景颜色(正常)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "White")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonForeNormalColor
        {
            get { return this.tabItemCloseButtonForeNormalColor; }
            set
            {
                if (this.tabItemCloseButtonForeNormalColor == value)
                    return;

                this.tabItemCloseButtonForeNormalColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonForeEnterColor = Color.White;
        /// <summary>
        /// TabItem按钮前景颜色(鼠标进入)
        /// </summary>
        [Description("TabItem按钮前景颜色(鼠标进入)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "White")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonForeEnterColor
        {
            get { return this.tabItemCloseButtonForeEnterColor; }
            set
            {
                if (this.tabItemCloseButtonForeEnterColor == value)
                    return;

                this.tabItemCloseButtonForeEnterColor = value;
                this.Invalidate();
            }
        }

        private Color tabItemCloseButtonForeDisableColor = Color.White;
        /// <summary>
        /// TabItem按钮前景颜色(禁用)
        /// </summary>
        [Description("TabItem按钮前景颜色(禁用)")]
        [Category("杂项_选项关闭按钮")]
        [DefaultValue(typeof(Color), "White")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabItemCloseButtonForeDisableColor
        {
            get { return this.tabItemCloseButtonForeDisableColor; }
            set
            {
                if (this.tabItemCloseButtonForeDisableColor == value)
                    return;

                this.tabItemCloseButtonForeDisableColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 提示信息

        private Color tipBackColor = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// 提示信息背景颜色
        /// </summary>
        [Description("提示信息背景颜色")]
        [Category("杂项_提示信息")]
        [DefaultValue(typeof(Color), "240, 240, 240")]
        public Color TipBackColor
        {
            get { return this.tipBackColor; }
            set
            {
                if (this.tipBackColor == value)
                    return;

                this.tipBackColor = value;
            }
        }

        private Color tipTextColor = Color.FromArgb(109, 109, 109);
        /// <summary>
        /// 提示信息文本颜色
        /// </summary>
        [Description("提示信息文本颜色")]
        [Category("杂项_提示信息")]
        [DefaultValue(typeof(Color), "109, 109, 109")]
        public Color TipTextColor
        {
            get { return this.tipTextColor; }
            set
            {
                if (this.tipTextColor == value)
                    return;

                this.tipTextColor = value;
            }
        }

        #endregion

        #region TabPage

        private TabPagePlusCollection tabPagePlusCollection;
        /// <summary>
        /// TabPage集合
        /// </summary>
        [Description("TabPage集合")]
        [Category("杂项_TabPage")]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabPagePlusCollection TabPages
        {
            get
            {
                if (this.tabPagePlusCollection == null)
                    this.tabPagePlusCollection = new TabPagePlusCollection(this);
                return this.tabPagePlusCollection;
            }
        }

        /// <summary>
        /// TabPage总数
        /// </summary>
        [Description("TabPage总数")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TabCount
        {
            get { return this.tabPages.Count(); }
        }

        private int selectedIndex = -1;
        /// <summary>
        /// 已选中TabPage索引
        /// </summary>
        [Description("已选中TabPage索引")]
        [DefaultValue("-1")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                if (this.selectedIndex == value || value < -1 || value >= this.TabCount)
                    return;

                int old_tabPageIndex = this.selectedIndex;
                TabPagePlusExt old_tabPage = this.GetTabPage(this.selectedIndex);
                if (old_tabPage != null)
                {
                    //旧已选中选项取消中事件
                    TabItemOperatingEventArgs deselecting_arg = new TabItemOperatingEventArgs(old_tabPage);
                    this.OnTabItemDeselecting(deselecting_arg);
                    if (deselecting_arg.Cancel)
                    {
                        return;
                    }

                    //旧已选中选项取消后事件
                    TabItemOperatedEventArgs deselected_arg = new TabItemOperatedEventArgs(old_tabPage);
                    this.OnTabItemDeselected(deselected_arg);
                }

                this.selectedIndex = value;
                TabPagePlusExt new_tabPage = this.GetTabPage(this.selectedIndex);
                if (new_tabPage != null)
                {
                    // 新选项选中中事件
                    TabItemOperatingEventArgs selecting_arg = new TabItemOperatingEventArgs(new_tabPage);
                    this.OnTabItemSelecting(selecting_arg);
                    if (selecting_arg.Cancel)
                    {
                        this.selectedIndex = old_tabPageIndex;
                        return;
                    }

                    // 新选项选中后事件
                    TabItemOperatedEventArgs selected_arg = new TabItemOperatedEventArgs(new_tabPage);
                    this.OnTabItemSelected(selected_arg);
                }

                //选中索引更改事件
                this.OnSelectedIndexChanged(new TabItemOperatedEventArgs(this.SelectedTab));

                //更新画面信息
                this.ReplenishSelectTabItemToRectangle();
                this.ReplenishTabItemToRectangleForLeft();
                this.Invalidate();

                this.SetActiveTabPage(this.selectedIndex);
            }
        }

        /// <summary>
        /// 已选中TabPage
        /// </summary>
        [Description("已选中TabPage")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabPagePlusExt SelectedTab
        {
            get
            {
                if (this.SelectedIndex < 0 || this.SelectedIndex >= this.TabCount)
                    return null;

                return this.TabPages[this.SelectedIndex];
            }
            set
            {
                int index = this.FindTabPage(value);

                if (this.selectedIndex < 0 || this.selectedIndex >= this.TabCount)
                    return;

                this.SelectedIndex = index;
            }
        }

        #endregion

        #region 主体

        private int pageMainBorderThickness = 1;
        /// <summary>
        /// Page主体区域边框厚度
        /// </summary>
        [Description("Page主体区域边框厚度")]
        [Category("杂项_Page区域")]
        [DefaultValue(1)]
        public int PageMainBorderThickness
        {
            get { return this.pageMainBorderThickness; }
            set
            {
                if (this.pageMainBorderThickness == value || value < 0)
                    return;

                this.pageMainBorderThickness = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color pageMainBackColor = Color.White;
        /// <summary>
        /// Page主体区域背景色
        /// </summary>
        [Description("Page主体区域背景色")]
        [Category("杂项_Page区域")]
        [DefaultValue(typeof(Color), "White")]
        public Color PageMainBackColor
        {
            get { return this.pageMainBackColor; }
            set
            {
                if (this.pageMainBackColor == value)
                    return;

                this.pageMainBackColor = value;
                base.Invalidate();
            }
        }

        private Color pageMainBorderColor = Color.FromArgb(176, 197, 175);
        /// <summary>
        /// Page主体区域边框色
        /// </summary>
        [Description("Page主体区域边框色")]
        [Category("杂项_Page区域")]
        [DefaultValue(typeof(Color), "176, 197, 175")]
        public Color PageMainBorderColor
        {
            get { return this.pageMainBorderColor; }
            set
            {
                if (this.pageMainBorderColor == value)
                    return;

                this.pageMainBorderColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Page主体区域Rect(排除外边框)
        /// </summary>
        [Description("Page主体区域Rect(排除外边框)")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle PageMainDisplayRectangle
        {
            get
            {
                return this.pagemain_c_rect;
            }
        }

        #endregion

        #region 下拉面板

        private TabControlPlusDropDownPanelClass dropDownPanel;
        /// <summary>
        /// 下拉面板
        /// </summary>
        [Description("下拉面板")]
        [Category("杂项_下拉面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabControlPlusDropDownPanelClass DropDownPanel
        {
            get
            {
                if (this.dropDownPanel == null)
                    this.dropDownPanel = new TabControlPlusDropDownPanelClass();
                return this.dropDownPanel;
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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(650, 300);
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get
            {
                return new Padding(0);
            }
            set
            {
                base.Padding = new Padding(0);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                base.BackColor = Color.Transparent;
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
            get { return base.Font; }
            set { base.Font = value; }
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

        #endregion

        #region 字段

        /// <summary>
        /// 菜单rect(包含：内边距、内容)
        /// </summary>
        private Rectangle menubar_p_rect = new Rectangle();

        /// <summary>
        /// 菜单rect(包含：内容)
        /// </summary>
        private Rectangle menubar_c_rect = new Rectangle();

        /// <summary>
        /// 全局自定义按钮rect(包含：内容)
        /// </summary>
        private Rectangle menubar_globalcustombuttton_c_rect = new Rectangle();

        /// <summary>
        /// 导航栏rect(包含：内容)
        /// </summary>
        private Rectangle menubar_navigation_c_rect = new Rectangle();

        /// <summary>
        /// tabitem显示的总区域(菜单rect减去全局自定义按钮rect减去导航栏rect)
        /// </summary>
        private Rectangle menubar_items_c_rect = new Rectangle();

        /// <summary>
        /// Page主体区域(包含：内容)
        /// </summary>
        private Rectangle pagemain_c_rect = new Rectangle();

        /// <summary>
        /// 在tabitem显示的总区域中要显示的第一个tabitem的索引
        /// </summary>
        private int menubar_items_start_index = 0;

        /// <summary>
        /// 视觉上当前导航栏是否显示
        /// </summary>
        private bool menubar_navigation_visualstatus = false;

        /// <summary>
        /// 用于存放TabPage数组
        /// </summary>
        private TabPagePlusExt[] tabPages = new TabPagePlusExt[0];

        /// <summary>
        /// 当前鼠标已按下的对象
        /// </summary>
        private object currentMouseDownObject = null;

        /// <summary>
        /// 提示信息弹层拥有者
        /// </summary>
        private static TabControlPlusExt tte_owner = null;

        /// <summary>
        /// 提示信息弹层
        /// </summary>
        private static ToolTipExt tte;

        /// <summary>
        /// 下拉面板
        /// </summary>
        private TabControlPlusDropDownPanelExt panel = null;

        /// <summary>
        /// 下拉面板浮层
        /// </summary>
        private ToolStripDropDown tsdd = null;

        /// <summary>
        /// 下拉面板浮层容器
        /// </summary>
        private ToolStripControlHost tsch = null;

        #endregion

        #region 构造

        public TabControlPlusExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, true);

            this.BackColor = Color.Transparent;

            this.InitializeRectangle();
        }

        #endregion

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Region source_c_region = g.Clip;//控件绘图区(C)

            Region menubar_p_region = new Region(this.menubar_p_rect);//菜单绘图区(P)
            g.Clip = menubar_p_region;

            #region 菜单背景

            MenuBarDrawBackgroundBeforeEventArgs menubar_before_arg = new MenuBarDrawBackgroundBeforeEventArgs(DotsPerInchHelper.DPIScale, g, this.menubar_p_rect, this.menubar_p_rect, this.menubar_c_rect, false);
            if (!menubar_before_arg.Finish)
            {
                SolidBrush menubar_back_sb = new SolidBrush(this.Enabled ? this.MenuBarBackNormalColor : this.MenuBarBackDisableColor);
                g.FillRectangle(menubar_back_sb, this.menubar_p_rect);
                menubar_back_sb.Dispose();

                this.OnMenuBarDrawBackgroundAfter(new MenuBarDrawBackgroundAfterEventArgs(DotsPerInchHelper.DPIScale, g, this.menubar_p_rect, this.menubar_p_rect, this.menubar_c_rect));
            }

            #endregion

            Region menubar_c_region = new Region(this.menubar_c_rect);//菜单绘图区(C)
            g.Clip = menubar_c_region;

            #region 全局按钮

            if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                {
                    GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                    if (btn.Visible)
                    {
                        Image btn_image = this.GetGlobalCustomButttonImage(btn);
                        g.DrawImage(btn_image, btn.C_Rect, new RectangleF(0, 0, btn_image.Width, btn_image.Height), GraphicsUnit.Pixel);
                    }
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)
                {
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Image btn_image = this.GetGlobalCustomButttonImage(btn);
                            btn_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(btn_image, btn.C_Rect, new RectangleF(0, 0, btn_image.Width, btn_image.Height), GraphicsUnit.Pixel);
                            btn_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }
                }
                else
                {
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Image btn_image = this.GetGlobalCustomButttonImage(btn);
                            g.DrawImage(btn_image, btn.C_Rect, new RectangleF(0, 0, btn_image.Width, btn_image.Height), GraphicsUnit.Pixel);
                        }
                    }
                }
            }

            #endregion

            #region 导航栏

            if (this.NavigationVisible && this.menubar_navigation_visualstatus)
            {
                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    if (this.NavigationPrevButton.Style == NavigationButtonStyles.Default)
                    {
                        PointF[] prev_point = new PointF[3]{
                            new PointF(this.NavigationPrevButton.C_Rect.X, this.NavigationPrevButton.C_Rect.Y + this.NavigationPrevButton.C_Rect.Height / 2),
                            new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Bottom),
                            new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Y)
                            };

                        SolidBrush navigation_prev_back_sb = null;
                        SolidBrush navigation_prev_fore_sb = null;
                        this.GetDrawPrevButtonColorBrush(ref navigation_prev_back_sb, ref navigation_prev_fore_sb);
                        g.FillRectangle(navigation_prev_back_sb, this.NavigationPrevButton.C_Rect);

                        SmoothingMode source_sm = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillPolygon(navigation_prev_fore_sb, prev_point);

                        Color btn_border_color = navigation_prev_fore_sb.Color;
                        Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                        g.DrawPolygon(btn_obrder_pen, prev_point);
                        btn_obrder_pen.Dispose();

                        g.SmoothingMode = source_sm;

                        navigation_prev_back_sb.Dispose();
                        navigation_prev_fore_sb.Dispose();
                    }
                    else
                    {
                        Image prev_image = this.GetDrawPrevButtonImage();
                        g.DrawImage(prev_image, this.NavigationPrevButton.C_Rect, new Rectangle(0, 0, prev_image.Width, prev_image.Height), GraphicsUnit.Pixel);
                    }

                    if (this.NavigationNextButton.Style == NavigationButtonStyles.Default)
                    {
                        PointF[] next_point = new PointF[3]{
                            new PointF(this.NavigationNextButton.C_Rect.Right, this.NavigationNextButton.C_Rect.Y + this.NavigationNextButton.C_Rect.Height / 2),
                            new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Bottom),
                            new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Y)
                           };

                        SolidBrush navigation_next_back_sb = null;
                        SolidBrush navigation_next_fore_sb = null;
                        this.GetDrawNextButtonColorBrush(ref navigation_next_back_sb, ref navigation_next_fore_sb);
                        g.FillRectangle(navigation_next_back_sb, this.NavigationNextButton.C_Rect);

                        SmoothingMode source_sm = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillPolygon(navigation_next_fore_sb, next_point);

                        Color btn_border_color = navigation_next_fore_sb.Color;
                        Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                        g.DrawPolygon(btn_obrder_pen, next_point);
                        btn_obrder_pen.Dispose();

                        g.SmoothingMode = source_sm;

                        navigation_next_back_sb.Dispose();
                        navigation_next_fore_sb.Dispose();
                    }
                    else
                    {
                        Image next_image = this.GetDrawNextButtonImage();
                        g.DrawImage(next_image, this.NavigationNextButton.C_Rect, new Rectangle(0, 0, next_image.Width, next_image.Height), GraphicsUnit.Pixel);
                    }
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left)
                {
                    if (this.TabItemVerticalLayout)
                    {
                        if (this.NavigationPrevButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] prev_point = new PointF[3]{
                                new PointF(this.NavigationPrevButton.C_Rect.X+this.NavigationPrevButton.C_Rect.Width/2, this.NavigationPrevButton.C_Rect.Y),
                                new PointF(this.NavigationPrevButton.C_Rect.X, this.NavigationPrevButton.C_Rect.Bottom),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Bottom)
                                };

                            SolidBrush navigation_prev_back_sb = null;
                            SolidBrush navigation_prev_fore_sb = null;
                            this.GetDrawPrevButtonColorBrush(ref navigation_prev_back_sb, ref navigation_prev_fore_sb);
                            g.FillRectangle(navigation_prev_back_sb, this.NavigationPrevButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_prev_fore_sb, prev_point);

                            Color btn_border_color = navigation_prev_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, prev_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_prev_back_sb.Dispose();
                            navigation_prev_fore_sb.Dispose();
                        }
                        else
                        {
                            Image prev_image = this.GetDrawPrevButtonImage();
                            prev_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(prev_image, this.NavigationPrevButton.C_Rect, new Rectangle(0, 0, prev_image.Width, prev_image.Height), GraphicsUnit.Pixel);
                            prev_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }

                        if (this.NavigationNextButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] next_point = new PointF[3]{
                                new PointF(this.NavigationNextButton.C_Rect.X+this.NavigationNextButton.C_Rect.Width/2, this.NavigationNextButton.C_Rect.Bottom),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Y),
                                new PointF(this.NavigationNextButton.C_Rect.Right, this.NavigationNextButton.C_Rect.Y)
                                };

                            SolidBrush navigation_next_back_sb = null;
                            SolidBrush navigation_next_fore_sb = null;
                            this.GetDrawNextButtonColorBrush(ref navigation_next_back_sb, ref navigation_next_fore_sb);
                            g.FillRectangle(navigation_next_back_sb, this.NavigationNextButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_next_fore_sb, next_point);

                            Color btn_border_color = navigation_next_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, next_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_next_back_sb.Dispose();
                            navigation_next_fore_sb.Dispose();
                        }
                        else
                        {
                            Image next_image = this.GetDrawNextButtonImage();
                            next_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(next_image, this.NavigationNextButton.C_Rect, new Rectangle(0, 0, next_image.Width, next_image.Height), GraphicsUnit.Pixel);
                            next_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }
                    else
                    {
                        if (this.NavigationPrevButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] prev_point = new PointF[3]{
                                new PointF(this.NavigationPrevButton.C_Rect.X, this.NavigationPrevButton.C_Rect.Y + this.NavigationPrevButton.C_Rect.Height / 2),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Bottom),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Y)
                                };

                            SolidBrush navigation_prev_back_sb = null;
                            SolidBrush navigation_prev_fore_sb = null;
                            this.GetDrawPrevButtonColorBrush(ref navigation_prev_back_sb, ref navigation_prev_fore_sb);
                            g.FillRectangle(navigation_prev_back_sb, this.NavigationPrevButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_prev_fore_sb, prev_point);

                            Color btn_border_color = navigation_prev_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, prev_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_prev_back_sb.Dispose();
                            navigation_prev_fore_sb.Dispose();
                        }
                        else
                        {
                            Image prev_image = this.GetDrawPrevButtonImage();
                            g.DrawImage(prev_image, this.NavigationPrevButton.C_Rect, new Rectangle(0, 0, prev_image.Width, prev_image.Height), GraphicsUnit.Pixel);
                        }

                        if (this.NavigationNextButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] next_point = new PointF[3]{
                                new PointF(this.NavigationNextButton.C_Rect.Right, this.NavigationNextButton.C_Rect.Y + this.NavigationNextButton.C_Rect.Height / 2),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Bottom),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Y)
                                };

                            SolidBrush navigation_next_back_sb = null;
                            SolidBrush navigation_next_fore_sb = null;
                            this.GetDrawNextButtonColorBrush(ref navigation_next_back_sb, ref navigation_next_fore_sb);
                            g.FillRectangle(navigation_next_back_sb, this.NavigationNextButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_next_fore_sb, next_point);

                            Color btn_border_color = navigation_next_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, next_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_next_back_sb.Dispose();
                            navigation_next_fore_sb.Dispose();
                        }
                        else
                        {
                            Image next_image = this.GetDrawNextButtonImage();
                            g.DrawImage(next_image, this.NavigationNextButton.C_Rect, new Rectangle(0, 0, next_image.Width, next_image.Height), GraphicsUnit.Pixel);
                        }
                    }
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabItemVerticalLayout)
                    {
                        if (this.NavigationPrevButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] prev_point = new PointF[3]{
                                new PointF(this.NavigationPrevButton.C_Rect.X+this.NavigationPrevButton.C_Rect.Width/2, this.NavigationPrevButton.C_Rect.Y),
                                new PointF(this.NavigationPrevButton.C_Rect.X, this.NavigationPrevButton.C_Rect.Bottom),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Bottom)
                                };

                            SolidBrush navigation_prev_back_sb = null;
                            SolidBrush navigation_prev_fore_sb = null;
                            this.GetDrawPrevButtonColorBrush(ref navigation_prev_back_sb, ref navigation_prev_fore_sb);
                            g.FillRectangle(navigation_prev_back_sb, this.NavigationPrevButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_prev_fore_sb, prev_point);

                            Color btn_border_color = navigation_prev_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, prev_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_prev_back_sb.Dispose();
                            navigation_prev_fore_sb.Dispose();
                        }
                        else
                        {
                            Image prev_image = this.GetDrawPrevButtonImage();
                            prev_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(prev_image, this.NavigationPrevButton.C_Rect, new Rectangle(0, 0, prev_image.Width, prev_image.Height), GraphicsUnit.Pixel);
                            prev_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }

                        if (this.NavigationNextButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] next_point = new PointF[3]{
                                new PointF(this.NavigationNextButton.C_Rect.X+this.NavigationNextButton.C_Rect.Width/2, this.NavigationNextButton.C_Rect.Bottom),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Y),
                                new PointF(this.NavigationNextButton.C_Rect.Right, this.NavigationNextButton.C_Rect.Y)
                                };

                            SolidBrush navigation_next_back_sb = null;
                            SolidBrush navigation_next_fore_sb = null;
                            this.GetDrawNextButtonColorBrush(ref navigation_next_back_sb, ref navigation_next_fore_sb);
                            g.FillRectangle(navigation_next_back_sb, this.NavigationNextButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_next_fore_sb, next_point);

                            Color btn_border_color = navigation_next_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, next_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_next_back_sb.Dispose();
                            navigation_next_fore_sb.Dispose();
                        }
                        else
                        {
                            Image next_image = this.GetDrawNextButtonImage();
                            next_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(next_image, this.NavigationNextButton.C_Rect, new Rectangle(0, 0, next_image.Width, next_image.Height), GraphicsUnit.Pixel);
                            next_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }
                    else
                    {
                        if (this.NavigationPrevButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] prev_point = new PointF[3]{
                                new PointF(this.NavigationPrevButton.C_Rect.X, this.NavigationPrevButton.C_Rect.Y + this.NavigationPrevButton.C_Rect.Height / 2),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Bottom),
                                new PointF(this.NavigationPrevButton.C_Rect.Right, this.NavigationPrevButton.C_Rect.Y)
                                };

                            SolidBrush navigation_prev_back_sb = null;
                            SolidBrush navigation_prev_fore_sb = null;
                            this.GetDrawPrevButtonColorBrush(ref navigation_prev_back_sb, ref navigation_prev_fore_sb);
                            g.FillRectangle(navigation_prev_back_sb, this.NavigationPrevButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_prev_fore_sb, prev_point);

                            Color btn_border_color = navigation_prev_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, prev_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_prev_back_sb.Dispose();
                            navigation_prev_fore_sb.Dispose();
                        }
                        else
                        {
                            Image prev_image = this.GetDrawPrevButtonImage();
                            g.DrawImage(prev_image, this.NavigationPrevButton.C_Rect, new Rectangle(0, 0, prev_image.Width, prev_image.Height), GraphicsUnit.Pixel);
                        }

                        if (this.NavigationNextButton.Style == NavigationButtonStyles.Default)
                        {
                            PointF[] next_point = new PointF[3]{
                                new PointF(this.NavigationNextButton.C_Rect.Right, this.NavigationNextButton.C_Rect.Y + this.NavigationNextButton.C_Rect.Height / 2),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Bottom),
                                new PointF(this.NavigationNextButton.C_Rect.X, this.NavigationNextButton.C_Rect.Y)
                                };

                            SolidBrush navigation_next_back_sb = null;
                            SolidBrush navigation_next_fore_sb = null;
                            this.GetDrawNextButtonColorBrush(ref navigation_next_back_sb, ref navigation_next_fore_sb);
                            g.FillRectangle(navigation_next_back_sb, this.NavigationNextButton.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.FillPolygon(navigation_next_fore_sb, next_point);

                            Color btn_border_color = navigation_next_fore_sb.Color;
                            Pen btn_obrder_pen = new Pen((double)btn_border_color.GetBrightness() >= 0.5 ? ControlPaint.Dark(btn_border_color, 0.1f) : ControlPaint.Light(btn_border_color, 0.1f));
                            g.DrawPolygon(btn_obrder_pen, next_point);
                            btn_obrder_pen.Dispose();

                            g.SmoothingMode = source_sm;

                            navigation_next_back_sb.Dispose();
                            navigation_next_fore_sb.Dispose();
                        }
                        else
                        {
                            Image next_image = this.GetDrawNextButtonImage();
                            g.DrawImage(next_image, this.NavigationNextButton.C_Rect, new Rectangle(0, 0, next_image.Width, next_image.Height), GraphicsUnit.Pixel);
                        }
                    }
                }
            }

            #endregion

            #region 选项

            if (this.TabCount > 0)
            {
                #region 笔刷

                //存放选项通用笔刷
                SolidBrush tabitem_back_normal_commom_sb = null;
                SolidBrush tabitem_back_enter_commom_sb = null;
                SolidBrush tabitem_back_selected_commom_sb = null;
                SolidBrush tabitem_back_disable_commom_sb = null;

                SolidBrush tabitem_text_normal_commom_sb = null;
                SolidBrush tabitem_text_enter_commom_sb = null;
                SolidBrush tabitem_text_selected_commom_sb = null;
                SolidBrush tabitem_text_disable_commom_sb = null;

                StringFormat text_sf = new StringFormat() { Alignment = this.TabItemTextAlignment };

                //存放选项关闭按钮通用笔刷
                SolidBrush tabitem_closebutton_back_normal_commom_sb = null;
                SolidBrush tabitem_closebutton_back_enter_commom_sb = null;
                SolidBrush tabitem_closebutton_back_disable_commom_sb = null;
                Pen tabitem_closebutton_fore_normal_commom_pen = null;
                Pen tabitem_closebutton_fore_enter_commom_pen = null;
                Pen tabitem_closebutton_fore_disable_commom_pen = null;

                #endregion

                for (int i = 0; i < this.TabCount; i++)
                {
                    TabPagePlusExt tab_page = this.TabPages[i];
                    if (!this.GetTabItemVisualStatus(tab_page))
                    {
                        continue;
                    }

                    Region item_p_region = new Region(tab_page.P_GP);//选项绘图区(P)
                    item_p_region.Intersect(this.menubar_items_c_rect);
                    g.Clip = item_p_region;

                    #region  绘制选项背景颜色

                    SolidBrush tabitem_back_sb = null;
                    bool tabitem_back_is_commom_sb = false;
                    SolidBrush tabitem_text_sb = null;
                    bool tabitem_text_is_commom_sb = false;

                    this.GetProperty_ItemSolidBrush(
                        tab_page,
                        ref tabitem_back_normal_commom_sb, ref tabitem_back_enter_commom_sb, ref tabitem_back_selected_commom_sb, ref tabitem_back_disable_commom_sb, ref tabitem_back_sb, ref tabitem_back_is_commom_sb,
                        ref tabitem_text_normal_commom_sb, ref tabitem_text_enter_commom_sb, ref tabitem_text_selected_commom_sb, ref tabitem_text_disable_commom_sb, ref tabitem_text_sb, ref tabitem_text_is_commom_sb
                        );

                    if (this.TabItemRoundedAntiAlias)
                    {
                        SmoothingMode source_sm = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillPath(tabitem_back_sb, tab_page.P_GP);
                        g.SmoothingMode = source_sm;
                    }
                    else
                    {
                        g.FillPath(tabitem_back_sb, tab_page.P_GP);
                    }

                    if (tabitem_back_is_commom_sb == false && tabitem_back_sb != null)
                    {
                        tabitem_back_sb.Dispose();
                    }

                    RectangleF item_p_rect_tmp = new RectangleF(tab_page.P_Rect.X, tab_page.P_Rect.Y, tab_page.P_Rect.Width, tab_page.P_Rect.Height);
                    item_p_rect_tmp.Intersect(this.menubar_items_c_rect);
                    this.OnTabItemDrawBackgroundAfter(new TabItemDrawBackgroundAfterEventArgs(tab_page, DotsPerInchHelper.DPIScale, g, this.menubar_items_c_rect, item_p_rect_tmp, tab_page.M_Rect, tab_page.P_Rect, tab_page.C_Rect));

                    #endregion

                    Region item_c_region = item_p_region.Clone();//选项绘图区(C)
                    item_c_region.Intersect(tab_page.C_Rect);
                    g.Clip = item_c_region;

                    #region 绘制选项图标

                    if (this.GetProperty_ItemIcoVisible(tab_page))
                    {
                        Image ico_image = tab_page.TabItemEnabled ? tab_page.TabItemIcoImage : tab_page.TabItemIcoImageDisable;
                        if (ico_image == null)
                        {
                            ico_image = Resources.tabcontrol_item_default_ico;
                        }

                        if ((this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right) && this.TabItemVerticalLayout)
                        {
                            ico_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            g.DrawImage(ico_image, tab_page.Ico_C_Rect, new Rectangle(0, 0, ico_image.Width, ico_image.Height), GraphicsUnit.Pixel);
                            ico_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        else
                        {
                            g.DrawImage(ico_image, tab_page.Ico_C_Rect, new Rectangle(0, 0, ico_image.Width, ico_image.Height), GraphicsUnit.Pixel);
                        }

                        RectangleF item_ico_c_rect_tmp = new RectangleF(tab_page.Ico_C_Rect.X, tab_page.Ico_C_Rect.Y, tab_page.Ico_C_Rect.Width, tab_page.Ico_C_Rect.Height);
                        item_ico_c_rect_tmp.Intersect(tab_page.C_Rect);
                        item_ico_c_rect_tmp.Intersect(this.menubar_items_c_rect);
                        tab_page.OnItemIcoDrawAfter(new TabPagePlusExt.TabItemIcoDrawAfterEventArgs(tab_page, DotsPerInchHelper.DPIScale, g, item_ico_c_rect_tmp, tab_page.Ico_M_Rect, tab_page.Ico_C_Rect));
                    }

                    #endregion

                    #region 绘制选项文本

                    if ((this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right) && this.TabItemVerticalLayout)
                    {
                        //纵向文本
                        if (tab_page.TabItemTextVerticalLayout == false)
                        {
                            if (tab_page.Text_C_Rect.Width > 0)
                            {
                                text_sf.Trimming = tab_page.TabItemTextEllipsisCharacter ? StringTrimming.EllipsisCharacter : StringTrimming.None;
                                g.TranslateTransform(tab_page.Text_C_Rect.Right, tab_page.Text_C_Rect.Y);
                                g.RotateTransform(90);
                                g.DrawString(tab_page.Text, this.TabItemFont, tabitem_text_sb, new RectangleF(0, 0, tab_page.Text_C_Rect.Height, tab_page.Text_C_Rect.Width), text_sf);
                                g.ResetTransform();
                            }
                        }
                        //垂直文本
                        else
                        {
                            if (tab_page.Text_C_Rect.Height > 0)
                            {
                                text_sf.Trimming = StringTrimming.None;
                                g.DrawString(tab_page.TextVerticalLayoutTmp, this.TabItemFont, tabitem_text_sb, tab_page.Text_C_Rect);
                            }
                        }
                    }
                    //横向文本
                    else
                    {
                        if (tab_page.Text_C_Rect.Width > 0)
                        {
                            text_sf.Trimming = tab_page.TabItemTextEllipsisCharacter ? StringTrimming.EllipsisCharacter : StringTrimming.None;
                            g.DrawString(tab_page.Text, this.TabItemFont, tabitem_text_sb, tab_page.Text_C_Rect, text_sf);
                        }
                    }

                    if (tabitem_text_is_commom_sb == false && tabitem_text_sb != null)
                    {
                        tabitem_text_sb.Dispose();
                    }

                    #endregion

                    #region  绘制选项自定义按钮

                    for (int k = 0; k < tab_page.TabItemCustomButtons.Count; k++)
                    {
                        TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                        if (btn.Visible)
                        {

                            Image btn_image = this.GetTabItemCustomButttonImage(tab_page, btn);
                            if ((this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right) && this.TabItemVerticalLayout)
                            {
                                btn_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                g.DrawImage(btn_image, btn.C_Rect, new Rectangle(0, 0, btn_image.Width, btn_image.Height), GraphicsUnit.Pixel);
                                btn_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            }
                            else
                            {
                                g.DrawImage(btn_image, btn.C_Rect, new Rectangle(0, 0, btn_image.Width, btn_image.Height), GraphicsUnit.Pixel);
                            }

                            RectangleF item_custombutton_c_rect_tmp = new RectangleF(btn.C_Rect.X, btn.C_Rect.Y, btn.C_Rect.Width, btn.C_Rect.Height);
                            item_custombutton_c_rect_tmp.Intersect(tab_page.C_Rect);
                            item_custombutton_c_rect_tmp.Intersect(this.menubar_items_c_rect);
                            btn.OnTabItemCusomButtonDrawAfter(new TabPagePlusExt.TabItemCustomButtonDrawAfterEventArgs(tab_page, btn, DotsPerInchHelper.DPIScale, g, item_custombutton_c_rect_tmp, btn.M_Rect, btn.C_Rect));
                        }
                    }

                    #endregion

                    #region 绘制选项关闭按钮

                    if (this.GetProperty_ItemColseVisible(tab_page))
                    {
                        TabPagePlusExt.TabItemCloseButtonClass btn = tab_page.TabItemCloseButton;

                        SolidBrush close_back_sb = null;
                        Pen close_fore_pen = null;
                        bool close_back_is_commom_sb = false;
                        bool close_fore_is_commom_pen = false;

                        this.GetTabItemClosePen(
                            tab_page, ref tabitem_closebutton_back_normal_commom_sb, ref tabitem_closebutton_back_enter_commom_sb, ref tabitem_closebutton_back_disable_commom_sb, ref close_back_sb, ref close_back_is_commom_sb,
                            ref tabitem_closebutton_fore_normal_commom_pen, ref tabitem_closebutton_fore_enter_commom_pen, ref tabitem_closebutton_fore_disable_commom_pen, ref close_fore_pen, ref close_fore_is_commom_pen
                            );

                        RectangleF item_close_c_rect_tmp = new RectangleF(btn.C_Rect.X, btn.C_Rect.Y, btn.C_Rect.Width, btn.C_Rect.Height);
                        item_close_c_rect_tmp.Intersect(tab_page.C_Rect);
                        item_close_c_rect_tmp.Intersect(this.menubar_items_c_rect);
                        TabPagePlusExt.TabItemCloseButtonDrawBeforeEventArgs arg = new TabPagePlusExt.TabItemCloseButtonDrawBeforeEventArgs(tab_page, DotsPerInchHelper.DPIScale, g, close_back_sb, close_fore_pen, item_close_c_rect_tmp, btn.M_Rect, btn.C_Rect, false);
                        tab_page.OnTabItemCloseButtonDrawBefore(arg);
                        if (!arg.Finish)
                        {
                            g.FillRectangle(close_back_sb, btn.C_Rect);

                            SmoothingMode source_sm = g.SmoothingMode;
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.DrawLine(close_fore_pen, new PointF(btn.C_Rect.X + close_fore_pen.Width, btn.C_Rect.Y + close_fore_pen.Width), new PointF(btn.C_Rect.Right - close_fore_pen.Width, btn.C_Rect.Bottom - close_fore_pen.Width));
                            g.DrawLine(close_fore_pen, new PointF(btn.C_Rect.Right - close_fore_pen.Width, btn.C_Rect.Y + close_fore_pen.Width), new PointF(btn.C_Rect.Left + close_fore_pen.Width, btn.C_Rect.Bottom - close_fore_pen.Width));
                            g.SmoothingMode = source_sm;
                        }

                        if (!close_back_is_commom_sb)
                            close_back_sb.Dispose();
                        if (!close_fore_is_commom_pen)
                            close_fore_pen.Dispose();
                    }

                    #endregion


                    item_c_region.Dispose();
                    item_p_region.Dispose();
                }

                #region 释放

                if (tabitem_back_normal_commom_sb != null)
                    tabitem_back_normal_commom_sb.Dispose();
                if (tabitem_back_enter_commom_sb != null)
                    tabitem_back_enter_commom_sb.Dispose();
                if (tabitem_back_selected_commom_sb != null)
                    tabitem_back_selected_commom_sb.Dispose();
                if (tabitem_back_disable_commom_sb != null)
                    tabitem_back_disable_commom_sb.Dispose();
                if (tabitem_text_normal_commom_sb != null)
                    tabitem_text_normal_commom_sb.Dispose();
                if (tabitem_text_enter_commom_sb != null)
                    tabitem_text_enter_commom_sb.Dispose();
                if (tabitem_text_selected_commom_sb != null)
                    tabitem_text_selected_commom_sb.Dispose();
                if (tabitem_text_disable_commom_sb != null)
                    tabitem_text_disable_commom_sb.Dispose();
                if (text_sf != null)
                    text_sf.Dispose();

                if (tabitem_closebutton_back_normal_commom_sb != null)
                    tabitem_closebutton_back_normal_commom_sb.Dispose();
                if (tabitem_closebutton_back_enter_commom_sb != null)
                    tabitem_closebutton_back_enter_commom_sb.Dispose();
                if (tabitem_closebutton_back_disable_commom_sb != null)
                    tabitem_closebutton_back_disable_commom_sb.Dispose();
                if (tabitem_closebutton_fore_normal_commom_pen != null)
                    tabitem_closebutton_fore_normal_commom_pen.Dispose();
                if (tabitem_closebutton_fore_enter_commom_pen != null)
                    tabitem_closebutton_fore_enter_commom_pen.Dispose();
                if (tabitem_closebutton_fore_disable_commom_pen != null)
                    tabitem_closebutton_fore_disable_commom_pen.Dispose();

                #endregion
            }

            #endregion

            g.Clip = source_c_region;

            #region Page主体区域

            SolidBrush pagemain_back_sb = new SolidBrush(this.PageMainBackColor);
            g.FillRectangle(pagemain_back_sb, this.pagemain_c_rect);
            pagemain_back_sb.Dispose();

            if (this.PageMainBorderThickness > 0)
            {
                Pen pagemain_border_pen = new Pen(this.PageMainBorderColor, this.PageMainBorderThickness) { Alignment = PenAlignment.Inset };
                g.DrawRectangle(pagemain_border_pen, new Rectangle(this.pagemain_c_rect.X - this.PageMainBorderThickness, this.pagemain_c_rect.Y - this.PageMainBorderThickness, this.pagemain_c_rect.Width - (this.PageMainBorderThickness == 1 ? 1 : 0) + this.PageMainBorderThickness * 2, this.pagemain_c_rect.Height - (this.PageMainBorderThickness == 1 ? 1 : 0) + this.PageMainBorderThickness * 2));
                pagemain_border_pen.Dispose();
            }

            #endregion

            menubar_c_region.Dispose();
            menubar_p_region.Dispose();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            this.currentMouseDownObject = null;
            this.ResetAllMouseStatus();
            this.TipHide();
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            this.currentMouseDownObject = null;
            this.ResetAllMouseStatus();
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.ResetAllMouseStatus();
            this.TipHide();
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.CanFocus && !this.Focused)
            {
                this.Focus();
            }

            // 检查当前鼠标按下的对象
            if (e.Button == MouseButtons.Left)
            {
                Point point = e.Location;

                if (this.menubar_c_rect.Contains(point) == false)
                {
                    this.currentMouseDownObject = null;
                    return;
                }

                bool isfind = false;

                //全局自定义按钮
                if (!isfind)
                {
                    if (this.GetGlobalCustomButttonVisualstatus() && this.menubar_globalcustombuttton_c_rect.Contains(point))
                    {
                        if (this.DesignMode)
                        {
                            isfind = true;
                            this.currentMouseDownObject = null;
                        }
                        else
                        {
                            for (int i = 0; i < this.GlobalCustomButttons.Count; i++)
                            {
                                GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                                if (btn.Visible && btn.Enabled && btn.C_Rect.Contains(point))
                                {
                                    isfind = true;
                                    this.currentMouseDownObject = btn;
                                    goto result;
                                }
                            }
                        }

                    result:
                        if (isfind == false && this.currentMouseDownObject != null)
                        {
                            this.currentMouseDownObject = null;
                        }
                    }
                }

                //导航栏
                if (!isfind)
                {
                    if (this.NavigationVisible && this.menubar_navigation_visualstatus && this.menubar_navigation_c_rect.Contains(point))
                    {
                        //上一页
                        if (this.NavigationPrevButton.C_Rect.Contains(point))
                        {
                            isfind = true;
                            this.currentMouseDownObject = this.NavigationPrevButton;
                            goto result;
                        }
                        //下一页
                        if (this.NavigationNextButton.C_Rect.Contains(point))
                        {
                            isfind = true;
                            this.currentMouseDownObject = this.NavigationNextButton;
                            goto result;
                        }

                    result:
                        if (isfind == false && this.currentMouseDownObject != null)
                        {
                            this.currentMouseDownObject = null;
                        }
                    }
                }

                //所有选项、选项自定义按钮、选项关闭按钮
                if (!isfind)
                {
                    if (this.DesignMode)
                    {
                        if (this.menubar_items_c_rect.Contains(point))
                        {
                            for (int i = 0; i < this.TabCount; i++)
                            {
                                if (this.TabPages[i].P_GP.IsVisible(point))
                                {
                                    isfind = true;
                                    this.currentMouseDownObject = this.TabPages[i];
                                    goto result;
                                }
                            }

                        result:
                            if (isfind == false && this.currentMouseDownObject != null)
                            {
                                this.currentMouseDownObject = null;
                            }
                        }
                    }
                    else
                    {
                        if (this.menubar_items_c_rect.Contains(point))
                        {
                            for (int i = 0; i < this.TabCount; i++)
                            {
                                if (this.TabPages[i].P_GP.IsVisible(point))
                                {
                                    if (this.TabPages[i].TabItemEnabled)
                                    {
                                        //自定义按钮
                                        foreach (TabPagePlusExt.TabItemCustomButtonClass btn in this.TabPages[i].TabItemCustomButtons)
                                        {
                                            if (btn.Visible && btn.Enabled && btn.C_Rect.Contains(point))
                                            {
                                                isfind = true;
                                                this.currentMouseDownObject = btn;
                                                goto result;
                                            }
                                        }

                                        //关闭按钮
                                        if (this.GetProperty_ItemColseVisible(this.tabPages[i]) && this.TabPages[i].TabItemCloseButton.Enabled && this.TabPages[i].TabItemCloseButton.C_Rect.Contains(point))
                                        {
                                            isfind = true;
                                            this.currentMouseDownObject = this.TabPages[i].TabItemCloseButton;
                                            goto result;
                                        }

                                        isfind = true;
                                        this.currentMouseDownObject = this.TabPages[i];
                                        goto result;
                                    }
                                    else
                                    {
                                        if (this.TabItemDisableActivation)
                                        {
                                            this.currentMouseDownObject = this.TabPages[i];
                                        }
                                    }

                                    isfind = true;
                                    goto result;
                                }

                            }

                        result:
                            if (isfind == false && this.currentMouseDownObject != null)
                            {
                                this.currentMouseDownObject = null;
                            }
                        }
                    }
                }
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // 检查当前鼠标释放的对象
            if (e.Button == MouseButtons.Left)
            {
                Point point = e.Location;

                if (this.menubar_c_rect.Contains(point) == false)
                {
                    this.currentMouseDownObject = null;
                    return;
                }

                bool isfind = false;

                //判断是否单击全局自定义按钮
                if (!isfind)
                {
                    if (this.GetGlobalCustomButttonVisualstatus() && this.menubar_globalcustombuttton_c_rect.Contains(point))
                    {
                        if (this.DesignMode == false)
                        {
                            for (int i = 0; i < this.GlobalCustomButttons.Count; i++)
                            {
                                GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                                if (btn.C_Rect.Contains(point))
                                {
                                    if (this.currentMouseDownObject == btn && btn.Enabled)
                                    {
                                        btn.OnGlobalCustomButttonClick(new GlobalCustomButttonEventArgs(btn));
                                    }
                                    isfind = true;
                                    goto restlt;
                                }
                            }
                        }

                        isfind = true;
                        goto restlt;
                    }

                restlt:
                    { }
                }


                // 判断是否单击导航栏按钮
                if (!isfind)
                {
                    if (this.NavigationVisible && this.menubar_navigation_visualstatus && this.menubar_navigation_c_rect.Contains(point))
                    {
                        //上一页
                        if (this.NavigationPrevButton.C_Rect.Contains(point))
                        {
                            if (this.currentMouseDownObject == this.NavigationPrevButton)
                            {
                                int index = this.menubar_items_start_index - 1;
                                if (index < 0)
                                {
                                    index = 0;
                                }

                                if (this.menubar_items_start_index != index)
                                {
                                    NavigationButtonOperatingEventArgs arg = new NavigationButtonOperatingEventArgs(NavigationButtonTypes.Prev, this.menubar_items_start_index, index, false);
                                    this.OnNavigationButtonOperating(arg);
                                    if (arg.Cancel == false)
                                    {
                                        this.menubar_items_start_index = index;

                                        this.UpdateEveryOneTabItemRectangle();
                                        this.Invalidate();

                                        this.OnNavigationButtonOperated(new NavigationButtonOperatedEventArgs(this.menubar_items_start_index));
                                    }
                                }
                            }
                            isfind = true;
                            goto restlt;
                        }
                        //下一页
                        if (this.NavigationNextButton.C_Rect.Contains(point))
                        {
                            if (this.currentMouseDownObject == this.NavigationNextButton)
                            {
                                bool isreset = false;
                                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                                {
                                    if (this.TabCount > 0 && this.TabPages[this.TabCount - 1].P_Rect.Right > this.menubar_items_c_rect.Right)
                                    {
                                        isreset = true;
                                    }
                                }
                                else
                                {
                                    if (this.TabCount > 0 && this.TabPages[this.TabCount - 1].P_Rect.Bottom >= this.menubar_items_c_rect.Bottom)
                                    {
                                        isreset = true;
                                    }
                                }

                                if (isreset)
                                {
                                    int index = this.menubar_items_start_index + 1;
                                    if (index >= this.TabCount)
                                    {
                                        index = this.TabCount - 1;
                                    }
                                    if (this.menubar_items_start_index != index)
                                    {
                                        NavigationButtonOperatingEventArgs arg = new NavigationButtonOperatingEventArgs(NavigationButtonTypes.Next, this.menubar_items_start_index, index, false);
                                        this.OnNavigationButtonOperating(arg);
                                        if (arg.Cancel == false)
                                        {
                                            this.menubar_items_start_index = index;

                                            this.UpdateEveryOneTabItemRectangle();
                                            this.Invalidate();

                                            this.OnNavigationButtonOperated(new NavigationButtonOperatedEventArgs(this.menubar_items_start_index));

                                        }
                                    }
                                }
                            }
                            isfind = true;
                            goto restlt;
                        }

                        isfind = true;
                        goto restlt;
                    }

                restlt:
                    { }
                }

                // 判断是否单击TabItem选项
                if (!isfind)
                {
                    if (this.DesignMode)
                    {
                        if (this.menubar_items_c_rect.Contains(point))
                        {
                            for (int i = 0; i < this.TabCount; i++)
                            {
                                if (this.TabPages[i].P_GP.IsVisible(point))
                                {
                                    if (this.currentMouseDownObject == this.TabPages[i])
                                    {
                                        this.SelectedIndex = i;
                                    }
                                    isfind = true;
                                    goto result;
                                }
                            }

                            isfind = true;
                            goto result;
                        }
                    }
                    else
                    {
                        if (this.menubar_items_c_rect.Contains(point))
                        {
                            for (int i = 0; i < this.TabCount; i++)
                            {
                                TabPagePlusExt tab_page = this.TabPages[i];
                                if (tab_page.P_GP.IsVisible(point))
                                {
                                    if (tab_page.TabItemEnabled)
                                    {
                                        //自定义按钮
                                        foreach (TabPagePlusExt.TabItemCustomButtonClass btn in tab_page.TabItemCustomButtons)
                                        {
                                            if (btn.Visible && btn.C_Rect.Contains(point))
                                            {
                                                if (this.currentMouseDownObject == btn && btn.Enabled)
                                                {
                                                    if (btn.CheckButton)
                                                    {
                                                        btn.Checked = !btn.Checked;
                                                    }
                                                    else
                                                    {
                                                        btn.OnTabItemCustomButtonClick(new TabPagePlusExt.TabItemCustomButttonOperatedEventArgs(tab_page, btn));
                                                    }
                                                }
                                                isfind = true;
                                                goto result;
                                            }
                                        }

                                        //关闭按钮
                                        if (this.GetProperty_ItemColseVisible(tab_page) && tab_page.TabItemCloseButton.C_Rect.Contains(point))
                                        {
                                            if (this.currentMouseDownObject == tab_page.TabItemCloseButton && tab_page.TabItemCloseButton.Enabled)
                                            {
                                                TabPagePlusExt.TabItemCloseButtonCloseingEventArgs arg = new TabPagePlusExt.TabItemCloseButtonCloseingEventArgs(tab_page, this.TabPages[i].TabItemCloseButton, false);
                                                tab_page.OnTabItemCloseButtonCloseing(arg);
                                                if (arg.Cancel == false)
                                                {
                                                    this.RemoveTabPage(i);

                                                    tab_page.OnTabItemCloseButtonClosed(new TabPagePlusExt.TabItemCloseButtonClosedEventArgs(tab_page, tab_page.TabItemCloseButton));
                                                }
                                            }

                                            isfind = true;
                                            goto result;
                                        }

                                        //选项选中
                                        if (this.currentMouseDownObject == tab_page)
                                        {
                                            this.SelectedIndex = i;
                                        }
                                        else
                                        {
                                            //选项移动
                                            if (this.TabItemInterchangeEnabled && this.currentMouseDownObject != null)
                                            {
                                                TabPagePlusExt current_tabpage_tmp = (TabPagePlusExt)this.currentMouseDownObject;
                                                //TabItem索引更改时事件
                                                TabItemInterchangeingEventArgs changeing_arg = new TabItemInterchangeingEventArgs(current_tabpage_tmp, tab_page);
                                                this.OnTabItemInterchangeing(changeing_arg);
                                                if (changeing_arg.Cancel)
                                                {
                                                    isfind = true;
                                                    goto result;
                                                }

                                                this.InterchangeTabItemIndex(current_tabpage_tmp, tab_page);

                                                //TabItem索引更改后事件
                                                TabItemInterchangedEventArgs changed_arg = new TabItemInterchangedEventArgs(current_tabpage_tmp, tab_page);
                                                this.OnTabItemInterchanged(changed_arg);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //选项选中
                                        if (this.currentMouseDownObject == tab_page)
                                        {
                                            if (this.TabItemDisableActivation)
                                            {
                                                this.SelectedIndex = i;
                                            }
                                        }
                                        else
                                        {
                                            //选项移动
                                            if (this.TabItemInterchangeEnabled && this.currentMouseDownObject != null)
                                            {
                                                TabPagePlusExt current_tabpage_tmp = (TabPagePlusExt)this.currentMouseDownObject;
                                                //TabItem索引更改时事件
                                                TabItemInterchangeingEventArgs changeing_arg = new TabItemInterchangeingEventArgs(current_tabpage_tmp, tab_page);
                                                this.OnTabItemInterchangeing(changeing_arg);
                                                if (changeing_arg.Cancel)
                                                {
                                                    isfind = true;
                                                    goto result;
                                                }

                                                this.InterchangeTabItemIndex(current_tabpage_tmp, tab_page);

                                                //TabItem索引更改后事件
                                                TabItemInterchangedEventArgs changed_arg = new TabItemInterchangedEventArgs(current_tabpage_tmp, tab_page);
                                                this.OnTabItemInterchanged(changed_arg);
                                            }
                                        }
                                    }

                                    isfind = true;
                                    goto result;
                                }
                            }

                            isfind = true;
                            goto result;
                        }
                    }

                result:
                    { }
                }

                if (this.currentMouseDownObject != null)
                {
                    this.currentMouseDownObject = null;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool isreset = false;
            Point point = e.Location;
            object tip_show_parts = null;
            object tip_hide_parts = null;

            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.menubar_items_c_rect.Contains(point) && this.TabPages[i].TabItemEnabled && this.TabPages[i].P_GP.IsVisible(point))
                {
                    if (this.TabPages[i].MouseStatus != MouseStatuss.Enter)
                    {
                        this.TabPages[i].MouseStatus = MouseStatuss.Enter;
                        isreset = true;
                    }

                    // 关闭
                    if (this.DesignMode == false && this.GetProperty_ItemColseVisible(this.TabPages[i]) && this.TabPages[i].TabItemCloseButton.Enabled && this.TabPages[i].TabItemCloseButton.C_Rect.Contains(point))
                    {
                        if (this.TabPages[i].TabItemCloseButton.MouseStatus != MouseStatuss.Enter)
                        {
                            this.TabPages[i].TabItemCloseButton.MouseStatus = MouseStatuss.Enter;
                            isreset = true;
                        }
                    }
                    else
                    {
                        if (this.TabPages[i].TabItemCloseButton.MouseStatus != MouseStatuss.Normal)
                        {
                            this.TabPages[i].TabItemCloseButton.MouseStatus = MouseStatuss.Normal;
                            isreset = true;
                        }
                    }

                    foreach (TabPagePlusExt.TabItemCustomButtonClass item in this.TabPages[i].TabItemCustomButtons)
                    {
                        if (this.DesignMode == false && item.Enabled && item.Visible && item.C_Rect.Contains(point))
                        {
                            if (item.MouseStatus != MouseStatuss.Enter)
                            {
                                item.MouseStatus = MouseStatuss.Enter;
                                tip_show_parts = item;
                                isreset = true;
                            }
                        }
                        else
                        {
                            if (item.MouseStatus != MouseStatuss.Normal)
                            {
                                item.MouseStatus = MouseStatuss.Normal;
                                tip_hide_parts = item;
                                isreset = true;
                            }
                        }
                    }
                }
                else
                {
                    if (this.TabPages[i].MouseStatus != MouseStatuss.Normal)
                    {
                        this.TabPages[i].MouseStatus = MouseStatuss.Normal;
                        isreset = true;
                    }

                    if (this.TabPages[i].TabItemCloseButton.MouseStatus != MouseStatuss.Normal)
                    {
                        this.TabPages[i].TabItemCloseButton.MouseStatus = MouseStatuss.Normal;
                        isreset = true;
                    }

                    foreach (TabPagePlusExt.TabItemCustomButtonClass item in this.TabPages[i].TabItemCustomButtons)
                    {
                        if (item.MouseStatus != MouseStatuss.Normal)
                        {
                            item.MouseStatus = MouseStatuss.Normal;
                            tip_hide_parts = item;
                            isreset = true;
                        }
                    }
                }
            }

            if (this.NavigationVisible && this.NavigationPrevButton.C_Rect.Contains(point))
            {
                if (this.NavigationPrevButton.MoveStatus != MouseStatuss.Enter)
                {
                    this.NavigationPrevButton.MoveStatus = MouseStatuss.Enter;
                    isreset = true;
                }
            }
            else
            {
                if (this.NavigationPrevButton.MoveStatus != MouseStatuss.Normal)
                {
                    this.NavigationPrevButton.MoveStatus = MouseStatuss.Normal;
                    isreset = true;
                }
            }
            if (this.NavigationVisible && this.NavigationNextButton.C_Rect.Contains(point))
            {
                if (this.NavigationNextButton.MoveStatus != MouseStatuss.Enter)
                {
                    this.NavigationNextButton.MoveStatus = MouseStatuss.Enter;
                    isreset = true;
                }
            }
            else
            {
                if (this.NavigationNextButton.MoveStatus != MouseStatuss.Normal)
                {
                    this.NavigationNextButton.MoveStatus = MouseStatuss.Normal;
                    isreset = true;
                }
            }

            if (this.menubar_globalcustombuttton_c_rect.Contains(point))
            {
                for (int i = 0; i < this.GlobalCustomButttons.Count; i++)
                {
                    GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                    if (btn.Visible && btn.C_Rect.Contains(point))
                    {
                        if (btn.MouseStatus != MouseStatuss.Enter)
                        {
                            btn.MouseStatus = MouseStatuss.Enter;
                            tip_show_parts = btn;
                            isreset = true;
                        }
                    }
                    else
                    {
                        if (btn.MouseStatus != MouseStatuss.Normal)
                        {
                            btn.MouseStatus = MouseStatuss.Normal;
                            tip_hide_parts = btn;
                            isreset = true;
                        }
                    }
                }
            }

            if (isreset)
            {
                this.Invalidate();
            }


            if (tip_hide_parts != null)
            {
                this.TipHide();
            }
            if (tip_show_parts != null)
            {
                this.TipShow(tip_show_parts);
            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.TabCount > 0)
            {
                if (this.DesignMode || this.TabItemDisableActivation)
                {
                    if (keyData == Keys.Left || keyData == Keys.Up)
                    {
                        this.SelectedIndex = Math.Max(0, this.SelectedIndex - 1);
                        return true;
                    }
                    else if (keyData == Keys.Right || keyData == Keys.Down)
                    {
                        this.SelectedIndex = Math.Min(this.TabCount - 1, this.SelectedIndex + 1);
                        return true;
                    }
                }
                else
                {
                    if (keyData == Keys.Left || keyData == Keys.Up)
                    {
                        for (int i = this.SelectedIndex - 1; i >= 0; i--)
                        {
                            if (this.TabPages[i].TabItemEnabled)
                            {
                                this.SelectedIndex = i;
                                return true;
                            }
                            continue;
                        }
                        return true;
                    }
                    else if (keyData == Keys.Right || keyData == Keys.Down)
                    {
                        for (int i = this.SelectedIndex + 1; i < this.TabCount; i++)
                        {
                            if (this.TabPages[i].TabItemEnabled)
                            {
                                this.SelectedIndex = i;
                                return true;
                            }
                            continue;
                        }
                        return true;
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.UpdateMenuBarRectangle();
            this.UpdateEveryOneTabItemRectangle();
            this.ReplenishTabItemToRectangleForLeft();
            this.ReplenishSelectTabItemToRectangle();
            this.UpdateTabMainDisplayRectangleByTabItemsDisplayRectangle();
            this.Invalidate();
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TabControlPlusExtControlsCollection(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                for (int i = 0; i < this.TabCount; i++)
                {
                    TabPagePlusExt tab_page = this.TabPages[i];
                    if (tab_page != null && tab_page.P_GP != null)
                    {
                        tab_page.P_GP.Dispose();
                    }
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        //菜单背景
        protected virtual void OnMenuBarDrawBackgroundBefore(MenuBarDrawBackgroundBeforeEventArgs e)
        {
            if (this.menuBarDrawBackgroundBefore != null)
            {
                this.menuBarDrawBackgroundBefore(this, e);
            }
        }

        protected virtual void OnMenuBarDrawBackgroundAfter(MenuBarDrawBackgroundAfterEventArgs e)
        {
            if (this.menuBarDrawBackgroundAfter != null)
            {
                this.menuBarDrawBackgroundAfter(this, e);
            }
        }

        //导航栏
        protected virtual void OnNavigationButtonOperating(NavigationButtonOperatingEventArgs e)
        {
            if (this.navigationButtonOperating != null)
            {
                this.navigationButtonOperating(this, e);
            }
        }

        protected virtual void OnNavigationButtonOperated(NavigationButtonOperatedEventArgs e)
        {
            if (this.navigationButtonOperated != null)
            {
                this.navigationButtonOperated(this, e);
            }
        }

        //TabItem
        protected virtual void OnTabItemDeselecting(TabItemOperatingEventArgs e)
        {
            if (this.tabItemDeselecting != null)
            {
                this.tabItemDeselecting(this, e);
            }
        }

        protected virtual void OnTabItemDeselected(TabItemOperatedEventArgs e)
        {
            if (this.tabItemDeselected != null)
            {
                this.tabItemDeselected(this, e);
            }
        }

        protected virtual void OnTabItemSelecting(TabItemOperatingEventArgs e)
        {
            if (this.tabItemSelecting != null)
            {
                this.tabItemSelecting(this, e);
            }
        }

        protected virtual void OnTabItemSelected(TabItemOperatedEventArgs e)
        {
            if (this.tabItemSelected != null)
            {
                this.tabItemSelected(this, e);
            }
        }

        protected virtual void OnSelectedIndexChanged(TabItemOperatedEventArgs e)
        {
            if (this.selectedIndexChanged != null)
            {
                this.selectedIndexChanged(this, e);
            }
        }

        internal protected virtual void OnTabItemEnabledChanged(TabItemOperatedEventArgs e)
        {
            if (this.tabItemEnabledChanged != null)
            {
                this.tabItemEnabledChanged(this, e);
            }
        }

        protected virtual void OnTabItemInterchangeing(TabItemInterchangeingEventArgs e)
        {
            if (this.tabItemInterchangeing != null)
            {
                this.tabItemInterchangeing(this, e);
            }
        }

        protected virtual void OnTabItemInterchanged(TabItemInterchangedEventArgs e)
        {
            if (this.tabItemInterchanged != null)
            {
                this.tabItemInterchanged(this, e);
            }
        }

        protected virtual void OnTabItemDrawBackgroundAfter(TabItemDrawBackgroundAfterEventArgs e)
        {
            if (this.tabItemDrawBackgroundAfter != null)
            {
                this.tabItemDrawBackgroundAfter(this, e);
            }
        }

        protected virtual void OnTabItemCreateCustomPathBefore(TabItemCreateCustomPathBeforeEventArgs e)
        {
            if (this.tabItemCreateCustomPathBefore != null)
            {
                this.tabItemCreateCustomPathBefore(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化Rectangle
        /// </summary>
        internal void InitializeRectangle()
        {
            this.UpdateEveryOneTabItemSize();
            this.UpdateMenuBarRectangle();
            this.UpdateEveryOneTabItemRectangle();

            this.ReplenishTabItemToRectangleForLeft();
            this.ReplenishSelectTabItemToRectangle();

            this.UpdateTabMainDisplayRectangleByTabItemsDisplayRectangle();
        }

        /// <summary>
        /// 更新每一个tabitem选项size
        /// </summary>
        private void UpdateEveryOneTabItemSize()
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.Handle, out g, out hDC);

            //选项
            bool menubar_item_auto_width = false;
            int scale_menubar_item_auto_width_min = 0;
            Size scale_menubar_item_size = Size.Ceiling(new SizeF(this.TabItemSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_left_padding = 0;
            int scale_menubar_item_right_padding = 0;
            int scale_menubar_item_p_width = 0;
            //选项图标
            bool scale_menubar_item_ico_visible = false;
            Size scale_menubar_item_ico_size = Size.Ceiling(new SizeF(this.TabItemIcoSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemIcoSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_ico_left_margin = 0;
            int scale_menubar_item_ico_right_margin = 0;
            int scale_menubar_item_ico_m_width = 0;
            //选关闭按钮
            bool menubar_item_closebutton_visible = false;
            Size scale_menubar_item_closebutton_size = Size.Ceiling(new SizeF(this.TabItemCloseButtonSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemCloseButtonSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_closebutton_left_margin = 0;
            int scale_menubar_item_closebutton_right_margin = 0;
            int scale_menubar_item_closebutton_m_width = 0;
            //选项自定义按钮
            int scale_menubar_item_custombuttons_width_sum = 0;//自定义按钮总宽度 

            //计算选项rect
            for (int i = 0; i < this.TabCount; i++)
            {
                TabPagePlusExt tabPage = this.TabPages[i];

                menubar_item_auto_width = this.GetProperty_ItemAutoWidth(tabPage);
                scale_menubar_item_auto_width_min = (int)Math.Ceiling(this.GetProperty_ItemAutoWidthMin(tabPage) * DotsPerInchHelper.DPIScale.XScale);
                scale_menubar_item_left_padding = (int)Math.Ceiling(this.GetProperty_ItemLeftPadding(tabPage) * DotsPerInchHelper.DPIScale.XScale);
                scale_menubar_item_right_padding = (int)Math.Ceiling(this.GetProperty_ItemRightPadding(tabPage) * DotsPerInchHelper.DPIScale.XScale);

                scale_menubar_item_ico_visible = this.GetProperty_ItemIcoVisible(tabPage);
                scale_menubar_item_ico_left_margin = (int)Math.Ceiling(this.TabItemIcoMargin.Left * DotsPerInchHelper.DPIScale.XScale);
                scale_menubar_item_ico_right_margin = (int)Math.Ceiling(this.TabItemIcoMargin.Right * DotsPerInchHelper.DPIScale.XScale);

                menubar_item_closebutton_visible = this.GetProperty_ItemColseVisible(tabPage);
                scale_menubar_item_closebutton_left_margin = (int)Math.Ceiling(this.TabItemCloseButtonMargin.Left * DotsPerInchHelper.DPIScale.XScale);
                scale_menubar_item_closebutton_right_margin = (int)Math.Ceiling(this.TabItemCloseButtonMargin.Right * DotsPerInchHelper.DPIScale.XScale);

                scale_menubar_item_custombuttons_width_sum = 0;//自定义按钮总宽度
                foreach (TabPagePlusExt.TabItemCustomButtonClass btn in tabPage.TabItemCustomButtons)
                {
                    if (btn.Visible)
                    {
                        Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);
                        scale_menubar_item_custombuttons_width_sum += scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                    }
                }

                scale_menubar_item_ico_m_width = 0;
                if (scale_menubar_item_ico_visible)
                {
                    scale_menubar_item_ico_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                }

                scale_menubar_item_closebutton_m_width = 0;
                if (menubar_item_closebutton_visible)
                {
                    scale_menubar_item_closebutton_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                }

                tabPage.Text_DropDown_Size = Size.Ceiling(g.MeasureString(tabPage.Text, this.DropDownPanel.ItemFont, int.MaxValue));

                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    if (menubar_item_auto_width)//选项自动宽度模式
                    {
                        int menubar_item_text_width = Size.Ceiling(g.MeasureString(tabPage.Text, this.TabItemFont, int.MaxValue)).Width;
                        scale_menubar_item_p_width = Math.Max(scale_menubar_item_auto_width_min, scale_menubar_item_left_padding + scale_menubar_item_ico_m_width + menubar_item_text_width + scale_menubar_item_custombuttons_width_sum + scale_menubar_item_closebutton_m_width + scale_menubar_item_right_padding);

                        tabPage.Text_C_Size = new SizeF(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_ico_m_width - scale_menubar_item_custombuttons_width_sum - scale_menubar_item_closebutton_m_width - scale_menubar_item_right_padding, this.TabItemFont.Height);
                        tabPage.Rect_C_Size = new Size(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, scale_menubar_item_size.Height);
                    }
                    else//选项指定宽度模式
                    {
                        scale_menubar_item_p_width = tabPage.TabItemFixedWidth == -1 ? scale_menubar_item_size.Width : (int)Math.Ceiling(tabPage.TabItemFixedWidth * DotsPerInchHelper.DPIScale.XScale);
                        int menubar_item_text_width = Math.Max(0, (scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_ico_m_width - scale_menubar_item_custombuttons_width_sum - scale_menubar_item_closebutton_m_width - scale_menubar_item_right_padding));

                        tabPage.Text_C_Size = new SizeF(menubar_item_text_width, this.TabItemFont.Height);
                        tabPage.Rect_C_Size = new Size(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, scale_menubar_item_size.Height);
                    }

                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabItemVerticalLayout) //Tab选项是否纵向布局(限于左右两边)(依然存储横向的数据)
                    {
                        if (menubar_item_auto_width)//自动宽度模式
                        {
                            int menubar_item_text_width = 0;
                            if (tabPage.TabItemTextVerticalLayout)
                            {
                                menubar_item_text_width = tabPage.Text.Length * this.TabItemFont.Height;
                            }
                            else
                            {
                                menubar_item_text_width = Size.Ceiling(g.MeasureString(tabPage.Text, this.TabItemFont, int.MaxValue)).Width;
                            }
                            scale_menubar_item_p_width = Math.Max(scale_menubar_item_auto_width_min, scale_menubar_item_left_padding + scale_menubar_item_ico_m_width + menubar_item_text_width + scale_menubar_item_custombuttons_width_sum + scale_menubar_item_closebutton_m_width + scale_menubar_item_right_padding);

                            tabPage.Text_C_Size = new SizeF(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_ico_m_width - scale_menubar_item_custombuttons_width_sum - scale_menubar_item_closebutton_m_width - scale_menubar_item_right_padding, this.TabItemFont.Height);
                            tabPage.Rect_C_Size = new Size(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, scale_menubar_item_size.Height);

                        }
                        else//指定宽度模式
                        {
                            scale_menubar_item_p_width = tabPage.TabItemFixedWidth == -1 ? scale_menubar_item_size.Width : (int)Math.Ceiling(tabPage.TabItemFixedWidth * DotsPerInchHelper.DPIScale.XScale);
                            int menubar_item_text_width = Math.Max(0, (scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_ico_m_width - scale_menubar_item_custombuttons_width_sum - scale_menubar_item_closebutton_m_width - scale_menubar_item_right_padding));

                            tabPage.Text_C_Size = new SizeF(menubar_item_text_width, this.TabItemFont.Height);
                            tabPage.Rect_C_Size = new Size(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, scale_menubar_item_size.Height);
                        }
                    }
                    else
                    {
                        scale_menubar_item_p_width = scale_menubar_item_size.Width;
                        int menubar_item_text_width = Math.Max(0, (scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_ico_m_width - scale_menubar_item_custombuttons_width_sum - scale_menubar_item_closebutton_m_width - scale_menubar_item_right_padding));
                        tabPage.Text_C_Size = new SizeF(menubar_item_text_width, this.TabItemFont.Height);
                        tabPage.Rect_C_Size = new Size(scale_menubar_item_p_width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, scale_menubar_item_size.Height);
                    }
                }

            }

            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);

        }

        /// <summary>
        /// 更新菜单区域M_Rectangle(包含外边距)、C_Rectangle(排除外边距、边框、内边距)
        /// </summary>
        /// <returns></returns>
        private void UpdateMenuBarRectangle()
        {
            Size scale_menubar_item_size = Size.Ceiling(new SizeF(this.TabItemSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_padding_top = (int)Math.Ceiling(this.MenuBarPadding.Top * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_padding_bottom = (int)Math.Ceiling(this.MenuBarPadding.Bottom * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_padding_left = (int)Math.Ceiling(this.MenuBarPadding.Left * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_padding_right = (int)Math.Ceiling(this.MenuBarPadding.Right * DotsPerInchHelper.DPIScale.XScale);

            // 更新菜单区域Rectangle信息
            if (this.MenuBarAlignment == MenuBarAlignments.Top)
            {
                this.menubar_p_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, scale_menubar_padding_top + scale_menubar_item_size.Height + scale_menubar_padding_bottom);
                this.menubar_c_rect = new Rectangle(scale_menubar_padding_left, scale_menubar_padding_top, this.ClientRectangle.Width - scale_menubar_padding_left - scale_menubar_padding_right, scale_menubar_item_size.Height);
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                this.menubar_p_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Bottom - scale_menubar_padding_bottom - scale_menubar_item_size.Height - scale_menubar_padding_top, this.ClientRectangle.Width, scale_menubar_padding_top + scale_menubar_item_size.Height + scale_menubar_padding_bottom);
                this.menubar_c_rect = new Rectangle(scale_menubar_padding_left, this.ClientRectangle.Bottom - scale_menubar_padding_top - scale_menubar_item_size.Height, this.ClientRectangle.Width - scale_menubar_padding_left - scale_menubar_padding_right, scale_menubar_item_size.Height);
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left)
            {
                if (this.TabItemVerticalLayout)
                {
                    this.menubar_p_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, scale_menubar_padding_top + scale_menubar_item_size.Height + scale_menubar_padding_bottom, this.ClientRectangle.Height);
                    this.menubar_c_rect = new Rectangle(scale_menubar_padding_top, scale_menubar_padding_left, scale_menubar_item_size.Height, this.ClientRectangle.Height - scale_menubar_padding_left - scale_menubar_padding_right);
                }
                else
                {
                    this.menubar_p_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, scale_menubar_padding_top + scale_menubar_item_size.Width + scale_menubar_padding_bottom, this.ClientRectangle.Height);
                    this.menubar_c_rect = new Rectangle(scale_menubar_padding_top, scale_menubar_padding_left, scale_menubar_item_size.Width, this.ClientRectangle.Height - scale_menubar_padding_left - scale_menubar_padding_right);
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)
                {
                    this.menubar_p_rect = new Rectangle(this.ClientRectangle.Right - scale_menubar_padding_top - scale_menubar_item_size.Height - scale_menubar_padding_bottom, this.ClientRectangle.Y, scale_menubar_padding_top + scale_menubar_item_size.Height + scale_menubar_padding_bottom, this.ClientRectangle.Height);
                    this.menubar_c_rect = new Rectangle(this.ClientRectangle.Right - scale_menubar_padding_top - scale_menubar_item_size.Height, scale_menubar_padding_left, scale_menubar_item_size.Height, this.ClientRectangle.Height - scale_menubar_padding_left - scale_menubar_padding_right);
                }
                else
                {
                    this.menubar_p_rect = new Rectangle(this.ClientRectangle.Right - scale_menubar_padding_top - scale_menubar_item_size.Width - scale_menubar_padding_bottom, this.ClientRectangle.Y, scale_menubar_padding_top + scale_menubar_item_size.Width + scale_menubar_padding_bottom, this.ClientRectangle.Height);
                    this.menubar_c_rect = new Rectangle(this.ClientRectangle.Right - scale_menubar_padding_top - scale_menubar_item_size.Width, scale_menubar_padding_left, scale_menubar_item_size.Width, this.ClientRectangle.Height - scale_menubar_padding_left - scale_menubar_padding_right);
                }
            }

            //全局自定义按钮
            if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                int scale_menubar_globalcustombuttton_width_sum = 0;
                for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                {
                    GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                    if (btn.Visible)
                    {
                        Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        scale_menubar_globalcustombuttton_width_sum += scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                    }
                }

                this.menubar_globalcustombuttton_c_rect = new Rectangle(this.menubar_c_rect.Right - scale_menubar_globalcustombuttton_width_sum, this.menubar_c_rect.Y, scale_menubar_globalcustombuttton_width_sum, this.menubar_c_rect.Height);

                float globalcustombuttton_x = this.menubar_globalcustombuttton_c_rect.X;
                for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                {
                    GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                    if (btn.Visible)
                    {
                        Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        btn.M_Rect = new RectangleF(globalcustombuttton_x, this.menubar_globalcustombuttton_c_rect.Y + (this.menubar_globalcustombuttton_c_rect.Height - scale_btn_size.Height) / 2f, scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right, scale_btn_size.Height);
                        btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                        globalcustombuttton_x = btn.M_Rect.Right;
                    }
                    else
                    {
                        btn.M_Rect = RectangleF.Empty;
                        btn.C_Rect = RectangleF.Empty;
                    }
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)
                {
                    int scale_menubar_globalcustombuttton_width_sum = 0;
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);
                            scale_menubar_globalcustombuttton_width_sum += scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                        }
                    }

                    this.menubar_globalcustombuttton_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Bottom - scale_menubar_globalcustombuttton_width_sum, scale_menubar_item_size.Height, scale_menubar_globalcustombuttton_width_sum);

                    float globalcustombuttton_y = this.menubar_globalcustombuttton_c_rect.Y;
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                            btn.M_Rect = new RectangleF(this.menubar_globalcustombuttton_c_rect.X + (this.menubar_globalcustombuttton_c_rect.Width - scale_btn_size.Height) / 2f, globalcustombuttton_y, scale_btn_size.Height, scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right);
                            btn.C_Rect = new RectangleF(btn.M_Rect.X, btn.M_Rect.Y + scale_btn_margin_right, scale_btn_size.Height, scale_btn_size.Width);
                            globalcustombuttton_y = btn.M_Rect.Bottom;
                        }
                        else
                        {
                            btn.M_Rect = RectangleF.Empty;
                            btn.C_Rect = RectangleF.Empty;
                        }
                    }
                }
                else
                {
                    int scale_menubar_globalcustombuttton_width_sum = 0;
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                            scale_menubar_globalcustombuttton_width_sum += scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                        }
                    }

                    this.menubar_globalcustombuttton_c_rect = new Rectangle(this.menubar_c_rect.Right - scale_menubar_globalcustombuttton_width_sum, this.menubar_c_rect.Bottom - scale_menubar_item_size.Height, scale_menubar_globalcustombuttton_width_sum, scale_menubar_item_size.Height);

                    float globalcustombuttton_x = this.menubar_globalcustombuttton_c_rect.X;
                    for (int i = this.GlobalCustomButttons.Count - 1; i > -1; i--)
                    {
                        GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                        if (btn.Visible)
                        {
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                            btn.M_Rect = new RectangleF(globalcustombuttton_x, this.menubar_globalcustombuttton_c_rect.Y + (this.menubar_globalcustombuttton_c_rect.Height - scale_btn_size.Height) / 2f, scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right, scale_btn_size.Height);
                            btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                            globalcustombuttton_x = btn.M_Rect.Right;
                        }
                        else
                        {
                            btn.M_Rect = RectangleF.Empty;
                            btn.C_Rect = RectangleF.Empty;
                        }
                    }
                }
            }


            // 导航栏Rectangle信息
            if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                if (this.NavigationVisible)
                {
                    Size scale_navigation_prev_button_size = Size.Ceiling(new SizeF(this.NavigationPrevButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationPrevButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                    int scale_navigation_prev_button_left = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                    int scale_navigation_prev_button_right = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                    Size scale_navigation_next_button_size = Size.Ceiling(new SizeF(this.NavigationNextButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationNextButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                    int scale_navigation_next_button_left = (int)Math.Ceiling(this.NavigationNextButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                    int scale_navigation_next_button_right = (int)Math.Ceiling(this.NavigationNextButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                    int scale_menubar_navigation_btn_width_sum = 0;
                    scale_menubar_navigation_btn_width_sum += scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right;
                    scale_menubar_navigation_btn_width_sum += scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right;

                    this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.Right - this.menubar_globalcustombuttton_c_rect.Width - scale_menubar_navigation_btn_width_sum, this.menubar_c_rect.Y, scale_menubar_navigation_btn_width_sum, this.menubar_c_rect.Height);

                    this.NavigationPrevButton.M_Rect = new Rectangle(this.menubar_navigation_c_rect.X, this.menubar_navigation_c_rect.Y + (this.menubar_navigation_c_rect.Height - scale_navigation_prev_button_size.Height) / 2, scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right, scale_navigation_prev_button_size.Height);
                    this.NavigationPrevButton.C_Rect = new Rectangle(this.NavigationPrevButton.M_Rect.X + scale_navigation_prev_button_left, this.NavigationPrevButton.M_Rect.Y, scale_navigation_prev_button_size.Width, scale_navigation_prev_button_size.Height);

                    this.NavigationNextButton.M_Rect = new Rectangle(this.NavigationPrevButton.M_Rect.Right, this.menubar_navigation_c_rect.Y + (this.menubar_navigation_c_rect.Height - scale_navigation_next_button_size.Height) / 2, scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right, scale_navigation_next_button_size.Height);
                    this.NavigationNextButton.C_Rect = new Rectangle(this.NavigationNextButton.M_Rect.X + scale_navigation_next_button_left, this.NavigationNextButton.M_Rect.Y, scale_navigation_next_button_size.Width, scale_navigation_next_button_size.Height);
                }
                else
                {
                    this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.Right - this.menubar_globalcustombuttton_c_rect.Width, this.menubar_c_rect.Y, 0, this.menubar_c_rect.Height);
                    this.NavigationPrevButton.M_Rect = Rectangle.Empty;
                    this.NavigationPrevButton.C_Rect = Rectangle.Empty;
                    this.NavigationNextButton.M_Rect = Rectangle.Empty;
                    this.NavigationNextButton.C_Rect = Rectangle.Empty;
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)//Tab选项是否垂直布局(限于左右两边)
                {
                    if (this.NavigationVisible)
                    {
                        Size scale_navigation_prev_button_size = Size.Ceiling(new SizeF(this.NavigationPrevButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationPrevButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_navigation_prev_button_left = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_navigation_prev_button_right = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        Size scale_navigation_next_button_size = Size.Ceiling(new SizeF(this.NavigationNextButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationNextButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_navigation_next_button_left = (int)Math.Ceiling(this.NavigationNextButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_navigation_next_button_right = (int)Math.Ceiling(this.NavigationNextButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        int scale_menubar_navigation_btn_height_sum = 0;
                        scale_menubar_navigation_btn_height_sum += scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right;
                        scale_menubar_navigation_btn_height_sum += scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right;

                        this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Bottom - this.menubar_globalcustombuttton_c_rect.Height - scale_menubar_navigation_btn_height_sum, scale_menubar_item_size.Height, scale_menubar_navigation_btn_height_sum);

                        this.NavigationPrevButton.M_Rect = new Rectangle(this.menubar_navigation_c_rect.X + (this.menubar_navigation_c_rect.Width - scale_navigation_prev_button_size.Height) / 2, this.menubar_navigation_c_rect.Y, scale_navigation_prev_button_size.Height, scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right);
                        this.NavigationPrevButton.C_Rect = new Rectangle(this.NavigationPrevButton.M_Rect.X, this.NavigationPrevButton.M_Rect.Y + scale_navigation_prev_button_left, scale_navigation_prev_button_size.Height, scale_navigation_prev_button_size.Width);

                        this.NavigationNextButton.M_Rect = new Rectangle(this.menubar_navigation_c_rect.X + (this.menubar_navigation_c_rect.Width - scale_navigation_next_button_size.Height) / 2, this.NavigationPrevButton.M_Rect.Bottom, scale_navigation_next_button_size.Height, scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right);
                        this.NavigationNextButton.C_Rect = new Rectangle(this.NavigationNextButton.M_Rect.X, this.NavigationNextButton.M_Rect.Y + scale_navigation_next_button_left, scale_navigation_next_button_size.Height, scale_navigation_next_button_size.Width);
                    }
                    else
                    {
                        this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Bottom - this.menubar_globalcustombuttton_c_rect.Height, scale_menubar_item_size.Height, 0);
                        this.NavigationPrevButton.M_Rect = Rectangle.Empty;
                        this.NavigationPrevButton.C_Rect = Rectangle.Empty;
                        this.NavigationNextButton.M_Rect = Rectangle.Empty;
                        this.NavigationNextButton.C_Rect = Rectangle.Empty;
                    }
                }
                else
                {
                    if (this.NavigationVisible)
                    {
                        Size scale_navigation_prev_button_size = Size.Ceiling(new SizeF(this.NavigationPrevButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationPrevButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_navigation_prev_button_left = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_navigation_prev_button_right = (int)Math.Ceiling(this.NavigationPrevButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        Size scale_navigation_next_button_size = Size.Ceiling(new SizeF(this.NavigationNextButton.Size.Width * DotsPerInchHelper.DPIScale.XScale, this.NavigationNextButton.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                        int scale_navigation_next_button_left = (int)Math.Ceiling(this.NavigationNextButton.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                        int scale_navigation_next_button_right = (int)Math.Ceiling(this.NavigationNextButton.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                        int scale_menubar_navigation_btn_width_sum = 0;
                        scale_menubar_navigation_btn_width_sum += scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right;
                        scale_menubar_navigation_btn_width_sum += scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right;
                        int scale_navigation_btn_height_sum = scale_menubar_item_size.Height;

                        this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.Right - this.menubar_globalcustombuttton_c_rect.Width - scale_menubar_navigation_btn_width_sum, this.menubar_c_rect.Bottom - scale_navigation_btn_height_sum, scale_menubar_navigation_btn_width_sum, scale_navigation_btn_height_sum);

                        this.NavigationPrevButton.M_Rect = new Rectangle(this.menubar_navigation_c_rect.X, this.menubar_navigation_c_rect.Y + (this.menubar_navigation_c_rect.Height - scale_navigation_prev_button_size.Height) / 2, scale_navigation_prev_button_left + scale_navigation_prev_button_size.Width + scale_navigation_prev_button_right, scale_navigation_prev_button_size.Height);
                        this.NavigationPrevButton.C_Rect = new Rectangle(this.NavigationPrevButton.M_Rect.X + scale_navigation_prev_button_left, this.NavigationPrevButton.M_Rect.Y, scale_navigation_prev_button_size.Width, scale_navigation_prev_button_size.Height);

                        this.NavigationNextButton.M_Rect = new Rectangle(this.NavigationPrevButton.M_Rect.Right, this.menubar_navigation_c_rect.Y + (this.menubar_navigation_c_rect.Height - scale_navigation_next_button_size.Height) / 2, scale_navigation_next_button_left + scale_navigation_next_button_size.Width + scale_navigation_next_button_right, scale_navigation_next_button_size.Height);
                        this.NavigationNextButton.C_Rect = new Rectangle(this.NavigationNextButton.M_Rect.X + scale_navigation_next_button_left, this.NavigationNextButton.M_Rect.Y, scale_navigation_next_button_size.Width, scale_navigation_next_button_size.Height);
                    }
                    else
                    {
                        this.menubar_navigation_c_rect = new Rectangle(this.menubar_c_rect.Right - this.menubar_globalcustombuttton_c_rect.Width, this.menubar_c_rect.Bottom, scale_menubar_item_size.Width, 0);
                        this.NavigationPrevButton.M_Rect = Rectangle.Empty;
                        this.NavigationPrevButton.C_Rect = Rectangle.Empty;
                        this.NavigationNextButton.M_Rect = Rectangle.Empty;
                        this.NavigationNextButton.C_Rect = Rectangle.Empty;
                    }
                }
            }

            // 根据tabitem是否超出显示区边界来更新导航栏当前的显示状态
            if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                float scale_menubar_items_width_sum = 0;
                for (int i = 0; i < this.TabCount; i++)
                {
                    TabPagePlusExt tab_page = this.TabPages[i];
                    int scale_menubar_item_left_margin = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                    int scale_menubar_item_right_margin = (int)Math.Ceiling(this.GetProperty_ItemRightMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                    int scale_menubar_item_left_padding = (int)Math.Ceiling(this.GetProperty_ItemLeftPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                    int scale_menubar_item_right_padding = (int)Math.Ceiling(this.GetProperty_ItemRightPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                    if (i == 0)
                    {
                        scale_menubar_items_width_sum += scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                    }
                    else if (i == this.TabCount - 1)
                    {
                        scale_menubar_items_width_sum += scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding;
                    }
                    else
                    {
                        scale_menubar_items_width_sum += scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                    }
                }

                if (this.TabCount > 0 && scale_menubar_items_width_sum > this.menubar_c_rect.Width - this.menubar_globalcustombuttton_c_rect.Width)
                {
                    this.menubar_navigation_visualstatus = true;
                }
                else
                {
                    this.menubar_navigation_visualstatus = false;
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)
                {
                    float scale_menubar_items_height_sum = 0;
                    for (int i = 0; i < this.TabCount; i++)
                    {
                        TabPagePlusExt tab_page = this.TabPages[i];
                        int scale_menubar_item_left_margin = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_right_margin = (int)Math.Ceiling(this.GetProperty_ItemRightMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_left_padding = (int)Math.Ceiling(this.GetProperty_ItemLeftPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_right_padding = (int)Math.Ceiling(this.GetProperty_ItemRightPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        if (i == 0)
                        {
                            scale_menubar_items_height_sum += scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                        }
                        else if (i == this.TabCount - 1)
                        {
                            scale_menubar_items_height_sum += scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding;
                        }
                        else
                        {
                            scale_menubar_items_height_sum += scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                        }
                    }

                    if (this.TabCount > 0 && scale_menubar_items_height_sum > this.menubar_c_rect.Height - this.menubar_globalcustombuttton_c_rect.Height)
                    {
                        this.menubar_navigation_visualstatus = true;
                    }
                    else
                    {
                        this.menubar_navigation_visualstatus = false;
                    }
                }
                else
                {
                    float scale_menubar_items_height_sum = 0;
                    for (int i = 0; i < this.TabCount; i++)
                    {
                        TabPagePlusExt tab_page = this.TabPages[i];
                        int scale_menubar_item_left_margin = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_right_margin = (int)Math.Ceiling(this.GetProperty_ItemRightMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_left_padding = (int)Math.Ceiling(this.GetProperty_ItemLeftPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        int scale_menubar_item_right_padding = (int)Math.Ceiling(this.GetProperty_ItemRightPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                        if (i == 0)
                        {
                            scale_menubar_items_height_sum += tab_page.Rect_C_Size.Height + scale_menubar_item_right_margin;
                        }
                        else if (i == this.TabCount - 1)
                        {
                            scale_menubar_items_height_sum += scale_menubar_item_left_margin + tab_page.Rect_C_Size.Height;
                        }
                        else
                        {
                            scale_menubar_items_height_sum += scale_menubar_item_left_margin + tab_page.Rect_C_Size.Height + scale_menubar_item_right_margin;
                        }
                    }

                    if (this.TabCount > 0 && scale_menubar_items_height_sum > this.menubar_c_rect.Height - this.menubar_globalcustombuttton_c_rect.Height)
                    {
                        this.menubar_navigation_visualstatus = true;
                    }
                    else
                    {
                        this.menubar_navigation_visualstatus = false;
                    }
                }

            }

            // 更新TabItems的总显示区域Rectangle信息
            if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                if (this.menubar_navigation_visualstatus)
                {
                    this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width - this.menubar_globalcustombuttton_c_rect.Width - this.menubar_navigation_c_rect.Width, this.menubar_c_rect.Height);
                }
                else
                {
                    this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width - this.menubar_globalcustombuttton_c_rect.Width, this.menubar_c_rect.Height);
                }

            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                if (this.TabItemVerticalLayout)
                {
                    if (this.menubar_navigation_visualstatus)
                    {
                        this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width, this.menubar_c_rect.Height - this.menubar_globalcustombuttton_c_rect.Height - this.menubar_navigation_c_rect.Height);
                    }
                    else
                    {
                        this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width, this.menubar_c_rect.Height - this.menubar_globalcustombuttton_c_rect.Height);
                    }
                }
                else
                {
                    if (this.menubar_navigation_visualstatus || this.GetGlobalCustomButttonVisualstatus())
                    {
                        this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width, this.menubar_c_rect.Height - this.menubar_navigation_c_rect.Height);
                    }
                    else
                    {
                        this.menubar_items_c_rect = new Rectangle(this.menubar_c_rect.X, this.menubar_c_rect.Y, this.menubar_c_rect.Width, this.menubar_c_rect.Height);
                    }
                }
            }

        }

        /// <summary>
        /// 根据ItemStartIndex更新每个TabItem的Rectangle信息
        /// </summary>
        private void UpdateEveryOneTabItemRectangle()
        {
            Size scale_menubar_item_size = Size.Ceiling(new SizeF(this.TabItemSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_rounded_lefttop = (int)Math.Ceiling(this.TabItemRoundedCorner.LeftTop * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_rounded_righttop = (int)Math.Ceiling(this.TabItemRoundedCorner.RightTop * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_rounded_leftbottom = (int)Math.Ceiling(this.TabItemRoundedCorner.LeftBottom * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_rounded_rightbottom = (int)Math.Ceiling(this.TabItemRoundedCorner.RightBottom * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_rounded_contentoffset = (int)Math.Ceiling(this.TabItemContentOffset * DotsPerInchHelper.DPIScale.XScale);

            Size scale_menubar_item_ico_size = Size.Ceiling(new SizeF(this.TabItemIcoSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemIcoSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_ico_left_margin = (int)Math.Ceiling(this.TabItemIcoMargin.Left * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_ico_right_margin = (int)Math.Ceiling(this.TabItemIcoMargin.Right * DotsPerInchHelper.DPIScale.XScale);

            TabItemColseButtonAlignments menubar_item_closebutton_alignments = this.TabItemCloseButtonAlignment;
            Size scale_menubar_item_closebutton_size = Size.Ceiling(new SizeF(this.TabItemCloseButtonSize.Width * DotsPerInchHelper.DPIScale.XScale, this.TabItemCloseButtonSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_menubar_item_closebutton_left_margin = (int)Math.Ceiling(this.TabItemCloseButtonMargin.Left * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_item_closebutton_right_margin = (int)Math.Ceiling(this.TabItemCloseButtonMargin.Right * DotsPerInchHelper.DPIScale.XScale);

            //计算正向选项rect
            for (int i = this.menubar_items_start_index; i < this.TabCount; i++)
            {
                TabPagePlusExt tab_page = this.TabPages[i];

                int scale_menubar_item_left_margin = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                int scale_menubar_item_right_margin = (int)Math.Ceiling(this.GetProperty_ItemRightMargin(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                int scale_menubar_item_left_padding = (int)Math.Ceiling(this.GetProperty_ItemLeftPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);
                int scale_menubar_item_right_padding = (int)Math.Ceiling(this.GetProperty_ItemRightPadding(tab_page) * DotsPerInchHelper.DPIScale.XScale);

                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    float menubar_previtem_x = (i == menubar_items_start_index) ? this.menubar_c_rect.X - scale_menubar_item_left_margin : this.TabPages[i - 1].M_Rect.Right;

                    tab_page.M_Rect = new RectangleF(menubar_previtem_x, this.menubar_c_rect.Y, scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin, scale_menubar_item_size.Height);
                    tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X + scale_menubar_item_left_margin, tab_page.M_Rect.Y, tab_page.M_Rect.Width - scale_menubar_item_left_margin - scale_menubar_item_right_margin, tab_page.M_Rect.Height);
                    tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X + scale_menubar_item_left_padding, tab_page.P_Rect.Y, tab_page.P_Rect.Width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, tab_page.P_Rect.Height);
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    float menubar_previtem_y = (i == menubar_items_start_index) ? this.menubar_c_rect.Y : this.TabPages[i - 1].M_Rect.Bottom;
                    if (this.TabItemVerticalLayout) //Tab选项是否纵向布局(限于左右两边)(依然存储横向的数据)
                    {
                        //选项rect
                        tab_page.M_Rect = new RectangleF(this.menubar_c_rect.X, menubar_previtem_y, scale_menubar_item_size.Height, scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin);
                        tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X, tab_page.M_Rect.Y + scale_menubar_item_left_margin, tab_page.M_Rect.Width, tab_page.M_Rect.Height - scale_menubar_item_left_margin - scale_menubar_item_right_margin);
                        tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X, tab_page.P_Rect.Y + scale_menubar_item_left_padding, tab_page.P_Rect.Width, tab_page.P_Rect.Height - scale_menubar_item_left_padding - scale_menubar_item_right_padding);
                    }
                    else
                    {
                        tab_page.M_Rect = new RectangleF(this.menubar_c_rect.X, menubar_previtem_y, scale_menubar_item_size.Width, scale_menubar_item_left_margin + scale_menubar_item_size.Height + scale_menubar_item_right_margin);
                        tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X, tab_page.M_Rect.Y + scale_menubar_item_left_margin, tab_page.M_Rect.Width, tab_page.M_Rect.Height - scale_menubar_item_left_margin - scale_menubar_item_right_margin);
                        tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X + scale_menubar_item_left_padding, tab_page.P_Rect.Y, tab_page.P_Rect.Width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, tab_page.P_Rect.Height);
                    }
                }

                RectangleF item_p_rect_clip = new RectangleF(tab_page.P_Rect.X, tab_page.P_Rect.Y, tab_page.P_Rect.Width, tab_page.P_Rect.Height);
                item_p_rect_clip.Intersect(this.menubar_items_c_rect);
                GraphicsPath menubar_item_old_gp = tab_page.P_GP;
                TabItemCreateCustomPathBeforeEventArgs arg = new TabItemCreateCustomPathBeforeEventArgs(tab_page, DotsPerInchHelper.DPIScale, this.menubar_items_c_rect, item_p_rect_clip, tab_page.M_Rect, tab_page.P_Rect, tab_page.C_Rect, false);
                this.OnTabItemCreateCustomPathBefore(arg);
                if (arg.Finish)
                {
                    tab_page.P_GP = arg.GraphicsPath;
                }
                else
                {
                    tab_page.P_GP = ControlCommom.TransformCircular(tab_page.P_Rect, scale_menubar_item_rounded_lefttop, scale_menubar_item_rounded_righttop, scale_menubar_item_rounded_rightbottom, scale_menubar_item_rounded_leftbottom);
                }

                if (menubar_item_old_gp != null)
                {
                    menubar_item_old_gp.Dispose();
                }

            }

            //计算反向选项rect
            for (int i = this.menubar_items_start_index - 1; i > -1; i--)
            {
                TabPagePlusExt tab_page = this.TabPages[i];

                int scale_menubar_item_left_margin = this.GetProperty_ItemLeftMargin(tab_page);
                int scale_menubar_item_right_margin = this.GetProperty_ItemRightMargin(tab_page);
                int scale_menubar_item_left_padding = this.GetProperty_ItemLeftPadding(tab_page);
                int scale_menubar_item_right_padding = this.GetProperty_ItemRightPadding(tab_page);

                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    float scale_menubar_item_m_width = scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                    tab_page.M_Rect = new RectangleF(this.TabPages[i + 1].M_Rect.X - scale_menubar_item_m_width, this.menubar_c_rect.Y, scale_menubar_item_m_width, scale_menubar_item_size.Height);
                    tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X + scale_menubar_item_left_margin, tab_page.M_Rect.Y, tab_page.M_Rect.Width - scale_menubar_item_left_margin - scale_menubar_item_right_margin, tab_page.M_Rect.Height);
                    tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X + scale_menubar_item_left_padding, tab_page.P_Rect.Y, tab_page.P_Rect.Width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, tab_page.P_Rect.Height);
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabItemVerticalLayout) //Tab选项是否纵向布局(限于左右两边)(依然存储横向的数据)
                    {
                        float scale_menubar_item_m_height = scale_menubar_item_left_margin + scale_menubar_item_left_padding + tab_page.Rect_C_Size.Width + scale_menubar_item_right_padding + scale_menubar_item_right_margin;
                        tab_page.M_Rect = new RectangleF(this.menubar_c_rect.X, this.TabPages[i + 1].M_Rect.Y - scale_menubar_item_m_height, scale_menubar_item_size.Height, scale_menubar_item_m_height);
                        tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X, tab_page.M_Rect.Y + scale_menubar_item_left_margin, tab_page.M_Rect.Width, tab_page.M_Rect.Height - scale_menubar_item_left_margin - scale_menubar_item_right_margin);
                        tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X, tab_page.P_Rect.Y + scale_menubar_item_left_padding, tab_page.P_Rect.Width, tab_page.P_Rect.Height - scale_menubar_item_left_padding - scale_menubar_item_right_padding);
                    }
                    else
                    {
                        float scale_menubar_item_m_height = scale_menubar_item_left_margin + scale_menubar_item_size.Height + scale_menubar_item_right_margin;
                        tab_page.M_Rect = new RectangleF(this.menubar_c_rect.X, this.TabPages[i + 1].M_Rect.Y - scale_menubar_item_m_height, scale_menubar_item_size.Width, scale_menubar_item_m_height);
                        tab_page.P_Rect = new RectangleF(tab_page.M_Rect.X, tab_page.M_Rect.Y + scale_menubar_item_left_margin, tab_page.M_Rect.Width, tab_page.M_Rect.Height - scale_menubar_item_left_margin - scale_menubar_item_right_margin);
                        tab_page.C_Rect = new RectangleF(tab_page.P_Rect.X + scale_menubar_item_left_padding, tab_page.M_Rect.Y, tab_page.P_Rect.Width - scale_menubar_item_left_padding - scale_menubar_item_right_padding, tab_page.P_Rect.Height);
                    }
                }


                RectangleF item_p_rect_clip = new RectangleF(tab_page.P_Rect.X, tab_page.P_Rect.Y, tab_page.P_Rect.Width, tab_page.P_Rect.Height);
                item_p_rect_clip.Intersect(this.menubar_items_c_rect);
                GraphicsPath menubar_item_old_gp = tab_page.P_GP;
                TabItemCreateCustomPathBeforeEventArgs arg = new TabItemCreateCustomPathBeforeEventArgs(tab_page, DotsPerInchHelper.DPIScale, item_p_rect_clip, this.menubar_items_c_rect, tab_page.M_Rect, tab_page.P_Rect, tab_page.C_Rect, false);
                this.OnTabItemCreateCustomPathBefore(arg);
                if (arg.Finish)
                {
                    tab_page.P_GP = arg.GraphicsPath;
                }
                else
                {
                    tab_page.P_GP = ControlCommom.TransformCircular(tab_page.P_Rect, scale_menubar_item_rounded_lefttop, scale_menubar_item_rounded_righttop, scale_menubar_item_rounded_rightbottom, scale_menubar_item_rounded_leftbottom);
                }

                if (menubar_item_old_gp != null)
                {
                    menubar_item_old_gp.Dispose();
                }

            }

            //计算选项内部部件rect
            for (int i = 0; i < this.TabCount; i++)
            {
                TabPagePlusExt tab_page = this.TabPages[i];

                bool menubar_item_ico_visible = this.GetProperty_ItemIcoVisible(tab_page);
                bool menubar_item_closebutton_visible = this.GetProperty_ItemColseVisible(tab_page);

                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Left)
                    {
                        //选项关闭按钮rect
                        if (menubar_item_closebutton_visible)
                        {
                            int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                            tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_closebutton_size.Height);
                            tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X + scale_menubar_item_closebutton_left_margin, tab_page.TabItemCloseButton.M_Rect.Y, scale_menubar_item_closebutton_size.Width, scale_menubar_item_closebutton_size.Height);
                        }
                        else
                        {
                            tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_closebutton_size.Height);
                            tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                        }

                        //选项自定义按钮rect
                        float item_custombuttons_x = tab_page.TabItemCloseButton.M_Rect.Right;
                        for (int k = 0; k < tab_page.TabItemCustomButtons.Count; k++)
                        {
                            TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                            if (btn.Visible)
                            {
                                int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_btn_size.Height);
                                btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                                item_custombuttons_x = btn.M_Rect.Right;
                            }
                            else
                            {
                                btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_btn_size.Height);
                                btn.C_Rect = btn.M_Rect;
                                item_custombuttons_x = btn.M_Rect.Right;
                            }
                        }

                        //选项文本rect
                        tab_page.Text_C_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Size.Width, tab_page.Text_C_Size.Height);

                        //选项图标rect
                        if (menubar_item_ico_visible)
                        {
                            int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                            tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_ico_size.Height);
                            tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X + scale_menubar_item_ico_left_margin, tab_page.Ico_M_Rect.Y, scale_menubar_item_ico_size.Width, scale_menubar_item_ico_size.Height);
                        }
                        else
                        {
                            tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_ico_size.Height);
                            tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                        }

                    }
                    else if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Right)
                    {
                        //选项关闭按钮rect
                        if (menubar_item_closebutton_visible)
                        {
                            int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                            tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.Right - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_closebutton_size.Height);
                            tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X + scale_menubar_item_closebutton_left_margin, tab_page.TabItemCloseButton.M_Rect.Y, scale_menubar_item_closebutton_size.Width, scale_menubar_item_closebutton_size.Height);
                        }
                        else
                        {
                            tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_closebutton_size.Height);
                            tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                        }

                        //选项自定义按钮rect
                        float item_custombuttons_x = tab_page.TabItemCloseButton.M_Rect.X;
                        for (int k = tab_page.TabItemCustomButtons.Count - 1; k > -1; k--)
                        {
                            TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                            Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                            int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                            int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                            if (btn.Visible)
                            {
                                int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                btn.M_Rect = new RectangleF(item_custombuttons_x - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_btn_size.Height);
                                btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                                item_custombuttons_x = btn.M_Rect.X;
                            }
                            else
                            {
                                btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_btn_size.Height);
                                btn.C_Rect = btn.M_Rect;
                                item_custombuttons_x = btn.M_Rect.X;
                            }
                        }

                        //选项文本rect
                        tab_page.Text_C_Rect = new RectangleF(item_custombuttons_x - tab_page.Text_C_Size.Width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Size.Width, tab_page.Text_C_Size.Height);

                        //选项图标rect
                        if (menubar_item_ico_visible)
                        {
                            int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                            tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.X - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_ico_size.Height);
                            tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X + scale_menubar_item_ico_left_margin, tab_page.Ico_M_Rect.Y, scale_menubar_item_ico_size.Width, scale_menubar_item_ico_size.Height);
                        }
                        else
                        {
                            tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_ico_size.Height);
                            tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                        }

                    }
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabItemVerticalLayout) //Tab选项是否纵向布局(限于左右两边)(依然存储横向的数据)
                    {
                        if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Left)
                        {
                            //选项关闭按钮rect
                            if (menubar_item_closebutton_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.C_Rect.Y, scale_menubar_item_closebutton_size.Height, scale_btn_m_width);
                                tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X, tab_page.TabItemCloseButton.M_Rect.Y + scale_menubar_item_closebutton_left_margin, scale_menubar_item_closebutton_size.Height, scale_menubar_item_closebutton_size.Width);
                            }
                            else
                            {
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.C_Rect.Y, scale_menubar_item_closebutton_size.Height, 0);
                                tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                            }

                            //选项自定义按钮rect
                            float item_custombuttons_y = tab_page.TabItemCloseButton.M_Rect.Bottom;
                            for (int k = 0; k < tab_page.TabItemCustomButtons.Count; k++)
                            {
                                TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                                Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                                int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                                int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                                if (btn.Visible)
                                {
                                    int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                    btn.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y, scale_btn_size.Height, scale_btn_m_width);
                                    btn.C_Rect = new RectangleF(btn.M_Rect.X, btn.M_Rect.Y + scale_btn_margin_left, scale_btn_size.Height, scale_btn_size.Width);
                                    item_custombuttons_y = btn.M_Rect.Bottom;
                                }
                                else
                                {
                                    btn.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y, scale_btn_size.Height, 0);
                                    btn.C_Rect = btn.M_Rect;
                                    item_custombuttons_y = btn.M_Rect.Bottom;
                                }
                            }

                            tab_page.Text_C_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y, tab_page.Text_C_Size.Height, tab_page.Text_C_Size.Width);

                            //选项图标rect
                            if (menubar_item_ico_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Rect.Bottom, scale_menubar_item_ico_size.Height, scale_btn_m_width);
                                tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X, tab_page.Ico_M_Rect.Y + scale_menubar_item_ico_left_margin, scale_menubar_item_ico_size.Height, scale_menubar_item_ico_size.Width);
                            }
                            else
                            {
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Rect.Bottom, scale_menubar_item_ico_size.Height, 0);
                                tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                            }

                        }
                        else if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Right)
                        {
                            //选项关闭按钮rect
                            if (menubar_item_closebutton_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.C_Rect.Bottom - scale_btn_m_width, scale_menubar_item_closebutton_size.Height, scale_btn_m_width);
                                tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X, tab_page.TabItemCloseButton.M_Rect.Y + scale_menubar_item_closebutton_left_margin, scale_menubar_item_closebutton_size.Height, scale_menubar_item_closebutton_size.Width);
                            }
                            else
                            {
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.C_Rect.Bottom, scale_menubar_item_closebutton_size.Height, 0);
                                tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                            }

                            //选项自定义按钮rect
                            float item_custombuttons_y = tab_page.TabItemCloseButton.M_Rect.Y;
                            for (int k = tab_page.TabItemCustomButtons.Count - 1; k > -1; k--)
                            {
                                TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                                Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                                int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                                int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                                if (btn.Visible)
                                {
                                    int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                    btn.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y - scale_btn_m_width, scale_btn_size.Height, scale_btn_m_width);
                                    btn.C_Rect = new RectangleF(btn.M_Rect.X, btn.M_Rect.Y + scale_btn_margin_left, scale_btn_size.Height, scale_btn_size.Width);
                                    item_custombuttons_y = btn.M_Rect.Y;
                                }
                                else
                                {
                                    btn.M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y, scale_btn_size.Height, 0);
                                    btn.C_Rect = btn.M_Rect;
                                    item_custombuttons_y = btn.M_Rect.Y;
                                }
                            }

                            //选项文本rect
                            tab_page.Text_C_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, item_custombuttons_y - tab_page.Text_C_Size.Width, tab_page.Text_C_Size.Height, tab_page.Text_C_Size.Width);

                            //选项图标rect
                            if (menubar_item_ico_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Rect.Y - scale_btn_m_width, scale_menubar_item_ico_size.Height, scale_btn_m_width);
                                tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X, tab_page.Ico_M_Rect.Y + scale_menubar_item_ico_left_margin, scale_menubar_item_ico_size.Height, scale_menubar_item_ico_size.Width);
                            }
                            else
                            {
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.C_Rect.X + (tab_page.C_Rect.Width - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Rect.Y, scale_menubar_item_ico_size.Height, 0);
                                tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                            }

                        }
                    }
                    else
                    {
                        if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Left)
                        {
                            //选项关闭按钮rect
                            if (menubar_item_closebutton_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_closebutton_size.Height);
                                tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X + scale_menubar_item_closebutton_left_margin, tab_page.TabItemCloseButton.M_Rect.Y, scale_menubar_item_closebutton_size.Width, scale_menubar_item_closebutton_size.Height);
                            }
                            else
                            {
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_closebutton_size.Height);
                                tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                            }

                            //选项自定义按钮rect
                            float item_custombuttons_x = tab_page.TabItemCloseButton.M_Rect.Right;
                            for (int k = 0; k < tab_page.TabItemCustomButtons.Count; k++)
                            {
                                TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                                Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                                int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                                int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                                if (btn.Visible)
                                {
                                    int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                    btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_btn_size.Height);
                                    btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                                    item_custombuttons_x = btn.M_Rect.Right;
                                }
                                else
                                {
                                    btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_btn_size.Height);
                                    btn.C_Rect = btn.M_Rect;
                                    item_custombuttons_x = btn.M_Rect.Right;
                                }
                            }

                            //选项文本rect
                            tab_page.Text_C_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Size.Width, tab_page.Text_C_Size.Height);

                            //选项图标rect
                            if (menubar_item_ico_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_ico_size.Height);
                                tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X + scale_menubar_item_ico_left_margin, tab_page.Ico_M_Rect.Y, scale_menubar_item_ico_size.Width, scale_menubar_item_ico_size.Height);
                            }
                            else
                            {
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_ico_size.Height);
                                tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                            }

                        }
                        else if (menubar_item_closebutton_alignments == TabItemColseButtonAlignments.Right)
                        {
                            //选项关闭按钮rect
                            if (menubar_item_closebutton_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_closebutton_left_margin + scale_menubar_item_closebutton_size.Width + scale_menubar_item_closebutton_right_margin;
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.Right - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_closebutton_size.Height);
                                tab_page.TabItemCloseButton.C_Rect = new RectangleF(tab_page.TabItemCloseButton.M_Rect.X + scale_menubar_item_closebutton_left_margin, tab_page.TabItemCloseButton.M_Rect.Y, scale_menubar_item_closebutton_size.Width, scale_menubar_item_closebutton_size.Height);
                            }
                            else
                            {
                                tab_page.TabItemCloseButton.M_Rect = new RectangleF(tab_page.C_Rect.Right, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_closebutton_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_closebutton_size.Height);
                                tab_page.TabItemCloseButton.C_Rect = tab_page.TabItemCloseButton.M_Rect;
                            }

                            //选项自定义按钮rect
                            float item_custombuttons_x = tab_page.TabItemCloseButton.M_Rect.X;
                            for (int k = tab_page.TabItemCustomButtons.Count - 1; k > -1; k--)
                            {
                                TabPagePlusExt.TabItemCustomButtonClass btn = tab_page.TabItemCustomButtons[k];
                                Size scale_btn_size = Size.Ceiling(new SizeF(btn.Size.Width * DotsPerInchHelper.DPIScale.XScale, btn.Size.Height * DotsPerInchHelper.DPIScale.XScale));
                                int scale_btn_margin_left = (int)Math.Ceiling(btn.Margin.Left * DotsPerInchHelper.DPIScale.XScale);
                                int scale_btn_margin_right = (int)Math.Ceiling(btn.Margin.Right * DotsPerInchHelper.DPIScale.XScale);

                                if (btn.Visible)
                                {
                                    int scale_btn_m_width = scale_btn_margin_left + scale_btn_size.Width + scale_btn_margin_right;
                                    btn.M_Rect = new RectangleF(item_custombuttons_x - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_btn_size.Height);
                                    btn.C_Rect = new RectangleF(btn.M_Rect.X + scale_btn_margin_left, btn.M_Rect.Y, scale_btn_size.Width, scale_btn_size.Height);
                                    item_custombuttons_x = btn.M_Rect.X;
                                }
                                else
                                {
                                    btn.M_Rect = new RectangleF(item_custombuttons_x, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_btn_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_btn_size.Height);
                                    btn.C_Rect = btn.M_Rect;
                                    item_custombuttons_x = btn.M_Rect.X;
                                }
                            }

                            //选项文本rect
                            tab_page.Text_C_Rect = new RectangleF(item_custombuttons_x - tab_page.Text_C_Size.Width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - tab_page.Text_C_Size.Height) / 2 + scale_menubar_item_rounded_contentoffset, tab_page.Text_C_Size.Width, tab_page.Text_C_Size.Height);

                            //选项图标rect
                            if (menubar_item_ico_visible)
                            {
                                int scale_btn_m_width = scale_menubar_item_ico_left_margin + scale_menubar_item_ico_size.Width + scale_menubar_item_ico_right_margin;
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.X - scale_btn_m_width, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, scale_btn_m_width, scale_menubar_item_ico_size.Height);
                                tab_page.Ico_C_Rect = new RectangleF(tab_page.Ico_M_Rect.X + scale_menubar_item_ico_left_margin, tab_page.Ico_M_Rect.Y, scale_menubar_item_ico_size.Width, scale_menubar_item_ico_size.Height);
                            }
                            else
                            {
                                tab_page.Ico_M_Rect = new RectangleF(tab_page.Text_C_Rect.X, tab_page.C_Rect.Y + (tab_page.C_Rect.Height - scale_menubar_item_ico_size.Height) / 2 + scale_menubar_item_rounded_contentoffset, 0, scale_menubar_item_ico_size.Height);
                                tab_page.Ico_C_Rect = tab_page.Ico_M_Rect;
                            }

                        }
                    }
                }
            }

        }

        /// <summary>
        /// 自动把左边需要显示tabitem显示在tabitem总显示区域中
        /// </summary>
        private void ReplenishTabItemToRectangleForLeft()
        {
            if (this.menubar_items_start_index > 0)
            {
                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    if (this.TabPages[this.TabCount - 1].P_Rect.Right < this.menubar_items_c_rect.Right)
                    {
                        int index_tmp = Math.Max(0, this.menubar_items_start_index - 1);
                        for (int i = this.menubar_items_start_index - 1; i >= 0; i--)
                        {
                            int scale_item_margin_left = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(this.TabPages[this.menubar_items_start_index]) * DotsPerInchHelper.DPIScale.XScale);
                            if (Math.Abs(this.TabPages[i].P_Rect.X) + scale_item_margin_left + this.TabPages[this.TabCount - 1].P_Rect.Right < this.menubar_items_c_rect.Right)
                            {
                                index_tmp--;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Max(0, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }

                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabPages[this.TabCount - 1].P_Rect.Bottom < this.menubar_items_c_rect.Bottom)
                    {
                        int index_tmp = Math.Max(0, this.menubar_items_start_index - 1);
                        for (int i = this.menubar_items_start_index - 1; i >= 0; i--)
                        {
                            int scale_item_margin_left = (int)Math.Ceiling(this.GetProperty_ItemLeftMargin(this.TabPages[this.menubar_items_start_index]) * DotsPerInchHelper.DPIScale.XScale);
                            if (Math.Abs(this.TabPages[i].P_Rect.Y) + scale_item_margin_left + this.TabPages[this.TabCount - 1].P_Rect.Bottom < this.menubar_items_c_rect.Bottom)
                            {
                                index_tmp--;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Max(0, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }
                }

            }
        }

        /// <summary>
        /// 自动把已选中tabitem显示在tabitem总显示区域中
        /// </summary>
        private void ReplenishSelectTabItemToRectangle()
        {
            if (this.SelectedIndex > -1)
            {
                if (this.MenuBarAlignment == MenuBarAlignments.Top || this.MenuBarAlignment == MenuBarAlignments.Bottom)
                {
                    if (this.TabPages[this.SelectedIndex].P_Rect.X >= this.menubar_items_c_rect.Right)
                    {
                        int index_tmp = Math.Min(this.TabCount - 1, this.menubar_items_start_index + 1);
                        for (int i = this.menubar_items_start_index + 1; i < this.TabCount; i++)
                        {
                            if (this.TabPages[this.SelectedIndex].P_Rect.X - this.TabPages[i].M_Rect.Width >= this.menubar_items_c_rect.Right)
                            {
                                index_tmp++;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Min(this.TabCount - 1, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }
                    else if (this.TabPages[this.SelectedIndex].P_Rect.Y < this.menubar_items_c_rect.Y)
                    {
                        int index_tmp = Math.Max(0, this.menubar_items_start_index - 1);
                        for (int i = this.menubar_items_start_index - 1; i >= 0; i--)
                        {
                            if (this.TabPages[this.SelectedIndex].P_Rect.Y + Math.Abs(this.TabPages[i].M_Rect.Y) < this.menubar_items_c_rect.Y)
                            {
                                index_tmp--;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Max(0, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }
                    if (this.TabPages[this.SelectedIndex].P_Rect.X < this.menubar_items_c_rect.X)
                    {
                        int index_tmp = Math.Max(0, this.menubar_items_start_index - 1);
                        for (int i = this.menubar_items_start_index - 1; i >= 0; i--)
                        {
                            if (this.TabPages[this.SelectedIndex].P_Rect.X + Math.Abs(this.TabPages[i].M_Rect.X) < this.menubar_items_c_rect.X)
                            {
                                index_tmp--;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Max(0, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }
                }
                else if (this.MenuBarAlignment == MenuBarAlignments.Left || this.MenuBarAlignment == MenuBarAlignments.Right)
                {
                    if (this.TabPages[this.SelectedIndex].P_Rect.Y >= this.menubar_items_c_rect.Bottom)
                    {
                        int index_tmp = Math.Min(this.TabCount - 1, this.menubar_items_start_index + 1);
                        for (int i = this.menubar_items_start_index + 1; i < this.TabCount; i++)
                        {
                            if (this.TabPages[this.SelectedIndex].P_Rect.Y - this.TabPages[i].M_Rect.Height >= this.menubar_items_c_rect.Bottom)
                            {
                                index_tmp++;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Min(this.TabCount - 1, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }

                    else if (this.TabPages[this.SelectedIndex].P_Rect.Y < this.menubar_items_c_rect.Y)
                    {
                        int index_tmp = Math.Max(0, this.menubar_items_start_index - 1);
                        for (int i = this.menubar_items_start_index - 1; i >= 0; i--)
                        {
                            if (this.TabPages[this.SelectedIndex].P_Rect.Y + Math.Abs(this.TabPages[i].M_Rect.Y) < this.menubar_items_c_rect.Y)
                            {
                                index_tmp--;
                                continue;
                            }
                            break;
                        }

                        index_tmp = Math.Max(0, index_tmp);
                        this.menubar_items_start_index = index_tmp;
                        this.UpdateEveryOneTabItemRectangle();
                    }
                }
            }
        }

        /// <summary>
        /// 根据tabitems总显示区更新主体Rectangle信息
        /// </summary>
        private void UpdateTabMainDisplayRectangleByTabItemsDisplayRectangle()
        {
            int scale_menubar_margin_top = (int)Math.Ceiling(this.MenuBarPadding.Top * DotsPerInchHelper.DPIScale.XScale);
            int scale_menubar_margin_bottom = (int)Math.Ceiling(this.MenuBarPadding.Bottom * DotsPerInchHelper.DPIScale.XScale);

            if (this.MenuBarAlignment == MenuBarAlignments.Top)
            {
                this.pagemain_c_rect = new Rectangle(
                    this.ClientRectangle.X + this.PageMainBorderThickness,
                    this.ClientRectangle.Y + scale_menubar_margin_top + this.menubar_items_c_rect.Height + scale_menubar_margin_bottom + this.PageMainBorderThickness,
                    this.ClientRectangle.Width - this.PageMainBorderThickness * 2,
                    this.ClientRectangle.Height - scale_menubar_margin_top - this.menubar_items_c_rect.Height - scale_menubar_margin_bottom - this.PageMainBorderThickness * 2
                    );
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                this.pagemain_c_rect = new Rectangle(
                    this.ClientRectangle.X + this.PageMainBorderThickness,
                    this.ClientRectangle.Y + this.PageMainBorderThickness,
                    this.ClientRectangle.Width - this.PageMainBorderThickness * 2,
                    this.ClientRectangle.Height - scale_menubar_margin_top - this.menubar_items_c_rect.Height - scale_menubar_margin_bottom - this.PageMainBorderThickness * 2
                    );

            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left)
            {
                this.pagemain_c_rect = new Rectangle(
                    this.ClientRectangle.X + scale_menubar_margin_top + this.menubar_items_c_rect.Width + scale_menubar_margin_bottom + this.PageMainBorderThickness,
                    this.ClientRectangle.Y + this.PageMainBorderThickness,
                    this.ClientRectangle.Width - scale_menubar_margin_top - this.menubar_items_c_rect.Width - scale_menubar_margin_bottom - this.PageMainBorderThickness * 2,
                    this.ClientRectangle.Height - this.PageMainBorderThickness * 2
                    );
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                this.pagemain_c_rect = new Rectangle(
                    this.ClientRectangle.X + this.PageMainBorderThickness,
                    this.ClientRectangle.Y + this.PageMainBorderThickness,
                    this.ClientRectangle.Width - scale_menubar_margin_top - this.menubar_items_c_rect.Width - scale_menubar_margin_bottom - this.PageMainBorderThickness * 2,
                    this.ClientRectangle.Height - this.PageMainBorderThickness * 2
                    );
            }

            for (int i = 0; i < this.tabPages.Length; i++)
            {
                this.SetTabPageDisplayRectangle(this.tabPages[i]);
            }

        }

        /// <summary>
        /// 设置TabPage的DisplayRectangle
        /// </summary>
        /// <param name="tabPage">要设置的TabPage</param>
        private void SetTabPageDisplayRectangle(TabPagePlusExt tabPage)
        {
            tabPage.SetBounds(this.pagemain_c_rect.X, this.pagemain_c_rect.Y, this.pagemain_c_rect.Width, this.pagemain_c_rect.Height);
        }



        /// <summary>
        /// 获取视觉上全局自定义按钮是否显示
        /// </summary>
        /// <returns></returns>
        private bool GetGlobalCustomButttonVisualstatus()
        {
            for (int i = 0; i < this.GlobalCustomButttons.Count; i++)
            {
                if (this.GlobalCustomButttons[i].Visible)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取全局自定义按钮的图片
        /// </summary>
        /// <param name="btn">全局自定义按钮</param>
        private Image GetGlobalCustomButttonImage(GlobalCustomButttonClass btn)
        {
            Image btn_image = null;

            if (!this.Enabled || !btn.Enabled)
            {
                btn_image = btn.ImageDisable;
            }
            else
            {
                if (btn.MouseStatus == MouseStatuss.Enter)
                {
                    btn_image = btn.ImageEnter;
                }
                else
                {
                    btn_image = btn.ImageNormal;
                }
            }

            if (btn_image == null)
            {
                btn_image = global::WinformControlLibraryExtension.Resources.tabcontrol_item_default_button_ico;
            }

            return btn_image;
        }



        /// <summary>
        /// 获取导航栏上一页按钮的颜色
        /// </summary>
        /// <param name="navigation_prev_back_sb">背景色</param>
        /// <param name="navigation_prev_fore_sb">前景色</param>
        private void GetDrawPrevButtonColorBrush(ref SolidBrush navigation_prev_back_sb, ref SolidBrush navigation_prev_fore_sb)
        {
            if (!this.Enabled)
            {
                navigation_prev_back_sb = new SolidBrush(this.NavigationPrevButton.BackDisableColor);
                navigation_prev_fore_sb = new SolidBrush(this.NavigationPrevButton.ForeDisableColor);
            }
            else
            {
                if (this.NavigationPrevButton.MoveStatus == MouseStatuss.Enter)
                {
                    navigation_prev_back_sb = new SolidBrush(this.NavigationPrevButton.BackEnterColor);
                    navigation_prev_fore_sb = new SolidBrush(this.NavigationPrevButton.ForeEnterColor);
                }
                else
                {
                    navigation_prev_back_sb = new SolidBrush(this.NavigationPrevButton.BackNormalColor);
                    navigation_prev_fore_sb = new SolidBrush(this.NavigationPrevButton.ForeNormalColor);
                }
            }
        }
        /// <summary>
        /// 获取导航栏上一页按钮的图片
        /// </summary>
        private Image GetDrawPrevButtonImage()
        {
            Image prev_image = null;

            if (!this.Enabled)
            {
                prev_image = this.NavigationPrevButton.ImageDisable;
            }
            else
            {
                if (this.NavigationPrevButton.MoveStatus == MouseStatuss.Enter)
                {
                    prev_image = this.NavigationPrevButton.ImageEnter;
                }
                else
                {
                    prev_image = this.NavigationPrevButton.ImageNormal;
                }
            }

            if (prev_image == null)
            {
                prev_image = global::WinformControlLibraryExtension.Resources.tabcontrol_item_default_button_ico;
            }

            return prev_image;
        }

        /// <summary>
        /// 获取导航栏下一页按钮的颜色
        /// </summary>
        /// <param name="navigation_prev_back_sb">背景色</param>
        /// <param name="navigation_prev_text_sb">前景色</param>
        private void GetDrawNextButtonColorBrush(ref SolidBrush navigation_next_back_sb, ref SolidBrush navigation_next_fore_sb)
        {
            if (!this.Enabled)
            {
                navigation_next_back_sb = new SolidBrush(this.NavigationNextButton.BackDisableColor);
                navigation_next_fore_sb = new SolidBrush(this.NavigationNextButton.ForeDisableColor);
            }
            else
            {
                if (this.NavigationNextButton.MoveStatus == MouseStatuss.Enter)
                {
                    navigation_next_back_sb = new SolidBrush(this.NavigationNextButton.BackEnterColor);
                    navigation_next_fore_sb = new SolidBrush(this.NavigationNextButton.ForeEnterColor);
                }
                else
                {
                    navigation_next_back_sb = new SolidBrush(this.NavigationNextButton.BackNormalColor);
                    navigation_next_fore_sb = new SolidBrush(this.NavigationNextButton.ForeNormalColor);
                }
            }
        }
        /// <summary>
        /// 获取导航栏下一页按钮的图片
        /// </summary>
        private Image GetDrawNextButtonImage()
        {
            Image next_image = null;

            if (!this.Enabled)
            {
                next_image = this.NavigationNextButton.ImageDisable;
            }
            else
            {
                if (this.NavigationNextButton.MoveStatus == MouseStatuss.Enter)
                {
                    next_image = this.NavigationNextButton.ImageEnter;
                }
                else
                {
                    next_image = this.NavigationNextButton.ImageNormal;
                }
            }

            if (next_image == null)
            {
                next_image = global::WinformControlLibraryExtension.Resources.tabcontrol_item_default_button_ico;
            }

            return next_image;
        }



        /// <summary>
        /// 获取指定TabPage笔刷
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <param name="tabitem_back_normal_commom_sb"></param>
        /// <param name="tabitem_back_enter_commom_sb"></param>
        /// <param name="tabitem_back_selected_commom_sb"></param>
        /// <param name="tabitem_back_disable_commom_sb"></param>
        /// <param name="tabitem_back_sb"></param>
        /// <param name="tabitem_back_is_commom_sb"></param>
        /// <param name="tabitem_text_normal_commom_sb"></param>
        /// <param name="tabitem_text_enter_commom_sb"></param>
        /// <param name="tabitem_text_selected_commom_sb"></param>
        /// <param name="tabitem_text_disable_commom_sb"></param>
        /// <param name="tabitem_text_sb"></param>
        /// <param name="tabitem_text_is_commom_sb"></param>
        /// <returns></returns>
        private void GetProperty_ItemSolidBrush(TabPagePlusExt tabPage,
            ref SolidBrush tabitem_back_normal_commom_sb,
            ref SolidBrush tabitem_back_enter_commom_sb,
            ref SolidBrush tabitem_back_selected_commom_sb,
            ref SolidBrush tabitem_back_disable_commom_sb,
            ref SolidBrush tabitem_back_sb, ref bool tabitem_back_is_commom_sb,
            ref SolidBrush tabitem_text_normal_commom_sb,
            ref SolidBrush tabitem_text_enter_commom_sb,
            ref SolidBrush tabitem_text_selected_commom_sb,
            ref SolidBrush tabitem_text_disable_commom_sb,
            ref SolidBrush tabitem_text_sb, ref bool tabitem_text_is_commom_sb)
        {
            if (!this.Enabled || !tabPage.TabItemEnabled)
            {
                if (tabPage.TabItemBackDisableColor == Color.Empty)
                {
                    if (tabitem_back_disable_commom_sb == null)
                    {
                        tabitem_back_disable_commom_sb = new SolidBrush(this.TabItemBackDisableColor);
                    }
                    tabitem_back_sb = tabitem_back_disable_commom_sb;
                    tabitem_back_is_commom_sb = true;
                }
                else
                {
                    tabitem_back_sb = new SolidBrush(tabPage.TabItemBackDisableColor);
                    tabitem_back_is_commom_sb = false;
                }

                if (tabPage.TabItemTextDisableColor == Color.Empty)
                {
                    if (tabitem_text_disable_commom_sb == null)
                    {
                        tabitem_text_disable_commom_sb = new SolidBrush(this.TabItemTextDisableColor);
                    }
                    tabitem_text_sb = tabitem_text_disable_commom_sb;
                    tabitem_text_is_commom_sb = true;
                }
                else
                {
                    tabitem_text_sb = new SolidBrush(tabPage.TabItemTextDisableColor);
                    tabitem_text_is_commom_sb = false;
                }
            }
            else
            {
                if (this.JudgeTabPageIsSelect(tabPage))
                {
                    if (tabPage.TabItemBackSelectedColor == Color.Empty)
                    {
                        if (tabitem_back_selected_commom_sb == null)
                        {
                            tabitem_back_selected_commom_sb = new SolidBrush(this.TabItemBackSelectedColor);
                        }
                        tabitem_back_sb = tabitem_back_selected_commom_sb;
                        tabitem_back_is_commom_sb = true;
                    }
                    else
                    {
                        tabitem_back_sb = new SolidBrush(tabPage.TabItemBackSelectedColor);
                        tabitem_back_is_commom_sb = false;
                    }

                    if (tabPage.TabItemTextSelectedColor == Color.Empty)
                    {
                        if (tabitem_text_selected_commom_sb == null)
                        {
                            tabitem_text_selected_commom_sb = new SolidBrush(this.TabItemTextSelectedColor);
                        }
                        tabitem_text_sb = tabitem_text_selected_commom_sb;
                        tabitem_text_is_commom_sb = true;
                    }
                    else
                    {
                        tabitem_text_sb = new SolidBrush(tabPage.TabItemTextSelectedColor);
                        tabitem_text_is_commom_sb = false;
                    }
                }
                else
                {
                    if (tabPage.MouseStatus == MouseStatuss.Enter)
                    {
                        if (tabPage.TabItemBackEnterColor == Color.Empty)
                        {
                            if (tabitem_back_enter_commom_sb == null)
                            {
                                tabitem_back_enter_commom_sb = new SolidBrush(this.TabItemBackEnterColor);
                            }
                            tabitem_back_sb = tabitem_back_enter_commom_sb;
                            tabitem_back_is_commom_sb = true;
                        }
                        else
                        {
                            tabitem_back_sb = new SolidBrush(tabPage.TabItemBackEnterColor);
                            tabitem_back_is_commom_sb = false;
                        }

                        if (tabPage.TabItemTextEnterColor == Color.Empty)
                        {
                            if (tabitem_text_enter_commom_sb == null)
                            {
                                tabitem_text_enter_commom_sb = new SolidBrush(this.TabItemTextEnterColor);
                            }
                            tabitem_text_sb = tabitem_text_enter_commom_sb;
                            tabitem_text_is_commom_sb = true;
                        }
                        else
                        {
                            tabitem_text_sb = new SolidBrush(tabPage.TabItemTextEnterColor);
                            tabitem_text_is_commom_sb = false;
                        }
                    }
                    else
                    {
                        if (tabPage.TabItemBackNormalColor == Color.Empty)
                        {
                            if (tabitem_back_normal_commom_sb == null)
                            {
                                tabitem_back_normal_commom_sb = new SolidBrush(this.TabItemBackNormalColor);
                            }
                            tabitem_back_sb = tabitem_back_normal_commom_sb;
                            tabitem_back_is_commom_sb = true;
                        }
                        else
                        {
                            tabitem_back_sb = new SolidBrush(tabPage.TabItemBackNormalColor);
                            tabitem_back_is_commom_sb = false;
                        }

                        if (tabPage.TabItemTextNormalColor == Color.Empty)
                        {
                            if (tabitem_text_normal_commom_sb == null)
                            {
                                tabitem_text_normal_commom_sb = new SolidBrush(this.TabItemTextNormalColor);
                            }
                            tabitem_text_sb = tabitem_text_normal_commom_sb;
                            tabitem_text_is_commom_sb = true;
                        }
                        else
                        {
                            tabitem_text_sb = new SolidBrush(tabPage.TabItemTextNormalColor);
                            tabitem_text_is_commom_sb = false;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 获取Tab选项关闭按钮画笔
        /// </summary>
        /// <param name="tabPage">Tab选项</param>
        /// <param name="close_back_normal_commom_sb">通用背景色画笔(正常)</param>
        /// <param name="close_back_enter_commom_sb">通用背景色画笔(鼠标进入)</param>
        /// <param name="close_back_disable_commom_sb">通用背景色画笔(禁用)</param>
        /// <param name="close_back_sb">专用背景色画笔<</param>
        /// <param name="close_back_is_commom_sb">返回是否为通用背景色画笔</param>
        /// <param name="close_fore_normal_commom_pen">通用前景色画笔(正常)</param>
        /// <param name="close_fore_enter_commom_pen">通用前景色画笔(鼠标进入)</param>
        /// <param name="close_forek_disable_commom_pen">通用前景色画笔(禁用)</param>
        /// <param name="close_fore_pen">专用前景色画笔</param>
        /// <param name="close_fore_is_commom_pen">返回是否为通用前景色画笔</param>
        private void GetTabItemClosePen(TabPagePlusExt tabPage,
            ref SolidBrush close_back_normal_commom_sb,
            ref SolidBrush close_back_enter_commom_sb,
            ref SolidBrush close_back_disable_commom_sb,
            ref SolidBrush close_back_sb, ref bool close_back_is_commom_sb,
            ref Pen close_fore_normal_commom_pen,
            ref Pen close_fore_enter_commom_pen,
            ref Pen close_forek_disable_commom_pen,
            ref Pen close_fore_pen, ref bool close_fore_is_commom_pen)
        {
            if (!this.Enabled || !tabPage.TabItemEnabled || !tabPage.TabItemCloseButton.Enabled)
            {
                if (tabPage.TabItemCloseButton.BackDisableColor == Color.Empty)
                {
                    if (close_back_disable_commom_sb == null)
                    {
                        close_back_disable_commom_sb = new SolidBrush(this.TabItemCloseButtonBackDisableColor);
                    }
                    close_back_sb = close_back_disable_commom_sb;
                    close_back_is_commom_sb = true;
                }
                else
                {
                    close_back_sb = new SolidBrush(tabPage.TabItemCloseButton.BackDisableColor);
                    close_back_is_commom_sb = false;
                }

                if (tabPage.TabItemCloseButton.ForeDisableColor == Color.Empty)
                {
                    if (close_forek_disable_commom_pen == null)
                    {
                        close_forek_disable_commom_pen = new Pen(this.TabItemCloseButtonForeDisableColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    }
                    close_fore_pen = close_forek_disable_commom_pen;
                    close_fore_is_commom_pen = true;
                }
                else
                {
                    close_fore_pen = new Pen(tabPage.TabItemCloseButton.ForeDisableColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    close_fore_is_commom_pen = false;
                }
            }
            else
            {
                if (tabPage.TabItemCloseButton.MouseStatus == MouseStatuss.Enter)
                {
                    if (tabPage.TabItemCloseButton.BackEnterColor == Color.Empty)
                    {
                        if (close_back_enter_commom_sb == null)
                        {
                            close_back_enter_commom_sb = new SolidBrush(this.TabItemCloseButtonBackEnterColor);
                        }
                        close_back_sb = close_back_enter_commom_sb;
                        close_back_is_commom_sb = true;
                    }
                    else
                    {
                        close_back_sb = new SolidBrush(tabPage.TabItemCloseButton.BackEnterColor);
                        close_back_is_commom_sb = false;
                    }

                    if (tabPage.TabItemCloseButton.ForeEnterColor == Color.Empty)
                    {
                        if (close_fore_enter_commom_pen == null)
                        {
                            close_fore_enter_commom_pen = new Pen(this.TabItemCloseButtonForeEnterColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                        }
                        close_fore_pen = close_fore_enter_commom_pen;
                        close_fore_is_commom_pen = true;
                    }
                    else
                    {
                        close_fore_pen = new Pen(tabPage.TabItemCloseButton.ForeEnterColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                        close_fore_is_commom_pen = false;
                    }
                }
                else
                {
                    if (tabPage.TabItemCloseButton.BackNormalColor == Color.Empty)
                    {
                        if (close_back_normal_commom_sb == null)
                        {
                            close_back_normal_commom_sb = new SolidBrush(this.TabItemCloseButtonBackNormalColor);
                        }
                        close_back_sb = close_back_normal_commom_sb;
                        close_back_is_commom_sb = true;
                    }
                    else
                    {
                        close_back_sb = new SolidBrush(tabPage.TabItemCloseButton.BackNormalColor);
                        close_back_is_commom_sb = false;
                    }

                    if (tabPage.TabItemCloseButton.ForeNormalColor == Color.Empty)
                    {
                        if (close_fore_normal_commom_pen == null)
                        {
                            close_fore_normal_commom_pen = new Pen(this.TabItemCloseButtonForeNormalColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                        }
                        close_fore_pen = close_fore_normal_commom_pen;
                        close_fore_is_commom_pen = true;
                    }
                    else
                    {
                        close_fore_pen = new Pen(tabPage.TabItemCloseButton.ForeNormalColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                        close_fore_is_commom_pen = false;
                    }
                }
            }
        }

        /// <summary>
        /// 获取选项自定义按钮的图片
        /// </summary>
        /// <param name="tabPage">选项自定义按钮所属选项</param>
        /// <param name="btn">选项自定义按钮</param>
        private Image GetTabItemCustomButttonImage(TabPagePlusExt tabPage, TabPagePlusExt.TabItemCustomButtonClass btn)
        {
            Image btn_image = null;

            if (btn.CheckButton && btn.Checked)
            {
                if (!this.Enabled || !tabPage.TabItemEnabled || !btn.Enabled)
                {
                    btn_image = btn.TabItemCustomButtonCheckedDisableImage;
                }
                else
                {
                    if (btn.MouseStatus == MouseStatuss.Enter)
                    {
                        btn_image = btn.TabItemCustomButtonCheckedEnterImage;
                    }
                    else if (btn.MouseStatus == MouseStatuss.Normal)
                    {
                        btn_image = btn.TabItemCustomButtonCheckedNormalImage;
                    }
                }
            }
            else
            {
                if (!this.Enabled || !tabPage.TabItemEnabled || !btn.Enabled)
                {
                    btn_image = btn.TabItemCustomButtonDisableImage;
                }
                else
                {
                    if (btn.MouseStatus == MouseStatuss.Enter)
                    {
                        btn_image = btn.TabItemCustomButtonEnterImage;
                    }
                    else if (btn.MouseStatus == MouseStatuss.Normal)
                    {
                        btn_image = btn.TabItemCustomButtonNormalImage;
                    }
                }
            }

            if (btn_image == null)
            {
                btn_image = global::WinformControlLibraryExtension.Resources.tabcontrol_item_default_button_ico;
            }

            return btn_image;
        }

        /// <summary>
        /// 视觉上TabItem是否正在tabtop_items_display_rect区域显示
        /// </summary>
        /// <param name="tabPage">指定TabItem</param>
        private bool GetTabItemVisualStatus(TabPagePlusExt tabPage)
        {
            if (this.MenuBarAlignment == MenuBarAlignments.Top)
            {
                return (tabPage.P_Rect.Right >= this.menubar_items_c_rect.X && tabPage.P_Rect.X <= this.menubar_items_c_rect.Right);
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Bottom)
            {
                return (tabPage.P_Rect.Right >= this.menubar_items_c_rect.X && tabPage.P_Rect.X <= this.menubar_items_c_rect.Right);
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left)
            {
                return (tabPage.P_Rect.Bottom >= this.menubar_items_c_rect.Y && tabPage.P_Rect.Y <= this.menubar_items_c_rect.Bottom);
            }
            else
            {
                return (tabPage.P_Rect.Bottom >= this.menubar_items_c_rect.Y && tabPage.P_Rect.Y <= this.menubar_items_c_rect.Bottom);
            }
        }


        /// <summary>
        /// 重置所有对象鼠标状态
        /// </summary>
        private void ResetAllMouseStatus()
        {
            bool isreset = false;
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.TabPages[i].MouseStatus != MouseStatuss.Normal)
                {
                    this.TabPages[i].MouseStatus = MouseStatuss.Normal;
                    isreset = true;
                }

                if (this.TabPages[i].TabItemCloseButton.MouseStatus != MouseStatuss.Normal)
                {
                    this.TabPages[i].TabItemCloseButton.MouseStatus = MouseStatuss.Normal;
                    isreset = true;
                }

                foreach (TabPagePlusExt.TabItemCustomButtonClass btn in this.TabPages[i].TabItemCustomButtons)
                {
                    if (btn.Enabled)
                    {
                        if (btn.MouseStatus == MouseStatuss.Enter)
                        {
                            btn.MouseStatus = MouseStatuss.Normal;
                            isreset = true;
                        }
                    }
                }
            }

            if (this.NavigationPrevButton.MoveStatus != MouseStatuss.Normal)
            {
                this.NavigationPrevButton.MoveStatus = MouseStatuss.Normal;
                isreset = true;
            }
            if (this.NavigationNextButton.MoveStatus != MouseStatuss.Normal)
            {
                this.NavigationNextButton.MoveStatus = MouseStatuss.Normal;
                isreset = true;
            }

            for (int i = 0; i < this.GlobalCustomButttons.Count; i++)
            {
                GlobalCustomButttonClass btn = this.GlobalCustomButttons[i];
                if (btn.MouseStatus != MouseStatuss.Normal)
                {
                    btn.MouseStatus = MouseStatuss.Normal;
                    isreset = true;
                }
            }

            if (isreset)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 判断指定TabPage是否选中
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        private bool JudgeTabPageIsSelect(TabPagePlusExt tabPage)
        {
            if (tabPage == null || this.SelectedIndex < 0 || this.SelectedIndex >= this.TabCount)
                return false;

            return this.TabPages[this.SelectedIndex] == tabPage;
        }

        /// <summary>
        /// 设置指定索引TabPage为激活页
        /// </summary>
        /// <param name="index">要激活的TabPage</param>
        private void SetActiveTabPage(int index)
        {
            if (index < 0 || index >= this.TabCount)
                return;

            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.tabPages[i].Visible != false)
                {
                    this.tabPages[i].Visible = false;
                }
            }

            this.tabPages[index].Visible = true;
        }

        /// <summary>
        /// 隐藏提示信息
        /// </summary>
        private void TipHide()
        {
            if (tte_owner != null && tte_owner.Equals(this))
            {
                tte.Hide(this);
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="tipParts">要隐藏的部件</param>
        private void TipShow(object tipParts)
        {
            Type type = tipParts.GetType();
            string text = "";
            Rectangle rect = Rectangle.Empty;
            if (type == typeof(GlobalCustomButttonClass))
            {
                GlobalCustomButttonClass btn = (GlobalCustomButttonClass)tipParts;
                text = btn.TipText;
                rect = new Rectangle((int)btn.C_Rect.X, (int)btn.C_Rect.Y, (int)btn.C_Rect.Width, (int)btn.C_Rect.Height);
            }
            else if (type == typeof(TabPagePlusExt.TabItemCustomButtonClass))
            {
                TabPagePlusExt.TabItemCustomButtonClass btn = (TabPagePlusExt.TabItemCustomButtonClass)tipParts;
                text = btn.TipText;
                rect = new Rectangle((int)btn.C_Rect.X, (int)btn.C_Rect.Y, (int)btn.C_Rect.Width, (int)btn.C_Rect.Height);
            }
            if (!String.IsNullOrEmpty(text))
            {
                if (tte == null)
                {
                    tte = new ToolTipExt();
                }

                tte_owner = this;
                tte.AnchorDistance = (int)(4 * DotsPerInchHelper.DPIScale.XScale);
                tte.BackColor = this.TipBackColor;
                tte.ForeColor = this.TipTextColor;
                tte.Show(text, this, rect, ToolTipExt.ToolTipAnchor.TopCenter);
            }

        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 尾部添加TabPage页
        /// </summary>
        /// <param name="tabPage">要添加的TabPage</param>
        /// <returns></returns>
        internal int AddTabPage(TabPagePlusExt tabPage)
        {
            int index = this.TabCount;
            this.Insert(this.TabCount, tabPage);
            return index;
        }

        /// <summary>
        /// 添加TabPage到指定索引位置
        /// </summary>
        /// <param name="index">指定索引位置</param>
        /// <param name="tabPage">要添加的TabPage</param>
        internal void Insert(int index, TabPagePlusExt tabPage)
        {
            if (index < 0 || index > this.tabPages.Length)
            {
                throw new ArgumentOutOfRangeException("索引:" + index + " 超出TabPages范围");
            }

            TabPagePlusExt[] tabPages_tmp = new TabPagePlusExt[this.tabPages.Length + 1];
            int k = 0;
            for (int i = 0; i <= this.tabPages.Length; i++)
            {
                if (i == index)
                {
                    tabPages_tmp[i] = tabPage;
                }
                else
                {
                    tabPages_tmp[i] = this.tabPages[k];
                    k++;
                }
            }
            if (this.menubar_items_start_index < 0)
            {
                this.menubar_items_start_index = 0;
            }

            this.tabPages = tabPages_tmp;
            this.InitializeRectangle();
            this.Invalidate();

            if (this.tsdd != null && this.tsdd.Visible)
            {
                this.tsdd.Close();
            }

            if ((this.SelectedIndex < 0 || this.SelectedIndex >= this.tabPages.Length) && this.tabPages.Length > 0)
            {
                this.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 移除所有TabPage
        /// </summary>
        internal void RemoveAll()
        {
            this.Controls.Clear();
            this.tabPages = new TabPagePlusExt[0];

            this.menubar_items_start_index = 0;
            if (this.SelectedIndex == -1)
            {
                this.ReplenishSelectTabItemToRectangle();
                this.Invalidate();
            }
            else
            {
                this.SelectedIndex = -1;
            }

            if (this.tsdd != null && this.tsdd.Visible)
            {
                this.tsdd.Close();
            }
        }

        /// <summary>
        /// 移除指定索引的TabPage
        /// </summary>
        /// <param name="index">指定索引</param>
        internal void RemoveTabPage(int index)
        {
            if (index < 0 || index >= this.TabCount)
            {
                throw new ArgumentOutOfRangeException("索引:" + index + " 超出TabPages范围");
            }

            TabPagePlusExt old_tabPage = this.SelectedTab;
            int old_tabPageIndex = this.SelectedIndex;
            int k = 0;
            TabPagePlusExt[] tabPages_tmp = new TabPagePlusExt[this.TabCount - 1];
            for (int i = 0; i < this.tabPages.Length; i++)
            {
                if (i != index)
                {
                    tabPages_tmp[k] = this.tabPages[i];
                    k++;
                }
                else
                {
                    this.tabPages[i].Visible = false;
                }
            }
            this.tabPages = tabPages_tmp;

            if (this.tsdd != null && this.tsdd.Visible)
            {
                this.tsdd.Close();
            }

            if (this.SelectedIndex == -1 || index > old_tabPageIndex)
            {
                //更新画面信息
                this.InitializeRectangle();
                this.Invalidate();
                return;
            }

            if (this.TabCount < 1 && this.SelectedIndex != -1)
            {
                this.selectedIndex = -1;
                //选中索引更改事件
                this.OnSelectedIndexChanged(new TabItemOperatedEventArgs(this.SelectedTab));

                //更新画面信息
                this.InitializeRectangle();
                this.Invalidate();
                return;
            }
            if (index < old_tabPageIndex)
            {
                this.selectedIndex -= 1;
                //选中索引更改事件
                this.OnSelectedIndexChanged(new TabItemOperatedEventArgs(this.SelectedTab));

                //更新画面信息
                this.InitializeRectangle();
                this.Invalidate();
                return;
            }


            int left_start_index = index;
            if (this.selectedIndex == this.TabCount || index == old_tabPageIndex)
            {
                left_start_index -= 1;
            }
            //往左边找激活页
            for (int i = left_start_index; i >= 0; i--)
            {
                TabPagePlusExt new_tabPage = this.GetTabPage(i);

                // 新选项选中中事件
                TabItemOperatingEventArgs selecting_arg = new TabItemOperatingEventArgs(new_tabPage);
                this.OnTabItemSelecting(selecting_arg);
                if (selecting_arg.Cancel)
                {
                    continue;
                }
                else
                {
                    // 新选项选中后事件
                    TabItemOperatedEventArgs selected_arg = new TabItemOperatedEventArgs(new_tabPage);
                    this.OnTabItemSelected(selected_arg);

                    this.selectedIndex = i;
                    //选中索引更改事件
                    this.OnSelectedIndexChanged(new TabItemOperatedEventArgs(this.SelectedTab));

                    //更新画面信息
                    this.InitializeRectangle();
                    this.Invalidate();

                    this.SetActiveTabPage(this.selectedIndex);
                    return;
                }
            }
            int right_start_index = index;
            //往右边找激活页
            for (int i = right_start_index; i < this.TabCount; i++)
            {
                TabPagePlusExt new_tabPage = this.GetTabPage(i);

                // 新选项选中中事件
                TabItemOperatingEventArgs selecting_arg = new TabItemOperatingEventArgs(new_tabPage);
                this.OnTabItemSelecting(selecting_arg);
                if (selecting_arg.Cancel)
                {
                    continue;
                }
                else
                {
                    // 新选项选中后事件
                    TabItemOperatedEventArgs selected_arg = new TabItemOperatedEventArgs(new_tabPage);
                    this.OnTabItemSelected(selected_arg);

                    this.selectedIndex = i;
                    //选中索引更改事件
                    this.OnSelectedIndexChanged(new TabItemOperatedEventArgs(this.SelectedTab));

                    //更新画面信息
                    this.InitializeRectangle();
                    this.Invalidate();

                    this.SetActiveTabPage(this.selectedIndex);
                    return;
                }
            }

            //没有找到可以激活的页        
            this.selectedIndex = -1;
            this.InitializeRectangle();
            this.Invalidate();

            this.SetActiveTabPage(this.selectedIndex);

        }

        /// <summary>
        /// 设置指定索引的TabPage
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <param name="tabPage">要设置的TabPage页</param>
        internal void SetTabPage(int index, TabPagePlusExt tabPage)
        {
            if (index < 0 || index >= this.TabCount)
            {
                throw new ArgumentOutOfRangeException("索引:" + index + " 超出TabPages范围");
            }
            tabPage.Visible = this.tabPages[index].Visible;
            this.tabPages[index] = tabPage;

            if (this.tsdd != null && this.tsdd.Visible)
            {
                this.tsdd.Close();
            }
        }

        /// <summary>
        /// 设置指定索引TabPage为选中
        /// </summary>
        /// <param name="index">指定索引</param>
        public void SelectTab(int index)
        {
            this.SelectedIndex = index;
        }

        /// <summary>
        /// 设置指定TabPage为选中
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        public void SelectTab(TabPagePlusExt tabPage)
        {
            int index = this.FindTabPage(tabPage);
            this.SelectTab(index);
        }

        /// <summary>
        /// 设置指定Name属性值的TabPage为选中
        /// </summary>
        /// <param name="tabPageName">指定Name属性值</param>
        public void SelectTab(string tabPageName)
        {
            if (tabPageName == null)
            {
                throw new ArgumentNullException("tabPageName不允许为null");
            }

            TabPagePlusExt tabPage = this.TabPages[tabPageName];
            this.SelectTab(tabPage);
        }

        /// <summary>
        /// 取消指定索引TabPage的选中状态
        /// </summary>
        /// <param name="index">指定索引</param>
        public void DeselectTab(int index)
        {
            if (this.SelectedIndex == index)
            {
                if (this.TabCount > 1)
                {
                    if (index > 0)
                    {
                        this.SelectedIndex -= 1;
                    }
                    else
                    {
                        int index_tmp = index += 1;
                        if (index_tmp >= this.TabCount)
                        {
                            this.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 取消指定TabPage的选中状态
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        public void DeselectTab(TabPagePlusExt tabPage)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException("tabPage不允许为null");
            }

            int index = this.FindTabPage(tabPage);
            this.DeselectTab(index);
        }

        /// <summary>
        /// 取消指定Name属性值的TabPage的选中状态
        /// </summary>
        /// <param name="tabPageName">指定Name属性值</param>
        public void DeselectTab(string tabPageName)
        {
            if (tabPageName == null)
            {
                throw new ArgumentNullException("tabPageName不允许为null");
            }
            TabPagePlusExt tabPage = this.TabPages[tabPageName];
            this.DeselectTab(tabPage);
        }

        /// <summary>
        /// 查找指定TabPage的索引
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns>找不到返回-1</returns>
        public int FindTabPage(TabPagePlusExt tabPage)
        {
            if (this.tabPages != null)
            {
                for (int i = 0; i < this.TabCount; i++)
                {
                    if (this.tabPages[i].Equals(tabPage))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 调换两个TabItem的位置
        /// </summary>
        /// <param name="currentTabPage">当前要移动的TabPage</param>
        /// <param name="targetTabPage">当前要移动的目标TabPage</param>
        internal void InterchangeTabItemIndex(TabPagePlusExt currentTabPage, TabPagePlusExt targetTabPage)
        {
            if (this.TabCount <= 0 || currentTabPage == targetTabPage)
                return;

            int current_index = this.FindTabPage(currentTabPage);
            int target_index = this.FindTabPage(targetTabPage);
            if (current_index > -1 && target_index > -1)
            {
                TabPagePlusExt[] tabPages_tmp = new TabPagePlusExt[this.TabCount];
                Array.Copy(tabPages, 0, tabPages_tmp, 0, this.TabCount);

                TabPagePlusExt tmp = tabPages_tmp[target_index];
                tabPages_tmp[target_index] = currentTabPage;
                tabPages_tmp[current_index] = tmp;
                this.tabPages = tabPages_tmp;

                if (this.selectedIndex == current_index)
                {
                    this.selectedIndex = target_index;
                }
                else if (this.selectedIndex != current_index && this.selectedIndex == target_index)
                {
                    this.selectedIndex = current_index;
                }

                this.UpdateEveryOneTabItemRectangle();
                this.ReplenishSelectTabItemToRectangle();
                this.Invalidate();

                if (this.tsdd != null && this.tsdd.Visible)
                {
                    this.tsdd.Close();
                }

            }

        }

        /// <summary>
        /// 根据指定索引返回TabPageBaseExt
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <returns></returns>
        public Control GetControl(int index)
        {
            return (Control)this.GetTabPage(index);
        }

        /// <summary>
        /// 根据指定索引返回TabPageBaseExt
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <returns></returns>
        internal TabPagePlusExt GetTabPage(int index)
        {
            if (index < 0 || index >= this.TabCount)
            {
                return null;
            }
            return this.tabPages[index];
        }

        /// <summary>
        /// 获取TabPage数组
        /// </summary>
        /// <returns></returns>
        internal TabPagePlusExt[] GetTabPages()
        {
            return (TabPagePlusExt[])this.GetItems();
        }

        /// <summary>
        /// 获取TabPage数组
        /// </summary>
        /// <returns></returns>
        protected virtual object[] GetItems()
        {
            TabPagePlusExt[] result = new TabPagePlusExt[this.TabCount];
            if (this.TabCount > 0)
            {
                Array.Copy(tabPages, 0, result, 0, this.TabCount);
            }
            return result;
        }


        /// <summary>
        /// 判断坐标是否在导航栏按钮中(设计器使用)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool JudgePointNavigationButton(Point point)
        {
            if (this.NavigationVisible == false || this.menubar_navigation_visualstatus == false)
            {
                return false;
            }

            if (this.menubar_navigation_c_rect.Contains(point))
            {
                if (this.NavigationPrevButton.C_Rect.Contains(point))
                {
                    return true;
                }
                if (this.NavigationNextButton.C_Rect.Contains(point))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断坐标是否在选卡项中(设计器使用)
        /// </summary>
        /// <param name="point">坐标</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool JudgePointInItem(Point point)
        {
            bool result = false;
            if (this.menubar_items_c_rect.Contains(point))
            {
                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    if (this.TabPages[i].P_GP.IsVisible(point))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }



        /// <summary>
        /// 获取指定选项是否为自动宽度
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public bool GetProperty_ItemAutoWidth(TabPagePlusExt tabPage)
        {
            if (tabPage.TabItemAutoWidth == TabPagePlusExt.TabItemAutoWidthMode.Auto)
            {
                return this.TabItemAutoWidth;
            }
            else
            {
                return tabPage.TabItemAutoWidth == TabPagePlusExt.TabItemAutoWidthMode.True ? true : false;
            }
        }

        /// <summary>
        /// 获取指定选项自动宽度最小宽度
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public int GetProperty_ItemAutoWidthMin(TabPagePlusExt tabPage)
        {
            return tabPage.TabItemAutoWidthMin == -1 ? this.TabItemAutoWidthMin : tabPage.TabItemAutoWidthMin;
        }

        /// <summary>
        /// 获取指定TabPage左边外边距
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public int GetProperty_ItemLeftMargin(TabPagePlusExt tabPage)
        {
            return tabPage.TabItemMargin.Left == -1 ? this.TabItemMargin.Left : tabPage.TabItemMargin.Left;
        }

        /// <summary>
        /// 获取指定TabPage右边外边距
        /// </summary>
        /// <param name="tabPage">指定TabPage/param>
        /// <returns></returns>
        public int GetProperty_ItemRightMargin(TabPagePlusExt tabPage)
        {
            return tabPage.TabItemMargin.Right == -1 ? this.TabItemMargin.Right : tabPage.TabItemMargin.Right;
        }

        /// <summary>
        /// 获取指定TabPage左边内边距
        /// </summary>
        /// <param name="tabPage">指定选项</param>
        /// <returns></returns>
        public int GetProperty_ItemLeftPadding(TabPagePlusExt tabPage)
        {
            return tabPage.TabItemPadding.Left == -1 ? this.TabItemPadding.Left : tabPage.TabItemPadding.Left;
        }

        /// <summary>
        /// 获取指定TabPage右边内边距 
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public int GetProperty_ItemRightPadding(TabPagePlusExt tabPage)
        {
            return tabPage.TabItemPadding.Right == -1 ? this.TabItemPadding.Right : tabPage.TabItemPadding.Right;
        }

        /// <summary>
        /// 获取指定TabPage的背景颜色
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public Color GetProperty_ItemBackColor(TabPagePlusExt tabPage)
        {
            if (!this.Enabled || !tabPage.TabItemEnabled)
            {
                if (tabPage.TabItemBackDisableColor == Color.Empty)
                {
                    return this.TabItemBackDisableColor;
                }
                return tabPage.TabItemBackDisableColor;
            }
            else
            {
                if (this.JudgeTabPageIsSelect(tabPage))
                {
                    if (tabPage.TabItemBackSelectedColor == Color.Empty)
                    {
                        return this.TabItemBackSelectedColor;
                    }
                    return tabPage.TabItemBackSelectedColor;
                }
                else
                {
                    if (tabPage.MouseStatus == MouseStatuss.Enter)
                    {
                        if (tabPage.TabItemBackEnterColor == Color.Empty)
                        {
                            return this.TabItemBackEnterColor;
                        }
                        return tabPage.TabItemBackEnterColor;
                    }
                    else
                    {
                        if (tabPage.TabItemBackNormalColor == Color.Empty)
                        {
                            return this.TabItemBackNormalColor;
                        }
                        return tabPage.TabItemBackNormalColor;
                    }

                }
            }
        }

        /// <summary>
        /// 获取指定TabPage的文本颜色
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public Color GetProperty_ItemTextColor(TabPagePlusExt tabPage)
        {
            if (!this.Enabled || !tabPage.TabItemEnabled)
            {
                if (tabPage.TabItemTextDisableColor == Color.Empty)
                {
                    return this.TabItemTextDisableColor;
                }
                return tabPage.TabItemTextDisableColor;
            }
            else
            {
                if (this.JudgeTabPageIsSelect(tabPage))
                {
                    if (tabPage.TabItemTextSelectedColor == Color.Empty)
                    {
                        return this.TabItemTextSelectedColor;
                    }
                    return tabPage.TabItemTextSelectedColor;
                }
                else
                {
                    if (tabPage.MouseStatus == MouseStatuss.Enter)
                    {
                        if (tabPage.TabItemTextEnterColor == Color.Empty)
                        {
                            return this.TabItemTextEnterColor;
                        }
                        return tabPage.TabItemTextEnterColor;
                    }
                    else
                    {
                        if (tabPage.TabItemTextNormalColor == Color.Empty)
                        {
                            return this.TabItemTextNormalColor;
                        }
                        return tabPage.TabItemTextNormalColor;
                    }

                }
            }
        }



        /// <summary>
        /// 获取指定TabPage是否显示图标
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public bool GetProperty_ItemIcoVisible(TabPagePlusExt tabPage)
        {
            if (tabPage.TabItemIcoVisible == TabPagePlusExt.TabItemIcoVisibles.Auto)
            {
                return this.TabItemIcoVisible;
            }
            else
            {
                return tabPage.TabItemIcoVisible == TabPagePlusExt.TabItemIcoVisibles.True ? true : false;
            }
        }

        /// <summary>
        /// 获取指定TabPage是否显示关闭按钮
        /// </summary>
        /// <param name="tabPage">指定TabPage</param>
        /// <returns></returns>
        public bool GetProperty_ItemColseVisible(TabPagePlusExt tabPage)
        {
            if (tabPage.TabItemCloseButton.Visible == TabPagePlusExt.TabItemCloseButtonVisibles.Auto)
            {
                return this.TabItemCloseButtonVisible;
            }
            else
            {
                return tabPage.TabItemCloseButton.Visible == TabPagePlusExt.TabItemCloseButtonVisibles.True ? true : false;
            }
        }

        /// <summary>
        /// 显示下拉面板
        /// </summary>
        /// <param name="target_rect">相对于TabControlPlusExt控件RectangleF</param>
        public void ShowDropDownPanel(RectangleF target_rect)
        {
            if (this.panel == null)
            {
                this.panel = new TabControlPlusDropDownPanelExt(this);
            }
            if (this.tsdd == null)
            {
                this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };
            }
            if (this.tsch == null)
            {
                this.tsch = new ToolStripControlHost(this.panel) { Margin = Padding.Empty, Padding = Padding.Empty };
                tsdd.Items.Add(this.tsch);
            }

            int dropdownpanel_space = 4;
            target_rect = new RectangleF(this.PointToScreen(new Point((int)target_rect.Location.X, (int)target_rect.Location.Y)), target_rect.Size);
            Rectangle screen_rect = Screen.GetWorkingArea(this);
            int scale_item_height = (int)(this.DropDownPanel.ItemHeight * DotsPerInchHelper.DPIScale.XScale);
            int scale_item_width = (int)(200 * DotsPerInchHelper.DPIScale.XScale);
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.TabPages[i].Text_DropDown_Size.Width > scale_item_width)
                {
                    scale_item_width = this.TabPages[i].Text_DropDown_Size.Width;
                }
            }

            Size scale_dropdownpanel_maxsize = Size.Ceiling(new SizeF(this.DropDownPanel.MaxSize.Width * DotsPerInchHelper.DPIScale.XScale, this.DropDownPanel.MaxSize.Height * DotsPerInchHelper.DPIScale.XScale));
            int scale_dropdownpanel_width = Math.Min((scale_item_width + this.DropDownPanel.BorderThickness * 2), scale_dropdownpanel_maxsize.Width);
            int scale_dropdownpanel_height = Math.Min((scale_item_height * this.TabPages.Count + this.DropDownPanel.BorderThickness * 2), scale_dropdownpanel_maxsize.Height);

            Point point = Point.Empty;
            if (this.MenuBarAlignment == MenuBarAlignments.Top)
            {
                point = new Point((int)(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width), (int)(target_rect.Bottom + dropdownpanel_space));//下拉框Top默认位置
                if (point.Y + scale_dropdownpanel_height > screen_rect.Bottom - dropdownpanel_space)//下拉框高度超过屏幕底部
                {
                    if (target_rect.Y > screen_rect.Height * 3 / 4)//下拉框Top默认位置在屏幕高度3/4下面
                    {
                        if (target_rect.Y - dropdownpanel_space - scale_dropdownpanel_height < 0)
                        {
                            scale_dropdownpanel_height = (int)target_rect.Y - dropdownpanel_space * 2;//下拉框高度不能超过屏幕顶部
                        }
                        point = new Point((int)(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width), (int)(target_rect.Y - dropdownpanel_space - scale_dropdownpanel_height));//下拉框改为Bottom默认位置
                    }
                    else
                    {
                        scale_dropdownpanel_height = screen_rect.Bottom - point.Y - dropdownpanel_space;//下拉框高度不能超过屏幕底部
                    }
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Bottom || this.MenuBarAlignment == MenuBarAlignments.Right)
            {
                point = new Point((int)(Math.Min(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.Right - dropdownpanel_space - scale_dropdownpanel_width)), (int)(target_rect.Y - dropdownpanel_space - scale_dropdownpanel_height));//下拉框Bottom默认位置
                if (point.Y < screen_rect.Y + dropdownpanel_space)//下拉框高度超过屏幕顶部
                {
                    if (target_rect.Y < screen_rect.Height / 4)//下拉框Bottom默认位置在屏幕高度1/4上面
                    {
                        point = new Point((int)(Math.Min(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.Right - dropdownpanel_space - scale_dropdownpanel_width)), (int)(target_rect.Bottom + dropdownpanel_space));//下拉框改为Top默认位置
                        if (point.Y + scale_dropdownpanel_height > screen_rect.Bottom - dropdownpanel_space)
                        {
                            scale_dropdownpanel_height = (int)screen_rect.Bottom - point.Y - dropdownpanel_space;//下拉框高度不能超过屏幕底部
                        }
                    }
                    else
                    {
                        point = new Point((int)(Math.Min(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.Right - dropdownpanel_space - scale_dropdownpanel_width)), (int)(screen_rect.Y + dropdownpanel_space));//下拉框Bottom默认位置
                        scale_dropdownpanel_height = (int)target_rect.Y - dropdownpanel_space * 2;//下拉框高度不能超过屏幕顶部
                    }
                }
            }
            else if (this.MenuBarAlignment == MenuBarAlignments.Left)
            {
                if (this.TabItemVerticalLayout)
                {
                    point = new Point((int)(Math.Max(target_rect.X - target_rect.Width, screen_rect.X + dropdownpanel_space)), (int)(target_rect.Y - dropdownpanel_space - scale_dropdownpanel_height));//下拉框Bottom默认位置
                    if (point.Y < screen_rect.Y + dropdownpanel_space)//下拉框高度超过屏幕顶部
                    {
                        if (target_rect.Y < screen_rect.Height / 4)//下拉框Bottom默认位置在屏幕高度1/4上面
                        {
                            point = new Point((int)(Math.Max(target_rect.X - target_rect.Width, screen_rect.X + dropdownpanel_space)), (int)(target_rect.Bottom + dropdownpanel_space));//下拉框改为Top默认位置
                            if (point.Y + scale_dropdownpanel_height > screen_rect.Bottom - dropdownpanel_space)
                            {
                                scale_dropdownpanel_height = (int)screen_rect.Bottom - point.Y - dropdownpanel_space;//下拉框高度不能超过屏幕底部
                            }
                        }
                        else
                        {
                            point = new Point((int)(Math.Max(target_rect.X - target_rect.Width, screen_rect.X + dropdownpanel_space)), (int)(screen_rect.Y + dropdownpanel_space));//下拉框Bottom默认位置
                            scale_dropdownpanel_height = (int)target_rect.Y - dropdownpanel_space * 2;//下拉框高度不能超过屏幕顶部
                        }
                    }
                }
                else
                {
                    point = new Point((int)(Math.Max(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.X + dropdownpanel_space)), (int)(target_rect.Y - dropdownpanel_space - scale_dropdownpanel_height));//下拉框Bottom默认位置
                    if (point.Y < screen_rect.Y + dropdownpanel_space)//下拉框高度超过屏幕顶部
                    {
                        if (target_rect.Y < screen_rect.Height / 4)//下拉框Bottom默认位置在屏幕高度1/4上面
                        {
                            point = new Point((int)(Math.Max(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.X + dropdownpanel_space)), (int)(target_rect.Bottom + dropdownpanel_space));//下拉框改为Top默认位置
                            if (point.Y + scale_dropdownpanel_height > screen_rect.Bottom - dropdownpanel_space)
                            {
                                scale_dropdownpanel_height = (int)screen_rect.Bottom - point.Y - dropdownpanel_space;//下拉框高度不能超过屏幕底部
                            }
                        }
                        else
                        {
                            point = new Point((int)(Math.Max(target_rect.X + target_rect.Width * 2 - scale_dropdownpanel_width, screen_rect.X + dropdownpanel_space)), (int)(screen_rect.Y + dropdownpanel_space));//下拉框Bottom默认位置
                            scale_dropdownpanel_height = (int)target_rect.Y - dropdownpanel_space * 2;//下拉框高度不能超过屏幕顶部
                        }
                    }
                }

            }

            this.panel.Size = new Size(scale_dropdownpanel_width, scale_dropdownpanel_height);

            this.panel.InitializeRectangle();
            this.panel.Invalidate();
            tsdd.Show(point);
        }

        /// <summary>
        /// 隐藏下拉面板
        /// </summary>
        public void HideDropDownPanel()
        {
            if (this.tsdd == null)
                return;

            this.panel.ResetMouseDownStatus();
            this.tsdd.Close();
        }

        #endregion

        #region 类

        #region TabPage

        /// <summary>
        /// TabPagePlus集合
        /// </summary>
        [Editor(typeof(TabPagePlusCollectionEditorExt), typeof(UITypeEditor))]
        public class TabPagePlusCollection : IList
        {
            #region 字段

            private TabControlPlusExt owner;

            #endregion

            public TabPagePlusCollection(TabControlPlusExt owner)
            {
                this.owner = owner;
            }

            public virtual TabPagePlusExt this[int index]
            {
                get
                {
                    return owner.GetTabPage(index);
                }
                set
                {
                    this.owner.SetTabPage(index, value);
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    if (value is TabPagePlusExt)
                    {
                        this[index] = (TabPagePlusExt)value;
                    }
                    else
                    {
                        throw new ArgumentException("value");
                    }
                }
            }

            public virtual TabPagePlusExt this[string key]
            {
                get
                {
                    if (string.IsNullOrEmpty(key))
                    {
                        return null;
                    }

                    int index = IndexOfKey(key);
                    if (IsValidIndex(index))
                    {
                        return this[index];
                    }
                    else
                    {
                        return null;
                    }

                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.owner.tabPages.Count();
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public void Add(TabPagePlusExt value)
            {

                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                owner.Controls.Add(value);
            }

            int IList.Add(object value)
            {
                if (value is TabPagePlusExt)
                {
                    TabPagePlusExt tab_page = (TabPagePlusExt)value;
                    this.Add(tab_page);
                    return IndexOf(tab_page);
                }
                else
                {
                    throw new ArgumentException("value");
                }
            }

            public void Add(string text)
            {
                TabPagePlusExt tab_page = new TabPagePlusExt();
                tab_page.Text = text;
                this.Add(tab_page);
            }

            public void Add(string key, string text)
            {
                TabPagePlusExt tab_page = new TabPagePlusExt();
                tab_page.Name = key;
                tab_page.Text = text;
                this.Add(tab_page);
            }

            public void AddRange(TabPagePlusExt[] tabPages)
            {
                if (tabPages == null)
                {
                    throw new ArgumentNullException("pages");
                }
                foreach (TabPagePlusExt tab_page in tabPages)
                {
                    this.Add(tab_page);
                }
            }

            public bool Contains(TabPagePlusExt tabPage)
            {
                if (tabPage == null)
                    throw new ArgumentNullException("value");

                return IndexOf(tabPage) != -1;
            }

            bool IList.Contains(object tabPage)
            {
                if (tabPage is TabPagePlusExt)
                {
                    return Contains((TabPagePlusExt)tabPage);
                }
                else
                {
                    return false;
                }
            }

            public virtual bool ContainsKey(string key)
            {
                return IsValidIndex(IndexOfKey(key));
            }

            public int IndexOf(TabPagePlusExt tabPage)
            {
                if (tabPage == null)
                    throw new ArgumentNullException("value");

                for (int index = 0; index < Count; ++index)
                {
                    if (this[index] == tabPage)
                    {
                        return index;
                    }
                }
                return -1;
            }

            int IList.IndexOf(object tabPage)
            {
                if (tabPage is TabPagePlusExt)
                {
                    return IndexOf((TabPagePlusExt)tabPage);
                }
                else
                {
                    return -1;
                }
            }

            public virtual int IndexOfKey(String key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return -1;
                }

                for (int i = 0; i < this.Count; i++)
                {
                    if (((TabPagePlusExt)this.owner.tabPages[i]).Name == key)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void Insert(int index, TabPagePlusExt tabPage)
            {
                if (index < 0 || index > this.Count)
                    return;

                owner.Controls.Add(tabPage);
                owner.Controls.SetChildIndex(tabPage, index);
            }

            void IList.Insert(int index, object tabPage)
            {
                if (tabPage is TabPagePlusExt)
                {
                    this.Insert(index, (TabPagePlusExt)tabPage);
                }
                else
                {
                    throw new ArgumentException("tabPage");
                }
            }

            public void Insert(int index, string text)
            {
                TabPagePlusExt tab_page = new TabPagePlusExt();
                tab_page.Text = text;
                this.Insert(index, tab_page);
            }

            private bool IsValidIndex(int index)
            {
                return ((index >= 0) && (index < this.Count));
            }

            public virtual void Clear()
            {
                owner.RemoveAll();
            }

            void ICollection.CopyTo(Array dest, int index)
            {
                if (Count > 0)
                {
                    System.Array.Copy(owner.GetTabPages(), 0, dest, index, Count);
                }
            }

            public IEnumerator GetEnumerator()
            {
                TabPagePlusExt[] tabPages = owner.GetTabPages();
                if (tabPages != null)
                {
                    return tabPages.GetEnumerator();
                }
                else
                {
                    return new TabPagePlusExt[0].GetEnumerator();
                }
            }

            public void Remove(TabPagePlusExt value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                owner.Controls.Remove(value);
            }

            void IList.Remove(object value)
            {
                if (value is TabPagePlusExt)
                {
                    this.Remove((TabPagePlusExt)value);
                }
            }

            public void RemoveAt(int index)
            {
                owner.Controls.RemoveAt(index);
            }

            public virtual void RemoveByKey(string key)
            {
                int index = IndexOfKey(key);
                if (IsValidIndex(index))
                {
                    this.RemoveAt(index);
                }
            }

        }

        /// <summary>
        /// 重写TabControlPlusExt只允许添加TabPagePlusExt类型的子控件
        /// </summary>
        [ComVisible(false)]
        [Editor(typeof(TabPagePlusExtControlCollectionEditor), typeof(UITypeEditor))]
        public class TabControlPlusExtControlsCollection : Control.ControlCollection
        {
            #region 字段

            private TabControlPlusExt owner;

            #endregion

            public TabControlPlusExtControlsCollection(TabControlPlusExt owner) : base(owner)
            {
                this.owner = owner;
            }

            #region 重写

            public override void Add(Control value)
            {
                if (!(value is TabPagePlusExt))
                {
                    throw new ArgumentException("添加的类型必须为 TabPagePlusExt");
                }

                TabPagePlusExt tabPage = (TabPagePlusExt)value;
                tabPage.Visible = false;
                base.Add(tabPage);
                owner.AddTabPage(tabPage);
            }

            public override void Remove(Control value)
            {
                base.Remove(value);
                if (!(value is TabPagePlusExt))
                {
                    return;
                }

                int index = owner.FindTabPage((TabPagePlusExt)value);
                if (index != -1)
                {
                    owner.RemoveTabPage(index);
                }

            }

            #endregion

        }

        #endregion

        #region 全局自定义按钮

        /// <summary>
        /// 全局自定义按钮集合
        /// </summary>
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public class GlobalCustomButttonCollection : IList, ICollection, IEnumerable
        {
            #region 字段

            /// <summary>
            /// 全局自定义按钮集合
            /// </summary>
            private ArrayList globalCustomButttonList = new ArrayList();

            /// <summary>
            /// 全局自定义按钮所属TabControl
            /// </summary>
            private TabControlPlusExt owner;

            #endregion

            /// <summary>
            /// 
            /// </summary>
            /// <param name="owner">全局自定义按钮所属TabControl</param>
            public GlobalCustomButttonCollection(TabControlPlusExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                GlobalCustomButttonClass[] listArray = new GlobalCustomButttonClass[this.globalCustomButttonList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (GlobalCustomButttonClass)this.globalCustomButttonList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.globalCustomButttonList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.globalCustomButttonList.Count;
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
                if (!(value is GlobalCustomButttonClass))
                {
                    throw new ArgumentException("GlobalCustomButttonClass");
                }
                return this.Add((GlobalCustomButttonClass)value);
            }

            public int Add(GlobalCustomButttonClass item)
            {
                item.SetOwner(this.owner);
                this.globalCustomButttonList.Add(item);
                if (this.owner != null)
                {
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
                return this.Count - 1;
            }

            public void Clear()
            {
                for (int i = 0; i < this.globalCustomButttonList.Count; i++)
                {
                    ((GlobalCustomButttonClass)this.globalCustomButttonList[i]).SetOwner(null);
                }
                this.globalCustomButttonList.Clear();
                if (this.owner != null)
                {
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            public bool Contains(object value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is GlobalCustomButttonClass)
                {
                    return this.Contains((GlobalCustomButttonClass)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is GlobalCustomButttonClass)
                {
                    return this.globalCustomButttonList.IndexOf(item);
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
                if (!(value is GlobalCustomButttonClass))
                {
                    throw new ArgumentException("GlobalCustomButttonClass");
                }
                this.Remove((GlobalCustomButttonClass)value);
            }

            public void Remove(GlobalCustomButttonClass item)
            {
                item.SetOwner(null);
                this.globalCustomButttonList.Remove(item);
                if (this.owner != null)
                {
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            public void RemoveAt(int index)
            {
                GlobalCustomButttonClass item = (GlobalCustomButttonClass)this.globalCustomButttonList[index];
                item.SetOwner(null);
                this.globalCustomButttonList.RemoveAt(index);
                if (this.owner != null)
                {
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            public void RemoveByKey(string key)
            {
                int index = this.IndexOfKey(key);
                if (this.IsValidIndex(index))
                {
                    this.RemoveAt(index);
                }
            }

            public GlobalCustomButttonClass this[int index]
            {
                get
                {
                    return (GlobalCustomButttonClass)this.globalCustomButttonList[index];
                }
                set
                {
                    GlobalCustomButttonClass item = (GlobalCustomButttonClass)value;
                    item.SetOwner(this.owner);
                    this.globalCustomButttonList[index] = item;
                    if (this.owner != null)
                    {
                        this.owner.InitializeRectangle();
                        this.owner.Invalidate();
                    }
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.globalCustomButttonList[index];
                }
                set
                {
                    GlobalCustomButttonClass item = (GlobalCustomButttonClass)value;
                    item.SetOwner(this.owner);
                    this.globalCustomButttonList[index] = item;
                    if (this.owner != null)
                    {
                        this.owner.InitializeRectangle();
                        this.owner.Invalidate();
                    }
                }
            }

            public virtual GlobalCustomButttonClass this[string key]
            {
                get
                {
                    if (string.IsNullOrEmpty(key))
                    {
                        return null;
                    }

                    int index = this.IndexOfKey(key);
                    if (this.IsValidIndex(index))
                    {
                        return this[index];
                    }
                    else
                    {
                        return null;
                    }

                }
            }

            public virtual int IndexOfKey(String key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return -1;
                }

                for (int i = 0; i < this.Count; i++)
                {
                    if (((GlobalCustomButttonClass)this.globalCustomButttonList[i]).Name == key)
                    {
                        return i;
                    }
                }

                return -1;
            }

            private bool IsValidIndex(int index)
            {
                return ((index >= 0) && (index < this.Count));
            }

            #endregion

        }

        /// <summary>
        /// 全局自定义按钮
        /// </summary>
        [TypeConverter(typeof(EmptyConverter))]
        public class GlobalCustomButttonClass
        {
            #region 新增事件

            public delegate void GlobalCustomButttonEventHandler(object sender, GlobalCustomButttonEventArgs e);
            private event GlobalCustomButttonEventHandler globalCustomButttonClick;
            /// <summary>
            /// 全局自定义按钮单击事件
            /// </summary>
            [Description("全局自定义按钮单击事件")]
            [Category("杂项_全局自定义按钮")]
            public event GlobalCustomButttonEventHandler GlobalCustomButttonClick
            {
                add { this.globalCustomButttonClick += value; }
                remove { this.globalCustomButttonClick -= value; }
            }

            #endregion

            #region 字段

            /// <summary>
            /// 全局自定义按钮所属TabControl
            /// </summary>
            private TabControlPlusExt owner;

            #endregion

            #region 属性

            private string name = "";
            /// <summary>
            /// 按钮名称（必须唯一，可用于索引）
            /// </summary>
            [Description("按钮名称（必须唯一，可用于索引）")]
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

            private BackGauge margin = new BackGauge(1, 1);
            /// <summary>
            /// 按钮左右外边距
            /// </summary>
            [Description("按钮左右外边距")]
            [DefaultValue(typeof(BackGauge), "1,1")]
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
            [Description("按钮Size")]
            [DefaultValue(typeof(Size), "14, 14")]
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

            private object data = null;
            /// <summary>
            /// 按钮自定义保存数据
            /// </summary>
            [Description("按钮自定义保存数据")]
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

            private Image imageNormal = null;
            /// <summary>
            /// 按钮图片(正常)
            /// </summary>
            [Description("按钮图片(正常)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image ImageNormal
            {
                get { return this.imageNormal; }
                set
                {
                    this.imageNormal = value;
                    this.imageDisable = null;
                    this.Invalidate();
                }
            }

            private Image imageDisable = null;
            /// <summary>
            /// 按钮图片(禁用)
            /// </summary>
            [Description("按钮图片(禁用)")]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Image ImageDisable
            {
                get
                {
                    if (this.imageDisable == null && this.ImageNormal != null)
                    {
                        this.imageDisable = ImageCommom.CreateDisabledImage(this.ImageNormal);
                    }
                    return imageDisable;
                }
            }

            private Image imageEnter = null;
            /// <summary>
            /// 按钮图片(鼠标进入)
            /// </summary>
            [Description("按钮图片(鼠标进入)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image ImageEnter
            {
                get { return imageEnter; }
                set
                {
                    this.imageEnter = value;
                    this.Invalidate();
                }
            }

            #region 临时存储

            private RectangleF m_Rect = RectangleF.Empty;
            /// <summary>
            /// 按钮rect（包含:外边距、内边距、内容）
            /// </summary>
            [Description("按钮rect（包含:外边距、内边距、内容）")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF M_Rect
            {
                get { return this.m_Rect; }
                set
                {
                    if (this.m_Rect == value)
                        return;

                    this.m_Rect = value;
                }
            }

            private RectangleF c_Rect = RectangleF.Empty;
            /// <summary>
            /// 按钮rect（只包含:内容）
            /// </summary>
            [Description("按钮rect（只包含:内容）")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal RectangleF C_Rect
            {
                get { return this.c_Rect; }
                set
                {
                    if (this.c_Rect == value)
                        return;

                    this.c_Rect = value;
                }
            }

            private MouseStatuss mouseStatus = MouseStatuss.Normal;
            /// <summary>
            /// 按钮鼠标状态
            /// </summary>
            [Description("按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal MouseStatuss MouseStatus
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

            public GlobalCustomButttonClass()
            {

            }

            #region 虚方法

            internal protected virtual void OnGlobalCustomButttonClick(GlobalCustomButttonEventArgs e)
            {
                if (this.globalCustomButttonClick != null && this.owner != null && this.owner is TabControlPlusExt)
                {
                    this.globalCustomButttonClick(this.owner, e);
                }
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 控件重新初始化和重绘
            /// </summary>
            private void InitializeInvalidate()
            {
                if (this.owner != null)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            /// <summary>
            /// 控件重绘
            /// </summary>
            private void Invalidate()
            {
                if (this.owner != null)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner;
                    tabControl.Invalidate();
                }
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 设置全局自定义按钮所属的控件
            /// </summary>
            /// <param name="owner">设置全局自定义按钮所属的控件</param>
            internal void SetOwner(TabControlPlusExt owner)
            {
                this.owner = owner;
            }

            /// <summary>
            /// 获取按钮Rectangle信息（只包含:内容）
            /// </summary>
            /// <returns></returns>
            public RectangleF GetRectangle()
            {
                return new RectangleF(this.C_Rect.X, this.C_Rect.Y, this.C_Rect.Width, this.C_Rect.Height);
            }

            #endregion

        }

        #endregion

        #region 导航栏按钮

        /// <summary>
        /// 导航栏按钮
        /// </summary>
        [TypeConverter(typeof(EmptyConverter))]
        public class NavigationButtonClass
        {
            #region 字段

            /// <summary>
            /// 导航栏按钮所属TabControl
            /// </summary>
            private TabControlPlusExt owner;

            #endregion

            /// <summary>
            /// 导航栏按钮所属TabControl
            /// </summary>
            /// <param name="_owner"></param>
            public NavigationButtonClass(TabControlPlusExt _owner)
            {
                this.owner = _owner;
            }

            #region 属性

            private NavigationButtonStyles style = NavigationButtonStyles.Default;
            /// <summary>
            /// 导航栏按钮显示风格
            /// </summary>
            [Description("导航栏按钮显示风格")]
            [DefaultValue(NavigationButtonStyles.Default)]
            public NavigationButtonStyles Style
            {
                get { return this.style; }
                set
                {
                    if (this.style == value)
                        return;

                    this.style = value;
                    this.Invalidate();
                }
            }

            private BackGauge margin = new BackGauge(2, 2);
            /// <summary>
            /// 导航栏按钮外边距
            /// </summary>
            [Description("导航栏按钮外边距")]
            [DefaultValue(typeof(BackGauge), "2,2")]
            public BackGauge Margin
            {
                get
                {
                    return this.margin;
                }
                set
                {
                    if (this.margin == value || value.Left < 0 || value.Right < 0)
                        return;

                    this.margin = value;
                    this.InitializeInvalidate();
                }
            }

            private Size size = new Size(12, 12);
            /// <summary>
            /// 导航栏按钮Size
            /// </summary>
            [Description("导航栏按钮Size")]
            [DefaultValue(typeof(Size), "12, 12")]
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

            private Color backNormalColor = Color.Empty;
            /// <summary>
            /// 导航栏按钮背景颜色(正常)
            /// </summary>
            [Description("导航栏按钮背景颜色(正常)")]
            [DefaultValue(typeof(Color), "")]
            public Color BackNormalColor
            {
                get { return this.backNormalColor; }
                set
                {
                    if (this.backNormalColor == value)
                        return;

                    this.backNormalColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Color backEnterColor = Color.Empty;
            /// <summary>
            /// 导航栏按钮背景颜色(鼠标进入)
            /// </summary>
            [Description("导航栏按钮背景颜色(鼠标进入)")]
            [DefaultValue(typeof(Color), "")]
            public Color BackEnterColor
            {
                get { return this.backEnterColor; }
                set
                {
                    if (this.backEnterColor == value)
                        return;

                    this.backEnterColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Color backDisableColor = Color.Empty;
            /// <summary>
            /// 导航栏按钮背景颜色(禁用)
            /// </summary>
            [Description("导航栏按钮背景颜色(禁用)")]
            [DefaultValue(typeof(Color), "")]
            public Color BackDisableColor
            {
                get { return this.backDisableColor; }
                set
                {
                    if (this.backDisableColor == value)
                        return;

                    this.backDisableColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Color foreNormalColor = Color.FromArgb(176, 197, 175);
            /// <summary>
            /// 导航栏按钮前景颜色(正常)
            /// </summary>
            [Description("导航栏按钮前景颜色(正常)")]
            [DefaultValue(typeof(Color), "176, 197, 175")]
            public Color ForeNormalColor
            {
                get { return this.foreNormalColor; }
                set
                {
                    if (this.foreNormalColor == value)
                        return;

                    this.foreNormalColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Color foreEnterColor = Color.FromArgb(144, 169, 143);
            /// <summary>
            /// 导航栏按钮前景颜色(鼠标进入)
            /// </summary>
            [Description("导航栏按钮前景颜色(鼠标进入)")]
            [DefaultValue(typeof(Color), "144, 169, 143")]
            public Color ForeEnterColor
            {
                get { return this.foreEnterColor; }
                set
                {
                    if (this.foreEnterColor == value)
                        return;

                    this.foreEnterColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Color foreDisableColor = Color.FromArgb(206, 226, 206);
            /// <summary>
            /// 导航栏按钮前景颜色(禁用)
            /// </summary>
            [Description("导航栏按钮前景颜色(禁用)")]
            [DefaultValue(typeof(Color), "206, 226, 206")]
            public Color ForeDisableColor
            {
                get { return this.foreDisableColor; }
                set
                {
                    if (this.foreDisableColor == value)
                        return;

                    this.foreDisableColor = value;
                    if (this.Style == NavigationButtonStyles.Default)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Image imageNormal = null;
            /// <summary>
            /// 导航栏按钮图片(正常)
            /// </summary>
            [Description("导航栏按钮图片(正常)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image ImageNormal
            {
                get { return this.imageNormal; }
                set
                {
                    if (this.imageNormal == value)
                        return;

                    this.imageNormal = value;
                    this.imageDisable = null;
                    if (this.Style == NavigationButtonStyles.Image)
                    {
                        this.Invalidate();
                    }
                }
            }

            private Image imageDisable = null;
            /// <summary>
            /// 导航栏按钮图片(禁用)
            /// </summary>
            [Description("导航栏按钮图片(禁用)")]
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Image ImageDisable
            {
                get
                {
                    if (this.imageDisable == null && this.imageNormal != null)
                    {
                        this.imageDisable = ImageCommom.CreateDisabledImage(this.imageNormal);
                    }
                    return imageDisable;
                }

            }

            private Image imageEnter = null;
            /// <summary>
            /// 导航栏按钮图片(鼠标进入)
            /// </summary>
            [Description("导航栏按钮图片(鼠标进入)")]
            [DefaultValue(null)]
            [RefreshProperties(RefreshProperties.Repaint)]
            public Image ImageEnter
            {
                get { return imageEnter; }
                set
                {
                    if (this.imageEnter == value)
                        return;

                    this.imageEnter = value;
                    if (this.Style == NavigationButtonStyles.Image)
                    {
                        this.Invalidate();
                    }
                }
            }

            #region 临时存储

            private Rectangle m_rect;
            /// <summary>
            /// 导航栏按钮rect(包括外边距)
            /// </summary>
            [Description("导航栏按钮rect(包括外边距)")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal Rectangle M_Rect
            {
                get { return this.m_rect; }
                set
                {
                    if (this.m_rect == value)
                        return;

                    this.m_rect = value;
                }
            }

            private Rectangle c_rect;
            /// <summary>
            /// 导航栏按钮rect(不包括外边距、边框、内边距)
            /// </summary>
            [Description("导航栏按钮rect(不包括外边距、边框、内边距)")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal Rectangle C_Rect
            {
                get { return this.c_rect; }
                set
                {
                    if (this.c_rect == value)
                        return;

                    this.c_rect = value;
                }
            }

            private MouseStatuss moveStatus = MouseStatuss.Normal;
            /// <summary>
            /// 导航栏按钮鼠标状态
            /// </summary>
            [Description("导航栏按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal MouseStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;

                    this.moveStatus = value;
                }
            }

            #endregion

            #endregion

            #region 私有方法

            /// <summary>
            /// 控件重新初始化和重绘
            /// </summary>
            private void InitializeInvalidate()
            {
                if (this.owner != null)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner;
                    tabControl.InitializeRectangle();
                    tabControl.Invalidate();
                }
            }

            /// <summary>
            /// 控件重绘
            /// </summary>
            private void Invalidate()
            {
                if (this.owner != null)
                {
                    TabControlPlusExt tabControl = (TabControlPlusExt)this.owner;
                    tabControl.Invalidate();
                }
            }

            #endregion

        }

        #endregion

        #region 下拉面板

        /// <summary>
        /// TabControlPlusExt(下拉面板)
        /// </summary>
        [TypeConverter(typeof(EmptyConverter))]
        public class TabControlPlusDropDownPanelClass
        {
            #region 属性

            private Size maxSize = new Size(400, 600);
            /// <summary>
            /// 下拉框最大Size
            /// </summary>
            [DefaultValue(typeof(Size), "600,600")]
            [Description("下拉框最大Size")]
            public Size MaxSize
            {
                get { return this.maxSize; }
                set
                {
                    if (this.maxSize == value || value.Width < 0 || value.Height < 0)
                        return;

                    this.maxSize = value;
                }
            }

            private int borderThickness = 1;
            /// <summary>
            /// 下拉框边框厚度
            /// </summary>
            [DefaultValue(1)]
            [Description("下拉框边框厚度")]
            public int BorderThickness
            {
                get { return this.borderThickness; }
                set
                {
                    if (this.borderThickness == value || value < 0)
                        return;

                    this.borderThickness = value;
                }
            }

            private Color borderColor = Color.FromArgb(192, 192, 192);
            /// <summary>
            /// 下拉框边框颜色
            /// </summary>
            [DefaultValue(typeof(Color), "192, 192, 192")]
            [Description(" 下拉框边框颜色")]
            public Color BorderColor
            {
                get { return this.borderColor; }
                set
                {
                    if (this.borderColor == value)
                        return;

                    this.borderColor = value;
                }
            }

            #region 下拉框选项

            private bool icoVisible = false;
            /// <summary>
            /// 图标是否显示
            /// </summary>
            [Description("图标是否显示")]
            [DefaultValue(false)]
            public bool IcoVisible
            {
                get { return this.icoVisible; }
                set
                {
                    if (this.icoVisible == value)
                        return;

                    this.icoVisible = value;
                }
            }

            private int itemHeight = 22;
            /// <summary>
            /// 下拉框选项高度
            /// </summary>
            [DefaultValue(22)]
            [Description("下拉框选项高度")]
            public int ItemHeight
            {
                get { return this.itemHeight; }
                set
                {
                    if (this.itemHeight == value || value < 0)
                        return;

                    this.itemHeight = value;
                }
            }

            private Font itemFont = new Font("宋体", 9f);
            /// <summary>
            /// 下拉框选项字体
            /// </summary>
            [DefaultValue(typeof(Font), "宋体, 9pt")]
            [Description("下拉框选项字体")]
            public Font ItemFont
            {
                get { return this.itemFont; }
                set
                {
                    if (this.itemFont == value)
                        return;

                    this.itemFont = value;
                }
            }

            private Color itemBackNormalColor = Color.White;
            /// <summary>
            /// 下拉框选项背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "White")]
            [Description(" 下拉框选项背景颜色（正常）")]
            public Color ItemBackNormalColor
            {
                get { return this.itemBackNormalColor; }
                set
                {
                    if (this.itemBackNormalColor == value)
                        return;

                    this.itemBackNormalColor = value;
                }
            }

            private Color itemTextNormalColor = Color.FromArgb(128, 128, 128);
            /// <summary>
            /// 下拉框选项文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "128, 128, 128")]
            [Description(" 下拉框选项文本颜色（正常）")]
            public Color ItemTextNormalColor
            {
                get { return this.itemTextNormalColor; }
                set
                {
                    if (this.itemTextNormalColor == value)
                        return;

                    this.itemTextNormalColor = value;
                }
            }

            private Color itemBackEnterColor = Color.FromArgb(189, 208, 188);
            /// <summary>
            /// 下拉框选项背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "189, 208, 188")]
            [Description(" 下拉框选项背景颜色（鼠标进入）")]
            public Color ItemBackEnterColor
            {
                get { return this.itemBackEnterColor; }
                set
                {
                    if (this.itemBackEnterColor == value)
                        return;

                    this.itemBackEnterColor = value;
                }
            }

            private Color itemTextEnterColor = Color.White;
            /// <summary>
            /// 下拉框选项文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "White")]
            [Description(" 下拉框选项文本颜色（鼠标进入）")]
            public Color ItemTextEnterColor
            {
                get { return this.itemTextEnterColor; }
                set
                {
                    if (this.itemTextEnterColor == value)
                        return;

                    this.itemTextEnterColor = value;
                }
            }

            private Color itemBackDisableColor = Color.FromArgb(234, 234, 234);
            /// <summary>
            /// 下拉框选项背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "234, 234, 234")]
            [Description(" 下拉框选项背景颜色（禁止）")]
            public Color ItemBackDisableColor
            {
                get { return this.itemBackDisableColor; }
                set
                {
                    if (this.itemBackDisableColor == value)
                        return;

                    this.itemBackDisableColor = value;
                }
            }

            private Color itemTextDisableColor = Color.FromArgb(192, 192, 192);
            /// <summary>
            /// 下拉框选项文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "192, 192, 192")]
            [Description("下拉框选项文本颜色（禁止）")]
            public Color ItemTextDisableColor
            {
                get { return this.itemTextDisableColor; }
                set
                {
                    if (this.itemTextDisableColor == value)
                        return;

                    this.itemTextDisableColor = value;
                }
            }

            private DropDownItemSplitterStyles itemSplitterStyle = DropDownItemSplitterStyles.GradualLine;
            /// <summary>
            /// 下拉框选项分割线风格
            /// </summary>
            [DefaultValue(DropDownItemSplitterStyles.GradualLine)]
            [Description("下拉框选项分割线风格")]
            public DropDownItemSplitterStyles ItemSplitterStyle
            {
                get { return this.itemSplitterStyle; }
                set
                {
                    if (this.itemSplitterStyle == value)
                        return;

                    this.itemSplitterStyle = value;
                }
            }

            private Color itemSplitterColor = Color.FromArgb(224, 224, 224);
            /// <summary>
            /// 下拉框选项分割线颜色
            /// </summary>
            [DefaultValue(typeof(Color), "224, 224, 224")]
            [Description(" 下拉框选项分割线颜色")]
            public Color ItemSplitterColor
            {
                get { return this.itemSplitterColor; }
                set
                {
                    if (this.itemSplitterColor == value)
                        return;

                    this.itemSplitterColor = value;
                }
            }

            #endregion

            #region  下拉框滚动条

            private int scrollWheelSpeed = 10;
            /// <summary>
            /// 下拉框滚动条鼠标滚轮速度倍数
            /// </summary>
            [DefaultValue(10)]
            [Description("下拉框滚动条鼠标滚轮速度倍数")]
            public int ScrollWheelSpeed
            {
                get { return this.scrollWheelSpeed; }
                set
                {
                    if (this.scrollWheelSpeed == value || value <= 0)
                        return;

                    this.scrollWheelSpeed = value;
                }
            }

            private int scrollBarThickness = 10;
            /// <summary>
            /// 下拉框滚动条滑条厚度
            /// </summary>
            [DefaultValue(10)]
            [Description("下拉框滚动条滑条厚度")]
            public int ScrollBarThickness
            {
                get { return this.scrollBarThickness; }
                set
                {
                    if (this.scrollBarThickness == value || value < 0)
                        return;

                    this.scrollBarThickness = value;
                }
            }

            private Color scrollBarBackNormalColor = Color.FromArgb(68, 128, 128, 128);
            /// <summary>
            /// 下拉框滚动条滑条背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "68, 128, 128, 128")]
            [Description("下拉框滚动条滑条背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ScrollBarBackNormalColor
            {
                get { return this.scrollBarBackNormalColor; }
                set
                {
                    if (this.scrollBarBackNormalColor == value)
                        return;

                    this.scrollBarBackNormalColor = value;
                }
            }

            private Color scrollBarBackDisableColor = Color.FromArgb(224, 224, 224);
            /// <summary>
            /// 下拉框滚动条滑条背景颜色（禁止）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "224, 224, 224")]
            [Description("下拉框滚动条滑条背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color ScrollBarBackDisableColor
            {
                get { return this.scrollBarBackDisableColor; }
                set
                {
                    if (this.scrollBarBackDisableColor == value)
                        return;

                    this.scrollBarBackDisableColor = value;
                }
            }



            private int scrollSlideMinHeight = 26;
            /// <summary>
            /// 下拉框滚动条滑块最小高度
            /// </summary>
            [DefaultValue(26)]
            [Description("下拉框滚动条滑块最小高度")]
            public int ScrollSlideMinHeight
            {
                get { return this.scrollSlideMinHeight; }
                set
                {
                    if (this.scrollSlideMinHeight == value || value < 1)
                        return;

                    this.scrollSlideMinHeight = value;
                }
            }

            private Color scrollSlideBackNormalColor = Color.FromArgb(120, 64, 64, 64);
            /// <summary>
            /// 下拉框滚动条滑块背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "120, 64, 64, 64")]
            [Description("下拉框滚动条滑块背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ScrollSlideBackNormalColor
            {
                get { return this.scrollSlideBackNormalColor; }
                set
                {
                    if (this.scrollSlideBackNormalColor == value)
                        return;

                    this.scrollSlideBackNormalColor = value;
                }
            }

            private Color scrollSlideBackDisableColor = Color.FromArgb(192, 192, 192);
            /// <summary>
            /// 下拉框滚动条滑块背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "192, 192, 192")]
            [Description("下拉框滚动条滑块背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ScrollSlideBackDisableColor
            {
                get { return this.scrollSlideBackDisableColor; }
                set
                {
                    if (this.scrollSlideBackDisableColor == value)
                        return;

                    this.scrollSlideBackDisableColor = value;
                }
            }

            private Color scrollSlideBackEnterColor = Color.FromArgb(160, 64, 64, 64);
            /// <summary>
            /// 下拉框滚动条滑块背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "160,64, 64, 64")]
            [Description("下拉框滚动条滑块背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ScrollSlideBackEnterColor
            {
                get { return this.scrollSlideBackEnterColor; }
                set
                {
                    if (this.scrollSlideBackEnterColor == value)
                        return;

                    this.scrollSlideBackEnterColor = value;
                }
            }



            private Rectangle scrollBar_Rect = Rectangle.Empty;
            /// <summary>
            /// 下拉框滚动条滑条Rect
            /// </summary>
            [Description("下拉框滚动条滑条Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle ScrollBar_Rect
            {
                get { return this.scrollBar_Rect; }
                set
                {
                    if (this.scrollBar_Rect == value)
                        return;

                    this.scrollBar_Rect = value;
                }
            }

            private RectangleF scrollSlide_Rect = RectangleF.Empty;
            /// <summary>
            /// 下拉框滚动条滑块rect
            /// </summary>
            [Description("下拉框滚动条滑块rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF ScrollSlide_Rect
            {
                get { return this.scrollSlide_Rect; }
                set { this.scrollSlide_Rect = value; }
            }

            private ScrollSlideMoveStatus scrollSlide_MouseStatus = ScrollSlideMoveStatus.Normal;
            /// <summary>
            /// 下拉框滚动条滑块鼠标状态
            /// </summary>
            [Browsable(false)]
            [Description("下拉框滚动条滑块鼠标状态")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal ScrollSlideMoveStatus ScrollSlide_MouseStatus
            {
                get { return this.scrollSlide_MouseStatus; }
                set { this.scrollSlide_MouseStatus = value; }
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region 枚举

        /// <summary>
        /// 菜单出现的位置
        /// </summary>
        public enum MenuBarAlignments
        {
            /// <summary>
            /// 控件的顶部
            /// </summary>
            Top = 0,
            /// <summary>
            /// 控件的底部
            /// </summary>
            Bottom = 1,
            /// <summary>
            /// 控件的左边
            /// </summary>
            Left = 2,
            /// <summary>
            /// 控件的右边
            /// </summary>
            Right = 3
        }

        /// <summary>
        /// 导航栏按钮类型
        /// </summary>
        public enum NavigationButtonTypes
        {
            /// <summary>
            /// 上一页
            /// </summary>
            Prev,
            /// <summary>
            /// 下一页
            /// </summary>
            Next
        }

        /// <summary>
        /// 导航栏按钮显示风格
        /// </summary>
        public enum NavigationButtonStyles
        {
            /// <summary>
            /// 默认
            /// </summary>
            Default,
            /// <summary>
            /// 图片
            /// </summary>
            Image
        }

        /// <summary>
        /// TabItem关闭按钮显示位置(通用配置)
        /// </summary>
        public enum TabItemColseButtonAlignments
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
        /// 按钮鼠标状态
        /// </summary>
        internal enum MouseStatuss
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
        /// 滚动条滑块鼠标状态
        /// </summary>
        internal enum ScrollSlideMoveStatus
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
        /// 下拉框选项分割线风格
        /// </summary>
        public enum DropDownItemSplitterStyles
        {
            /// <summary>
            /// 没有
            /// </summary>
            None,
            /// <summary>
            /// 线
            /// </summary>
            Line,
            /// <summary>
            /// 渐变线
            /// </summary>]
            GradualLine
        }

        #endregion

        #region 事件参数类

        #region 菜单

        /// <summary>
        /// 菜单背景绘制前事件参数
        /// </summary>
        public class MenuBarDrawBackgroundBeforeEventArgs : EventArgs
        {
            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipPaddingBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 菜单Rectangle（排除非剪辑区）（只包含:内边距、内容）
            /// </summary>
            public RectangleF ClipPaddingBounds { get; }

            /// <summary>
            /// 菜单Rectangle（包含非剪辑区）（包含:内边距、内容）
            /// </summary>
            public RectangleF NoClipPaddingBounds { get; }

            /// <summary>
            /// 菜单Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 菜单背景绘制是否已处理完毕 (True 将会跳过控件的默认绘制)
            /// </summary>
            public bool Finish { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面</param>
            /// <param name="noClipPaddingBounds">菜单Rectangle（包含内边距）</param>
            /// <param name="noClipContentBounds">菜单Rectangle（排除内边距）</param>
            /// <param name="finish">是否处理完毕</param>
            public MenuBarDrawBackgroundBeforeEventArgs(DotsPerInch dPIScale, Graphics graphics, RectangleF clipPaddingBounds, RectangleF noClipPaddingBounds, RectangleF noClipContentBounds, bool finish)
            {
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.ClipPaddingBounds = clipPaddingBounds;
                this.NoClipPaddingBounds = noClipPaddingBounds;
                this.NoClipContentBounds = noClipContentBounds;
                this.Finish = finish;
            }

        }

        /// <summary>
        /// 菜单背景绘制后事件参数
        /// </summary>
        public class MenuBarDrawBackgroundAfterEventArgs : EventArgs
        {
            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipPaddingBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 菜单Rectangle（排除非剪辑区）（只包含:内边距、内容）
            /// </summary>
            public RectangleF ClipPaddingBounds { get; }

            /// <summary>
            /// 菜单Rectangle（包含非剪辑区）（包含:内边距、内容）
            /// </summary>
            public RectangleF NoClipPaddingBounds { get; }

            /// <summary>
            /// 菜单Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面（可绘制区域为:ClipPaddingBounds）</param>
            /// <param name="clipPaddingBounds">菜单Rectangle（排除非剪辑区）（只包含:内边距、内容）</param>
            /// <param name="noClipPaddingBounds">菜单Rectangle（包含非剪辑区）（包含:内边距、内容）</param>
            /// <param name="noClipContentBounds">菜单Rectangle（包含非剪辑区）（只包含:内容）</param>
            public MenuBarDrawBackgroundAfterEventArgs(DotsPerInch dPIScale, Graphics graphics, RectangleF clipPaddingBounds, RectangleF noClipPaddingBounds, RectangleF noClipContentBounds)
            {
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.ClipPaddingBounds = clipPaddingBounds;
                this.NoClipPaddingBounds = noClipPaddingBounds;
                this.NoClipContentBounds = noClipContentBounds;
            }

        }

        #endregion

        #region 全局自定义按钮

        /// <summary>
        /// 全局自定义按钮事件参数
        /// </summary>
        public class GlobalCustomButttonEventArgs : EventArgs
        {
            /// <summary>
            /// 全局自定义按钮
            /// </summary>
            public GlobalCustomButttonClass GlobalCustomButtton { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="globalCustomButtton">全局自定义按钮</param>
            public GlobalCustomButttonEventArgs(GlobalCustomButttonClass globalCustomButtton)
            {
                this.GlobalCustomButtton = globalCustomButtton;
            }

        }

        #endregion

        #region 导航栏按钮

        /// <summary>
        /// 导航栏按钮操作时事件参数
        /// </summary>
        public class NavigationButtonOperatingEventArgs : CancelEventArgs
        {
            /// <summary>
            /// 导航栏按钮类型
            /// </summary>
            public NavigationButtonTypes NavigationButtonType { get; }

            /// <summary>
            /// 当前选项卡左边出现的第一个选项索引
            /// </summary>
            public int CurrentFirstTabItemIndex { get; }

            /// <summary>
            /// 当前选项卡左边出现的第一个选项要切换到的索引
            /// </summary>
            public int TargetFirstTabItemIndex { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="navigationButtonType">导航栏按钮类型</param>
            /// <param name="currentFirstTabItemIndex">当前选项卡左边出现的第一个选项的索引</param>
            /// <param name="targetFirstTabItemIndex">当前选项卡左边出现的第一个选项要切换到的索引</param>
            /// <param name="cancel">是否取消操作</param>
            public NavigationButtonOperatingEventArgs(NavigationButtonTypes navigationButtonType, int currentFirstTabItemIndex, int targetFirstTabItemIndex, bool cancel)
            {
                this.NavigationButtonType = navigationButtonType;
                this.CurrentFirstTabItemIndex = currentFirstTabItemIndex;
                this.TargetFirstTabItemIndex = targetFirstTabItemIndex;
                this.Cancel = cancel;
            }

        }

        /// <summary>
        /// 导航栏按钮操作后事件参数
        /// </summary>
        public class NavigationButtonOperatedEventArgs : EventArgs
        {
            /// <summary>
            /// 导航栏按钮类型
            /// </summary>
            public NavigationButtonTypes NavigationButtonType { get; }

            /// <summary>
            /// 当前选项卡左边出现的第一个选项索引
            /// </summary>
            public int CurrentFirstTabItemIndex { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="currentFirstTabItemIndex">当前选项卡左边出现的第一个选项索引</param>
            public NavigationButtonOperatedEventArgs(int currentFirstTabItemIndex)
            {
                this.CurrentFirstTabItemIndex = currentFirstTabItemIndex;
            }

        }

        #endregion

        #region TabItem选项

        /// <summary>
        /// TabItem操作时事件参数
        /// </summary>
        public class TabItemOperatingEventArgs : CancelEventArgs
        {
            /// <summary>
            /// TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">TabPage</param>
            public TabItemOperatingEventArgs(TabPagePlusExt tabPage)
            {
                this.TabPage = tabPage;
            }

        }

        /// <summary>
        /// TabItem操作后事件参数
        /// </summary>
        public class TabItemOperatedEventArgs : EventArgs
        {
            /// <summary>
            /// TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">TabPage</param>
            public TabItemOperatedEventArgs(TabPagePlusExt tabPage)
            {
                this.TabPage = tabPage;
            }

        }

        /// <summary>
        /// 两个TabItem位置互换时事件参数
        /// </summary>
        public class TabItemInterchangeingEventArgs : CancelEventArgs
        {
            /// <summary>
            /// 当前要移动的TabPage
            /// </summary>
            public TabPagePlusExt CurrentTabPage { get; }

            /// <summary>
            /// 当前要移动的目标TabPage
            /// </summary>
            public TabPagePlusExt TargetTabPage { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="currentTabPage">当前要移动的TabPage</param>
            /// <param name="targetTabPage">当前要移动的目标TabPage</param>
            public TabItemInterchangeingEventArgs(TabPagePlusExt currentTabPage, TabPagePlusExt targetTabPage)
            {
                this.CurrentTabPage = currentTabPage;
                this.TargetTabPage = targetTabPage;
            }

        }

        /// <summary>
        /// 两个TabItem位置互换后事件参数
        /// </summary>
        public class TabItemInterchangedEventArgs : EventArgs
        {
            /// <summary>
            /// 当前要移动的TabPage
            /// </summary>
            public TabPagePlusExt CurrentTabPage { get; }

            /// <summary>
            /// 当前要移动的目标TabPage
            /// </summary>
            public TabPagePlusExt TargetTabPage { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="currentTabPage">当前要移动的TabPage</param>
            /// <param name="targetTabPage">当前要移动的目标TabPage</param>
            public TabItemInterchangedEventArgs(TabPagePlusExt currentTabPage, TabPagePlusExt targetTabPage)
            {
                this.CurrentTabPage = currentTabPage;
                this.TargetTabPage = targetTabPage;
            }

        }

        /// <summary>
        /// TabItem背景绘制后事件参数
        /// </summary>
        public class TabItemDrawBackgroundAfterEventArgs : EventArgs
        {
            /// <summary>
            /// TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 封装一个 GDI+ 绘图图面（可绘制区域为:ClipPaddingBounds）
            /// </summary>
            public Graphics Graphics { get; set; }

            /// <summary>
            /// 允许显示所有选项的总区域Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ItemsClipContentBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（排除非剪辑区）（只包含:内边距、内容）
            /// </summary>
            public RectangleF ClipPaddingBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（包含:外边距、内边距、内容）
            /// </summary>
            public RectangleF NoClipMarginBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（包含:内边距、内容）
            /// </summary>
            public RectangleF NoClipPaddingBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">TabPage</param>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="graphics">封装一个 GDI+ 绘图图面（可绘制区域为:ClipPaddingBounds）</param>
            /// <param name="itemsClipContentBounds">允许显示所有选项的总区域Rectangle（排除非剪辑区）（只包含:内容）</param>
            /// <param name="clipPaddingBounds">当前选项Rectangle（排除非剪辑区）（只包含:内边距、内容）</param>
            /// <param name="noClipMarginBounds">当前选项Rectangle（包含非剪辑区）（包含:外边距、内边距、内容）</param>
            /// <param name="noClipPaddingBounds">当前选项Rectangle（包含非剪辑区）（包含:内边距、内容）</param>
            /// <param name="noClipContentBounds">当前选项Rectangle（包含非剪辑区）（只包含:内容）</param>
            public TabItemDrawBackgroundAfterEventArgs(TabPagePlusExt tabPage, DotsPerInch dPIScale, Graphics graphics, RectangleF itemsClipContentBounds, RectangleF clipPaddingBounds, RectangleF noClipMarginBounds, RectangleF noClipPaddingBounds, RectangleF noClipContentBounds)
            {
                this.TabPage = tabPage;
                this.DPIScale = dPIScale;
                this.Graphics = graphics;
                this.ItemsClipContentBounds = itemsClipContentBounds;
                this.ClipPaddingBounds = clipPaddingBounds;
                this.NoClipMarginBounds = noClipMarginBounds;
                this.NoClipPaddingBounds = noClipPaddingBounds;
                this.NoClipContentBounds = noClipContentBounds;
            }

        }

        /// <summary>
        /// TabItem生成选项自定义路径前事件参数
        /// </summary>
        public class TabItemCreateCustomPathBeforeEventArgs : EventArgs
        {
            /// <summary>
            /// TabPage
            /// </summary>
            public TabPagePlusExt TabPage { get; }

            /// <summary>
            /// 系统缩放比例
            /// </summary>
            public DotsPerInch DPIScale { get; }

            /// <summary>
            /// 允许显示所有选项的总区域Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ItemsClipContentBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（排除非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF ClipContentBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（包含:外边距、内边距、内容）
            /// </summary>
            public RectangleF NoClipMarginBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（包含:内边距、内容）
            /// </summary>
            public RectangleF NoClipPaddingBounds { get; }

            /// <summary>
            /// 当前选项Rectangle（包含非剪辑区）（只包含:内容）
            /// </summary>
            public RectangleF NoClipContentBounds { get; }

            /// <summary>
            /// 当前选项生成形状GraphicsPath路径(一般用选项的NoClipPaddingBounds范围生成)
            /// </summary>
            public GraphicsPath GraphicsPath { get; set; }

            /// <summary>
            /// 当前选项生成自定义路径是否处理完毕(True 将会跳过控件的默认生成)
            /// </summary>
            public bool Finish { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tabPage">TabPage</param>
            /// <param name="dPIScale">系统缩放比例</param>
            /// <param name="itemsClipContentBounds">允许显示所有选项的总区域Rectangle（排除非剪辑区）（只包含:内容）</param>
            /// <param name="clipContentBounds">当前选项Rectangle（排除非剪辑区）（只包含:内容）</param>
            /// <param name="noClipMarginBounds">当前选项Rectangle（包含非剪辑区）（包含:外边距、内边距、内容）</param>
            /// <param name="noClipPaddingBounds">当前选项Rectangle（包含非剪辑区）（包含:内边距、内容）</param>
            /// <param name="noClipContentBounds">当前选项Rectangle（包含非剪辑区）（只包含:内容）</param>
            /// <param name="finish">当前选项生成自定义路径是否处理完毕(True 将会跳过控件的默认生成)</param>
            public TabItemCreateCustomPathBeforeEventArgs(TabPagePlusExt tabPage, DotsPerInch dPIScale, RectangleF itemsClipContentBounds, RectangleF clipContentBounds, RectangleF noClipMarginBounds, RectangleF noClipPaddingBounds, RectangleF noClipContentBounds, bool finish)
            {
                this.TabPage = tabPage;
                this.DPIScale = dPIScale;
                this.ItemsClipContentBounds = itemsClipContentBounds;
                this.ClipContentBounds = clipContentBounds;
                this.NoClipMarginBounds = noClipMarginBounds;
                this.NoClipPaddingBounds = noClipPaddingBounds;
                this.NoClipContentBounds = noClipContentBounds;
                this.Finish = finish;
            }

        }

        #endregion

        #endregion
    }

    /// <summary>
    /// TabControlPlusDropDownPanelExt(下拉面板)
    /// </summary>
    [ToolboxItem(false)]
    public class TabControlPlusDropDownPanelExt : Control
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

        /// <summary>
        /// 列表区域Rect
        /// </summary>
        private Rectangle mainRect = Rectangle.Empty;
        /// <summary>
        /// 真实列表区域Rect
        /// </summary>
        private Rectangle mainRealityRect = Rectangle.Empty;

        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        private bool ismovedown = false;
        /// <summary>
        /// 鼠标按下的坐标
        /// </summary>
        private Point movedownpoint = Point.Empty;
        /// <summary>
        /// 鼠标按下信息
        /// </summary>
        private MouseDownClass mousedowninfo = new MouseDownClass();

        /// <summary>
        /// 所属控件
        /// </summary>
        private TabControlPlusExt tcuge = null;

        /// <summary>
        /// 代表滚动条对象
        /// </summary>
        private readonly object scrollObject = new object();

        #endregion

        public TabControlPlusDropDownPanelExt(TabControlPlusExt tcuge)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, false);

            this.tcuge = tcuge;
            this.BackColor = Color.Transparent;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int scale_scrollThickness = (int)(this.tcuge.DropDownPanel.ScrollBarThickness * DotsPerInchHelper.DPIScale.XScale);
            int ico_padding = (int)(4 * DotsPerInchHelper.DPIScale.XScale);

            #region 边框

            if (this.tcuge.DropDownPanel.BorderThickness > 0)
            {
                Pen border_pen = new Pen(this.tcuge.DropDownPanel.BorderColor, this.tcuge.DropDownPanel.BorderThickness);
                border_pen.Alignment = PenAlignment.Inset;
                int border = this.tcuge.DropDownPanel.BorderThickness == 1 ? -1 : 0;
                g.DrawRectangle(border_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, (int)(this.ClientRectangle.Width + border), this.ClientRectangle.Height + border));
                border_pen.Dispose();
            }

            #endregion

            #region 背景

            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.mainRect);
            back_sb.Dispose();

            #endregion

            Region client_region = null;
            Region main_region = null;
            if (this.tcuge.DropDownPanel.BorderThickness > 0)
            {
                client_region = g.Clip.Clone();
                main_region = new Region(this.mainRect);
                g.Clip = main_region;
            }

            #region 选项

            #region 颜色

            Pen item_splitter_pen = null;
            LinearGradientBrush item_splitter_lgb = null;
            if (this.tcuge.DropDownPanel.ItemSplitterStyle == TabControlPlusExt.DropDownItemSplitterStyles.Line)
            {
                item_splitter_pen = new Pen(this.tcuge.DropDownPanel.ItemSplitterColor, 1);
            }
            else if (this.tcuge.DropDownPanel.ItemSplitterStyle == TabControlPlusExt.DropDownItemSplitterStyles.GradualLine)
            {
                item_splitter_lgb = new LinearGradientBrush(new PointF(this.mainRect.X, this.mainRect.Y), new PointF(this.mainRect.Right, this.mainRect.Y), Color.Transparent, Color.Transparent);
                ColorBlend itemborder_cb = new ColorBlend();
                itemborder_cb.Colors = new Color[] { Color.Transparent, this.tcuge.DropDownPanel.ItemSplitterColor, this.tcuge.DropDownPanel.ItemSplitterColor, Color.Transparent };
                itemborder_cb.Positions = new float[] { 0.0f, 0.23f, 0.70f, 1.0f };
                item_splitter_lgb.InterpolationColors = itemborder_cb;
                item_splitter_pen = new Pen(item_splitter_lgb, 1);
            }

            SolidBrush item_normal_back_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemBackNormalColor);
            SolidBrush item_enter_back_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemBackEnterColor);
            SolidBrush item_disable_back_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemBackDisableColor);

            SolidBrush item_normal_text_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemTextNormalColor);
            SolidBrush item_enter_text_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemTextEnterColor);
            SolidBrush item_disable_text_sb = new SolidBrush(this.tcuge.DropDownPanel.ItemTextDisableColor);

            #endregion

            for (int i = 0; i < this.tcuge.TabPages.Count; i++)
            {
                TabPagePlusExt tab_page = this.tcuge.TabPages[i];
                if (tab_page.DropDownPanelItem_Rect.Bottom >= this.mainRect.Y && tab_page.DropDownPanelItem_Rect.Y <= this.mainRect.Bottom)
                {
                    SolidBrush commom_back_sb = null;
                    SolidBrush commom_text_sb = null;
                    if (tab_page.TabItemEnabled == false)
                    {
                        commom_back_sb = item_disable_back_sb;
                        commom_text_sb = item_disable_text_sb;
                    }
                    else if (tab_page.DropDownPanelItem_MouseStatus == TabPagePlusExt.DropDownPanelItemMouseStatuss.Enter)
                    {
                        commom_back_sb = item_enter_back_sb;
                        commom_text_sb = item_enter_text_sb;
                    }
                    else
                    {
                        commom_back_sb = item_normal_back_sb;
                        commom_text_sb = item_normal_text_sb;
                    }

                    #region 选项背景
                    g.FillRectangle(commom_back_sb, tab_page.DropDownPanelItem_Rect);
                    #endregion

                    #region 选项图标
                    if (this.tcuge.DropDownPanel.IcoVisible)
                    {
                        Image ico_image = tab_page.TabItemEnabled ? tab_page.TabItemIcoImage : tab_page.TabItemIcoImageDisable;
                        if (ico_image == null)
                        {
                            ico_image = Resources.tabcontrol_item_default_ico;
                        }
                        RectangleF ico_rect = new RectangleF(tab_page.DropDownPanelItem_Rect.X + ico_padding, tab_page.DropDownPanelItem_Rect.Y + ico_padding, tab_page.DropDownPanelItem_Rect.Height - ico_padding * 2, tab_page.DropDownPanelItem_Rect.Height - ico_padding * 2);
                        g.DrawImage(ico_image, ico_rect, new RectangleF(0, 0, ico_image.Width, ico_image.Height), GraphicsUnit.Pixel);
                    }
                    #endregion

                    #region 选项文本

                    RectangleF text_rect = RectangleF.Empty;
                    if (this.tcuge.DropDownPanel.IcoVisible)
                    {
                        text_rect = new RectangleF(tab_page.DropDownPanelItem_Rect.Height, tab_page.DropDownPanelItem_Rect.Y + (tab_page.DropDownPanelItem_Rect.Height - tab_page.Text_DropDown_Size.Height) / 2f, tab_page.Text_DropDown_Size.Width, tab_page.Text_DropDown_Size.Height);
                    }
                    else
                    {
                        text_rect = new RectangleF(tab_page.DropDownPanelItem_Rect.X, tab_page.DropDownPanelItem_Rect.Y + (tab_page.DropDownPanelItem_Rect.Height - tab_page.Text_DropDown_Size.Height) / 2f, tab_page.Text_DropDown_Size.Width, tab_page.Text_DropDown_Size.Height);
                    }
                    g.DrawString(tab_page.Text, this.tcuge.DropDownPanel.ItemFont, commom_text_sb, text_rect);

                    #endregion

                    #region 选项分割线
                    if (this.tcuge.DropDownPanel.ItemSplitterStyle != TabControlPlusExt.DropDownItemSplitterStyles.None)
                    {
                        g.DrawLine(item_splitter_pen, tab_page.DropDownPanelItem_Rect.X, tab_page.DropDownPanelItem_Rect.Bottom - 1, tab_page.DropDownPanelItem_Rect.Right, tab_page.DropDownPanelItem_Rect.Bottom - 1);
                    }
                    #endregion

                }
            }

            #region 释放全局画笔

            if (item_splitter_pen != null)
                item_splitter_pen.Dispose();

            if (item_splitter_lgb != null)
                item_splitter_lgb.Dispose();

            if (item_normal_back_sb != null)
                item_normal_back_sb.Dispose();
            if (item_enter_back_sb != null)
                item_enter_back_sb.Dispose();
            if (item_disable_back_sb != null)
                item_disable_back_sb.Dispose();

            if (item_normal_text_sb != null)
                item_normal_text_sb.Dispose();
            if (item_enter_text_sb != null)
                item_enter_text_sb.Dispose();
            if (item_disable_text_sb != null)
                item_disable_text_sb.Dispose();

            #endregion

            #endregion

            #region 滚动条
            if (this.mainRealityRect.Height > this.mainRect.Height)
            {
                #region 画笔
                SolidBrush bar_back_sb = null;
                Pen slide_back_pen = null;

                if (this.Enabled)
                {
                    bar_back_sb = new SolidBrush(this.tcuge.DropDownPanel.ScrollBarBackNormalColor);
                    slide_back_pen = new Pen(this.tcuge.DropDownPanel.ScrollSlide_MouseStatus == TabControlPlusExt.ScrollSlideMoveStatus.Normal ? this.tcuge.DropDownPanel.ScrollSlideBackNormalColor : this.tcuge.DropDownPanel.ScrollSlideBackEnterColor, scale_scrollThickness);
                }
                else
                {
                    bar_back_sb = new SolidBrush(this.tcuge.DropDownPanel.ScrollBarBackDisableColor);
                    slide_back_pen = new Pen(this.tcuge.DropDownPanel.ScrollSlideBackDisableColor, scale_scrollThickness);
                }

                #endregion

                #region 滑条
                g.FillRectangle(bar_back_sb, this.tcuge.DropDownPanel.ScrollBar_Rect);
                #endregion

                #region  滑块
                PointF sp_start = new PointF(this.tcuge.DropDownPanel.ScrollSlide_Rect.X + scale_scrollThickness / 2, this.tcuge.DropDownPanel.ScrollSlide_Rect.Y);
                PointF sp_end = new PointF(this.tcuge.DropDownPanel.ScrollSlide_Rect.X + scale_scrollThickness / 2, this.tcuge.DropDownPanel.ScrollSlide_Rect.Bottom);

                g.DrawLine(slide_back_pen, sp_start, sp_end);
                #endregion

                #region 释放画笔

                if (bar_back_sb != null)
                    bar_back_sb.Dispose();
                if (slide_back_pen != null)
                    slide_back_pen.Dispose();

                #endregion
            }
            #endregion

            if (main_region != null)
            {
                g.Clip = client_region;
                main_region.Dispose();
                client_region.Dispose();
            }

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (this.ResetItemsMouseStatus())
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (this.ResetItemsMouseStatus())
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                this.ismovedown = true;
                this.movedownpoint = e.Location;

                if (this.tcuge.DropDownPanel.ScrollBar_Rect.Contains(e.Location))
                {
                    if (this.tcuge.DropDownPanel.ScrollSlide_Rect.Contains(e.Location))
                    {
                        this.mousedowninfo.Type = MouseDownTypes.Scroll;
                        this.mousedowninfo.Sender = this.scrollObject;
                    }
                    else
                    {
                        this.mousedowninfo.Type = MouseDownTypes.Scroll;
                        this.mousedowninfo.Sender = null;
                    }
                }
                else if (this.mainRect.Contains(e.Location))
                {
                    TabPagePlusExt item = this.FindMouseDownItem(e.Location);
                    if (item != null)
                    {
                        this.mousedowninfo.Type = MouseDownTypes.Item;
                        this.mousedowninfo.Sender = item;
                    }
                    else
                    {
                        this.mousedowninfo.Type = MouseDownTypes.None;
                        this.mousedowninfo.Sender = null;
                    }
                }
                else
                {
                    this.mousedowninfo.Type = MouseDownTypes.None;
                    this.mousedowninfo.Sender = null;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.tcuge.DropDownPanel.ScrollBar_Rect.Contains(e.Location) == false && this.mousedowninfo.Type == MouseDownTypes.Item)
                {
                    TabPagePlusExt tab_page = this.FindMouseDownItem(e.Location);
                    int index = this.tcuge.FindTabPage(tab_page);
                    if (tab_page != null && index > -1 && tab_page == this.mousedowninfo.Sender)
                    {
                        if (tab_page.TabItemEnabled || this.tcuge.TabItemDisableActivation)
                        {
                            this.tcuge.SelectedIndex = index;
                            this.tcuge.HideDropDownPanel();
                        }
                    }
                }

                this.ResetMouseDownStatus();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (this.ismovedown)
            {
                if (this.mousedowninfo.Type == MouseDownTypes.Scroll)
                {
                    if (this.mousedowninfo.Sender == this.scrollObject)
                    {
                        int offset = (int)((e.Location.Y - this.movedownpoint.Y));
                        this.movedownpoint = e.Location;
                        this.MouseMoveWheel(offset);
                    }
                }
            }
            else
            {
                this.UpdateItemsMouseStatus(e.Location);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode || this.tcuge == null)
                return;

            if (this.mainRealityRect.Height > this.mainRect.Height)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                offset = (int)Math.Ceiling(offset * DotsPerInchHelper.DPIScale.XScale * this.tcuge.DropDownPanel.ScrollWheelSpeed);
                this.MouseMoveWheel(offset);
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
        /// 初始化控件Rect
        /// </summary>
        internal void InitializeRectangle()
        {
            this.InitializeMainRectangle();
            this.InitializeMainRealityRectangle();
            this.InitializeScrollRectangle();
            this.UpdateItemsRect();
        }

        /// <summary>
        /// 初始化列表区域Rect
        /// </summary>
        private void InitializeMainRectangle()
        {
            this.mainRect = new Rectangle(this.ClientRectangle.X + this.tcuge.DropDownPanel.BorderThickness, this.ClientRectangle.Top + this.tcuge.DropDownPanel.BorderThickness, this.ClientRectangle.Width - this.tcuge.DropDownPanel.BorderThickness * 2, this.ClientRectangle.Height - this.tcuge.DropDownPanel.BorderThickness * 2);
        }

        /// <summary>
        /// 初始化真实列表区域Rect
        /// </summary>
        private void InitializeMainRealityRectangle()
        {
            int scale_itemHeight = (int)(this.tcuge.DropDownPanel.ItemHeight * DotsPerInchHelper.DPIScale.XScale);

            this.mainRealityRect = new Rectangle(this.mainRect.X, this.mainRect.Y, this.mainRect.Width, 0);

            int y = this.mainRealityRect.Y;
            if (this.mainRealityRect.Bottom < this.mainRect.Bottom)
            {
                y += (this.mainRect.Bottom - this.mainRealityRect.Bottom);
            }
            if (y > this.mainRect.Y)
            {
                y = this.mainRect.Y;
            }
            this.mainRealityRect = new Rectangle(this.mainRealityRect.X, y, this.mainRealityRect.Width, this.mainRealityRect.Height);

            int h = 0;
            for (int i = 0; i < this.tcuge.TabPages.Count; i++)
            {
                h += scale_itemHeight;
                this.tcuge.TabPages[i].DropDownPanelItem_Rect = new RectangleF(this.mainRect.Left, this.mainRect.Top + i * scale_itemHeight, this.mainRect.Width, scale_itemHeight);
            }
            this.mainRealityRect = new Rectangle(this.mainRealityRect.X, this.mainRealityRect.Y, this.mainRealityRect.Width, h);

            this.UpdateScrollSlideRectLocation();
        }

        /// <summary>
        /// 初始化滚动条Rect
        /// </summary>
        private void InitializeScrollRectangle()
        {
            int scale_scrollBarThickness = (int)(this.tcuge.DropDownPanel.ScrollBarThickness * DotsPerInchHelper.DPIScale.XScale);

            this.tcuge.DropDownPanel.ScrollBar_Rect = new Rectangle((int)this.mainRect.Right - scale_scrollBarThickness, this.mainRect.Top, scale_scrollBarThickness, this.mainRect.Height);
            float proportion = (float)this.mainRect.Height / (float)this.mainRealityRect.Height;
            if (proportion > 1)
            {
                proportion = 1;
            }
            float slide_height = this.tcuge.DropDownPanel.ScrollBar_Rect.Height * proportion;
            if (slide_height < this.tcuge.DropDownPanel.ScrollSlideMinHeight)
            {
                slide_height = this.tcuge.DropDownPanel.ScrollSlideMinHeight;
            }
            this.tcuge.DropDownPanel.ScrollSlide_Rect = new RectangleF(this.tcuge.DropDownPanel.ScrollBar_Rect.X, this.tcuge.DropDownPanel.ScrollBar_Rect.Y, scale_scrollBarThickness, slide_height);
        }

        /// <summary>
        /// 更新所有选项的鼠标状态
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        private void UpdateItemsMouseStatus(Point mousePoint)
        {
            bool result = false;
            bool isInMainRect = this.mainRect.Contains(mousePoint) && !this.tcuge.DropDownPanel.ScrollBar_Rect.Contains(mousePoint);
            foreach (TabPagePlusExt tab_page in this.tcuge.TabPages)
            {
                if (tab_page.TabItemEnabled)
                {
                    if (isInMainRect && tab_page.DropDownPanelItem_Rect.Contains(mousePoint))
                    {
                        if (tab_page.DropDownPanelItem_MouseStatus == TabPagePlusExt.DropDownPanelItemMouseStatuss.Normal)
                        {
                            tab_page.DropDownPanelItem_MouseStatus = TabPagePlusExt.DropDownPanelItemMouseStatuss.Enter;
                            result = true;
                        }
                    }
                    else
                    {
                        if (tab_page.DropDownPanelItem_MouseStatus == TabPagePlusExt.DropDownPanelItemMouseStatuss.Enter)
                        {
                            tab_page.DropDownPanelItem_MouseStatus = TabPagePlusExt.DropDownPanelItemMouseStatuss.Normal;
                            result = true;
                        }
                    }
                }
            }

            if (result)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 重置所有选项鼠标状态
        /// </summary>
        /// <returns>返回是否需要重绘</returns>
        private bool ResetItemsMouseStatus()
        {
            bool result = false;
            foreach (TabPagePlusExt tab_page in this.tcuge.TabPages)
            {
                if (tab_page.DropDownPanelItem_MouseStatus != TabPagePlusExt.DropDownPanelItemMouseStatuss.Normal)
                {
                    tab_page.DropDownPanelItem_MouseStatus = TabPagePlusExt.DropDownPanelItemMouseStatuss.Normal;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 重置鼠标按下状态信息
        /// </summary>
        internal void ResetMouseDownStatus()
        {
            this.ismovedown = false;
            this.movedownpoint = Point.Empty;
            this.mousedowninfo.Type = MouseDownTypes.None;
            this.mousedowninfo.Sender = null;
        }

        /// <summary>
        /// 更新滑块的RectLocation
        /// </summary>
        private void UpdateScrollSlideRectLocation()
        {
            float slide_height = this.tcuge.DropDownPanel.ScrollBar_Rect.Height * ((float)this.mainRect.Height / ((float)this.mainRealityRect.Height));
            if (slide_height < this.tcuge.DropDownPanel.ScrollSlideMinHeight)
            {
                slide_height = this.tcuge.DropDownPanel.ScrollSlideMinHeight;
            }
            float h = this.mainRect.Y - this.mainRealityRect.Y;
            if (this.mainRealityRect.Y < 0)
            {
                h = this.mainRect.Y + Math.Abs(this.mainRealityRect.Y);
            }
            float slide_y = this.tcuge.DropDownPanel.ScrollBar_Rect.Y + (this.tcuge.DropDownPanel.ScrollBar_Rect.Height - slide_height) * h / (float)(this.mainRealityRect.Height - this.mainRect.Height);

            this.tcuge.DropDownPanel.ScrollSlide_Rect = new RectangleF(this.tcuge.DropDownPanel.ScrollBar_Rect.X, slide_y, this.tcuge.DropDownPanel.ScrollSlide_Rect.Width, slide_height);

        }

        /// <summary>
        /// 更新所有选项Rect
        /// </summary>
        private void UpdateItemsRect()
        {
            int scale_itemHeight = (int)(this.tcuge.DropDownPanel.ItemHeight * DotsPerInchHelper.DPIScale.XScale);

            for (int i = 0; i < this.tcuge.TabPages.Count; i++)
            {
                this.tcuge.TabPages[i].DropDownPanelItem_Rect = new RectangleF(this.mainRect.Left, this.mainRealityRect.Top + i * scale_itemHeight, this.mainRect.Width, scale_itemHeight);
            }
        }

        /// <summary>
        /// 根据坐标查找被按下的选项
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        /// <returns>没有为null</returns>
        private TabPagePlusExt FindMouseDownItem(Point mousePoint)
        {
            foreach (TabPagePlusExt tab_page in this.tcuge.TabPages)
            {
                if (tab_page.DropDownPanelItem_Rect.Contains(mousePoint))
                {
                    return tab_page;
                }
            }
            return null;
        }

        /// <summary>
        /// 滚动条移动或鼠标滚轮移动
        /// </summary>
        /// <param name="offset"></param>
        private void MouseMoveWheel(int offset)
        {
            float y = this.tcuge.DropDownPanel.ScrollSlide_Rect.Y;
            y += offset;
            if (y < this.tcuge.DropDownPanel.ScrollBar_Rect.Y)
            {
                y = this.tcuge.DropDownPanel.ScrollBar_Rect.Y;
            }
            if (y > this.tcuge.DropDownPanel.ScrollBar_Rect.Bottom - this.tcuge.DropDownPanel.ScrollSlide_Rect.Height)
            {
                y = this.tcuge.DropDownPanel.ScrollBar_Rect.Bottom - this.tcuge.DropDownPanel.ScrollSlide_Rect.Height;
            }

            this.tcuge.DropDownPanel.ScrollSlide_Rect = new RectangleF(this.tcuge.DropDownPanel.ScrollSlide_Rect.Location.X, y, this.tcuge.DropDownPanel.ScrollSlide_Rect.Width, this.tcuge.DropDownPanel.ScrollSlide_Rect.Height);

            float proportion = (float)(this.tcuge.DropDownPanel.ScrollSlide_Rect.Y - this.tcuge.DropDownPanel.ScrollBar_Rect.Y) / (float)(this.tcuge.DropDownPanel.ScrollBar_Rect.Height - this.tcuge.DropDownPanel.ScrollSlide_Rect.Height);

            float scroll_height = this.mainRealityRect.Height - this.mainRect.Height < 0 ? 0 : (this.mainRealityRect.Height - this.mainRect.Height);
            this.mainRealityRect.Y = (int)(this.mainRect.Y - scroll_height * proportion);

            this.UpdateItemsRect();
            this.Invalidate();
        }

        #endregion

        #region 类

        /// <summary>
        /// 鼠标按下功能类型
        /// </summary>
        internal class MouseDownClass
        {
            /// <summary>
            /// 鼠标按下类型
            /// </summary>
            public MouseDownTypes Type { get; set; }
            /// <summary>
            /// 鼠标按下功能对象
            /// </summary>
            public object Sender { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鼠标按下类型
        /// </summary>
        internal enum MouseDownTypes
        {
            /// <summary>
            /// 空
            /// </summary>
            None,
            /// <summary>
            /// 选项按下
            /// </summary>
            Item,
            /// <summary>
            /// 滚动条按下
            /// </summary>
            Scroll
        }

        #endregion
    }
}
