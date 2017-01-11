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
    class Plane : RayGameObject
    {
        /// <summary>
        /// 法向量
        /// </summary>
        private Vector3 normal;

       
        public override RaycastHit Intersect(Ray3 ray)
        {
            throw new NotImplementedException();
        }
    }
}
