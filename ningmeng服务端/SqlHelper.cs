

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ningmeng服务端
{
    internal static class SqlHelper
    {
        public static string user_no = "";//缓存
        public static string user_guid = "";//缓存

        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string strConn = "server=.;uid=sa;pwd=sa;database='ningmengMusic'";

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(this string strSql)
        {
            DataTable Result = new DataTable();

            var conn = new SqlConnection(strConn);
            var dba = new SqlDataAdapter(strSql, conn);

            conn.Open();

            dba.Fill(Result);

            conn.Close();

            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(this string strSql, SqlParameter[] parameters)
        {
            DataTable Result = new DataTable();

            var conn = new SqlConnection(strConn);
            var dba = new SqlDataAdapter(strSql, conn);
            dba.SelectCommand.Parameters.AddRange(parameters);

            conn.Open();

            dba.Fill(Result);

            conn.Close();

            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(this string strSql, Dictionary<string, object> parameters)
        {
            DataTable Result = new DataTable();

            var conn = new SqlConnection(strConn);
            var dba = new SqlDataAdapter(strSql, conn);
            var cmd = dba.SelectCommand;
            foreach (var item in parameters)
            {
                var pam = new SqlParameter(item.Key, item.Value);
                cmd.Parameters.Add(pam);
            }
            conn.Open();

            dba.Fill(Result);

            conn.Close();

            return Result;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="strSql"></param>
        public static void ExecuteNonQuery(this string strSql)
        {
            var conn = new SqlConnection(strConn);
            var cmd = new SqlCommand(strSql, conn);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        public static void ExecuteNonQuery(this string strSql, SqlParameter[] parameters)
        {
            var conn = new SqlConnection(strConn);
            var cmd = new SqlCommand(strSql, conn);
            cmd.Parameters.AddRange(parameters);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        public static void ExecuteNonQuery(this string strSql, Dictionary<string, object> parameters)
        {
            var conn = new SqlConnection(strConn);
            var cmd = new SqlCommand(strSql, conn);
            foreach (var item in parameters)
            {
                var pam = new SqlParameter(item.Key, item.Value);
                cmd.Parameters.Add(pam);
            }

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        /// <summary>
        /// OBJ To String
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public static string RtxBytesToString(this object obj)
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

        /// <summary>
        /// RtxStr To Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] RtxToBytes(this string str)
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

        /// <summary>
        /// 将指定对象序列化为二进制。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <param name="iscompress">是否压缩。</param>
        public static byte[] SerializeDataTableToBytes(DataTable dt, bool iscompress)
        {
            dt.RemotingFormat = System.Data.SerializationFormat.Binary;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ms.Position = 0;
                System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (iscompress)
                {
                    using (System.IO.Compression.DeflateStream ds = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Compress)) bf.Serialize(ds, dt);
                }
                else
                {
                    bf.Serialize(ms, dt);
                }
                return ms.ToArray();
            }
        }
    }
}

