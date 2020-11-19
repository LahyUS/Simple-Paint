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
        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public Color Color { get => mycolor; set => mycolor = value; }
        public float Width { get => mywidth; set => mywidth = value; }
        public Rectangle(Point Start, Point End, Color Color, float line_width)
        {
            start = Start;
            end = End;
            mycolor = Color;
            mywidth = line_width;
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            gl.LineWidth(line_width);
            Point topright = new Point(end.X,start.Y);
            Point botleft = new Point(start.X,end.Y);
            //gl.Begin(OpenGL.GL_QUADS);
            //    gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            //    gl.Vertex(topright.X, gl.RenderContextProvider.Height - topright.Y);
            //    gl.Vertex(botleft.X, gl.RenderContextProvider.Height - botleft.Y);
            //    gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            //    gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            //    gl.Vertex(botleft.X, gl.RenderContextProvider.Height - botleft.Y);
            //    gl.Vertex(topright.X, gl.RenderContextProvider.Height - topright.Y);
            //    gl.Vertex(botleft.X, gl.RenderContextProvider.Height - botleft.Y);

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
        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {

        }
        public double calcDistance(Point start, Point end) // length of dianogal line
        {
            double Dianogal = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return Dianogal;
        }
    }
}
