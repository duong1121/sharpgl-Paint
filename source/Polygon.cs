using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btaa
{
    internal class Polygon:Draw
    {
        public List<Point> plg = null;//list luu cac point de ve polygon

        public Polygon()
        {
            if (plg == null)
            {
                plg = new List<Point>();
            }
        }
        public void addPoint(Point point)
        {
            plg.Add(point);//them vao danh sach
        }
        public override void DrawShape(OpenGL gl)
        {
            
            //Hop diem tiep theo vao hinh polygon va ve 
            gl.Begin(OpenGL.GL_LINE_LOOP);

            plg.ForEach(plgon => gl.Vertex(plgon.X, gl.RenderContextProvider.Height - plgon.Y));//Ve tung duong thang giua cac diem
            gl.End();


            /*for (int i=1; i < plg.Count; i++)
            {
                gl.Vertex(plg[i-1].X, gl.RenderContextProvider.Height - plg[i-1].Y);
                gl.Vertex(plg[i].X, gl.RenderContextProvider.Height - plg[i].Y);
            }*/
        }
    }
}
