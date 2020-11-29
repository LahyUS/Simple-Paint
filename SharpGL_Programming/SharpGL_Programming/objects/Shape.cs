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

        Point Center
        {
            get;
            set;
        }

        Color Color
        {
            get;
            set;
        }

        bool isFilled
        {
            get;
            set;
        }

        float Width
        {
            get;
            set;
        }

        List<Point> Vertices
        {
            get;
            set;
        }

        bool is_Other_Polygon
        {
            get;
            set;
        }

        void draw(OpenGL gl, Color color, float line_width, int draw_mode);

        void drawShape(OpenGL gl, Color color, float line_width);

        void drawWithAlgorithm(OpenGL gl, Color color, float line_width);

        void FillShape(OpenGL gl, Color mycolor, int fill_mode);
    }
}
