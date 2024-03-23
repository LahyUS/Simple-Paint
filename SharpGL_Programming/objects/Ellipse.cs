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
        private bool isfilled;
        private List<Point> vertices;
        private bool is_other_polygon;
        private Point center;
        private bool is_trans;

        private utils.Affine myAF;

        public utils.Affine AF
        {
            get => this.myAF;
            set => this.myAF = value;
        }

        public bool Is_trans
        {
            get => this.is_trans;
            set => this.is_trans = value;
        }

        public bool is_Other_Polygon
        {
            get => this.is_other_polygon;
            set => this.is_other_polygon = value;
        }

        public List<Point> Vertices
        {
            get
            {
                return this.vertices;
            }

            set
            {
                this.vertices = value;
            }
        }

        public bool isFilled
        {
            get => isfilled;
            set { isfilled = value; }
        }

        public Point Start { get => start; set => start = value; }

        public Point End { get => end; set => end = value; }

        public Point Center
        {
            get => this.center;
            set => this.center = value;
        }

        public double Radius_X { get => radius_x; set => radius_x = value; }

        public double Radius_Y { get => radius_y; set => radius_y = value; }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        // constructor
        public Ellipse(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.is_other_polygon = false;
            this.start = Start; // center point
            this.end = End;     // bottom right point of rectangle border
            this.radius_x = Math.Abs(start.X - end.X);
            this.radius_y = Math.Abs(start.Y - end.Y);
            this.mycolor = Color;
            this.mywidth = line_width;
            this.isfilled = filled;
            this.myAF = new utils.Affine();
        }

        public void draw(OpenGL gl, Color color, float width, int draw_mode)
        {
            if (draw_mode == 0)
                this.drawShape(gl, color, width);
            else
                this.drawWithAlgorithm(gl, color, width);
        }

        public void drawShape(OpenGL gl, Color color, float line_width)
        {
            if(this.Is_trans =  true)
            {
                // define information of ellipse
                gl.LineWidth(line_width);
                this.radius_x = Math.Abs(start.X - end.X);
                this.radius_y = Math.Abs(start.Y - end.Y);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);

                // draw ellipse
                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i <= 360; i++)
                {
                    // rotate with Radius_X and Radius_Y to get pixel belong to ellipse
                    double rad = (i * pi) / 180;
                    float x1, y1;
                    x1 = (float)(Start.X + radius_x * Math.Cos(rad));
                    y1 = (float)((Start.Y + radius_y * Math.Sin(rad)));
                    this.AF.TransformPoint(ref x1, ref y1);
                    gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
                }
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }
            else
            {
                // define information of ellipse
                gl.LineWidth(line_width);
                this.radius_x = Math.Abs(start.X - end.X);
                this.radius_y = Math.Abs(start.Y - end.Y);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);

                // draw ellipse
                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i <= 360; i++)
                {
                    // rotate with Radius_X and Radius_Y to get pixel belong to ellipse
                    double rad = (i * pi) / 180;
                    gl.Vertex(Start.X + radius_x * Math.Cos(rad), gl.RenderContextProvider.Height - (Start.Y + radius_y * Math.Sin(rad)));
                }
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }
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

            // if this shape has affine transformation, apply it when drawing
            if (this.Is_trans == true)  
            {
                // set pixel at begin coordinate
                {
                    float x1, y1, x2, y2;
                    x1 = (float)(xc + x);
                    y1 = (float)(yc + y);
                    x2 = (float)(xc - x);
                    y2 = (float)(yc - y);
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);
                    utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    utils.Utils.setPixel((int)x2, (int)(gl.RenderContextProvider.Height - y2), gl, color, line_width);
                }

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
                    {
                        float x1, y1;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc - x);
                        y1 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc - x);
                        y1 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }
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
                    {
                        float x1, y1;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc - x);
                        y1 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }

                    {
                        float x1, y1;
                        x1 = (float)(xc - x);
                        y1 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    }
                }
            }

            // this shape has no affine transformation
            else
            {
                // set pixel at begin coordinate
                utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);

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
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
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
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                }
            }
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
        {
            if (fill_mode == 0)
                this.Fill_With_Scanline_Mode(gl, mycolor);
            else
                this.Fill_With_Spill_Mode(gl, mycolor);
        }

        public void Fill_With_Spill_Mode(OpenGL gl, Color mycolor)
        {

        }

        public void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {
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

            // // if this shape has affine transformation, apply it when filling
            if (this.Is_trans == true)
            {    // For region 1 
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
                    // x : y , -x : y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);

                        Point right1 = new Point((int)x1, (int)y1);
                        Point left1 = new Point((int)x2, (int)y2);
                        Line line1 = new Line(left1, right1, mycolor);
                        line1.drawShape(gl, mycolor);
                    }

                    // x : -y , -x : -y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right2 = new Point((int)x1, (int)y1);
                        Point left2 = new Point((int)x2, (int)y2);
                        Line line2 = new Line(left2, right2, mycolor);
                        line2.drawShape(gl, mycolor);
                    }
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
                    // x : y , -x : y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right1 = new Point((int)x1, (int)y1);
                        Point left1 = new Point((int)x2, (int)y2);
                        Line line1 = new Line(left1, right1, mycolor);
                        line1.drawShape(gl, mycolor);
                    }

                    // x : -y , -x : -y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right2 = new Point((int)x1, (int)y1);
                        Point left2 = new Point((int)x2, (int)y2);
                        Line line2 = new Line(left2, right2, mycolor);
                        line2.drawShape(gl, mycolor);
                    }
                }
            }

            // this shape has no affine transformation
            else
            {
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
                    // x : y , -x : y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc + y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);

                        Point right1 = new Point((int)x1, (int)y1);
                        Point left1 = new Point((int)x2, (int)y2);
                        Line line1 = new Line(left1, right1, mycolor);
                        line1.drawShape(gl, mycolor);
                    }

                    // x : -y , -x : -y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc - y);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right2 = new Point((int)x1, (int)y1);
                        Point left2 = new Point((int)x2, (int)y2);
                        Line line2 = new Line(left2, right2, mycolor);
                        line2.drawShape(gl, mycolor);
                    }
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
                    // x : y , -x : y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc + y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc + y);
                        Point right1 = new Point((int)x1, (int)y1);
                        Point left1 = new Point((int)x2, (int)y2);
                        Line line1 = new Line(left1, right1, mycolor);
                        line1.drawShape(gl, mycolor);
                    }

                    // x : -y , -x : -y
                    {
                        float x1, x2, y1, y2;
                        x1 = (float)(xc + x);
                        y1 = (float)(yc - y);
                        x2 = (float)(xc - x);
                        y2 = (float)(yc - y);
                        Point right2 = new Point((int)x1, (int)y1);
                        Point left2 = new Point((int)x2, (int)y2);
                        Line line2 = new Line(left2, right2, mycolor);
                        line2.drawShape(gl, mycolor);
                    }
                }
            }
        }
    }
}
