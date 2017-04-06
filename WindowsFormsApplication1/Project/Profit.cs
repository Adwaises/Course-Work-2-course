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
    public partial class Profit : Form
    {
        public Profit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Profit_Load(object sender, EventArgs e)
        {
            for(int i=1;i<=12;i++)
            {
                comboBox1.Items.Add(i);
            }
        }
    }
}
