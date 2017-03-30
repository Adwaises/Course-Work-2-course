using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FormBD : Form
    {
        ManagerBD mbd = new ManagerBD();
        public FormBD()
        {
            InitializeComponent();


            //заполнение стат класса
            //заказ
            DataForBD.idZakaz = 2;
            DataForBD.length = 400;
            DataForBD.width = 400;
            DataForBD.height = 250;
            DataForBD.idCustomer = 1;
            DataForBD.summa = 75000; // нужно рассчитать
            DataForBD.mounth = 2;
            // заказчик если есть

            // список заказ_строймат
            DataForBD.listZakazStroyMat.Add("2,12");
            DataForBD.listZakazStroyMat.Add("2,22");
            // список заказ_мебтех
            DataForBD.listZakazMebTeh.Add("2,11,1");
            DataForBD.listZakazMebTeh.Add("2,21,1");
            DataForBD.listZakazMebTeh.Add("2,21,1");
            DataForBD.listZakazMebTeh.Add("2,21,1");
            DataForBD.listZakazMebTeh.Add("2,21,1");

        }

        private void FormBD_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select * from zakaz ;");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // вставка в заказ стр мат
            /*
            foreach (var n in DataForBD.listZakazStroyMat) {
                mbd.controlquery("insert into StroyMaterialZakaz values ( "+Convert.ToString(n) +");");
            }
            */
            // вставка в фурнит
            /*
            foreach (var n in DataForBD.listZakazMebTeh)
            {
                mbd.controlquery("insert into FurnituraZakaz  values ( " + Convert.ToString(n) + ");");
            }
            */
            //вставка в заказ
            /*
            mbd.controlquery("insert into Zakaz  values (" + DataForBD.idZakaz.ToString() + ", "+ DataForBD.length.ToString()
                + " ," + DataForBD.width.ToString() + " ," + DataForBD.height.ToString() + " ," + DataForBD.idCustomer.ToString() 
                + " ," + DataForBD.mounth.ToString() + " ," + DataForBD.summa.ToString() + ")");
                */
            

        }
    }
}
