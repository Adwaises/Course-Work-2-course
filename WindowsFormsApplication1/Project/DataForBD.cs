using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    static class DataForBD
    {
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
        public static string num_tel;
        public static string mail;

        public static List<string> listZakazStroyMat = new List<string>();
        public static List<string> listZakazMebTeh = new List<string>();

    }
}
