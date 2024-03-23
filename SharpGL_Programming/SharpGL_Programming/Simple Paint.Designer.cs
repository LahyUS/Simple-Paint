namespace SharpGL_Programming
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
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
            this.polygon = new System.Windows.Forms.Button();
            this.line_time = new System.Windows.Forms.Label();
            this.about_app = new System.Windows.Forms.GroupBox();
            this.infor = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Draw_style = new System.Windows.Forms.ComboBox();
            this.tool_bar = new System.Windows.Forms.GroupBox();
            this.fill = new System.Windows.Forms.Button();
            this.clean = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.GroupBox();
            this.polygon_time = new System.Windows.Forms.Label();
            this.stop_timer = new System.Windows.Forms.Button();
            this.hexagon_time = new System.Windows.Forms.Label();
            this.reset_timer = new System.Windows.Forms.Button();
            this.circle_time = new System.Windows.Forms.Label();
            this.ellipse_time = new System.Windows.Forms.Label();
            this.rectangle_time = new System.Windows.Forms.Label();
            this.triangle_time = new System.Windows.Forms.Label();
            this.pentagon_time = new System.Windows.Forms.Label();
            this.fillmode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.shapeBox.SuspendLayout();
            this.about_app.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tool_bar.SuspendLayout();
            this.timer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.SystemColors.Control;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl.Location = new System.Drawing.Point(298, 11);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(609, 447);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseClick);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // line
            // 
            this.line.Cursor = System.Windows.Forms.Cursors.Hand;
            this.line.Location = new System.Drawing.Point(0, 25);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(85, 30);
            this.line.TabIndex = 1;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // circle
            // 
            this.circle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circle.Location = new System.Drawing.Point(0, 66);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(85, 27);
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
            this.color.Location = new System.Drawing.Point(0, 65);
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
            this.rectangle.Location = new System.Drawing.Point(0, 144);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(85, 32);
            this.rectangle.TabIndex = 4;
            this.rectangle.Text = "Rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // ellipse
            // 
            this.ellipse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ellipse.Location = new System.Drawing.Point(0, 102);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(85, 28);
            this.ellipse.TabIndex = 5;
            this.ellipse.Text = "Ellipse";
            this.ellipse.UseVisualStyleBackColor = true;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // equilateral_triangle
            // 
            this.equilateral_triangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_triangle.Location = new System.Drawing.Point(0, 188);
            this.equilateral_triangle.Name = "equilateral_triangle";
            this.equilateral_triangle.Size = new System.Drawing.Size(85, 27);
            this.equilateral_triangle.TabIndex = 6;
            this.equilateral_triangle.Text = "Triangle";
            this.equilateral_triangle.UseVisualStyleBackColor = true;
            this.equilateral_triangle.Click += new System.EventHandler(this.equilateral_triangle_Click);
            // 
            // equilateral_pentagon
            // 
            this.equilateral_pentagon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_pentagon.Location = new System.Drawing.Point(0, 227);
            this.equilateral_pentagon.Name = "equilateral_pentagon";
            this.equilateral_pentagon.Size = new System.Drawing.Size(85, 29);
            this.equilateral_pentagon.TabIndex = 7;
            this.equilateral_pentagon.Text = "Pentagon";
            this.equilateral_pentagon.UseVisualStyleBackColor = true;
            this.equilateral_pentagon.Click += new System.EventHandler(this.equilateral_pentagon_Click);
            // 
            // equilateral_hexagon
            // 
            this.equilateral_hexagon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equilateral_hexagon.Location = new System.Drawing.Point(0, 271);
            this.equilateral_hexagon.Name = "equilateral_hexagon";
            this.equilateral_hexagon.Size = new System.Drawing.Size(85, 30);
            this.equilateral_hexagon.TabIndex = 8;
            this.equilateral_hexagon.Text = "Hexagon";
            this.equilateral_hexagon.UseVisualStyleBackColor = true;
            this.equilateral_hexagon.Click += new System.EventHandler(this.equilateral_hexagon_Click);
            // 
            // Capacity
            // 
            this.Capacity.BackColor = System.Drawing.Color.LightBlue;
            this.Capacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Capacity.Location = new System.Drawing.Point(0, 177);
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
            this.select_size.Location = new System.Drawing.Point(0, 194);
            this.select_size.Name = "select_size";
            this.select_size.Size = new System.Drawing.Size(75, 21);
            this.select_size.TabIndex = 10;
            this.select_size.Text = "Level";
            this.select_size.SelectedIndexChanged += new System.EventHandler(this.select_size_SelectedIndexChanged);
            // 
            // shapeBox
            // 
            this.shapeBox.Controls.Add(this.polygon);
            this.shapeBox.Controls.Add(this.rectangle);
            this.shapeBox.Controls.Add(this.line);
            this.shapeBox.Controls.Add(this.circle);
            this.shapeBox.Controls.Add(this.equilateral_pentagon);
            this.shapeBox.Controls.Add(this.equilateral_hexagon);
            this.shapeBox.Controls.Add(this.equilateral_triangle);
            this.shapeBox.Controls.Add(this.ellipse);
            this.shapeBox.Location = new System.Drawing.Point(3, 11);
            this.shapeBox.Name = "shapeBox";
            this.shapeBox.Size = new System.Drawing.Size(85, 375);
            this.shapeBox.TabIndex = 11;
            this.shapeBox.TabStop = false;
            this.shapeBox.Text = "Shape";
            // 
            // polygon
            // 
            this.polygon.Location = new System.Drawing.Point(0, 316);
            this.polygon.Name = "polygon";
            this.polygon.Size = new System.Drawing.Size(85, 23);
            this.polygon.TabIndex = 9;
            this.polygon.Text = "Polygon";
            this.polygon.UseVisualStyleBackColor = true;
            this.polygon.Click += new System.EventHandler(this.polygon_Click);
            // 
            // line_time
            // 
            this.line_time.AutoSize = true;
            this.line_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.line_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line_time.Location = new System.Drawing.Point(6, 33);
            this.line_time.Name = "line_time";
            this.line_time.Size = new System.Drawing.Size(41, 15);
            this.line_time.TabIndex = 12;
            this.line_time.Text = "Time : ";
            this.line_time.Click += new System.EventHandler(this.drawing_time_Click);
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
            // Draw_style
            // 
            this.Draw_style.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Draw_style.FormattingEnabled = true;
            this.Draw_style.Items.AddRange(new object[] {
            "OpenGL",
            "Algorithm"});
            this.Draw_style.Location = new System.Drawing.Point(0, 26);
            this.Draw_style.Name = "Draw_style";
            this.Draw_style.Size = new System.Drawing.Size(75, 21);
            this.Draw_style.TabIndex = 14;
            this.Draw_style.Text = "Draw Style";
            this.Draw_style.SelectedIndexChanged += new System.EventHandler(this.Draw_style_SelectedIndexChanged);
            // 
            // tool_bar
            // 
            this.tool_bar.Controls.Add(this.fillmode);
            this.tool_bar.Controls.Add(this.fill);
            this.tool_bar.Controls.Add(this.clean);
            this.tool_bar.Controls.Add(this.color);
            this.tool_bar.Controls.Add(this.Draw_style);
            this.tool_bar.Controls.Add(this.Capacity);
            this.tool_bar.Controls.Add(this.select_size);
            this.tool_bar.Location = new System.Drawing.Point(209, 11);
            this.tool_bar.Name = "tool_bar";
            this.tool_bar.Size = new System.Drawing.Size(83, 375);
            this.tool_bar.TabIndex = 15;
            this.tool_bar.TabStop = false;
            this.tool_bar.Text = "Toolbar";
            // 
            // fill
            // 
            this.fill.BackColor = System.Drawing.Color.Red;
            this.fill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fill.Location = new System.Drawing.Point(0, 133);
            this.fill.Name = "fill";
            this.fill.Size = new System.Drawing.Size(75, 23);
            this.fill.TabIndex = 18;
            this.fill.Text = "Fill";
            this.fill.UseVisualStyleBackColor = false;
            this.fill.Click += new System.EventHandler(this.fill_Click);
            // 
            // clean
            // 
            this.clean.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clean.Location = new System.Drawing.Point(0, 235);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(75, 36);
            this.clean.TabIndex = 17;
            this.clean.Text = "Clean Screen";
            this.clean.UseVisualStyleBackColor = false;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // timer
            // 
            this.timer.Controls.Add(this.polygon_time);
            this.timer.Controls.Add(this.stop_timer);
            this.timer.Controls.Add(this.hexagon_time);
            this.timer.Controls.Add(this.reset_timer);
            this.timer.Controls.Add(this.circle_time);
            this.timer.Controls.Add(this.ellipse_time);
            this.timer.Controls.Add(this.rectangle_time);
            this.timer.Controls.Add(this.triangle_time);
            this.timer.Controls.Add(this.pentagon_time);
            this.timer.Controls.Add(this.line_time);
            this.timer.Location = new System.Drawing.Point(94, 12);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(109, 374);
            this.timer.TabIndex = 16;
            this.timer.TabStop = false;
            this.timer.Text = "Timer";
            // 
            // polygon_time
            // 
            this.polygon_time.AutoSize = true;
            this.polygon_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.polygon_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.polygon_time.Location = new System.Drawing.Point(6, 315);
            this.polygon_time.Name = "polygon_time";
            this.polygon_time.Size = new System.Drawing.Size(41, 15);
            this.polygon_time.TabIndex = 21;
            this.polygon_time.Text = "Time : ";
            // 
            // stop_timer
            // 
            this.stop_timer.BackColor = System.Drawing.Color.Tomato;
            this.stop_timer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_timer.Location = new System.Drawing.Point(64, 351);
            this.stop_timer.Name = "stop_timer";
            this.stop_timer.Size = new System.Drawing.Size(45, 23);
            this.stop_timer.TabIndex = 19;
            this.stop_timer.Text = "Stop";
            this.stop_timer.UseVisualStyleBackColor = false;
            this.stop_timer.Click += new System.EventHandler(this.stop_timer_Click);
            // 
            // hexagon_time
            // 
            this.hexagon_time.AutoSize = true;
            this.hexagon_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.hexagon_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hexagon_time.Location = new System.Drawing.Point(6, 279);
            this.hexagon_time.Name = "hexagon_time";
            this.hexagon_time.Size = new System.Drawing.Size(41, 15);
            this.hexagon_time.TabIndex = 18;
            this.hexagon_time.Text = "Time : ";
            // 
            // reset_timer
            // 
            this.reset_timer.BackColor = System.Drawing.Color.RoyalBlue;
            this.reset_timer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset_timer.Location = new System.Drawing.Point(0, 351);
            this.reset_timer.Name = "reset_timer";
            this.reset_timer.Size = new System.Drawing.Size(47, 23);
            this.reset_timer.TabIndex = 20;
            this.reset_timer.Text = "Reset";
            this.reset_timer.UseVisualStyleBackColor = false;
            this.reset_timer.Click += new System.EventHandler(this.reset_timer_Click);
            // 
            // circle_time
            // 
            this.circle_time.AutoSize = true;
            this.circle_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.circle_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.circle_time.Location = new System.Drawing.Point(6, 72);
            this.circle_time.Name = "circle_time";
            this.circle_time.Size = new System.Drawing.Size(41, 15);
            this.circle_time.TabIndex = 17;
            this.circle_time.Text = "Time : ";
            // 
            // ellipse_time
            // 
            this.ellipse_time.AutoSize = true;
            this.ellipse_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ellipse_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ellipse_time.Location = new System.Drawing.Point(6, 109);
            this.ellipse_time.Name = "ellipse_time";
            this.ellipse_time.Size = new System.Drawing.Size(41, 15);
            this.ellipse_time.TabIndex = 16;
            this.ellipse_time.Text = "Time : ";
            // 
            // rectangle_time
            // 
            this.rectangle_time.AutoSize = true;
            this.rectangle_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rectangle_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rectangle_time.Location = new System.Drawing.Point(6, 153);
            this.rectangle_time.Name = "rectangle_time";
            this.rectangle_time.Size = new System.Drawing.Size(41, 15);
            this.rectangle_time.TabIndex = 15;
            this.rectangle_time.Text = "Time : ";
            // 
            // triangle_time
            // 
            this.triangle_time.AutoSize = true;
            this.triangle_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.triangle_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.triangle_time.Location = new System.Drawing.Point(6, 194);
            this.triangle_time.Name = "triangle_time";
            this.triangle_time.Size = new System.Drawing.Size(41, 15);
            this.triangle_time.TabIndex = 14;
            this.triangle_time.Text = "Time : ";
            // 
            // pentagon_time
            // 
            this.pentagon_time.AutoSize = true;
            this.pentagon_time.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pentagon_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pentagon_time.Location = new System.Drawing.Point(6, 234);
            this.pentagon_time.Name = "pentagon_time";
            this.pentagon_time.Size = new System.Drawing.Size(41, 15);
            this.pentagon_time.TabIndex = 13;
            this.pentagon_time.Text = "Time : ";
            // 
            // fillmode
            // 
            this.fillmode.FormattingEnabled = true;
            this.fillmode.Items.AddRange(new object[] {
            "Scan Line ",
            "Spill"});
            this.fillmode.Location = new System.Drawing.Point(0, 106);
            this.fillmode.Name = "fillmode";
            this.fillmode.Size = new System.Drawing.Size(75, 21);
            this.fillmode.TabIndex = 19;
            this.fillmode.Text = "Fill Mode";
            this.fillmode.SelectedIndexChanged += new System.EventHandler(this.fillmode_SelectedIndexChanged);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 452);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.tool_bar);
            this.Controls.Add(this.about_app);
            this.Controls.Add(this.shapeBox);
            this.Controls.Add(this.openGLControl);
            this.Name = "Paint";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Paint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.shapeBox.ResumeLayout(false);
            this.about_app.ResumeLayout(false);
            this.about_app.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tool_bar.ResumeLayout(false);
            this.timer.ResumeLayout(false);
            this.timer.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label line_time;
        private System.Windows.Forms.GroupBox about_app;
        private System.Windows.Forms.Label infor;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox Draw_style;
        private System.Windows.Forms.GroupBox tool_bar;
        private System.Windows.Forms.GroupBox timer;
        private System.Windows.Forms.Label hexagon_time;
        private System.Windows.Forms.Label ellipse_time;
        private System.Windows.Forms.Label rectangle_time;
        private System.Windows.Forms.Label triangle_time;
        private System.Windows.Forms.Label pentagon_time;
        private System.Windows.Forms.Label circle_time;
        private System.Windows.Forms.Button stop_timer;
        private System.Windows.Forms.Button reset_timer;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button fill;
        private System.Windows.Forms.Button polygon;
        private System.Windows.Forms.Label polygon_time;
        private System.Windows.Forms.ComboBox fillmode;
    }
}

