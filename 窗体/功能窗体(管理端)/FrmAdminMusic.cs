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
    public partial class FrmAdminMusic : XtraForm
    {
        DataTable dt = new DataTable();//音乐数据

        public FrmAdminMusic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmUploadFile();
            frm.ShowDialog();
            this.Show();
            this.LoadData();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAdminMusic_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        void LoadData()
        {
            dt = SqlHelper.ExecuteQuery($@"select * from Music");

            gridControl.DataSource = dt;
        }

        /// <summary>
        /// 编辑音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdataMusic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row == null) MessageBox.Show("请选择要编辑的行");
            else
            {
                var guid = Convert.ToString(Row["guid"]);
                var frm = new FrmUploadFile("编辑", guid);
                frm.ShowDialog();
                this.Show();
                this.LoadData();
            }
        }

        /// <summary>
        /// 编辑文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row == null) MessageBox.Show("请选择要编辑的行");
            else
            {
                var guid = Convert.ToString(Row["guid"]);

                var frm = new FrmUploadFile("编辑", guid);
                frm.ShowDialog();
                this.Show();
                this.LoadData();
            }
        }

        /// <summary>
        /// 启用音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row == null) MessageBox.Show("请选择要禁用的行");
            else
            {
                var guid = Convert.ToString(Row["guid"]);

                SqlHelper.ExecuteNonQuery($@"update Music set is_Enable='启用' where guid='{guid}'");
                this.LoadData();
            }
        }

        /// <summary>
        /// 禁用音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row == null) MessageBox.Show("请选择要禁用的行");
            else
            {
                var guid = Convert.ToString(Row["guid"]);

                SqlHelper.ExecuteNonQuery($@"update Music set is_Enable='禁用' where guid='{guid}'");
                this.LoadData();
            }
        }
    }
}
