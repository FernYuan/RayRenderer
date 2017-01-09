using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 球体
    /// </summary>
    public class Sphere : GameObject
    {
        /// <summary>
        /// 半径
        /// </summary>
        private float radius;
        /// <summary>
        /// 半径
        /// </summary>
        public float Radius
        {
            get
            {
                return radius;
            }
            protected set
            {
                radius = value;
                sqrRadius = radius * radius;
            }
        }

        

        /// <summary>
        /// 半径的平方
        /// </summary>
        private float sqrRadius;
        /// <summary>
        /// 半径的平方
        /// </summary>
        public float SqrRadius
        {
            get
            {
                return sqrRadius;
            }
        }


        public Sphere(float mRadius)
        {
            this.Radius = mRadius;
        }

        /// <summary>
        /// 与射线交叉
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public RaycastHit Intersect(Ray3 ray)
        {
            RaycastHit hit = new RayRenderer.RaycastHit();
            Vector3 v = ray.Origin - this.Transform.position;
            float a0 = v.SqeLength - this.SqrRadius;
            float DdotV = Vector3.Dot(ray.Direction, v);
            if (DdotV <= 0)
            {
                float discr = DdotV * DdotV - a0;
                if (discr >= 0)
                {
                    hit.GameObject = this;
                    hit.Distance = -DdotV - (float)Math.Sqrt(discr);
                    hit.Position = ray.GetPoint(hit.Distance);
                    hit.Normal = (hit.Position - this.Transform.position).Normalize();
                }
            }

            return hit;
        }


    }
}
