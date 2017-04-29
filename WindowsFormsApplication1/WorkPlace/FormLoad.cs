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
    public partial class FormLoad : Form
    {
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        public FormLoad()
        {
            InitializeComponent();

            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CBorder.Items.Add(dt.Rows[i][0] + " " + dt.Rows[i][1] + " " + dt.Rows[i][2] + " " + dt.Rows[i][3]+ " " + dt.Rows[i][6]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            DataForBD.length = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][1]);
            DataForBD.width = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][2]);
            DataForBD.height = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][3]);
            DataForBD.summa = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][6]);
            DataForBD.idZakaz = Convert.ToInt32(dt.Rows[CBorder.SelectedIndex][0]);


            DataForBD.listZakazMebTeh.Clear();
            //DataForBD.listZakazStroyMat.Clear();
            dt = mbd.selectionquery("select * from StroyMaterialZakaz where id_zakaz = "+ DataForBD.idZakaz+ ";");
            //for(int i=0; i< dt.Rows.Count;i++)
            //{
            // DataForBD.listZakazStroyMat.Add(dt.Rows[i][0] + "," + dt.Rows[i][1]);
            //}

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
            DataForBD.idCustomer = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i][0]) > DataForBD.idCustomer)
                {
                    DataForBD.idCustomer = Convert.ToInt32(dt.Rows[i][0]);
                }
            }
            DataForBD.idCustomer++;


            MessageBox.Show("Загружено");
        }
    }
}
