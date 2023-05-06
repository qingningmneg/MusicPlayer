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
    public partial class FrmMainHome : Form
    {
        FrmMainFroms frmMainFroms = new FrmMainFroms();

        public FrmMainHome(FrmMainFroms frmMainFroms)
        {
            InitializeComponent();
            imageWhirligigExt.Play();

            this.frmMainFroms = frmMainFroms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainHome_Load(object sender, EventArgs e)
        {
            this.imageWhirligigExt.Size = new System.Drawing.Size(800, 206);

            this.panel.Size = new System.Drawing.Size(800, 1000);
            this.is_Enable_Music();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void LoadData(DataTable dataTable)
        {
            gridControl.DataSource = null;

            Program.FrmMainHome_dt = dataTable;

            gridControl.DataSource = Program.FrmMainHome_dt;
        }

        /// <summary>
        /// 双击播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row != null)
            {
                var Paht_Hash = Convert.ToString(Row["file_hast"]);
                this.frmMainFroms.bofang(Paht_Hash, Program.FrmMainHome_dt);
            }
        }

        /// <summary>
        /// 刷新最近播放页面
        /// </summary>
        /// <returns></returns>
        public void is_Enable_Music()
        {
            try
            {
                string str = $"FrmMainHome音乐列表";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }
    }
}
