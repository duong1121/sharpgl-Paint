using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btaa
{
    internal class Hexagon:Draw
    {
        public Hexagon(Point pStart, Point pEnd)
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

            Point i = new Point();  //Tam 
            i.X = (pStart.X + pEnd.X) / 2;
            i.Y = (pStart.Y + pEnd.Y) / 2;

            double R = Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2)) / 2;

            max_x = (int)Math.Round(i.X + R);
            max_y = (int)Math.Round(i.Y + R);
            min_x = (int)Math.Round(i.X - R);
            min_y = (int)Math.Round(i.Y - R);
            mid_x = (max_x + min_x) / 2;
            mid_y = (max_y + min_y) / 2;

            //Point point_0 = new Point(i.X, i.Y );
            Point point_0 = new Point(max_x, max_y);
            Point point_1 = new Point(min_x, min_y);
            Point point_2 = new Point(max_x, min_y);
            Point point_3 = new Point(min_x, max_y);
            Point point_4 = new Point(mid_x, min_y);
            Point point_5 = new Point(mid_x, max_y);
            Point point_6 = new Point(min_x, mid_y);
            Point point_7 = new Point(max_x, mid_y);

            controlPoints.Add(point_0);
            controlPoints.Add(point_1);
            controlPoints.Add(point_2);
            controlPoints.Add(point_3);
            controlPoints.Add(point_4);
            controlPoints.Add(point_5);
            controlPoints.Add(point_6);
            controlPoints.Add(point_7);
        }
        public override void DrawShape(OpenGL gl)
        {

            Point i = new Point();  //Tam cua ngu giac deu
            i.X = Math.Abs((pEnd.X + pStart.X) / 2);
            i.Y = Math.Abs((gl.RenderContextProvider.Height - pEnd.Y + gl.RenderContextProvider.Height - pStart.Y) / 2);

            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            Point D = new Point();
            Point E = new Point();


            double R = Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2)) / 2;

            //Toa do dinh A
            A.X = (int)(i.X + R * Math.Cos(0 * Math.PI / 180));
            A.Y = (int)(i.Y + R * Math.Sin(0 * Math.PI / 180));

            //Toa do dinh B
            B.X = (int)(i.X + R * Math.Cos(72 * Math.PI / 180));
            B.Y = (int)(i.Y + R * Math.Sin(72 * Math.PI / 180));

            //Toa do dinh C
            C.X = (int)(i.X + R * Math.Cos(144 * Math.PI / 180));
            C.Y = (int)(i.Y + R * Math.Sin(144 * Math.PI / 180));

            //Toa do dinh D
            D.X = (int)(i.X + R * Math.Cos(216 * Math.PI / 180));
            D.Y = (int)(i.Y + R * Math.Sin(216 * Math.PI / 180));

            //Toa do dinh E
            E.X = (int)(i.X + R * Math.Cos(288 * Math.PI / 180));
            E.Y = (int)(i.Y + R * Math.Sin(288 * Math.PI / 180));

            //Noi tung dinh lai voi nhau
            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(A.X, A.Y);
            gl.Vertex(B.X, B.Y);

            gl.Vertex(B.X, B.Y);
            gl.Vertex(C.X, C.Y);

            gl.Vertex(C.X, C.Y);
            gl.Vertex(D.X, D.Y);

            gl.Vertex(D.X, D.Y);
            gl.Vertex(E.X, E.Y);

            gl.Vertex(A.X, A.Y);
            gl.Vertex(E.X, E.Y);

            gl.End();
        }
    }
}
