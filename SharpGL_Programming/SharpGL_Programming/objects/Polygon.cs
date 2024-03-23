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
        private List<EB> AEL;

        private bool isfilled;

        private bool is_other_polygon;

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

        public void drawShape(OpenGL gl, Color color, float width)
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

                vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                vertexN.X += CenterPoint.X;
                vertexN.Y += CenterPoint.Y;

                //save vertex of polygon to draw with line drawing theoretical algorithm
                points[j] = new Point(vertexN.X, vertexN.Y);
            }

            //loop and draw each edge with line drawing theoretical algorithm
            for (int i = 0, j = 1; i < points.Length; i++, j++)
            {
                if (j == points.Length)
                {
                    j = 0;
                }

                Line line = new Line(points[i], points[j], Color, Width, true);

                line.drawWithAlgorithm(gl,color,width);
            }
        }

        public void FillShape(OpenGL gl, Color mycolor, int fill_mode)
        {
            this.getET(gl);
            //if (fill_mode == 0)
            //    this.Fill_With_Scanline_Mode(gl, mycolor);
            //else
            //    this.Fill_With_Spill_Mode(gl, mycolor);
        }

        public void Fill_With_Spill_Mode(OpenGL gl, Color mycolor)
        {

        }

        public void Fill_With_Scanline_Mode(OpenGL gl, Color mycolor)
        {
            //const float pi = 3.14159f;
            //double Radius = utils.Utils.calcDistance(start, end);
            //utils.Custom_Color currentColor = new utils.Custom_Color(mycolor.R, mycolor.R, mycolor.B);

            //// draw circle 
            //for (int i = -90; i <= 90; i++)
            //{
            //    double rad = (i * pi) / 180;
            //    Point leftBorder = new Point(start.X + (int)(Radius * Math.Cos(rad)), start.Y + (int)(Radius * Math.Sin(rad)));
            //    Point rightBorder = new Point(-(start.X + (int)(Radius * Math.Cos(rad))), start.Y + (int)(Radius * Math.Sin(rad)));

            //    for (i = rightBorder.X; i < leftBorder.X; i++)
            //    {
            //        utils.Custom_Color.putPixel(gl, i, leftBorder.Y, currentColor);
            //    }
            //}
        }

        private void Adjust_Vertices(OpenGL gl)
        {
            List<Point> tempList = new List<Point>();
            for(int i = 0; i < this.Vertices.Count; i++)
            {
                Point temp = new Point();
                temp = this.Vertices[i];
                temp.Y = gl.RenderContextProvider.Height - Vertices[i].Y;
                tempList.Add(temp);
            }

            this.Vertices = tempList;
        }

        public void getET(OpenGL gl)
        {
            this.Adjust_Vertices(gl);
        // ***************** Process to create a list contain edges of polygon ******************

            // if polygon contain 2 vertices -> then return, because it just a line
            int len = this.Vertices.Count;
            if (len < 3) return;

            // initialize a list contains edges of polygon
            List<Line> edge_list = new List<Line>();
            for(int i = 0; i < len - 1; i++)    // from vertex 1 to vertex(len - 1)
            {
                Point head = new Point(this.Vertices[i].X, this.Vertices[i].Y);
                Point tail = new Point(this.Vertices[i + 1].X, this.Vertices[i + 1].Y);
                Line tempLine = new Line(head, tail, Color.Black, (float)(1.0), false);
                edge_list.Add(tempLine);
            }

            // extra edge : tail ---> head
            {
                Point ehead = new Point(this.Vertices[len - 1].X, this.Vertices[len - 1].Y);
                Point etail = new Point(this.Vertices[0].X, this.Vertices[0].Y);
                Line etempLine = new Line(ehead, etail, Color.Black, (float)(1.0), false);

                // add this extre edge to edge list
                edge_list.Add(etempLine);
            }

        // ***************** Process to initialize a list of EB ******************

            List<EB> edge_table = new List<EB>();
            for(int i = 0; i <= len - 1; i++)
            {
                int Y_Upper = Math.Max(edge_list[i].Start.Y, edge_list[i].End.Y);
                int Y_Lower = Math.Min(edge_list[i].Start.Y, edge_list[i].End.Y);

                float X_Int;
                if (Y_Lower == Start.Y)
                    X_Int = Start.X;
                else X_Int = End.X;

                float Reci_Slope = (edge_list[i].End.Y - edge_list[i].Start.Y) / (edge_list[i].End.X - edge_list[i].Start.X);

                EB eb = new EB(Y_Upper, Y_Lower, X_Int, Reci_Slope);
                edge_table.Add(eb);
            }

        // ***************** Process to adjust the Y_Upper specification of each Edge Bucket ******************

            // process with each EB : edge_list[j] and edge_list[j + 1]
            for (int j = 0; j <= len - 2; j++)
            {
                Point head = edge_list[j].Start;
                Point tail = edge_list[j].End;
                int Y_lower = Math.Min(head.Y, tail.Y);
                int delta1 = edge_list[j].End.Y - edge_list[j].Start.Y;
                int delta2 = edge_list[j + 1].End.Y - edge_list[j + 1].Start.Y;

                if (delta1 * delta2 > 0)    // this vertex(End_Point) is not a local min/max with Y value
                {
                    if(edge_list[j].Start.Y > edge_list[j + 1].End.Y)  // if edge[j] is lie above edge[j+1]
                        edge_table[j + 1].Y_Upper -= 1;     // Update y_upper for this Edge Bucket
                    else
                        edge_table[j].Y_Upper -= 1;     // Update y_upper for this Edge Bucket
                }
                else if (delta1 * delta2 == 0)
                {
                    edge_table.RemoveAt(j);
                }
            }

            // process with an extra EB : edge_list[len - 1] and edge_list[0]
            {
                Point head = edge_list[len - 1].Start;
                Point tail = edge_list[len - 1].End;
                int Y_lower = Math.Min(head.Y, tail.Y);
                int delta1 = edge_list[len - 1].End.Y - edge_list[len - 1].Start.Y;
                int delta2 = edge_list[0].End.Y - edge_list[0].Start.Y;

                if (delta1 * delta2 > 0)    // this vertex(End_Point) is not a local min/max with Y value
                {
                    if (edge_list[len - 1].Start.Y > edge_list[0].End.Y)  // if edge[j] is lie above edge[j+1]
                        edge_table[0].Y_Upper -= 1;     // Update y_upper for this Edge Bucket
                    else
                        edge_table[len - 1].Y_Upper -= 1;     // Update y_upper for this Edge Bucket
                }
                else if (delta1 * delta2 == 0)
                {
                    edge_table.RemoveAt(len - 1);
                }
            }


        }
    }
}
