using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
                                                                  //\\ 
                                                                 //  \\
                                                                //    \\
                                                               //      \\
                                                              //        \\
                                                             //          \\
                                                            //            \\
                                                           //              \\
namespace WorkPlace                                       //                \\ 
{                                                        //                  \\
    class ParserObj                                     //*****парсер 4.0*****\\
    {
        int count_v = 0;
        int count_n = 0;
        int count_p = 0;
        float[] newvert = new float[1000000];
        float[] vert = new float[1000000];
        float[] norm = new float[1000000];
        uint[] polygon = new uint[1000000];
        uint[] normalIndices = new uint[1000000];

        public void LoadMatrix(ref List<float> vt, ref List<float> norm, ref List<uint> polygon, string filename)  //Функція завантаження
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (StreamReader bs = new StreamReader(fs))
                {
                    string ss;
                    while ((ss = bs.ReadLine()) != null)
                    {
                        if (ss.StartsWith("v "))
                        {
                            string[] coord = ss.Split(' ');
                            //vert[count_v++] = (float)Convert.ToDouble(coord[1].Replace('.', ','));
                            //vert[count_v++] = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            vt.Add((float)Convert.ToDouble(coord[1].Replace('.', ',')));
                            vt.Add((float)Convert.ToDouble(coord[2].Replace('.', ',')));
                            vt.Add((float)Convert.ToDouble(coord[3].Replace('.', ',')));
                        }
                        else
                        if (ss.StartsWith("vn "))
                        {
                            string[] coord = ss.Split(' ');
                            norm.Add((float)Convert.ToDouble(coord[1].Replace('.', ',')));
                            norm.Add((float)Convert.ToDouble(coord[2].Replace('.', ',')));
                            norm.Add((float)Convert.ToDouble(coord[3].Replace('.', ',')));
                            //norm[count_n++] = (float)Convert.ToDouble(coord[1].Replace('.', ','));
                            //norm[count_n++] = (float)Convert.ToDouble(coord[2].Replace('.', ','));
                            //norm[count_n++] = (float)Convert.ToDouble(coord[3].Replace('.', ','));
                        }
                        else
                        if (ss.StartsWith("f "))
                        {
                            string[] points = ss.Split(' ');
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[1]);
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[2]);
                            //polygon[count_p++] = Convert.ToUInt32(ss.Split(' ')[3]);
                            polygon.Add(Convert.ToUInt32(points[1].Split('/')[0]) - 1);
                            polygon.Add(Convert.ToUInt32(points[2].Split('/')[0]) - 1);
                            polygon.Add(Convert.ToUInt32(points[3].Split('/')[0]) - 1);
                            //polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[1].Split('/')[0]) - 1);
                            //polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[2].Split('/')[0]) - 1);
                            //polygon[count_p++] = Convert.ToUInt32(Convert.ToInt32(points[3].Split('/')[0]) - 1);

                        }
                    }
                }
            }
        }
        public void on_paint(OpenGL gl)
        {
            //gl.Enable(OpenGL.GL_LIGHTING);
            ////      float[] material_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
            //float[] g_LightPosition = { 0, 0, 0, 3 };
            //gl.Enable(OpenGL.GL_LIGHTING);
            //gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
            ////     gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, material_diffuse);
            //gl.Enable(OpenGL.GL_LIGHT0);
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Normal(norm);                                                                    //
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
            gl.ClearDepth(1.0f);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.DepthFunc(OpenGL.GL_LEQUAL);
            gl.CullFace(OpenGL.GL_BACK);
            gl.FrontFace(OpenGL.GL_CCW);
            gl.Enable(OpenGL.GL_CULL_FACE);
            gl.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_TWO_SIDE, OpenGL.GL_TRUE);
            gl.Enable(OpenGL.GL_NORMALIZE);
            float[] light0_direction = { 100.0f, 0.0f, 100.0f, 0.0f };
            float[] light0_diffuse = { 1.0f, 1.0f, 1.0f };
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0_direction);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0_diffuse);           
    //        float[] material_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
    //        float[] g_LightPosition = { 0, 0, 0, 3 };
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_NORMALIZE);
    //        gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
    //        gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, material_diffuse);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.EnableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.VertexPointer(3, 0, vert);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, norm);
            gl.DrawElements(OpenGL.GL_TRIANGLES, count_p, polygon);
            //     gl.DrawElements(OpenGL.GL_LINES, count_p, polygon);
            gl.DisableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.DisableClientState(OpenGL.GL_VERTEX_ARRAY);
            gl.Disable(OpenGL.GL_LIGHT0);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.PopMatrix();

        }
    }
}

