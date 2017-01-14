using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 聚光灯
    /// </summary>
    public class SpotLight : RayLight
    {
        /// <summary>
        /// 内圆锥夹角
        /// </summary>
        public float theta;

        /// <summary>
        /// 外圆锥夹角
        /// </summary>
        public float phi;

        /// <summary>
        /// 衰减
        /// </summary>
        public float falloff;

        /// <summary>
        /// 聚光灯
        /// </summary>
        /// <param name="mIntensity">辐照强度</param>
        /// <param name="mPosition">位置</param>
        /// <param name="mDirection">方向</param>
        /// <param name="mTheta">内圆锥夹角</param>
        /// <param name="mPhi">外圆锥夹角</param>
        /// <param name="mFalloff">衰减</param>
        public SpotLight(Color mIntensity, Vector3 mPosition, Vector3 mDirection, float mTheta, float mPhi, float mFalloff)
        {
            this.color = mIntensity;
            this.Transform.position = mPosition;
            this.direction = mDirection;
            this.theta = mTheta;
            this.phi = mPhi;
            this.falloff = mFalloff;

            S = -this.direction.Normalize();
            this.cosTheta = (float)Math.Cos(this.theta * Math.PI / 180 / 2);
            this.cosPhi = (float)Math.Cos(this.phi * Math.PI / 180 / 2);
            this.baseMultiplier = 1 / (this.cosTheta - this.cosPhi);

        }


        private Vector3 S;
        private float cosTheta;
        private float cosPhi;
        private float baseMultiplier;
        /// <summary>
        /// 光影采样
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

            float spot;
            float SdotL = Vector3.Dot(this.S, L);
            if (SdotL >= this.cosTheta)
            {
                spot = 1;
            }
            else if (SdotL <= this.cosPhi)
            {
                spot = 0;
            }
            else
            {
                spot = (float)Math.Pow((SdotL - this.cosPhi) * this.baseMultiplier, this.falloff);
            }


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

            return new LightSample(L, this.color * (attenuation * spot));
        }
    }
}
