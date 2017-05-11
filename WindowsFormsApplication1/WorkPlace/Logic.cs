using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class Logic
    {
        public List<string> list1 = new List<string>() {
            
            "Дорогие товары качественные",
            "Товары из металла долго служат",
        "Размещение плиты",
        "Размещение стола"};

        public List<string> list2 = new List<string>() {
            
            "Техника сделана из металла",
            "Холодильник дорогой",
        "Размещение холодильника",
        "Размещение шкафа",
        "Размещение стульев"};

        public string result(int num1, int num2)
        {
            if (num1 == 0 && num2 == 1)
            {
                return "Холодильник качественный";
            }
            else if (num1 == 1 && num2 == 0)
            {
                return "Техника будет служить долго";
            }
            else if (num1 == 2 && num2 == 2)
            {
                return "Плиту и холодильник лучше не ставить вместе";
            }
            else if (num1 == 2 && num2 == 3)
            {
                return "Плиту и шкаф лучше не ставить вместе";
            }
            else if (num1 == 3 && num2 == 4)
            {
                return "Стол и стул лучше ставить вместе";
            }
            else if (num1 == 3 && num2 == 2)
            {
                return "Холодильник у стола лучше не ставить";
            }
            else if (num1 == 5 && num2 == 4)
            {
                return "Шкаф у стола лучше не ставить";
            }

            return "Выбранные суждения разного рода";
        }
    }
}
