using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WorkPlace
{
    public partial class FormSave : Form
    {
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        DataTable dt1;
        // DataTable dt1;
        public FormSave()
        {
            InitializeComponent();


            //заполнение стат класса (тестово)
            //заказ
            
            DataForBD.length = 400;
            DataForBD.width = 300;
            DataForBD.height = 250;
            //DataForBD.idCustomer = 1;

            //DataForBD.summa = 75000; // нужно рассчитать // вызвать report , он закинет в стат класс и оттуда взять уже сумму
            

            DateTime data = DateTime.Now;
            DataForBD.mounth = data.Month;
           // DataForBD.mounth = 3;
            // заказчик если есть


            mbd.Connection();
            dt = mbd.selectionquery("select * from customer;");
            for (int i=0; i<dt.Rows.Count; i++) {
                CBCustomer.Items.Add(Convert.ToString(dt.Rows[i][1]) +" "+ dt.Rows[i][2] +" "+ dt.Rows[i][3] + " " + dt.Rows[i][4]);
            }

            dt1 = mbd.selectionquery("select * from zakaz;");
            // поиск макс (присвоение id)
            DataForBD.idZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idCustomer)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;


            // список заказ_строймат
            //DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",12");
            //DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",22");
            DataForBD.idOboi = 12;
            DataForBD.idPlitka = 22;
            // список заказ_мебтех
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz,21,1,1));//стол

            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",11,2");
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",11,3");
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",31,4"); //шкаф
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",31,5");

            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",41,6"); //плита
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",41,7");

            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",51,8"); //вытяжка
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",51,9");
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",51,10");

            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",61,11"); //холодильник
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz, 61, 3, 3));
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz, 61, 4, 3));
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz, 61, 5, 3));
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz, 61, 3, 5));

            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz, 21, 2, 2)); // стул
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,21");
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,22");
            //DataForBD.listZakazMebTeh.Add(DataForBD.idZakaz + ",21,23");
            
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            

            if (RBSelect.Checked)
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
            /*foreach (var n in DataForBD.listZakazStroyMat)
            {
                mbd.controlquery("insert into StroyMaterialZakaz values ( " + Convert.ToString(n) + ");");
            }
            */

            mbd.controlquery("insert into StroyMaterialZakaz values ( " +DataForBD.idZakaz+","+DataForBD.idOboi + ");");
            mbd.controlquery("insert into StroyMaterialZakaz values ( " + DataForBD.idZakaz + "," + DataForBD.idPlitka + ");");

            // вставка в фурнит

            foreach (var n in DataForBD.listZakazMebTeh)
            {
                mbd.controlquery("insert into FurnituraZakaz  values ( " +n.IdZakaz +","+ n.IdFurnit+"," +n.CoordX + "," + n.CoordY+");");
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

        private void FormSave_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idCustomer)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;

        }
    }
}
