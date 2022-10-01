
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 控件工具类
    /// </summary>
    public static class ControlCommom
    {

        /// <summary>
        /// 转换成圆角
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="radius">圆角半径的大小</param>
        /// <returns></returns>
        public static GraphicsPath TransformCircular(RectangleF rectf, float radius = 0)
        {
            return TransformCircular(rectf, radius, radius, radius, radius);
        }

        /// <summary>
        /// 转换成圆角
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="leftTopRadius">左上角</param>
        /// <param name="rightTopRadius">右上角</param>
        /// <param name="rightBottomRadius">右下角</param>
        /// <param name="leftBottomRadius">左下角</param>
        /// <returns></returns>
        public static GraphicsPath TransformCircular(RectangleF rectf, float leftTopRadius = 0f, float rightTopRadius = 0f, float rightBottomRadius = 0f, float leftBottomRadius = 0f)
        {
            leftTopRadius = Math.Abs(leftTopRadius);
            rightTopRadius = Math.Abs(rightTopRadius);
            rightBottomRadius = Math.Abs(rightBottomRadius);
            leftBottomRadius = Math.Abs(leftBottomRadius);

            PointF leftTop_x = new PointF(rectf.Left, rectf.Top);
            PointF leftTop_y = new PointF(rectf.Left, rectf.Top);
            if (leftTopRadius > 0)
            {
                leftTop_x = new PointF(rectf.Left + leftTopRadius, rectf.Top);
                leftTop_y = new PointF(rectf.Left, rectf.Top + leftTopRadius);
            }

            PointF rightTop_x = new PointF(rectf.Right, rectf.Top);
            PointF rightTop_y = new PointF(rectf.Right, rectf.Top);
            if (rightTopRadius > 0)
            {
                rightTop_x = new PointF(rectf.Right - rightTopRadius, rectf.Top);
                rightTop_y = new PointF(rectf.Right, rectf.Top + rightTopRadius);
            }

            PointF rightBottom_x = new PointF(rectf.Right, rectf.Bottom);
            PointF rightBottom_y = new PointF(rectf.Right, rectf.Bottom);
            if (rightBottomRadius > 0)
            {
                rightBottom_x = new PointF(rectf.Right - rightBottomRadius, rectf.Bottom);
                rightBottom_y = new PointF(rectf.Right, rectf.Bottom - rightBottomRadius);
            }

            PointF leftBottom_x = new PointF(rectf.Left, rectf.Bottom);
            PointF leftBottom_y = new PointF(rectf.Left, rectf.Bottom);
            if (leftBottomRadius > 0)
            {
                leftBottom_x = new PointF(rectf.Left + leftBottomRadius, rectf.Bottom);
                leftBottom_y = new PointF(rectf.Left, rectf.Bottom - leftBottomRadius);
            }

            GraphicsPath gp = new GraphicsPath();

            if (leftTopRadius > 0)
            {
                RectangleF lefttop_rect = new RectangleF(rectf.Left, rectf.Top, leftTopRadius * 2, leftTopRadius * 2);
                gp.AddArc(lefttop_rect, 180, 90);
            }
            gp.AddLine(leftTop_x, rightTop_x);

            if (rightTopRadius > 0)
            {
                RectangleF righttop_rect = new RectangleF(rectf.Right - rightTopRadius * 2, rectf.Top, rightTopRadius * 2, rightTopRadius * 2);
                gp.AddArc(righttop_rect, 270, 90);
            }
            gp.AddLine(rightTop_y, rightBottom_y);

            if (rightBottomRadius > 0)
            {
                RectangleF rightbottom_rect = new RectangleF(rectf.Right - rightBottomRadius * 2, rectf.Bottom - rightBottomRadius * 2, rightBottomRadius * 2, rightBottomRadius * 2);
                gp.AddArc(rightbottom_rect, 0, 90);
            }
            gp.AddLine(rightBottom_x, leftBottom_x);

            if (leftBottomRadius > 0)
            {
                RectangleF rightbottom_rect = new RectangleF(rectf.Left, rectf.Bottom - leftBottomRadius * 2, leftBottomRadius * 2, leftBottomRadius * 2);
                gp.AddArc(rightbottom_rect, 90, 90);
            }
            gp.AddLine(leftBottom_y, leftTop_y);

            gp.CloseAllFigures();
            return gp;
        }

        /// <summary>
        /// 根据画笔大小计算出真是rectf
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="pen">画笔大小大小</param>
        /// <param name="pen">画笔对齐方式</param>
        /// <returns></returns>
        public static RectangleF TransformRectangleF(RectangleF rectf, float pen, PenAlignment alignment = PenAlignment.Center)
        {
            if (pen <= 0)
            {
                return rectf;
            }

            RectangleF result = new RectangleF();
            if (alignment == PenAlignment.Center || alignment == PenAlignment.Left || alignment == PenAlignment.Right || alignment == PenAlignment.Outset)
            {
                result.Width = rectf.Width - pen;
                result.Height = rectf.Height - pen;
                result.X = rectf.X + ((int)pen) / 2;
                result.Y = rectf.Y + ((int)pen) / 2;
            }
            else if (alignment == PenAlignment.Inset)
            {

                if (pen > 0 && pen < 2)
                {
                    result.Width = rectf.Width - 1;
                    result.Height = rectf.Height - 1;
                }
                else
                {
                    result.Width = rectf.Width;
                    result.Height = rectf.Height;
                }

                result.X = rectf.X;
                result.Y = rectf.Y;
            }

            return result;
        }

        /// <summary>
        /// 倒影变换
        /// </summary>
        /// <param name="bmp">原图片</param>
        /// <param name="reflectionTop">倒影边距</param>
        /// <param name="reflectionBrightness">明亮度</param>
        /// <param name="reflectionTransparentStart">倒影开始透明度</param>
        /// <param name="reflectionTransparentEnd">倒影结束透明度</param>
        /// <param name="reflectionHeight">倒影高度</param>
        /// <returns></returns>
        public static Bitmap TransformReflection(Bitmap bmp, int reflectionTop = 10, int reflectionBrightness = -50, int reflectionTransparentStart = 200, int reflectionTransparentEnd = -0, int reflectionHeight = 50)
        {
            /// <summary>
            /// 图片最终高度
            /// </summary>
            int finallyHeight = bmp.Height + reflectionTop + reflectionHeight;

            Color pixel;
            int transparentGradient = 0;//透明梯度
            transparentGradient = (reflectionTransparentEnd - reflectionTransparentStart) / reflectionHeight;
            if (transparentGradient == 0)
                transparentGradient = 1;

            Bitmap result = new Bitmap(bmp.Width, finallyHeight);
            Graphics graphic = Graphics.FromImage(result);
            graphic.DrawImage(bmp, new RectangleF(0, 0, bmp.Width, bmp.Height));
            graphic.Dispose();

            for (int y = 0; y < reflectionHeight; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    pixel = bmp.GetPixel(x, bmp.Height - 1 - y);
                    int a = VerifyRGB(reflectionTransparentStart + y * transparentGradient);
                    if (pixel.A == 0 || pixel.A < a)
                    {
                        result.SetPixel(x, bmp.Height - 1 + reflectionTop + y, pixel);
                    }
                    else
                    {
                        int r = VerifyRGB(pixel.R + reflectionBrightness);
                        int g = VerifyRGB(pixel.G + reflectionBrightness);
                        int b = VerifyRGB(pixel.B + reflectionBrightness);
                        result.SetPixel(x, bmp.Height - 1 + reflectionTop + y, Color.FromArgb(a, r, g, b));
                    }
                }
            }
            return result;
        }

        ///// <summary>
        ///// 获取DPI缩放比例
        ///// </summary>
        ///// <param name="autoHighAdaptive">是否返回高分辨率</param>
        ///// <param name="g">控件所属Graphics</param>
        ///// <returns></returns>
        //public static DotsPerInch GetDPIScale(bool autoHighAdaptive, Graphics g)
        //{
        //    if (!autoHighAdaptive)
        //    {
        //        return new DotsPerInch() { XScale = 1f, YScale = 1f };
        //    }

        //    float default_dpi = 96;
        //    DotsPerInch dpi = new DotsPerInch();
        //    dpi.XScale = g.DpiX / default_dpi;
        //    dpi.YScale = g.DpiY / default_dpi;
        //    return dpi;
        //}

        ///// <summary>
        ///// 获取DPI缩放比例
        ///// </summary>
        ///// <param name="autoHighAdaptive">是否返回高分辨率</param>
        ///// <param name="handle">控件句柄</param>
        ///// <returns></returns>
        //public static DotsPerInch GetDPIScale(bool autoHighAdaptive, IntPtr handle)
        //{
        //    if (!autoHighAdaptive)
        //    {
        //        return new DotsPerInch() { XScale = 1f, YScale = 1f };
        //    }

        //    Graphics g = GetGraphics(handle);
        //    float default_dpi = 96;
        //    DotsPerInch dpi = new DotsPerInch();
        //    dpi.XScale = g.DpiX / default_dpi;
        //    dpi.YScale = g.DpiY / default_dpi;
        //    g.Dispose();
        //    return dpi;
        //}

        /// <summary>
        /// 获取指定窗口（包括非工作区）的Graphics
        /// </summary>
        /// <param name="handle">指定窗口的handle</param>
        /// <param name="g">返回g</param>
        /// <param name="hDC">返回hDC</param>
        public static void GetWindowGraphics(IntPtr handle, out Graphics g, out IntPtr hDC)
        {
            hDC = WindowNavigate.GetWindowDC(handle);
            g = Graphics.FromHdc(hDC);
        }

        /// <summary>
        /// 获取指定窗口（只包括工作区）的Graphics
        /// </summary>
        /// <param name="handle">指定窗口的handle</param>
        /// <param name="g">返回g</param>
        /// <param name="hDC">返回hDC</param>
        public static void GetWindowClientGraphics(IntPtr handle, out Graphics g, out IntPtr hDC)
        {
            hDC = WindowNavigate.GetDC(handle);
            g = Graphics.FromHdc(hDC);
        }

        /// <summary>
        /// 检查RGB值ed有效范围
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static int VerifyRGB(int rgb)
        {
            if (rgb < 0)
                return 0;
            if (rgb > 255)
                return 255;
            return rgb;
        }

        /// <summary>
        /// 计算指定角度的坐标
        /// </summary>
        /// <param name="center">圆心坐标</param>
        /// <param name="radius">圆半径</param>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static PointF CalculatePointForAngle(PointF center, float radius, float angle)
        {
            if (radius == 0)
                return center;

            float w = 0;
            float h = 0;
            if (angle <= 90)
            {
                w = radius * (float)Math.Cos(Math.PI / 180 * angle);
                h = radius * (float)Math.Sin(Math.PI / 180 * angle);
            }
            else if (angle <= 180)
            {
                w = -radius * (float)Math.Sin(Math.PI / 180 * (angle - 90));
                h = radius * (float)Math.Cos(Math.PI / 180 * (angle - 90));

            }
            else if (angle <= 270)
            {
                w = -radius * (float)Math.Cos(Math.PI / 180 * (angle - 180));
                h = -radius * (float)Math.Sin(Math.PI / 180 * (angle - 180));
            }
            else
            {
                w = radius * (float)Math.Sin(Math.PI / 180 * (angle - 270));
                h = -radius * (float)Math.Cos(Math.PI / 180 * (angle - 270));

            }
            return new PointF(center.X + w, center.Y + h);
        }

        /// <summary>
        /// 根据画笔大小转换rectf
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="pen">画笔大小大小</param>
        /// <returns></returns>
        public static RectangleF TransformRectangleByPen(RectangleF rectf, float pen)
        {
            RectangleF result = new RectangleF();
            result.Width = rectf.Width - (pen < 1 ? 0 : pen);
            result.Height = rectf.Height - (pen < 1 ? 0 : pen);
            result.X = rectf.X + (float)(pen / 2);
            result.Y = rectf.Y + (float)(pen / 2);
            return result;
        }

        /// <summary>
        /// 结构转指针
        /// </summary>
        /// <typeparam name="T">结构类型</typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IntPtr StructToIntPtr<T>(T info)
        {
            int size = Marshal.SizeOf(info);
            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(info, intPtr, true);
            return intPtr;
        }

        /// <summary>
        /// 指针转结构
        /// </summary>
        /// <typeparam name="T">结构类型</typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static T IntPtrToStruct<T>(IntPtr info)
        {
            return (T)Marshal.PtrToStructure(info, typeof(T));
        }

    }

    public static class ImageCommom
    {
        private static ColorMatrix disabledImageColorMatrix;
        /// <summary>
        /// 用于创建禁用状态灰色图片（NET源码拷贝）
        /// </summary>
        private static ColorMatrix DisabledImageColorMatrix
        {
            get
            {
                if (disabledImageColorMatrix == null)
                {
                    float[][] greyscale = new float[5][];
                    greyscale[0] = new float[5] { 0.2125f, 0.2125f, 0.2125f, 0, 0 };
                    greyscale[1] = new float[5] { 0.2577f, 0.2577f, 0.2577f, 0, 0 };
                    greyscale[2] = new float[5] { 0.0361f, 0.0361f, 0.0361f, 0, 0 };
                    greyscale[3] = new float[5] { 0, 0, 0, 1, 0 };
                    greyscale[4] = new float[5] { 0.38f, 0.38f, 0.38f, 0, 1 };

                    float[][] transparency = new float[5][];
                    transparency[0] = new float[5] { 1, 0, 0, 0, 0 };
                    transparency[1] = new float[5] { 0, 1, 0, 0, 0 };
                    transparency[2] = new float[5] { 0, 0, 1, 0, 0 };
                    transparency[3] = new float[5] { 0, 0, 0, .7F, 0 };
                    transparency[4] = new float[5] { 0, 0, 0, 0, 0 };


                    int size = 5;
                    float[][] result = new float[size][];
                    for (int row = 0; row < size; row++)
                    {
                        result[row] = new float[size];
                    }

                    float[] column = new float[size];
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            column[k] = transparency[k][j];
                        }
                        for (int i = 0; i < size; i++)
                        {
                            float[] row = greyscale[i];
                            float s = 0;
                            for (int k = 0; k < size; k++)
                            {
                                s += row[k] * column[k];
                            }
                            result[i][j] = s;
                        }
                    }

                    disabledImageColorMatrix = new ColorMatrix(result);

                }

                return disabledImageColorMatrix;
            }
        }

        /// <summary>
        /// 创建禁用状态灰色图片（NET源码拷贝）
        /// </summary>
        /// <param name="normalImage">要处理的图片</param>
        /// <returns></returns>
        public static Image CreateDisabledImage(Image normalImage)
        {
            ImageAttributes imgAttrib = new ImageAttributes();
            imgAttrib.ClearColorKey();
            imgAttrib.SetColorMatrix(DisabledImageColorMatrix);

            Size size = normalImage.Size;
            Bitmap disabledBitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(disabledBitmap);

            graphics.DrawImage(normalImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imgAttrib);
            graphics.Dispose();

            return disabledBitmap;
        }
    }
}
