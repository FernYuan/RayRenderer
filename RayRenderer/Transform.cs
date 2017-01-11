using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 变换
    /// </summary>
    public class Transform 
    {
        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 position ;

        /// <summary>
        /// 欧拉角
        /// </summary>
        public Vector3 eulerAngles;

        public Transform()
        {
            position = new Vector3();
            eulerAngles = new Vector3();
        }
    }
}
