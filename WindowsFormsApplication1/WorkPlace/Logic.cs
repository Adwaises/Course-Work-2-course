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
            "Дерево хорошо горит",
            "Металл не горит",
            "Дорогие товары качественные",
            "Товары из металла долго служат" };

        public List<string> list2 = new List<string>() {
            "Мебель сделана из дерева",
            "Техника сделана из металла",
            "Холодильник дорогой"};

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
