using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 用于光线渲染的物体
    /// </summary>
    public abstract class RayGameObject:GameObject
    {

        /// <summary>
        /// 与射线交叉
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public abstract RaycastHit Intersect(Ray3 ray);

    }
}
