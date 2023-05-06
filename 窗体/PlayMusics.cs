using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 窗体
{
    internal class PlayMusics
    {
        public static TcpClient client = null;//与服务器得连接
        public static NetworkStream stream = null;//发送和接收数据

        private static string _FilePath;
        /// <summary>
        /// 储存当前的文件位置和文件名字
        /// </summary>
        public static string FilePath
        {
            //每次存储都会重新读一遍json里面的文件位置
            get
            {
                var Musice_Path = "";

                var Path = AppDomain.CurrentDomain.BaseDirectory + "MusicPath.json";//路径  
                if (System.IO.File.Exists(Path) == true)
                {
                    dynamic json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(Path));
                    Musice_Path = json.Musice_Path ?? "";
                }
                return Musice_Path + "\\" + _FilePath;
            }//输出
            set { _FilePath = value; }//输入
        }

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);
    }

    #region 音乐接口
    /// <summary>
    /// 改变声音
    /// </summary>
    public interface IResult_Volume
    {
        StringBuilder Result_Volume();
    }

    /// <summary>
    /// 返回音乐时间接口
    /// </summary>
    public interface IResult_time
    {
        StringBuilder Result_time(string FilePath);
    }

    /// <summary>
    /// 放音乐接口
    /// </summary>
    public interface IMusinc
    {
        void PlayNmusinc(string FilePath);
    }

    /// <summary>
    /// 停止音乐播放接口
    /// </summary>
    public interface IStopMusic
    {
        void StopMusic();
    }

    /// <summary>
    /// 指定位置播放
    /// </summary>
    public interface IMusic_play
    {
        void Music_play(int lPosition);
    }

    /// <summary>
    /// 继续播放
    /// </summary>
    public interface I_continue
    {
        void _continue();
    }

    /// <summary>
    /// 暂停播放
    /// </summary>
    public interface IPause
    {
        void Pause();
    }

    /// <summary>
    /// 改变音量
    /// </summary>
    public interface IMusic_volume
    {
        void Music_volume(int Result_Volume);
    }

    /// <summary>
    /// 重复播放音乐
    /// </summary>
    public interface IPlayMusic_Repeat
    {
        void PlayMusic_Repeat(string FilePath);
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    public interface IPlayMusic
    {
        StringBuilder PlayMusic(string FilePath);
    }
    #endregion

    #region 音乐类
    /// <summary>
    /// 放音乐
    /// </summary>
    public class ClassPlayNmusinc : IMusinc
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        public void PlayNmusinc(string FilePath)
        {
            mciSendString(@"close temp_alias", null, 0, new IntPtr());
            mciSendString(@"open """ + FilePath + @""" alias temp_alias", null, 0, new IntPtr());
            mciSendString("play temp_alias repeat", null, 0, new IntPtr());
        }
    }

    /// <summary>
    /// 返回音乐时间
    /// </summary>
    public class ClassResult_time : IResult_time
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 返回音乐的时间
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public StringBuilder Result_time(string FilePath)
        {
            StringBuilder Result = new StringBuilder();

            mciSendString(@"close temp_music2", null, 0, new IntPtr());
            mciSendString(@"open """ + FilePath + @""" alias temp_music2", null, 0, new IntPtr());

            mciSendString("set temp_music2 time format milliseconds", null, 0, new IntPtr());
            mciSendString("status temp_music2 length", Result, 50, new IntPtr());
            mciSendString(@"close temp_music2", null, 0, new IntPtr());

            return Result;
        }
    }

    /// <summary>
    /// 返回声音
    /// </summary>
    public class ClassResult_Volume : IResult_Volume
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 返回声音
        /// </summary>
        /// <returns></returns>
        public StringBuilder Result_Volume()
        {
            StringBuilder Result = new StringBuilder();

            mciSendString("status temp_music volume", Result, 50, new IntPtr());

            return Result;
        }
    }

    /// <summary>
    /// 停止当前音乐播放
    /// </summary>
    public class ClassStopMusic : IStopMusic
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 停止当前音乐播放
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public void StopMusic()
        {
            mciSendString(@"close temp_music", null, 0, new IntPtr());
        }
    }

    /// <summary>
    /// 指定位置开始播放
    /// </summary>
    public class ClassMusic_play : IMusic_play
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 从指定的播放位置播放音乐
        /// </summary>
        /// <param name="lPosition">播放的毫秒</param>
        public void Music_play(int lPosition)
        {
            StringBuilder Result = new StringBuilder();
            mciSendString($"seek temp_music to {lPosition}", null, 0, new IntPtr());
            mciSendString(@"play temp_music ", Result, 50, new IntPtr());
        }
    }

    /// <summary>
    /// 继续播放
    /// </summary>
    public class Class_continue : I_continue
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 继续
        /// </summary>
        public void _continue()
        {
            mciSendString("resume temp_music ", null, 0, new IntPtr());
        }
    }

    /// <summary>
    /// 暂停播放
    /// </summary>
    public class ClassPause : IPause
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            mciSendString("pause temp_music ", null, 0, new IntPtr());
        }
    }

    /// <summary>
    /// 改变音量
    /// </summary>
    public class ClassMusic_volume : IMusic_volume
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 更改音量
        /// </summary>
        /// <param name="Result_Volume"></param>
        public void Music_volume(int Result_Volume)
        {
            mciSendString($@" setaudio temp_music volume to {Result_Volume}", null, 50, new IntPtr());
        }
    }

    /// <summary>
    /// 重复播放音乐
    /// </summary>
    public class ClassPlayMusic_Repeat : IPlayMusic_Repeat
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// 播放音乐文件(重复)
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public void PlayMusic_Repeat(string FilePath)
        {
            mciSendString(@"close temp_music", null, 0, new IntPtr());
            mciSendString(@"open " + FilePath + " alias temp_music", null, 0, new IntPtr());
            mciSendString(@"play temp_music repeat", null, 0, new IntPtr());
        }
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    public class ClassPlayMusic: IPlayMusic
    {
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, StringBuilder buffer, uint uReturnLength, IntPtr hwndCallback);


        /// <summary>
        /// 播放音乐文件
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public StringBuilder PlayMusic(string FilePath)
        {
            StringBuilder Result = new StringBuilder();

            mciSendString(@"close temp_music", null, 0, new IntPtr());
            mciSendString(@"open """ + FilePath + @""" alias temp_music", null, 0, new IntPtr());

            mciSendString(@"play temp_music", null, 50, new IntPtr());

            mciSendString(@"close temp_music3", null, 0, new IntPtr());
            mciSendString(@"open """ + FilePath + @""" alias temp_music3", null, 0, new IntPtr());

            mciSendString("set temp_music3 time format milliseconds", null, 0, new IntPtr());
            mciSendString("status temp_music3 length", Result, 50, new IntPtr());

            return Result;
        }
    }
    #endregion
}
