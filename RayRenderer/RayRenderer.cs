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
        /// 最大深度
        /// </summary>
        private int maxDepth;

        /// <summary>
        /// 最大反射次数
        /// </summary>
        private int maxReflect;

        /// <summary>
        /// 绘图器
        /// </summary>
        private Graphics g;

        /// <summary>
        /// 要渲染的物体集合
        /// </summary>
        public UnionRayObject unionRayObject = new UnionRayObject();
        

        /// <summary>
        /// 光照集合
        /// </summary>
        public List<RayLight> listRayLight = new List<RayLight>();



        public RayRenderer(Camera mCamera, Bitmap mBitmap, Graphics mGraphics, int mMaxDepth, int mMaxReflect)
        {
            this.camera = mCamera;
            camera.Initialize();
            this.bitBuffer = mBitmap;
            this.g = mGraphics;
            this.maxDepth = mMaxDepth;
            this.maxReflect = mMaxReflect;

            //camera.Transform.position = new Vector3(0, 10, 10);

            Sphere sphere = new Sphere(10);
            sphere.Transform.position = new Vector3(-10, 10, -10);
            sphere.RayMaterial = new PhongMaterial(Color.red, Color.white, 16, 0.25f);

            Sphere sphere1 = new Sphere(10);
            sphere1.Transform.position = new Vector3(10, 10, -10);
            sphere1.RayMaterial = new PhongMaterial(Color.blue, Color.white, 16, 0.25f);

            Plane plane = new Plane(new Vector3(0, 1, 0), 0);
            plane.RayMaterial = new CheckerMaterial(0.1f, 0.5f);

            unionRayObject.Add(sphere);
            unionRayObject.Add(sphere1);
            unionRayObject.Add(plane);

            DirectionalLight dirLight = new DirectionalLight(Color.white, new Vector3(-1.75f, -2f, -1.5f));

            listRayLight.Add(dirLight);

        }



        /// <summary>
        /// 渲染
        /// </summary>
        public void Rendering()
        {


            int w = bitBuffer.Width;
            int h = bitBuffer.Height;

            //锁定位图到内存
            bitmapData = bitBuffer.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitBuffer.PixelFormat);

            unsafe
            {

                byte* bitMapPtr = (byte*)(bitmapData.Scan0);

                //多线程并行计算
                Parallel.ForEach(Partitioner.Create(0, h, h / Environment.ProcessorCount), (H) =>
                {

                    for (int y = H.Item1; y < H.Item2; y++)
                    {
                        byte* pointRow = bitMapPtr + bitmapData.Stride * y;
                        float sy = 1f - (float)y / (float)h;
                        for (int x = 0; x < w; x++)
                        {
                            float sx = (float)x / (float)w;
                            Ray3 ray = camera.GenerateRay(sx, sy);
                            RaycastHit hit = unionRayObject.Intersect(ray);
                            if (hit.GameObject != null)
                            {
                                //Console.WriteLine("----射线命中"+hit.Position);

                                //RenderDepth(hit,ref pointRow);
                                //RenderNormal(hit, ref pointRow);
                                //RayTrace(ray, hit, ref pointRow);
                                RenderLight(ray, hit, ref pointRow, listRayLight);
                            }
                            else
                            {
                                //Console.WriteLine("----射线未命中");
                                //bitBuffer.SetPixel(x, y, System.Drawing.Color.Black);

                                (*(pointRow++)) = 0;
                                (*(pointRow++)) = 0;
                                (*(pointRow++)) = 0;
                                (*(pointRow++)) = 255;
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

                });


            }

            bitBuffer.UnlockBits(bitmapData);
            g.DrawImage(bitBuffer, 0, 0);
        }





        /// <summary>
        /// 渲染深度
        /// </summary>
        public unsafe void RenderDepth(RaycastHit hit, ref byte* point)
        {
            float depth = 255f - Math.Min((hit.Distance / maxDepth) * 255f, 255f);
            int depthInt = (int)depth;
            //bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255, depthInt, depthInt, depthInt));

            (*(point++)) = (byte)depthInt;//b
            (*(point++)) = (byte)depthInt;//g
            (*(point++)) = (byte)depthInt;//r
            (*(point++)) = 255;//a
        }

        /// <summary>
        /// 渲染法向量
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public unsafe void RenderNormal(RaycastHit hit, ref byte* point)
        {
            //bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255,
            //    Mathf.Clamp((int)((hit.Normal.x + 1f) * 128f), 0, 255),
            //    Mathf.Clamp((int)((hit.Normal.y + 1f) * 128f), 0, 255),
            //    Mathf.Clamp((int)((hit.Normal.z + 1f) * 128f), 0, 255)));

            (*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.z + 1f) * 128f), 0, 255);//b
            (*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.y + 1f) * 128f), 0, 255);//g
            (*(point++)) = (byte)Mathf.Clamp((int)((hit.Normal.x + 1f) * 128f), 0, 255);//r
            (*(point++)) = 255;//a
        }


        /// <summary>
        /// 渲染阴影
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="hit"></param>
        /// <param name="point"></param>
        /// <param name="lights"></param>
        public unsafe void RenderLight(Ray3 ray, RaycastHit hit, ref byte* point, List<RayLight> lights)
        {
            Color color = Color.black;

            foreach (RayLight item in lights)
            {
                LightSample lightSample = item.Sample(unionRayObject,hit.Position);
                if (lightSample != LightSample.zero)
                {
                    float NdotL = Vector3.Dot(hit.Normal, lightSample.L);

                    if (NdotL >= 0)
                    {
                        color = color + (lightSample.EL * NdotL);
                    }
                }
            }

            (*(point++)) = (byte)Mathf.Clamp((int)(color.b * 255), 0, 255);//b
            (*(point++)) = (byte)Mathf.Clamp((int)(color.g * 255), 0, 255);//g
            (*(point++)) = (byte)Mathf.Clamp((int)(color.r * 255), 0, 255);//r
            (*(point++)) = 255;//a
        }

        /// <summary>
        /// 光线追踪
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public unsafe void RayTrace(Ray3 ray, RaycastHit hit, ref byte* point)
        {
            Color color = GetRayTraceColor(ray, hit, this.maxReflect);

            //bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255,
            //    Mathf.Clamp((int)(color.r * 255), 0, 255),
            //    Mathf.Clamp((int)(color.g * 255), 0, 255),
            //    Mathf.Clamp((int)(color.b * 255), 0, 255)));

            (*(point++)) = (byte)Mathf.Clamp((int)(color.b * 255), 0, 255);//b
            (*(point++)) = (byte)Mathf.Clamp((int)(color.g * 255), 0, 255);//g
            (*(point++)) = (byte)Mathf.Clamp((int)(color.r * 255), 0, 255);//r
            (*(point++)) = 255;//a
        }

        /// <summary>
        /// 获取光线追踪颜色
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="hit"></param>
        /// <param name="mMaxReflect"></param>
        /// <returns></returns>
        public Color GetRayTraceColor(Ray3 ray, RaycastHit hit, int mMaxReflect)
        {
            Color color = hit.GameObject.RayMaterial.Sample(ray, hit.Position, hit.Normal);
            try
            {
                float reflectiveness = hit.GameObject.RayMaterial.reflectiveness;
                color = color * (1 - reflectiveness);

                if (reflectiveness > 0 && mMaxReflect > 0)
                {
                    Vector3 r = hit.Normal * (-2 * Vector3.Dot(hit.Normal, ray.Direction)) + ray.Direction;
                    ray = new Ray3(hit.Position, r);
                    hit = unionRayObject.Intersect(ray);
                    Color reflectedColor;
                    if (hit.GameObject != null)
                    {
                        reflectedColor = GetRayTraceColor(ray, hit, mMaxReflect - 1);

                    }
                    else
                    {
                        reflectedColor = Color.black;
                    }

                    color = color + (reflectedColor * reflectiveness);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return color;
        }

       

      

    }
}
