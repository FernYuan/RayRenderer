using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 光线追踪材质
    /// </summary>
    public abstract class RayMaterial
    {
        /// <summary>
        /// 反射度
        /// </summary>
        public float reflectiveness;


        /// <summary>
        /// 采样
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public abstract Color Sample(Ray3 ray, Vector3 position, Vector3 normal);

    }
}
