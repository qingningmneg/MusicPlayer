
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
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WinformControlLibraryExtension.ComplexityPropertys
{
    /// <summary>
    /// 圆角转换器
    /// </summary>
    [Description("圆角转换器")]
    public class RoundedCornerConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string valueStr = value as string;
            if (valueStr != null)
            {
                valueStr = valueStr.Trim();

                if (valueStr.Length == 0)
                {
                    return null;
                }
                else
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    char sep = culture.TextInfo.ListSeparator[0];
                    string[] tokens = valueStr.Split(new char[] { sep });
                    int[] values = new int[tokens.Length];
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = (int)intConverter.ConvertFromString(context, culture, tokens[i]);
                    }
                    if (values.Length == 4)
                    {
                        return new RoundedCorner(values[0], values[1], values[2], values[3]);
                    }
                    else
                    {
                        throw new ArgumentException("参数个数错误");
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            try
            {
                if (destinationType == null)
                {
                    throw new ArgumentNullException("destinationType");
                }

                if (value is RoundedCorner)
                {
                    if (destinationType == typeof(string))
                    {
                        RoundedCorner rc = (RoundedCorner)value;

                        if (culture == null)
                        {
                            culture = CultureInfo.CurrentCulture;
                        }
                        string sep = culture.TextInfo.ListSeparator + " ";
                        TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
                        string[] args = new string[4];
                        int nArg = 0;

                        args[nArg++] = intConverter.ConvertToString(context, culture, rc.LeftTop);
                        args[nArg++] = intConverter.ConvertToString(context, culture, rc.RightTop);
                        args[nArg++] = intConverter.ConvertToString(context, culture, rc.RightBottom);
                        args[nArg++] = intConverter.ConvertToString(context, culture, rc.LeftBottom);

                        return string.Join(sep, args);
                    }
                    else if (destinationType == typeof(InstanceDescriptor))
                    {
                        RoundedCorner rc = (RoundedCorner)value;

                        if (rc.ShouldSerializeAll())
                        {
                            return new InstanceDescriptor(
                                typeof(RoundedCorner).GetConstructor(new Type[] { typeof(int) }),
                                new object[] { rc.All });
                        }
                        else
                        {
                            return new InstanceDescriptor(
                                typeof(RoundedCorner).GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) }),
                                new object[] { rc.LeftTop, rc.RightTop, rc.RightBottom, rc.LeftBottom });
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            RoundedCorner original = (RoundedCorner)context.PropertyDescriptor.GetValue(context.Instance);

            int all = (int)propertyValues["All"];
            if (original.All != all)
            {
                return new RoundedCorner(all);
            }
            else
            {
                return new RoundedCorner(
                    (int)propertyValues["LeftTop"],
                    (int)propertyValues["RightTop"],
                    (int)propertyValues["RightBottom"],
                    (int)propertyValues["LeftBottom"]);
            }
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(RoundedCorner), attributes);
            return props.Sort(new string[] { "All", "LeftTop", "RightTop", "RightBottom", "LeftBottom" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
