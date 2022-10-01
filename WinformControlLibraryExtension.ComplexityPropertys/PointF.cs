
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
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WinformControlLibraryExtension.ComplexityPropertys
{
    /// <summary>
    /// 表示在二维平面中定义点的浮点 x 和 y 坐标的有序对。
    /// </summary>
    [TypeConverter(typeof(PointFConverter))]
    [ComVisible(true)]
    [Serializable]
    public struct PointF
    {
        public static readonly PointF Empty;
        private float x;
        private float y;

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                if ((double)this.x == 0.0)
                {
                    return (double)this.y == 0.0;
                }
                return false;
            }
        }

        public float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public PointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static PointF operator +(PointF pt, Size sz)
        {
            return PointF.Add(pt, sz);
        }

        public static PointF operator -(PointF pt, Size sz)
        {
            return PointF.Subtract(pt, sz);
        }

        public static PointF operator +(PointF pt, SizeF sz)
        {
            return PointF.Add(pt, sz);
        }

        public static PointF operator -(PointF pt, SizeF sz)
        {
            return PointF.Subtract(pt, sz);
        }

        public static bool operator ==(PointF left, PointF right)
        {
            if ((double)left.X == (double)right.X)
            {
                return (double)left.Y == (double)right.Y;
            }
            return false;
        }

        public static bool operator !=(PointF left, PointF right)
        {
            return !(left == right);
        }

        public static PointF Add(PointF pt, Size sz)
        {
            return new PointF(pt.X + (float)sz.Width, pt.Y + (float)sz.Height);
        }

        public static PointF Subtract(PointF pt, Size sz)
        {
            return new PointF(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
        }

        public static PointF Add(PointF pt, SizeF sz)
        {
            return new PointF(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static PointF Subtract(PointF pt, SizeF sz)
        {
            return new PointF(pt.X - sz.Width, pt.Y - sz.Height);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF))
            {
                return false;
            }
            PointF pointF = (PointF)obj;
            if ((double)pointF.X == (double)this.X && (double)pointF.Y == (double)this.Y)
            {
                return pointF.GetType().Equals(this.GetType());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{X=" + X.ToString(CultureInfo.CurrentCulture) + ",Y=" + Y.ToString(CultureInfo.CurrentCulture) + "}";
        }

        /// <summary>
        /// System.Drawing.PointF 转换成 WinformControlLibraryExtension.ComplexityPropertys.PointF
        /// </summary>
        /// <returns></returns>
        [Description("System.Drawing.PointF 转换成 WinformControlLibraryExtension.ComplexityPropertys.PointF")]
        public static PointF ConvertFrom(System.Drawing.PointF pointf)
        {
            return new WinformControlLibraryExtension.ComplexityPropertys.PointF(pointf.X, pointf.Y);
        }

        /// <summary>
        /// WinformControlLibraryExtension.ComplexityPropertys.PointF 转换成 System.Drawing.PointF
        /// </summary>
        /// <returns></returns>
        [Description("WinformControlLibraryExtension.ComplexityPropertys.PointF 转换成 System.Drawing.PointF")]
        public System.Drawing.PointF ConvertTo()
        {
            return new System.Drawing.PointF(x, y);
        }
    }
}
