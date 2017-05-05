using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class Frame
    {
        Bitmap bmp;
        Graphics gr;
        private void drawStruct()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Фурнитура", new System.Drawing.Font("Arial", 10), Brushes.Blue, 275, 5);
            gr.DrawRectangle(p, 250, 25, 120, 20);
            gr.DrawString("Название", new System.Drawing.Font("Arial", 10), Brushes.Green, 260, 25);
            gr.DrawRectangle(p, 250, 45, 120, 20);
            gr.DrawString("Вид", new System.Drawing.Font("Arial", 10), Brushes.Green, 260, 45);
            gr.DrawRectangle(p, 250, 65, 120, 20);
            gr.DrawString("Цена", new System.Drawing.Font("Arial", 10), Brushes.Green, 260, 65);

            gr.DrawString("Мебель", new System.Drawing.Font("Arial", 10), Brushes.Blue, 125, 115);
            gr.DrawRectangle(p, 100, 135, 120, 20);
            gr.DrawString("Наименование", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 135);
            gr.DrawRectangle(p, 100, 155, 120, 20);
            gr.DrawString("Название", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 155);
            gr.DrawRectangle(p, 100, 175, 120, 20);
            gr.DrawString("Цена", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 175);
            gr.DrawRectangle(p, 100, 195, 120, 20);
            gr.DrawString("Материал", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 195);

            gr.DrawString("Техника", new System.Drawing.Font("Arial", 10), Brushes.Blue, 475, 115);
            gr.DrawRectangle(p, 450, 135, 120, 20);
            gr.DrawString("Наименование", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 135);
            gr.DrawRectangle(p, 450, 155, 120, 20);
            gr.DrawString("Название", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 155);
            gr.DrawRectangle(p, 450, 175, 120, 20);
            gr.DrawString("Цена", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 175);
            gr.DrawRectangle(p, 450, 195, 120, 20);
            gr.DrawString("Производитель", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 195);

            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p,  160, 115, 310, 87);
            gr.DrawLine(p,  510, 115,310, 87);
        }

        private void drawTable()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Экземпляр", new System.Drawing.Font("Arial", 10), Brushes.Blue, 125, 265);
            gr.DrawRectangle(p, 100, 285, 120, 20);
            gr.DrawString("Стол", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 285);
            gr.DrawRectangle(p, 100, 305, 120, 20);
            gr.DrawString("European", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 305);
            gr.DrawRectangle(p, 100, 325, 120, 20);
            gr.DrawString("2500", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 325);
            gr.DrawRectangle(p, 100, 345, 120, 20);
            gr.DrawString("Дерево", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 345);
            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 160, 260, 160, 220);
        }

        private void drawStol()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Экземпляр", new System.Drawing.Font("Arial", 10), Brushes.Blue, 125, 265);
            gr.DrawRectangle(p, 100, 285, 120, 20);
            gr.DrawString("Стул", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 285);
            gr.DrawRectangle(p, 100, 305, 120, 20);
            gr.DrawString("Victoria", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 305);
            gr.DrawRectangle(p, 100, 325, 120, 20);
            gr.DrawString("700", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 325);
            gr.DrawRectangle(p, 100, 345, 120, 20);
            gr.DrawString("Дерево", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 345);
            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 160, 260, 160, 220);
        }

        private void drawShkaf()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Экземпляр", new System.Drawing.Font("Arial", 10), Brushes.Blue, 125, 265);
            gr.DrawRectangle(p, 100, 285, 120, 20);
            gr.DrawString("Шкаф", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 285);
            gr.DrawRectangle(p, 100, 305, 120, 20);
            gr.DrawString("Brusali", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 305);
            gr.DrawRectangle(p, 100, 325, 120, 20);
            gr.DrawString("2000", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 325);
            gr.DrawRectangle(p, 100, 345, 120, 20);
            gr.DrawString("Дерево", new System.Drawing.Font("Arial", 10), Brushes.Green, 110, 345);
            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 160, 260, 160, 220);
        }

        private void drawIsebox()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Экземпляр", new System.Drawing.Font("Arial", 10), Brushes.Blue, 475, 265);
            gr.DrawRectangle(p, 450, 285, 120, 20);
            gr.DrawString("Холодильник", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 285);
            gr.DrawRectangle(p, 450, 305, 120, 20);
            gr.DrawString("LG", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 305);
            gr.DrawRectangle(p, 450, 325, 120, 20);
            gr.DrawString("11000", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 325);
            gr.DrawRectangle(p, 450, 345, 120, 20);
            gr.DrawString("Китай", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 345);
            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 510, 260, 510, 220);
        }

        private void drawPlita()
        {
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Экземпляр", new System.Drawing.Font("Arial", 10), Brushes.Blue, 475, 265);
            gr.DrawRectangle(p, 450, 285, 120, 20);
            gr.DrawString("Плита", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 285);
            gr.DrawRectangle(p, 450, 305, 120, 20);
            gr.DrawString("Mora", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 305);
            gr.DrawRectangle(p, 450, 325, 120, 20);
            gr.DrawString("6000", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 325);
            gr.DrawRectangle(p, 450, 345, 120, 20);
            gr.DrawString("Тайвань", new System.Drawing.Font("Arial", 10), Brushes.Green, 460, 345);
            p = new Pen(Brushes.Red, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 510, 260, 510, 220);
        }

        public Bitmap draw(int w, int h, int id)
        {
            bmp = new Bitmap(w, h);

            drawStruct();
            if(id == 1)
            {
                drawTable();
            } else if(id ==2)
            {
                drawStol();
            }
            else if (id == 3)
            {
                drawShkaf();
            }
            else if (id == 4)
            {
                drawIsebox();
            }
            else if (id == 5)
            {
                drawPlita();
            }
            return bmp;
        }


    }
}
