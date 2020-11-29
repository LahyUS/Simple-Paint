using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharpGL_Programming.objects
{
    class Circle : Shape
    {
        private Point start;
        private Point end;
        private double radius;
        private Color mycolor;
        private float mywidth;
        private bool isfilled;
        private List<Point> vertices;
        private bool is_other_polygon;
        private Point center;

        public bool is_Other_Polygon
        {
            get => this.is_other_polygon;
            set => this.is_other_polygon = value;
        }

        public bool isFilled
        {
            get => isfilled;
            set => isfilled = value; 
        }

        public List<Point> Vertices
        {
            get
            {
                return this.vertices;
            }

            set
            {
                this.vertices = value;
            }
        }

        public Point Start { get => start; set => start = value; }

        public Point End { get => end; set => end = value; }

        public Point Center
        {
            get => this.center;
            set => this.center = value;
        }

        public double Radius { get => radius; set => radius = value; }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        // constructor 
        public Circle(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.is_other_polygon = false;
            this.start = Start;
            this.end = End;
            this.radius = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            this.mycolor = Color;
            this.mywidth = line_width;
            this.isfilled = filled;
        }

        public void draw(OpenGL gl, Color color, float width, int draw_mode)
        {
            if (draw_mode == 0)
                this.drawShape(gl, color, width);
            else
                this.drawWithAlgorithm(gl, color, width);
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            gl.LineWidth(line_width);
            // initialize circle information 
            const float pi = 3.14159f;
            double Radius = utils.Utils.calcDistance(start, end);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            // draw circle 
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                double rad = (i * pi) / 180;
                gl.Vertex(start.X + Radius * Math.Cos(rad), gl.RenderContextProvider.Height - (start.Y + Radius * Math.Sin(rad)));

                //utils.Utils.setPixel(setPoint.X, gl.RenderContextProvider.Height - setPoint.Y, gl, mycolor, (float)1.0f);
            }
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            // initialize information to draw circle
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            const float pi = 3.14159f;
            double Radius = utils.Utils.calcDistance(start, end);
            double xc = Start.X;
            double yc = Start.Y;
            double x = 0;
            double y = Radius;
            double p = 1 - Radius;
            double dx = 2 * x;
            double dy = 2 * y;

            // set pixel at begin coordinate
            utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
            utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);

            // drawing loop
            while (x < y)
            {
                x++;
                if (p <= 0)
                {
                    dx += 2;
                    p += dx + 1;
                }

                else
                {
                    y--;
                    dx = dx + 2;
                    dy = dy - 2;
                    p += dx - dy + 1;
                    
                }

                // set symmetry pixel at 8 part of cirlce
                utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);

                utils.Utils.setPixel((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc + x)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc + x)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc - x)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc - x)), gl, color, line_width);
            }
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
        {
            if (fill_mode == 0)
                this.Fill_With_Scanline_Mode(gl, mycolor);
            else
                this.Fill_With_Spill_Mode(gl, mycolor);
        }

        public void Fill_With_Spill_Mode(OpenGL gl, Color mycolor)
        {

        }

        private void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {  
            const float pi = 3.14159f;
            double radius = utils.Utils.calcDistance(start, end);
            utils.Custom_Color currentcolor = new utils.Custom_Color(mycolor.R, mycolor.G, mycolor.B);

            // initialize information to draw circle
            double Radius = utils.Utils.calcDistance(start, end);
            double xc = Start.X;
            double yc = Start.Y;
            double x = 0;
            double y = Radius;
            double p = 1 - Radius;
            double dx = 2 * x;
            double dy = 2 * y;

            // fill diameter
            Point right = new Point((int)(xc + Radius), (int)(gl.RenderContextProvider.Height - yc));
            Point left = new Point((int)(xc - Radius), (int)(gl.RenderContextProvider.Height - yc));
            Line line = new Line(left, right, mycolor);
            line.drawShape(gl, mycolor);

            // drawing loop
            while (x < y)
            {
                x++;
                if (p <= 0)
                {
                    dx += 2;
                    p += dx + 1;
                }

                else
                {
                    y--;
                    dx = dx + 2;
                    dy = dy - 2;
                    p += dx - dy + 1;
                }

                // set symmetry pixel at 8 part of cirlce
                // x : y , -x : y
                Point right1 = new Point((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)));
                Point left1 = new Point((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)));
                Line line1 = new Line(left1, right1, mycolor);
                line1.drawShape(gl, mycolor);

                // x : -y , -x : -y
                Point right2 = new Point((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)));
                Point left2 = new Point((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)));
                Line line2 = new Line(left2, right2, mycolor);
                line2.drawShape(gl, mycolor);

                // y : x , -y : x
                Point right3 = new Point((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc + x)));
                Point left3 = new Point((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc + x)));
                Line line3 = new Line(left3, right3, mycolor);
                line3.drawShape(gl, mycolor);

                // y : -x , -y : -x
                Point right4 = new Point((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc - x)));
                Point left4 = new Point((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc - x)));
                Line line4 = new Line(left4, right4, mycolor);
                line4.drawShape(gl, mycolor);
            }

            gl.End();
            gl.Flush();
        }
    }
}
