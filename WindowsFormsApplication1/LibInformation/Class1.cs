using LibraryManagerBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInformation
{
    public class ProfitAnalysis
    {
        ManagerBD mbd = new ManagerBD();

        Dictionary<int, string> dict = new Dictionary<int, string>()
        {
            {0, "Нужно повысить количество заказов. Требуется больше рекламы! (Заказов меньше 5)" },
            {1, "Требуется понизить цены на мебель (Берут дешевую мебель либо берут мало)" },
            {2, "Требуется понизить цены на технику (Берут дешевую технику либо берут мало)"},
            {3, "Можно незначительно повысить цены на мебель (Хорошо брали мебель)"},
            {4, "Можно незначительно повысить цены на технику(Хорошо брали технику)"},
            {5, "Требуется понизить цены на стройматериалы (Брали дешевые стройматериалы)"},
            {6, "Можно незначительно повысить цены на стройматериалы (Берут дорогие стройматериалы)"},
            {7, "Можно поощрить менеджера за хорошую работу (Заказов больше 5)"}
        };

        public string Analis(int month)
        {
            string s = "";
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select count(*) from zakaz where month_Zakaz = " + month);
            int countOrder = Convert.ToInt32(dt.Rows[0][0]);
            if (Convert.ToInt32(dt.Rows[0][0]) < 5)
            {
                s += dict[0] + "\r\n";
            }
            dt = mbd.selectionquery("select sum(summa) from zakaz where month_Zakaz = " + month);
            if (countOrder >= 4 && Convert.ToInt32(dt.Rows[0][0]) > 300000)
            {
                s += dict[7] + "\r\n";
            }
            dt = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where month_Zakaz = " + month);
            if (Convert.ToInt32(dt.Rows[0][0]) / countOrder <= 3)
            {
                DataTable dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'mebel'");
                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder <= 3)
                {
                    s += dict[1] + "\r\n";
                }
                dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'technics'");
                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder <= 3)
                {
                    s += dict[2] + "\r\n";
                }
            }
            if (Convert.ToInt32(dt.Rows[0][0]) / countOrder > 3)
            {
                DataTable dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'mebel'");
                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder > 3)
                {
                    s += dict[3] + "\r\n";
                }
                dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'technics'");
                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder > 3)
                {
                    s += dict[4] + "\r\n";
                }
            }

            dt = mbd.selectionquery("select avg(price) from StroyMaterial  ");
            int avg = Convert.ToInt32(dt.Rows[0][0]);
            dt = mbd.selectionquery("select avg(price) from StroyMaterialZakaz join StroyMaterial on StroyMaterialZakaz.id_StroyMaterial =  StroyMaterial.id_stroy_mater join" +
                " zakaz on StroyMaterialZakaz.id_zakaz = zakaz.id_zakaz where month_zakaz = " + month);
            if (avg >= Convert.ToInt32(dt.Rows[0][0]) / countOrder)
            {
                if (countOrder <= 5)
                {
                    s += dict[5] + "\r\n";
                }
                if (countOrder > 5)
                {
                    s += dict[6] + "\r\n";
                }
            }

            if (avg < Convert.ToInt32(dt.Rows[0][0]) / countOrder)
            {
                if (countOrder <= 5)
                {
                    s += dict[5] + "\r\n";
                }
                if (countOrder > 5)
                {
                    s += dict[6] + "\r\n";
                }
            }
            return s;
        }
    }

    public class SemanticNetworks
    {
        ManagerBD mbd = new ManagerBD();
        Dictionary<string, string> dict = new Dictionary<string, string>();
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        public string analis()
        {
            dict.Add("oboi", "Обои");
            dict.Add("plitka", "Плитка");
            dict.Add("table", "Стол");
            dict.Add("stol", "Стул");
            dict.Add("plita", "Плита");
            dict.Add("icebox", "Холодильник");
            dict.Add("shkaf", "Шкаф");
            dict.Add("vytyazhka", "Вытяжка");
            string s = "Самая покупаемая фурнитура (Топ-3) \r\n";
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price, count(*), id_furnitura from FurnituraZakaz  join furnitura on furnitura.id_furnit = FurnituraZakaz.id_furnitura group by id_furnitura order by count(*) desc ");
            for (int i = 0; i < 3; i++)
            {
                s += "Наименование: " + dict[Convert.ToString(dt.Rows[i][0])] + "\t\t" + "Название: " + dt.Rows[i][1] + "   \tЦена: " + dt.Rows[i][2] + " \tКоличество заказов: " + dt.Rows[i][3] + "\r\n";
                DataTable dt1 = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = " + dt.Rows[i][4] + " group by zakaz.id_zakaz order by famil");
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    s += "Заказал: " + dt1.Rows[j][0] + " " + dt1.Rows[j][1] + " " + dt1.Rows[j][2] + "\tВ месяце: " + months[Convert.ToInt32(dt1.Rows[j][3]) - 1] + "       \tВ количестве: " + dt1.Rows[j][4] + "\r\n";
                }
            }
            return s;
        }

        List<String> listFamil;

        public Bitmap drawGraph(int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            gr.DrawString("Фурнитура", new System.Drawing.Font("Arial", 10), Brushes.Black, 250, 10);
            gr.DrawString("Покупатель", new System.Drawing.Font("Arial", 10), Brushes.Red, 600, 100);
            gr.DrawString("Количество", new System.Drawing.Font("Arial", 10), Brushes.Red, 600, 200);
            gr.DrawString("Месяц", new System.Drawing.Font("Arial", 10), Brushes.Red, 650, 300);
            for (int i = 0; i < 12; i++)
            {
                gr.DrawString((i + 1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, 50 + 50 * i, 300);
            }
            Pen p = new Pen(Brushes.Green, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(p, 70, 60, 250, 60);
            gr.DrawLine(p, 300, 60, 470, 60);
            gr.DrawString("Выгоднее", new System.Drawing.Font("Arial", 10), Brushes.Black, 150, 40);
            gr.DrawString("Выгоднее", new System.Drawing.Font("Arial", 10), Brushes.Black, 350, 40);
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price, count(*), id_furnitura from FurnituraZakaz  join furnitura on furnitura.id_furnit = FurnituraZakaz.id_furnitura group by id_furnitura order by count(*) desc ");
            int one = 30;
            for (int i = 0; i < 3; i++)
            {
                gr.DrawString(dict[Convert.ToString(dt.Rows[i][0])], new System.Drawing.Font("Arial", 10), Brushes.Black, one, 50);
                gr.DrawString(dt.Rows[i][1].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one, 65);
                gr.DrawLine(p, 290, 25, one + 30, 50);
                int x = one + 30;
                int y = 50;
                int two = 0;
                int two2 = 0;
                int num = 0;
                listFamil = new List<string>();
                DataTable dt1 = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = " + dt.Rows[i][4] + " group by zakaz.id_zakaz order by famil");
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    if (!listFamil.Contains(dt1.Rows[j][0].ToString()))
                    {
                        gr.DrawString(dt1.Rows[j][0].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + two, 100 + two2);
                        gr.DrawLine(p, one + 30, 80, one - 10 + two, 100 + two2);

                        listFamil.Add(dt1.Rows[j][0].ToString());
                        if (!listFamil.Contains(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString()))
                        {
                            gr.DrawString(dt1.Rows[j][4].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + num, 200);
                            gr.DrawLine(p, one - 10 + two, 120 + two2, one - 30 + num, 200);
                            gr.DrawLine(p, one - 20 + num, 220, Convert.ToInt32(dt1.Rows[j][3]) * 50, 300);
                            listFamil.Add(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString());
                            num += 25;
                        }
                        else
                        {
                            gr.DrawLine(p, one - 10 + two, 120 + two2, one - 30 + num - 25, 200);
                        }
                        two += 40;
                        two2 += 20;
                    }
                    else
                    {
                        if (!listFamil.Contains(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString()))
                        {
                            gr.DrawString(dt1.Rows[j][4].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + num, 200);
                            gr.DrawLine(p, one - 10 + two - 40, 120 + two2 - 20, one - 25 + num, 200);
                            gr.DrawLine(p, one - 20 + num, 220, Convert.ToInt32(dt1.Rows[j][3]) * 50, 300);
                            listFamil.Add(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString());
                            num += 25;
                        }
                        else
                        {
                            gr.DrawLine(p, one - 10 + two - 40, 120 + two2 - 20, one - 25 + num, 200);
                        }
                    }
                }
                one += 230;
            }
            return bmp;
        }
    }

    public class Frame
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
            gr.DrawLine(p, 160, 115, 310, 87);
            gr.DrawLine(p, 510, 115, 310, 87);
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
            if (id == 1)
            {
                drawTable();
            }
            else if (id == 2)
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

    public class Logic
    {
        public List<string> list1 = new List<string>() {
        "Плита будет размещена",
        "Стол будет размещен"};

        public List<string> list2 = new List<string>() {
        "Холодильник будет размещен",
        "Шкаф будет размещен",
        "Стул будет размещен"};

        private List<string> listSint = new List<string>()
        {
            "должны располагаться подальше друг от друга",
            "должны располагаться рядом"
        };

        string s = "";

        public string result(string num1, string num2)
        {
            s = num1 + " и " + num2 + " ";
            string tmp = predicat(num1, num2);
            if (tmp != "0")
            {
                s += tmp;
                return s;
            }
            else
            {
                return "Выбранные суждения разного рода";
            }
        }

        public string predicat(string str1, string str2)
        {
            if (str1 == "Плита" && str2 == "Холодильник" || str1 == "Плита" && str2 == "Шкаф" ||
                str1 == "Стол" && str2 == "Холодильник" || str1 == "Стол" && str2 == "Шкаф")
            {
                return listSint[0];
            }
            else if (str1 == "Стол" && str2 == "Стул")
            {
                return listSint[1];
            }
            else
            {
                return "0";
            }
        }
    }

}
