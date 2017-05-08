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
    public partial class FormLoad : Form
    {
        SaveLoadOrder slo = new SaveLoadOrder();

        public FormLoad()
        {
            InitializeComponent();
            /*
            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CBorder.Items.Add("Заказ №" + dt.Rows[i][0] + "" + " Размеры:" + Convert.ToDouble( dt.Rows[i][1])/100 + "*" + Convert.ToDouble(dt.Rows[i][2])/100 +
                    "*" + Convert.ToDouble(dt.Rows[i][3])/100+ " Сумма:" + dt.Rows[i][6]);
            }
            */
            foreach (var n in slo.initCBOrder())
            {
                CBorder.Items.Add(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
            DataForBD.length = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][1]);
            DataForBD.width = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][2]);
            DataForBD.height = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][3]);
            DataForBD.summa = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][6]);
            DataForBD.idZakaz = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][0]);


            DataForBD.listZakazMebTeh.Clear();
            dt = mbd.selectionquery("select * from StroyMaterialZakaz where id_zakaz = "+ DataForBD.idZakaz+ ";");
            

            DataForBD.idOboi = Convert.ToInt32(dt.Rows[0][1]);
            DataForBD.idPlitka = Convert.ToInt32(dt.Rows[1][1]);

            dt = mbd.selectionquery("select * from FurnituraZakaz  where id_zakaz = " + DataForBD.idZakaz + ";");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataForBD.listZakazMebTeh.Add(new ObjFurnit(Convert.ToInt32( dt.Rows[i][0]) , Convert.ToInt32(dt.Rows[i][1]) ,
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
            */

            slo.loadOrder(CBorder.SelectedIndex);

            foreach(var n in DataForBD.listZakazMebTeh)
            {
                Console.WriteLine(n.IdFurnit +" "+ n.IdZakaz);
            }

            MessageBox.Show("Заказ загружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {

        }
    }
}
