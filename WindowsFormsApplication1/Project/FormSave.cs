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
    public partial class FormSave : Form
    {
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
       // DataTable dt1;
        public FormSave()
        {
            InitializeComponent();


            //заполнение стат класса (тестово)
            //заказ
            
            DataForBD.length = 400;
            DataForBD.width = 400;
            DataForBD.height = 300;
            //DataForBD.idCustomer = 1;

            //DataForBD.summa = 75000; // нужно рассчитать // вызвать report , он закинет в стат класс и оттуда взять уже сумму
            

            DateTime data = DateTime.Now;
            DataForBD.mounth = data.Month;
            // заказчик если есть


            mbd.Connection();
            dt = mbd.selectionquery("select * from customer;");
            for (int i=0; i<dt.Rows.Count; i++) {
                CBCustomer.Items.Add(Convert.ToString(dt.Rows[i][1]) +" "+ dt.Rows[i][2] +" "+ dt.Rows[i][3] + " " + dt.Rows[i][4]);
            }

            


            // список заказ_строймат
            DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",12");
            DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",22");
            // список заказ_мебтех
            DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",11,1");
            DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,1");
            DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,1");
            DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,1");
            DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,1");

        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            if(RBSelect.Checked)
            {
                DataForBD.idCustomer = Convert.ToInt32( dt.Rows[CBCustomer.SelectedIndex][0]);
            } else if(RBNew.Checked)
            {
                // поиск макс (присвоение id)
                DataForBD.idCustomer = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(Convert.ToInt32(dt.Rows[i][0]) > DataForBD.idCustomer)
                    {
                        DataForBD.idCustomer = Convert.ToInt32(dt.Rows[i][0]);
                    }
                }
                DataForBD.idCustomer++;

                DataForBD.famil = TBFamil.Text;
                DataForBD.name = TBName.Text;
                DataForBD.otchestvo = TBOtch.Text;
                DataForBD.numTel = TBTel.Text;
                DataForBD.mail = TBmail.Text;

            }

            //dt.Rows[0][0];
            //dataGridView1.DataSource = dt;

            // вставка заказчика
            if (RBNew.Checked)
            {
                mbd.controlquery("insert into 'customer' (id_customer, Famil ,Name , otchestvo , num_tel, mail )" +
                    "values (" + DataForBD.idCustomer.ToString() + ", '" + DataForBD.famil + "' ,'" + DataForBD.name +
                    "','" + DataForBD.otchestvo + "', " + DataForBD.numTel + " , '" + DataForBD.mail + "' )");
            }

            // вставка в заказ стр мат
            foreach (var n in DataForBD.listZakazStroyMat)
            {
                mbd.controlquery("insert into StroyMaterialZakaz values ( " + Convert.ToString(n) + ");");
            }

            // вставка в фурнит

            foreach (var n in DataForBD.listZakazMebTeh)
            {
                mbd.controlquery("insert into FurnituraZakaz  values ( " + Convert.ToString(n) + ");");
            }

            //вставка в заказ

            //присвоение id заказа


            mbd.controlquery("insert into Zakaz  values (" + DataForBD.idZakaz.ToString() + ", " + DataForBD.length.ToString()
                + " ," + DataForBD.width.ToString() + " ," + DataForBD.height.ToString() + " ," + DataForBD.idCustomer.ToString()
                + " ," + DataForBD.mounth.ToString() + " ," + DataForBD.summa.ToString() + ")");

            Reports rep = new Reports();
            rep.blank(DataForBD.idZakaz);
            mbd.controlquery("update zakaz set summa = " + Convert.ToString(DataForBD.summa) + " where id_zakaz = " + Convert.ToString(DataForBD.idZakaz));

            MessageBox.Show("OK");
        }
    }
}
