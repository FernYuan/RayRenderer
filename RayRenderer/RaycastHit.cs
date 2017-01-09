using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 射线投射结果
    /// </summary>
    public struct RaycastHit
    {
        /// <summary>
        /// 碰撞到的物体
        /// </summary>
        private GameObject gameObject;
        /// <summary>
        /// 碰撞到的物体
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }

            set
            {
                gameObject = value;
            }
        }

        /// <summary>
        /// 距离
        /// </summary>
        private float distance;
        /// <summary>
        /// 距离
        /// </summary>
        public float Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        

        

        /// <summary>
        /// 位置
        /// </summary>
        private Vector3 position;
        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        /// <summary>
        /// 法向量
        /// </summary>
        private Vector3 normal;
        /// <summary>
        /// 法向量
        /// </summary>
        public Vector3 Normal
        {
            get
            {
                return normal;
            }

            set
            {
                normal = value;
            }
        }
    }
}
