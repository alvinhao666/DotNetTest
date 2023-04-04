using System;
using System.Collections.Generic;

namespace Hao
{
    public static class EnumExtensions
    {
        ///// <summary>
        ///// 获取描述
        ///// </summary>
        ///// <param name="enum">枚举对象</param>
        ///// <returns></returns>
        //public static string? ToDescription(this Enum? @enum)
        //{
        //    if (@enum is null) return null;

        //    //var enumType = @enum.GetType();
        //    //if (!Enum.IsDefined(enumType, @enum)) return null;

        //    return EnumHelper.GetDescription(@enum);
        //}

        ///// <summary>
        ///// 判断是否有值
        ///// </summary>
        ///// <param name="enum">枚举对象</param>
        ///// <returns></returns>
        //public static bool HasValueNot0(this Enum? @enum)
        //{
        //    if (@enum is null) return false;

        //    if (ToInt(@enum) == 0) return false;

        //    return true;
        //}

        /// <summary>
        /// enum转int值 
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static int ToInt(this Enum @enum)
        {
            return @enum.GetHashCode(); //https://www.cnblogs.com/maruko/p/11731681.html  //https://www.cnblogs.com/iguxiaobei/p/6235914.html

            //方式2

            //return Convert.ToInt32(e);


            //方式3

            //var type = @enum.GetType();

            //if (!Enum.IsDefined(type, @enum)) throw new ArgumentException("@enum不属于该枚举",nameof(@enum));

            //var fieldName = @enum.ToString();

            //object result = Enum.Parse(type, fieldName);

            //return (int)result;
        }

        /// <summary>
        /// enum转int值 
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static int ToInt<T>(this T @enum) where T : struct, Enum
        {
            // https://pvs-studio.com/en/blog/posts/csharp/0844/

            return EqualityComparer<T>.Default.GetHashCode(@enum!);
        }
    }
}
