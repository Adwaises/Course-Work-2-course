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
        static int valuePrBar = 0;

        static int idZakaz;
        static int length;
        static int width;
        static int height;
        static int idCustomer;
        static int summa;
        static int mounth;

        static string famil;
        static string name;
        static string otchestvo;
        static string numTel;
        static string mail;

        static int idOboi;
        static int idPlitka;

        static List<ObjFurnit> listZakazMebTeh = new List<ObjFurnit>();

        static int iter;

        public static int ValuePrBar
        {
            get
            {
                return valuePrBar;
            }

            set
            {
                valuePrBar = value;
            }
        }

        public static int IdZakaz
        {
            get
            {
                return idZakaz;
            }

            set
            {
                idZakaz = value;
            }
        }

        public static int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public static int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public static int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public static int IdCustomer
        {
            get
            {
                return idCustomer;
            }

            set
            {
                idCustomer = value;
            }
        }

        public static int Summa
        {
            get
            {
                return summa;
            }

            set
            {
                summa = value;
            }
        }

        public static int Mounth
        {
            get
            {
                return mounth;
            }

            set
            {
                mounth = value;
            }
        }

        public static string Famil
        {
            get
            {
                return famil;
            }

            set
            {
                famil = value;
            }
        }

        public static string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public static string Otchestvo
        {
            get
            {
                return otchestvo;
            }

            set
            {
                otchestvo = value;
            }
        }

        public static string NumTel
        {
            get
            {
                return numTel;
            }

            set
            {
                numTel = value;
            }
        }

        public static string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public static int IdOboi
        {
            get
            {
                return idOboi;
            }

            set
            {
                idOboi = value;
            }
        }

        public static int IdPlitka
        {
            get
            {
                return idPlitka;
            }

            set
            {
                idPlitka = value;
            }
        }

        public static List<ObjFurnit> ListZakazMebTeh
        {
            get
            {
                return listZakazMebTeh;
            }

            set
            {
                listZakazMebTeh = value;
            }
        }

        public static int Iter
        {
            get
            {
                return iter;
            }

            set
            {
                iter = value;
            }
        }
    }
}
