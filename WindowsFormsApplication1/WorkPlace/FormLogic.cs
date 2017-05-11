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
    public partial class FormLogic : Form
    {
        Logic log = new Logic();
        public FormLogic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = comboBox1.SelectedItem.ToString();
            string str2 = comboBox2.SelectedItem.ToString();

            string[] str1Mas = str1.Split(' ');
            string[] str2Mas = str2.Split(' ');

            textBox1.Text = log.result(str1Mas[0], str2Mas[0]);
        }

        private void FormLogic_Load(object sender, EventArgs e)
        {
            foreach(var n in log.list1) {
                comboBox1.Items.Add(n);
            }
            foreach (var n in log.list2)
            {
                comboBox2.Items.Add(n);
            }
        }
    }
}
