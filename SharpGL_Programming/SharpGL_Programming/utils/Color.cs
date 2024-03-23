using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.utils
{
    class Custom_Color
    {
        private byte R;
        private byte G;
        private byte B;

        public byte Red
        {
            get { return R; }
            set { R = value; }
        }

        public byte Green
        {
            get { return G; }
            set { G = value; }
        }

        public byte Blue
        {
            get { return B; }
            set { B = value; }
        }

        public Custom_Color(byte Red, byte Green, byte Blue)
        {
            this.R = Red;
            this.G = Green;
            this.B = Blue;
        }

        public Custom_Color()
        {
            this.R = 0;
            this.G = 0;
            this.B = 0;
        }

        public static Custom_Color GetPixels(OpenGL gl, int x, int y)
        {
            byte[] ptr = new byte[3];
            //int actual_y = gl.RenderContextProvider.Height - y;
            gl.ReadPixels(x, y, 1, 1, OpenGL.GL_RGB, OpenGL.GL_BYTE, ptr);

            byte Red = ptr[0];
            byte Green = ptr[1];
            byte Blue = ptr[2];
            // assign this value to currentColor variable
            Custom_Color currentColor = new Custom_Color(Red, Green, Blue);
            return currentColor;
        }

        public static void putPixel(int x, int y, OpenGL gl, Custom_Color color)
        {
            byte[] ptr = new byte[3];
            ptr[0] = color.R;
            ptr[1] = color.G;
            ptr[2] = color.B;
            gl.RasterPos(x, y);
            gl.DrawPixels(1, 1, OpenGL.GL_RGB, ptr);
            gl.Flush();
        }

        public static bool IsSameColor(Custom_Color currentColor, Custom_Color other)
        {
            bool Flag = false;
            if (currentColor.R != other.R)
                return Flag;
            if (currentColor.G != other.G)
                return Flag;
            if (currentColor.B != other.B)
                return Flag;
            Flag = true;
            return Flag;
        }
    }
}
