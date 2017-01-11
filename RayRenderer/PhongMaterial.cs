using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    public class PhongMaterial : RayMaterial
    {
        /// <summary>
        /// 漫反射
        /// </summary>
        public Color diffuse;

        /// <summary>
        /// 镜面反射
        /// </summary>
        public Color specular;

        /// <summary>
        /// 自发光
        /// </summary>
        public float shininess;

        /// <summary>
        /// 反光度
        /// </summary>
        public float reflectiveness;

        /// <summary>
        /// 全局光
        /// </summary>
        public static Light light = new Light(new Vector3(1, 1, 1).Normalize(), Color.white);

        public PhongMaterial(Color mDiffuse, Color mSpecular, float mShininess, float mReflectiveness)
        {
            this.diffuse = mDiffuse;
            this.specular = mSpecular;
            this.shininess = mShininess;
            this.reflectiveness = mReflectiveness;
        }

         
      

        /// <summary>
        ///     采样
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public override Color Sample(Ray3 ray, Vector3 position, Vector3 normal)
        {
            float NdotL = Vector3.Dot(normal, light.direction);
            Vector3 H = (light.direction - ray.Direction).Normalize();
            float NdotH = Vector3.Dot(normal, H);
            Color diffuseTerm = this.diffuse * (Math.Max(NdotL, 0));
            Color specularTerm = this.specular * ((float)Math.Pow(Math.Max(NdotH, 0), this.shininess));
            return light.color * (diffuseTerm + specularTerm);
        }
    }
}
