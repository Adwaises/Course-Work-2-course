using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Diagram : Form
    {
        Reports report = new Reports();
        public Diagram()
        {
            InitializeComponent();
            //label1.Text = "";
        }

        //Thread t = new Thread(report.ExcelDiagr());

        void diagr()
        {
            report.ExcelDiagr();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RBReceipt.Checked)
            {
                PBDiagr.Image = report.diagr(true);
                PBLegend.Image = report.vertLabelDiagr(true);
            }
            else if (RBCountOrders.Checked)
            {
                PBDiagr.Image = report.diagr(false);
                PBLegend.Image = report.vertLabelDiagr(false);
            }

            DialogResult result = MessageBox.Show("Построить в Excel?", "Диаграмма", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //Если нажал Да
            {
                //отрытие документа программой по умолчанию
                //Process.Start("Document.pdf");

                // System.Diagnostics.Stopwatch sw = new Stopwatch();
                // sw.Start();
                //label1.Text = "Построение отчета в Excel";
                //report.ExcelDiagr();
                Thread t = new Thread(diagr);
                t.Start();
                //обработать, когда звершится

                //progressBar1.Value = 100;
                //label1.Text = "";
                // sw.Stop();

                //MessageBox.Show("Диаграмма в Excel построена \r\nФайл находится в папке 'Мои документы'" ,
                  //  "Диаграмма", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult result1 = MessageBox.Show("Открыть папку?", "Диаграмма в Excel построена", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result1 == DialogResult.Yes) //Если нажал Да
                {
                    //отрытие документа программой по умолчанию
                    //Process.Start("Document.pdf");
                    //Process.Start("explorer", "C:\\");

                }

                /*
                result = MessageBox.Show("Желаете открыть?", "Диаграмма", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes) //Если нажал Да
                {
                    //string md = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//путь к Документам
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + " \\book.xlsx");
                }
                */

            }
        }

        private void Diagram_Load(object sender, EventArgs e)
        {
            PBDiagr.Image =  report.DrawGrid();

        }
    }
}
