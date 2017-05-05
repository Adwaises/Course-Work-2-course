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
        ManagerBD mbd = new ManagerBD();

        private double rotation = 0; //временно
        private double centX = 0; // важно
        private double centY = 0;
        private double centZ = 0;
        private int indexOfObj; // важно
        private Room room;// важно
        private double radius = 6;// важно
        private double CamX = 0;//временно
        private double CamY = 0;
        private double CamZ = 0;
        private double secret = 20;// важно
        private double perspective = 1f;

        private double mouseX = 0;// важно
        private double mouseY = 0;// важно
        private double sigma = 0;// важно
        private double fi = 0;// важно
        private bool editing = false;// важно
        private bool mouseDown = false;// важно
        private bool objMove = false;// важно
        Vertex ray_m = new Vertex(0, 0, 0);//временно
        Vertex ray_n = new Vertex(0, 0, 0);// важно


        /*-------------Взаимодействие с БД (тем классом)------------------*/
        int index = 0;
        /*----------------------------------------------------------------*/

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

            gl.ClearColor(0.4f, 0.4f, 0.4f, 0); // задний фон
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            var gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);//очистка сцены

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
            float zsd;//временно
            if (editing)//временно
            {
                zsd = (float)(ray_n.Z - radius);//временно
            }
            else
            {
                zsd = -1;//временно
            }
            gl.Begin(OpenGL.GL_LINES);//временно
            gl.Color(0f, 1f, 0f);//временно
            gl.Vertex(CamX, CamY, CamZ);//временно
            gl.Vertex(-(ray_n.X * secret), -(ray_n.Y * secret), zsd);//временно

            //    gl.Vertex(ray_m.X, ray_m.Y, ray_m.Z);
            gl.End();//временно
            DrawPlane(gl); // рисуем пол
            room.DrawRoom(gl); // рисуем комнату
            gl.Flush();// говорят, что эта штука для оптимизации
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

            /*-------------Взаимодействие с БД (тем классом)------------------*/

            DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idCustomer, 11, 0, 0));

            /*----------------------------------------------------------------*/
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
                room.GetObj(indexOfObj).Y = room.GetObj(indexOfObj).Y + (mouseY - e.Y) / 70;
                room.GetObj(indexOfObj).X = room.GetObj(indexOfObj).X + (e.X - mouseX) / 70;
                
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
                //     double NMouseX, NMouseY;
                //     double x, y, z;
                //     NMouseX = -1.0 + 2.0 * e.X / openGLControl.Width;                                                    //временно
                //    NMouseY = 1.0 - 2.0 * e.Y / openGLControl.Height;
                //     Console.WriteLine(NMouseX + "  " + NMouseY);
                //is FOV in radians 
                //    y = (NMouseY * Math.Tan(40 / 2.0));
                //      x = ((NMouseX / (openGLControl.Width / openGLControl.Height)) * Math.Tan(40 / 2.0));
                CamX = ((radius - 0.5) * Math.Cos(sigma * Math.PI / 180) * Math.Cos(fi * Math.PI / 180));                   //временно, луча отрисовки скоро не будет
                CamY = ((radius - 0.5) * Math.Cos(sigma * Math.PI / 180) * Math.Sin(fi * Math.PI / 180));                   //временно
                CamZ = ((radius - 0.5) * Math.Sin(sigma * Math.PI / 180));                                                  //временно
                ///////////////////////////////////////// лютая хрень
                double[] modelMatrix = new double[16];
                gl.GetDouble(OpenGL.GL_MODELVIEW_MATRIX, modelMatrix);
                double[] projMatrix = new double[16];
                gl.GetDouble(OpenGL.GL_PROJECTION_MATRIX, projMatrix);
                int[] viewport = new int[4];
                gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);
                int _yw = openGLControl.Height - e.Y - 1;
                double[] p1 = new double[3];
                gl.UnProject(e.X, _yw, -0.8, modelMatrix, projMatrix, viewport, ref p1[0], ref p1[1], ref p1[2]);
                double[] p2 = new double[3];
                gl.UnProject(e.X, _yw, 10, modelMatrix, projMatrix, viewport, ref p2[0], ref p2[1], ref p2[2]);
                ray_m = new Vertex((float)p1[0], (float)p1[1], (float)p1[2]);
                ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)p2[2]);
                Console.WriteLine("луч");                                                                                   //временно
                Console.WriteLine(-(ray_n.X * secret) + "  " + (-ray_n.Y * secret) + "  " + ray_n.Z);                       //временно
                for (int i = 0; i < room.GetSize(); i++)
                {
                    Console.WriteLine("объект");                                                                            //временно
                    Console.WriteLine(room.GetObj(i).X + "  " + room.GetObj(i).Y + "  " + ray_n.Z);                         //временно
                    if (room.GetObj(i).X < -((float)(p2[0] - p1[0]) * secret) && (room.GetObj(i).X + room.GetObj(i).Length) > -((float)(p2[0] - p1[0]) * secret))
                    {
                        if (room.GetObj(i).Y < -((float)(p2[1] - p1[1]) * secret) && (room.GetObj(i).Y + room.GetObj(i).Width) > -((float)(p2[1] - p1[1]) * secret))
                        {
                            ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                            //    otstup = room.GetObj(i).Height;
                            if(e.Clicks == 2)
                                Cursor.Hide();
                            objMove = true;
                            indexOfObj = i;

                            /*-------------Взаимодействие с БД (тем классом)------------------*/

                            for (int k = 0; k < DataForBD.listZakazMebTeh.Count; k++)
                            {
                                if (DataForBD.listZakazMebTeh[k].CoordX == room.GetObj(indexOfObj).X && DataForBD.listZakazMebTeh[k].CoordY == room.GetObj(indexOfObj).Y)
                                {
                                    Console.WriteLine("Есть конакт"); // потом уберу
                                    index = k;
                                }
                            }

                            /*----------------------------------------------------------------*/

                            return;
                            Console.WriteLine("Попали");
                        }
                        else
                        {
                            Console.WriteLine("Не попали");
                            //        otstup = 0;
                            ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не попали");
                        //       otstup = 0;
                        ray_n = new Vertex((float)(p2[0] - p1[0]), (float)(p2[1] - p1[1]), (float)(p2[2]));
                    }
                }
                ///////////////////////////////////////// конец лютой хрени
            }
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
            fi = 270;
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
                Cursor.Show();
                /*-------------Взаимодействие с БД (тем классом)------------------*/

                DataForBD.listZakazMebTeh[index].CoordX = room.GetObj(indexOfObj).X;
                DataForBD.listZakazMebTeh[index].CoordY = room.GetObj(indexOfObj).Y;
                foreach (var n in DataForBD.listZakazMebTeh)
                {
                    Console.WriteLine(n.CoordX + " " + n.CoordY + "");
                }


                /*----------------------------------------------------------------*/
            }
        }

        private void графическиеОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDiagram diag = new FDiagram();
            diag.ShowDialog();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPDF pdf = new FormPDF();
            pdf.ShowDialog();
        }

        private void отправитьНаПочтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FToMail tm = new FToMail();
            tm.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // присвоение нового id
            mbd.Connection();
            DataTable dt1 = mbd.selectionquery("select * from zakaz;");

            DataForBD.idZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idZakaz)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;
        }

        private void оформитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSave fs = new FormSave();
            fs.ShowDialog();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad fl = new FormLoad();
            fl.ShowDialog();
        }

        private void просмотрыременноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBD fBD = new FormBD();
            fBD.ShowDialog();
        }

        private void анализПрибылиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProfit pr = new FProfit();
            pr.ShowDialog();
        }

        private void самаяПокупаемаяФурнитураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSemantic sem = new FSemantic();
            sem.ShowDialog();
        }

        private void структураТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFrame ff = new FormFrame();
            ff.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void логическиеВыводыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogic fl = new FormLogic();
            fl.ShowDialog();
        }
    }
}
