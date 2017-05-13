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
        "Плита будет размещена",
        "Стол будет размещен"};

        public List<string> list2 = new List<string>() {
        "Холодильник будет размещен",
        "Шкаф будет размещен",
        "Стул будет размещен"};

        private List<string> listSint = new List<string>()
        {
            "должны располагаться подальше друг от друга",
            "должны располагаться рядом"
        };

        string s = "";

        public string result(string num1, string num2)
        {
            s = num1 + " и " + num2 + " ";
            string tmp = predicat(num1, num2);
            if (tmp !="0") {
                s += tmp;
                return s;
            } else
            {
                return "Выбранные суждения разного рода";
            }
        }

        public string predicat(string str1, string str2)
        {
            if(str1 == "Плита" && str2 == "Холодильник" || str1 == "Плита" && str2 == "Шкаф" ||
                str1 == "Стол" && str2 == "Холодильник" || str1 == "Стол" && str2 == "Шкаф")
            {
                return listSint[0] ;
            } else if (str1 == "Стол" && str2 == "Стул")
            {
                return listSint[1];
            } else
            {
                return "0";
            }
        }
    }
}
