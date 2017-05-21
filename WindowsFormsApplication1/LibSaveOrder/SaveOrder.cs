using LibDataForBD;
using LibraryManagerBD;
using LibReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSaveOrder
{
    public class SaveOrder
    {
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        DataTable dt1;

        public void saveOrder(int rbNum, int index, string famil, string name, string otch, string numTel, string mail)
        {
            if (rbNum == 1)
            {
                DataForBD.IdCustomer = Convert.ToInt32(dt.Rows[index][0]);
            }
            else if (rbNum == 2)
            {
                DataForBD.IdCustomer = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][0]) > DataForBD.IdCustomer)
                    {
                        DataForBD.IdCustomer = Convert.ToInt32(dt.Rows[i][0]);
                    }
                }
                DataForBD.IdCustomer++;

                DataForBD.Famil = famil;
                DataForBD.Name = name;
                DataForBD.Otchestvo = otch;
                DataForBD.NumTel = numTel; ;
                DataForBD.Mail = mail;
            }
            if (rbNum == 2)
            {
                mbd.controlquery("insert into 'customer' (id_customer, Famil ,Name , otchestvo , num_tel, mail )" +
                    "values (" + DataForBD.IdCustomer.ToString() + ", '" + DataForBD.Famil + "' ,'" + DataForBD.Name +
                    "','" + DataForBD.Otchestvo + "', " + DataForBD.NumTel + " , '" + DataForBD.Mail + "' )");
            }
            mbd.controlquery("insert into StroyMaterialZakaz values ( " + DataForBD.IdZakaz + "," + DataForBD.IdOboi + ");");
            mbd.controlquery("insert into StroyMaterialZakaz values ( " + DataForBD.IdZakaz + "," + DataForBD.IdPlitka + ");");
            foreach (var n in DataForBD.ListZakazMebTeh)
            {
                mbd.controlquery("insert into FurnituraZakaz  values ( " + n.IdZakaz + "," + n.IdFurnit + "," + n.CoordX + "," + n.CoordY + ");");
            }
            mbd.controlquery("insert into Zakaz  values (" + DataForBD.IdZakaz.ToString() + ", " + DataForBD.Length.ToString()
                + " ," + DataForBD.Width.ToString() + " ," + DataForBD.Height.ToString() + " ," + DataForBD.IdCustomer.ToString()
                + " ," + DataForBD.Mounth.ToString() + " ," + DataForBD.Summa.ToString() + ")");
            Reports rep = new Reports();
            rep.blank(DataForBD.IdZakaz);
            mbd.controlquery("update zakaz set summa = " + Convert.ToString(DataForBD.Summa) + " where id_zakaz = " + Convert.ToString(DataForBD.IdZakaz));
        }

        public void initIdOrder()
        {
            mbd.Connection();
            dt1 = mbd.selectionquery("select * from zakaz;");
            DataForBD.IdZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.IdZakaz)
                {
                    DataForBD.IdZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.IdZakaz++;
        }

        public List<string> initCBCustomer()
        {
            List<string> list = new List<string>();
            mbd.Connection();
            dt = mbd.selectionquery("select * from customer;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(Convert.ToString(dt.Rows[i][1]) + " " + dt.Rows[i][2] + " " + dt.Rows[i][3] + " Номер:" + dt.Rows[i][4]);
            }
            return list;
        }

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
    }
}
