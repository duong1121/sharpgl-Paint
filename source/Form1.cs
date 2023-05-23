using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using static btaa.Draw;

namespace btaa
{


    public partial class Form1 : Form
    {
        Color userColor;    //Gia tri luu mau
        //Color ColorFill;
        short Shape;        //Gia tri de ve hinh
        Point pStart = new Point();
        Point pEnd = new Point();
        Point pDot = new Point();
        List<Point> DotDraw = new List<Point>();
        List<Draw> listDraw;
        Draw ShDraw;
        bool  select;
        Polygon plg = new Polygon();
        List<Polygon> list_plg = new List<Polygon>();
        bool mouseLeft = false;
        int _currenControlPoint;
        private OpenGL gl;
        Affine transform;
        bool checkSeclected;
        bool checkPolygon;
        public Form1()
        {
            InitializeComponent();
            userColor = Color.Black;              //Gan gia tri mau ban dau
            Shape = 0;                          //Gan gia tri ban dau de ve duong tron
            listDraw = new List<Draw>();
            ShDraw = new Draw();
            Polygon plg = new Polygon();
            transform = new Affine();
            checkSeclected = false;
            _currenControlPoint = -1;
            checkPolygon = false;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(1, 1, 1, 1);

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl.LoadIdentity();

        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            //  Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl.LoadIdentity();
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);

        }
        /*public void Draw(OpenGL gl)
        {
            gl.Color(userColor.R / 255.0, userColor.G / 255.0, userColor.B / 255.0);
            //gl.LineWidth(size);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < points.Count; i++)
            {
                gl.Vertex(points[i].X, gl.RenderContextProvider.Height - points[i].Y);
            }
            gl.End();
        }*/
        private void openGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.Color(userColor.R / 255.0, userColor.G / 255.0, userColor.B / 255.0);
            for(int i = 0; i < listDraw.Count; i++)
            {
                
                listDraw[i].DrawShape(gl);
            }
            

            if (Shape == 0)   //Ve duong thang
            {
                ShDraw = new Line(pStart, pEnd);
                //listDraw.Add(ShDraw);
                //ShDraw.DrawShape(gl);

                ShDraw.SetControlPoint(gl);
                listDraw.Add(ShDraw);

              
                // ShDraw.DrawControlPoint(gl);
                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 1) //Ve hinh tron
            {
                ShDraw = new Circle(pStart, pEnd);
                
               // ShDraw.DrawShape(gl);
               ShDraw.SetControlPoint(gl);
               
                listDraw.Add(ShDraw);
               // ShDraw = new Draw();
                //ShDraw.DrawControlPoint(gl);

                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 2)   //Ve HCN
            {

                ShDraw = new Rectangle(pStart, pEnd);
                //ShDraw.DrawShape(gl);
                
                
                ShDraw.SetControlPoint(gl);
                // ShDraw.DrawControlPoint(gl);
                listDraw.Add(ShDraw);
                //ShDraw = new Draw();
                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 3)   //Ve Ellipse
            {
                ShDraw = new Ellipse(pStart, pEnd);
               // ShDraw.DrawShape(gl);
                listDraw.Add(ShDraw);
                ShDraw.SetControlPoint(gl);
                ShDraw.DrawControlPoint(gl);
               

                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 4)   //Ve tam giac deu
            {
                ShDraw = new Triangle(pStart, pEnd);
               // ShDraw.DrawShape(gl);
                listDraw.Add(ShDraw);
                ShDraw.SetControlPoint(gl);
               // ShDraw.DrawControlPoint(gl);
                ShDraw.SetFillingColor(userColor);

                /*Point i = new Point();  //Tam cua tam giac deu
                i.X = Math.Abs((pEnd.X + pStart.X) / 2);
                i.Y = Math.Abs((gl.RenderContextProvider.Height - pEnd.Y + gl.RenderContextProvider.Height - pStart.Y) / 2);
                RGBColor newColor = { 1.0f, 0.0f, 0.0f }; // red
                RGBColor oldColor = { 0.0f, 0.0f, 0.0f }; // black
                ShDraw.BoundaryFill(i.X, i.Y, oldColor, newColor, gl);*/
                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 5)   //Ve ngu giac deu
            {
                ShDraw = new Pentagon(pStart, pEnd);
               // ShDraw.DrawShape(gl);
                listDraw.Add(ShDraw);
                ShDraw.SetControlPoint(gl);
                //ShDraw.DrawControlPoint(gl);

                //gl.End();
                //gl.Flush();
            }

