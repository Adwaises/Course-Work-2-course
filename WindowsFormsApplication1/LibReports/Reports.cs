using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using LibDataForBD;
using LibraryManagerBD;
using System.Data;


namespace LibReports
{
    /// <summary>
    /// Отчеты
    /// </summary>
    public class Reports
    {
        ManagerBD mbd = new ManagerBD();
        Dictionary<string, string> dict;

        Dictionary<int, int> dictSum;
        Dictionary<int, int> dictCount;

        public void blank(int id)
        {
            dict = new Dictionary<string, string>();
            dict.Add("oboi", "Обои");
            dict.Add("plitka", "Плитка");
            dict.Add("table", "Стол");
            dict.Add("stol", "Стул");
            dict.Add("plita", "Плита");
            dict.Add("icebox", "Холодильник");
            dict.Add("shkaf", "Шкаф");
            dict.Add("vytyazhka", "Вытяжка");

            mbd.Connection();

            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price from StroyMaterial join StroyMaterialZakaz on StroyMaterial.id_stroy_mater = StroyMaterialZakaz.id_StroyMaterial" +
                " join Zakaz on StroyMaterialZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = " + Convert.ToString(id) + ";");

            DataTable dt1 = mbd.selectionquery("select naimenovanie,nazvanie,price from Furnitura  join FurnituraZakaz  on FurnituraZakaz.id_Furnitura = Furnitura.id_furnit " +
                " join Zakaz on FurnituraZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = " + Convert.ToString(id) + " AND type = 'mebel';");

            DataTable dt2 = mbd.selectionquery("select naimenovanie,nazvanie,price from Furnitura  join FurnituraZakaz  on FurnituraZakaz.id_Furnitura = Furnitura.id_furnit " +
               " join Zakaz on FurnituraZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = " + Convert.ToString(id) + " AND type = 'technics';");

            DataTable dt3 = mbd.selectionquery("select length,width,height from zakaz where id_zakaz = " + Convert.ToString(id) + ";");

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"lib/ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Phrase p = new Phrase("Бланк заказа №" + Convert.ToString(id),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a1 = new Paragraph(p);
            a1.Alignment = Element.ALIGN_CENTER;
            a1.Add(Environment.NewLine);
            a1.SpacingAfter = 5;
            doc.Add(a1);

            PdfPTable table = new PdfPTable(4);

