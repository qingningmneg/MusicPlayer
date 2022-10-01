
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 不规则形状按钮
    /// </summary>
    [Description("不规则形状按钮")]
    [DefaultProperty("ShapeEditorEnable")]
    [DefaultEvent("CheckedChanged")]
    [ToolboxItem(true)]
    [Designer(typeof(AnomalyButtonDesigner))]
    public class AnomalyButton : Control
    {
        #region 新增事件

        private event EventHandler checkedChanged;
        /// <summary>
        /// 按钮选中状态更改事件
        /// </summary>
        [Description("按钮选中状态更改事件")]
        public event EventHandler CheckedChanged
        {
            add { this.checkedChanged += value; }
            remove { this.checkedChanged -= value; }
        }

        #endregion

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

        /// <summary>
        /// 自定义形状布局调整： 1.单击 四周按钮停靠路径位置。 2. 拖动 中间按钮修改路径位置。
        /// </summary>
        [Description("自定义形状布局调整： 1.单击 四周按钮停靠路径位置。 2. 拖动 中间按钮修改路径位置。")]
        [DefaultValue(null)]
        [Editor(typeof(AnomalyButtonShapePointsAnchorEditor), typeof(UITypeEditor))]
        public object ShapeAnchor
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        private ShapeStyles shapeStyle = ShapeStyles.Bezier;
        /// <summary>
        /// 自定义形状路径风格
        /// </summary>
        [Description("自定义形状路径风格")]
        [DefaultValue(ShapeStyles.Bezier)]
        public ShapeStyles ShapeStyle
        {
            get { return this.shapeStyle; }
            set
            {
                if (this.shapeStyle == value)
                    return;

                this.shapeStyle = value;
                this.Invalidate();
            }
        }

        private string shapePoints = "{20,20}{130,20}{130,130}{20,130}";
        /// <summary>
        /// 自定义形状坐标
        /// </summary>
        [Description("自定义形状坐标")]
        [DefaultValue("")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(UITypeEditor))]
        public string ShapePoints
        {
            get { return this.shapePoints; }
            set
            {
                if (this.shapePoints == value)
                    return;

                this.shapePoints = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private bool checkEnable = false;
        /// <summary>
        /// 是否为开启checkbutton功能
        /// </summary>
        [Description("是否为开启checkbutton功能")]
        [DefaultValue(false)]
        public bool CheckEnable
        {
            get { return this.checkEnable; }
            set
            {
                if (this.checkEnable == value)
                    return;

                this.checkEnable = value;
                this.Invalidate();
            }
        }

        private bool _checked = false;
        /// <summary>
        /// 控件是否选中
        /// </summary>
        [DefaultValue(false)]
        [Description("控件是否选中")]
        public bool Checked
        {
            get { return this._checked; }
            set
            {
                if (this._checked == value)
                    return;

                this._checked = value;
                this.Invalidate();
            }
        }

        #region 背景颜色

        private Color backNormalColor = Color.FromArgb(189, 208, 188);
        /// <summary>
        /// 背景颜色(正常)
        /// </summary>
        [Description("背景颜色(正常)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "189, 208, 188")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
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

        private Color backDisabledColor = Color.FromArgb(225, 225, 225);
        /// <summary>
        /// 背景颜色(禁用)
        /// </summary>
        [Description("背景颜色(禁用)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "225, 225, 225")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDisabledColor
        {
            get { return this.backDisabledColor; }
            set
            {
                if (this.backDisabledColor == value)
                    return;

                this.backDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color backEnterColor = Color.FromArgb(230, 189, 208, 188);
        /// <summary>
        /// 背景颜色(鼠标进入)
        /// </summary>
        [Description("背景颜色(鼠标进入)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "230, 189, 208, 188")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
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

        private Color backDownColor = Color.FromArgb(200, 189, 208, 188);
        /// <summary>
        /// 背景颜色(鼠标按下)
        /// </summary>
        [Description("背景颜色(鼠标按下)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "200, 189, 208, 188")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDownColor
        {
            get { return this.backDownColor; }
            set
            {
                if (this.backDownColor == value)
                    return;

                this.backDownColor = value;
                this.Invalidate();
            }
        }

        private Color backNormalCheckedColor = Color.FromArgb(176, 197, 175);
        /// <summary>
        /// 背景颜色(选中状态正常)
        /// </summary>
        [Description("背景颜色(选中状态正常)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "176, 197, 175")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackNormalCheckedColor
        {
            get { return this.backNormalCheckedColor; }
            set
            {
                if (this.backNormalCheckedColor == value)
                    return;

                this.backNormalCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backDisabledCheckedColor = Color.FromArgb(168, 168, 168);
        /// <summary>
        /// 背景颜色(选中状态禁用)
        /// </summary>
        [Description("背景颜色(选中状态禁用)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "168, 168, 168")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDisabledCheckedColor
        {
            get { return this.backDisabledCheckedColor; }
            set
            {
                if (this.backDisabledCheckedColor == value)
                    return;

                this.backDisabledCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backEnterCheckedColor = Color.FromArgb(230, 176, 197, 175);
        /// <summary>
        /// 背景颜色(选中状态鼠标进入)
        /// </summary>
        [Description("背景颜色(选中状态鼠标进入)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "230, 176, 197, 175")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackEnterCheckedColor
        {
            get { return this.backEnterCheckedColor; }
            set
            {
                if (this.backEnterCheckedColor == value)
                    return;

                this.backEnterCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backDownCheckedColor = Color.FromArgb(200, 176, 197, 175);
        /// <summary>
        /// 背景颜色(选中状态鼠标按下)
        /// </summary>
        [Description("背景颜色(选中状态鼠标按下)")]
        [Category("杂项_背景色")]
        [DefaultValue(typeof(Color), "200, 176, 197, 175")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDownCheckedColor
        {
            get { return this.backDownCheckedColor; }
            set
            {
                if (this.backDownCheckedColor == value)
                    return;

                this.backDownCheckedColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 背景色渐变

        private bool gackGradualEnable = false;
        /// <summary>
        /// 背景色是否启用渐变
        /// </summary>
        [Description("背景色是否启用渐变")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(false)]
        public bool BackGradualEnable
        {
            get { return this.gackGradualEnable; }
            set
            {
                if (this.gackGradualEnable == value)
                    return;

                this.gackGradualEnable = value;
                this.Invalidate();
            }
        }

        private ComplexityPropertys.PointF backGradualPoint = new ComplexityPropertys.PointF(50, 40);
        /// <summary>
        /// 背景渐变颜色点坐标
        /// </summary>
        [Description("背景渐变颜色点坐标")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(ComplexityPropertys.PointF), "50, 40")]
        [Editor(typeof(AnomalyButtonRectangleCenterPointEditor), typeof(UITypeEditor))]
        public ComplexityPropertys.PointF BackGradualPoint
        {
            get { return this.backGradualPoint; }
            set
            {
                if (this.backGradualPoint == value)
                    return;

                this.backGradualPoint = value;
                this.Invalidate();
            }
        }

        private int backGradualRadius = 70;
        /// <summary>
        /// 背景渐变颜色半径
        /// </summary>
        [Description("背景渐变颜色半径")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(70)]
        [Editor(typeof(AnomalyButtonBackGradualRadiusPositionsEditor), typeof(UITypeEditor))]
        public int BackGradualRadius
        {
            get { return this.backGradualRadius; }
            set
            {
                if (this.backGradualRadius == value)
                    return;

                this.backGradualRadius = value;
                this.Invalidate();
            }
        }

        private Color backNormalGradualColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(正常)
        /// </summary>
        [Description("背景渐变颜色(正常)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackNormalGradualColor
        {
            get { return this.backNormalGradualColor; }
            set
            {
                if (this.backNormalGradualColor == value)
                    return;

                this.backNormalGradualColor = value;
                this.Invalidate();
            }
        }

        private Color backDisabledGradualColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(禁用)
        /// </summary>
        [Description("背景渐变颜色(禁用)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDisabledGradualColor
        {
            get { return this.backDisabledGradualColor; }
            set
            {
                if (this.backDisabledGradualColor == value)
                    return;

                this.backDisabledGradualColor = value;
                this.Invalidate();
            }
        }

        private Color backEnterGradualColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(鼠标进入)
        /// </summary>
        [Description("背景渐变颜色(鼠标进入)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackEnterGradualColor
        {
            get { return this.backEnterGradualColor; }
            set
            {
                if (this.backEnterGradualColor == value)
                    return;

                this.backEnterGradualColor = value;
                this.Invalidate();
            }
        }

        private Color backDownGradualColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(鼠标按下)
        /// </summary>
        [Description("背景渐变颜色(鼠标按下)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDownGradualColor
        {
            get { return this.backDownGradualColor; }
            set
            {
                if (this.backDownGradualColor == value)
                    return;

                this.backDownGradualColor = value;
                this.Invalidate();
            }
        }

        private Color backNormalGradualCheckedColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(选中状态正常)
        /// </summary>
        [Description("背景渐变颜色(选中状态正常)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackNormalGradualCheckedColor
        {
            get { return this.backNormalGradualCheckedColor; }
            set
            {
                if (this.backNormalGradualCheckedColor == value)
                    return;

                this.backNormalGradualCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backDisabledGradualCheckedColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(选中状态禁用)
        /// </summary>
        [Description("背景渐变颜色(选中状态禁用)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDisabledGradualCheckedColor
        {
            get { return this.backDisabledGradualCheckedColor; }
            set
            {
                if (this.backDisabledGradualCheckedColor == value)
                    return;

                this.backDisabledGradualCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backEnterGradualCheckedColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(选中状态鼠标进入)
        /// </summary>
        [Description("背景渐变颜色(选中状态鼠标进入)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackEnterGradualCheckedColor
        {
            get { return this.backEnterGradualCheckedColor; }
            set
            {
                if (this.backEnterGradualCheckedColor == value)
                    return;

                this.backEnterGradualCheckedColor = value;
                this.Invalidate();
            }
        }

        private Color backDownGradualCheckedColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        /// 背景渐变颜色(选中状态鼠标按下)
        /// </summary>
        [Description("背景渐变颜色(选中状态鼠标按下)")]
        [Category("杂项_背景色渐变")]
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackDownGradualCheckedColor
        {
            get { return this.backDownGradualCheckedColor; }
            set
            {
                if (this.backDownGradualCheckedColor == value)
                    return;

                this.backDownGradualCheckedColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 文本

        private ComplexityPropertys.PointF textPoint = new ComplexityPropertys.PointF(75, 75);
        /// <summary>
        /// 文本坐标
        /// </summary>
        [Description("文本坐标")]
        [Category("杂项_文本")]
        [DefaultValue(typeof(ComplexityPropertys.PointF), "75, 75")]
        [Editor(typeof(AnomalyButtonTextCenterPointEditor), typeof(UITypeEditor))]
        public ComplexityPropertys.PointF TextPoint
        {
            get { return this.textPoint; }
            set
            {
                if (this.textPoint == value)
                    return;

                this.textPoint = value;
                this.Invalidate();
            }
        }

        private Color textNormalColor = Color.FromArgb(122, 122, 122);
        /// <summary>
        /// 文本颜色(正常)
        /// </summary>
        [Description("文本颜色(正常)")]
        [Category("杂项_文本")]
        [DefaultValue(typeof(Color), "122, 122, 122")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TextNormalColor
        {
            get { return this.textNormalColor; }
            set
            {
                if (this.textNormalColor == value)
                    return;

                this.textNormalColor = value;
                this.Invalidate();
            }
        }

        private Color textDisabledColor = Color.FromArgb(122, 122, 122);
        /// <summary>
        /// 文本颜色(禁用)
        /// </summary>
        [Description("文本颜色(禁用)")]
        [Category("杂项_文本")]
        [DefaultValue(typeof(Color), "122, 122, 122")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TextDisabledColor
        {
            get { return this.textDisabledColor; }
            set
            {
                if (this.textDisabledColor == value)
                    return;

                this.textDisabledColor = value;
                this.Invalidate();
            }
        }

        private Color textCheckedColor = Color.FromArgb(122, 122, 122);
        /// <summary>
        /// 文本颜色(选中)
        /// </summary>
        [Description("文本颜色(选中)")]
        [Category("杂项_文本")]
        [DefaultValue(typeof(Color), "122, 122, 122")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TextCheckedColor
        {
            get { return this.textCheckedColor; }
            set
            {
                if (this.textCheckedColor == value)
                    return;

                this.textCheckedColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 编辑功能

        private bool shapeEditorEnable = true;
        /// <summary>
        /// 启用自定义形状编辑功能
        /// </summary>
        [Description("启用自定义形状编辑功能")]
        [Category("杂项_编辑功能")]
        [DefaultValue(true)]
        public bool ShapeEditorEnable
        {
            get { return this.shapeEditorEnable; }
            set
            {
                if (this.shapeEditorEnable == value)
                    return;

                this.shapeEditorEnable = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int shapePathPointRadius = 5;
        /// <summary>
        /// 自定义形状编辑点半径
        /// </summary>
        [Description("自定义形状编辑点半径")]
        [Category("杂项_编辑功能")]
        [DefaultValue(5)]
        public int ShapePathPointRadius
        {
            get
            {
                return this.shapePathPointRadius;
            }
            set
            {
                if (this.shapePathPointRadius == value || value <= 0)
                    return;

                this.shapePathPointRadius = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private bool shapePathPointTipEnable = true;
        /// <summary>
        /// 启用自定义形状编辑点提示
        /// </summary>
        [Description("启用自定义形状编辑点提示")]
        [Category("杂项_编辑功能")]
        [DefaultValue(true)]
        public bool ShapePathPointTipEnable
        {
            get { return this.shapePathPointTipEnable; }
            set
            {
                if (this.shapePathPointTipEnable == value)
                    return;

                this.shapePathPointTipEnable = value;
                this.Invalidate();
            }
        }

        private Font shapePathPointTipFont = new Font("宋体", 9);
        /// <summary>
        /// 自定义形状编辑点提示字体
        /// </summary>
        [Description("自定义形状编辑点提示字体")]
        [Category("杂项_编辑功能")]
        [DefaultValue(typeof(Font), "宋体, 9pt")]
        public Font ShapePathPointTipFont
        {
            get { return this.shapePathPointTipFont; }
            set
            {
                this.shapePathPointTipFont = value;
                this.Invalidate();
            }
        }

        private Color shapePathPointNormalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 自定义形状编辑点背景颜色(正常)
        /// </summary>
        [Description("自定义形状编辑点背景颜色(正常)")]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Category("杂项_编辑功能")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ShapePathPointNormalColor
        {
            get { return this.shapePathPointNormalColor; }
            set
            {
                if (this.shapePathPointNormalColor == value)
                    return;

                this.shapePathPointNormalColor = value;
                if (this.DesignMode && this.ShapeEditorEnable)
                {
                    this.Invalidate();
                }
            }
        }

        private Color shapePathPointEnterColor = Color.FromArgb(0, 192, 192);
        /// <summary>
        /// 自定义形状编辑点背景颜色(鼠标进入)
        /// </summary>
        [Description("自定义形状编辑点背景颜色(鼠标进入)")]
        [Category("杂项_编辑功能")]
        [DefaultValue(typeof(Color), "0, 192, 192")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ShapePathPointEnterColor
        {
            get { return this.shapePathPointEnterColor; }
            set
            {
                if (this.shapePathPointEnterColor == value)
                    return;

                this.shapePathPointEnterColor = value;
                if (this.DesignMode && this.ShapeEditorEnable)
                {
                    this.Invalidate();
                }
            }
        }

        private Color shapePathPointDownColor = Color.FromArgb(0, 255, 255);
        /// <summary>
        /// 自定义形状编辑点背景颜色(鼠标按下)
        /// </summary>
        [Description("自定义形状编辑点背景颜色(鼠标按下)")]
        [Category("杂项_编辑功能")]
        [DefaultValue(typeof(Color), "0, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ShapePathPointDownColor
        {
            get { return this.shapePathPointDownColor; }
            set
            {
                if (this.shapePathPointDownColor == value)
                    return;

                this.shapePathPointDownColor = value;
                if (this.DesignMode && this.ShapeEditorEnable)
                {
                    this.Invalidate();
                }
            }
        }

        private Color shapePathLineColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 自定义形状编辑路径颜色
        /// </summary>
        [Description("自定义形状编辑路径颜色")]
        [Category("杂项_编辑功能")]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ShapePathLineColor
        {
            get { return this.shapePathLineColor; }
            set
            {
                if (this.shapePathLineColor == value)
                    return;
                this.shapePathLineColor = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        private Color shapePathPointTipColor = Color.FromArgb(0, 100, 0);
        /// <summary>
        /// 自定义形状编辑路径文本颜色
        /// </summary>
        [Description("自定义形状编辑路径颜色")]
        [Category("杂项_编辑功能")]
        [DefaultValue(typeof(Color), "0, 100, 0")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ShapePathPointTipColor
        {
            get { return this.shapePathPointTipColor; }
            set
            {
                if (this.shapePathPointTipColor == value)
                    return;
                this.shapePathPointTipColor = value;

                if (this.DesignMode && this.ShapeEditorEnable)
                {
                    this.Invalidate();
                }
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
                    return true;   //界面设计模式
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
                return new Size(260, 260);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor
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

        [Category("杂项_文本")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        [Category("杂项_文本")]
        [DefaultValue(typeof(Font), "宋体, 9pt")]
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
        /// 形状坐标对象集合
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal List<ShapePathPointClass> shapePathPointObjectList = new List<ShapePathPointClass>();

        /// <summary>
        /// 鼠标进入编辑点索引
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int shapePathPointMouseEnterIndex = -1;

        /// <summary>
        /// 鼠标按下编辑点索引
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int shapePathPointMouseDownIndex = -1;

        /// <summary>
        /// 控件鼠标状态
        /// </summary>
        private MouseStatuss mouseStatus = MouseStatuss.Normal;

        #endregion

        public AnomalyButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
            this.InitializeRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            #region 颜色

            Color back_color = Color.Empty;
            Color back_gradual_color = Color.Empty;
            Color fore_color = Color.Empty;
            if (this.CheckEnable)
            {
                if (this.Checked)
                {
                    if (!this.Enabled && !this.DesignMode)
                    {
                        back_color = this.BackDisabledCheckedColor;
                        back_gradual_color = this.BackDisabledGradualCheckedColor;
                        fore_color = this.TextDisabledColor;
                    }
                    else
                    {
                        if (this.mouseStatus == MouseStatuss.Down)
                        {
                            back_color = this.BackDownCheckedColor;
                            back_gradual_color = this.BackDownGradualCheckedColor;
                            fore_color = this.TextCheckedColor;
                        }
                        else if (this.mouseStatus == MouseStatuss.Enter)
                        {
                            back_color = this.BackEnterCheckedColor;
                            back_gradual_color = this.BackEnterGradualCheckedColor;
                            fore_color = this.TextCheckedColor;
                        }
                        else
                        {
                            back_color = this.BackNormalCheckedColor;
                            back_gradual_color = this.BackNormalGradualCheckedColor;
                            fore_color = this.TextCheckedColor;
                        }
                    }
                }
                else
                {
                    if (!this.Enabled && !this.DesignMode)
                    {
                        back_color = this.BackDisabledColor;
                        back_gradual_color = this.BackDisabledGradualColor;
                        fore_color = this.TextDisabledColor;
                    }
                    else
                    {
                        if (this.mouseStatus == MouseStatuss.Down)
                        {
                            back_color = this.BackDownColor;
                            back_gradual_color = this.BackDownGradualColor;
                            fore_color = this.TextNormalColor;
                        }
                        else if (this.mouseStatus == MouseStatuss.Enter)
                        {
                            back_color = this.BackEnterColor;
                            back_gradual_color = this.BackEnterGradualColor;
                            fore_color = this.TextNormalColor;
                        }
                        else
                        {
                            back_color = this.BackNormalColor;
                            back_gradual_color = this.BackNormalGradualColor;
                            fore_color = this.TextNormalColor;
                        }
                    }
                }
            }
            else
            {
                if (!this.Enabled && !this.DesignMode)
                {
                    back_color = this.BackDisabledColor;
                    back_gradual_color = this.BackDisabledGradualColor;
                    fore_color = this.TextDisabledColor;
                }
                else
                {
                    if (this.mouseStatus == MouseStatuss.Down)
                    {
                        back_color = this.BackDownColor;
                        back_gradual_color = this.BackDownGradualColor;
                        fore_color = this.TextNormalColor;
                    }
                    else if (this.mouseStatus == MouseStatuss.Enter)
                    {
                        back_color = this.BackEnterColor;
                        back_gradual_color = this.BackEnterGradualColor;
                        fore_color = this.TextNormalColor;
                    }
                    else
                    {
                        back_color = this.BackNormalColor;
                        back_gradual_color = this.BackNormalGradualColor;
                        fore_color = this.TextNormalColor;
                    }
                }
            }

            #endregion

            #region 绘制背景

            SolidBrush sb = new SolidBrush(back_color);
            g.FillRectangle(sb, this.ClientRectangle);
            sb.Dispose();

            if (this.BackGradualEnable)
            {
                float r = this.BackGradualRadius * DotsPerInchHelper.DPIScale.XScale;

                ComplexityPropertys.PointF gradient_center_point = new ComplexityPropertys.PointF(this.BackGradualPoint.X * DotsPerInchHelper.DPIScale.XScale, this.BackGradualPoint.Y * DotsPerInchHelper.DPIScale.XScale);
                GraphicsPath gradual_gp = new GraphicsPath();
                RectangleF rect = new RectangleF(gradient_center_point .X- r, gradient_center_point.Y - r, r * 2, r * 2);
                gradual_gp.AddEllipse(rect);
                PathGradientBrush gpb = new PathGradientBrush(gradual_gp);
                gpb.CenterPoint = gradient_center_point.ConvertTo();
                gpb.CenterColor = back_gradual_color;
                gpb.SurroundColors = new Color[] { Color.Transparent };
                g.FillEllipse(gpb, rect);
                gpb.Dispose();
                gradual_gp.Dispose();
            }

            #endregion

            #region 文本

            if (this.Text != "")
            {
                SolidBrush text_sb = new SolidBrush(fore_color);
                Size text_size = Size.Ceiling(g.MeasureString(this.Text, this.Font, int.MaxValue, StringFormat.GenericDefault));
                g.DrawString(this.Text, this.Font, text_sb, new System.Drawing.PointF(TextPoint.X * DotsPerInchHelper.DPIScale.XScale - text_size.Width / 2, TextPoint.Y * DotsPerInchHelper.DPIScale.XScale - text_size.Height / 2));
                text_sb.Dispose();
            }

            #endregion

            #region 设置控件形状

            System.Drawing.PointF[] pointsArr = this.GetShapeRealityPoints();
            if ((this.DesignMode == false && pointsArr.Length >= 3) || (this.DesignMode == true && this.ShapeEditorEnable == false && pointsArr.Length >= 3))
            {
                GraphicsPath shape_gp = new GraphicsPath();
                if (this.ShapeStyle == ShapeStyles.Bezier)
                {
                    shape_gp.AddClosedCurve(pointsArr);
                }
                else
                {
                    shape_gp.AddPolygon(pointsArr);
                }
                this.Region = new Region(shape_gp);
                shape_gp.Dispose();
            }
            else
            {
                GraphicsPath shape_gp = new GraphicsPath();
                shape_gp.AddRectangle(this.ClientRectangle);
                this.Region = new Region(shape_gp);
                shape_gp.Dispose();
            }

            #endregion

            #region 编辑功能

            #region 绘制路径

            if (this.DesignMode == true && this.ShapeEditorEnable == true && pointsArr.Length >= 3)
            {
                Pen shapePath_pan = new Pen(this.ShapePathLineColor);
                if (this.ShapeStyle == ShapeStyles.Bezier)
                {
                    g.DrawClosedCurve(shapePath_pan, pointsArr);
                }
                else
                {
                    g.DrawPolygon(shapePath_pan, pointsArr);
                }
                shapePath_pan.Dispose();
            }

            #endregion

            #region 绘制路径坐标

            if (this.DesignMode == true && this.ShapeEditorEnable == true)
            {
                SolidBrush shapePoint_normal_sb = null;
                SolidBrush shapePoint_enter_sb = null;
                SolidBrush shapePoint_down_sb = null;
                SolidBrush shapePoint_text_sb = null;
                if (this.ShapePathPointTipEnable)
                {
                    shapePoint_text_sb = new SolidBrush(this.ShapePathPointTipColor);
                }

                for (int i = 0; i < this.shapePathPointObjectList.Count; i++)
                {
                    if (this.shapePathPointMouseDownIndex == i)
                    {
                        if (shapePoint_down_sb == null)
                        {
                            shapePoint_down_sb = new SolidBrush(this.ShapePathPointDownColor);
                        }
                        g.FillEllipse(shapePoint_down_sb, this.shapePathPointObjectList[i].RealityRect);
                    }
                    else if (this.shapePathPointMouseEnterIndex == i)
                    {
                        if (shapePoint_enter_sb == null)
                        {
                            shapePoint_enter_sb = new SolidBrush(this.ShapePathPointEnterColor);
                        }
                        g.FillEllipse(shapePoint_enter_sb, this.shapePathPointObjectList[i].RealityRect);
                    }
                    else
                    {
                        if (shapePoint_normal_sb == null)
                        {
                            shapePoint_normal_sb = new SolidBrush(this.ShapePathPointNormalColor);
                        }
                        g.FillEllipse(shapePoint_normal_sb, this.shapePathPointObjectList[i].RealityRect);
                    }

                    if (this.ShapePathPointTipEnable)
                    {
                        SizeF tip_size = g.MeasureString(i.ToString(), this.ShapePathPointTipFont);
                        int y = (int)((this.shapePathPointObjectList[i].RealityRect.Y > tip_size.Height) ? this.shapePathPointObjectList[i].RealityRect.Y - tip_size.Height : this.shapePathPointObjectList[i].RealityRect.Bottom + 4);
                        g.DrawString(i.ToString(), this.ShapePathPointTipFont, shapePoint_text_sb, new System.Drawing.PointF(this.shapePathPointObjectList[i].RealityRect.X, y));
                    }
                }

                if (shapePoint_normal_sb != null)
                    shapePoint_normal_sb.Dispose();
                if (shapePoint_enter_sb != null)
                    shapePoint_enter_sb.Dispose();
                if (shapePoint_down_sb != null)
                    shapePoint_down_sb.Dispose();
                if (shapePoint_text_sb != null)
                    shapePoint_text_sb.Dispose();
            }

            #endregion

            #endregion

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.mouseStatus != MouseStatuss.Enter)
            {
                this.mouseStatus = MouseStatuss.Enter;
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.mouseStatus != MouseStatuss.Normal)
            {
                this.mouseStatus = MouseStatuss.Normal;
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left && this.mouseStatus != MouseStatuss.Down)
            {
                this.mouseStatus = MouseStatuss.Down;
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.ClientRectangle.Contains(e.Location))
                {
                    if (this.mouseStatus != MouseStatuss.Enter)
                    {
                        this.mouseStatus = MouseStatuss.Enter;
                        this.Invalidate();
                    }
                }
                else
                {
                    if (this.mouseStatus != MouseStatuss.Normal)
                    {
                        this.mouseStatus = MouseStatuss.Normal;
                        this.Invalidate();
                    }
                }

                this.Checked = !this.Checked;
                this.OnCheckedChanged(new EventArgs());
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Invalidate();
        }

        #endregion

        #region 虚方法

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            if (this.checkedChanged != null)
            {
                this.checkedChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件坐标
        /// </summary>
        private void InitializeRectangle()
        {
            int scale_shapePathPointRadius = (int)(this.ShapePathPointRadius * DotsPerInchHelper.DPIScale.XScale);

            System.Drawing.PointF[] pointsArr = this.UnSerializeShapePoints(this.ShapePoints);
            List<ShapePathPointClass> pointObjectList_tmp = new List<ShapePathPointClass>();

            for (int i = 0; i < pointsArr.Length; i++)
            {
                System.Drawing.PointF tmp = new System.Drawing.PointF((float)Math.Round(pointsArr[i].X * DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round(pointsArr[i].Y * DotsPerInchHelper.DPIScale.XScale, 2));
                pointObjectList_tmp.Add(new ShapePathPointClass() { Point = pointsArr[i], RealityPoint = tmp, RealityRect = new RectangleF(tmp.X - scale_shapePathPointRadius, tmp.Y - scale_shapePathPointRadius, scale_shapePathPointRadius * 2, scale_shapePathPointRadius * 2) });
            }
            this.shapePathPointObjectList = pointObjectList_tmp;
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 反序列化坐标成对象
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public System.Drawing.PointF[] UnSerializeShapePoints(string points)
        {
            string[] pointsStrArr = points.Replace("\r\n", "").Replace(" ", "").Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            System.Drawing.PointF[] pointsArr = new System.Drawing.PointF[pointsStrArr.Length];
            for (int i = 0; i < pointsStrArr.Length; i++)
            {
                string[] xyArr = pointsStrArr[i].Split(',');
                float x = 0;
                float y = 0;
                if (xyArr.Length > 0)
                {
                    float.TryParse(xyArr[0], out x);
                }
                if (xyArr.Length > 1)
                {
                    float.TryParse(xyArr[1], out y);
                }
                pointsArr[i] = new System.Drawing.PointF(x, y);
            }

            return pointsArr;
        }

        /// <summary>
        /// 序列化坐标成字符串
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public string SerializeShapePoints(System.Drawing.PointF[] points)
        {
            List<string> pointList = new List<string>();
            for (int i = 0; i < points.Length; i++)
            {
                pointList.Add("{" + points[i].X + "," + points[i].Y + "}");
            }
            return String.Join(" ", pointList);
        }

        /// <summary>
        /// 获取形状的所有坐标
        /// </summary>
        /// <returns></returns>
        public System.Drawing.PointF[] GetShapePoints()
        {
            System.Drawing.PointF[] pointsArr = new System.Drawing.PointF[this.shapePathPointObjectList.Count];
            for (int i = 0; i < this.shapePathPointObjectList.Count; i++)
            {
                pointsArr[i] = new System.Drawing.PointF(this.shapePathPointObjectList[i].Point.X, this.shapePathPointObjectList[i].Point.Y);
            }
            return pointsArr;
        }

        /// <summary>
        /// 获取形状的所有实际坐标
        /// </summary>
        /// <returns></returns>
        public System.Drawing.PointF[] GetShapeRealityPoints()
        {
            System.Drawing.PointF[] pointsArr = new System.Drawing.PointF[this.shapePathPointObjectList.Count];
            for (int i = 0; i < this.shapePathPointObjectList.Count; i++)
            {
                pointsArr[i] = new System.Drawing.PointF(this.shapePathPointObjectList[i].RealityPoint.X, this.shapePathPointObjectList[i].RealityPoint.Y);
            }
            return pointsArr;
        }

        #endregion

        #region 类

        /// <summary>
        /// 自定义控件形状信息
        /// </summary>
        [Description("自定义控件信息")]
        public class ShapePathPointClass
        {
            private System.Drawing.PointF point = System.Drawing.PointF.Empty;
            /// <summary>
            /// 自定义控件形状路径坐标
            /// </summary>
            [Description("自定义控件形状路径坐标")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public System.Drawing.PointF Point
            {
                get
                {
                    return this.point;
                }
                set
                {
                    if (this.point == value)
                        return;

                    this.point = value;
                }
            }

            private System.Drawing.PointF realityPoint = System.Drawing.PointF.Empty;
            /// <summary>
            /// 自定义控件形状路径实际坐标
            /// </summary>
            [Description("自定义控件形状路径实际坐标")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public System.Drawing.PointF RealityPoint
            {
                get
                {
                    return this.realityPoint;
                }
                set
                {
                    if (this.realityPoint == value)
                        return;

                    this.realityPoint = value;
                }
            }


            private RectangleF realityRect = RectangleF.Empty;
            /// <summary>
            /// 自定义控件形状路径实际坐标Rect
            /// </summary>
            [Description("自定义控件形状路径实际坐标Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RealityRect
            {
                get
                {
                    return this.realityRect;
                }
                set
                {
                    if (this.realityRect == value)
                        return;

                    this.realityRect = value;
                }
            }

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 控件鼠标状态
        /// </summary>
        [Description("控件鼠标状态")]
        public enum MouseStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter,
            /// <summary>
            /// 鼠标按钮
            /// </summary>
            Down
        }

        /// <summary>
        /// 自定义形状路径风格
        /// </summary>
        [Description("自定义形状路径风格")]
        public enum ShapeStyles
        {
            /// <summary>
            /// 普通
            /// </summary>
            Normal,
            /// <summary>
            /// 贝塞尔
            /// </summary>
            Bezier
        }

        #endregion
    }

}
