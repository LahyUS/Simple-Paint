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
        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public double Radius { get => radius; set => radius = value; }
        public Color Color { get => mycolor; set => mycolor = value; }
        public float Width { get => mywidth; set => mywidth = value; }
        public Equilateral_Hexagon(Point Start, Point End, Color Color, float line_width)
        {
            this.start = Start;
            this.end = End;
            mycolor = Color;
            mywidth = line_width;
        }
        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            gl.LineWidth(line_width);
            double edge = (this.start.Y - this.end.Y) / 2;
            double a = (this.start.X - this.end.X) / 2;
            List<Point> list = new List<Point>();

            for (int i = 0; i <= 360; i += 60)
            {
                float theta = (i * pi) / 180;
                int x = (int)(start.X + edge * Math.Cos(theta));
                int y = (int)(start.Y + edge * Math.Sin(theta));
                Point point = new Point(x, y);
                list.Add(point);
            }

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
            
        }
        private void setPixel(int x, int y, OpenGL gl)
        {
            gl.Color(0.0, 0.0, 0.0); //Set pixel to black  
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y); //Set pixel coordinates 
            gl.End();
        }
        public double calcDistance(Point start, Point end)
        {
            double Dianogal = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return Dianogal;
        }
        
    }
}
