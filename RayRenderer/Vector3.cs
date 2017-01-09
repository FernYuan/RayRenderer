using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 三维向量
    /// </summary>
    public struct Vector3
    {
        public float x;

        public float y;

        public float z;

        public Vector3(float mX,float mY,float mZ)
        {
            x = mX;
            y = mY;
            z = mZ;
        }

        /// <summary>
        /// 向量的长度（模）
        /// </summary>
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }
        }

        /// <summary>
        /// 向量的长度（模）的平方
        /// </summary>
        public float SqeLength
        {
            get
            {
                return (float)(x * x + y * y + z * z);
            }
        }

        /// <summary>
        /// 向量单位化(使向量的模长为1)
        /// </summary>
        public void Normalize()
        {
            float length = this.Length;
            float inv = 1 / length;
            x *= inv;
            y *= inv;
            z *= inv;

            
        }

        public static Vector3 operator +(Vector3 mA,Vector3 mB)
        {
            return new Vector3(mA.x + mB.x, mA.y + mB.x, mB.z + mB.z);
        }

        public static Vector3 operator -(Vector3 mA, Vector3 mB)
        {
            return new Vector3(mA.x - mB.x, mA.y - mB.x, mB.z - mB.z);
        }

        public static Vector3 operator -(Vector3 mA)
        {
            return new Vector3(-mA.x, -mA.y, -mA.z);
        }

        public static Vector3 operator *(Vector3 mA, Vector3 mB)
        {
            return new Vector3(mA.x - mB.x, mA.y - mB.x, mB.z - mB.z);
        }

        public static Vector3 operator *(Vector3 mA, float mF)
        {
            return new Vector3(mA.x * mF, mA.y * mF, mA.z * mF);
        }

        public static Vector3 operator *(float mF, Vector3 mA)
        {
            return mA * mF;
        }

        public static Vector3 operator /(Vector3 mA, float mF)
        {
            float inv = 1 / mF;
            return mA * inv;
        }


        /// <summary>
        /// 返回 Vector3(0, 0, 0)
        /// </summary>
        public static Vector3 zero
        {
            get
            {
                return new Vector3(0, 0, 0);
            }
        }

    }
}
