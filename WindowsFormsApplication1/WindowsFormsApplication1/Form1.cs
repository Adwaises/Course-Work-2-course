using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;

using System.Net.Mime;
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
            //mbd.controlquery("ALTER TABLE zakaz add summa Integer;");
            //mbd.controlquery("update zakaz set summa = 150000 where id_zakaz =1;");

            DataTable dt = mbd.selectionquery("Select * from zakaz;");


            //var n = dt.Rows[0][0]; // получаю ячейку
            //textBox1.Text = n.ToString();


            dataGridView1.DataSource = dt;
            //отчет
            Reports report = new Reports();
            report.blank();
            MessageBox.Show("Отчет сформирован","Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);
           

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отправка на почту
            Mail mail = new Mail();
            mail.SendMail();
            MessageBox.Show("Письмо отправлено","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
