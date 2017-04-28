using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;

using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ManagerBD mbd = new ManagerBD();
        Reports report = new Reports();
        public Form1()
        {
            InitializeComponent();

            
        }


        public void diagr()
        {

            if (checkBox1.Checked)
            {
                pictureBox1.Image = report.diagr(true);
                pictureBox3.Image = report.vertLabelDiagr(true);
            }
            else if (checkBox2.Checked)
            {
                pictureBox1.Image = report.diagr(false);
                pictureBox3.Image = report.vertLabelDiagr(false);
            }
            report.ExcelDiagr();
            MessageBox.Show("OK");
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            mbd.Connection();
            //mbd.controlquery("ALTER TABLE zakaz add summa Integer;");
            //mbd.controlquery("update zakaz set summa = 150000 where id_zakaz =1;");

            //DataTable dt = mbd.selectionquery("Select * from zakaz;");

            DataTable dt = mbd.Statistic();

            //var n = dt.Rows[0][0]; // получаю ячейку
            //textBox1.Text = n.ToString();


            dataGridView1.DataSource = dt;



            
            //отчет
            
            report.blank();
            DialogResult result = MessageBox.Show("Открыть?", "Отчет сформирован", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            if (result == DialogResult.Yes) //Если нажал Да
            {
                //отрытие документа программой по умолчанию
                Process.Start("Document.pdf");
            }

            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отправка на почту
            Mail mail = new Mail();
            mail.SendMail();
            MessageBox.Show("Письмо отправлено","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            diagr();
        }
    }
}
