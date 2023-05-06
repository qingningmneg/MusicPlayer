using DevExpress.XtraEditors;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmSetUp : XtraForm
    {
        /// <summary>
        /// 设置窗体
        /// </summary>
        public FrmSetUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//居中

            var a = AppDomain.CurrentDomain.BaseDirectory + "MusicPath.json";//路径  
            if (System.IO.File.Exists(a) == true)
            {
                dynamic json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(a));
                this.txtMusicPath.Text = json.Musice_Path ?? "";
            }
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            var Musice_Path = this.txtMusicPath.Text;// C://suer


            var json = new { Musice_Path = Musice_Path };
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "MusicPath.json", JsonConvert.SerializeObject(json));
        }
    }
}
