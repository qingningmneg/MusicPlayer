using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ningmeng服务端
{
    public static class IPorPort
    {
        private static string _ip = "";

        public static string ip
        {
            get { return _ip; }//输出
            set { _ip = value; }//输入
        }

        private static string _port = "";

        public static string port
        {
            get { return _port; }//输出
            set { _port = value; }//输入
        }
    }
}
