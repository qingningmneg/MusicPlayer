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
    /// CheckBoxExt控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("CheckBoxExt控件")]
    [DefaultProperty("Checked")]
    [DefaultEvent("CheckedChanged")]
    [Designer(typeof(CheckBoxExtDesigner))]
    public class CheckBoxExt : Control
    {
        #region 新增事件

        public delegate void CheckedChangedEventHandler(object sender, CheckedChangedEventArgs e);

        private event CheckedChangedEventHandler checkedChanged;
        /// <summary>
        /// 控件状态更改事件
        /// </summary>
        [Description("控件状态更改事件")]
        public event CheckedChangedEventHandler CheckedChanged
        {
            add { this.checkedChanged += value; }
            remove { this.checkedChanged -= value; }
        }

        public delegate void CheckStateChangedEventHandler(object sender, CheckStateChangedEventArgs e);

        private event CheckStateChangedEventHandler checkStateChanged;
        /// <summary>
        /// 控件状态更改事件
        /// </summary>
        [Description("控件状态更改事件")]
        public event CheckStateChangedEventHandler CheckStateChanged
        {
            add { this.checkStateChanged += value; }
            remove { this.checkStateChanged -= value; }
        }

        #endregion

        #region 停用事件

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

        #region 

        private Styles style = Styles.Default;
        /// <summary>
        /// 控件风格
        /// </summary>
        [DefaultValue(Styles.Default)]
        [Description("控件风格")]
        public Styles Style
        {
            get { return this.style; }
            set
            {
                if (this.style == value)
                    return;

                this.style = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private bool autoAntiAlias = true;
        /// <summary>
        /// 控件是否启用抗锯齿模式
        /// </summary>
        [DefaultValue(true)]
        [Description("控件是否启用抗锯齿模式")]
        public bool AutoAntiAlias
        {
            get { return this.autoAntiAlias; }
            set
            {
                if (this.autoAntiAlias == value)
                    return;

                this.autoAntiAlias = value;
                this.Invalidate();
            }
        }

        private OperateScopes operateScope = OperateScopes.Box;
        /// <summary>
        /// 更改状态操作范围
        /// </summary>
        [DefaultValue(OperateScopes.Box)]
        [Description("更改状态操作范围")]
        public OperateScopes OperateScope
        {
            get { return this.operateScope; }
            set
            {
                if (this.operateScope == value)
                    return;

                this.operateScope = value;
            }
        }

        /// <summary>
        /// 否自动调整控件的大小以显示其完整内容。
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        [Description("否自动调整控件的大小以显示其完整内容。")]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                if (base.AutoSize == value)
                    return;

                base.AutoSize = value;
                if (base.AutoSize)
                {
                    this.UpdateAutoSize();
                }
                else
                {
                    this.InitializeRectangle();
                    this.Invalidate();
                }
            }
        }

        private int circular = 0;
        /// <summary>
        /// 控件圆角大小
        /// </summary>
        [DefaultValue(0)]
        [Description("控件圆角大小")]
        public int Circular
        {
            get { return this.circular; }
            set
            {
                if (this.circular == value || value < 0)
                    return;

                this.circular = value;
                this.Invalidate();
            }
        }

        private TextAligns textAlign = TextAligns.Right;
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        [DefaultValue(TextAligns.Right)]
        [Description("文本对齐方式")]
        public TextAligns TextAlign
        {
            get { return this.textAlign; }
            set
            {
                if (this.textAlign == value)
                    return;

                this.textAlign = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
                else
                {
                    this.InitializeRectangle();
                    this.Invalidate();
                }
            }
        }

        private bool threeState = false;
        /// <summary>
        /// 控件是否为三种选择状态（否则为两种选择状态）
        /// </summary>
        [DefaultValue(false)]
        [Description("控件是否为三种选择状态（否则为两种选择状态）")]
        public bool ThreeState
        {
            get { return this.threeState; }
            set
            {
                if (this.threeState == value)
                    return;

                this.threeState = value;
                this.Invalidate();
            }
        }

        private CheckStates checkState = CheckStates.UnChecked;
        /// <summary>
        /// 控件状态
        /// </summary>
        [DefaultValue(CheckStates.UnChecked)]
        [Description("控件状态")]
        public CheckStates CheckState
        {
            get { return this.checkState; }
            set
            {
                if (this.checkState == value)
                    return;

                this.checkState = value;

                if (this.ThreeState == true)
                {
                    this.Invalidate();
                }
                if (!this.DesignMode)
                {
                    this.OnCheckStateChanged(new CheckStateChangedEventArgs() { CheckState = value });
                }
            }
        }


        private bool _checked = false;
        /// <summary>
        /// 状态
        /// </summary>
        [DefaultValue(false)]
        [Description("状态")]
        public bool Checked
        {
            get { return this._checked; }
            set
            {
                if (this._checked == value)
                    return;

                this._checked = value;
                this.Invalidate();

                if (!this.DesignMode)
                {
                    this.OnCheckedChanged(new CheckedChangedEventArgs() { Checked = value });
                }
            }
        }

        private Color activateColor = Color.Gray;
        /// <summary>
        /// 控件激活的虚线框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("控件激活的虚线框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
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

        #region 图标

        private int boxRadius = 10;
        /// <summary>
        /// 图标半径大小
        /// </summary>
        [DefaultValue(10)]
        [Description("图标半径大小")]
        public int BoxRadius
        {
            get { return this.boxRadius; }
            set
            {
                if (this.boxRadius == value || value < 1)
                    return;

                this.boxRadius = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
                else
                {
                    this.InitializeRectangle();
                    this.Invalidate();
                }
            }
        }

        private int boxBorder = 1;
        /// <summary>
        /// 图标边框画笔大小
        /// </summary>
        [DefaultValue(1)]
        [Description("图标边框画笔大小")]
        public int BoxBorder
        {
            get { return this.boxBorder; }
            set
            {
                if (this.boxBorder == value || value < 0)
                    return;

                this.boxBorder = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int boxCircular = 0;
        /// <summary>
        /// 图标圆角大小
        /// </summary>
        [DefaultValue(0)]
        [Description("图标圆角大小")]
        public int BoxCircular
        {
            get { return this.boxCircular; }
            set
            {
                if (this.boxCircular == value || value < 0)
                    return;

                this.boxCircular = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int boxSpace = 10;
        /// <summary>
        /// 图标与文本的间距
        /// </summary>
        [DefaultValue(10)]
        [Description("图标与文本的间距")]
        public int BoxSpace
        {
            get { return this.boxSpace; }
            set
            {
                if (this.boxSpace == value || value < 0)
                    return;

                this.boxSpace = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private BoxTypes boxType = BoxTypes.DefaultChar;
        /// <summary>
        /// 图标类型
        /// </summary>
        [DefaultValue(BoxTypes.DefaultChar)]
        [Description("图标类型")]
        public BoxTypes BoxType
        {
            get { return this.boxType; }
            set
            {
                if (this.boxType == value)
                    return;

                this.boxType = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        #region 自定义图片

        private ImageList imageList;
        /// <summary>
        /// 自定义图片
        /// </summary>
        [Description("自定义图片")]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageList ImageList
        {
            get
            {
                return this.imageList;
            }
            set
            {
                if (this.imageList == value)
                    return;

                EventHandler eventHandler1 = new EventHandler(this.ImageListRecreateHandle);
                EventHandler eventHandler2 = new EventHandler(this.DetachImageList);
                if (this.imageList != null)
                {
                    this.imageList.RecreateHandle -= eventHandler1;
                    this.imageList.Disposed -= eventHandler2;
                }
                if (value != null)
                {
                    this.customCheckedImage = (Image)null;
                    this.customUnCheckedImage = (Image)null;
                }
                this.imageList = value;
                this.customCheckedImageIndex.ImageList = value;
                this.customUnCheckedImageIndex.ImageList = value;
                if (value != null)
                {
                    value.RecreateHandle += eventHandler1;
                    value.Disposed += eventHandler2;
                }
                else
                {
                    this.customCheckedImageIndex.Index = -1;
                    this.customCheckedImageIndex.Key = string.Empty;
                    this.customUnCheckedImageIndex.Index = -1;
                    this.customUnCheckedImageIndex.Key = string.Empty;
                }
                this.Invalidate();
            }
        }

        #region 已选中
        private Image customCheckedImage = null;
        /// <summary>
        /// 已选中状态图标图片
        /// </summary>
        [DefaultValue(null)]
        [Description("已选中状态图标图片")]
        public Image CustomCheckedImage
        {
            get
            {
                if (this.customCheckedImage != null)
                {
                    return this.customCheckedImage;
                }
                else
                {
                    if (this.imageList != null)
                    {
                        int index = this.customCheckedImageIndex.ActualIndex;
                        if (index >= this.imageList.Images.Count)
                            return null;
                        if (index >= 0)
                            return this.imageList.Images[index];
                    }
                    return null;
                }
            }
            set
            {
                if (this.customCheckedImage == value)
                    return;

                this.customCheckedImage = value;
                this.customCheckedImageIndex.Index = -1;
                this.customCheckedImageIndex.Key = string.Empty;
                this.Invalidate();
            }
        }

        private Indexer customCheckedImageIndex = new Indexer();
        /// <summary>
        /// 已选中状态图标图片Index
        /// </summary>
        [Description("已选中状态图标图片Index")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageIndexConverter))]
        public int CustomCheckedImageIndex
        {
            get
            {
                if (this.customCheckedImageIndex.Index != -1 && this.imageList != null && this.customCheckedImageIndex.Index >= this.imageList.Images.Count)
                    return this.imageList.Images.Count - 1;
                return this.customCheckedImageIndex.Index;
            }
            set
            {
                if (this.customCheckedImageIndex.Index == value || value < -1)
                    return;

                this.customCheckedImageIndex.Index = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 已选中状态图标图片Key
        /// </summary>
        [Description("已选中状态图标图片Key")]
        [DefaultValue("")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageKeyConverter))]
        public string CustomCheckedImageKey
        {
            get
            {
                return this.customCheckedImageIndex.Key;
            }
            set
            {
                if (this.customCheckedImageIndex.Key == value)
                    return;

                this.customCheckedImageIndex.Key = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 部分选中
        private Image customPartCheckedImage = null;
        /// <summary>
        /// 部分选中状态图标图片
        /// </summary>
        [DefaultValue(null)]
        [Description("部分选中状态图标图片")]
        public Image CustomPartCheckedImage
        {
            get
            {
                if (this.customPartCheckedImage != null)
                {
                    return this.customPartCheckedImage;
                }
                else
                {
                    if (this.imageList != null)
                    {
                        int index = this.customPartCheckedImageIndex.ActualIndex;
                        if (index >= this.imageList.Images.Count)
                            return null;
                        if (index >= 0)
                            return this.imageList.Images[index];
                    }
                    return null;
                }
            }
            set
            {
                if (this.customPartCheckedImage == value)
                    return;

                this.customPartCheckedImage = value;
                this.customPartCheckedImageIndex.Index = -1;
                this.customPartCheckedImageIndex.Key = string.Empty;
                this.Invalidate();
            }
        }

        private Indexer customPartCheckedImageIndex = new Indexer();
        /// <summary>
        /// 部分选中状态图标图片Index
        /// </summary>
        [Description("部分选中状态图标图片Index")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageIndexConverter))]
        public int CustomPartCheckedImageIndex
        {
            get
            {
                if (this.customPartCheckedImageIndex.Index != -1 && this.imageList != null && this.customPartCheckedImageIndex.Index >= this.imageList.Images.Count)
                    return this.imageList.Images.Count - 1;
                return this.customPartCheckedImageIndex.Index;
            }
            set
            {
                if (this.customPartCheckedImageIndex.Index == value || value < -1)
                    return;

                this.customPartCheckedImageIndex.Index = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 部分选中状态图标图片Key
        /// </summary>
        [Description("部分选中状态图标图片Key")]
        [DefaultValue("")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageKeyConverter))]
        public string CustomPartCheckedImageKey
        {
            get
            {
                return this.customPartCheckedImageIndex.Key;
            }
            set
            {
                if (this.customPartCheckedImageIndex.Key == value)
                    return;

                this.customPartCheckedImageIndex.Key = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 未选中

        private Image customUnCheckedImage = null;
        /// <summary>
        /// 未选中状态图标图片
        /// </summary>
        [DefaultValue(null)]
        [Description("未选中状态图标图片")]
        public Image CustomUnCheckedImage
        {
            get
            {
                if (this.customUnCheckedImage != null)
                {
                    return this.customUnCheckedImage;
                }
                else
                {
                    if (this.imageList != null)
                    {
                        int index = this.customUnCheckedImageIndex.ActualIndex;
                        if (index >= this.imageList.Images.Count)
                            return null;
                        if (index >= 0)
                            return this.imageList.Images[index];
                    }
                    return null;
                }
            }
            set
            {
                if (this.customUnCheckedImage == value)
                    return;

                this.customUnCheckedImage = value;
                this.customUnCheckedImageIndex.Index = -1;
                this.customUnCheckedImageIndex.Key = string.Empty;
                this.Invalidate();
            }
        }

        private Indexer customUnCheckedImageIndex = new Indexer();
        /// <summary>
        /// 未选中状态图标图片Index
        /// </summary>
        [Description("未选中状态图标图片Index")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageIndexConverter))]
        public int CustomUnCheckedImageIndex
        {
            get
            {
                if (this.customUnCheckedImageIndex.Index != -1 && this.imageList != null && this.customUnCheckedImageIndex.Index >= this.imageList.Images.Count)
                    return this.imageList.Images.Count - 1;
                return this.customUnCheckedImageIndex.Index;
            }
            set
            {
                if (this.customUnCheckedImageIndex.Index == value || value < -1)
                    return;

                this.customUnCheckedImageIndex.Index = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 未选中状态图标图片Key
        /// </summary>
        [Description("未选中状态图标图片Key")]
        [DefaultValue("")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageKeyConverter))]
        public string CustomUnCheckedImageKey
        {
            get
            {
                return this.customUnCheckedImageIndex.Key;
            }
            set
            {
                if (this.customUnCheckedImageIndex.Key == value)
                    return;

                this.customUnCheckedImageIndex.Key = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region 颜色

        #region（未选中）

        private Color unCheckedBackColor = Color.Empty;
        /// <summary>
        /// 背景颜色（未选中）
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("背景颜色（未选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBackColor
        {
            get { return this.unCheckedBackColor; }
            set
            {
                if (this.unCheckedBackColor == value)
                    return;

                this.unCheckedBackColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedTextColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 文本颜色（未选中）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("文本颜色（未选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedTextColor
        {
            get { return this.unCheckedTextColor; }
            set
            {
                if (this.unCheckedTextColor == value)
                    return;

                this.unCheckedTextColor = value;
                this.Invalidate();
            }
        }


        private Color unCheckedBoxBackColor = Color.Empty;
        /// <summary>
        /// 图标颜色（未选中）
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("图标颜色（未选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBoxBackColor
        {
            get { return this.unCheckedBoxBackColor; }
            set
            {
                if (this.unCheckedBoxBackColor == value)
                    return;

                this.unCheckedBoxBackColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedBoxBorderColor = Color.FromArgb(221, 216, 206);
        /// <summary>
        /// 图标边框颜色（未选中）
        /// </summary>
        [DefaultValue(typeof(Color), "221, 216, 206")]
        [Description("图标边框颜色（未选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBoxBorderColor
        {
            get { return this.unCheckedBoxBorderColor; }
            set
            {
                if (this.unCheckedBoxBorderColor == value)
                    return;

                this.unCheckedBoxBorderColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedBoxCharColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 图标符号颜色（未选中）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("图标符号颜色（未选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBoxCharColor
        {
            get { return this.unCheckedBoxCharColor; }
            set
            {
                if (this.unCheckedBoxCharColor == value)
                    return;

                this.unCheckedBoxCharColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region（部分选中）

        private Color partCheckedBackColor = Color.Empty;
        /// <summary>
        /// 背景颜色（部分选中）
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("背景颜色（部分选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PartCheckedBackColor
        {
            get { return this.partCheckedBackColor; }
            set
            {
                if (this.partCheckedBackColor == value)
                    return;

                this.partCheckedBackColor = value;
                this.Invalidate();
            }
        }

        private Color partCheckedTextColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 文本颜色（部分选中）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("文本颜色（部分选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PartCheckedTextColor
        {
            get { return this.partCheckedTextColor; }
            set
            {
                if (this.partCheckedTextColor == value)
                    return;

                this.partCheckedTextColor = value;
                this.Invalidate();
            }
        }


        private Color partCheckedBoxBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 图标颜色（部分选中）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("图标颜色（部分选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PartCheckedBoxBackColor
        {
            get { return this.partCheckedBoxBackColor; }
            set
            {
                if (this.partCheckedBoxBackColor == value)
                    return;

                this.partCheckedBoxBackColor = value;
                this.Invalidate();
            }
        }

        private Color partCheckedBoxBorderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 图标边框颜色（部分选中）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("图标边框颜色（部分选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PartCheckedBoxBorderColor
        {
            get { return this.partCheckedBoxBorderColor; }
            set
            {
                if (this.partCheckedBoxBorderColor == value)
                    return;

                this.partCheckedBoxBorderColor = value;
                this.Invalidate();
            }
        }

        private Color partCheckedBoxCharColor = Color.FromArgb(205, 220, 57);
        /// <summary>
        /// 图标符号颜色（部分选中）
        /// </summary>
        [DefaultValue(typeof(Color), "205, 220, 57")]
        [Description("图标符号颜色（部分选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PartCheckedBoxCharColor
        {
            get { return this.partCheckedBoxCharColor; }
            set
            {
                if (this.partCheckedBoxCharColor == value)
                    return;

                this.partCheckedBoxCharColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region（选中）

        private Color checkedBackColor = Color.Empty;
        /// <summary>
        /// 背景颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("背景颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedBackColor
        {
            get { return this.checkedBackColor; }
            set
            {
                if (this.checkedBackColor == value)
                    return;

                this.checkedBackColor = value;
                this.Invalidate();
            }
        }

        private Color checkedTextColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 文本颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("文本颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedTextColor
        {
            get { return this.checkedTextColor; }
            set
            {
                if (this.checkedTextColor == value)
                    return;

                this.checkedTextColor = value;
                this.Invalidate();
            }
        }


        private Color checkedBoxBackColor = Color.FromArgb(205, 220, 57);
        /// <summary>
        /// 图标颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "205, 220, 57")]
        [Description("图标颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedBoxBackColor
        {
            get { return this.checkedBoxBackColor; }
            set
            {
                if (this.checkedBoxBackColor == value)
                    return;

                this.checkedBoxBackColor = value;
                this.Invalidate();
            }
        }

        private Color checkedBoxBorderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 图标边框颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("图标边框颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedBoxBorderColor
        {
            get { return this.checkedBoxBorderColor; }
            set
            {
                if (this.checkedBoxBorderColor == value)
                    return;

                this.checkedBoxBorderColor = value;
                this.Invalidate();
            }
        }

        private Color checkedBoxCharColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 图标符号颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("图标符号颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedBoxCharColor
        {
            get { return this.checkedBoxCharColor; }
            set
            {
                if (this.checkedBoxCharColor == value)
                    return;

                this.checkedBoxCharColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region（鼠标进入）

        private Color enterBackColor = Color.FromArgb(192, 210, 27);
        /// <summary>
        /// 背景颜色（鼠标进入）限于Styles.Button
        /// </summary>
        [DefaultValue(typeof(Color), "192, 210, 27")]
        [Description("背景颜色（鼠标进入）限于Styles.Button")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color EnterBackColor
        {
            get { return this.enterBackColor; }
            set
            {
                if (this.enterBackColor == value)
                    return;

                this.enterBackColor = value;
                this.Invalidate();
            }
        }

        private Color enterBoxBorderColor = Color.FromArgb(205, 220, 57);
        /// <summary>
        /// 图标边框颜色（鼠标进入）限于Styles.Default
        /// </summary>
        [DefaultValue(typeof(Color), "205, 220, 57")]
        [Description("图标边框颜色（鼠标进入）限于Styles.Default")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color EnterBoxBorderColor
        {
            get { return this.enterBoxBorderColor; }
            set
            {
                if (this.enterBoxBorderColor == value)
                    return;

                this.enterBoxBorderColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region （禁止）
        private Color disableBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 背景颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBackColor
        {
            get { return this.disableBackColor; }
            set
            {
                if (this.disableBackColor == value)
                    return;

                this.disableBackColor = value;
                this.Invalidate();
            }
        }

        private Color disableTextColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("文本颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableTextColor
        {
            get { return this.disableTextColor; }
            set
            {
                if (this.disableTextColor == value)
                    return;

                this.disableTextColor = value;
                this.Invalidate();
            }
        }

        private Color disableBoxBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 图标颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("图标颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBoxBackColor
        {
            get { return this.disableBoxBackColor; }
            set
            {
                if (this.disableBoxBackColor == value)
                    return;

                this.disableBoxBackColor = value;
                this.Invalidate();
            }
        }

        private Color disableBoxBorderColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 图标边框颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("图标边框颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBoxBorderColor
        {
            get { return this.disableBoxBorderColor; }
            set
            {
                if (this.disableBoxBorderColor == value)
                    return;

                this.disableBoxBorderColor = value;
                this.Invalidate();
            }
        }

        private Color disableBoxCharColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 图标符号颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("图标符号颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBoxCharColor
        {
            get { return this.disableBoxCharColor; }
            set
            {
                if (this.disableBoxCharColor == value)
                    return;

                this.disableBoxCharColor = value;
                this.Invalidate();
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

        public new Size Size
        {
            get { return base.Size; }
            set
            {
                if (this.AutoSize || base.Size == value)
                    return;

                base.Size = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
            }

        }

        /// <summary>
        /// 内边距限于AutoSize
        /// </summary>
        [Description("内边距限于AutoSize")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                if (base.Padding == value)
                    return;

                base.Padding = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
            }

        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text == value)
                    return;

                base.Text = value;
                if (this.AutoSize)
                {
                    this.UpdateAutoSize();
                }
                else
                {
                    this.InitializeRectangle();
                    this.Invalidate();
                }
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(120, 23);
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
        /// 控件激活状态
        /// </summary>
        private bool activatedState = false;
        /// <summary>
        /// 鼠标进入状态
        /// </summary>
        private bool mouseEnter = false;
        /// <summary>
        /// 图标rect
        /// </summary>
        private RectangleF box_rect;
        /// <summary>
        /// 文本rect
        /// </summary>
        private RectangleF text_rect;

        #endregion

        public CheckBoxExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.AutoSize = true;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            #region color

            Color back_color = Color.Empty;
            Color text_color = Color.Empty;
            Color box_back_color = Color.Empty;
            Color box_border_color = Color.Empty;
            Color box_char_color = Color.Empty;

            if (this.Enabled)
            {
                if (this.ThreeState == false)
                {
                    back_color = this.Checked == true ? this.CheckedBackColor : this.UnCheckedBackColor;
                    if (this.Style == Styles.Button && this.mouseEnter)
                    {
                        back_color = this.EnterBackColor;
                    }
                    text_color = this.Checked == true ? this.CheckedTextColor : this.UnCheckedTextColor;

                    box_back_color = this.Checked == true ? this.CheckedBoxBackColor : this.UnCheckedBoxBackColor;
                    box_border_color = this.Checked == true ? this.CheckedBoxBorderColor : this.UnCheckedBoxBorderColor;
                    if (this.Style == Styles.Default && this.mouseEnter)
                    {
                        box_border_color = this.EnterBoxBorderColor;
                    }
                    box_char_color = this.Checked == true ? this.CheckedBoxCharColor : this.UnCheckedBoxCharColor;
                }
                else
                {
                    if (this.CheckState == CheckStates.Checked)
                        back_color = this.CheckedBackColor;
                    else if (this.CheckState == CheckStates.PartChecked)
                        back_color = this.PartCheckedBackColor;
                    else
                        back_color = this.UnCheckedBackColor;
                    if (this.Style == Styles.Button && this.mouseEnter)
                    {
                        back_color = this.EnterBackColor;
                    }

                    if (this.CheckState == CheckStates.Checked)
                        text_color = this.CheckedTextColor;
                    else if (this.CheckState == CheckStates.PartChecked)
                        text_color = this.PartCheckedTextColor;
                    else
                        text_color = this.UnCheckedTextColor;


                    if (this.CheckState == CheckStates.Checked)
                        box_back_color = this.CheckedBoxBackColor;
                    else if (this.CheckState == CheckStates.PartChecked)
                        box_back_color = this.PartCheckedBoxBackColor;
                    else
                        box_back_color = this.UnCheckedBoxBackColor;

                    if (this.CheckState == CheckStates.Checked)
                        box_border_color = this.CheckedBoxBorderColor;
                    else if (this.CheckState == CheckStates.PartChecked)
                        box_border_color = this.PartCheckedBoxBorderColor;
                    else
                        box_border_color = this.UnCheckedBoxBorderColor;
                    if (this.Style == Styles.Default && this.mouseEnter)
                    {
                        box_border_color = this.EnterBoxBorderColor;
                    }


                    if (this.CheckState == CheckStates.Checked)
                        box_char_color = this.CheckedBoxCharColor;
                    else if (this.CheckState == CheckStates.PartChecked)
                        box_char_color = this.PartCheckedBoxCharColor;
                    else
                        box_char_color = this.UnCheckedBoxCharColor;
                }
            }
            else
            {
                back_color = this.DisableBackColor;
                text_color = this.DisableTextColor;

                box_back_color = this.DisableBoxBackColor;
                box_border_color = this.DisableBoxBorderColor;
                box_char_color = this.DisableBoxCharColor;
            }

            #endregion

            SmoothingMode sm = g.SmoothingMode;
            if (this.AutoAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
            }

            #region back
            if (back_color != Color.Empty)
            {
                SolidBrush back_sb = new SolidBrush(back_color);
                if (this.Circular > 0)
                {
                    float scale_circular = this.Circular * DotsPerInchHelper.DPIScale.XScale;
                    GraphicsPath back_rect_gp = ControlCommom.TransformCircular(this.ClientRectangle, scale_circular);

                    g.FillPath(back_sb, back_rect_gp);
                    back_rect_gp.Dispose();
                }
                else
                {
                    g.FillRectangle(back_sb, this.ClientRectangle);
                }
                back_sb.Dispose();
            }
            #endregion

            #region text
            if (text_color != Color.Empty)
            {
                SolidBrush text_sb = new SolidBrush(text_color);
                g.DrawString(this.Text, this.Font, text_sb, this.text_rect.X, this.text_rect.Y, StringFormat.GenericTypographic);
                text_sb.Dispose();
            }
            #endregion

            #region box

            RectangleF box_rect_tmp = ControlCommom.TransformRectangleF(this.box_rect, this.BoxBorder);
            GraphicsPath box_rect_gp = null;

            #region back
            if (this.Style == Styles.Default && box_back_color != Color.Empty)
            {
                SolidBrush box_back_sb = new SolidBrush(box_back_color);
                if (this.BoxCircular > 0)
                {
                    float scale_boxCircular = this.BoxCircular * DotsPerInchHelper.DPIScale.XScale;
                    box_rect_gp = ControlCommom.TransformCircular(box_rect_tmp, scale_boxCircular);
                    g.FillPath(box_back_sb, box_rect_gp);
                }
                else
                {
                    g.FillRectangle(box_back_sb, this.box_rect);
                }
                box_back_sb.Dispose();
            }
            #endregion

            #region border
            if (box_border_color != Color.Empty)
            {
                if (this.Style == Styles.Default && this.BoxBorder > 0)
                {
                    Pen box_border_pen = new Pen(box_border_color, this.BoxBorder);
                    if (this.BoxCircular > 0)
                    {
                        float scale_boxCircular = this.BoxCircular * DotsPerInchHelper.DPIScale.XScale;
                        box_rect_gp = ControlCommom.TransformCircular(box_rect_tmp, scale_boxCircular);
                        g.DrawPath(box_border_pen, box_rect_gp);
                    }
                    else
                    {
                        g.DrawRectangle(box_border_pen, box_rect_tmp.X, box_rect_tmp.Y, box_rect_tmp.Width, box_rect_tmp.Height);
                    }
                    box_border_pen.Dispose();
                }
            }
            #endregion

            if (box_rect_gp != null)
                box_rect_gp.Dispose();

            #region char

            #region 默认符号
            if (this.BoxType == BoxTypes.DefaultChar)
            {
                if (box_char_color != Color.Empty)
                {
                    float min_grid = (this.BoxRadius * 2 * DotsPerInchHelper.DPIScale.XScale) / 8f;
                    if (this.ThreeState == false)
                    {
                        Pen box_char_pen = new Pen(box_char_color, this.BoxRadius * DotsPerInchHelper.DPIScale.XScale / 4f - 0.3f);
                        if (this.Checked)
                        {
                            PointF[] box_char_line = new PointF[] {
                        new PointF(this.box_rect.X+min_grid,this.box_rect.Y+ min_grid * 3),
                        new PointF(this.box_rect.X+min_grid *3,this.box_rect.Y+  min_grid * 5),
                        new PointF(this.box_rect.X+min_grid*6 ,this.box_rect.Y+  min_grid*2)
                        };

                            g.DrawLines(box_char_pen, box_char_line);
                        }
                        else
                        {
                            if (this.Style == Styles.Button)
                            {
                                PointF line_left_s = new PointF(this.box_rect.X + min_grid * 2, this.box_rect.Y + min_grid * 2);
                                PointF line_left_e = new PointF(this.box_rect.X + min_grid * 6, this.box_rect.Y + min_grid * 6);

                                PointF line_right_s = new PointF(this.box_rect.X + min_grid * 6, this.box_rect.Y + min_grid * 2);
                                PointF line_right_e = new PointF(this.box_rect.X + min_grid * 2, this.box_rect.Y + min_grid * 6);
                                g.DrawLine(box_char_pen, line_left_s, line_left_e);
                                g.DrawLine(box_char_pen, line_right_s, line_right_e);
                            }
                        }
                        box_char_pen.Dispose();
                    }
                    else
                    {
                        if (this.CheckState == CheckStates.Checked)
                        {
                            Pen box_char_pen = new Pen(box_char_color, this.BoxRadius * DotsPerInchHelper.DPIScale.XScale / 4f - 0.3f);

                            PointF[] box_char_line = new PointF[] {
                                       new PointF(this.box_rect.X+min_grid,this.box_rect.Y+ min_grid * 3),
                                       new PointF(this.box_rect.X+min_grid *3,this.box_rect.Y+  min_grid * 5),
                                       new PointF(this.box_rect.X+min_grid*6 ,this.box_rect.Y+  min_grid*2)
                                       };

                            g.DrawLines(box_char_pen, box_char_line);
                            box_char_pen.Dispose();
                        }
                        else if (this.CheckState == CheckStates.UnChecked)
                        {
                            if (this.Style == Styles.Button)
                            {
                                Pen box_char_pen = new Pen(box_char_color, this.BoxRadius * DotsPerInchHelper.DPIScale.XScale / 4f - 0.3f);

                                PointF line_left_s = new PointF(this.box_rect.X + min_grid * 2, this.box_rect.Y + min_grid * 2);
                                PointF line_left_e = new PointF(this.box_rect.X + min_grid * 6, this.box_rect.Y + min_grid * 6);

                                PointF line_right_s = new PointF(this.box_rect.X + min_grid * 6, this.box_rect.Y + min_grid * 2);
                                PointF line_right_e = new PointF(this.box_rect.X + min_grid * 2, this.box_rect.Y + min_grid * 6);
                                g.DrawLine(box_char_pen, line_left_s, line_left_e);
                                g.DrawLine(box_char_pen, line_right_s, line_right_e);
                                box_char_pen.Dispose();
                            }
                        }
                        else
                        {
                            SolidBrush box_char_sb = new SolidBrush(box_char_color);
                            RectangleF box_char_rect = new RectangleF(this.box_rect.X + 4, this.box_rect.Y + 4, this.box_rect.Width - 8, this.box_rect.Height - 8);
                            g.FillRectangle(box_char_sb, box_char_rect);
                            box_char_sb.Dispose();

                        }
                    }
                }
            }
            #endregion
            #region 自定义图案
            else
            {
                if (this.ThreeState == false)
                {
                    if (this.Checked)
                    {
                        if (this.CustomCheckedImage != null)
                        {
                            g.DrawImage(this.CustomCheckedImage, this.box_rect);
                        }
                    }
                    else
                    {
                        if (this.CustomUnCheckedImage != null)
                        {
                            g.DrawImage(this.CustomUnCheckedImage, this.box_rect);
                        }
                    }
                }
                else
                {
                    if (this.CheckState == CheckStates.Checked)
                    {
                        if (this.CustomCheckedImage != null)
                        {
                            g.DrawImage(this.CustomCheckedImage, this.box_rect);
                        }
                    }
                    else if (this.CheckState == CheckStates.UnChecked)
                    {
                        if (this.CustomUnCheckedImage != null)
                        {
                            g.DrawImage(this.CustomUnCheckedImage, this.box_rect);
                        }
                    }
                    else
                    {
                        if (this.CustomPartCheckedImage != null)
                        {
                            g.DrawImage(this.CustomPartCheckedImage, this.box_rect);
                        }
                    }
                }
            }
            #endregion

            #endregion

            #endregion

            if (this.AutoAntiAlias)
            {
                g.SmoothingMode = sm;
            }

            #region 激活边框
            if (this.activatedState)
            {
                Pen activate_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
                g.DrawRectangle(activate_pen, this.text_rect.X - 1, this.text_rect.Y - 1, this.text_rect.Width + 2, this.text_rect.Height + 2);
                activate_pen.Dispose();
            }
            #endregion
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            this.Select();
            this.activatedState = false;

            if (this.Style == Styles.Button)
            {
                this.SetState();
            }
            else
            {
                if (this.OperateScope == OperateScopes.Box)
                {
                    if (this.box_rect.Contains(e.Location))
                    {
                        this.SetState();
                    }
                }
                else
                {
                    if (this.box_rect.Contains(e.Location) || this.text_rect.Contains(e.Location))
                    {
                        this.SetState();
                    }
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (this.DesignMode)
                return;

            base.OnMouseClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            if (this.Style == Styles.Button)
            {
                if (this.mouseEnter == false)
                {
                    this.mouseEnter = true;
                    this.Cursor = Cursors.Hand;
                    this.Invalidate();
                }
            }
            else
            {
                if (this.box_rect.Contains(this.PointToClient(Control.MousePosition)))
                {
                    if (this.mouseEnter == true)
                    {
                        this.mouseEnter = false;
                        this.Cursor = Cursors.Hand;
                        this.Invalidate();
                    }
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            if (this.mouseEnter == true)
            {
                this.mouseEnter = false;
                this.Cursor = Cursors.Default;
                this.Invalidate();
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.Style == Styles.Default)
            {
                bool result = this.box_rect.Contains(this.PointToClient(Control.MousePosition));
                if (this.mouseEnter != result)
                {
                    this.mouseEnter = result;
                    this.Invalidate();
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
                return base.ProcessDialogKey(keyData);

            if (this.activatedState)
            {
                #region Space
                if (keyData == Keys.Space)
                {
                    this.SetState();
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeRectangle();
            this.Invalidate();
        }

        #endregion

        #region 虚方法

        protected virtual void OnCheckedChanged(CheckedChangedEventArgs e)
        {
            if (this.checkedChanged != null)
            {
                this.checkedChanged(this, e);
            }
        }

        protected virtual void OnCheckStateChanged(CheckStateChangedEventArgs e)
        {
            if (this.checkStateChanged != null)
            {
                this.checkStateChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化Rectangle
        /// </summary>
        private void InitializeRectangle()
        {
            Padding scale_padding = new Padding((int)(this.Padding.Left * DotsPerInchHelper.DPIScale.XScale), (int)(this.Padding.Top * DotsPerInchHelper.DPIScale.YScale), (int)(this.Padding.Right * DotsPerInchHelper.DPIScale.XScale), (int)(this.Padding.Bottom * DotsPerInchHelper.DPIScale.YScale));

            RectangleF scale_rectf = this.AutoSize ? new RectangleF(this.ClientRectangle.X + scale_padding.Left, this.ClientRectangle.Y + scale_padding.Top, this.ClientRectangle.Width - scale_padding.Left - scale_padding.Right, this.ClientRectangle.Height - scale_padding.Top - scale_padding.Bottom) : this.ClientRectangle;
            SizeF scale_box_sizef = new SizeF(this.BoxRadius * 2 * DotsPerInchHelper.DPIScale.XScale, this.BoxRadius * 2 * DotsPerInchHelper.DPIScale.YScale);
            SizeF scale_text_sizef = this.GetTextSize();

            switch (this.TextAlign)
            {
                case TextAligns.Top:
                case TextAligns.Bottom:
                    {
                        if (this.textAlign == TextAligns.Top)
                        {
                            this.text_rect = new RectangleF(
                               scale_rectf.X + (scale_rectf.Width - scale_text_sizef.Width) / 2f,
                               scale_rectf.Y + (scale_rectf.Height - scale_text_sizef.Height - this.BoxSpace * DotsPerInchHelper.DPIScale.YScale - scale_box_sizef.Height) / 2f,
                               scale_text_sizef.Width,
                               scale_text_sizef.Height);

                            this.box_rect = new RectangleF(
                               scale_rectf.X + (scale_rectf.Width - scale_box_sizef.Width) / 2f,
                               this.text_rect.Bottom + this.BoxSpace * DotsPerInchHelper.DPIScale.YScale,
                               scale_box_sizef.Width,
                               scale_box_sizef.Height);
                        }
                        else if (this.textAlign == TextAligns.Bottom)
                        {
                            this.box_rect = new RectangleF(
                               scale_rectf.X + (scale_rectf.Width - scale_box_sizef.Width) / 2f,
                               scale_rectf.Y + (scale_rectf.Height - scale_box_sizef.Height - this.BoxSpace * DotsPerInchHelper.DPIScale.YScale - scale_text_sizef.Height) / 2f,
                               scale_box_sizef.Width,
                               scale_box_sizef.Height);

                            this.text_rect = new RectangleF(
                               scale_rectf.X + (scale_rectf.Width - scale_text_sizef.Width) / 2f,
                               this.box_rect.Bottom + this.BoxSpace * DotsPerInchHelper.DPIScale.YScale,
                               scale_text_sizef.Width,
                               scale_text_sizef.Height);
                        }
                        break;
                    }
                case TextAligns.Left:
                case TextAligns.Right:
                    {
                        if (this.textAlign == TextAligns.Right)
                        {
                            this.box_rect = new RectangleF(
                               scale_rectf.X,
                               scale_rectf.Y + (scale_rectf.Height - scale_box_sizef.Height) / 2f,
                               scale_box_sizef.Width,
                               scale_box_sizef.Height);

                            this.text_rect = new RectangleF(
                               this.box_rect.Right + this.BoxSpace * DotsPerInchHelper.DPIScale.XScale,
                               scale_rectf.Y + (scale_rectf.Height - scale_text_sizef.Height) / 2f,
                               scale_text_sizef.Width,
                               scale_text_sizef.Height);
                        }
                        else if (this.textAlign == TextAligns.Left)
                        {
                            this.text_rect = new RectangleF(
                               scale_rectf.X,
                               scale_rectf.Y + (scale_rectf.Height - scale_text_sizef.Height) / 2f,
                               scale_text_sizef.Width,
                               scale_text_sizef.Height);

                            this.box_rect = new RectangleF(
                               this.text_rect.Right + this.BoxSpace * DotsPerInchHelper.DPIScale.XScale,
                               scale_rectf.Y + (scale_rectf.Height - scale_box_sizef.Height) / 2f,
                               scale_box_sizef.Width,
                               scale_box_sizef.Height);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 更新控件size
        /// </summary>
        private void UpdateAutoSize()
        {
            if (!this.AutoSize && ((this.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right) || (this.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == (AnchorStyles.Top | AnchorStyles.Bottom)))
                return;

            Padding scale_padding = new Padding((int)(this.Padding.Left * DotsPerInchHelper.DPIScale.XScale), (int)(this.Padding.Top * DotsPerInchHelper.DPIScale.YScale), (int)(this.Padding.Right * DotsPerInchHelper.DPIScale.XScale), (int)(this.Padding.Bottom * DotsPerInchHelper.DPIScale.YScale));

            SizeF scale_box_sizef = new SizeF(this.boxRadius * 2 * DotsPerInchHelper.DPIScale.XScale, this.boxRadius * 2 * DotsPerInchHelper.DPIScale.YScale);
            SizeF scale_text_sizef = this.GetTextSize();
            SizeF size = SizeF.Empty;
            float text_border = 2;

            switch (this.TextAlign)
            {
                case TextAligns.Top:
                case TextAligns.Bottom:
                    {
                        size = new SizeF(Math.Max(scale_box_sizef.Width, scale_text_sizef.Width) + scale_padding.Left + scale_padding.Right + text_border * 2, scale_box_sizef.Height + this.BoxSpace * DotsPerInchHelper.DPIScale.YScale + scale_text_sizef.Height + scale_padding.Top + scale_padding.Bottom + text_border * 2);
                        break;
                    }
                case TextAligns.Left:
                case TextAligns.Right:
                    {
                        size = new SizeF(scale_box_sizef.Width + this.BoxSpace * DotsPerInchHelper.DPIScale.XScale + scale_text_sizef.Width + scale_padding.Left + scale_padding.Right + text_border * 2, Math.Max(scale_box_sizef.Height, scale_text_sizef.Height) + scale_padding.Top + scale_padding.Bottom + text_border * 2);
                        break;
                    }
            }

            this.SetBounds(this.Location.X, this.Location.Y, (int)size.Width, (int)size.Height, BoundsSpecified.Size);
        }

        /// <summary>
        /// 获取文本size
        /// </summary>
        /// <returns></returns>
        private SizeF GetTextSize()
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.Handle, out g, out hDC);

            SizeF text_sizef = g.MeasureString(this.Text, this.Font, int.MaxValue, StringFormat.GenericTypographic);
            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);

            return text_sizef;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageListRecreateHandle(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
                return;
            this.Invalidate();
        }

        /// <summary>
        /// 控件分离ImageList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetachImageList(object sender, EventArgs e)
        {
            this.ImageList = (ImageList)null;
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetState()
        {
            if (this.ThreeState == false)
            {
                this.Checked = !this.Checked;
            }
            else
            {
                if (this.CheckState == CheckStates.UnChecked)
                {
                    this.CheckState = CheckStates.PartChecked;
                }
                else if (this.CheckState == CheckStates.PartChecked)
                {
                    this.CheckState = CheckStates.Checked;
                }
                else if (this.CheckState == CheckStates.Checked)
                {
                    this.CheckState = CheckStates.UnChecked;
                }
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// ImageList自定义索引管理
        /// </summary>
        [Description("ImageList自定义索引管理")]
        public class Indexer
        {
            private string key = string.Empty;
            private int index = -1;
            private bool useIntegerIndex = true;
            private ImageList imageList;

            public virtual ImageList ImageList
            {
                get
                {
                    return this.imageList;
                }
                set
                {
                    this.imageList = value;
                }
            }

            public virtual string Key
            {
                get
                {
                    return this.key;
                }
                set
                {
                    this.index = -1;
                    this.key = value == null ? string.Empty : value;
                    this.useIntegerIndex = false;
                }
            }

            public virtual int Index
            {
                get
                {
                    return this.index;
                }
                set
                {
                    this.key = string.Empty;
                    this.index = value;
                    this.useIntegerIndex = true;
                }
            }

            public virtual int ActualIndex
            {
                get
                {
                    if (this.useIntegerIndex)
                        return this.Index;
                    if (this.ImageList != null)
                        return this.ImageList.Images.IndexOfKey(this.Key);
                    return -1;
                }
            }
        }

        /// <summary>
        /// 控件状态更改事件参数
        /// </summary>
        [Description("控件状态更改事件参数")]
        public class CheckedChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 控件状态
            /// </summary>
            [Description("控件状态")]
            public bool Checked { get; set; }
        }

        /// <summary>
        /// 控件状态更改事件参数
        /// </summary>
        [Description("控件状态更改事件参数")]
        public class CheckStateChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 控件状态
            /// </summary>
            [Description("控件状态")]
            public CheckStates CheckState { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        [Description("文本对齐方式")]
        public enum TextAligns
        {
            /// <summary>
            /// 顶部
            /// </summary>
            Top,
            /// <summary>
            /// 右边
            /// </summary>
            Right,
            /// <summary>
            /// 底部
            /// </summary>
            Bottom,
            /// <summary>
            /// 左边
            /// </summary>
            Left
        }

        /// <summary>
        /// 图标的类型
        /// </summary>
        [Description("图标的类型")]
        public enum BoxTypes
        {
            /// <summary>
            /// 默认符号
            /// </summary>
            DefaultChar,
            /// <summary>
            /// 自定义图片
            /// </summary>
            CustomImage
        }

        /// <summary>
        /// 控件风格
        /// </summary>
        [Description("控件风格")]
        public enum Styles
        {
            /// <summary>
            /// 默认
            /// </summary>
            Default,
            /// <summary>
            /// 按钮
            /// </summary>
            Button
        }

        /// <summary>
        /// 更改状态操作范围
        /// </summary>
        [Description("更改状态操作范围")]
        public enum OperateScopes
        {
            /// <summary>
            /// 图标范围
            /// </summary>
            Box,
            /// <summary>
            /// (图标和文本)范围
            /// </summary>
            BoxText
        }

        /// <summary>
        /// 控件选中状态
        /// </summary>
        [Description("控件选中状态")]
        public enum CheckStates
        {
            /// <summary>
            /// 选中
            /// </summary>
            Checked,
            /// <summary>
            /// 未选中
            /// </summary>
            UnChecked,
            /// <summary>
            /// 部分选中
            /// </summary>
            PartChecked
        }

        #endregion
    }
}
