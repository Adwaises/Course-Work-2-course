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
using LibDataForBD;
using LibObjFurnit;
using LibraryManagerBD;
using System.IO;

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
        ParserObj p = new ParserObj();
        private double mouseX = 0;// важно
        private double mouseY = 0;// важно
        private double sigma = 0;// важно
        private double fi = 0;// важно
        private bool editing = false;// важно
        private bool mouseDown = false;// важно
        private bool objMove = false;// важно
        bool key = false;
        List<Model> list = new List<Model>();
        Vertex ray_m = new Vertex(0, 0, 0);//временно
        Vertex ray_n = new Vertex(0, 0, 0);// важно


        /*-------------Взаимодействие с БД (тем классом)------------------*/
        int index = 0;
        /*----------------------------------------------------------------*/

        public Form1()
        {
            InitializeComponent();
            openGLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(openGLControl_MouseWheel);
            room = new Room(8, 8, 5);

            /*-------------Взаимодействие с БД (тем классом)------------------*/
            DataForBD.Length = Convert.ToInt32(room.length/2*100);
            DataForBD.Width = Convert.ToInt32(room.width/2 * 100);
            DataForBD.Height = Convert.ToInt32(room.height * 100);
            /*----------------------------------------------------------------*/
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

            //float[] g_LightPosition = { 0, 0, 1, 3 };
            //gl.Enable(OpenGL.GL_LIGHTING);
            //gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, g_LightPosition);
            //gl.Enable(OpenGL.GL_LIGHT0);

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
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Render(gl);

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
            if (key)
                p.on_paint(gl);
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
       //     gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SharpGLXmlFormat s = new SharpGLXmlFormat();
            //SceneControl sc = new SceneControl();
            //s.SaveData(sc.Scene, "save.xml");
            // ParserObj p = new ParserObj();
            p.LoadMatrix();
            key = true;
        //    room.AddObj((new Cupboard(0, 0, -1, 1, 1, 2)));

            /*-------------Взаимодействие с БД (тем классом)------------------*/

            DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, 61, 0, 0));

            /*----------------------------------------------------------------*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Clear();
         //   p.on_ob();
            key = true;
            DataForBD.ListZakazMebTeh.Clear();
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

                            for (int k = 0; k < DataForBD.ListZakazMebTeh.Count; k++)
                            {
                                if (DataForBD.ListZakazMebTeh[k].CoordX == room.GetObj(indexOfObj).X && DataForBD.ListZakazMebTeh[k].CoordY == room.GetObj(indexOfObj).Y)
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

                DataForBD.ListZakazMebTeh[index].CoordX = room.GetObj(indexOfObj).X;
                DataForBD.ListZakazMebTeh[index].CoordY = room.GetObj(indexOfObj).Y;
                foreach (var n in DataForBD.ListZakazMebTeh)
                {
                    Console.WriteLine(n.IdFurnit +" "+n.CoordX + " " + n.CoordY + " ");
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

            DataForBD.IdZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.IdZakaz)
                {
                    DataForBD.IdZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.IdZakaz++;

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

        int nFurnituraCounter = 0;
        int nPlitkaCounter = 0;
        int nOboiCounter = 0;
        List<string> furnituraPath = new List<string>();
        List<string> plitkaPath = new List<string>();
        List<string> oboiPath = new List<string>();
        List<string> modelsPath = new List<string>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            //тут будет заполнение комбобоксов
            //cbOboi.Items.Add("Fiji - 600");
            //cbOboi.Items.Add("Vernissage - 700");

            //cbPlitka.Items.Add("Florence - 300");
            //cbPlitka.Items.Add("Magma - 500");

            //cbFurnit.Items.Add("Стол European - 1500");
            //cbFurnit.Items.Add("Стол Premiere - 2000");

            //cbFurnit.Items.Add("Стул Victoria - 700");
            //cbFurnit.Items.Add("Стул Bravo - 1700");
            //cbFurnit.Items.Add("Стул Iris - 1000");

            //cbFurnit.Items.Add("Шкаф Brusali - 3000");
            //cbFurnit.Items.Add("Шкаф Wyspaa - 2000");

            //cbFurnit.Items.Add("Плита Mora - 6000");

            //cbFurnit.Items.Add("Холодильник LG - 11000");
            //cbFurnit.Items.Add("Холодильник BEKO - 13000");

            //oboiPath.Add("pictures\\oboi1.png");
            //oboiPath.Add("pictures\\oboi2.png");
            //oboiPath.Add("pictures\\oboi3.png");

            DirectoryInfo di = new DirectoryInfo(@"textures//oboi");
            FileInfo[] fi = di.GetFiles("*.png"); // Фильтруем нужный формат

            foreach (FileInfo fc in fi)
            {
                oboiPath.Add("textures//oboi//" + fc.Name); // Добавляем все что удалось найти из @"D:\путь"
            }


            //plitkaPath.Add("pictures\\plitka1.png");
            //plitkaPath.Add("pictures\\plitka2.png");
            //plitkaPath.Add("pictures\\plitka3.png");
            //plitkaPath.Add("pictures\\plitka4.png");

             di = new DirectoryInfo(@"textures//plitka");
             fi = di.GetFiles("*.png"); // Фильтруем нужный формат
            
            foreach (FileInfo fc in fi)
            {
                plitkaPath.Add("textures//plitka//" + fc.Name); // Добавляем все что удалось найти из @"D:\путь"
            }



            //furnituraPath.Add("pictures\\table1.png");
            //furnituraPath.Add("pictures\\table2.png");
            //furnituraPath.Add("pictures\\stol1.png");
            //furnituraPath.Add("pictures\\stol2.png");
            //furnituraPath.Add("pictures\\stol3.png");
            //furnituraPath.Add("pictures\\shkaf1.png");
            //furnituraPath.Add("pictures\\shkaf2.png");
            //furnituraPath.Add("pictures\\plita1.png");
            //furnituraPath.Add("pictures\\isebox1.png");
            //furnituraPath.Add("pictures\\isebox2.png");

            di = new DirectoryInfo(@"textures//furnitura");
            fi = di.GetFiles("*.png"); // Фильтруем нужный формат

            foreach (FileInfo fc in fi)
            {
                furnituraPath.Add("textures//furnitura//" + fc.Name); // Добавляем все что удалось найти из @"D:\путь"
            }


            pbFurnit.Load(furnituraPath[nFurnituraCounter]);
           // nFurnituraCounter++;
            pbOboi.Load(oboiPath[nOboiCounter]);
           // nOboiCounter++;
            pbPlitka.Load(plitkaPath[nPlitkaCounter]);
            //nPlitkaCounter++;

            //path.Add("res\\Obj2.bmp");
            //path.Add("res\\Obj3.bmp");
            //path.Add("res\\Obj4.bmp");
            //path.Add("res\\Obj5.bmp");
            //path.Add("res\\Obj6.bmp");

            di = new DirectoryInfo(@"textures//models");
            fi = di.GetFiles("*.obj"); // Фильтруем нужный формат

            foreach (FileInfo fc in fi)
            {
                modelsPath.Add("textures//models//" + fc.Name); // Добавляем все что удалось найти из @"D:\путь"
            }

            //присвоение нового id
            mbd.Connection();
            DataTable dt1 = mbd.selectionquery("select * from zakaz;");
            DataForBD.IdZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.IdCustomer)
                {
                    DataForBD.IdZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.IdZakaz++;

            label1.Text ="Заказ №"+ DataForBD.IdZakaz.ToString();
        }

      

        private void логическиеВыводыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogic fl = new FormLogic();
            fl.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Заказ №" + DataForBD.IdZakaz.ToString();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Model m = new Model();
                m.LoadModel(openFileDialog1.FileName);
                list.Add(m);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nFurnituraCounter++;
            if (nFurnituraCounter > furnituraPath.Count-1)
            {
                nFurnituraCounter = 0;
            } else if (nFurnituraCounter < 0)
            {
                nFurnituraCounter = furnituraPath.Count - 1;
            }
            Console.WriteLine(nFurnituraCounter);

            pbFurnit.Load(furnituraPath[nFurnituraCounter]);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nFurnituraCounter--;
            if (nFurnituraCounter > furnituraPath.Count - 1)
            {
                nFurnituraCounter = 0;
            }
            else if (nFurnituraCounter < 0)
            {
                nFurnituraCounter = furnituraPath.Count - 1;
            }
            Console.WriteLine(nFurnituraCounter);
            pbFurnit.Load(furnituraPath[nFurnituraCounter]);
           
        }

        private void bOboiR_Click(object sender, EventArgs e)
        {
            nOboiCounter++;
            if (nOboiCounter > oboiPath.Count - 1)
            {
                nOboiCounter = 0;
            } else if (nOboiCounter < 0)
            {
                nOboiCounter = oboiPath.Count - 1;
            }
            pbOboi.Load(oboiPath[nOboiCounter]);
           
        }

        private void bOboiL_Click(object sender, EventArgs e)
        {
            nOboiCounter--;
            if (nOboiCounter > oboiPath.Count - 1)
            {
                nOboiCounter = 0;
            }
            else if (nOboiCounter < 0)
            {
                nOboiCounter = oboiPath.Count - 1;
            }
            pbOboi.Load(oboiPath[nOboiCounter]);
            
        }

        private void bPlitkaR_Click(object sender, EventArgs e)
        {
            nPlitkaCounter++;
            if (nPlitkaCounter > plitkaPath.Count - 1)
            {
                nPlitkaCounter = 0;
            } else if (nPlitkaCounter < 0)
            {
                nPlitkaCounter = plitkaPath.Count - 1;
            }
            pbPlitka.Load(plitkaPath[nPlitkaCounter]);
           
        }

        private void bPlitkaL_Click(object sender, EventArgs e)
        {
            nPlitkaCounter--;
            if (nPlitkaCounter > plitkaPath.Count - 1)
            {
                nPlitkaCounter = 0;
            }
            else if (nPlitkaCounter < 0)
            {
                nPlitkaCounter = plitkaPath.Count - 1;
            }
            pbPlitka.Load(plitkaPath[nPlitkaCounter]);
            
        }

        private void bFurnitAdd_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Model m = new Model();
            //    m.LoadModel(openFileDialog1.FileName);
            //    list.Add(m);
            //}

            if (nFurnituraCounter > furnituraPath.Count - 1)
            {
                nFurnituraCounter = 0;
            }
            else if (nFurnituraCounter < 0)
            {
                nFurnituraCounter = furnituraPath.Count - 1;
            }

            Model m = new Model();
            m.LoadModel(modelsPath[nFurnituraCounter]);
            list.Add(m);

            string num = ""+ modelsPath[nFurnituraCounter][modelsPath[nFurnituraCounter].Length - 6];
            /*
            if (modelsPath[nFurnituraCounter].Contains("isebox"))
            {
                num = "6";
            } else if(modelsPath[nFurnituraCounter].Contains("plita"))
            {
                //DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, 41, 0, 0));
                num = "4";
            }
            else if (modelsPath[nFurnituraCounter].Contains("table"))
            {
                //DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, 11, 0, 0));
                num = "1";
            }
            else if (modelsPath[nFurnituraCounter].Contains("stol"))
            {
                //DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, 21, 0, 0));
                num = "2";
            }
            else if (modelsPath[nFurnituraCounter].Contains("shkaf"))
            {
                //DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, 31, 0, 0));
                num = "3";
            }
            */
            num += modelsPath[nFurnituraCounter][modelsPath[nFurnituraCounter].Length - 5];
            DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, Convert.ToInt32(num), 0, 0));

            //уберу потом
            foreach (var n in DataForBD.ListZakazMebTeh)
            {
                Console.WriteLine(n.IdFurnit + " " + n.CoordX + " " + n.CoordY + " ");
            }
            //
        }
    }
}
