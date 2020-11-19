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

        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public Color Color { get => mycolor; set => mycolor = value; }
        public float Width { get => mywidth; set => mywidth = value; }
        public Equilateral_Triangle(Point Start, Point End, Color Color, float line_width)
        {
            this.start = Start;
            this.end = End;
            mycolor = Color;
            mywidth = line_width;
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            {//Point botleft = new Point(start.X, end.Y);
             //this.setTopMid();
             //gl.Begin(OpenGL.GL_LINE_LOOP);
             //gl.Vertex(topmid.X, gl.RenderContextProvider.Height - topmid.Y);
             //gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
             //gl.Vertex(botleft.X, gl.RenderContextProvider.Height - botleft.Y);
             //gl.End();
             //gl.Flush();
            }
            gl.LineWidth(line_width);
            Point triangle_insider_Circle = new Point(end.X, gl.RenderContextProvider.Height - end.Y);
            double edge = this.calcDistance(this.start, this.end);
            double rad = 60 * pi / 180;
            double xC = Math.Cos(rad) * edge + triangle_insider_Circle.X;
            double yC = Math.Sin(rad) * edge + triangle_insider_Circle.Y;

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
                gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
                gl.Vertex(xC, yC);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }
        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {

        }
        public double calcDistance(Point start, Point end)
        {
            double Dianogal = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return Dianogal;
        }

        //private void setTopMid()
        //{
        //    this.edge = Math.Abs(start.X - end.X);
        //    if (start.X < end.X && start.Y < end.Y) 
        //    {
        //        this.topmid.X = (int)(this.start.X + this.edge/2); 
        //        this.topmid.Y = this.start.Y;
        //    }
        //    else if (start.X < end.X && start.Y > end.Y)
        //    {
        //        this.topmid.X = (int)(this.start.X + this.edge/2);
        //        this.topmid.Y = this.end.Y;
        //    }
        //    else if (start.X > end.X && start.Y > end.Y)
        //    {
        //        this.topmid.X = (int)(this.start.X - this.edge/2);
        //        this.topmid.Y = end.Y;
        //    }
        //    else if (start.X > end.X && start.Y < end.Y)
        //    {
        //        this.topmid.X = (int)(this.start.X - this.edge);
        //        this.topmid.Y = start.X;
        //    }
        //}
    }
}
