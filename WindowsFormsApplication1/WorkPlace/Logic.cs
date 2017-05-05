using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class Logic
    {

        public string result(int num1, int num2)
        {
            if(num1 == 0 && num2 == 0)
            {
                return "Мебель хорошо горит. Берегитесь пожара";
            } else if (num1 == 1 && num2 == 1)
            {
                return "Техника не горит, но пожар может её испортить";
            }
            else if (num1 == 2 && num2 == 2)
            {
                return "Холодильник качественный";
            }
            else if (num1 == 3 && num2 == 1)
            {
                return "Техника будет служить долго";
            }

            return "Выбранные суждения разного рода";
        }

    }
}
