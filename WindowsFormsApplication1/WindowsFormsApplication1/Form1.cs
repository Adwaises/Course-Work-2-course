using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;

using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ManagerBD mbd = new ManagerBD();
        public Form1()
        {
            InitializeComponent();

            
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
            //dictCount[11] = 3; dictCount[12] = 8; dictCount[5] = 2;


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

            if (checkBox1.Checked) {
                // сетка
                for (float x = 0; x < maxX; x++)
                {
                    gr.DrawString((x + 1).ToString(), new Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                    gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
                }

                double cy = 0.4;
                for (float y = 1; y <= maxY + 1; y += 100)
                {
                    gr.DrawString((y - 1).ToString(), new Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                    gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
                }

                //гист
                for (int i = 1; i <= dictSum.Count; i++)
                {
                    gr.FillRectangle(Brushes.Red, 40 * (i - 1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4), 10, (int)(dictSum[i] * 0.4));
                    //gr.DrawString(Convert.ToString(dictCount[i]), new Font("Arial", 10), Brushes.Red,
                    //40 * (i - 1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4) -20);
                }

                
            } else if (checkBox2.Checked)
            {
                //сетка
                for (float x = 0; x < maxX; x++)
                {
                    gr.DrawString((x + 1).ToString(), new Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                    gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
                }

                double cy = 0.4;
                for (float y = 1; y <= maxY + 1; y += 100)
                {
                    gr.DrawString(((y - 1)/100).ToString(), new Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                    gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
                }

                for (int i = 1; i <= dictCount.Count; i++)
                {
                    gr.FillRectangle(Brushes.Red, 40 * (i - 1) + 40, (int)(maxY * 0.43) - dictCount[i] * 40, 10, (int)(dictCount[i] * 40));
                    //gr.DrawString(Convert.ToString(dictCount[i]), new Font("Arial", 10), Brushes.Red,
                    //40 * (i - 1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4) -20);
                }

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
            if (checkBox1.Checked)
            {
                grL.DrawString("Выручка (тыс)", new Font("Arial", 10), Brushes.Black, 50, 120);
            }else if (checkBox2.Checked)
            {
                grL.DrawString("Количество заказов", new Font("Arial", 10), Brushes.Black, 30, 120);
            }
            bmpL.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox3.Image = bmpL;

            w = pictureBox4.Width;
            h = pictureBox4.Height;
            Bitmap bmpLeg = new Bitmap(w, h);
            Graphics grLeg = Graphics.FromImage(bmpLeg);
            grLeg.DrawRectangle(new Pen(Brushes.Black),0,0,w-1,h-1);

            grLeg.FillRectangle(Brushes.Red, 10, 23, 10, 10);
            if (checkBox1.Checked)
            {
                grLeg.DrawString("Выручка (тыс)", new Font("Arial", 10), Brushes.Black, 35, 20);
            } else if (checkBox2.Checked)
            {
                grLeg.DrawString("Количество заказов", new Font("Arial", 10), Brushes.Black, 35, 20);
            }
            //grLeg.DrawString("1", new Font("Arial", 10), Brushes.Red, 10, 30);
            //grLeg.DrawString("Количество заказов", new Font("Arial", 10), Brushes.Black, 35, 30);


            pictureBox4.Image = bmpLeg;

            //эксель
            
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                for(int i = 1; i<=dictSum.Count; i++)
                {
                    ObjWorkSheet.Cells[i, 1] = Convert.ToString(dictSum[i]);
                    ObjWorkSheet.Cells[i, 2] = Convert.ToString(dictCount[i]);
                }
                //ObjWorkSheet.Cells[3, 1] = "51";
                //ObjExcel.Application.DisplayAlerts = true;
                ObjExcel.DisplayAlerts = false;
                ObjWorkBook.SaveAs("book.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
               
                ObjExcel.Quit();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка1 \n" + exc.Message);
            }


            Excel.Application excelapp = new Excel.Application();
            try
            {

               // if (checkBox1.Checked){
                    ExcelDiagr1();
                //}else if(checkBox2.Checked)
                //{
                    ExcelDiagr2();
                //}


                MessageBox.Show("OK");


            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка2 \n" + exc.Message);
                excelapp.Quit();
            }
    
        }

        public void ExcelDiagr2()
        {
            Excel.Application excelapp = new Excel.Application();
            try
            {


                // excelapp.Visible = true;
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelapp.Workbooks.Open("book.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;

                //excelappworkbook = excelappworkbooks[2];
                //excelappworkbook.Activate();
                //excelsheets = excelapp.ActiveWorkbook.Worksheets;

                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                //Excel.Worksheet excelworksheet = (Excel.Worksheet)excelappworkbook.Sheets[2];
                Excel.Range excelcells = excelworksheet.get_Range("B1", "B12");
                excelcells.Select();

                Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                excelapp.ActiveChart.HasTitle = true;
                excelapp.ActiveChart.ChartTitle.Text = "Количество заказов";

                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Месяц";
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество";

                Excel.SeriesCollection seriesCollection =
                (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
                Excel.Series series = seriesCollection.Item(1);
                series.Name = "Количество заказов";

                //excelworksheet.Name = "Количество заказов";

                excelapp.DisplayAlerts = false;
                excelappworkbook.SaveAs("book.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                
                excelapp.Quit();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка22 \n" + exc.Message);
                excelapp.Quit();
            }
        }

        public void ExcelDiagr1()
        {
            Excel.Application excelapp = new Excel.Application();
            try
            {


                // excelapp.Visible = true;
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelapp.Workbooks.Open("book.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                Excel.Range excelcells = excelworksheet.get_Range("A1", "A12");
                excelcells.Select();
                //выручка
                Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                excelapp.ActiveChart.HasTitle = true;
                excelapp.ActiveChart.ChartTitle.Text = "Выручка";

                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Месяц";
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Выручка (тыс)";

                Excel.SeriesCollection seriesCollection =
                (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(
                Type.Missing);
                Excel.Series series = seriesCollection.Item(1);
                series.Name = "Выручка";
                
                excelapp.DisplayAlerts = false;
                excelappworkbook.SaveAs("book.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excelapp.Quit();



            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка2 \n" + exc.Message);
                excelapp.Quit();
            }
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

        private void button3_Click(object sender, EventArgs e)
        {

            diagr();
        }
    }
}
