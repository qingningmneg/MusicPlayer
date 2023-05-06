using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using DevExpress.XtraEditors;

namespace ningmeng服务端
{
    public partial class Frmsendout : XtraForm
    {
        public Frmsendout()
        {
            InitializeComponent();
        }

        public Frmsendout(Socket socketWatch, Dictionary<string, Socket> dicsocket, string aa) : this()
        {
            this.socketWatch = socketWatch;
            this.dicsocket = dicsocket;
            this.aa = aa;
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private Socket socketWatch;
        private Dictionary<string, Socket> dicsocket;
        private string aa;

        private void btn_Click(object sender, EventArgs e)
        {
            ofd.InitialDirectory = @"C:\Users";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();

            this.txtFile.Text = ofd.FileName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string path = txtFile.Text;

            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];

                int r = fsRead.Read(buffer, 0, buffer.Length);

                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                byte[] newbuffer = list.ToArray();

                dicsocket[aa].Send(newbuffer, 0, r + 1, SocketFlags.None);
            }
        }
    }
}
