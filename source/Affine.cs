using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btaa
{
    internal class Affine
    {
        // Ma trận biến đổi
        private float[] matrix =
        {
            1, 0, 0,
            0, 1, 0,
            0, 0, 1
        };

        public void NhanMaTran(float[] _matrix)
        {
            float[] result = new float[9];

            result[0] = matrix[0] * _matrix[0] + matrix[1] * _matrix[3] + matrix[2] * _matrix[6];
            result[1] = matrix[0] * _matrix[1] + matrix[1] * _matrix[4] + matrix[2] * _matrix[7];
            result[2] = matrix[0] * _matrix[2] + matrix[1] * _matrix[5] + matrix[2] * _matrix[8];

            result[3] = matrix[3] * _matrix[0] + matrix[4] * _matrix[3] + matrix[5] * _matrix[6];
            result[4] = matrix[3] * _matrix[1] + matrix[4] * _matrix[4] + matrix[5] * _matrix[7];
            result[5] = matrix[3] * _matrix[2] + matrix[4] * _matrix[5] + matrix[5] * _matrix[8];

            result[6] = matrix[6] * _matrix[0] + matrix[7] * _matrix[3] + matrix[8] * _matrix[6];
            result[7] = matrix[6] * _matrix[1] + matrix[7] * _matrix[4] + matrix[8] * _matrix[7];
            result[8] = matrix[6] * _matrix[2] + matrix[7] * _matrix[5] + matrix[8] * _matrix[8];

            matrix = result;
        }

        // Ma trận tịnh tiến
        public void Translate(float dx, float dy)
        {
            
		    //Tạo ma trận Affine tịnh tiến:

            float[] matrixTranslate =
            {
                1, 0, dx,
                0, 1, dy,
                0, 0, 1
            };

            // Nhân với ma trận affine hiện có
            NhanMaTran(matrixTranslate);
        }

        // Ma trận co dãn
        public void Scale(float sx, float sy)
        {

		   // Tạo ma trận Affine tịnh tiến:

            float[] matrixTranslate =
            {
                sx, 0, 0,
                0, sy, 0,
                0, 0, 1
            };

            // Nhân với ma trận affine hiện có
            NhanMaTran(matrixTranslate);
        }

        // Ma trận quay, góc quay ở tâm
        public void Rotate(float angle)
        {
            
		    //Tạo ma trận Affine xoay:

            float[] matrixTranslate =
            {
                (float)Math.Cos(angle), -(float)Math.Sin(angle), 0,
                (float)Math.Sin(angle), (float)Math.Cos(angle), 0,
                0, 0, 1
            };

            // Nhân với ma trận affine hiện có
            NhanMaTran(matrixTranslate);
        }

        // Biến đổi 1 điểm
        public Point TransformPoint(Point point)
        {
            
		    //Thực hiện phép nhân ma trận Affine với điểm (x, y, 1)
	        
            Point result = new Point();

            result.X = (int)Math.Round(matrix[0] * point.X + matrix[1] * point.Y + matrix[2]);
            result.Y = (int)Math.Round(matrix[3] * point.X + matrix[4] * point.Y + matrix[5]);

            return result;
        }

        public void TransformShape(ref Draw shape, Point _pStart, Point _pEnd, int controlPoint, OpenGL gl)
        {
            Point pNewStart = new Point();
            Point pNewEnd = new Point();
            Point pOldStart = shape.GetPStart();
            Point pOldEnd = shape.GetPEnd();

            // Tuỳ vào control Point đang chọn mà biến đổi
            if (controlPoint == 0)
            {
                // Xoay hình (chưa hoàn thành)
                pNewStart = pOldStart;
                pNewEnd = pOldEnd;
            }
            // Co dãn tuỳ theo control point được chọn
            else if (controlPoint == 1)
            {
                if (pOldStart.Y > pOldEnd.Y)
                {
                    pNewEnd = pOldEnd;
                    pNewStart = _pEnd;
                }
                else
                {
                    pNewEnd.X = pOldEnd.X;
                    pNewEnd.Y = _pEnd.Y;
                    pNewStart.Y = pOldStart.Y;
                    pNewStart.X = _pEnd.X;
                }
            }
            else if (controlPoint == 2)
            {
                if (pOldStart.Y > pOldEnd.Y)
                {
                    pNewStart.X = pOldStart.X;
                    pNewStart.Y = _pEnd.Y;
                    pNewEnd = pOldEnd;
                }
                else
                {
                    pNewEnd.X = pOldEnd.X;
                    pNewEnd.Y = _pEnd.Y;
                    pNewStart = pOldStart;
                }
            }
            else if (controlPoint == 3)
            {
                if (pOldEnd.Y > pOldStart.Y)
                {
                    pNewEnd = _pEnd;
                    pNewStart = pOldStart;
                }
                else
                {
                    pNewEnd.X = _pEnd.X;
                    pNewEnd.Y = pOldEnd.Y;
                    pNewStart.X = pOldStart.X;
                    pNewStart.Y = _pEnd.Y;
                }
            }
            else if (controlPoint == 4)
            {
                pNewStart.Y = pOldStart.Y;
                pNewStart.X = _pEnd.X;

                pNewEnd = pOldEnd;
            }
            else if (controlPoint == 5)
            {
                pNewEnd.Y = pOldEnd.Y;
                pNewEnd.X = _pEnd.X;

                pNewStart = pOldStart;
            }
            else if (controlPoint == 6)
            {
                if (pOldStart.Y < pOldEnd.Y)
                {
                    pNewEnd = pOldEnd;
                    pNewStart = _pEnd;
                }
                else
                {
                    pNewEnd.X = pOldEnd.X;
                    pNewEnd.Y = _pEnd.Y;
                    pNewStart.Y = pOldStart.Y;
                    pNewStart.X = _pEnd.X;
                }
            }
            else if (controlPoint == 7)
            {
                if (pOldStart.Y < pOldEnd.Y)
                {
                    pNewStart.X = pOldStart.X;
                    pNewStart.Y = _pEnd.Y;
                    pNewEnd = pOldEnd;
                }
                else
                {
                    pNewEnd.X = pOldEnd.X;
                    pNewEnd.Y = _pEnd.Y;
                    pNewStart = pOldStart;
                }

            }
            else if (controlPoint == 8)
            {
                if (pOldEnd.Y < pOldStart.Y)
                {
                    pNewEnd = _pEnd;
                    pNewStart = pOldStart;
                }
                else
                {
                    pNewEnd.X = _pEnd.X;
                    pNewEnd.Y = pOldEnd.Y;
                    pNewStart.X = pOldStart.X;
                    pNewStart.Y = _pEnd.Y;
                }
            }
            else if (controlPoint == 9)
            {
                int dx = (pOldEnd.X - pOldStart.X) / 2;
                int dy = (pOldEnd.Y - pOldStart.Y) / 2;

                int stepY;
                if (dy > 0)
                {
                    stepY = 1;
                }
                else
                {
                    stepY = -1;
                }
                dy = Math.Abs(dy);

                pNewStart.X = _pEnd.X - dx;
                pNewEnd.X = _pEnd.X + dx;

                if (stepY > 0)
                {
                    pNewStart.Y = _pEnd.Y - dy;
                    pNewEnd.Y = _pEnd.Y + dy;
                }
                else
                {
                    pNewStart.Y = _pEnd.Y + dy;
                    pNewEnd.Y = _pEnd.Y - dy;
                }
            }


            // Tạo lại hình mới sau khi biến đổi
            string type = shape.GetType().ToString();
            if (type == "btaa.Line")
            {
                shape = new Line(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Rec")
            {
                shape = new Rectangle(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Ellipse")
            {
                shape = new Ellipse(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Circle")
            {
                shape = new Circle(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Triangle")
            {
                shape = new Triangle(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Pentagon")
            {
                shape = new Pentagon(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            else if (type == "btaa.Hexagon")
            {
                shape = new Hexagon(pNewStart, pNewEnd);
                shape.SetControlPoint(gl);
            }
            
        }
    }
}
