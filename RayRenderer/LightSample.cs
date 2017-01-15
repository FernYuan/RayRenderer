using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 光线采样结果
    /// </summary>
    public struct LightSample
    {
        /// <summary>
        /// 反向法向量
        /// </summary>
        public Vector3 L;

        /// <summary>
        /// 辐照度
        /// </summary>
        public Color EL;

        public static LightSample zero
        {
            get
            {
                return new LightSample(Vector3.zero, Color.black);
            }
        }

        public LightSample(Vector3 mL, Color mEL)
        {
            this.L = mL;
            this.EL = mEL;
            
        }

        public static bool operator ==(LightSample lhs, LightSample rhs)
        {
            return (lhs.L == rhs.L && lhs.EL == rhs.EL);
        }

        public static bool operator !=(LightSample lhs, LightSample rhs)
        {
            return !(lhs.L == rhs.L && lhs.EL == rhs.EL);
        }

    }
}
