using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// отчеты
    /// </summary>
    class Reports
    {

        ManagerBD mbd = new ManagerBD();
        Dictionary<string, string> dict;
        int id = 1;
        public void blank()
        {
            dict = new Dictionary<string, string>();
            dict.Add("oboi","Обои");
            dict.Add("plitka", "Плитка");
            dict.Add("table", "Стол");
            dict.Add("stol", "Стул");
            dict.Add("plita", "Плита");
            dict.Add("icebox", "Холодильник");
            mbd.Connection();

            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price from StroyMaterial join StroyMaterialZakaz on StroyMaterial.id_stroy_mater = StroyMaterialZakaz.id_StroyMaterial" +
                " join Zakaz on StroyMaterialZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = " + Convert.ToString(id) + ";");

            DataTable dt1 = mbd.selectionquery("select naimenovanie,nazvanie,price from Furnitura  join FurnituraZakaz  on FurnituraZakaz.id_Furnitura = Furnitura.id_furnit " +
                " join Zakaz on FurnituraZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = " + Convert.ToString(id) +" AND type = 'mebel';");

            DataTable dt2 = mbd.selectionquery("select naimenovanie,nazvanie,price from Furnitura  join FurnituraZakaz  on FurnituraZakaz.id_Furnitura = Furnitura.id_furnit " +
               " join Zakaz on FurnituraZakaz.id_zakaz = Zakaz.id_zakaz  where zakaz.id_zakaz = "+ Convert.ToString(id) + " AND type = 'technics';");

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Phrase p = new Phrase("Бланк заказа №" + Convert.ToString(id),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a1 = new Paragraph(p);
            a1.Alignment = Element.ALIGN_CENTER;
            a1.Add(Environment.NewLine);
            a1.SpacingAfter = 5;
            doc.Add(a1);

            PdfPTable table = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Наименование", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));

            //cell.BackgroundColor = new BaseColor(Color.Yellow);
            //cell.Padding = 3; //отступ
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

            cell = new PdfPCell(new Phrase("Строительные материалы", new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.BOLD, new BaseColor(Color.Black))));

            //cell.BackgroundColor = new BaseColor(Color.Yellow);
            cell.Padding = 3; //отступ
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            //PdfPCell cell1 = new PdfPCell(new Phrase("14"));
            //cell1.Rowspan = 1;
            //table.AddCell(cell1);
            int sumSM = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string s = Convert.ToString(dt.Rows[i][j]);
                    if (j == 0) {
                        cell = new PdfPCell(new Phrase(dict[Convert.ToString(dt.Rows[i][j])], new iTextSharp.text.Font(baseFont,
                            12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    } else
                    {
                        cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont,
                            12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    }
                   
                    
                    table.AddCell(cell);
                }
                sumSM += Convert.ToInt32(dt.Rows[i][2]);
            }

            cell = new PdfPCell(new Phrase("Мебель", new iTextSharp.text.Font(baseFont,
               12, iTextSharp.text.Font.BOLD, new BaseColor(Color.Black))));

            cell.Padding = 3; //отступ
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            int sumM = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        cell = new PdfPCell(new Phrase(dict[Convert.ToString(dt1.Rows[i][j])], new iTextSharp.text.Font(baseFont, 12,
                        iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    } else
                    {
                        cell = new PdfPCell(new Phrase(Convert.ToString(dt1.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                     iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    }
                    table.AddCell(cell);
                    
                }
                sumM += Convert.ToInt32(dt1.Rows[i][2]);
            }

            cell = new PdfPCell(new Phrase("Техника", new iTextSharp.text.Font(baseFont,
             12, iTextSharp.text.Font.BOLD, new BaseColor(Color.Black))));
            int sumT = 0;
            cell.Padding = 3; //отступ
            cell.Colspan = 3;
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
                    }else
                    {
                        cell = new PdfPCell(new Phrase(Convert.ToString(dt2.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                       iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    }
                    table.AddCell(cell);
                   
                }
                sumT += Convert.ToInt32(dt2.Rows[i][2]);
            }

            //table.AddCell("Обои");
            //table.AddCell("Col 3 Row 1");
            //table.AddCell("Col 2 Row 2");


            //jpg = iTextSharp.text.Image.GetInstance(@"G:/left.jpg");
            //cell = new PdfPCell(jpg);
            //cell.Padding = 5;
            //cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            //table.AddCell(cell);

            //jpg = iTextSharp.text.Image.GetInstance(@"G:/right.jpg");
            //cell = new PdfPCell(jpg);
            //cell.Padding = 5;
            //cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            //table.AddCell(cell);


            doc.Add(table);


            Phrase p1 = new Phrase("             Сумма строительных материалов(это не точно): " + Convert.ToString(sumSM),
            new iTextSharp.text.Font(baseFont, 14,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a2 = new Paragraph(p1);
            a2.Alignment = Element.ALIGN_LEFT;
            a2.Add(Environment.NewLine);
            //a2.SpacingAfter = 5;
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

            p1 = new Phrase("             Общая сумма: " + Convert.ToString(sumM+ sumT+ sumSM),
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


        }
    }
}
