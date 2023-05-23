using SharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btaa
{
    internal class Rectangle:Draw
    {
        
    
        public Rectangle(Point pStart, Point pEnd)
        {
            base.pStart = pStart;
            base.pEnd = pEnd;
            
        }
        public override void SetControlPoint(OpenGL gl)
        {
            Point i = new Point();  //Tam cua hinh tron nam giua duong thang chuot keo
            i.X = (pStart.X + pEnd.X) / 2;
            i.Y = (pStart.Y + pEnd.Y) / 2;
            Point point_0 = new Point(i.X, pStart.Y -30);
            Point point_1 = new Point(pStart.X, pStart.Y);
            Point point_2 = new Point((pStart.X + pEnd.X) / 2, pStart.Y );
            Point point_3 = new Point(pEnd.X, pEnd.Y);
            Point point_4 = new Point((pStart.X + pEnd.X) / 2, pEnd.Y);
            Point point_5 = new Point(pStart.X , (pStart.Y + pEnd.Y) / 2);
            Point point_6 = new Point(pEnd.X, (pStart.Y + pEnd.Y) / 2);
            Point point_7 = new Point(pEnd.X, pStart.Y);
            Point point_8 = new Point(pStart.X,  pEnd.Y);

            controlPoints.Add(point_0);
            controlPoints.Add(point_1);
            controlPoints.Add(point_2);
            controlPoints.Add(point_3);
            controlPoints.Add(point_4);
            controlPoints.Add(point_5);
            controlPoints.Add(point_6);
            controlPoints.Add(point_7);
            controlPoints.Add(point_8);
            controlPoints.Add(i);
        }
        public override void DrawShape(OpenGL gl)
        {
            //Ve tung canh cua hinh chu nhat voi diem dau va diem cuoi chuot la 2 dinh doi dien cua 1 hinh chu nhat
            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pEnd.Y);

            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pEnd.Y);

            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pStart.Y);

            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pEnd.Y);
            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pEnd.Y);
            gl.End();
        }


        //them vao danh sach

        public override void FloodFill(OpenGL gl)
        {
            gl.PointSize(3);
            gl.Color(0.250f, 0.230f, 0.230f);
            gl.Begin(OpenGL.GL_POINTS);

            for (int i = (pStart.X) + 1; i < (pEnd.X) - 1; i++)
            {
                for (int e = (pStart.Y) + 1; e < (pEnd.Y) - 1; e++)
                    gl.Vertex(i, gl.RenderContextProvider.Height - e);
            }
            gl.End();
           
        }
    }
}
