using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    class Ellipse : Shape
    {
        const float pi = 3.14159f;
        private Point start;
        private Point end;
        private double radius_x;
        private double radius_y;
        private Color mycolor;
        private float mywidth;
        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public double Radius_X { get => radius_x; set => radius_x = value; }
        public double Radius_Y { get => radius_y; set => radius_y = value; }
        public Color Color { get => mycolor; set => mycolor = value; }
        public float Width { get => mywidth; set => mywidth = value; }
        public Ellipse(Point Start, Point End, Color Color, float line_width)
        {
            this.start = Start; // center point
            this.end = End;     // bottom right point of rectangle border
            this.radius_x = Math.Abs(start.X - end.X);
            this.radius_y = Math.Abs(start.Y - end.Y);
            this.mycolor = Color;
            this.mywidth = line_width;
        }
        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            gl.LineWidth(line_width);
            this.radius_x = Math.Abs(start.X - end.X);
            this.radius_y = Math.Abs(start.Y - end.Y);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                double rad = (i * pi) / 180;
                gl.Vertex(Start.X + radius_x * Math.Cos(rad), gl.RenderContextProvider.Height - (Start.Y + radius_y * Math.Sin(rad)));
            }
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }
        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            // initialize information to draw ellipse
            this.radius_x = Math.Abs(start.X - end.X);
            this.radius_y = Math.Abs(start.Y - end.Y);
            double xc = Start.X;
            double yc = Start.Y;
            double x = 0;
            double y = Radius_Y;
            double Rx2 = Math.Pow(Radius_X, 2);
            double Ry2 = Math.Pow(Radius_Y, 2);
            // Initial decision parameter of region 1 
            double P1 = Ry2 - Rx2 * Radius_Y + (0.25f * Rx2);
            double dx = 2 * Ry2 * x;
            double dy = 2 * Rx2 * y;

            // For region 1 
            while (dx < dy)
            {
                x++;
                dx += 2 * Ry2;
                // Checking and updating value of decision parameter based on algorithm 
                if (P1 < 0)
                    P1 += dx + Ry2;

                else
                {
                    y--;
                    dy -= 2 * Rx2;
                    P1 += dx - dy + Ry2;
                }
                // set symmetry pixel at 4 part of ellipse
                setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
            }

            // Decision parameter of region 2 
            double P2 = (Ry2 * ((x + 0.5f) * (x + 0.5f))) + (Rx2 * ((y - 1) * (y - 1))) - (Rx2 * Ry2);

            // Plotting points of region 2 
            while (y >= 0)
            {

                y--;
                dy = dy - (2 * Rx2);
                // Checking and updating parameter value based on algorithm 
                if (P2 > 0)
                    P2 += Rx2 - dy;
                
                else
                {
                    x++;
                    dx += (2 * Ry2);
                    P2 += dx - dy + (Rx2);
                }
                // set symmetry pixel at 4 part of ellipse
                setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
            }                                                                       
        }
        private void setPixel(int x, int y, OpenGL gl, Color color, float width) // set pixel at coordinate (x,y) with custom appearance
        {
            gl.PointSize(width);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }
        public double calcDistance(Point start, Point end) // length of dianogal line
        {
            double distance = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return distance;
        }
    }
}
