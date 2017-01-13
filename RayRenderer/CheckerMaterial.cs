using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 格子材质
    /// </summary>
    public class CheckerMaterial : RayMaterial
    {
        /// <summary>
        /// 缩放
        /// </summary>
        public float scale;

        

        public CheckerMaterial(float mScale, float mReflectiveness)
        {
            this.scale = mScale;
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
            return Math.Abs((Math.Floor(position.x * 0.1f) + Math.Floor(position.z * this.scale)) % 2) < 1 ? Color.black : Color.white;
        }

    }
}
