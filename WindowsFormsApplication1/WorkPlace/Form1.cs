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
        private int indexOfObj; // важно
        private Room room;// важно
        private Camera cam;
        private ObjectMove objCtrl;
        private bool changeTex = false;
        ParserObj p = new ParserObj();
        private double mouseX = 0;// важно
        private double mouseY = 0;// важно
        private bool editing = false;// важно
        private bool mouseDown = false;// важно
        private bool objMove = false;// важно

        public Form1()
        {
            cam = new Camera();
            cam.Radius = 6;
            cam.Sigma = 0;
            cam.Fi = 0;
            cam.Secret = 20;
            room = new Room(8, 4, 2.5);
            InitializeComponent();
            openGLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(openGLControl_MouseWheel);

            DataForBD.Length = Convert.ToInt32(room.length * 100);
            DataForBD.Width = Convert.ToInt32(room.width * 100);
            DataForBD.Height = Convert.ToInt32(room.height * 100);

            просмотрToolStripMenuItem.Checked = true;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            room.GenTexture(gl);
            room.UseTextureToFloor(gl);
            room.UseTextureToWall(gl);
            gl.ClearColor(0.4f, 0.4f, 0.4f, 0); // задний фон
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            var gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //gl.Begin(OpenGL.GL_LINES);
            //gl.Color(1f, 0f, 0f); // X Green
            //gl.Vertex(0f, 0f, 0f);
            //gl.Vertex(3f, 0f, 0f);
            //gl.Color(0f, 1f, 0f); // Y Red
            //gl.Vertex(0f, 0f, 0f);
            //gl.Vertex(0f, 3f, 0f);
            //gl.Color(0f, 0f, 1f); // Z Blue
            //gl.Vertex(0f, 0f, 0f);
            //gl.Vertex(0f, 0f, 3f);
            //gl.End();
            if (changeTex)
            {
                room.GenTexture(gl);
                room.UseTextureToFloor(gl);
                room.UseTextureToWall(gl);
                changeTex = false;
            }
            room.Draw(gl);
            for (int i = 0; i < room.GetSize(); i++)
            {
                room.GetObj(i).Render(gl);
            }
            DrawPlane(gl);
            gl.Finish();
            gl.Flush();// говорят, что эта штука для оптимизации
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(50, (double)openGLControl.Width / (double)openGLControl.Height, 0.5, 200.0);
            gl.LookAt(cam.CamX, cam.CamY, cam.CamZ, 0, 0, 0, 0, 0, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openGLControl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!objMove)
            {
                if (e.Delta > 0)
                {
                    cam.RadDown();
                    cam.SecretDown();
                    openGLControl_Resized(sender, e);
                }
                else
                {
                    cam.RadUP();
                    cam.SecretUP();
                    openGLControl_Resized(sender, e);
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    room.GetObj(indexOfObj).RotationUp();
                }
                else
                {
                    room.GetObj(indexOfObj).RotationDown();
                }
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
                cam.SigmaDelta(e.Y - mouseY);
                cam.FiDelta(mouseX - e.X);
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
            cam.Sigma = 30;
            cam.Fi = 45;
            openGLControl_Resized(sender, e);
        }

        private void openGLControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (editing)
            {
                OpenGL gl = openGLControl.OpenGL;
                objCtrl = new ObjectMove(openGLControl.Height, e.X, e.Y, cam.Secret);
                if (objCtrl.CheckField(gl, room))
                {
                    objMove = true;
                    if (e.Clicks == 2)
                    {
                        Cursor.Hide();
                    }
                    indexOfObj = objCtrl.IndexOfObj;
                }
            }
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            просмотрToolStripMenuItem.Checked = false;
            редактированиеToolStripMenuItem.Checked = true;
            editing = true;
            cam.Radius = 8;
            cam.Secret = 26;
            cam.Sigma = 90;
            cam.Fi = 270;
            openGLControl.Cursor = Cursors.Hand;
            openGLControl_Resized(sender, e);
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            просмотрToolStripMenuItem.Checked = true;
            редактированиеToolStripMenuItem.Checked = false;
            cam.Sigma = 30;
            cam.Fi = 45;
            editing = false;
            openGLControl.Cursor = Cursors.SizeAll;
            openGLControl_Resized(sender, e);

        }

        private void видСверхуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam.Radius = room.length * 2 / Math.Tan(20);
            cam.Sigma = 90;
            cam.Fi = 90;
            openGLControl_Resized(sender, e);
        }

        private void видСбокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam.Radius = room.length * 2 / Math.Tan(20);
            cam.Sigma = 0;
            cam.Fi = 0;
            openGLControl_Resized(sender, e);
        }

        private void видСпередиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam.Radius = room.length * 2 / Math.Tan(20);
            cam.Sigma = 0;
            cam.Fi = 90;
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
            room.ClearRoom();
            DataForBD.ListZakazMebTeh.Clear();
        }

        private void оформитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSave fs = new FormSave();
            fs.ShowDialog();
        }

        private void просмотрыременноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFurnit fBD = new FormAddFurnit();
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

        List<string> plitkaBPath = new List<string>();
        List<string> oboiBPath = new List<string>();

        List<string> modelsPath = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(@"textures//oboiPlitka");
            FileInfo[] fi = di.GetFiles("oboi*.png");
            foreach (FileInfo fc in fi)
            {
                oboiPath.Add("textures/oboiPlitka/" + fc.Name);
            }

            di = new DirectoryInfo(@"textures//oboiPlitka//");
            fi = di.GetFiles("plitka*.png");
            foreach (FileInfo fc in fi)
            {
                plitkaPath.Add("textures//oboiPlitka//" + fc.Name);
            }

            di = new DirectoryInfo(@"textures//oboiPlitkaBig//");
            fi = di.GetFiles("oboi*.bmp");
            foreach (FileInfo fc in fi)
            {
                oboiBPath.Add("textures/oboiPlitkaBig/" + fc.Name);
            }

            di = new DirectoryInfo(@"textures//oboiPlitkaBig//");
            fi = di.GetFiles("plitka*.bmp");
            foreach (FileInfo fc in fi)
            {
                plitkaBPath.Add("textures//oboiPlitkaBig//" + fc.Name);
            }

            di = new DirectoryInfo(@"textures//furnitura");
            fi = di.GetFiles("*.png");
            foreach (FileInfo fc in fi)
            {
                furnituraPath.Add("textures//furnitura//" + fc.Name);
            }

            pbFurnit.Load(furnituraPath[nFurnituraCounter]);
            pbOboi.Load(oboiPath[nOboiCounter]);
            pbPlitka.Load(plitkaPath[nPlitkaCounter]);

            di = new DirectoryInfo(@"textures//models");
            fi = di.GetFiles("*.obj");
            foreach (FileInfo fc in fi)
            {
                modelsPath.Add("textures//models//" + fc.Name);
            }

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

            try
            {
                room.ChangePathToWall(oboiBPath[nOboiCounter]);
                changeTex = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл повреждён\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string num = "" + oboiBPath[nOboiCounter][oboiBPath[nOboiCounter].Length - 6];
            num += oboiBPath[nOboiCounter][oboiBPath[nOboiCounter].Length - 5];
            DataForBD.IdOboi = Convert.ToInt32(num);

            try
            {
                room.ChangePathToFloor(plitkaBPath[nPlitkaCounter]);
                changeTex = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл повреждён\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            num = "" + plitkaBPath[nPlitkaCounter][plitkaBPath[nPlitkaCounter].Length - 6];
            num += plitkaBPath[nPlitkaCounter][plitkaBPath[nPlitkaCounter].Length - 5];
            DataForBD.IdPlitka = Convert.ToInt32(num);
            label1.Text = "Заказ №" + DataForBD.IdZakaz.ToString();
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

        private void button7_Click(object sender, EventArgs e)
        {
            nFurnituraCounter++;
            if (nFurnituraCounter > furnituraPath.Count - 1)
            {
                nFurnituraCounter = 0;
            }
            else if (nFurnituraCounter < 0)
            {
                nFurnituraCounter = furnituraPath.Count - 1;
            }

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
            pbFurnit.Load(furnituraPath[nFurnituraCounter]);
        }

        private void bOboiR_Click(object sender, EventArgs e)
        {
            nOboiCounter++;
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
            }
            else if (nPlitkaCounter < 0)
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
            if (nFurnituraCounter > furnituraPath.Count - 1)
            {
                nFurnituraCounter = 0;
            }
            else if (nFurnituraCounter < 0)
            {
                nFurnituraCounter = furnituraPath.Count - 1;
            }

            try
            {
                InterfaceObject obj = null;
                if (modelsPath[nFurnituraCounter].Contains("fridge"))
                {
                    obj = new Fridge(0, 0, 0, 1, 1, 2);
                }
                else if (modelsPath[nFurnituraCounter].Contains("stove"))
                {
                    obj = new Stove(-1, -1, 0, 0.5, 0.7, 1.5);
                }
                else if (modelsPath[nFurnituraCounter].Contains("table"))
                {
                    obj = new Table(0, 0, 0, 2, 2, 0);
                }
                else if (modelsPath[nFurnituraCounter].Contains("chair"))
                {
                    obj = new Chair(0, 0, 0, 0.5, 0.5, 0);
                }
                else if (modelsPath[nFurnituraCounter].Contains("cupboard"))
                {
                    obj = new Cupboard(0, 0, 0, 1.5, 0.5, 0);
                }

                if (obj != null)
                    obj.LoadModel(modelsPath[nFurnituraCounter]);
                room.AddObj(obj);

                string num = "" + modelsPath[nFurnituraCounter][modelsPath[nFurnituraCounter].Length - 6];
                num += modelsPath[nFurnituraCounter][modelsPath[nFurnituraCounter].Length - 5];
                DataForBD.ListZakazMebTeh.Add(new ObjFurnit(DataForBD.IdZakaz, Convert.ToInt32(num), 0, 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл повреждён\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьОбоиплиткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddStroyMat fa = new FormAddStroyMat();
            fa.ShowDialog();

        }

        private void bOboiAdd_Click(object sender, EventArgs e)
        {
            if (nOboiCounter > oboiPath.Count - 1)
            {
                nOboiCounter = 0;
            }
            else if (nOboiCounter < 0)
            {
                nOboiCounter = oboiPath.Count - 1;
            }

            try
            {
                room.ChangePathToWall(oboiBPath[nOboiCounter]);
                changeTex = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл повреждён\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string num = "" + oboiBPath[nOboiCounter][oboiBPath[nOboiCounter].Length - 6];
            num += oboiBPath[nOboiCounter][oboiBPath[nOboiCounter].Length - 5];
            DataForBD.IdOboi = Convert.ToInt32(num);
        }

        private void openGLControl_Load(object sender, EventArgs e)
        {

        }

        private void bPlitkaAdd_Click(object sender, EventArgs e)
        {
            if (nPlitkaCounter > plitkaPath.Count - 1)
            {
                nPlitkaCounter = 0;
            }
            else if (nPlitkaCounter < 0)
            {
                nPlitkaCounter = plitkaPath.Count - 1;
            }

            try
            {
                room.ChangePathToFloor(plitkaBPath[nPlitkaCounter]);
                changeTex = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл повреждён\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string num = "" + plitkaBPath[nPlitkaCounter][plitkaBPath[nPlitkaCounter].Length - 6];
            num += plitkaBPath[nPlitkaCounter][plitkaBPath[nPlitkaCounter].Length - 5];
            DataForBD.IdPlitka = Convert.ToInt32(num);
        }
    }
}