            else if (Shape == 6)   //Ve luc giac deu
            {
                ShDraw = new Hexagon(pStart, pEnd);
               // ShDraw.DrawShape(gl);
                listDraw.Add(ShDraw);
                ShDraw.SetControlPoint(gl);
                //ShDraw.DrawControlPoint(gl);

                //gl.End();
                //gl.Flush();
            }
            else if (Shape == 7)
            {
                if (mouseLeft == true)
                    plg.DrawShape(gl);
            }
            else if (Shape == -1)
            {
               
                transform.TransformShape(ref ShDraw, pStart, pEnd, _currenControlPoint, gl);
                listDraw.Add(ShDraw);
                ShDraw.DrawControlPoint(gl);

            }

            ShDraw.DrawShape(gl);
            gl.Flush();
            if (!checkPolygon)
            {
                list_plg.Clear();
            }
        }

        private void bt_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                userColor = colorDialog1.Color;//Luu lai mau da chon
        }


        private void openGLControl_Load(object sender, EventArgs e)
        {

        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {

            pStart = e.Location;
            pEnd = pStart;
            if (select == true)
            {

                for (int i = 0; i < listDraw.Count; i++)
                {
                    if (listDraw[i].CheckInsideShape(pStart) == true)
                    {
                        listDraw[i].DrawControlPoint(gl);

                    }
                }
            }
            if (Shape==-1)
            {
                select = false;
                for (int i = 0; i < listDraw.Count; i++)
                {
                   
                    _currenControlPoint = listDraw[i].CheckControlPoint(pStart);
                    if (_currenControlPoint != -1)
                    {
                        
                        checkSeclected = true;
                        ShDraw = listDraw[i];

                        listDraw.RemoveAt(i);
                        listDraw.Clear();
                        break;
                    }
                }

            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            
            pEnd = e.Location;
            checkSeclected = false;
          
            if (Shape == 7)
            {
                if (e.Button == MouseButtons.Right)//Kiem tra neu la chuot phai thi luu diem cuoi vao danh sasch roi dung
                {
                    list_plg.Add(plg);
                    plg = new Polygon();
                    mouseLeft = false;
                }
                else
                    if (e.Button == MouseButtons.Left)//Kiem tra neu la chuot trai thi ve tiep
                {
                    plg.addPoint(e.Location);
                    mouseLeft = true;
                }
            }
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (select==true)
                pEnd = e.Location;
        }

        private void bt_Line_Click(object sender, EventArgs e)
        {
            Shape = 0;
            select = false;
            checkPolygon = false;
        }

        private void bt_Circle_Click(object sender, EventArgs e)
        {
            Shape = 1;
            select = false;
            checkPolygon = false;
        }

        private void bt_Rectangle_Click(object sender, EventArgs e)
        {
            Shape = 2;
            select = false;
            checkPolygon = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_Pentagon_Click(object sender, EventArgs e)
        {
            Shape = 5;
            select = false;
            checkPolygon = false;
        }

        private void bt_Ellipse_Click(object sender, EventArgs e)
        {
            Shape = 3;
            select = false;
            checkPolygon = false;
        }

        private void bt_Triangle_Click(object sender, EventArgs e)
        {
            Shape = 4;
            select = false;
            checkPolygon = false;
        }

        private void bt_Hexagon_Click(object sender, EventArgs e)
        {
            Shape = 6;
            select = false;
            checkPolygon = false;
        }

        private void bt_Hexagon_MouseClick(object sender, MouseEventArgs e)
        {
            pDot= e.Location;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkPolygon = true;
            Shape =7;
            select = false;
            if(Shape==1)
                select = true;
        }

 

        private void button2_Click_1(object sender, EventArgs e)
        {
            Shape = -1;
            select = false;
            listDraw.Add(ShDraw);
            ShDraw = new Draw();

        }

  
        /*private void openGLControl_MouseUp1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pDot=e.Location;

            }
           
            else if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }*/



        //chon mau to hinh
        /*private void button_FillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                ColorFill = colorDialog2.Color;
            }
        }*/


    }
}
