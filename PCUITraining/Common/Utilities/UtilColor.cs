using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Common.Utilities
{
    /// <summary>
    /// カラーユーティリティ
    /// </summary>
    public class UtilColor
    {
        /// <summary>
        /// Webカラーリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<Color> GetWebColors()
        {
            return GetConstants(typeof(Color));
        }

        /// <summary>
        /// システムカラーリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<Color> GetSysColors()
        {
            return GetConstants(typeof(SystemColors));
        }

        /// <summary>
        /// カラーリストを取得する.
        /// </summary>
        /// <param name="enumType">ENUM種別</param>
        /// <returns>カラーリスト</returns>
        private static List<Color> GetConstants(Type enumType)
        {
            var attributes = MethodAttributes.Static | MethodAttributes.Public;
            var properties = enumType.GetProperties();

            var list = new List<Color>();
            for (int i = 0; i < properties.Length; i++)
            {
                var info = properties[i];
                if (info.PropertyType == typeof(Color))
                {
                    var getMethod = info.GetGetMethod();
                    if ((null != getMethod) &&
                        ((getMethod.Attributes & attributes) == attributes))
                    {
                        object[] index = null;
                        list.Add((Color)info.GetValue(null, index));
                    }
                }
            }

            return list;
        }
    }
}
