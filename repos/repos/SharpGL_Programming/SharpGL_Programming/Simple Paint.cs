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
    public partial class Form1 : Form
    {
        const float pi = 3.14159f;
        Color mycolor;
        Point p_start, p_end;
        List<Shape> drawnlist;
        short shape_type; // shape_type of shape
        bool isDraw;
        Shape[] shape_arr;
        float line_width;
        
        // initialize new instance of the class
        public Form1()
        {
            InitializeComponent();
            mycolor = Color.White;
            shape_type = 0;
            isDraw = false;
            line_width = (float)1.0;
            drawnlist = new List<Shape>();
            shape_arr = new Shape[7];
            Point temp = new Point(0, 0);
            shape_arr[0] = new Line(temp,temp,mycolor,line_width);
            shape_arr[1] = new Circle(temp,temp, mycolor, line_width);
            shape_arr[2] = new Ellipse(temp, temp, mycolor, line_width);
            shape_arr[3] = new Rectangle(temp, temp, mycolor, line_width);
            shape_arr[4] = new Equilateral_Triangle(temp,temp, mycolor, line_width);
            shape_arr[5] = new Equilateral_Pentagon(temp, temp, mycolor, line_width);
            shape_arr[6] = new Equilateral_Hexagon(temp, temp, mycolor, line_width);
        }
        // sender = the source of the event
        // EventArgs = instance containing the event data
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
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

            if (isDraw) shape_arr[shape_type].drawShape(gl, mycolor, line_width); 

            if (drawnlist.Count > 0)
            {
                int i = 0;
                int length = drawnlist.Count;
                foreach (Shape shape in drawnlist)
                { 
                    if (i == length - 1)
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        shape.drawShape(gl, shape.Color, shape.Width);
                        watch.Stop();
                        double elapsedMs = watch.Elapsed.Milliseconds;
                        drawing_time.Text = "Time : " + elapsedMs.ToString() + " milisecond";
                        break;
                    }
                    shape.drawShape(gl, shape.Color, shape.Width);
                    i++;
                }
            }
        }
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
        private void color_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
                mycolor = colorDlg.Color;
        }
        private void Capacity_Click(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //MessageBox.Show(btn.Name + "Click");
            //int x = 736, y = 49;
            //for (int i = 0; i < 3; i++)
            //{
            //    Button b = new Button();
            //    b.Location = new Point(x, y);
            //    b.Name = "button_" + (i + 1).ToString();
            //    b.Text = "level " + i.ToString();
            //    b.Size = new Size(75, 23);
            //    b.Font = new Font("Minion Pro", 8);
            //    b.Padding = new Padding(0);

            //    b.Click += new EventHandler(this.Dynamic_Button_Click);
            //    this.Controls.Add(b);
            //    y += 28;
            //}
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
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            p_start = e.Location;
            p_end = p_start;
            shape_arr[shape_type].Start = p_start;
            shape_arr[shape_type].End = p_end;
            isDraw = true;
        }
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            p_end = e.Location;
            shape_arr[shape_type].End = p_end;
        }
        //private void drawingtime_Click(object sender, EventArgs e)
        //{
        //    // Creating and setting the label 
        //    Label mylab = new Label();
        //    mylab.Text = "GeeksforGeeks";
        //    mylab.Location = new Point(820, 169);
        //    mylab.AutoSize = true;
        //    mylab.Font = new Font("Calibri", 18);
        //    mylab.BorderStyle = BorderStyle.Fixed3D;
        //    mylab.ForeColor = Color.Green;
        //    mylab.Padding = new Padding(6);

        //    // Adding this control to the form 
        //    this.Controls.Add(mylab);

        //    //// Creating and setting the label 
        //    //Label mylab1 = new Label();
        //    //mylab1.Text = "Welcome To GeeksforGeeks";
        //    //mylab1.Location = new Point(155, 170);
        //    //mylab1.AutoSize = true;
        //    //mylab1.BorderStyle = BorderStyle.Fixed3D;
        //    //mylab1.Font = new Font("Calibri", 18);
        //    //mylab1.Padding = new Padding(6);

        //    // Adding this control to the form 
        //    //this.Controls.Add(mylab1);
        //}
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            p_end = e.Location;
            shape_arr[shape_type].End = p_end;
            isDraw = false;

            if (shape_type == 0)
            {
                Line line = new Line(p_start,p_end,mycolor,line_width);
                drawnlist.Add(line);
            }
            else if (shape_type == 1)
            {
                Circle circle = new Circle(p_start,p_end, mycolor, line_width);
                drawnlist.Add(circle);
            }
            else if (shape_type == 2)
            {
                Ellipse ellipse = new Ellipse(p_start,p_end, mycolor, line_width);
                drawnlist.Add(ellipse);
            }
            else if (shape_type == 3)
            {
                Rectangle rectangle = new Rectangle(p_start,p_end, mycolor, line_width);
                drawnlist.Add(rectangle);
            }
            else if (shape_type == 4)
            {
                Equilateral_Triangle equi_triangle = new Equilateral_Triangle(p_start,p_end, mycolor, line_width);
                drawnlist.Add(equi_triangle);
            }
            else if (shape_type == 5)
            {
                Equilateral_Pentagon equi_pentagon = new Equilateral_Pentagon(p_start,p_end, mycolor, line_width);
                drawnlist.Add(equi_pentagon);
            }
            else if (shape_type == 6)
            {
                Equilateral_Hexagon equi_hexagon = new Equilateral_Hexagon(p_start,p_end, mycolor, line_width);
                drawnlist.Add(equi_hexagon);
            }
        }
        private void infor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*********** Unregister ***********\nSimple paint application\nVersion 1.0\nFounder HyLa_US");
        }
        private void select_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = select_size.SelectedItem.ToString();
            line_width = float.Parse(selected);
        }
    } 
}

