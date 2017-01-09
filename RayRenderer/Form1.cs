using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayRenderer
{
    public partial class Form1 : Form
    {
        Graphics g;

        /// <summary>
        /// 帧缓冲
        /// </summary>
        Bitmap bitBuffer;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            bitBuffer = new Bitmap(256, 256);
            timer.Enabled = true;
            timer.Interval = 1000 / 1;
            timer.Tick += Timer_Tick;
            timer.Start();

            
        }

        /// <summary>
        /// 绘制
        /// </summary>
        public void Draw()
        {
            g.Clear(Color.Black);

            Sphere sphere = new RayRenderer.Sphere(10);
            sphere.Transform.position = new RayRenderer.Vector3(0, 10, -10);
            Camera camera = new RayRenderer.Camera(new Vector3(0, 10, 10), new Vector3(0, 0, -1), new Vector3(0, 1, 0), 90);

            int w = bitBuffer.Width;
            int h = bitBuffer.Height;

            for (int y = 0; y < h; y++)
            {
                float sy = 1f - (float)y / (float)h;
                for (int x = 0; x < w; x++)
                {
                    float sx = (float)x / (float)w;
                    Ray3 ray = camera.GenerateRay(sx, sy);
                    RaycastHit hit = sphere.Intersect(ray);
                    if (hit.GameObject != null)
                    {
                        float depth = 255 - Math.Min((hit.Distance / 20) * 255, 255);
                        int depthInt = (int)depth;
                        bitBuffer.SetPixel(x, y, Color.FromArgb(255, depthInt, depthInt, depthInt));
                    }

                   // bitBuffer.SetPixel(x, y, Color.FromArgb(255, (int)(((float)x / (float)w )* 255), (int)(((float)y / (float)h) * 255), 255));
                }
            }


            g.DrawImage(bitBuffer, 0, 0);

        }
        



        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
        }


        //protected override void OnPaint(PaintEventArgs e)
        //{
        //}

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
