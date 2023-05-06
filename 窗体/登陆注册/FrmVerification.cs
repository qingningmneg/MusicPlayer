using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmVerification : XtraForm
    {
        public FrmVerification()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//居中
        }

        private void slideValidExt_Valided(object sender, WinformControlLibraryExtension.JigsawValidExt.ValidedEventArgs e)
        {
            if (e.Pass == true)
            {
                Program.e_Pass_yanzheng = "通过";
                this.Close();
            }
        }

        private void FrmVerification_Load(object sender, EventArgs e)
        {
            this.slideValidExt.SlideType = WinformControlLibraryExtension.JigsawValidExt.SlideTypes.One;
        }
    }
}
