using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 窗体
{
    /// <summary>
    /// 操作string
    /// </summary>
    internal class OperationString
    {
        public IBytesToString _iBytesToString;
        public IRtxToByte _iRtxToByte;

        /// <summary>
        /// 二进制转string
        /// </summary>
        /// <param name="obj">二进制数据</param>
        /// <returns></returns>
        public string RtxBytesToString(object obj)
        {
            var Result = _iBytesToString.RtxBytesToString(obj);
            return Result;
        }

        /// <summary>
        /// string转二进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] RtxToBytes(string str)
        {
            var Result = _iRtxToByte.RtxToByte(str);
            return Result;
        }
    }

    /// <summary>
    /// 二进制转string类型
    /// </summary>
    public interface IBytesToString
    {
        string RtxBytesToString(object obj);
    }

    /// <summary>
    /// 将二进制转换成string类型
    /// </summary>
    public class BytesToStringClass : IBytesToString
    {
        /// <summary>
        /// OBJ To String
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public string RtxBytesToString(object obj)
        {
            if (obj is byte[])
            {
                if (obj == default)
                    return default;
                else
                {
                    try
                    {
                        return Encoding.UTF8.GetString((byte[])obj);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        return null;
                    }
                }
            }
            return default;
        }
    }

    /// <summary>
    /// string转byte[]
    /// </summary>
    public interface IRtxToByte
    {
        byte[] RtxToByte(string str);
    }

    /// <summary>
    /// string转byte[]
    /// </summary>
    public class RtxToByteClass : IRtxToByte
    {
        /// <summary>
        /// RtxStr To Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] RtxToByte(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default;
            else
            {
                try
                {
                    return Encoding.UTF8.GetBytes(str);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return default;
                }
            }
        }
    }
}
