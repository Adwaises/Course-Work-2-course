using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class ParserObj
    {
        //public class VT
        //{
        //    public float X;
        //    public float Y;
        //    public float Z;
        //};
        class VN
        {
            public float X;
            public float Y;
            public float Z;
        };
        class F
        {
            public int A1;
            public int A2;
            public int A3;
        };

        class ObektS1
        {
            //     public int VT_i;
            

            //       public int VN_i;
            public List<VN> vn = new List<VN>();

            public List<F> f = new List<F>();

        };
 //       public List<VT> vt = new List<VT>();
        int count_v = 0;
        int count_n = 0;
        int count_p = 0;
        float[] newvert = new float[1000000];
        float[] vert = new float[1000000];
        float[] norm = new float[1000000];
        uint[] polygon = new uint[1000000];
        uint[] normalIndices = new uint[1000000];

        ObektS1 DER = new ObektS1();

        //    public void LoadMatrix(ref List<VT> vt, ref List<float> norm, ref List<uint> polygon, string filename)  //Функція завантаження
        public void LoadMatrix()
        {
            //    DER.VN_i = 1;
            //   DER.VT_i = 1;

  //          string filename = "Plita1T.obj";
            string filename = "textures//models//plita41.obj";
            //     string filename = "untitled3.obj";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                string s = "";

                using (StreamReader bs = new StreamReader(fs))
                {
                    string ss;
                    while ((ss = bs.ReadLine()) != null)
                    {
                        //      s += ss + '\n';
                        if (ss.StartsWith("v "))
                        {
                            string[] coord = ss.Split(' ');
                            //DER.VT[DER.VT_i].X = (float)Convert.ToDouble(coord[1].Replace('.',','));
                            //DER.VT[DER.VT_i].Y = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            //DER.VT[DER.VT_i].Z = (float)Convert.ToDouble(coord[3].Replace('.', ','));
                            //DER.VT_i++;
                            vert[count_v++] = (float)Convert.ToDouble(coord[1].Replace('.', ','));
                            vert[count_v++] = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            vert[count_v++] = (float)Convert.ToDouble(coord[3].Replace('.', ','));
                            VT v = new VT();
                            v.X = (float)Convert.ToDouble(coord[1].Replace('.', ','));
                            v.Y = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            v.Z = (float)Convert.ToDouble(coord[3].Replace('.', ','));
                          //  vt.Add(v);
                        }
                        else
                        if (ss.StartsWith("vn "))
                        {
                            string[] coord = ss.Split(' ');
                            //norm.Add((float)Convert.ToDouble(coord[1].Replace('.', ',')));
                            //norm.Add((float)Convert.ToDouble(coord[2].Replace('.', ',')));
                            //norm.Add((float)Convert.ToDouble(coord[3].Replace('.', ',')));
                            norm[count_n++] = (float)Convert.ToDouble(coord[1].Replace('.', ','));
                            norm[count_n++] = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            norm[count_n++] = (float)Convert.ToDouble(coord[3].Replace('.', ','));

                        }
                        else
                        if (ss.StartsWith("f "))
                        {
                            string[] points = ss.Split(' ');
                            //for (int i = 1; i < 4; i++)
                            //{
                            //    string[] point = points[i].Split('/');
                            //    //for (int j = 0; j < 3; j++)
                            //    //{
                            //    //    if (point[j].Length == 0)
                            //    //    {
                            //    //        point[j] = "0";
                            //    //    }
                            //    //}
                            //   ///было тут
                            //}
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[1]);
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[2]);
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[3]);



                            //polygon.Add(Convert.ToUInt32(points[1].Split('/')[0]) - 1);
                            //polygon.Add(Convert.ToUInt32(points[2].Split('/')[0]) - 1);
                            //polygon.Add(Convert.ToUInt32(points[3].Split('/')[0]) - 1);
                            //   normalIndices[count_nI++] = Convert.ToUInt32(points[1].Split('/')[2]);
                            //     polygon[count_p++] = Convert.ToUInt32(points[1].Split('/')[1]);
                            //      polygon[count_p++] = Convert.ToUInt32(points[1].Split('/')[2]);

                            //    polygon[count_p++] = Convert.ToUInt32(points[2].Split('/')[0]) - 1;
                            //     normalIndices[count_nI++] = Convert.ToUInt32(points[2].Split('/')[2]);
                            //       polygon[count_p++] = Convert.ToUInt32(points[2].Split('/')[1]);
                            //      polygon[count_p++] = Convert.ToUInt32(points[2].Split('/')[2]);
                           
                            polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[1].Split('/')[0]) - 1);
                            polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[2].Split('/')[0]) - 1);
                            polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[3].Split('/')[0]) - 1);
                            //     polygon[count_p++] = Convert.ToUInt32(points[3].Split('/')[0]) - 1;
                            //     normalIndices[count_nI++] = Convert.ToUInt32(points[2].Split('/')[2]);
                            //       polygon[count_p++] = Convert.ToUInt32(points[3].Split('/')[1]);
                            //       polygon[count_p++] = Convert.ToUInt32(points[3].Split('/')[2]);
                            //DER.VN[DER.VN_i].A1 = Convert.ToInt32(points[1].Split('/')[0]);
                            //DER.VN[DER.VN_i].A2 = Convert.ToInt32(points[2].Split('/')[0]);
                            //DER.VN[DER.VN_i].A3 = Convert.ToInt32(points[3].Split('/')[0]);
                        }
                    }
                }
                // По каждой вершине каждого треугольника
                //for (int i = 0; i < count_p; i++)
                //{

                //    //         Индекс к позиции вершины: vertexIndices[i]
                //    uint vertexIndex = polygon[i];

                //    //       Поэтому позиция, это temp_vertices[vertexIndex - 1](тут у нас - 1, так как в С++ индексация идет с 0, а в OBJ с 1):
                //    float vertex = vert[vertexIndex - 1];

                //    //       И в итоге мы получаем позицию нашей новой вершины
                //    newvert[i] = vertex;
                //}
            }
        }
        public void on_paint(OpenGL gl)
        {

            //       Pixel jj1 = { 1, 1, 1 };
            //       tuman(1, 1, 0.2, jj1);
            int i = 0;
            // //    glPointSize(5);
            // gl.Color(0, 0, 0);
            // //   gl.Begin(OpenGL.GL_LINES);

            ////     gl.Begin(OpenGL.GL_TRIANGLES);

            





            //gl.Enable(OpenGL.GL_LIGHTING);
            ////      float[] material_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };

            //float[] g_LightPosition = { 0, 0, 0, 3 };
            //gl.Enable(OpenGL.GL_LIGHTING);
            //gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
            ////     gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, material_diffuse);
            //gl.Enable(OpenGL.GL_LIGHT0);
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Normal(norm);
            //while (i <= count_p)
            //{

            //    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);

            //    i++;
            //    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);
            //    i++;
            //    gl.Vertex(vt[Convert.ToInt32(polygon[i])].X, vt[Convert.ToInt32(polygon[i])].Y, vt[Convert.ToInt32(polygon[i])].Z);
            //    i++;
            //}

            gl.PushMatrix();
            gl.ShadeModel(OpenGL.GL_SMOOTH);
            //       gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
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
            float[] light0_direction = { 100.0f, 0.0f, 100.0f, 0.0f };
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0_diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0_direction);
            gl.Enable(OpenGL.GL_LIGHTING);
            float[] material_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };

                float[] g_LightPosition = { 0, 0, 0, 3 };
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_NORMALIZE);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, material_diffuse);
            gl.Enable(OpenGL.GL_LIGHT0);
            
            gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.EnableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.VertexPointer(3, 0, vert);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, norm);
            gl.DrawElements(OpenGL.GL_TRIANGLES, count_p, polygon);
            //     gl.DrawElements(OpenGL.GL_LINES, count_p, polygon);
            gl.DisableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.DisableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.End();

                    gl.Disable(OpenGL.GL_LIGHT0);
                  gl.Disable(OpenGL.GL_LIGHTING);
            gl.PopMatrix();

        }
    }
}

