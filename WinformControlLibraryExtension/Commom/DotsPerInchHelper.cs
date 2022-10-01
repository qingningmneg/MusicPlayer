
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 系统缩放比例
    /// </summary>
    [Description("系统缩放比例")]
    public class DotsPerInchHelper
    {
        #region 新增属性

        private static DotsPerInch dPIScale = new DotsPerInch() { XScale = 0f, YScale = 0f };
        /// <summary>
        /// 系统缩放比例
        /// </summary>
        [Description("系统缩放比例")]
        public static DotsPerInch DPIScale
        {
            get
            {
                if (dPIScale.XScale == 0f && dPIScale.YScale == 0f)
                {
                    if (Environment.OSVersion.Version.Major >= 6)
                    {
                        WindowNavigate.SetProcessDPIAware();// DPI的缩放由程序自己处理
                    }

                    var hdc = WindowNavigate.GetDC(WindowNavigate.GetDesktopWindow());

                    DotsPerInch dpi = new DotsPerInch();
                    dpi.XScale = WindowNavigate.GetDeviceCaps(hdc, LOGPIXELSX) / 96f;
                    dpi.YScale = WindowNavigate.GetDeviceCaps(hdc, LOGPIXELSY) / 96f;
                    dPIScale = dpi;

                    WindowNavigate.ReleaseDC(IntPtr.Zero, hdc);
                }
                return dPIScale;
            }
        }

        #endregion

        #region 扩展

        private const int LOGPIXELSX = 88;
        private const int LOGPIXELSY = 90;

        #endregion

        #region 公开方法

        /// <summary>
        /// DPI的缩放由程序自己处理
        /// </summary>
        public static void DPIApply()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                WindowNavigate.SetProcessDPIAware();
            }
        }

        #endregion
    }

    /// <summary>
    /// 96 dpi 作为100% 的缩放比率
    /// </summary>
    public struct DotsPerInch
    {
        public float XScale;
        public float YScale;
    }
}
