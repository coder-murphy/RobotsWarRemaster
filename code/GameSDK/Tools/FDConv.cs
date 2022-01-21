using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDGameSDK.Tools
{
    /// <summary>
    /// 转换类
    /// </summary>
    public static class FDConv
    {
        /// <summary>
        /// 将对象转化为
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int O2I(object obj)
        {
            if(obj == null)return 0;
            var str = obj.ToString();
            if (string.IsNullOrWhiteSpace(str)) return 0;
            if(int.TryParse(str, out int res))
                return res;
            return 0;
        }

        /// <summary>
        /// 对象转化为双精度
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double O2D(object obj)
        {
            if (obj == null) return 0;
            var str = obj.ToString();
            if (string.IsNullOrWhiteSpace(str)) return 0;
            if (double.TryParse(str, out double res))
                return res;
            return 0;
        }
    }
}
