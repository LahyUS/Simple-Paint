using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    class Equilateral_Triangle : Shape
    {
        const float pi = 3.14159f;
        private Point start;
        private Point end;
        private Color mycolor;
        private float mywidth;
        private bool isfilled;

        public bool isFilled
        {
            get => isfilled;
            set { isfilled = value; }
        }

        public Point Start { get => start; set => start = value; }

        public Point End { get => end; set => end = value; }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        // constructor
        public Equilateral_Triangle(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.start = Start;
            this.end = End;
            this.mycolor = Color;
            this.mywidth = line_width;
            this.isfilled = filled;
        }

        public void draw(OpenGL gl, Color color, float width, int draw_mode, bool is_draw_polygon)
        {
            if (draw_mode == 0)
                this.drawShape(gl, color, width);
            else
                this.drawWithAlgorithm(gl, color, width);
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            // define information of triangle
            gl.LineWidth(line_width);
            Point triangle_insider_Circle = new Point(End.X, End.Y);
            double edge = utils.Utils.calcDistance(this.start, this.end);
            double rad = 60 * pi / 180;

            // define an outreach circle with center is the remain vertex of equilateral triangle, and this circle contains 2 those vertices
            double xC = Math.Cos(rad) * edge + triangle_insider_Circle.X;
            double yC = Math.Sin(rad) * edge + triangle_insider_Circle.Y;

            // draw triangle
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Vertex(Start.X, gl.RenderContextProvider.Height - Start.Y);
                gl.Vertex(End.X, gl.RenderContextProvider.Height - End.Y);
                gl.Vertex(xC, gl.RenderContextProvider.Height - yC);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            // define an outreach circle with center is the remain vertex of equilateral triangle, and this circle contains 2 those vertices
            Point triangle_insider_Circle = new Point(End.X, End.Y);
            double edge = utils.Utils.calcDistance(this.start, this.end);
            double rad = 60 * pi / 180;
            double xC = Math.Cos(rad) * edge + triangle_insider_Circle.X;
            double yC = Math.Sin(rad) * edge + triangle_insider_Circle.Y;
            Point C = new Point((int)xC, (int)yC);

            // draw start point to center circle point
            Line l1 = new Line(Start, C, color, line_width, true);
            l1.drawWithAlgorithm(gl, color, line_width);

            // draw center to end point
            Line l2 = new Line(C, End, color, line_width, true);
            l2.drawWithAlgorithm(gl, color, line_width);

            // draw end point to start point
            Line l3 = new Line(End, Start, color, line_width, true);
            l3.drawWithAlgorithm(gl, color, line_width);

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

        public void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {
            //const float pi = 3.14159f;
            //double Radius = utils.Utils.calcDistance(start, end);
            //utils.Custom_Color currentColor = new utils.Custom_Color(mycolor.R, mycolor.R, mycolor.B);

            //// draw circle 
            //for (int i = -90; i <= 90; i++)
            //{
            //    double rad = (i * pi) / 180;
            //    Point leftBorder = new Point(start.X + (int)(Radius * Math.Cos(rad)), start.Y + (int)(Radius * Math.Sin(rad)));
            //    Point rightBorder = new Point(-(start.X + (int)(Radius * Math.Cos(rad))), start.Y + (int)(Radius * Math.Sin(rad)));

            //    for (i = rightBorder.X; i < leftBorder.X; i++)
            //    {
            //        utils.Custom_Color.putPixel(gl, i, leftBorder.Y, currentColor);
            //    }
            //}
        }
    }
}
