using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmMusicList : Form
    {
        private FrmMainFroms frmMainFroms;

        public FrmMusicList()
        {
            InitializeComponent();
        }

        public FrmMusicList(FrmMainFroms frmMainFroms)
        {
            this.frmMainFroms = frmMainFroms;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMusicList_Load(object sender, EventArgs e)
        {

        }
    }
}
