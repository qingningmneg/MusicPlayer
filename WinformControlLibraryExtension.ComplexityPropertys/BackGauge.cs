
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
    ///边距 
    /// </summary>
    [Description("边距")]
    [Serializable]
    [TypeConverterAttribute(typeof(BackGaugeConverter))]
    public struct BackGauge
    {
        #region 字段

        private bool _all;
        private int _left;
        private int _right;

        public static readonly BackGauge Empty = new BackGauge(0);

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
                return this._all ? this._left : -1;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all != true || this._left != value)
                {
                    this._all = true;
                    this._left = this._right = value;
                }
            }
        }

        /// <summary>
        /// 左边边距
        /// </summary>
        [Description("左边边距")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int Left
        {
            get
            {
                if (this._all)
                {
                    return this._left;
                }
                return this._left;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._left != value)
                {
                    this._all = false;
                    this._left = value;
                }
            }
        }

        /// <summary>
        /// 右边边距
        /// </summary>
        [Description("右边边距")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int Right
        {
            get
            {
                if (this._all)
                {
                    return this._left;
                }
                return this._right;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (this._all || this._right != value)
                {
                    this._all = false;
                    this._right = value;
                }
            }
        }

        #endregion

        #region  构造

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all">全部边距</param>
        public BackGauge(int all)
        {
            this._all = true;
            this._left = this._right = all;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left">左边边距</param>
        /// <param name="right">右边边距</param>
        public BackGauge(int left, int right)
        {
            this._left = left;
            this._right = right;
            this._all = (this._left == this._right);
        }

        #endregion

        #region 运算符重载

        /// <summary>
        /// 判断两个边距对象设置是否一样
        /// </summary>
        /// <param name="rc1"></param>
        /// <param name="rc2"></param>
        /// <returns></returns>
        [Description("判断两个边距对象设置是否一样")]
        public static bool operator ==(BackGauge rc1, BackGauge rc2)
        {
            return rc1.Left == rc2.Left && rc1.Right == rc2.Right;
        }

        /// <summary>
        /// 判断两个边距对象设置是否不一样
        /// </summary>
        /// <param name="rc1"></param>
        /// <param name="rc2"></param>
        /// <returns></returns>
        [Description("判断两个边距对象设置是否不一样")]
        public static bool operator !=(BackGauge rc1, BackGauge rc2)
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
            return this.Left ^ RotateLeft(this.Right, 8);
        }

        /// <summary>
        /// 判断是否和该对象的引用是一样
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [Description("判断是否和该对象的引用是一样")]
        public override bool Equals(object other)
        {
            if (other is BackGauge)
            {
                return ((BackGauge)other) == this;
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
            return "{Left=" + this.Left.ToString(CultureInfo.CurrentCulture) + ",Right=" + this.Right.ToString(CultureInfo.CurrentCulture) + "}";
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
        public static int RotateLeft(int value, int nBits)
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
