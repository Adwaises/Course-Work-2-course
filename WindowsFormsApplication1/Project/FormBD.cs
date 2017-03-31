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




        }

        private void FormBD_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select * from StroyMaterialZakaz where id_zakaz = 2;");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

        }
    }
}
