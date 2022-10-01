博客：[https://www.cnblogs.com/tlmbem/](https://www.cnblogs.com/tlmbem/)控件的介绍。

邮箱：1252578118@qq.com,有问题可以发到这个邮箱，我有空会回复你。

qq交流群： **180744253** 


# 花木兰控件库(开源)

#### 版本更新历史：
         
**6.0.0.0       [2022-09-14]**  
WinformControlLibraryExtension 
WinformDemo 
本次版本改动很大，要更新的人要注意，主要修改DateExt.cs文件，重新写过“DateExt”控件和“DatePickerExt” 控件。这两个控件不再兼容旧版本，也就是更新后可能导致你以前使用过旧日期控件的项目都会报错，需要你手动删除所有错误代码（主要都是颜色、对齐方式、控件显示格式功能）重新编译你的项目。
这次的改动主要修复日期控件 修改字体大小时输入框文本显示错位，日期面板的时间面板空白情况。同时把控件的颜色方案简化了，有部分属性名称删除或修改过，还删除了一些没用事件，简化控件的代码，
修改画笔管理方式，因为之前画笔管理方式会占用大量资源。控件CUP占用率降低三分二。 在控件赋值、最大最小值、按时间格式截取时间的逻辑也尽量规范起来。同时也为日期输入框控件添加新功能。
                   
  
         
**5.4.5.4       [2022-07-25]**  
WinformControlLibraryExtension 
修复 RadianMenuHandleExt.cs 全局模式下关闭程序因释放导致程序报错,和隐藏。                    
                   
                  
**5.4.4.4       [2022-06-23]**  
WinformControlLibraryExtension 
修复 FormExt.cs 鼠标更改大小时窗口失去焦点问题。                    
                   
            
**5.4.4.3       [2022-06-21]**  
WinformControlLibraryExtension 
修复 SlideMenuPanelExt.cs 过滤功能无法切换到中文问题。                    
                   
         
**5.4.4.2       [2022-06-09]**  
WinformControlLibraryExtension 
修复 ThermometerExt.cs 温度控件最小值最大值大于0时，值背景色范围错误问题。                    
                
             
**5.4.3.2       [2022-06-08]**  
WinformControlLibraryExtension 
修复 AnomalyButton.cs 自定义形状按钮文本颜色问题。                    
                
               
**5.4.3.1       [2022-05-24]**  
WinformControlLibraryExtension         
WinformDemo       
修改 颜色控件、日期控件高dpi下错位问题，修正分层窗体资源释放。                    
                
         
**5.4.2.1       [2022-05-18]**  
WinformControlLibraryExtension.ComplexityPropertys       
WinformControlLibraryExtension         
WinformDemo       
新增WinformControlLibraryExtension.ComplexityPropertys自定义复杂属性项目。该项目必须以编译后的dll方式引入，不能在其他项目直接引用该项目。否则VS试图设计器保存时汇报无法序列化保存的错。
修改 AnomalyButton.cs、AnomalyButtonDesigner.cs、ShapePointsAnchorEditor.cs  自定义形状按钮控件添加高分屏功能。                     
                
         
**5.3.1.1       [2022-05-16]**  
WinformControlLibraryExtension         
WinformDemo       
新增 AnomalyButton.cs、AnomalyButtonDesigner.cs、ShapePointsAnchorEditor.cs  新增自定义形状按钮控件，该控件可以在VS可视化编辑器里面操作修改控件形状。                     
                
         
**5.2.1.1       [2022-04-29]**  
WinformControlLibraryExtension         
WinformDemo       
修改 ListBoxExt.cs  修复继承基类应该为Control。                     
                   
         
**5.2.1.1       [2022-04-28]**  
WinformControlLibraryExtension         
WinformDemo       
修改 FormExt.cs  修复带阴影边框美化窗体最大化时覆盖任务栏问题。同事添加属性最大化是否覆盖任务栏。 目前该窗体不支持作为子窗体方式使用。                     
                      
         
**5.2.0.1       [2022-04-18]**  
WinformControlLibraryExtension         
WinformDemo       
修改 NavigationBarExt.cs 删除旧版所有事件，新增新事件                      
修改 旧版部分控件在运行时会保存临时信息到资源文件导致控件画面异常。                
            
         
**5.1.0.1       [2022-03-25]**  
WinformControlLibraryExtension         
WinformDemo       
修改 MultidropSlideBarExt.cs 多点滑块控件负数错误问题           
     
         
**5.0.0.1       [2022-03-18]**         
WinformDemo       
更新demo例子     
         
**5.0.0.0       [2022-03-13]**   
WinformControlLibraryExtension      
WinformDemo      
WcleAnimationLibrary      
（注意）本次版本修改主要是为了适应高分屏绘制，如果要从低版本升级到5.0.0.0 版本，要测试好你的程序不变形才确定要不要更新。       
修改 FormExt.cs 无边框窗体这次改动很大，主要增加阴影边框让鼠标可以通过阴影边框进行拖动改变窗体大小。这是利用添加分层窗体方式实现的。          
新增 HRulerExt.cs 横向刻度尺控件、VRulerExt.cs 纵向刻度尺控件、LabelExt.cs带滚动条文本控件 。       
修改 ToolTipExt 隐藏部分属性、ProcedureExt 内边距计算修改过、ControlCommom 修正 圆角换算、边框换算。对所有控件绘制计算加入缩放比例。      

                 
**4.7.5.11       [2021-07-13]**   
WinformControlLibraryExtension      
修复了RadioButtonExt.cs CheckedChanged事件没有反应问题。 



#### 介绍
提示 **不提倡没有任何控件基础的人使用该控件库，只适合于那些会改造控件的人群使用**

使用教程：   
1.  编译WinformControlLibraryExtension程序程序集后把生成的 WcleAnimationLibrary.dll、WinformControlLibraryExtension.ComplexityPropertys.dll、WinformControlLibraryExtension.dll 3个程序集引用到你的项目，再把WinformControlLibraryExtension.dll 添加到你的工具箱就可以使用。
2.  在高分辨率系统上建议把系统的缩放比例设置在100%情况下使用试图设计器拖放控件设计窗体。不然软件界面在其他机器上使用时会发现控件Size偏大。
3.  如果要让控件在系统缩放比例大于100%情况下控件清晰度也要尖锐，要在你的程序Program.cs文件加上   WinformControlLibraryExtension.DotsPerInchHelper.DPIApply();//DPI的缩放由程序自己处理。

- 基于  **C#（语言） 4.0**  、 **VS2019**  、 **Net Framework 4.0(不包括Net Framework 4.0 Client Profile)**  开发的Winform控件库。为了兼容性采用了C#（语言） 4.0版本，低版本VS也可以编译该项目。整个控件控除了动画函数由Silverlight提取出来和ColorEditorExt.cs颜色面板视图设计器扩展器在网上例子修改而来，其他都是自己在原生控件基础上写的，没有使用任何第三方库。所以放心有没有侵犯他人著作权的问题。
- 这套控件库原本在博客上都是单个控件发布的，这次在gitee整体的发布。由于原来控件都是独立开发，大量的控件使用到滑动的效果，导致定时器消耗过多，所以在整体发布前对大部分控件做了修改，不排除还有bug，所以这套控件库适合有基本基础控件开发的人使用。控件本身并不复杂，像window消息使用的比较小，主要都是重写Paint方法实现。还有就是所有的控件目前都是采用整体刷新方式绘制，你可以继续优化控件。这些控件都是我平常无聊时写的，没有在真正的项目上使用过，你要是使用在自己的项目中，最好先测试下控件有没有bug，为什么这么说呢，因为我在开发这些控件时就会遇到过控件有bug导致在操作视图设计器时VS奔溃自动关闭的现象。开发可化视图设计器的控件还是挺麻烦的，你必须要了VS 视图设计器的流程原理。

- 关于授权问题有以下 **3种** 方式：（以下都不提供BUG解决服务，我也没有刻意留下bug）
1.  **30元** (人民币)永久授权(适用以后所有版本)，控件库可以集成在你的商业系统中使用但控件库不能用于二次贩售和授权他人，对于二次开发看下面2的情况。
2.  **免费** 永久授权(适用以后所有版本)，你可以用于学习但禁止任何商用。但是如果你在这些控件的基础上进行二次开发，当你的控件库的功能都比我免费授权的源码功能强大一倍后还有代码相似度在一半以下，你可以独立发布贩售你的源码，但要在你的源码版权上加上一句描述“该控件库是以花木兰控件库为基础开发而来的”，如果你的二次开发导致你的控件库源码和我免费授权的源码有90%的非相似度就可以不用加刚才说的那句描述，因为我承认一个成功的借鉴就是原创。

3.  **免费** 永久授权(适用以后所有版本)，可以免费让控件库集成在你的商业系统中使用，但控件库不能用于二次贩售和授权他人。还有你的系统中要用到该控件库的文件都要加上我的版权描述，特别是木兰诗不能删掉，不要问为什么。

 关于申请授权的话简单点在评论那里发表"**我要申请第*种方式授权**"的文字有个记录就可以了。

虽然不是专业的控件库，但还是请尊重下劳动付出，说真你们的工钱最少也四五百一天，30元在广州也最多吃顿好点的中午饭。既然你能看到介绍末尾，请点个赞。

![输入图片说明](https://images.gitee.com/uploads/images/2020/1029/095745_34ae7c16_7974552.png "Snipaste_2020-10-29_09-57-25.png")

WinformDemo.exe
![输入图片说明](https://images.gitee.com/uploads/images/2021/0507/202704_c7d7bf84_7974552.gif "13.gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/113721_b73e4a1c_7974552.png "撕纸效果_Snipaste_2020-11-10_11-35-48.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114026_9faa9cb4_7974552.gif "zz (26).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114324_8eb63922_7974552.gif "zz (27).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114653_c7406475_7974552.gif "zz (28).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/115054_e8c3a933_7974552.gif "zz (29).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/115342_867c8db8_7974552.gif "zz (30).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1108/150809_633488b3_7974552.gif "zz (24).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1113/100304_cbb30d0b_7974552.png "Snipaste_2020-11-13_10-00-50.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0108/195533_13988778_7974552.png "Snipaste_2021-01-08_19-54-54.png")