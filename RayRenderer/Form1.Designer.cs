namespace RayRenderer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFPS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.barLight = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRendererMode = new System.Windows.Forms.ComboBox();
            this.cmbRendererType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLightType = new System.Windows.Forms.ComboBox();
            this.lblLightType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLight)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFPS
            // 
            this.lblFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFPS.AutoSize = true;
            this.lblFPS.BackColor = System.Drawing.Color.Transparent;
            this.lblFPS.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFPS.Location = new System.Drawing.Point(459, 20);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(11, 12);
            this.lblFPS.TabIndex = 0;
            this.lblFPS.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(424, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "FPS:";
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.Location = new System.Drawing.Point(1, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(311, 292);
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // barLight
            // 
            this.barLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.barLight.Location = new System.Drawing.Point(425, 215);
            this.barLight.Minimum = -10;
            this.barLight.Name = "barLight";
            this.barLight.Size = new System.Drawing.Size(201, 45);
            this.barLight.SmallChange = 0;
            this.barLight.TabIndex = 5;
            this.barLight.Value = 10;
            this.barLight.Scroll += new System.EventHandler(this.barLight_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "渲染模式：";
            // 
            // cmbRendererMode
            // 
            this.cmbRendererMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRendererMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRendererMode.FormattingEnabled = true;
            this.cmbRendererMode.Items.AddRange(new object[] {
            "深度",
            "法线",
            "全局光照",
            "带反射Phong材质"});
            this.cmbRendererMode.Location = new System.Drawing.Point(486, 104);
            this.cmbRendererMode.Name = "cmbRendererMode";
            this.cmbRendererMode.Size = new System.Drawing.Size(121, 20);
            this.cmbRendererMode.TabIndex = 7;
            this.cmbRendererMode.SelectedIndexChanged += new System.EventHandler(this.cmbRendererMode_SelectedIndexChanged);
            // 
            // cmbRendererType
            // 
            this.cmbRendererType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRendererType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRendererType.FormattingEnabled = true;
            this.cmbRendererType.Items.AddRange(new object[] {
            "光线追踪渲染器"});
            this.cmbRendererType.Location = new System.Drawing.Point(486, 64);
            this.cmbRendererType.Name = "cmbRendererType";
            this.cmbRendererType.Size = new System.Drawing.Size(121, 20);
            this.cmbRendererType.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "渲染器：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "光照位置：";
            // 
            // cmbLightType
            // 
            this.cmbLightType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLightType.FormattingEnabled = true;
            this.cmbLightType.Items.AddRange(new object[] {
            "平行光",
            "点光源",
            "聚光灯"});
            this.cmbLightType.Location = new System.Drawing.Point(486, 145);
            this.cmbLightType.Name = "cmbLightType";
            this.cmbLightType.Size = new System.Drawing.Size(121, 20);
            this.cmbLightType.TabIndex = 12;
            this.cmbLightType.SelectedIndexChanged += new System.EventHandler(this.cmbLightType_SelectedIndexChanged);
            // 
            // lblLightType
            // 
            this.lblLightType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightType.AutoSize = true;
            this.lblLightType.Location = new System.Drawing.Point(425, 148);
            this.lblLightType.Name = "lblLightType";
            this.lblLightType.Size = new System.Drawing.Size(65, 12);
            this.lblLightType.TabIndex = 11;
            this.lblLightType.Text = "光照模式：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 295);
            this.Controls.Add(this.cmbLightType);
            this.Controls.Add(this.lblLightType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRendererType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRendererMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.barLight);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFPS);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TrackBar barLight;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRendererMode;
        private System.Windows.Forms.ComboBox cmbRendererType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLightType;
        private System.Windows.Forms.Label lblLightType;
    }
}

