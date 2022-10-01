
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
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using WinformControlLibraryExtension.ComplexityPropertys;

namespace WinformControlLibraryExtension
{
    /// <summary>
    ///圆角
    /// </summary>
    [Description("圆角")]
    [Serializable]

   [TypeConverterAttribute(typeof(RoundedCornerConverter))]
    public class RoundedCorner
    {
        #region 字段

        private bool _all;
        private int _leftTop;
        private int _rightTop;
        private int _rightBottom;
        private int _leftBottom;

        public static readonly RoundedCorner Empty = new RoundedCorner(0);

        #endregion

        #region 属性

        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                return this._all ? this._leftTop : -1;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all != true || this._leftTop != value)
                {
                    this._all = true;
                    this._leftTop = this._rightTop = this._rightBottom = this._leftBottom = value;
                }
            }
        }

        /// <summary>
        /// 左上角
        /// </summary>
        [Description("左上角")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int LeftTop
        {
            get
            {
                if (this._all)
                {
                    return this._leftTop;
                }
                return this._leftTop;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._leftTop != value)
                {
                    this._all = false;
                    this._leftTop = value;
                }
            }
        }

        /// <summary>
        /// 右上角
        /// </summary>
        [Description("右上角")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int RightTop
        {
            get
            {
                if (this._all)
                {
                    return this._leftTop;
                }
                return this._rightTop;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._rightTop != value)
                {
                    this._all = false;
                    this._rightTop = value;
                }
            }
        }

        /// <summary>
        /// 右下角
        /// </summary>
        [Description("右下角")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int RightBottom
        {
            get
            {
                if (this._all)
                {
                    return this._leftTop;
                }
                return this._rightBottom;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._rightBottom != value)
                {
                    this._all = false;
                    this._rightBottom = value;
                }
            }
        }

        /// <summary>
        /// 左下角
        /// </summary>
        [Description("左下角")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int LeftBottom
        {
            get
            {
                if (this._all)
                {
                    return this._leftTop;
                }
                return this._leftBottom;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._leftBottom != value)
                {
                    this._all = false;
                    this._leftBottom = value;
                }
            }
        }

        #endregion

        #region  构造

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all">全部圆角</param>
        public RoundedCorner(int all)
        {
            this._all = true;
            this._leftTop = this._rightTop = this._rightBottom = this._leftBottom = all;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftTop">左上角</param>
        /// <param name="rightTop">右上角</param>
        /// <param name="rightBottom">右下角</param>
        /// <param name="leftBottom">左下角</param>
        public RoundedCorner(int leftTop, int rightTop, int rightBottom, int leftBottom)
        {
            this._leftTop = leftTop;
            this._rightTop = rightTop;
            this._rightBottom = rightBottom;
            this._leftBottom = leftBottom;
            this._all = (this._leftTop == this._rightTop && this._leftTop == this._rightBottom && this._leftTop == this._leftBottom);
        }

        #endregion

        #region 运算符重载

        /// <summary>
        /// 判断两个圆角对象设置是否一样
        /// </summary>
        /// <param name="rc1"></param>
        /// <param name="rc2"></param>
        /// <returns></returns>
        [Description("判断两个圆角对象设置是否一样")]
        public static bool operator ==(RoundedCorner rc1, RoundedCorner rc2)
        {
            return rc1.LeftTop == rc2.LeftTop && rc1.RightTop == rc2.RightTop && rc1.RightBottom == rc2.RightBottom && rc1.LeftBottom == rc2.LeftBottom;
        }

        /// <summary>
        /// 判断两个圆角对象设置是否不一样
        /// </summary>
        /// <param name="rc1"></param>
        /// <param name="rc2"></param>
        /// <returns></returns>
        [Description("判断两个圆角对象设置是否不一样")]
        public static bool operator !=(RoundedCorner rc1, RoundedCorner rc2)
        {
            return !(rc1 == rc2);
        }

        #endregion

        #region 重写

        /// <summary>
        /// 获取该对象的哈希值（参考源码）
        /// </summary>
        /// <returns></returns>
        [Description("获取该对象的哈希值（参考源码）")]
        public override int GetHashCode()
        {
            return this.LeftTop ^ RotateLeftTop(this.RightTop, 8) ^ RotateLeftTop(this.RightBottom, 16) ^ RotateLeftTop(this.LeftBottom, 24);
        }

        /// <summary>
        /// 判断是否和该对象的引用是一样
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [Description("判断是否和该对象的引用是一样")]
        public override bool Equals(object other)
        {
            if (other is RoundedCorner)
            {
                return ((RoundedCorner)other) == this;
            }
            return false;
        }

        /// <summary>
        /// 把该对象转换成字符串
        /// </summary>
        /// <returns></returns>
        [Description("把该对象转换成字符串")]
        public override string ToString()
        {
            return "{LeftTop=" + this.LeftTop.ToString(CultureInfo.CurrentCulture) + ",RightTop=" + this.RightTop.ToString(CultureInfo.CurrentCulture) + ",RightBottom=" + this.RightBottom.ToString(CultureInfo.CurrentCulture) + ",LeftBottom=" + this.LeftBottom.ToString(CultureInfo.CurrentCulture) + "}";
        }

        #endregion

        #region 方法

        /// <summary>
        /// 计算哈希值（参考源码）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nBits"></param>
        /// <returns></returns>
        [Description("计算哈希值（参考源码）")]
        public static int RotateLeftTop(int value, int nBits)
        {
            nBits = nBits % 32;
            return value << nBits | (value >> (32 - nBits));
        }

        /// <summary>
        /// 是否应该使用All设置初始化对象
        /// </summary>
        /// <returns></returns>
        [Description("是否应该使用All设置初始化对象")]
        public bool ShouldSerializeAll()
        {
            return this._all;
        }

        #endregion
    }

}
