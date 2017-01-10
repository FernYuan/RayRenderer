using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 数学库
    /// </summary>
    public class Mathf
    {
        /// <summary>
        /// 取数字界限
        /// </summary>
        /// <param name="value">数字源</param>
        /// <param name="min">最小界限</param>
        /// <param name="max">最大界限</param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
                return value;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }



    }
}
