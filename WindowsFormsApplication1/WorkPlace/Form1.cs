using ObjectsControl;
using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPlace
{
    public partial class Form1 : Form
    {
        private double rotation = 0;
        private double centX = 0;
        private double centY = 0;
        private double centZ = 0;
        private double otstup = 0;
        private int indexOfObj;
        private Room room;
        private double radius = 6;
        private double CamX = 0;
        private double CamY = 0;
        private double CamZ = 0;
        private double secret = 20;
        private double HitX = 0;
        private double HitY = 0;
        private double HitZ = 0;
        private double perspective = 1f;

        private double mouseX = 0;
        private double mouseY = 0;
        private double sigma = 0;
        private double fi = 0;
        private bool editing = false;
        private bool mouseDown = false;
        private bool objMove = false;
        Vertex ray_m = new Vertex(0, 0, 0);
        Vertex ray_n = new Vertex(0, 0, 0);

        public Form1()
        {
            InitializeComponent();
            openGLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(openGLControl_MouseWheel);
            room = new Room(8, 4, 2.5);
            просмотрToolStripMenuItem.Checked = true;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            gl.ClearColor(0.4f, 0.4f, 0.4f, 0);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            var gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
 
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1f, 0f, 0f); // X Green
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(3f, 0f, 0f);
            gl.Color(0f, 1f, 0f); // Y Red
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(0f, 3f, 0f);
            gl.Color(0f, 0f, 1f); // Z Blue
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(0f, 0f, 3f);
            gl.End();

            for (int i = 0; i < room.GetSize(); i++)
            {
                room.GetObj(i).Draw(gl);
            }
            float zsd;
            if (editing)
            {
                zsd = (float)(ray_n.Z - radius);
            }
            else
            {
                zsd = -1;
            }
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 1f, 0f);
            gl.Vertex(CamX, CamY, CamZ);
            gl.Vertex(-(ray_n.X * secret), -(ray_n.Y * secret), zsd + otstup);

            //    gl.Vertex(ray_m.X, ray_m.Y, ray_m.Z);
            gl.End();
            gl.PopMatrix();
            DrawPlane(gl);
            room.DrawRoom(gl);
            gl.Flush();
        }
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(40, (double)Width / (double)Height, 0.5, 200.0);
            gl.LookAt(radius * Math.Cos(sigma * Math.PI / 180) * Math.Cos(fi * Math.PI / 180), radius *
                Math.Cos(sigma * Math.PI / 180) * Math.Sin(fi * Math.PI / 180), radius * Math.Sin(sigma * Math.PI / 180),
                centX, centY, centZ, 0, 0, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SharpGLXmlFormat s = new SharpGLXmlFormat();
            //SceneControl sc = new SceneControl();
            //s.SaveData(sc.Scene, "save.xml");
            room.AddObj((new Cupboard(0, 0, -1, 1, 1, 2)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //     openGLControl_Resized(sender, e);
      //      SharpGLXmlFormat s = new SharpGLXmlFormat();
    //        SceneControl sc = new SceneControl();

      //      sc.Scene = s.LoadData("save.xml");

        }

        private void openGLControl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                radius -= 2f;
                secret -= 6.5f;
                openGLControl_Resized(sender, e);
            }
            else
            {
                radius += 2f;
                secret += 6.5f;
                openGLControl_Resized(sender, e);
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Button.ToString().Equals("Left") && !editing)
            {
                sigma = sigma + e.Y - mouseY;
                fi = (fi + mouseX - e.X) % 360;
                openGLControl_Resized(sender, e);
                mouseY = e.Y;
                mouseX = e.X;

            }
            if (mouseDown && e.Button.ToString().Equals("Right"))
            {
                centY = centY + (e.X - mouseX) / 10;
                centX = centX + (e.Y - mouseY) / 10;
                openGLControl_Resized(sender, e);
                mouseY = e.Y;
                mouseX = e.X;
            }
            if (objMove)
            {
                room.GetObj(indexOfObj).Y = room.GetObj(indexOfObj).Y + (e.Y - mouseY) / 100;
                room.GetObj(indexOfObj).X = room.GetObj(indexOfObj).X + (mouseX - e.X) / 100;
                mouseY = e.Y;
                mouseX = e.X;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }



        private void размерыКомнатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRoomConf f = new FRoomConf(ref room);
            f.Show();
        }

        private void НачальноеПоложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            centX = 0;
            centY = 0;
            sigma = 30;
            fi = 45;
            openGLControl_Resized(sender, e);
        }



        private void openGLControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (editing)
            {
                OpenGL gl = openGLControl.OpenGL;
                double NMouseX, NMouseY;
                double x, y, z;
                NMouseX = -1.0 + 2.0 * e.X / openGLControl.Width;
                NMouseY = 1.0 - 2.0 * e.Y / openGLControl.Height;
                //     Console.WriteLine(NMouseX + "  " + NMouseY);
                //is FOV in radians 
                y = (NMouseY * Math.Tan(40 / 2.0));
                x = ((NMouseX / (openGLControl.Width / openGLControl.Height)) * Math.Tan(40 / 2.0));
                CamX = ((radius - 0.5) * Math.Cos(sigma * Math.PI / 180) * Math.Cos(fi * Math.PI / 180));
                CamY = ((radius - 0.5) * Math.Cos(sigma * Math.PI / 180) * Math.Sin(fi * Math.PI / 180));
                CamZ = ((radius - 0.5) * Math.Sin(sigma * Math.PI / 180));

                double[] modelMatrix = new double[16];
                gl.GetDouble(OpenGL.GL_MODELVIEW_MATRIX, modelMatrix);

                double[] projMatrix = new double[16];
                gl.GetDouble(OpenGL.GL_PROJECTION_MATRIX, projMatrix);

                int[] viewport = new int[4];
                gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);
                //  gl.Viewport(e.X, e.Y, openGLControl.Width, openGLControl.Height);

                //координаты по оси Y отсчитываются снизу вверх
                int _yw = openGLControl.Height - e.Y - 1;

                //первая точка будет в центре объема отсечения
                //winX = (float)x;
                //winY = (float)viewport[3] - (float)y - 1;

                double[] p1 = new double[3];
                //           gl.UnProject(e.X, _yw, -1, modelMatrix, projMatrix, viewport, ref p1[0], ref p1[1], ref p1[2]);
                p1 = gl.UnProject(e.X, _yw, -1);
                //       gl.UnProject(winX, winY, -1, modelMatrix, projMatrix, viewport, ref p1[0], ref p1[1], ref p1[2]);

                //         Console.WriteLine(p1[0] + "  " + p1[1] + "  " + p1[2]);
                //вторая - с отступом на 10 единиц от центра объема отсечения
                double[] p2 = new double[3];
                gl.UnProject(e.X, _yw, 10, modelMatrix, projMatrix, viewport, ref p2[0], ref p2[1], ref p2[2]);
                Console.WriteLine(p2[0] + "  " + p2[1] + "  " + p2[2]);
                ray_m = new Vertex((float)p1[0], (float)p1[1], (float)p1[2]);
                ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)p2[2]);
                //     ray_n.Normalize();
                Console.WriteLine((ray_n.X * secret) + "  " + (ray_n.Y * secret) + "  " + ray_n.Z);

                for (int i = 0; i < room.GetSize(); i++)
                {
                    //      ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2] - room.GetObj(i).Height));
                    if (room.GetObj(i).X < -((float)(p2[0] - p1[0])) && (room.GetObj(i).X + room.GetObj(i).Length) > -((float)(p2[0] - p1[0]) * secret))
                    {
                        if (room.GetObj(i).Y < -((float)(p2[1] - p1[1]) * secret) && (room.GetObj(i).Y + room.GetObj(i).Width) > -((float)(p2[1] - p1[1]) * secret))
                        {
                            ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                            otstup = room.GetObj(i).Height;
                            objMove = true;
                            indexOfObj = i;
                            return;
                            Console.WriteLine("Попали");
                        }
                        else
                        {
                            Console.WriteLine("Не попали");
                            otstup = 0;
                            ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не попали");
                        otstup = 0;
                        ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                    }

                    //      room.GetObj(i).Draw(gl);
                }
            }
            //   gl.Project(1, 0, 0, modelMatrix, projMatrix, viewport,  p3[0],  p3[1],  p3[2]);
            //        ray_m.Normalize();

            //    Console.WriteLine(x + "  " + y);
            
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            просмотрToolStripMenuItem.Checked = false;
            редактированиеToolStripMenuItem.Checked = true;
            centX = 0;
            centY = 0;
            editing = true;
            radius = room.length * 2 / Math.Tan(20);
            radius = 8;
            secret = 26;
            Console.WriteLine(radius);
            sigma = 90;
            fi = 90;
            openGLControl_Resized(sender, e);
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            просмотрToolStripMenuItem.Checked = true;
            редактированиеToolStripMenuItem.Checked = false;
            centX = 0;
            centY = 0;
            sigma = 30;
            fi = 45;
            editing = false;
            openGLControl_Resized(sender, e);
        }


        private void видСверхуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radius = room.length * 2 / Math.Tan(20);
            sigma = 90;
            fi = 90;
            openGLControl_Resized(sender, e);
        }

        private void видСбокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radius = room.length * 2 / Math.Tan(20);
            sigma = 0;
            fi = 0;
            openGLControl_Resized(sender, e);
        }

        private void видСпередиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radius = room.length * 2 / Math.Tan(20);
            sigma = 0;
            fi = 90;
            openGLControl_Resized(sender, e);
        }

        public void DrawPlane(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1f, 1f, 1f);
            for (int i = 0; i <= 16; i++)
            {
                gl.Vertex(-8 + i, 8, -1f);
                gl.Vertex(-8 + i, -8, -1f);
                gl.Vertex(8, -8 + i, -1f);
                gl.Vertex(-8, -8 + i, -1f);
            }
            gl.End();
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (objMove)
            {
                objMove = false;
            }
        }
    }
}
