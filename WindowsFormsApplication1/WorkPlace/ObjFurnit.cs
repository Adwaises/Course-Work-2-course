using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class ObjFurnit
    {
        private int idZakaz;
        private int idFurnit;
        private double coordX;
        private double coordY;

        public ObjFurnit(int _idZakaz, int _idFurnit, double _coordX, double _coordY)
        {
            this.IdZakaz = _idZakaz;
            this.IdFurnit = _idFurnit;
            this.CoordX = _coordX;
            this.CoordY = _coordY;
        }

        public int IdZakaz
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

        public int IdFurnit
        {
            get
            {
                return idFurnit;
            }

            set
            {
                idFurnit = value;
            }
        }

        public double CoordX
        {
            get
            {
                return coordX;
            }

            set
            {
                coordX = value;
            }
        }

        public double CoordY
        {
            get
            {
                return coordY;
            }

            set
            {
                coordY = value;
            }
        }
    }
}
