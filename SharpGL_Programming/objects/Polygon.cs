using Paint.ScanLine;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpGL_Programming.objects
{
    class Polygon : Shape
    {
        private double Radius;
        private const double pi = 3.14159;
        protected int Edge;

        private Point start;
        private Point end;
        private Point center;
        private Color mycolor;
        private float mywidth;
        private List<Point> vertices;

        private Point CenterPoint;
        private Point BorderPoint;
        private bool isfilled;
        private bool is_other_polygon;
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
            set { isfilled = value; }
        }

        public Polygon(Point Start, Point End, Color color, int edge, float lineWidth, bool filled)
        {
            this.is_other_polygon = false;
            vertices = new List<Point>();
            this.CenterPoint = Start;
            this.BorderPoint = End;
            this.mycolor = color;
            this.mywidth = lineWidth;
            this.Edge = edge;
            this.Radius = utils.Utils.calcDistance(CenterPoint, BorderPoint);
            this.isfilled = filled;
            this.myAF = new utils.Affine();
        }

        public Polygon(Point Start, Point End, Color color, float lineWidth, bool filled, List<Point> Vertices)
        {
            this.is_other_polygon = true;
            vertices = new List<Point>();
            this.CenterPoint = Start;
            this.BorderPoint = End;
            this.mycolor = color;
            this.mywidth = lineWidth;
            this.Radius = utils.Utils.calcDistance(CenterPoint, BorderPoint);
            this.isfilled = filled;
            this.vertices = Vertices;
            this.myAF = new utils.Affine();
        }

        public List<Point> Vertices
        {
            get
            {
                return this.vertices;
            }
            
            set
            {
                this.vertices = value.ToList();
            }
        }

        public Point Start
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = utils.Utils.calcDistance(CenterPoint, BorderPoint);
            }
        }

        public Point End
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = utils.Utils.calcDistance(CenterPoint, BorderPoint);
            }
        }

        public Point Center
        {
            get => this.center;
            set => this.center = value;
        }

        public Color Color { get => mycolor; set => mycolor = value; }

        public float Width { get => mywidth; set => mywidth = value; }

        public void draw(OpenGL gl, Color color, float width, int draw_mode)
        {
            // this.connect_Vertices(gl, color, width);
            if (this.is_Other_Polygon ==  true)
                this.connect_Vertices(gl, color, width);
            else
            {
                if (draw_mode == 0)
                    this.drawShape(gl, color, width);
                else
                    this.drawWithAlgorithm(gl, color, width);
            }   
        }

        public void connect_Vertices(OpenGL gl, Color color, float width)
        { 
            if(this.Is_trans == true) // if this shape has affine transformation, apply it when drawing
            {
                //Set color, line width
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.LineWidth(width);


                gl.Begin(OpenGL.GL_LINE_LOOP);

                foreach (Point vertex in this.Vertices)
                {
                    float x1, y1;
                    x1 = (float)vertex.X;
                    y1 = (float)vertex.Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
                }

                gl.End();
                gl.Flush();
            }
            else // this shape has no affine transformation
            {
                //Set color, line width
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.LineWidth(width);

                gl.Begin(OpenGL.GL_LINE_LOOP);

                foreach (Point vertex in this.Vertices)
                {
                    gl.Vertex(vertex.X, gl.RenderContextProvider.Height - vertex.Y);
                }

                gl.End();
                gl.Flush();
            }
        }

        public void drawShape(OpenGL gl, Color color, float width)
        {
            if(this.Is_trans == true)   // if this shape has affine transformation, apply it when drawing
            {
                //Set color, line width
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.LineWidth(width);

                //use the idea of ​​drawing a circle, with the arcs divided by the number of edges of the polygon
                gl.Begin(OpenGL.GL_LINE_LOOP);

                //each arc have circular measure is 360/num of edges
                int angle = 360 / this.Edge;

                for (int i = 0; i <= 360; i += angle)
                {
                    double degInRad = i * pi / 180;

                    //translate center point to (0,0)
                    Point vertexN = new Point();
                    vertexN.X = BorderPoint.X - CenterPoint.X;
                    vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                    //save the vertex last
                    double vertexX_last = vertexN.X;
                    double vertexY_last = vertexN.Y;

                    //rotate vertex with increase agle
                    vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                    vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                    //translate center point to center point started
                    vertexN.X += CenterPoint.X;
                    vertexN.Y += CenterPoint.Y;
                    float x1, y1;
                    x1 = (float)vertexN.X;
                    y1 = (float)vertexN.Y;
                    this.AF.TransformPoint(ref x1, ref y1);

                    gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
                }

                gl.End();
                gl.Flush();
            }
            else // this shape has no affine transformation
            {
                //Set color, line width
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
                gl.LineWidth(width);

                //use the idea of ​​drawing a circle, with the arcs divided by the number of edges of the polygon
                gl.Begin(OpenGL.GL_LINE_LOOP);

                //each arc have circular measure is 360/num of edges
                int angle = 360 / this.Edge;

                for (int i = 0; i <= 360; i += angle)
                {
                    double degInRad = i * pi / 180;

                    //translate center point to (0,0)
                    Point vertexN = new Point();
                    vertexN.X = BorderPoint.X - CenterPoint.X;
                    vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                    //save the vertex last
                    double vertexX_last = vertexN.X;
                    double vertexY_last = vertexN.Y;

                    //rotate vertex with increase agle
                    vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                    vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                    //translate center point to center point started
                    vertexN.X += CenterPoint.X;
                    vertexN.Y += CenterPoint.Y;
                    gl.Vertex(vertexN.X, gl.RenderContextProvider.Height - vertexN.Y);
                }

                gl.End();
                gl.Flush();
            }
        }

        public void drawWithAlgorithm(OpenGL gl, Color color, float width)
        {
            //Set color, line width
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.LineWidth(width);

            Point[] points = new Point[Edge];
            int angle = 360 / Edge;

            for (int i = 0, j = 0; i < 360; i += angle, j++)
            {
                double degInRad = i * pi / 180;

                Point vertexN = new Point();
                vertexN.X = BorderPoint.X - CenterPoint.X;
                vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                double vertexX_last = vertexN.X;
                double vertexY_last = vertexN.Y;

                // rotate surround vertex around center point
                vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                vertexN.X += CenterPoint.X;
                vertexN.Y += CenterPoint.Y;

                //save vertex of polygon to draw with line drawing theoretical algorithm
                points[j] = new Point(vertexN.X, vertexN.Y);
            }

            if(this.Is_trans == true) // if this shape has affine transformation, apply it when drawing
            {
                //loop and draw each edge with line drawing theoretical algorithm
                for (int i = 0, j = 1; i < points.Length; i++, j++)
                {
                    if (j == points.Length)
                    {
                        j = 0;
                    }

                    float x1, y1,x2,y2;
                    x1 = (float)points[i].X;
                    y1 = (float)points[i].Y;
                    x2 = (float)points[j].X;
                    y2 = (float)points[j].Y;
                    this.AF.TransformPoint(ref x1, ref y1);
                    this.AF.TransformPoint(ref x2, ref y2);

                    Point a = new Point((int)x1, (int)y1);
                    Point b = new Point((int)x2, (int)y2);
                    Line line = new Line(a, b, Color, Width, true);

                    line.drawWithAlgorithm(gl, color, width);
                }
            }
            else // this shape has no affine transformation
            {
                //loop and draw each edge with line drawing theoretical algorithm
                for (int i = 0, j = 1; i < points.Length; i++, j++)
                {
                    if (j == points.Length)
                    {
                        j = 0;
                    }

                    Line line = new Line(points[i], points[j], Color, Width, true);

                    line.drawWithAlgorithm(gl, color, width);
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
            if (this.is_other_polygon == true)  // this is a normal polygon
            {
                if(this.Is_trans == true) // if this shape has affine transformation, apply it when filling
                {
                    ScanLine scan_line = new ScanLine();
                    scan_line.g = gl;
                    List<Point> temp = new List<Point>();
                    foreach (Point p in this.Vertices)
                    {
                        Point temp_p = p;
                        float x1, y1;
                        y1 = (float)(gl.RenderContextProvider.Height - p.Y);
                        x1 = (float)p.X;
                        this.AF.TransformPoint(ref x1, ref y1);
                        temp_p.X = (int)x1;
                        temp_p.Y = (int)y1;
                        temp.Add(temp_p);
                    }
                    scan_line.ScanLinePolygonFill(temp, gl, 1);
                }
                else // this shape has no affine transformation
                {
                    ScanLine scan_line = new ScanLine();
                    scan_line.g = gl;
                    List<Point> temp = new List<Point>();
                    foreach (Point p in this.Vertices)
                    {
                        Point temp_p = p;
                        temp_p.Y = gl.RenderContextProvider.Height - p.Y;
                        temp_p.X = p.X;
                        temp.Add(temp_p);
                    }
                    scan_line.ScanLinePolygonFill(temp, gl, 1);
                }
            }

            else  // this is an equilateral polygon : triangle, pentagon, hexagon
            {
                List<Point> Vertices = new List<Point>();

                Point[] points = new Point[Edge];
                int angle = 360 / Edge;

                for (int i = 0, j = 0; i < 360; i += angle, j++)
                {
                    double degInRad = i * pi / 180;

                    Point vertexN = new Point();
                    vertexN.X = BorderPoint.X - CenterPoint.X;
                    vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                    double vertexX_last = vertexN.X;
                    double vertexY_last = vertexN.Y;

                    // rotate surround vertex around center point
                    vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                    vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                    vertexN.X += CenterPoint.X;
                    vertexN.Y += CenterPoint.Y;

                    //save vertex of polygon to draw with line drawing theoretical algorithm
                    points[j] = new Point(vertexN.X, vertexN.Y);
                    Vertices.Add(points[j]);
                }

                if (this.Is_trans == true)   // if this shape has affine transformation, apply it when filling
                {
                    ScanLine scan_line = new ScanLine();
                    scan_line.g = gl;
                    List<Point> temp = new List<Point>();
                    foreach (Point p in Vertices)
                    {
                        Point temp_p = p;
                        float x1, y1;
                        y1 = (float)(gl.RenderContextProvider.Height - p.Y);
                        x1 = (float)p.X;
                        this.AF.TransformPoint(ref x1, ref y1);
                        temp_p.X = (int)x1;
                        temp_p.Y = (int)y1;
                        temp.Add(temp_p);
                    }
                    scan_line.ScanLinePolygonFill(temp, gl, 1);
                }
                else   // this shape has no affine transformation
                {
                    ScanLine scan_line = new ScanLine();
                    scan_line.g = gl;
                    List<Point> temp = new List<Point>();
                    foreach (Point p in Vertices)
                    {
                        Point temp_p = p;
                        temp_p.Y = gl.RenderContextProvider.Height - p.Y;
                        temp_p.X = p.X;
                        temp.Add(temp_p);
                    }
                    scan_line.ScanLinePolygonFill(temp, gl, 1);
                }
            }              
        }
    }
}
