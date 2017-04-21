using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class SemanticNetworks
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


            for(int i=0; i< 3; i++)
            {


                s += "Наименование: " + dict[Convert.ToString(dt.Rows[i][0])] + "\t\t"+"Название: " + dt.Rows[i][1] +  "   \tЦена: " + dt.Rows[i][2]  +" \tКоличество заказов: " + dt.Rows[i][3] + "\r\n";
                DataTable dt1 = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = "+ dt.Rows[i][4] + " group by zakaz.id_zakaz order by famil");
                for(int j=0;j < dt1.Columns.Count;j++)
                {
                    


                    s += "Заказал: " + dt1.Rows[j][0] + " "+ dt1.Rows[j][1] +" "+ dt1.Rows[j][2] + "\tВ месяце: " + months[Convert.ToInt32( dt1.Rows[j][3])] + "       \tВ количестве: " + dt1.Rows[j][4] + "\r\n";
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
            gr.DrawString("Месяц", new System.Drawing.Font("Arial", 10), Brushes.Red, 600, 300);

            for (int i=0; i<12;i++)
            {
                gr.DrawString((i+1).ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, 50*i, 300);

            }

            Pen p = new Pen(Brushes.Green, 3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            mbd.Connection();
            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price, count(*), id_furnitura from FurnituraZakaz  join furnitura on furnitura.id_furnit = FurnituraZakaz.id_furnitura group by id_furnitura order by count(*) desc ");
            int one = 30;
            for (int i = 0; i < 3; i++)
            {
                gr.DrawString(dict[Convert.ToString(dt.Rows[i][0])], new System.Drawing.Font("Arial", 10), Brushes.Black, one, 50);
                gr.DrawString(dt.Rows[i][1].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one, 65);
                gr.DrawLine(p,290,25,one+30,50);
                int x = one + 30;
                int y = 50;
                int two = 0;
                int two2 = 0;
                int num = 0;
                listFamil = new List<string>();
                //s += "Наименование: " + dict[Convert.ToString(dt.Rows[i][0])] + "\t\t" + "Название: " + dt.Rows[i][1] + "   \tЦена: " + dt.Rows[i][2] + " \tКоличество заказов: " + dt.Rows[i][3] + "\r\n";
                DataTable dt1 = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = " + dt.Rows[i][4] + " group by zakaz.id_zakaz order by famil");
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (!listFamil.Contains(dt1.Rows[j][0].ToString()))
                    {
                        gr.DrawString(dt1.Rows[j][0].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + two, 100 + two2);
                        //s += "Заказал: " + dt1.Rows[j][0] + " " + dt1.Rows[j][1] + " " + dt1.Rows[j][2] + "\tВ месяце: " + months[Convert.ToInt32(dt1.Rows[j][3])] + "       \tВ количестве: " + dt1.Rows[j][4] + "\r\n";
                        gr.DrawLine(p, one+30, 80, one -10+two, 100+two2);
                        
                        listFamil.Add(dt1.Rows[j][0].ToString());
                        if(!listFamil.Contains(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString()))
                        {
                            gr.DrawString(dt1.Rows[j][4].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + num, 200); // колво
                            gr.DrawLine(p, one - 10 + two, 120 + two2, one - 30 + num, 200); // к колву
                            gr.DrawLine(p, one - 20 + num, 220, Convert.ToInt32(dt1.Rows[j][3]) * 50, 300); // к мес
                            listFamil.Add(dt1.Rows[j][4].ToString() + dt1.Rows[j][3].ToString());
                            num += 25;
                        } else
                        {
                            //gr.DrawString(dt1.Rows[j][4].ToString(), new System.Drawing.Font("Arial", 10), Brushes.Black, one - 30 + num, 200); // колво
                            gr.DrawLine(p, one - 10 + two, 120 + two2, one - 30 + num-25, 200); // к колву
                            //gr.DrawLine(p, one - 20 + num, 220, Convert.ToInt32(dt1.Rows[j][3]) * 50, 300); // к мес
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
                            //two2 += 20;
                            //two += 40;
                    }
                    //num += 25;

                }

                one += 230;
            }


            return bmp;
        }

    }
}
