using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class SemanticNetworks
    {
        ManagerBD mbd = new ManagerBD();
        public string analis()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("oboi", "Обои");
            dict.Add("plitka", "Плитка");
            dict.Add("table", "Стол");
            dict.Add("stol", "Стул");
            dict.Add("plita", "Плита");
            dict.Add("icebox", "Холодильник");
            dict.Add("shkaf", "Шкаф");
            dict.Add("vytyazhka", "Вытяжка");
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            string s = "";

            mbd.Connection();
            DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price, count(*), id_furnitura from FurnituraZakaz  join furnitura on furnitura.id_furnit = FurnituraZakaz.id_furnitura group by id_furnitura order by count(*) desc ");

            for(int i=0; i< 3; i++)
            {


                s += "Наименование: " + dict[Convert.ToString(dt.Rows[i][0])] + "\t\t"+"Название: " + dt.Rows[i][1] +  "   \tЦена: " + dt.Rows[i][2]  +" \tКоличество заказов: " + dt.Rows[i][3] + "\r\n";
                DataTable dt1 = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = "+ dt.Rows[i][4] + " group by zakaz.id_zakaz");
                for(int j=0;j < dt1.Columns.Count;j++)
                {
                    


                    s += "Заказал: " + dt1.Rows[j][0] + " "+ dt1.Rows[j][1] +" "+ dt1.Rows[j][2] + "\tВ месяце: " + months[Convert.ToInt32( dt1.Rows[j][3])] + "       \tВ количестве: " + dt1.Rows[j][4] + "\r\n";
                }
                

            }


            return s;
        }
    }
}
