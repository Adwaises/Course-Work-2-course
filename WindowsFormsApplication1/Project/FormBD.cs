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
            DataForBD.id_zakaz = 2;
            DataForBD.length = 400;
            DataForBD.width = 400;
            DataForBD.height = 250;

            //


        }

        private void FormBD_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select * from Zakaz;");
            dataGridView1.DataSource = dt;
        }
    }
}
