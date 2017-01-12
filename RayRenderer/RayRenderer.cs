using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace RayRenderer
{
    /// <summary>
    /// 光线追踪渲染器
    /// </summary>
    public class RayRenderer
    {
        /// <summary>
        /// 摄像机
        /// </summary>
        private Camera camera;

        /// <summary>
        /// 绘图缓冲
        /// </summary>
        private Bitmap bitBuffer;

        /// <summary>
        /// 绘图特性
        /// </summary>
        private System.Drawing.Imaging.BitmapData bitmapData;


        /// <summary>
        /// 绘图首行地址
        /// </summary>
        private unsafe byte* bitMapPtr;

        /// <summary>
        /// 最大深度
        /// </summary>
        private int maxDepth;

        /// <summary>
        /// 绘图器
        /// </summary>
        private Graphics g;

        /// <summary>
        /// 要渲染的物体集合
        /// </summary>
        public UnionRayObject unionRayObject = new UnionRayObject();

   

        public RayRenderer(Camera mCamera, Bitmap mBitmap, Graphics mGraphics, int mMaxDepth)
        {
            this.camera = mCamera;
            camera.Initialize();
            this.bitBuffer = mBitmap;
            this.g = mGraphics;
            this.maxDepth = mMaxDepth;

            Sphere sphere = new Sphere(10);
            sphere.Transform.position = new Vector3(-10, 10, -10);
            sphere.RayMaterial = new PhongMaterial(Color.red, Color.white, 16, 0);

            Sphere sphere1 = new Sphere(10);
            sphere1.Transform.position = new Vector3(10, 10, -10);
            sphere1.RayMaterial = new PhongMaterial(Color.blue, Color.white, 16, 0);

            unionRayObject.Add(sphere);
            unionRayObject.Add(sphere1);

        }

   
        
        /// <summary>
        /// 渲染
        /// </summary>
        public void Rendering()
        {
            

            int w = bitBuffer.Width;
            int h = bitBuffer.Height;

            //锁定位图到内存
            //bitmapData = bitBuffer.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitBuffer.PixelFormat);

            unsafe
            {
                //byte* bitMapPtr = (byte*)(bitmapData.Scan0);

                for (int y = 0; y < h; y++)
                {
                    float sy = 1f - (float)y / (float)h;
                    for (int x = 0; x < w; x++)
                    {
                        float sx = (float)x / (float)w;
                        Ray3 ray = camera.GenerateRay(sx, sy);
                        RaycastHit hit = unionRayObject.Intersect(ray);
                        if (hit.GameObject != null)
                        {
                            //Console.WriteLine("----射线命中"+hit.Position);

                            RenderDepth(hit, x, y);
                            //RenderNormal(hit, x, y);
                            //RayTrace(ray, hit, x, y);
                        }
                        else
                        {
                            //Console.WriteLine("----射线未命中");
                            //bitBuffer.SetPixel(x, y, System.Drawing.Color.Black);

                            (*(bitMapPtr++)) = 0;
                            (*(bitMapPtr++)) = 0;
                            (*(bitMapPtr++)) = 0;
                            (*(bitMapPtr++)) = 255;
                        }
                    }

                    //忽略无用数据区域,图像数据按4字节对其
                    //｜－－－－－－－Ｓｔｒｉｄｅ－－－－－－－－－－－｜ 
                    //｜－－－－－－－Ｗｉｄｔｈ－－－－－－－－－｜ ｜ 
                    //Scan0： 
                    //ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＸＸ
                    //ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＸＸ
                    //ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＢＧＲ ＸＸ
                    //bitMapPtr += bitmapData.Stride - w * 3;
                }
            }

            //bitBuffer.UnlockBits(bitmapData);
            g.DrawImage(bitBuffer, 0, 0);
        }
        
        



        /// <summary>
        /// 渲染深度
        /// </summary>
        public void RenderDepth(RaycastHit hit, int x, int y)
        {
            float depth = 255f - Math.Min((hit.Distance / maxDepth) * 255f, 255f);
            int depthInt = (int)depth;
            bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255, depthInt, depthInt, depthInt));

            ////(*(point++)) = (byte)depthInt;//b
            ////(*(point++)) = (byte)depthInt;//g
            ////(*(point++)) = (byte)depthInt;//r
            ////(*(point++)) = 255;//a
        }

        /// <summary>
        /// 渲染法向量
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RenderNormal(RaycastHit hit, int x, int y)
        {
            bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255,
                Mathf.Clamp((int)((hit.Normal.x + 1f) * 128f), 0, 255),
                Mathf.Clamp((int)((hit.Normal.y + 1f) * 128f), 0, 255),
                Mathf.Clamp((int)((hit.Normal.z + 1f) * 128f), 0, 255)));

            //(*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.z + 1f) * 128f), 0, 255);//b
            //(*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.y + 1f) * 128f), 0, 255);//g
            //(*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.x + 1f) * 128f), 0, 255);//r
            //(*(point++)) = 255;//a
        }
        
        /// <summary>
        /// 光线追踪
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RayTrace(Ray3 ray, RaycastHit hit, int x, int y)
        {
            Color color = hit.GameObject.RayMaterial.Sample(ray, hit.Position, hit.Normal);
            bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255,
                Mathf.Clamp((int)(color.r * 255), 0, 255),
                Mathf.Clamp((int)(color.g * 255), 0, 255),
                Mathf.Clamp((int)(color.b * 255), 0, 255)));

            //(*(point++)) = (byte)(color.b * 255f);//b
            //(*(point++)) = (byte)(color.g * 255f);//g
            //(*(point++)) = (byte)(color.r * 255f);//r
            //(*(point++)) = 255;//a
        }

    }
}
