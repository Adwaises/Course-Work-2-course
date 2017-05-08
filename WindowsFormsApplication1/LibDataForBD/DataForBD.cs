using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibObjFurnit;

namespace LibDataForBD
{
    public static class DataForBD
    {
        public static int valuePrBar = 0;

        public static int idZakaz;
        public static int length;
        public static int width;
        public static int height;
        public static int idCustomer;
        public static int summa;
        public static int mounth;

        public static string famil;
        public static string name;
        public static string otchestvo;
        public static string numTel;
        public static string mail;

        public static int idOboi;
        public static int idPlitka;

        public static List<ObjFurnit> listZakazMebTeh = new List<ObjFurnit>();

        public static int iter;

    }
}
