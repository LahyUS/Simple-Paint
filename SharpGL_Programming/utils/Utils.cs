using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.utils
{
    class Utils
    {
        public static double calcDistance(Point start, Point end) // length of dianogal line
        {
            double Dianogal = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return Dianogal;
        }

        public static void setPixel(int x, int y, OpenGL gl, Color color, float width) // set pixel at coordinate (x,y) with custom appearance
        {
            gl.PointSize(width);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }

        public static void BoundaryFill(OpenGL gl, int x, int y, Custom_Color fill_color, Custom_Color boundary_color)
        {
            // get color value at coordinate (x,y)
            Custom_Color currentColor = utils.Custom_Color.GetPixels(gl, x, y);

            if (!utils.Custom_Color.IsSameColor(currentColor,boundary_color) && !utils.Custom_Color.IsSameColor(currentColor,fill_color))
            {
                utils.Custom_Color.putPixel(x, y, gl, fill_color);
                BoundaryFill(gl, x - 1, y, fill_color, boundary_color);
                BoundaryFill(gl, x, y + 1, fill_color, boundary_color);
                BoundaryFill(gl, x + 1, y, fill_color, boundary_color);
                BoundaryFill(gl, x, y - 1, fill_color, boundary_color);
            }           
        }

        public static void ScanLine(OpenGL gl, int x1, int x2, int y, Color color)
        {
            gl.Begin(OpenGL.GL_LINE);
            Point leftborder = new Point(x1, y);
            Point rightborder = new Point(x2, y);
            objects.Line line = new objects.Line(leftborder, rightborder, color);
            line.drawShape(gl,color);
            gl.End();
            gl.Flush();
        }
        
    }
}
