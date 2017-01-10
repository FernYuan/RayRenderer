using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 颜色类
    /// </summary>
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;


        public Color(float mR,float mG,float mB)
        {
            r = mR;
            g = mG;
            b = mB;
            a = 1f;
        }

        public Color(float mR, float mG, float mB,float mA)
        {
            r = mR;
            g = mG;
            b = mB;
            a = mA;
        }

        public static Color operator +(Color mA, Color mB)
        {
            return new Color(mA.r + mB.r, mA.g + mB.g, mA.b + mB.b, mA.a + mB.a);
        }

    }
}
