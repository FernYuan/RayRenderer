using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 三维射线
    /// </summary>
    public struct Ray3
    {
        /// <summary>
        /// 起点
        /// </summary>
        private Vector3 origin;

        /// <summary>
        /// 方向
        /// </summary>
        public Vector3 Origin
        {
            get
            {
                return origin;
            }

            set
            {
                origin = value;
            }
        }

        


        /// <summary>
        /// 方向
        /// </summary>
        private Vector3 direction;

        /// <summary>
        /// 方向
        /// </summary>
        public Vector3 Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value.Normalize();
            }
        }



        public Ray3(Vector3 mOrigin,Vector3 mDirection)
        {
            origin  = mOrigin;
            direction = mDirection.Normalize();
        }

        /// <summary>
        /// 获取交点
        /// </summary>
        /// <param name="distance">距离</param>
        /// <returns></returns>
        public Vector3 GetPoint(float distance)
        {
            return origin + direction * distance;
        }
    }
}
