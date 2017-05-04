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
        public Bitmap drawStruct(int w, int h)
        {
            bmp = new Bitmap(w, h);
            gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Brushes.Black, 2);
            gr.DrawString("Фурнитура", new System.Drawing.Font("Arial", 10), Brushes.Black, 125, 5);

            gr.DrawRectangle(p,100,25,120,20);
            gr.DrawString("Название", new System.Drawing.Font("Arial", 10), Brushes.Black, 110, 25);
            gr.DrawRectangle(p, 100, 45, 120, 20);
            gr.DrawString("Название", new System.Drawing.Font("Arial", 10), Brushes.Black, 110, 40);


            return bmp;
        }


    }
}
