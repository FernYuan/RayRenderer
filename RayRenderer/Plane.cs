using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 平面
    /// </summary>
    public class Plane : RayGameObject
    {
        /// <summary>
        /// 法向量
        /// </summary>
        private Vector3 normal;

        private float d;

        public Plane(Vector3 mNormal,float mD)
        {
            this.d = mD;
            this.normal = mNormal;
            this.Transform.position = this.normal * d;
        }
        

       
        public override RaycastHit Intersect(Ray3 ray)
        {
            RaycastHit hit = new RaycastHit();
            float a = Vector3.Dot(ray.Direction, normal);
            if (a < 0)
            {
                var b = Vector3.Dot(normal, ray.Origin - this.Transform.position);
                hit.GameObject = this;
                hit.Distance = -b / a;
                hit.Position = ray.GetPoint(hit.Distance);
                hit.Normal = normal;
            }

            return hit;
        }
    }
}
