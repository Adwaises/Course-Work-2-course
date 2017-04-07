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
    public partial class ToMail : Form
    {
        Mail mail = new Mail();
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        Reports report = new Reports();
        public ToMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            report.blank(Convert.ToInt32(dt.Rows[comboBox1.SelectedIndex][0]));
            try
            {
                mail.SendMail(textBox1.Text, Convert.ToInt32(dt.Rows[comboBox1.SelectedIndex][0]));

                //progressBar1.Value = 100;

                MessageBox.Show("Письмо отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введите правильный E-mail", "Ошибка: " + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ToMail_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(Convert.ToString(dt.Rows[i][0]) + " " + dt.Rows[i][1] + " " + dt.Rows[i][2] + " " + dt.Rows[i][3] + " " + dt.Rows[i][6]);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = mbd.selectionquery("select id_zakaz,mail from zakaz join customer on zakaz.id_customer = customer.id_customer;");
            textBox1.Text = Convert.ToString(dt1.Rows[comboBox1.SelectedIndex][1]);
        }
    }
}
