using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlace
{
    class SaveLoadOrder
    {
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        DataTable dt1;

        public void saveOrder(int rbNum,int index, string famil, string name, string otch, string numTel, string mail)
        {
            if (rbNum == 1)
            {
                DataForBD.idCustomer = Convert.ToInt32(dt.Rows[index][0]);
            }
            else if (rbNum ==2)
            {
                // поиск макс (присвоение id)
                DataForBD.idCustomer = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][0]) > DataForBD.idCustomer)
                    {
                        DataForBD.idCustomer = Convert.ToInt32(dt.Rows[i][0]);
                    }
                }
                DataForBD.idCustomer++;

                DataForBD.famil = famil;
                DataForBD.name = name;
                DataForBD.otchestvo = otch;
                DataForBD.numTel = numTel; ;
                DataForBD.mail = mail;

            }


            // вставка заказчика
            if (rbNum == 2)
            {
                mbd.controlquery("insert into 'customer' (id_customer, Famil ,Name , otchestvo , num_tel, mail )" +
                    "values (" + DataForBD.idCustomer.ToString() + ", '" + DataForBD.famil + "' ,'" + DataForBD.name +
                    "','" + DataForBD.otchestvo + "', " + DataForBD.numTel + " , '" + DataForBD.mail + "' )");
            }


            mbd.controlquery("insert into StroyMaterialZakaz values ( " + DataForBD.idZakaz + "," + DataForBD.idOboi + ");");
            mbd.controlquery("insert into StroyMaterialZakaz values ( " + DataForBD.idZakaz + "," + DataForBD.idPlitka + ");");

            // вставка в фурнит

            foreach (var n in DataForBD.listZakazMebTeh)
            {
                mbd.controlquery("insert into FurnituraZakaz  values ( " + n.IdZakaz + "," + n.IdFurnit + "," + n.CoordX + "," + n.CoordY + ");");
            }

            //вставка в заказ

            //присвоение id заказа


            mbd.controlquery("insert into Zakaz  values (" + DataForBD.idZakaz.ToString() + ", " + DataForBD.length.ToString()
                + " ," + DataForBD.width.ToString() + " ," + DataForBD.height.ToString() + " ," + DataForBD.idCustomer.ToString()
                + " ," + DataForBD.mounth.ToString() + " ," + DataForBD.summa.ToString() + ")");

            Reports rep = new Reports();
            rep.blank(DataForBD.idZakaz);
            mbd.controlquery("update zakaz set summa = " + Convert.ToString(DataForBD.summa) + " where id_zakaz = " + Convert.ToString(DataForBD.idZakaz));
        }

        public void initIdOrder()
        {
            mbd.Connection();
            dt1 = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idCustomer)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;
        }

        public List<string> initCBCustomer()
        {
            List<string> list = new List<string>();

            mbd.Connection();
            dt = mbd.selectionquery("select * from customer;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(Convert.ToString(dt.Rows[i][1]) + " " + dt.Rows[i][2] + " " + dt.Rows[i][3] + " " + dt.Rows[i][4]);
            }

            return list;
        }

        // для сохранения

        public List<string> initCBOrder()
        {
            List<string> list = new List<string>();

            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add("Заказ №" + dt.Rows[i][0] + "" + " Размеры:" + Convert.ToDouble(dt.Rows[i][1]) / 100 + "*" + Convert.ToDouble(dt.Rows[i][2]) / 100 +
                    "*" + Convert.ToDouble(dt.Rows[i][3]) / 100 + " Сумма:" + dt.Rows[i][6]);
            }

            return list;
        }

        public void loadOrder(int index)
        {
            dt = mbd.selectionquery("select * from zakaz;");
            DataForBD.length = Convert.ToInt32(dt.Rows[index][1]);
            DataForBD.width = Convert.ToInt32(dt.Rows[index][2]);
            DataForBD.height = Convert.ToInt32(dt.Rows[index][3]);
            DataForBD.summa = Convert.ToInt32(dt.Rows[index][6]);
            DataForBD.idZakaz = Convert.ToInt32(dt.Rows[index][0]);


            DataForBD.listZakazMebTeh.Clear();
            dt = mbd.selectionquery("select * from StroyMaterialZakaz where id_zakaz = " + DataForBD.idZakaz + ";");


            DataForBD.idOboi = Convert.ToInt32(dt.Rows[0][1]);
            DataForBD.idPlitka = Convert.ToInt32(dt.Rows[1][1]);

            dt = mbd.selectionquery("select * from FurnituraZakaz  where id_zakaz = " + DataForBD.idZakaz + ";");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataForBD.listZakazMebTeh.Add(new ObjFurnit(Convert.ToInt32(dt.Rows[i][0]), Convert.ToInt32(dt.Rows[i][1]),
                    Convert.ToInt32(dt.Rows[i][2]), Convert.ToInt32(dt.Rows[i][3])));

            }

            //наверное нужно присвоить новый id, т к пользователь будет изменять
            // поиск макс (присвоение id)

            DataTable dt1 = mbd.selectionquery("select * from zakaz;");
            DataForBD.idZakaz = 1;
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
