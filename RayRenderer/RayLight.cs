using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 光线追踪光照
    /// </summary>
    public abstract class RayLight : Light
    {



        /// <summary>
        /// 阴影采样
        /// </summary>
        /// <param name="mUnion"></param>
        /// <param name="mPosition"></param>
        /// <returns></returns>
        public abstract LightSample Sample(UnionRayObject mUnion, Vector3 mPosition);

    }
}
