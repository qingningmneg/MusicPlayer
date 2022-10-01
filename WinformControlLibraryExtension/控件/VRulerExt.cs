
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
    /// 纵向尺子控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("纵向尺子控件")]
    [DefaultProperty("MasterDivideThickness")]
    public class VRulerExt : Control
    {
        #region 停用事件

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

        private bool loseCharShow = false;
        /// <summary>
        /// 刻度值负号是否显示
        /// </summary>
        [Description("刻度值负号是否显示")]
        [DefaultValue(false)]
        public bool LoseCharShow
        {
            get
            {
                return this.loseCharShow;
            }
            set
            {
                if (this.loseCharShow == value)
                    return;

                this.loseCharShow = value;
                this.Invalidate();
            }
        }

        private float realityHeight = 500f;
        /// <summary>
        /// 内容真实宽度
        /// </summary>
        [Description("内容真实宽度")]
        [DefaultValue(500f)]
        public float RealityHeight
        {
            get
            {
                return this.realityHeight;
            }
            set
            {
                if (this.realityHeight == value)
                    return;

                this.realityHeight = value;
                this.Invalidate();
            }
        }

        private float displayHeight = 500f;
        /// <summary>
        /// 内容真实宽度对应在面板显示宽度
        /// </summary>
        [Description("内容真实宽度对应在面板显示宽度")]
        [DefaultValue(500f)]
        public float DisplayHeight
        {
            get
            {
                return this.displayHeight;
            }
            set
            {
                if (this.displayHeight == value)
                    return;

                this.displayHeight = value;
                this.Invalidate();
            }
        }

        private int masterStartPoint = 0;
        /// <summary>
        /// 控件0刻度的开始坐标
        /// </summary>
        [Description("控件0刻度的开始坐标")]
        [DefaultValue(0)]
        public int MasterStartPoint
        {
            get
            {
                return this.masterStartPoint;
            }
            set
            {
                if (this.masterStartPoint == value)
                    return;

                this.masterStartPoint = value;
                this.Invalidate();
            }
        }

        private int masterDivideThickness = 40;
        /// <summary>
        /// 一个主刻度预设多少个像素
        /// </summary>
        [Description("一个主刻度预设多少个像素")]
        [DefaultValue(40)]
        public int MasterDivideThickness
        {
            get
            {
                return this.masterDivideThickness;
            }
            set
            {
                if (this.masterDivideThickness == value || value <= 0)
                    return;

                this.masterDivideThickness = value;
                this.Invalidate();
            }
        }

        private float masterDivideMagnification = 10;
        /// <summary>
        /// 主刻度倍数（主刻度为该数的倍数）
        /// </summary>
        [Description("主刻度倍数（主刻度为该数的倍数）")]
        [DefaultValue(10)]
        public float MasterDivideMagnification
        {
            get
            {
                return this.masterDivideMagnification;
            }
            set
            {
                if (this.masterDivideMagnification == value || value == 0)
                    return;

                this.masterDivideMagnification = value;
                this.Invalidate();
            }
        }

        private Color masterDivideColor = Color.FromArgb(142, 142, 145);
        /// <summary>
        /// 主刻度颜色
        /// </summary>
        [Description("主刻度颜色")]
        [DefaultValue(typeof(Color), "142, 142, 145")]
        public Color MasterDivideColor
        {
            get
            {
                return this.masterDivideColor;
            }
            set
            {
                if (this.masterDivideColor == value)
                    return;

                this.masterDivideColor = value;
                this.Invalidate();
            }
        }



        private Color secondDivideColor = Color.FromArgb(142, 142, 145);
        /// <summary>
        /// 次刻度颜色
        /// </summary>
        [Description("次刻度颜色")]
        [DefaultValue(typeof(Color), "142, 142, 145")]
        public Color SecondDivideColor
        {
            get
            {
                return this.secondDivideColor;
            }
            set
            {
                if (this.secondDivideColor == value)
                    return;

                this.secondDivideColor = value;
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
            get {
                return new Size(40,200);
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size MaximumSize
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
        public new Size MinimumSize
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

        public VRulerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen master_pen = new Pen(this.MasterDivideColor, 1);
            Pen second_pen = new Pen(this.SecondDivideColor, 1);
            SolidBrush text_sb = new SolidBrush(this.ForeColor);
            StringFormat text_sf = new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical, LineAlignment = StringAlignment.Near };

            float ruler_extent_ratio = this.RealityHeight / this.DisplayHeight;//真实内容和尺子比例
            float main_scale_interval_px = this.MasterDivideThickness * DotsPerInchHelper.DPIScale.XScale;//定义40格像素为一个主刻度

            float single_main_scale_value = main_scale_interval_px * ruler_extent_ratio;//40格像素为一个主刻度的刻度数值大小

            if (single_main_scale_value % MasterDivideMagnification != 0)
            {
                single_main_scale_value += MasterDivideMagnification - (single_main_scale_value % MasterDivideMagnification);
                main_scale_interval_px = single_main_scale_value / ruler_extent_ratio;
            }

            int minor_scale_count = 5; //一个主刻度分成多少个次刻度
            float minor_scale_pixel = main_scale_interval_px / (float)minor_scale_count;//一个次刻度为多少个像素

            g.DrawLine(master_pen, new Point(this.ClientRectangle.Right - 1, this.ClientRectangle.Top), new Point(this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom));

            for (int i = 0; ; i++)//正向尺子
            {
                //主刻度
                float current_main_scale_y = this.MasterStartPoint + i * main_scale_interval_px;

                //次刻度
                for (int k = 0; k < minor_scale_count; k++)
                {
                    float current_minor_scale_y = current_main_scale_y + k * minor_scale_pixel;
                    g.DrawLine(second_pen, new PointF(this.ClientRectangle.Right - this.ClientRectangle.Width / 3, current_minor_scale_y), new PointF(this.ClientRectangle.Right, current_minor_scale_y));
                }

                g.DrawLine(master_pen, new PointF(this.ClientRectangle.Left, current_main_scale_y), new PointF(this.ClientRectangle.Right, current_main_scale_y));
                //主刻度文本
                string current_main_scale_str = ((int)(i * single_main_scale_value)).ToString();
                g.DrawString(current_main_scale_str, this.Font, text_sb, new PointF(this.ClientRectangle.Left, current_main_scale_y + 2), text_sf);

                if (this.MasterStartPoint + (i + 1) * main_scale_interval_px >= this.ClientRectangle.Bottom)
                {
                    break;
                }
            }

            if (this.MasterStartPoint > 0)//反向尺子
            {
                for (int i = 0; ; i++)
                {
                    //主刻度
                    float current_main_scale_y = this.MasterStartPoint - i * main_scale_interval_px;

                    //次刻度
                    for (int k = 0; k < minor_scale_count; k++)
                    {
                        float current_minor_scale_y = current_main_scale_y - k * minor_scale_pixel;
                        g.DrawLine(second_pen, new PointF(this.ClientRectangle.Right - this.ClientRectangle.Width / 3, current_minor_scale_y), new PointF(this.ClientRectangle.Right, current_minor_scale_y));
                    }

                    g.DrawLine(master_pen, new PointF(this.ClientRectangle.Left, current_main_scale_y), new PointF(this.ClientRectangle.Right, current_main_scale_y));
                    //主刻度文本
                    string current_main_scale_str = (this.LoseCharShow && i > 0 ? "-" : "") + ((int)(i * single_main_scale_value)).ToString();
                    g.DrawString(current_main_scale_str, this.Font, text_sb, new PointF(this.ClientRectangle.Left, current_main_scale_y + 2), text_sf);

                    if (this.MasterStartPoint - i * main_scale_interval_px <= 0)
                    {
                        break;
                    }
                }
            }

            master_pen.Dispose();
            second_pen.Dispose();
            text_sb.Dispose();
            text_sf.Dispose();
        }

        #endregion
    }
}
