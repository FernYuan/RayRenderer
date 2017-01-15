using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 颜色
    /// </summary>
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;


        public Color(float mR, float mG, float mB)
        {
            r = mR;
            g = mG;
            b = mB;
            a = 1f;
        }

        public Color(float mR, float mG, float mB, float mA)
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

        public static Color operator *(Color mA, Color mB)
        {
            return new Color(mA.r * mB.r, mA.g * mB.g, mA.b * mB.b, mA.a * mB.a);
        }

        public static Color operator *(Color mColor, float mF)
        {
            return new Color(mColor.r * mF, mColor.g * mF, mColor.b * mF, mColor.a * mF);
        }

        public static Color operator *(float mF, Color mColor)
        {
            return new Color(mColor.r * mF, mColor.g * mF, mColor.b * mF, mColor.a * mF);
        }

        public static bool operator ==(Color lhs, Color rhs)
        {
            return (((lhs.r.Equals(rhs.r) && lhs.g.Equals(rhs.g)) && lhs.b.Equals(rhs.b)) && lhs.a.Equals(rhs.a));
        }

        public static bool operator !=(Color lhs, Color rhs)
        {
            return !(((lhs.r.Equals(rhs.r) && lhs.g.Equals(rhs.g)) && lhs.b.Equals(rhs.b)) && lhs.a.Equals(rhs.a));
        }

        public override string ToString()
        {
            return string.Format("Color(r:{0},g:{1},b:{2},a:{3})", r, g, b,a);
        }



        public static Color black
        {
            get
            {
                return new Color(0f, 0f, 0f);
            }
        }


        public static Color white
        {
            get
            {
                return new Color(1, 1, 1);
            }
        }

        public static Color red
        {
            get
            {
              return  new Color(1, 0, 0);
            }
        }
        

        public static Color green
        {
            get
            {
                return new Color(0, 1, 0);
            }
        }
        

        public static Color blue
        {
            get
            {
                return new Color(0, 0, 1);
            }
        }
    }
}
