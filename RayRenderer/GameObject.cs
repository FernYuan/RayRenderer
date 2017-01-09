using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 游戏物体
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// 变换
        /// </summary>
        private Transform transform;


        /// <summary>
        /// 变换
        /// </summary>
        public Transform Transform
        {
            get
            {
                return transform;
            }
        }

        public GameObject()
        {
            transform = new Transform();
        }

       
    }
}
