using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class Model
    {

        public List<VT> vt = new List<VT>();
        //  float[] vert = new float[1000000];
        public List<float> norm = new List<float>();
  //      float[] norm = new float[1000000];
      //  uint[] polygon = new uint[1000000];
        List<uint> polygon = new List<uint>();

        public void LoadModel(string filename)
        {
            ParserObj p = new ParserObj();
            p.LoadMatrix(ref vt, ref norm, ref polygon, filename);
        }
        public void Render(OpenGL gl)
        {
            {
                int i = 0;

                gl.ShadeModel(OpenGL.GL_SMOOTH);
                gl.ClearDepth(1.0f);
                gl.Enable(OpenGL.GL_DEPTH_TEST);
                gl.DepthFunc(OpenGL.GL_LEQUAL);
                gl.CullFace(OpenGL.GL_BACK);
                gl.FrontFace(OpenGL.GL_CCW);
                gl.Enable(OpenGL.GL_CULL_FACE);
                gl.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
                gl.Enable(OpenGL.GL_LIGHTING);
                gl.LightModel(OpenGL.GL_LIGHT_MODEL_TWO_SIDE, OpenGL.GL_TRUE);
                gl.Enable(OpenGL.GL_NORMALIZE);

                float[] light0_diffuse = { 1.0f, 1.0f, 1f };
                gl.Enable(OpenGL.GL_LIGHT0);

                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0_diffuse);
                gl.PushMatrix();
                gl.Enable(OpenGL.GL_LIGHTING);

                float[] g_LightPosition = { 0, 0, 0, 3 };
                gl.Enable(OpenGL.GL_LIGHTING);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
                //     gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, material_diffuse);
                gl.Enable(OpenGL.GL_LIGHT0);
                gl.Begin(OpenGL.GL_TRIANGLES);
                gl.Normal(norm.ToArray());
                while (i < polygon.Count)
                {
                    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);
                    i++;
                    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);
                    i++;
                    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);
                    i++;
                }
                gl.Translate(1f, 1f, 1f);
                gl.End();

                gl.Disable(OpenGL.GL_LIGHT0);
                gl.Disable(OpenGL.GL_LIGHTING);
                gl.PopMatrix();
            }
        }
    }
}
