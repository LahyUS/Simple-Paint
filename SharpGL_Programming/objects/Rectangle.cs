using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    class Rectangle : Shape
    {
        private Point start; // topleft
        private Point end;   // bottom right
        private Color mycolor;
        private float mywidth;
        private List<Point> vertices;
        private bool isfilled;
        private bool is_other_polygon;
        private Point center;
        private bool is_trans;
        private utils.Affine myAF;

        public utils.Affine AF
        {
            get => this.myAF;
            set => this.myAF = value;
        }
        public bool Is_trans
        {
            get => this.is_trans;
            set => this.is_trans = value;
        }

        public bool is_Other_Polygon
        {
            get => this.is_other_polygon;
            set => this.is_other_polygon = value;
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

        public bool isFilled
        {
            get => isfilled;
            set { isfilled = value; }
        }

        public Point Start { get => start; set => start = value; }

        public Point End { get => end; set => end = value; }

        public Point Center
        {
            get => this.center;
            set => this.center = value;
        }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        // Constructor 
        public Rectangle(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.is_other_polygon = false;
            this.start = Start;
            this.end = End;
            this.mycolor = Color;
            this.mywidth = line_width;
            this.isfilled = filled;

            float edge_a = Math.Abs(Start.X - End.X) / 2;
            float edge_b = Math.Abs(Start.Y - End.Y) / 2;
            int center_x = Math.Min(Start.X, End.X) + (int)edge_a;
            int center_y = Math.Min(Start.Y, End.Y) + (int)edge_b;
            Point Center = new Point(center_x, center_y);
            this.center = Center;
            this.myAF = new utils.Affine();
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
            // if this shape has affine transformation, apply it when drawing
            if (Is_trans == true)
            {
                float x1, x2, y1, y2;
                x1 = (float)Start.X;
                x2 = (float)End.X;
                y1 = (float)Start.Y;
                y2 = (float)End.Y;

                this.AF.TransformPoint(ref x1, ref y1);
                this.AF.TransformPoint(ref x2,ref y2);

                // draw lines
                gl.LineWidth(line_width);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
                gl.Vertex(x2, gl.RenderContextProvider.Height - y1);
                gl.Vertex(x2, gl.RenderContextProvider.Height - y2);
                gl.Vertex(x1, gl.RenderContextProvider.Height - y2);
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }
            // this shape has no affine transformation
            else
            {
                // create 2 Point that define a rectangle
                gl.LineWidth(line_width);
                Point topright = new Point(end.X, start.Y);
                Point botleft = new Point(start.X, end.Y);

                // draw lines
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
                gl.Vertex(end.X, gl.RenderContextProvider.Height - start.Y);
                gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
                gl.Vertex(start.X, gl.RenderContextProvider.Height - end.Y);
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            // if this shape has affine transformation, apply it when drawing
            if (this.Is_trans == true)
            {
                // Get create line of each edge
                {
                    float x1, y1, x2, y2;
                    x1 = (float)Start.X;
                    y1 = (float)Start.Y;
                    x2 = (float)Start.X;
                    y2 = (float)End.Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    Line l1 = new Line(new Point((int)x1, (int)y1),
                        new Point((int)x2, (int)y2), Color, line_width, true);
                    l1.drawWithAlgorithm(gl, color, line_width);
                }

                {
                    float x1, y1, x2, y2;
                    x1 = (float)Start.X;
                    y1 = (float)Start.Y;
                    x2 = (float)End.X;
                    y2 = (float)Start.Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    Line l2 = new Line(new Point((int)x1, (int)y1),
                        new Point((int)x2, (int)y2), Color, line_width, true);
                    l2.drawWithAlgorithm(gl, color, line_width);
                    
                }

                {
                    float x1, y1, x2, y2;
                    x1 = (float)Start.X;
                    y1 = (float)End.Y;
                    x2 = (float)End.X;
                    y2 = (float)End.Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    Line l3 = new Line(new Point((int)x1, (int)y1),
                        new Point((int)x2, (int)y2), Color, line_width, true);
                    l3.drawWithAlgorithm(gl, color, line_width);
                }

                {
                    float x1, y1, x2, y2;
                    x1 = (float)End.X;
                    y1 = (float)Start.Y;
                    x2 = (float)End.X;
                    y2 = (float)End.Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    Line l4 = new Line(new Point((int)x1, (int)y1),
                        new Point((int)x2, (int)y2), Color, line_width, true);
                    l4.drawWithAlgorithm(gl, color, line_width);
                }
            }

            // this shape has no affine transformation
            else
            {
                // Get create line of each edge
                Line l1 = new Line(new Point(Start.X, Start.Y),
                    new Point(Start.X, End.Y), Color, line_width, true);

                Line l2 = new Line(new Point(Start.X, Start.Y),
                    new Point(End.X, Start.Y), Color, line_width, true);

                Line l3 = new Line(new Point(Start.X, End.Y),
                    new Point(End.X, End.Y), Color, line_width, true);

                Line l4 = new Line(new Point(End.X, Start.Y),
                    new Point(End.X, End.Y), Color, line_width, true);

                // draw each line with method of Line class
                l1.drawWithAlgorithm(gl, color, line_width);
                l2.drawWithAlgorithm(gl, color, line_width);
                l3.drawWithAlgorithm(gl, color, line_width);
                l4.drawWithAlgorithm(gl, color, line_width);
            }
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
        {
            if (fill_mode == 0)
                this.Fill_With_Scanline_Mode(gl, mycolor);
            else
                this.Fill_With_Spill_Mode(gl, mycolor);
        }

        private void Fill_With_Spill_Mode(OpenGL gl, Color mycolor)
        {
            int top, bot, left, right;

            if (Start.X - End.X > 0)
            {
                left = End.X;
                right = Start.X;
            }
            else
            {
                left = Start.X;
                right = End.X;
            }
            if(Start.Y - End.Y < 0)
            {
                top = Start.Y;
                bot = End.Y;
            }
            else
            {
                bot = Start.Y;
                top = End.Y;
            }

            int mid_x = (int)((right - left) / 2);
            int mid_y = (int)((bot - top) / 2);
            utils.Custom_Color boundary_color = new utils.Custom_Color(0, 0, 0);
            utils.Custom_Color fill_color = new utils.Custom_Color(mycolor.R, mycolor.G, mycolor.B);
            Point center = new Point(left + mid_x, top + mid_y);
            utils.Utils.BoundaryFill(gl, center.X, gl.RenderContextProvider.Height - center.Y, fill_color, boundary_color);
        }

        private void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {
            // if this shape has affine transformation, apply it when filling
            if (this.Is_trans == true)
            {
                int step1 = 0;
                if (Start.Y - End.Y > 0) step1 = -1;
                else step1 = 1;

                for (int i = Start.Y; i != End.Y; i = i + step1)
                {
                    float x1, y1, x2, y2;
                    x1 = (float)Start.X;
                    y1 = (float)i;
                    x2 = (float)End.X;
                    y2 = (float)i;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    Line line = new Line(new Point((int)x1, (int)y1), new Point((int)x2, (int)y2), mycolor);
                    line.drawShape(gl, mycolor);
                }


                int step2 = 0;
                if (Start.X - End.X > 0) step2 = -1;
                else step2 = 1;

                for (int i = Start.X; i != End.X; i += step2)
                {
                    float x1, y1, x2, y2;
                    x1 = (float)Start.X;
                    y1 = (float)i;
                    x2 = (float)End.X;
                    y2 = (float)i;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                }
            }

            // this shape has no affine transformation
            else
            {
                int step = 0;
                if (Start.Y - End.Y > 0) step = -1;
                else step = 1;

                for (int i = Start.Y; i != End.Y; i = i + step)
                    utils.Utils.ScanLine(gl, Start.X, End.X, i, mycolor);
            }
        }
    }
}
