
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace WinformControlLibraryExtension.ComplexityPropertys
{
    /// <summary>
    /// PointFExt转换器
    /// </summary>
    [Description("PointFExt转换器")]
    public class PointFConverter : TypeConverter
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

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strValue = value as string;

            if (strValue != null)
            {
                string text = strValue.Trim();

                if (text.Length == 0)
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
                    string[] tokens = text.Split(new char[] { sep });
                    float[] values = new float[tokens.Length];
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(float));
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = (float)intConverter.ConvertFromString(context, culture, tokens[i]);
                    }

                    if (values.Length == 2)
                    {
                        return new ComplexityPropertys.PointF(values[0], values[1]);
                    }
                    else
                    {
                        throw new ArgumentException("参数格式错误");
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            if (value is ComplexityPropertys.PointF)
            {
                if (destinationType == typeof(string))
                {
                    ComplexityPropertys.PointF pt = (ComplexityPropertys.PointF)value;

                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string sep = culture.TextInfo.ListSeparator + " ";
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(float));
                    string[] args = new string[2];
                    int nArg = 0;

                    args[nArg++] = intConverter.ConvertToString(context, culture, pt.X);
                    args[nArg++] = intConverter.ConvertToString(context, culture, pt.Y);

                    return string.Join(sep, args);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    ComplexityPropertys.PointF pt = (ComplexityPropertys.PointF)value;

                    ConstructorInfo ctor = typeof(ComplexityPropertys.PointF).GetConstructor(new Type[] { typeof(float), typeof(float) });
                    if (ctor != null)
                    {
                        return new InstanceDescriptor(ctor, new object[] { pt.X, pt.Y });
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object x = propertyValues["X"];
            object y = propertyValues["Y"];

            if (x == null || y == null || !(x is float) || !(y is float))
            {
                throw new ArgumentException("数据不能为空");
            }

            return new ComplexityPropertys.PointF((float)x, (float)y);

        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(ComplexityPropertys.PointF), attributes);
            return props.Sort(new string[] { "X", "Y" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

    }

}
