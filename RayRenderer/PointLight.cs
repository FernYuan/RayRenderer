using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 点光源
    /// </summary>
    public class PointLight : RayLight
    {
       
        /// <summary>
        /// 点光源
        /// </summary>
        /// <param name="mIntensity">辐照强度</param>
        /// <param name="mPosition">位置</param>
        public PointLight(Color mIntensity,Vector3 mPosition)
        {
            this.color = mIntensity;
            this.Transform.position = mPosition;
        }

        /// <summary>
        /// 阴影采样
        /// </summary>
        /// <param name="mUnion"></param>
        /// <param name="mPosition"></param>
        /// <returns></returns>
        public override LightSample Sample(UnionRayObject mUnion, Vector3 mPosition)
        {
            Vector3 delta = this.Transform.position - mPosition;
            float rr = delta.SqeLength;
            float r = delta.Length;
            Vector3 L = delta / r;

            if (this.isShadow)
            {
                Ray3 shadowRay = new Ray3(mPosition, L);
                RaycastHit hit = mUnion.Intersect(shadowRay);
                if (hit.GameObject != null && hit.Distance <= r)
                {
                    return LightSample.zero;
                }
            }

            //平方反比衰减
            float attenuation = 1 / rr;

            return new LightSample(L, this.color * attenuation);
        }
    }
}
