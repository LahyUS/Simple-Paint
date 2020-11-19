using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    interface Shape
    {
        Point Start
        {
            get;
            set;
        }
        Point End
        {
            get;
            set;
        }
        Color Color
        {
            get;
            set;
        }
        float Width
        {
            get;
            set;
        }
        void drawShape(OpenGL gl, Color color, float line_width);
        void drawWithAlgorithm(OpenGL gl, Color color, float line_width);
        double calcDistance(Point start, Point end);
    }
}
