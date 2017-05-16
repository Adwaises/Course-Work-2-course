using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDataForBD;


namespace WorkPlace
{
    public partial class FormSave : Form
    {
        SaveLoadOrder slo = new SaveLoadOrder();

        public FormSave()
        {
            InitializeComponent();


            //заполнение стат класса (тестово)
            //заказ
            /*
            DataForBD.length = 400;
            DataForBD.width = 300;
            DataForBD.height = 250;
            */
            
            

            DateTime data = DateTime.Now;
            DataForBD.Mounth = data.Month;
            // заказчик если есть
            /*
            mbd.Connection();
            dt = mbd.selectionquery("select * from customer;");
            for (int i=0; i<dt.Rows.Count; i++) {
                CBCustomer.Items.Add(Convert.ToString(dt.Rows[i][1]) +" "+ dt.Rows[i][2] +" "+ dt.Rows[i][3] + " " + dt.Rows[i][4]);
            }
            */
            foreach (var n in slo.initCBCustomer())
            {
                CBCustomer.Items.Add(n);
            }

            
            // поиск макс (присвоение id)
            /*
            DataForBD.idZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idCustomer)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;
            **/

            // список заказ_строймат
            //DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",12");
            //DataForBD.listZakazStroyMat.Add(DataForBD.idZakaz + ",22");
            DataForBD.IdOboi = 12;
            DataForBD.IdPlitka = 22;
            // список заказ_мебтех
            //DataForBD.listZakazMebTeh.Add(new ObjFurnit(DataForBD.idZakaz,21,1,1));//стул

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
                if (CBCustomer.SelectedIndex != -1) {
                    slo.saveOrder(1, CBCustomer.SelectedIndex, TBFamil.Text, TBName.Text, TBOtch.Text, TBTel.Text, TBmail.Text);
                    slo.initIdOrder();
                    MessageBox.Show("Заказ оформлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (RBNew.Checked)
            {
                try
                {
                    slo.saveOrder(2, CBCustomer.SelectedIndex, TBFamil.Text, TBName.Text, TBOtch.Text, TBTel.Text, TBmail.Text);
                    slo.initIdOrder();
                    MessageBox.Show("Заказ оформлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch
                {
                    MessageBox.Show("Введите верные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            /*
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


            // вставка заказчика
            if (RBNew.Checked)
            {
                mbd.controlquery("insert into 'customer' (id_customer, Famil ,Name , otchestvo , num_tel, mail )" +
                    "values (" + DataForBD.idCustomer.ToString() + ", '" + DataForBD.famil + "' ,'" + DataForBD.name +
                    "','" + DataForBD.otchestvo + "', " + DataForBD.numTel + " , '" + DataForBD.mail + "' )");
            }


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
            */
            
        }

        private void FormSave_FormClosed(object sender, FormClosedEventArgs e)
        {
            slo.initIdOrder();

        }

        private void FormSave_Load(object sender, EventArgs e)
        {

        }
    }
}