            p = new Phrase("Строительные материалы",
            new iTextSharp.text.Font(baseFont, 12,
            iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            a1 = new Paragraph(p);
            a1.Alignment = Element.ALIGN_CENTER;
            a1.Add(Environment.NewLine);
            a1.SpacingAfter = 5;
            doc.Add(a1);

            PdfPCell cell = new PdfPCell(new Phrase("Наименование", new iTextSharp.text.Font(baseFont,
               12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));

            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Название", new iTextSharp.text.Font(baseFont,
            12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Цена за кв.м", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Кв.м", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            double sumSM = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        cell = new PdfPCell(new Phrase(dict[Convert.ToString(dt.Rows[i][j])], new iTextSharp.text.Font(baseFont,
                            12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont,
                            12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    }

                    table.AddCell(cell);
                }
                double S = 0;
                if (Convert.ToString(dt.Rows[i][0]) == "plitka")
                {
                    S = (Convert.ToDouble(dt3.Rows[0][0]) / 100) * (Convert.ToDouble(dt3.Rows[0][1]) / 100);
                    cell = new PdfPCell(new Phrase(Convert.ToString(S), new iTextSharp.text.Font(baseFont,
                                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table.AddCell(cell);
                }
                else if (Convert.ToString(dt.Rows[i][0]) == "oboi")
                {
                    S = (Convert.ToDouble(dt3.Rows[0][0]) / 100) * (Convert.ToDouble(dt3.Rows[0][2]) / 100) * 2;
                    S += (Convert.ToDouble(dt3.Rows[0][1]) / 100) * (Convert.ToDouble(dt3.Rows[0][2]) / 100) * 2;
                    cell = new PdfPCell(new Phrase(Convert.ToString(S), new iTextSharp.text.Font(baseFont,
                                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table.AddCell(cell);
                }
                sumSM += Convert.ToInt32(dt.Rows[i][2]) * S;

            }

            doc.Add(table);

            table = new PdfPTable(3);
            int sumM = 0;
            if (dt1.Rows.Count != 0)
            {
                p = new Phrase("Мебель",
                new iTextSharp.text.Font(baseFont, 12,
                iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
                a1 = new Paragraph(p);
                a1.Alignment = Element.ALIGN_CENTER;
                a1.Add(Environment.NewLine);
                a1.SpacingAfter = 5;
                doc.Add(a1);

                cell = new PdfPCell(new Phrase("Наименование", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Название", new iTextSharp.text.Font(baseFont,
                    12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Цена", new iTextSharp.text.Font(baseFont,
                    12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            cell = new PdfPCell(new Phrase(dict[Convert.ToString(dt1.Rows[i][j])], new iTextSharp.text.Font(baseFont, 12,
                            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(Convert.ToString(dt1.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                         iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                        }
                        table.AddCell(cell);

                    }
                    sumM += Convert.ToInt32(dt1.Rows[i][2]);
                }
            }

            doc.Add(table);

            table = new PdfPTable(3);
            int sumT = 0;

            if (dt2.Rows.Count != 0)
            {

                p = new Phrase("Техника",
                new iTextSharp.text.Font(baseFont, 12,
                iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
                a1 = new Paragraph(p);
                a1.Alignment = Element.ALIGN_CENTER;
                a1.Add(Environment.NewLine);
                a1.SpacingAfter = 5;
                doc.Add(a1);

                cell = new PdfPCell(new Phrase("Наименование", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Название", new iTextSharp.text.Font(baseFont,
                    12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Цена", new iTextSharp.text.Font(baseFont,
                    12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            cell = new PdfPCell(new Phrase(dict[Convert.ToString(dt2.Rows[i][j])], new iTextSharp.text.Font(baseFont, 12,
                            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(Convert.ToString(dt2.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                           iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                        }
                        table.AddCell(cell);

                    }
                    sumT += Convert.ToInt32(dt2.Rows[i][2]);
                }
            }

            doc.Add(table);

            Phrase p1 = new Phrase("             Параметры комнаты: " + Convert.ToString(Convert.ToDouble(dt3.Rows[0][0]) / 100) + " м * " +
                 Convert.ToString(Convert.ToDouble(dt3.Rows[0][1]) / 100) + " м * " + Convert.ToString(Convert.ToDouble(dt3.Rows[0][2]) / 100) + " м",
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a2 = new Paragraph(p1);
            a2.Alignment = Element.ALIGN_LEFT;
            a2.Add(Environment.NewLine);
            doc.Add(a2);

            p1 = new Phrase("             Сумма строительных материалов: " + Convert.ToString(sumSM),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a2 = new Paragraph(p1);
            a2.Alignment = Element.ALIGN_LEFT;
            a2.Add(Environment.NewLine);
            doc.Add(a2);

            p1 = new Phrase("             Сумма техники: " + Convert.ToString(sumT),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a2 = new Paragraph(p1);
            doc.Add(a2);

            p1 = new Phrase("             Сумма мебели: " + Convert.ToString(sumM),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a2 = new Paragraph(p1);

            doc.Add(a2);

            int allSum = Convert.ToInt32(sumM + sumT + sumSM);

            p1 = new Phrase("             Общая сумма: " + Convert.ToString(allSum),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            a2 = new Paragraph(p1);

            a2.SpacingAfter = 30;
            doc.Add(a2);
            a2.SpacingAfter = 30;
            DateTime second = DateTime.Now;

            Phrase p2 = new Phrase("Дата формирования заказа: " + second,
            new iTextSharp.text.Font(baseFont, 12,
            iTextSharp.text.Font.ITALIC, new BaseColor(Color.Black)));
            a2 = new Paragraph(p2);
            a2.Alignment = Element.ALIGN_RIGHT;
            doc.Add(a2);

            doc.Close();

            DataForBD.Summa = allSum;

        }
        /// <summary>
        /// Рисует сетку
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawGrid()
        {
            Bitmap bmp = new Bitmap(760, 500);
            Graphics gr = Graphics.FromImage(bmp);

            int h = 455;
            int w = 570;
            int maxX = 12;
            int maxY = 1000;
            int max = h - 25;
            float cdx = (w - 90) / maxX;
            float cdy = (h - 50) / maxY;
            Pen p = new Pen(Brushes.Green, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, (int)(0 * cdx) + 40, (int)h - 25, (int)(0 * cdx) + 40, 0);
            gr.DrawLine(p, 0, (int)(max - 0 * cdy), (int)w - 50, (int)(max - 0 * cdy));

            for (float x = 0; x < maxX; x++)
            {
                gr.DrawString((x + 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
            }

            double cy = 0.4;
            for (float y = 1; y <= maxY + 1; y += 100)
            {
                gr.DrawString((y - 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
            }
            return bmp;
        }

        public Bitmap diagr(bool check)
        {
            dictSum = new Dictionary<int, int>();
            dictCount = new Dictionary<int, int>();
            for (int i = 1; i <= 12; i++)
            {
                dictSum.Add(i, 0);
                dictCount.Add(i, 0);
            }

            mbd.Connection();
            DataTable dt = mbd.Statistic();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictSum[Convert.ToInt32(dt.Rows[i][0])] = Convert.ToInt32(dt.Rows[i][1]) / 1000;
                dictCount[Convert.ToInt32(dt.Rows[i][0])] = Convert.ToInt32(dt.Rows[i][2]);
            }
            int w = 570;
            int h = 455;
            int maxX = 12;
            int maxY = 1000;
            int max = h - 25;

            Bitmap bmp = new Bitmap(760, 500);
            Graphics gr = Graphics.FromImage(bmp);
            float cdx = (w - 90) / maxX;
            float cdy = (h - 50) / maxY;

            Pen p = new Pen(Brushes.Green, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, (int)(0 * cdx) + 40, (int)h - 25, (int)(0 * cdx) + 40, 0);
            gr.DrawLine(p, 0, (int)(max - 0 * cdy), (int)w - 50, (int)(max - 0 * cdy));

            if (check)
            {
                for (float x = 0; x < maxX; x++)
                {
                    gr.DrawString((x + 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                    gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
                }

                double cy = 0.4;
                for (float y = 1; y <= maxY + 1; y += 100)
                {
                    gr.DrawString((y - 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                    gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
                }

                for (int i = 1; i <= dictSum.Count; i++)
                {
                    gr.FillRectangle(Brushes.Red, 40 * (i - 1) + 40, (int)(maxY * 0.43) - (int)(dictSum[i] * 0.4), 10, (int)(dictSum[i] * 0.4));
                }


            }
            else if (!check)
            {
                for (float x = 0; x < maxX; x++)
                {
                    gr.DrawString((x + 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, (int)(x * cdx) + 40, max + 10);
                    gr.DrawLine(Pens.Green, (int)(x * cdx) + 40, (int)h - 25, (int)(x * cdx) + 40, 0);
                }

                double cy = 0.4;
                for (float y = 1; y <= maxY + 1; y += 100)
                {
                    gr.DrawString(((y - 1) / 100).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Green, 0, (int)(max - (y) * cy));
                    gr.DrawLine(Pens.Green, 0, (int)(max - (int)(y * cy)), (int)w - 50, (int)(max - (int)(y * cy)));
                }

                for (int i = 1; i <= dictCount.Count; i++)
                {
                    gr.FillRectangle(Brushes.Red, 40 * (i - 1) + 40, (int)(maxY * 0.43) - dictCount[i] * 40, 10, (int)(dictCount[i] * 40));
                }

            }

            gr.DrawString("Месяц", new System.Drawing.Font("Arial", 10), Brushes.Black, 250, 470);

            w = 184;
            h = 56;
            gr.DrawRectangle(new Pen(Brushes.Black), 550, 180, w - 1, h - 1);

            gr.FillRectangle(Brushes.Red, 560, 203, 10, 10);
            if (check)
            {
                gr.DrawString("Выручка (тыс)", new System.Drawing.Font("Arial", 10), Brushes.Black, 585, 200);
            }
            else if (!check)
            {
                gr.DrawString("Количество заказов", new System.Drawing.Font("Arial", 10), Brushes.Black, 585, 200);
            }

            return bmp;

        }

        public Bitmap vertLabelDiagr(bool check)
        {
            Bitmap bmpL = new Bitmap(150, 50);
            Graphics grL = Graphics.FromImage(bmpL);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            if (check)
            {
                grL.DrawString("Выручка (тыс)", new System.Drawing.Font("Arial", 10), Brushes.Black, 0, 0);
            }
            else if (!check)
            {
                grL.DrawString("Количество заказов", new System.Drawing.Font("Arial", 10), Brushes.Black, 0, 0);
            }
            bmpL.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bmpL;
        }

        public void ExcelDiagr()
        {
            DataForBD.Iter = 0;
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                for (int i = 1; i <= dictSum.Count; i++)
                {
                    ObjWorkSheet.Cells[i, 1] = Convert.ToString(dictSum[i]);
                    ObjWorkSheet.Cells[i, 2] = Convert.ToString(dictCount[i]);
                }
                ObjExcel.DisplayAlerts = false;
                ObjWorkBook.SaveAs("book.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                ObjExcel.Quit();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            DataForBD.Iter = 1;
            Excel.Application excelapp = new Excel.Application();
            try
            {

                DataForBD.Iter = 2;
                ExcelDiagr1();
                DataForBD.Iter = 4;
                ExcelDiagr2();
                DataForBD.Iter = 6;
            }
            catch (Exception exc)
            {
                excelapp.Quit();
                throw exc;
            }
        }


        public void ExcelDiagr2()
        {
            Excel.Application excelapp = new Excel.Application();
            try
            {
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelapp.Workbooks.Open("book.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;

                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                Excel.Range excelcells = excelworksheet.get_Range("B1", "B12");
                excelcells.Select();

                Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                excelapp.ActiveChart.HasTitle = true;
                excelapp.ActiveChart.ChartTitle.Text = "Количество заказов";

                DataForBD.Iter = 5;

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

                excelapp.DisplayAlerts = false;
                excelappworkbook.SaveAs("book.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                excelapp.Quit();

            }
            catch (Exception exc)
            {
                excelapp.Quit();
                throw exc;

            }
        }

        public void ExcelDiagr1()
        {
            Excel.Application excelapp = new Excel.Application();
            try
            {
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelapp.Workbooks.Open("book.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                Excel.Range excelcells = excelworksheet.get_Range("A1", "A12");
                excelcells.Select();

                Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                excelapp.ActiveChart.HasTitle = true;
                excelapp.ActiveChart.ChartTitle.Text = "Выручка";
                DataForBD.Iter = 3;

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
                excelapp.Quit();
                throw exc;

            }
        }

    }
}
