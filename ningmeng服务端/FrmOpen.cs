using DevExpress.XtraEditors;

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

namespace ningmeng服务端
{
    public partial class FrmOpen : XtraForm
    {
        public FrmOpen()
        {
            InitializeComponent();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            IPorPort.ip = this.txtIp.Text.Trim();
            IPorPort.port = this.txtPort.Text.Trim();

            this.Close();
        }
    }
}
