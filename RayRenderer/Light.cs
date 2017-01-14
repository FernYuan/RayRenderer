using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 光照
    /// </summary>
    public class Light : GameObject
    {
        /// <summary>
        /// 方向
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// 颜色
        /// </summary>
        public Color color;

        /// <summary>
        /// 是否有阴影
        /// </summary>
        public bool isShadow = true;

        public Light()
        {
        }

        public Light(Vector3 mDirection, Color mColor)
        {
            this.direction = mDirection;
            this.color = mColor;
        }

    }
}
