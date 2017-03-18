using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;

using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ManagerBD mbd = new ManagerBD();
        public Form1()
        {
            InitializeComponent();

            diagr();
        }


        public void diagr()
        {
            Dictionary<int, int> dictSum = new Dictionary<int, int>();
            Dictionary<int, int> dictCount = new Dictionary<int, int>();
            for (int i=1;i<=12; i++)
            {
                dictSum.Add(i,0);
                dictCount.Add(i, 0);
            }

            mbd.Connection();
            DataTable dt = mbd.Statistic();

            for(int i=0; i<dt.Rows.Count;i++)
            {
                dictSum[Convert.ToInt32( dt.Rows[i][0])] = Convert.ToInt32(dt.Rows[i][1])/1000;
                dictCount[Convert.ToInt32(dt.Rows[i][0])] = Convert.ToInt32(dt.Rows[i][2]);
            }

            //dictCount[2] = 3;
            //dictSum[2] = 750;

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int maxX = 12;
            int maxY = 1000;
            int max = h - 25;

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            float cdx = (w - 90) / maxX;
            float cdy = (h - 50) / maxY;

            Pen p = new Pen(Brushes.Green, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, (int)(0 * cdx) + 40, (int)h - 25, (int)(0 * cdx) + 40, 0);
            gr.DrawLine(p, 0, (int)(max - 0 * cdy), (int)w - 50, (int)(max - 0 * cdy));

            for (float x = 0; x < maxX ; x++)
            {
                gr.DrawString((x+1).ToString(), new Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
            }

            double cy = 0.4;
            for (float y = 1; y <= maxY + 1; y+=100)
            {
                gr.DrawString((y-1).ToString(), new Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
            }
            /*
            int[] mas = new int[12] ;
            mas[0] = 150;
            for (int i = 1; i<mas.Length-1; i++) {
                mas[i] = 250;
            }
            mas[11] = 750;
            
            for (int i = 0; i < mas.Length; i++)
            {
                gr.FillRectangle(Brushes.Red, 40*i + 40, (int)(maxY*0.43) - (int)(mas[i] * 0.4), 10, (int)(mas[i]*0.4));
            }
            */
            for (int i = 1; i <= dictSum.Count; i++)
            {
                gr.FillRectangle(Brushes.Red, 40 * (i-1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4), 10, (int)(dictSum[i] * 0.4));
                gr.DrawString(Convert.ToString(dictCount[i]), new Font("Arial", 10), Brushes.Red,
                    40 * (i - 1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4) -20);
            }


            pictureBox1.Image = bmp;

            w = pictureBox2.Width;
            h = pictureBox2.Height;
            Bitmap bmpD = new Bitmap(w, h);
            Graphics grD = Graphics.FromImage(bmpD);

            grD.DrawString("Месяц", new Font("Arial", 10), Brushes.Black,250,5);

            pictureBox2.Image = bmpD;

            w = pictureBox3.Width;
            h = pictureBox3.Height;
            Bitmap bmpL = new Bitmap(w, h);
            Graphics grL = Graphics.FromImage(bmpL);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            
            grL.DrawString("Выручка (тыс)", new Font("Arial", 10), Brushes.Black,0, 75);
            bmpL.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox3.Image = bmpL;

            w = pictureBox4.Width;
            h = pictureBox4.Height;
            Bitmap bmpLeg = new Bitmap(w, h);
            Graphics grLeg = Graphics.FromImage(bmpLeg);
            grLeg.DrawRectangle(new Pen(Brushes.Black),0,0,w-1,h-1);

            grLeg.FillRectangle(Brushes.Red, 10, 10, 10, 10);
            grLeg.DrawString("Выручка (тыс)", new Font("Arial", 10), Brushes.Black, 35, 7);
            grLeg.DrawString("1", new Font("Arial", 10), Brushes.Red, 10, 30);
            grLeg.DrawString("Количество заказов", new Font("Arial", 10), Brushes.Black, 35, 30);


            pictureBox4.Image = bmpLeg;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            mbd.Connection();
            //mbd.controlquery("ALTER TABLE zakaz add summa Integer;");
            //mbd.controlquery("update zakaz set summa = 150000 where id_zakaz =1;");

            //DataTable dt = mbd.selectionquery("Select * from zakaz;");

            DataTable dt = mbd.Statistic();

            //var n = dt.Rows[0][0]; // получаю ячейку
            //textBox1.Text = n.ToString();


            dataGridView1.DataSource = dt;
            /*
            //отчет
            Reports report = new Reports();
            report.blank();
            DialogResult result = MessageBox.Show("Отчет сформирован","Сообщение",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            if (result == DialogResult.Yes) //Если нажал Да
            {
                //отрытие документа программой по умолчанию
                Process.Start("Document.pdf");
            }

            
            */

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отправка на почту
            Mail mail = new Mail();
            mail.SendMail();
            MessageBox.Show("Письмо отправлено","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
