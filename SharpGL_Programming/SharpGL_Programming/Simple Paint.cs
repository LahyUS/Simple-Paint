using SharpGL_Programming.objects;
using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = SharpGL_Programming.objects.Rectangle; // fix ambigious reference between class and system.draw.rectangle

namespace SharpGL_Programming
{
    public partial class Paint : Form
    {
        const float pi = 3.14159f;
        Color mycolor;
        Point p_start, p_end;
        List<Shape> drawnlist;
        short shape_type; // shape_type of shape
        bool isDraw;
        Shape[] shape_arr;
        float line_width;
        int draw_style;
        bool isStopTimer;
        bool isFill;
        int fill_mode;
        List<Point> polygon_vertices;
        List<Point> list_vertices;
        bool is_draw_polygon;

        // initialize new instance of the class
        public Paint()
        {
            // initialize all information of fomrm
            InitializeComponent();
            mycolor = Color.Black;
            shape_type = 0;
            draw_style = 0;
            isDraw = false;
            isFill = false;
            isStopTimer = false;
            line_width = (float)1.0;
            fill_mode = 0;
            polygon_vertices = new List<Point>();
            list_vertices = new List<Point>();
            is_draw_polygon = false;

            drawnlist = new List<Shape>()   ;
            shape_arr = new Shape[8];
            Point temp = new Point(0, 0);
            shape_arr[0] = new Line(temp,temp,mycolor,line_width, false);
            shape_arr[1] = new Circle(temp,temp, mycolor, line_width, false);
            shape_arr[2] = new Ellipse(temp, temp, mycolor, line_width, false);
            shape_arr[3] = new Rectangle(temp, temp, mycolor, line_width, false);
            shape_arr[4] = new Polygon(temp,temp, mycolor, 3, line_width, false);
            shape_arr[5] = new Polygon(temp, temp, mycolor, 5, line_width, false);
            shape_arr[6] = new Polygon(temp, temp, mycolor, 6, line_width, false);
            shape_arr[7] = new Polygon(temp, temp, mycolor, line_width, false, list_vertices);
        }
        // sender = the source of the event
        // EventArgs = instance containing the event data

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(188, 210, 225, 255);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // check if we are still using mouse to draw and not up mouse
            if (isDraw)
            {
                shape_arr[shape_type].draw(gl, mycolor, line_width, draw_style);
            }

            // if there are some drawn shape in list, we need to draw these all the time
            if (drawnlist.Count > 0)
            {
                // get each element in list to draw
                foreach (Shape shape in drawnlist)
                {
                    if (isStopTimer)
                    {
                        if(shape.isFilled == true)
                            shape.FillShape(gl, mycolor, fill_mode);

                        else
                            shape.draw(gl, mycolor, line_width, draw_style);
                    }

                    else
                    {
                        // start timer
                        Stopwatch timer = new Stopwatch();
                        timer.Start();

                        // if this is fill case
                        if (shape.isFilled == true)
                            shape.FillShape(gl, mycolor, fill_mode);

                        // if this is draw case, we draw with draw_style (OpenGL/Algorithm) and if shape_type = 7, we draw polygon
                        else
                            shape.draw(gl, mycolor, line_width, draw_style);

                        timer.Stop();   // stop timer

                        // show drawing time for each object
                        if (shape_type == 0)
                        {
                            line_time.Text = "Line:       " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 1)
                        {
                            circle_time.Text = "Circle:        " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 2)
                        {
                            ellipse_time.Text = "Ellipse:      " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 3)
                        {
                            rectangle_time.Text = "Rectangle: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 4)
                        {
                            triangle_time.Text = "Triangle: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 5)
                        {
                            pentagon_time.Text = "Pentagon: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 6)
                        {
                            hexagon_time.Text = "Hexagon: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        else if (shape_type == 7)
                        {
                            polygon_time.Text = "Polygon: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                    }
                }
            }
        }

        // *****************************************************************************************
        //                  get type of shape 
        private void line_Click(object sender, EventArgs e)
        {
            shape_type = 0;
        }

        private void circle_Click(object sender, EventArgs e)
        {
            shape_type = 1;
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            shape_type = 2;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            shape_type = 3;
        }

        private void equilateral_triangle_Click(object sender, EventArgs e)
        {
            shape_type = 4;
        }

        private void equilateral_pentagon_Click(object sender, EventArgs e)
        {
            shape_type = 5;
        }

        private void equilateral_hexagon_Click(object sender, EventArgs e)
        {
            shape_type = 6;
        }

        private void polygon_Click(object sender, EventArgs e)
        {
            shape_type = 7;
            is_draw_polygon = true;
        }

        // *****************************************************************************************

        // *****************************************************************************************
        //              get some feature event
        private void color_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
                mycolor = colorDlg.Color;
        }

        private void Capacity_Click(object sender, EventArgs e)
        {
            
        }

        private void infor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*********** Unregister ***********\nSimple paint application\nVersion 1.0\nFounder HyLa_US");
        }

        private void Dynamic_Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Location.Y == 49)
            {
               line_width = (float)1.0;
            }
            else if (btn.Location.Y == 77)
            {
               line_width = (float)2.0;
            }
            else
            {
                line_width = (float)4.0;
            }
        }

        private void Paint_Load(object sender, EventArgs e)
        {

        }

        private void Draw_style_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = Draw_style.SelectedItem.ToString();
            if (selected == "OpenGL")
            {
                draw_style = 0;
            }
            else
            {
                draw_style = 1;
            }
        }

