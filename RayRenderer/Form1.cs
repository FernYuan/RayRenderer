using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayRenderer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 光线追踪渲染器
        /// </summary>
        private RayRenderer rayRenderer;

        public Form1()
        {
            InitializeComponent();

        }


        System.Timers.Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {

            rayRenderer = new RayRenderer(new Camera(new Vector3(0, 5, 15), new Vector3(0, 0, -1), new Vector3(0, 1, 0), 90),
           new Bitmap(256, 256), this.pic.CreateGraphics(), 20);
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 1000 / 60;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


        }

        private void OnFPSChange(float mFPS)
        {
            this.lblFPS.Text = mFPS.ToString();
        }

        private object isLock = new object();

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (isLock)
            {
                Draw();
            }
        }

        /// <summary>
        /// 计时器
        /// </summary>
        private Stopwatch sw = new Stopwatch();
        /// <summary>
        /// 绘制
        /// </summary>
        public void Draw()
        {

            sw.Restart();

            rayRenderer.Rendering();


            sw.Stop();




            int fps = (int)(60f / (sw.ElapsedMilliseconds / (1000f / 60f)));

            Action<int> action = new Action<int>((num) => { lblFPS.Text = num.ToString(); });

            if (this.lblFPS.Disposing || this.lblFPS.IsDisposed)
            {
                return;
            }

            this.lblFPS.Invoke(action, fps);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

      

        private void barLight_Scroll(object sender, EventArgs e)
        {
            PhongMaterial.light.direction = new Vector3(barLight.Value, 1, 1).Normalize();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                PhongMaterial.light.color = new Color(255f / (float)colorDialog.Color.R, 255f / (float)colorDialog.Color.G, 255f / (float)colorDialog.Color.B);
            }
        }
    }
}
