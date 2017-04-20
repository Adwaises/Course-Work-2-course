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
