using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinformDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            WinformControlLibraryExtension.DotsPerInchHelper.DPIApply();//DPI的缩放由程序自己处理

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DemoForm());
        }
    }
}
