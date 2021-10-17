using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs
{
    public class Utility
    {
        /// <summary>
        /// 文字列型に変換します。
        /// </summary>
        /// <param name="value">変換オブジェクト</param>
        /// <returns>文字列(Nullの場合、ブランクを返す。)</returns>
        public static string Null2Blank(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }

            return value.ToString();
        }
    }
}
