using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    class Equilateral_Hexagon : Shape
    {
        const float pi = 3.14159f;
        private Point start;
        private Point end;
        private double radius;
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

        public double Radius { get => radius; set => radius = value; }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        public Equilateral_Hexagon(Point Start, Point End, Color Color, float line_width, bool filled)
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
            gl.LineWidth(line_width);

            // define edge length of hexagon
            double edge = (this.start.Y - this.end.Y) / 2;

            // initialize list of vertices
            List<Point> list = new List<Point>();

            // calculate vertices rely on edge length and rotate angle theta
            for (int i = 0; i <= 360; i += 60)
            {
                float theta = (i * pi) / 180;
                int x = (int)(start.X + edge * Math.Cos(theta));
                int y = (int)(start.Y + edge * Math.Sin(theta));
                Point point = new Point(x, y);
                list.Add(point);
            }

            // draw hexagon
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Vertex(list[0].X, gl.RenderContextProvider.Height - list[0].Y);
                gl.Vertex(list[1].X, gl.RenderContextProvider.Height - list[1].Y);
                gl.Vertex(list[2].X, gl.RenderContextProvider.Height - list[2].Y);
                gl.Vertex(list[3].X, gl.RenderContextProvider.Height - list[3].Y);
                gl.Vertex(list[4].X, gl.RenderContextProvider.Height - list[4].Y);
                gl.Vertex(list[5].X, gl.RenderContextProvider.Height - list[5].Y);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            // define edge length of hexagon
            double edge = (this.start.Y - this.end.Y) / 2;

            // initialize list of vertices
            List<Point> list = new List<Point>();

            // calculate vertices rely on edge length and rotate angle theta
            for (int i = 0; i <= 360; i += 60)
            {
                float theta = (i * pi) / 180;
                int x = (int)(start.X + edge * Math.Cos(theta));
                int y = (int)(start.Y + edge * Math.Sin(theta));
                Point point = new Point(x, y);
                list.Add(point);
            }

            // initialize edge between each vertex

            Line l1 = new Line(list[0],list[1], Color, line_width, true);

            Line l2 = new Line(list[1], list[2], Color, line_width, true);

            Line l3 = new Line(list[2], list[3], Color, line_width, true);

            Line l4 = new Line(list[3], list[4], Color, line_width, true);

            Line l5 = new Line(list[4], list[5], Color, line_width, true);

            Line l6 = new Line(list[5], list[0], Color, line_width, true);


            // draw edge between each vertex

            l1.drawWithAlgorithm(gl, color, line_width);
            l2.drawWithAlgorithm(gl, color, line_width);
            l3.drawWithAlgorithm(gl, color, line_width);
            l4.drawWithAlgorithm(gl, color, line_width);
            l5.drawWithAlgorithm(gl, color, line_width);
            l6.drawWithAlgorithm(gl, color, line_width);
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
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
