using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpGL_Programming.objects
{
    class Line : Shape
    {
        private Point start;
        private Point end;
        private Color mycolor;
        private float mywidth;
        private bool isfilled;
        private List<Point> vertices;
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

        public bool isFilled
        {
            get => isfilled;
            set { isfilled = value; }
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

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        public Line(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.is_other_polygon = false;
            this.start = Start;
            this.end = End;
            this.mycolor = Color;
            this.mywidth = line_width;
            this.isfilled = filled;
            this.myAF = new utils.Affine();
        }

        public Line(Point Start, Point End, Color Color)
        {
            this.is_other_polygon = false;
            this.start = Start;
            this.end = End;
            this.mycolor = Color;
            this.myAF = new utils.Affine();
        }

        public void draw(OpenGL gl, Color color, float width, int draw_mode)
        {
            if (draw_mode == 0)
                drawShape(gl, color, width);
            else
                drawWithAlgorithm(gl, color, width);
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            if(this.Is_trans = true)
            {
                gl.LineWidth(line_width);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                float x1, x2, y1, y2;
                x1 = (float)Start.X;
                y1 = (float)Start.Y;
                x2 = (float)End.X;
                y2 = (float)End.Y;
                this.AF.TransformPoint(ref x1, ref y1);
                this.AF.TransformPoint(ref x2, ref y2);
                // draw line
                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
                gl.Vertex(x2, gl.RenderContextProvider.Height - y2);
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0); // reset
            }
            else
            {
                gl.LineWidth(line_width);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);

                // draw line
                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
                gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0); // reset
            }
        }

        public void drawShape(OpenGL gl, Color color)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);

            // draw line
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0); // reset
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            int dx, dy, i, e;
            int incx, incy, inc1, inc2;
            int x, y;

            dx = Math.Abs(Start.X - End.X);
            dy = Math.Abs(Start.Y - End.Y);

            incx = 1;
            if (End.X < Start.X) incx = -1;
            incy = 1;
            if (End.Y < Start.Y) incy = -1;
            x = Start.X; y = Start.Y;
            if (dx > dy)
            {
                utils.Utils.setPixel(x, gl.RenderContextProvider.Height - y, gl, color, line_width);
                e = 2 * dy - dx;
                inc1 = 2 * (dy - dx);
                inc2 = 2 * dy;
                for (i = 0; i < dx; i++)
                {
                    if (e >= 0)
                    {
                        y += incy;
                        e += inc1;
                    }
                    else
                        e += inc2;
                    x += incx;
                    utils.Utils.setPixel(x, gl.RenderContextProvider.Height - y, gl, color, line_width);
                }

            }
            else
            {
                utils.Utils.setPixel(x, gl.RenderContextProvider.Height - y, gl, color, line_width);
                e = 2 * dx - dy;
                inc1 = 2 * (dx - dy);
                inc2 = 2 * dx;
                for (i = 0; i < dy; i++)
                {
                    if (e >= 0)
                    {
                        x += incx;
                        e += inc1;
                    }
                    else
                        e += inc2;
                    y += incy;
                    utils.Utils.setPixel(x, gl.RenderContextProvider.Height - y, gl, color, line_width);
                }
            }
            gl.Flush();
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
        {
            this.drawShape(gl, mycolor, this.Width);
        }
    }
}
