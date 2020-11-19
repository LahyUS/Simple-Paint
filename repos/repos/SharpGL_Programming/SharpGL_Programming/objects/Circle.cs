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
        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public double Radius { get => radius; set => radius = value; }
        public Color Color { get => mycolor; set => mycolor = value; }
        public float Width { get => mywidth; set => mywidth = value; }
        public Circle(Point Start, Point End, Color Color, float line_width)
        {
            start = Start;
            end = End;
            radius = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            mycolor = Color;
            mywidth = line_width;
        }
        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            gl.LineWidth(line_width);
            const float pi = 3.14159f;
            double Radius = calcDistance(start, end);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i <= 360; i++)
                {
                    double rad = (i * pi) / 180;
                    gl.Vertex(start.X + Radius * Math.Cos(rad), gl.RenderContextProvider.Height - (start.Y + Radius * Math.Sin(rad)));
                }
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }
        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {

        }
        public double calcDistance(Point start, Point end)
        {
            double Radius = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            radius = Radius;
            return Radius;
        }
    }
}
