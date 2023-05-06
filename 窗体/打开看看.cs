using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 窗体
{
    internal class 打开看看
    {
        /* 请先读完
        一、未完成功能和bug
        项目的主要功能是窗体,分为服务端(ningmeng的服务端),客户端(窗体下的客户端文件夹),管理端(窗体下的管理端文件夹)
        客户端未完成的:
        1.歌单功能(FrmMusicList),
        2.登录功能(登陆注册文件夹下(记住密码等没有完成)),
        3.音乐图片(图片已经可以上传了,但是没有使用),
        4.设置功能(FrmSetUp窗体),
       
        客户端遗留bug:二次登陆时会无法登录,主要问题是while无状态,进入死循环,服务端返回的信息并没有被捕捉到

        管理端:功能挺简单的,只有上传等等,没有完成的功能应该是在服务端防音乐吧

        服务端:使用的是 Socket 通讯协议 用的是TCP协议,即三次握手
        bug：不知道客户端的原因是否为服务端造成的

        二、使用控件:
        花木兰控件库:可能需要授权,要去他的作者下留言
        DEV控件,需要安装DEV控件

        如果要预览花木兰控件库请到mulan文件夹下:启动winformDemo预览文件
        需要预览DEV控件就需要到它的官网下查看了

        数据库:
        1.文件在\花木兰控件库\hml\Data下,数据库的备注在Navicat的文件下

        三、介绍：
        客户端:
        1.SqlHelper文件夹只是摆设,真正的处理文件方式在服务端中
        2.播放音乐的方法在ningmengMusic类中
        3.多个方法并没有用到
        4.FrmFavoriteMusic   是客户端我喜欢的音乐窗体
        5.FrmHistoryPlay     是客户端最近播放窗体
        6.FrmMainFroms       是客户端的主窗体
        7.FrmMainHome        是客户端推荐歌单窗体
        8.FrmMusicList       是客户端音乐列表窗体
        9.FrmSetUp           是客户端设置窗体

        注:客户端和服务端之间沟通是将 byte[]的第一个数据改成需要的字符来实现互相辨认需要什么方法的
        
        服务端:
        1.FrmLogin           是服务端的主窗体 (主功能,点击开启监听功能,其余功能可能无法使用)
        2.FrmOpen            是确定服务端需要什么样的端口
        3.FrmSendout         是无效窗体

        管理端:
        1.FrmAdminMainFrom   管理端的主窗体
        2.FrmAdminMusic      音乐管理页面
        3.FrmUploadFile      上传文件页面
        */
    }
}
