using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ManagerBD mbd = new ManagerBD();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mbd.Connection();
            DataTable dt = mbd.selectionquery("Select * from FurnituraZakaz;");
            var n =  dt.Rows[0][1]; // получаю ячейку
            textBox1.Text = n.ToString();
            dataGridView1.DataSource = dt;

        }
    }
}
