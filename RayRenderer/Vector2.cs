using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{

    /// <summary>
    /// 二维坐标
    /// </summary>
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float mX,float mY)
        {
            this.x = mX;
            this.y = mY;
        }
    }
}
