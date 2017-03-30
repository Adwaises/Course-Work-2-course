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
        public ToMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                mail.SendMail(textBox1.Text);

                //progressBar1.Value = 100;

                MessageBox.Show("Письмо отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введите правильный E-mail", "Ошибка: " + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
