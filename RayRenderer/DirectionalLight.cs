using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 平行光照
    /// </summary>
    public class DirectionalLight:RayLight
    {
        /// <summary>
        /// 反向法向量
        /// </summary>
        private Vector3 L
        {
            get
            {
                return -(this.direction.Normalize());
            }
        }

        /// <summary>
        /// 平行光
        /// </summary>
        /// <param name="mIntensity">辐照强度</param>
        /// <param name="mDirection">方向</param>
        public DirectionalLight(Color mIntensity, Vector3 mDirection)
        {
            this.color = mIntensity;
            this.direction = mDirection;
        }

        /// <summary>
        /// 阴影采样
        /// </summary>
        /// <param name="mUnion"></param>
        /// <param name="mPosition"></param>
        /// <returns></returns>
        public override LightSample Sample(UnionRayObject mUnion, Vector3 mPosition)
        {
            Vector3 lNormal = this.L;

            if (isShadow)
            {
                Ray3 rayShadow = new Ray3(mPosition, lNormal);
                RaycastHit hitShadow = mUnion.Intersect(rayShadow);
                if (hitShadow.GameObject != null)
                {
                    return LightSample.zero;
                }
            }

            return new LightSample(lNormal, this.color);
        }
    }
}
