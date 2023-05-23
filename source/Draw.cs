using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btaa
{
    internal class Draw
    {
        protected Point pStart;
        protected Point pEnd;
        protected int lineWidth = 1;
        protected List<Point> controlPoints = new List<Point>();
        protected Color fillingColor = Color.White;
        //Biến đánh dấu có tô màu hay không
        public bool isColored;
        
        public void SetPoint(Point x, Point y)

        {
            if (x.X < y.X)
            {
                pStart = x;
                pEnd = y;
            }
            else
            {
                pStart = y;
                pEnd = x;
            }
        }
        /*public void SetShape(short s)
        {
            Shape = s;
        }*/
        public virtual void SetControlPoint(OpenGL gl)
        {
            
        }
        public virtual void DrawShape(OpenGL gl)
        {
        }
        public virtual void addPoint()
        {

        }
        public virtual void FloodFill(OpenGL gl)
        {
            
        }
        public void SetFillingColor(Color color)
        {
            fillingColor = color;
        }

        // Lấy màu tô
        public Color GetFillColor()
        { return fillingColor; }
        // Hàm vẽ điểm điều khiển
        public void DrawControlPoint(OpenGL gl)
        {
            // Màu mặc định của điểm điều khiển là đen
            gl.Color(0.24f, 0.2f, 0.3f);
            // Kích thước mặc định của điểm điều khiển là 5
            gl.PointSize(20);
            // Làm mịn pixel để vẽ tròn hơn
            gl.Enable(OpenGL.GL_POINT_SMOOTH);
            // Bắt đầu vẽ
            gl.Begin(OpenGL.GL_POINTS);
            

            for (int i = 0; i < controlPoints.Count; i++)
            {
                gl.Vertex(controlPoints[i].X, gl.RenderContextProvider.Height - controlPoints[i].Y);
            }

            gl.End();
        }
        public virtual List<Point> GetListPoint()
        {
            return null;
        }


        // Kiểm tra điểm có thuộc hình hay không
        public bool CheckInsideShape(Point point)
        {
            if (controlPoints.Count == 0)
                return false;

            if (point.X < controlPoints[1].X + 10 && point.X > controlPoints[1].X - 10)
                return false;
            if (point.Y > controlPoints[2].Y - 10 && point.Y < controlPoints[7].Y + 10)
                return false;
            return true;
        }
        /*                                     Cac ham bo tro dung de to mau van dang loi
        // Struct mau RGB 
        public struct RGBColor
        {
            public float r;
            public float g;
            public float b;
        }
        
        // Lay mau cua pixel
        /*RGBColor getPixelColor(int x, int y, OpenGL gl)
        {
            float[] prt = new float[3];

            gl.ReadPixels(x, gl.RenderContextProvider.Height - y, 1, 1, OpenGL.GL_RGB, OpenGL.GL_FLOAT, prt);
            var color = new RGBColor
            {
                r = prt[0],
                g = prt[1],
                b = prt[2]
            };
            return color;
        }

        public void setPixelColor(int x, int y, RGBColor color, OpenGL gl)
        {
            gl.Color(color.r, color.g, color.b);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
            gl.Flush();
        }

        //Ham to mau BoundryFill
        public void BoundaryFill(int x, int y, RGBColor F_Color, RGBColor B_Color, OpenGL gl)
        {
            RGBColor currentColor;

            currentColor = getPixelColor(x, y, gl);

            if (!IsSameColor(currentColor, B_Color) && !IsSameColor(currentColor, F_Color))
            {

                setPixelColor(x, y, F_Color, gl);
                BoundaryFill(x - 1, y, F_Color, B_Color, gl);
                BoundaryFill(x, y + 1, F_Color, B_Color, gl);
                BoundaryFill(x + 1, y, F_Color, B_Color, gl);
                BoundaryFill(x, y - 1, F_Color, B_Color, gl);
            }
        }

        //Ham check mau co trung nhau hay khong
        public bool IsSameColor(RGBColor x, RGBColor y)
        {
            if (x.r == y.r && x.b == y.b && x.g == y.g)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        */

        public Point GetPStart()
        {
            return pStart;
        }

        public Point GetPEnd()
        {
            return pEnd;
        }
        public int CheckControlPoint(Point point)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                if (Math.Abs(point.X - controlPoints[i].X) <= 5 && Math.Abs(point.Y - controlPoints[i].Y) <= 5)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}