using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 摄像机
    /// </summary>
    public class Camera : GameObject
    {
        /// <summary>
        /// 视场角
        /// </summary>
        private float fov;
        /// <summary>
        /// 视场角
        /// </summary>
        public float Fov
        {
            get
            {
                return fov;
            }

            set
            {
                fov = value;
            }
        }

        private Vector3 front;

        private Vector3 refUp;

        private Vector3 right;

        private Vector3 up;

        private float fovScale;

        public Camera(Vector3 mPosition, Vector3 mFront, Vector3 mUp, float mFov)
        {
            this.Transform.position = mPosition;
            this.front = mFront;
            this.refUp = mUp;
            this.fov = mFov;
        }

        public void Initialize()
        {
            this.right = Vector3.Cross(this.front,this.refUp);
            this.up = Vector3.Cross(this.right, this.front);
            this.fovScale = (float)Math.Tan(this.fov * 0.5f * Math.PI / 180f) * 2f;
        }

        public Ray3 GenerateRay(float x, float y)
        {
            Vector3 r = right * (float)((x - 0.5f) * fovScale);
            Vector3 u = up * (float)((y - 0.5f) * fovScale);
            return new Ray3(this.Transform.position, (this.front + r + u).Normalize());

        }

    }
}
