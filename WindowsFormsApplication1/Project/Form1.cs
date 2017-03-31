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
        Reports report = new Reports();
        public Form1()
        {
            InitializeComponent();

            DataForBD.idZakaz = 2;

        }

        private void графическийОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diagram diag = new Diagram();
            diag.ShowDialog();
        }


        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
            report.blank(DataForBD.idZakaz);
            DialogResult result = MessageBox.Show("Открыть?", "Отчет сформирован", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes) //Если нажал Да
            {
                //отрытие документа программой по умолчанию
                Process.Start("Document.pdf");
            }
        }

        private void отправитьНаПочтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report.blank(DataForBD.idZakaz);
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
    }
}
