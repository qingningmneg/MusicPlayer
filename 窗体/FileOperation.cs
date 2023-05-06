using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace 窗体
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public class FileOperation
    {
        /// <summary>
        /// 返回文件的哈希值
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetHash(string path)
        {
            var hash = SHA1.Create();
            var stream = new FileStream(path, FileMode.Open);
            byte[] hashByte = hash.ComputeHash(stream);
            stream.Close();
            return BitConverter.ToString(hashByte).Replace("-", "");
        }
    }
}

