using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project
{
    public partial class Form1 : Form
    {
        //Reports report = new Reports();
        ManagerBD mbd = new ManagerBD();
        public Form1()
        {
            InitializeComponent();


        }

        private void графическийОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diagram diag = new Diagram();
            diag.ShowDialog();
        }


        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormPDF pdf = new FormPDF();
            pdf.ShowDialog();

        }

        private void отправитьНаПочтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //report.blank(DataForBD.idZakaz);
            ToMail tm = new ToMail();
            tm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBD fBD = new FormBD();
            fBD.ShowDialog();
        }

        private void оформитьСохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSave fs = new FormSave();
            fs.ShowDialog();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad fl = new FormLoad();
            fl.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //присвоение id заказа
            //DataForBD.idZakaz = 1;
            mbd.Connection();
            DataTable dt1 = mbd.selectionquery("select * from zakaz;");

            DataForBD.idZakaz = 1;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt1.Rows[i][0]) > DataForBD.idZakaz)
                {
                    DataForBD.idZakaz = Convert.ToInt32(dt1.Rows[i][0]);
                }
            }
            DataForBD.idZakaz++;

        }


        private void продукцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profit pr = new Profit();
            pr.ShowDialog();
        }
    }
}
