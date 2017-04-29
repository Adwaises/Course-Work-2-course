using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    static class DataForBD
    {
        public static int valuePrBar = 0;

        //заказ
        public static int idZakaz;
        public static int length;
        public static int width;
        public static int height;
        public static int idCustomer;
        public static int summa;
        public static int mounth;
        //заказчик если нет в таблице (нужно проверить)
        public static string famil;
        public static string name;
        public static string otchestvo;
        public static string numTel;
        public static string mail;


        //public static List<string> listZakazStroyMat = new List<string>();
        public static int idOboi;
        public static int idPlitka; 


        public static List<ObjFurnit> listZakazMebTeh = new List<ObjFurnit>();



        public static int iter;

    }
}
