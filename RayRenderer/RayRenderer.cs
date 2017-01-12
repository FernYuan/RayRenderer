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
        /// 最大深度
        /// </summary>
        private int maxDepth;

        /// <summary>
        /// 绘图器
        /// </summary>
        private Graphics g;

        /// <summary>
        /// 是否渲染完成
        /// </summary>
        private bool isDown  = false;
        /// <summary>
        /// 是否渲染完成
        /// </summary>
        public bool IsDown
        {
            get
            {
                return isDown;
            }
        }

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
            isDown = false;
            numEnd = 0;
            numCpu = 1;

            int w = bitBuffer.Width;
            int h = bitBuffer.Height;
            ThreadRendering(h, w, 0, h, ThreadRenderingEnd);
        }


        private int numCpu = 4;
        /// <summary>
        /// 多线程渲染
        /// </summary>
        public void ThreadRendering()
        {

            isDown = false;
            numEnd = 0;

            int w = bitBuffer.Width;
            int h = bitBuffer.Height;

           
            //numCpu = Environment.ProcessorCount;
            int numOnce = h / numCpu;

            int numLoop = 0;

            for (int i = 0; i < numCpu; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Test));
            }

            

            System.Drawing.Imaging.BitmapData aa;
            Parallel.ForEach(Partitioner.Create(0,h,numOnce),(H)=>
            {
                
            });

            for (int i = 0; i < numCpu; i++)
            {
                int numStart = numLoop;
                int numNext = numLoop + numOnce;

                if (i == (numCpu - 1))
                {
                    numNext = h;
                }

                
                System.Threading.ThreadPool.QueueUserWorkItem((obj)=> { ThreadRendering(h,w, numStart, numNext,ThreadRenderingEnd); });

                numLoop = numNext;
            }
            

            

        }

        public void Test(object obj)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------test");
        }

        /// <summary>
        /// 线程渲染
        /// </summary>
        protected void ThreadRendering(int h,int w,int yStart,int yEnd,Action mActionEnd)
        {
         
            //Console.WriteLine(string.Format("-------------yStart:{0}  yEnd:{1}",yStart,yEnd));
            for (int y = yStart; y < yEnd; y++)
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

                        //RenderDepth(hit,x,y);
                        //RenderNormal(hit, x, y);
                        RayTrace(ray, hit, x, y);
                    }
                    else
                    {
                        //Console.WriteLine("----射线未命中");
                        dicData.TryAdd(new Vector2(x, y), Color.black);
                        //bitBuffer.SetPixel(x, y, System.Drawing.Color.Black);
                    }


                }
            }
            if (mActionEnd != null)
            {
                mActionEnd();
            }

        }

        private int numEnd = 0;
        private object lockEnd = new object();
        protected void ThreadRenderingEnd()
        {
            lock (lockEnd)
            {
                numEnd++;
                if (numEnd >= numCpu)
                {
                   // Console.WriteLine("----------数据量:" + dicData.Count);
                    foreach (KeyValuePair<Vector2, Color> item in dicData)
                    {
                        bitBuffer.SetPixel((int)item.Key.x, (int)item.Key.y, System.Drawing.Color.FromArgb(255,
                            Mathf.Clamp((int)(item.Value.r * 255), 0, 255),
                            Mathf.Clamp((int)(item.Value.g * 255), 0, 255),
                            Mathf.Clamp((int)(item.Value.b * 255), 0, 255)));
                    }
                    dicData.Clear();

                    g.DrawImage(bitBuffer, 0, 0);
                    isDown = true;
                }
            }
        }



        /// <summary>
        /// 渲染深度
        /// </summary>
        public void RenderDepth(RaycastHit hit, int x, int y)
        {
            float depth = 255f - Math.Min((hit.Distance / maxDepth) * 255f, 255f);
            int depthInt = (int)depth;
            bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255, depthInt, depthInt, depthInt));
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
        }


        private ConcurrentDictionary<Vector2, Color> dicData = new ConcurrentDictionary<Vector2, Color>();
        /// <summary>
        /// 光线追踪
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RayTrace(Ray3 ray, RaycastHit hit, int x, int y)
        {
            Color color = hit.GameObject.RayMaterial.Sample(ray, hit.Position, hit.Normal);
            dicData.TryAdd(new Vector2(x, y), color);
            //bitBuffer.SetPixel(x, y, System.Drawing.Color.FromArgb(255,
            //    Mathf.Clamp((int)(color.r * 255), 0, 255),
            //    Mathf.Clamp((int)(color.g * 255), 0, 255),
            //    Mathf.Clamp((int)(color.b * 255), 0, 255)));
        }

    }
}
