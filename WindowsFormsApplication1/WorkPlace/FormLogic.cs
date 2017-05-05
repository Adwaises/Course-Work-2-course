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
        public FormLogic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic log = new Logic();
            textBox1.Text = log.result(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
        }

        private void FormLogic_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Дерево хорошо горит");
            comboBox2.Items.Add("Мебель сделана из дерева");

            comboBox1.Items.Add("Металл не горит");
            comboBox2.Items.Add("Техника сделана из металла");

            comboBox1.Items.Add("Дорогие товары качественные");
            comboBox2.Items.Add("Холодильник дорогой");

            comboBox1.Items.Add("Товары из металла долго служат");
        }
    }
}
