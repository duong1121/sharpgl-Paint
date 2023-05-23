namespace btaa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_Circle = new System.Windows.Forms.Button();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.bt_Line = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_Color1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.bt_Rectangle = new System.Windows.Forms.Button();
            this.bt_Ellipse = new System.Windows.Forms.Button();
            this.bt_Triangle = new System.Windows.Forms.Button();
            this.bt_Pentagon = new System.Windows.Forms.Button();
            this.bt_Hexagon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Circle
            // 
            this.bt_Circle.Location = new System.Drawing.Point(94, 37);
            this.bt_Circle.Name = "bt_Circle";
            this.bt_Circle.Size = new System.Drawing.Size(76, 42);
            this.bt_Circle.TabIndex = 0;
            this.bt_Circle.Text = "Circle";
            this.bt_Circle.UseVisualStyleBackColor = true;
            this.bt_Circle.Click += new System.EventHandler(this.bt_Circle_Click);
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(12, 89);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(596, 358);
            this.openGLControl.TabIndex = 1;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.Load += new System.EventHandler(this.openGLControl_Load);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // bt_Line
            // 
            this.bt_Line.Location = new System.Drawing.Point(12, 37);
            this.bt_Line.Name = "bt_Line";
            this.bt_Line.Size = new System.Drawing.Size(76, 42);
            this.bt_Line.TabIndex = 0;
            this.bt_Line.Text = "Line";
            this.bt_Line.UseVisualStyleBackColor = true;
            this.bt_Line.Click += new System.EventHandler(this.bt_Line_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bt_Color1
            // 
            this.bt_Color1.Location = new System.Drawing.Point(526, 3);
            this.bt_Color1.Name = "bt_Color1";
            this.bt_Color1.Size = new System.Drawing.Size(82, 33);
            this.bt_Color1.TabIndex = 2;
            this.bt_Color1.Text = "Color";
            this.bt_Color1.UseVisualStyleBackColor = true;
            this.bt_Color1.Click += new System.EventHandler(this.bt_Color_Click);
            // 
            // bt_Rectangle
            // 
            this.bt_Rectangle.Location = new System.Drawing.Point(176, 37);
            this.bt_Rectangle.Name = "bt_Rectangle";
            this.bt_Rectangle.Size = new System.Drawing.Size(76, 42);
            this.bt_Rectangle.TabIndex = 3;
            this.bt_Rectangle.Text = "Rectangle";
            this.bt_Rectangle.UseVisualStyleBackColor = true;
            this.bt_Rectangle.Click += new System.EventHandler(this.bt_Rectangle_Click);
            // 
            // bt_Ellipse
            // 
            this.bt_Ellipse.Location = new System.Drawing.Point(258, 37);
            this.bt_Ellipse.Name = "bt_Ellipse";
            this.bt_Ellipse.Size = new System.Drawing.Size(76, 42);
            this.bt_Ellipse.TabIndex = 4;
            this.bt_Ellipse.Text = "Ellipse";
            this.bt_Ellipse.UseVisualStyleBackColor = true;
            this.bt_Ellipse.Click += new System.EventHandler(this.bt_Ellipse_Click);
            // 
            // bt_Triangle
            // 
            this.bt_Triangle.Location = new System.Drawing.Point(340, 37);
            this.bt_Triangle.Name = "bt_Triangle";
            this.bt_Triangle.Size = new System.Drawing.Size(75, 42);
            this.bt_Triangle.TabIndex = 5;
            this.bt_Triangle.Text = "E Triangle";
            this.bt_Triangle.UseVisualStyleBackColor = true;
            this.bt_Triangle.Click += new System.EventHandler(this.bt_Triangle_Click);
            // 
            // bt_Pentagon
            // 
            this.bt_Pentagon.Location = new System.Drawing.Point(421, 37);
            this.bt_Pentagon.Name = "bt_Pentagon";
            this.bt_Pentagon.Size = new System.Drawing.Size(75, 42);
            this.bt_Pentagon.TabIndex = 6;
            this.bt_Pentagon.Text = "E Pentagon";
            this.bt_Pentagon.UseVisualStyleBackColor = true;
            this.bt_Pentagon.Click += new System.EventHandler(this.bt_Pentagon_Click);
            // 
            // bt_Hexagon
            // 
            this.bt_Hexagon.Location = new System.Drawing.Point(502, 37);
            this.bt_Hexagon.Name = "bt_Hexagon";
            this.bt_Hexagon.Size = new System.Drawing.Size(75, 42);
            this.bt_Hexagon.TabIndex = 7;
            this.bt_Hexagon.Text = "E Hexagon";
            this.bt_Hexagon.UseVisualStyleBackColor = true;
            this.bt_Hexagon.Click += new System.EventHandler(this.bt_Hexagon_Click);
            this.bt_Hexagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_Hexagon_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Polygon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 468);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_Hexagon);
            this.Controls.Add(this.bt_Pentagon);
            this.Controls.Add(this.bt_Triangle);
            this.Controls.Add(this.bt_Ellipse);
            this.Controls.Add(this.bt_Rectangle);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.bt_Color1);
            this.Controls.Add(this.bt_Line);
            this.Controls.Add(this.bt_Circle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Color1;
        private System.Windows.Forms.Button bt_Line;
        private System.Windows.Forms.Button bt_Circle;
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button bt_Rectangle;
        private System.Windows.Forms.Button bt_Ellipse;
        private System.Windows.Forms.Button bt_Triangle;
        private System.Windows.Forms.Button bt_Pentagon;
        private System.Windows.Forms.Button bt_Hexagon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

