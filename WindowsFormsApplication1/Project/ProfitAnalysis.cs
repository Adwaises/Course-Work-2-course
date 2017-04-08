using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    
    class ProfitAnalysis
    {
        ManagerBD mbd = new ManagerBD();

        Dictionary<int, string> dict = new Dictionary<int, string>()
        {
            {0, "Нужно повысить количество заказов. Требуется больше рекламы!" },
            {1, "Требуется понизить цены на мебель" },
            {2, "Требуется понизить цены на технику"},
            {3, "Можно незначительно павысить цены на мебель"},
            {4, "Можно незначительно павысить цены на технику"},
            {5, "Требуется понизить цены на стройматериалы"},
            {6, "Можно незначительно павысить цены на стройматериалы"},
            {7, "Можно поощрить менеджера за хорошую работу"}
        };

        public string Analis(int month)
        {


            string s = "";

            mbd.Connection();
            DataTable dt = mbd.selectionquery("select count(*) from zakaz where month_Zakaz = " + month);
            int countOrder = Convert.ToInt32(dt.Rows[0][0]);
            if (Convert.ToInt32( dt.Rows[0][0]) < 5)
            {
                s += dict[0] + "\r\n";
            }

            dt = mbd.selectionquery("select sum(summa) from zakaz where month_Zakaz = " + month);

            if (countOrder >= 4 && Convert.ToInt32(dt.Rows[0][0]) >300000)
            {
                s += dict[7] + "\r\n";
            }

            dt = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where month_Zakaz = " + month);
           
            if(Convert.ToInt32(dt.Rows[0][0])/ countOrder <= 3)
            {
                DataTable dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz ="+month+" and type = 'mebel'");

                if(Convert.ToInt32(dt1.Rows[0][0])/ countOrder <= 3)
                {
                    s += dict[1] + "\r\n";
                }
                /*
                if (Convert.ToInt32(dt1.Rows[0][0])/ countOrder > 3)
                {
                    s += "Можно незначительно повысить цены на мебель\r\n";
                }
                */
                dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'technics'");

                if (Convert.ToInt32(dt1.Rows[0][0])/ countOrder <= 3)
                {
                    s += dict[2]+"\r\n";
                }
                /*
                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder > 3)
                {
                    s += "Можно незначительно повысить цены на технику\r\n";
                }
                */
            }

            if (Convert.ToInt32(dt.Rows[0][0]) / countOrder > 3)
            {

                DataTable dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'mebel'");

                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder > 3)
                {
                    s += dict[3]+"\r\n";
                }

                dt1 = mbd.selectionquery("select count(*) from FurnituraZakaz join zakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz join Furnitura " +
                 "on Furnitura.id_furnit = FurnituraZakaz.id_Furnitura  where month_Zakaz =" + month + " and type = 'technics'");

                if (Convert.ToInt32(dt1.Rows[0][0]) / countOrder > 3)
                {
                    s += dict[4]+"\r\n";
                }
            }

            dt = mbd.selectionquery("select avg(price) from StroyMaterial  ");
            int avg = Convert.ToInt32(dt.Rows[0][0]);

            dt = mbd.selectionquery("select avg(price) from StroyMaterialZakaz join StroyMaterial on StroyMaterialZakaz.id_StroyMaterial =  StroyMaterial.id_stroy_mater join" +
                " zakaz on StroyMaterialZakaz.id_zakaz = zakaz.id_zakaz where month_zakaz = " + month);

            if (avg >= Convert.ToInt32(dt.Rows[0][0])/ countOrder)
            {
                if(countOrder <=5)
                {
                    s += dict[5] + "\r\n";
                }

                if (countOrder > 5)
                {
                    s +=dict[6]+ "\r\n";
                }

            }

            if (avg < Convert.ToInt32(dt.Rows[0][0]) / countOrder)
            {
                if (countOrder <= 5)
                {
                    s += dict[5]+"\r\n";
                }

                if (countOrder > 5)
                {
                    s += dict[6] + "\r\n"; 
                }
            }


                return s;
        }

    }
}
