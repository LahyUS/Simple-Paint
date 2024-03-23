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

        public bool isFilled
        {
            get => isfilled;
            set => isfilled = value; 
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

        public Point Start { get => start; set => start = value; }

        public Point End { get => end; set => end = value; }

        public Point Center
        {
            get => this.center;
            set => this.center = value;
        }

        public double Radius { get => radius; set => radius = value; }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        // constructor 
        public Circle(Point Start, Point End, Color Color, float line_width, bool filled)
        {
            this.is_other_polygon = false;
            this.start = Start;
            this.end = End;
            this.radius = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
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
            // if this shape has affine transformation, apply it when drawing
            if (this.Is_trans == true)
            {
                gl.LineWidth(line_width);
                // initialize circle information 
                const float pi = 3.14159f;
                double Radius = utils.Utils.calcDistance(start, end);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                // draw circle 

                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i <= 360; i++)
                {
                    double rad = (i * pi) / 180;
                    float x1, y1;
                    x1 = (float)(start.X + Radius * Math.Cos(rad));
                    y1 = (float)(start.Y + Radius * Math.Sin(rad));
                    AF.TransformPoint(ref x1, ref y1);

                    gl.Vertex((int)x1, gl.RenderContextProvider.Height - (int)(y1));

                    //utils.Utils.setPixel(setPoint.X, gl.RenderContextProvider.Height - setPoint.Y, gl, mycolor, (float)1.0f);
                }
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }

            // this shape has no affine transformation
            else
            {
                gl.LineWidth(line_width);
                // initialize circle information 
                const float pi = 3.14159f;
                double Radius = utils.Utils.calcDistance(start, end);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                // draw circle 

                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i <= 360; i++)
                {
                    double rad = (i * pi) / 180;
                    float x1, y1;
                    x1 = (float)(start.X + Radius * Math.Cos(rad));
                    y1 = (float)(start.Y + Radius * Math.Sin(rad));
                    gl.Vertex((int)x1, gl.RenderContextProvider.Height - (int)(y1));

                    //utils.Utils.setPixel(setPoint.X, gl.RenderContextProvider.Height - setPoint.Y, gl, mycolor, (float)1.0f);
                }
                gl.End();
                gl.Flush();
                gl.LineWidth((float)1.0);
            }
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float line_width)
        {
            // initialize information to draw circle
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            const float pi = 3.14159f;
            double Radius = utils.Utils.calcDistance(start, end);
            double xc = Start.X;
            double yc = Start.Y;
            double x = 0;
            double y = Radius;
            double p = 1 - Radius;
            double dx = 2 * x;
            double dy = 2 * y;

            // if this shape has affine transformation, apply it when drawing
            if (this.Is_trans == true) 
            {
                {
                    // set pixel at begin coordinate
                    float x1, y1, x2, y2;
                    x1 = (float)(xc + x);
                    y1 = (float)(yc + y);
                    x2 = (float)(xc - x);
                    y2 = (float)(yc - y);

                    // apply affine transformation
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);

                    utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);
                    utils.Utils.setPixel((int)x2, (int)(gl.RenderContextProvider.Height - y2), gl, color, line_width);
                }

                // drawing loop
                while (x < y) 
                {
                    x++;
                    if (p <= 0)
                    {
                        dx += 2;
                        p += dx + 1;
                    }

                    else
                    {
                        y--;
                        dx = dx + 2;
                        dy = dy - 2;
                        p += dx - dy + 1;

                    }             
                    // set symmetry pixel at 8 part of cirlce
                    float x1 = (float)(xc + x);
                    float y1 = (float)(yc + y);
                    this.AF.TransformPoint(ref x1, ref y1);
                    utils.Utils.setPixel((int)x1, (int)(gl.RenderContextProvider.Height - y1), gl, color, line_width);

                    float x2 = (float)(xc - x);
                    float y2 = (float)(yc + y);
                    this.AF.TransformPoint(ref x2, ref y2);
                    utils.Utils.setPixel((int)x2, (int)(gl.RenderContextProvider.Height - y2), gl, color, line_width);

                    float x3 = (float)(xc + x);
                    float y3 = (float)(yc - y);
                    this.AF.TransformPoint(ref x3, ref y3);
                    utils.Utils.setPixel((int)x3, (int)(gl.RenderContextProvider.Height - y3), gl, color, line_width);

                    float x4 = (float)(xc - x);
                    float y4 = (float)(yc - y);
                    this.AF.TransformPoint(ref x4, ref y4);
                    utils.Utils.setPixel((int)x4, (int)(gl.RenderContextProvider.Height - y4), gl, color, line_width);


                    float x5 = (float)(xc + y);
                    float y5 = (float)(yc + x);
                    this.AF.TransformPoint(ref x5, ref y5);
                    utils.Utils.setPixel((int)x5, (int)(gl.RenderContextProvider.Height - y5), gl, color, line_width);

                    float x6 = (float)(xc - y);
                    float y6 = (float)(yc + x);
                    this.AF.TransformPoint(ref x6, ref y6);
                    utils.Utils.setPixel((int)x6, (int)(gl.RenderContextProvider.Height - y6), gl, color, line_width);

                    float x7 = (float)(xc + y);
                    float y7 = (float)(yc - x);
                    this.AF.TransformPoint(ref x7, ref y7);
                    utils.Utils.setPixel((int)x7, (int)(gl.RenderContextProvider.Height - y7), gl, color, line_width);

                    float x8 = (float)(xc - y);
                    float y8 = (float)(yc - x);
                    this.AF.TransformPoint(ref x8, ref y8);
                    utils.Utils.setPixel((int)x8, (int)(gl.RenderContextProvider.Height - y8), gl, color, line_width);
                }
            }
            // this shape has no affine transformation
            else
            {
                // set pixel at begin coordinate
                utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);

                // drawing loop
                while (x < y)
                {
                    x++;
                    if (p <= 0)
                    {
                        dx += 2;
                        p += dx + 1;
                    }

                    else
                    {
                        y--;
                        dx = dx + 2;
                        dy = dy - 2;
                        p += dx - dy + 1;

                    }

                    // set symmetry pixel at 8 part of cirlce
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc + y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc + x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - x), (int)(gl.RenderContextProvider.Height - (yc - y)), gl, color, line_width);

                    utils.Utils.setPixel((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc + x)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc + x)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc + y), (int)(gl.RenderContextProvider.Height - (yc - x)), gl, color, line_width);
                    utils.Utils.setPixel((int)(xc - y), (int)(gl.RenderContextProvider.Height - (yc - x)), gl, color, line_width);
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

        private void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {  
            const float pi = 3.14159f;
            double radius = utils.Utils.calcDistance(start, end);
            utils.Custom_Color currentcolor = new utils.Custom_Color(mycolor.R, mycolor.G, mycolor.B);

            // initialize information to draw circle
            double Radius = utils.Utils.calcDistance(start, end);
            double xc = Start.X;
            double yc = Start.Y;
            double x = 0;
            double y = Radius;
            double p = 1 - Radius;
            double dx = 2 * x;
            double dy = 2 * y;

            // if this shape has affine transformation, apply it when filling
            if (this.Is_trans == true) 
            {
                // fill diameter
                {
                    float x1, y1, x2, y2;
                    x1 = (float)(xc + Radius);
                    y1 = (float)yc;
                    x2 = (float)(xc - Radius);
                    y2 = y1;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);

                    Point right = new Point((int)x1, (int)y1);
                    Point left = new Point((int)x2, (int)y1);
                    Line line = new Line(left, right, mycolor);
                    line.drawShape(gl, mycolor);
                }

                // drawing loop
                while (x < y)
                {
                    x++;
                    if (p <= 0)
                    {
                        dx += 2;
                        p += dx + 1;
                    }

                    else
                    {
                        y--;
                        dx = dx + 2;
                        dy = dy - 2;
                        p += dx - dy + 1;
                    }

                    // set symmetry pixel at 8 part of cirlce
                    // x : y , -x : y
                    {
                        float x1, y1, x2, y2;
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
                        float x1, y1, x2, y2;
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

                    // y : x , -y : x
                    {
                        float x1, y1, x2, y2;
                        x1 = (float)(xc + y);
                        y1 = (float)(yc + x);
                        x2 = (float)(xc - y);
                        y2 = (float)(yc + x);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right3 = new Point((int)x1, (int)y1);
                        Point left3 = new Point((int)x2, (int)y2);
                        Line line3 = new Line(left3, right3, mycolor);
                        line3.drawShape(gl, mycolor);
                    }

                    // y : -x , -y : -x
                    {
                        float x1, y1, x2, y2;
                        x1 = (float)(xc + y);
                        y1 = (float)(yc - x);
                        x2 = (float)(xc - y);
                        y2 = (float)(yc - x);
                        this.AF.TransformPoint(ref x1, ref y1);
                        this.AF.TransformPoint(ref x2, ref y2);
                        Point right4 = new Point((int)x1, (int)y1);
                        Point left4 = new Point((int)x2, (int)y2);
                        Line line4 = new Line(left4, right4, mycolor);
                        line4.drawShape(gl, mycolor);
                    }
                }
            }
            // this shape has no affine transformation
            else
            {
                // fill diameter
                Point right = new Point((int)(xc + Radius), (int)(yc));
                Point left = new Point((int)(xc - Radius), (int)(yc));
                Line line = new Line(left, right, mycolor);
                line.drawShape(gl, mycolor);

                // drawing loop
                while (x < y)
                {
                    x++;
                    if (p <= 0)
                    {
                        dx += 2;
                        p += dx + 1;
                    }

                    else
                    {
                        y--;
                        dx = dx + 2;
                        dy = dy - 2;
                        p += dx - dy + 1;
                    }

                    // set symmetry pixel at 8 part of cirlce
                    // x : y , -x : y
                    Point right1 = new Point((int)(xc + x), (int)((yc + y)));
                    Point left1 = new Point((int)(xc - x), (int)((yc + y)));
                    Line line1 = new Line(left1, right1, mycolor);
                    line1.drawShape(gl, mycolor);

                    // x : -y , -x : -y
                    Point right2 = new Point((int)(xc + x), (int)((yc - y)));
                    Point left2 = new Point((int)(xc - x), (int)((yc - y)));
                    Line line2 = new Line(left2, right2, mycolor);
                    line2.drawShape(gl, mycolor);

                    // y : x , -y : x
                    Point right3 = new Point((int)(xc + y), (int)((yc + x)));
                    Point left3 = new Point((int)(xc - y), (int)((yc + x)));
                    Line line3 = new Line(left3, right3, mycolor);
                    line3.drawShape(gl, mycolor);

                    // y : -x , -y : -x
                    Point right4 = new Point((int)(xc + y), (int)((yc - x)));
                    Point left4 = new Point((int)(xc - y), (int)((yc - x)));
                    Line line4 = new Line(left4, right4, mycolor);
                    line4.drawShape(gl, mycolor);
                }
            }

            gl.End();
            gl.Flush();
        }
    }
}