        private void drawing_time_Click(object sender, EventArgs e)
        {

        }

        private void reset_timer_Click(object sender, EventArgs e)
        {
            line_time.Text = "Time:";
            circle_time.Text = "Time:";
            ellipse_time.Text = "Time:";
            triangle_time.Text = "Time:";
            rectangle_time.Text = "Time:";
            pentagon_time.Text = "Time:";
            hexagon_time.Text = "Time:";
            polygon_time.Text = "Time:";
        }

        private void stop_timer_Click(object sender, EventArgs e)
        {
            if (isStopTimer)
            {
                isStopTimer = false;
                stop_timer.Text = "Stop";
            }
            else
            {
                isStopTimer = true;
                stop_timer.Text = "Start";
            }
        }

        private void clean_Click(object sender, EventArgs e)
        {
            drawnlist.Clear();
            reset_timer_Click(reset_timer, e);
        }

        private void select_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = select_size.SelectedItem.ToString();
            line_width = float.Parse(selected);
        }

        private void fillmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = fillmode.SelectedItem.ToString();
            if (selected == "Spill")
            {
                fill_mode = 1;
            }
            else
            {
                fill_mode = 0;
            }
        }

        private void fill_Click(object sender, EventArgs e)
        {
            if (drawnlist.Count > 0)
                drawnlist[drawnlist.Count - 1].isFilled = true;
            //isFill = true;
        } 

        // *****************************************************************************************

        //              get event of mouse - drawing action
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            //if(shape_type != 7)
            {
                p_start = e.Location;
                p_end = p_start;
                shape_arr[shape_type].Start = p_start;
                shape_arr[shape_type].End = p_end;

                isDraw = true;
            }
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            p_end = e.Location;
            shape_arr[shape_type].End = p_end;
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            isDraw = true;
            if (shape_type == 7)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        
                        polygon_vertices.Add(e.Location);
                        shape_arr[shape_type].Vertices = polygon_vertices;
                        break;

                    case MouseButtons.Right:
                        is_draw_polygon = false;
                        isDraw = false;
                        p_end = e.Location;
                        shape_arr[shape_type].End = p_end;

                        list_vertices = polygon_vertices.ToList();
                        Polygon polygon = new Polygon(p_start, p_end, mycolor, line_width, isFill, list_vertices);
                        drawnlist.Add(polygon);

                        // update vertices list for next generation
                        polygon_vertices.Clear();
                        break;
                }
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            p_end = e.Location;
            shape_arr[shape_type].End = p_end;

            if(is_draw_polygon == false)
                isDraw = false;

            if (is_draw_polygon == true)
                isDraw = true;

            if (shape_type == 0)
            {
                Line line = new Line(p_start,p_end,mycolor,line_width, isFill);
                drawnlist.Add(line);
            }
            else if (shape_type == 1)
            {
                Circle circle = new Circle(p_start,p_end, mycolor, line_width, isFill);
                drawnlist.Add(circle);
            }
            else if (shape_type == 2)
            {
                Ellipse ellipse = new Ellipse(p_start,p_end, mycolor, line_width, isFill);
                drawnlist.Add(ellipse);
            }
            else if (shape_type == 3)
            {
                Rectangle rectangle = new Rectangle(p_start,p_end, mycolor, line_width, isFill);
                drawnlist.Add(rectangle);
            }
            else if (shape_type == 4)
            {
                //Equilateral_Triangle equi_triangle = new Equilateral_Triangle(p_start,p_end, mycolor, line_width, isFill);
                Polygon equi_triangle = new Polygon(p_start, p_end, mycolor, 3, line_width, isFill);
                drawnlist.Add(equi_triangle);
            }
            else if (shape_type == 5)
            {
               Polygon equi_pentagon = new Polygon(p_start,p_end, mycolor, 5, line_width, isFill);
                drawnlist.Add(equi_pentagon);
            }
            else if (shape_type == 6)
            {
                Polygon equi_hexagon = new Polygon(p_start,p_end, mycolor, 6, line_width, isFill);
                drawnlist.Add(equi_hexagon);
            }

            isFill = false;
        }     
    } 
}

