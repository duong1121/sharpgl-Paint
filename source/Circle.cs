using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btaa
{
    internal class Circle:Draw
    {
        public Circle(Point pStart, Point pEnd)
        {
            base.pStart = pStart;
            base.pEnd = pEnd; 
        }
        public override void SetControlPoint(OpenGL gl)
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            Point i = new Point();  //Tam cua hinh tron nam giua duong thang chuot keo
            i.X = (pStart.X + pEnd.X) / 2;
            i.Y = (pStart.Y + pEnd.Y) / 2;
            double R = Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2)) / 2;

            max_x = (int)Math.Round(i.X + R);
            max_y = (int)Math.Round(i.Y + R);
            min_x = (int)Math.Round(i.X - R);
            min_y = (int)Math.Round(i.Y - R);
            mid_x = (max_x + min_x) / 2;
            mid_y = (max_y + min_y) / 2;

            Point point_0 = new Point(mid_x, min_y - 30);
            Point point_1 = new Point(max_x, max_y);
            Point point_2 = new Point(min_x, min_y);
            Point point_3 = new Point(max_x, min_y);
            Point point_4 = new Point(min_x, max_y);
            Point point_5 = new Point(mid_x, min_y);
            Point point_6 = new Point(mid_x, max_y);
            Point point_7 = new Point(min_x, mid_y);
            Point point_8 = new Point(max_x, mid_y);
           
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
            Point i = new Point();  //Tam cua hinh tron nam giua duong thang chuot keo
            i.X = Math.Abs((pEnd.X + pStart.X) / 2);
            i.Y = Math.Abs((gl.RenderContextProvider.Height - pEnd.Y + gl.RenderContextProvider.Height - pStart.Y) / 2);

            double R = Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2)) / 2;    //Gia tri ban kinh hinh tron
            double theta;   //Gia tri luu goc khi xoay quoanh tam i
            gl.PointSize(2);
            gl.Begin(OpenGL.GL_POINTS);
            for (int e = 0; e < 36000; e++)
            {
                theta = e * Math.PI / 180;
                gl.Vertex(i.X + R * Math.Cos(theta), i.Y - R * Math.Sin(theta));
            }
            gl.End();
        }
    }
}
