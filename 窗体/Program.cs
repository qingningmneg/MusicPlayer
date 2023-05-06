using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    internal static class Program
    {
        public static string user_no = "";//缓存
        public static string user_guid = "";//缓存
        

        /// <summary>
        /// 判断是否音乐是暂停还是播放
        /// </summary>
        public static bool btnStart_switch = true;//判断是否音乐是暂停还是播放

        /// <summary>
        /// 判断是否为暂停的函数,0为暂停,1为新歌
        /// </summary>
        public static int btnStart_int = 1;//判断是否为暂停的函数

        public static DataTable FrmFavoriteMusic_dt = new DataTable();
        public static DataTable FrmHistoryPlay_dt = new DataTable();
        public static DataTable FrmMainHome_dt = new DataTable();

        public static string e_Pass_yanzheng = "";//验证是否通过

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static dynamic ToDynamic(this string str)
        {
            return JsonConvert.DeserializeObject<dynamic>(str);
        }

        /// <summary>
        /// 将二进制反序列化为指定的类型。
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型。</typeparam>
        /// <param name="bytes">要反序列化的二进制数据。</param>
        /// <param name="isdecompress">是否解压缩。</param>
        public static DataTable DeserializeDataTableFromBytes(byte[] bytes, bool isdecompress, int r)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes, 1, r - 1))
            {
                System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (isdecompress)
                {
                    using (System.IO.Compression.DeflateStream ds = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress))
                    {
                        return (DataTable)bf.Deserialize(ds);
                    }
                }
                else
                {
                    return (DataTable)bf.Deserialize(ms);
                }
            }
        }

        /// <summary>
        /// 将二进制反序列化为指定的类型。
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型。</typeparam>
        /// <param name="bytes">要反序列化的二进制数据。</param>
        /// <param name="isdecompress">是否解压缩。</param>
        public static DataTable DeserializeDataTableFromBytes(byte[] bytes, bool isdecompress)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
            {
                System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (isdecompress)
                {
                    using (System.IO.Compression.DeflateStream ds = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress))
                    {
                        return (DataTable)bf.Deserialize(ds);
                    }
                }
                else
                {
                    return (DataTable)bf.Deserialize(ms);
                }
            }
        }
    }
}
