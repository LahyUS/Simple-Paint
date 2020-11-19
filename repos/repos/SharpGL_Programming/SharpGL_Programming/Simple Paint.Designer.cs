namespace SharpGL_Programming
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.line = new System.Windows.Forms.Button();
            this.circle = new System.Windows.Forms.Button();
            this.color = new System.Windows.Forms.Button();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.rectangle = new System.Windows.Forms.Button();
            this.ellipse = new System.Windows.Forms.Button();
            this.equilateral_triangle = new System.Windows.Forms.Button();
            this.equilateral_pentagon = new System.Windows.Forms.Button();
            this.equilateral_hexagon = new System.Windows.Forms.Button();
            this.Capacity = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.select_size = new System.Windows.Forms.ComboBox();
            this.shapeBox = new System.Windows.Forms.GroupBox();
            this.drawing_time = new System.Windows.Forms.Label();
            this.about_app = new System.Windows.Forms.GroupBox();
            this.infor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.shapeBox.SuspendLayout();
            this.about_app.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.Color.LightSkyBlue;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.openGLControl.Location = new System.Drawing.Point(199, -1);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(758, 452);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // line
            // 
            this.line.Cursor = System.Windows.Forms.Cursors.Hand;
            this.line.Location = new System.Drawing.Point(6, 26);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(75, 23);
            this.line.TabIndex = 1;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // circle
            // 
            this.circle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circle.Location = new System.Drawing.Point(6, 55);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(73, 23);
            this.circle.TabIndex = 2;
            this.circle.Text = "Circle";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // color
            // 
            this.color.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("color.BackgroundImage")));
            this.color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.color.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color.ForeColor = System.Drawing.Color.Red;
            this.color.Location = new System.Drawing.Point(118, 153);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(75, 23);
            this.color.TabIndex = 3;
            this.color.Text = "Color";
            this.color.UseVisualStyleBackColor = true;
            this.color.Click += new System.EventHandler(this.color_Click);
            // 
            // rectangle
            // 
            this.rectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangle.Location = new System.Drawing.Point(6, 113);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(73, 23);
            this.rectangle.TabIndex = 4;
            this.rectangle.Text = "Rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // ellipse
            // 
            this.ellipse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ellipse.Location = new System.Drawing.Point(6, 84);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(73, 23);
            this.ellipse.TabIndex = 5;
            this.ellipse.Text = "Ellipse";
            this.ellipse.UseVisualStyleBackColor = true;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // equilateral_triangle
            // 
            this.equilateral_triangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_triangle.Location = new System.Drawing.Point(6, 142);
            this.equilateral_triangle.Name = "equilateral_triangle";
            this.equilateral_triangle.Size = new System.Drawing.Size(73, 36);
            this.equilateral_triangle.TabIndex = 6;
            this.equilateral_triangle.Text = "Equilateral Triangle";
            this.equilateral_triangle.UseVisualStyleBackColor = true;
            this.equilateral_triangle.Click += new System.EventHandler(this.equilateral_triangle_Click);
            // 
            // equilateral_pentagon
            // 
            this.equilateral_pentagon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_pentagon.Location = new System.Drawing.Point(6, 184);
            this.equilateral_pentagon.Name = "equilateral_pentagon";
            this.equilateral_pentagon.Size = new System.Drawing.Size(73, 42);
            this.equilateral_pentagon.TabIndex = 7;
            this.equilateral_pentagon.Text = "Equilateral Pentagon";
            this.equilateral_pentagon.UseVisualStyleBackColor = true;
            this.equilateral_pentagon.Click += new System.EventHandler(this.equilateral_pentagon_Click);
            // 
            // equilateral_hexagon
            // 
            this.equilateral_hexagon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_hexagon.Location = new System.Drawing.Point(6, 232);
            this.equilateral_hexagon.Name = "equilateral_hexagon";
            this.equilateral_hexagon.Size = new System.Drawing.Size(73, 36);
            this.equilateral_hexagon.TabIndex = 8;
            this.equilateral_hexagon.Text = "Equilateral Hexagon";
            this.equilateral_hexagon.UseVisualStyleBackColor = true;
            this.equilateral_hexagon.Click += new System.EventHandler(this.equilateral_hexagon_Click);
            // 
            // Capacity
            // 
            this.Capacity.BackColor = System.Drawing.Color.LightBlue;
            this.Capacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Capacity.Location = new System.Drawing.Point(118, 37);
            this.Capacity.Name = "Capacity";
            this.Capacity.Size = new System.Drawing.Size(75, 23);
            this.Capacity.TabIndex = 9;
            this.Capacity.Text = "Capacity";
            this.Capacity.UseVisualStyleBackColor = false;
            this.Capacity.Click += new System.EventHandler(this.Capacity_Click);
            // 
            // select_size
            // 
            this.select_size.BackColor = System.Drawing.Color.White;
            this.select_size.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_size.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.select_size.FormattingEnabled = true;
            this.select_size.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.select_size.Location = new System.Drawing.Point(118, 66);
            this.select_size.Name = "select_size";
            this.select_size.Size = new System.Drawing.Size(75, 21);
            this.select_size.TabIndex = 10;
            this.select_size.Text = "Level";
            this.select_size.SelectedIndexChanged += new System.EventHandler(this.select_size_SelectedIndexChanged);
            // 
            // shapeBox
            // 
            this.shapeBox.Controls.Add(this.rectangle);
            this.shapeBox.Controls.Add(this.line);
            this.shapeBox.Controls.Add(this.circle);
            this.shapeBox.Controls.Add(this.equilateral_pentagon);
            this.shapeBox.Controls.Add(this.equilateral_hexagon);
            this.shapeBox.Controls.Add(this.equilateral_triangle);
            this.shapeBox.Controls.Add(this.ellipse);
            this.shapeBox.Location = new System.Drawing.Point(12, 11);
            this.shapeBox.Name = "shapeBox";
            this.shapeBox.Size = new System.Drawing.Size(85, 284);
            this.shapeBox.TabIndex = 11;
            this.shapeBox.TabStop = false;
            this.shapeBox.Text = "Shape";
            // 
            // drawing_time
            // 
            this.drawing_time.AutoSize = true;
            this.drawing_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drawing_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawing_time.Location = new System.Drawing.Point(18, 324);
            this.drawing_time.Name = "drawing_time";
            this.drawing_time.Size = new System.Drawing.Size(41, 15);
            this.drawing_time.TabIndex = 12;
            this.drawing_time.Text = "Time : ";
            // 
            // about_app
            // 
            this.about_app.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.about_app.Controls.Add(this.infor);
            this.about_app.Location = new System.Drawing.Point(12, 403);
            this.about_app.Name = "about_app";
            this.about_app.Size = new System.Drawing.Size(181, 35);
            this.about_app.TabIndex = 13;
            this.about_app.TabStop = false;
            this.about_app.Text = "About Application";
            // 
            // infor
            // 
            this.infor.AutoSize = true;
            this.infor.BackColor = System.Drawing.Color.RoyalBlue;
            this.infor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infor.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.infor.Location = new System.Drawing.Point(103, 16);
            this.infor.Name = "infor";
            this.infor.Size = new System.Drawing.Size(59, 13);
            this.infor.TabIndex = 0;
            this.infor.Text = "Information";
            this.infor.Click += new System.EventHandler(this.infor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 450);
            this.Controls.Add(this.about_app);
            this.Controls.Add(this.drawing_time);
            this.Controls.Add(this.shapeBox);
            this.Controls.Add(this.select_size);
            this.Controls.Add(this.Capacity);
            this.Controls.Add(this.color);
            this.Controls.Add(this.openGLControl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.shapeBox.ResumeLayout(false);
            this.about_app.ResumeLayout(false);
            this.about_app.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Button color;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button ellipse;
        private System.Windows.Forms.Button equilateral_triangle;
        private System.Windows.Forms.Button equilateral_pentagon;
        private System.Windows.Forms.Button equilateral_hexagon;
        private System.Windows.Forms.Button Capacity;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox select_size;
        private System.Windows.Forms.GroupBox shapeBox;
        private System.Windows.Forms.Label drawing_time;
        private System.Windows.Forms.GroupBox about_app;
        private System.Windows.Forms.Label infor;
    }
}

