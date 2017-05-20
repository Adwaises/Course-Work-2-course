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
using LibDataForBD;
using LibReports;

namespace WorkPlace
{
    public partial class FDiagram : Form
    {
        Reports report = new Reports();
       
        public FDiagram()
        {
            InitializeComponent();
        }

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
            if (result == DialogResult.Yes)
            {
                Thread t = new Thread(diagr);
                t.Start();
                timer1.Start();
            }
        }

        private void Diagram_Load(object sender, EventArgs e)
        {
            PBDiagr.Image =  report.DrawGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataForBD.Iter == 0)
            {
                progressBar1.Value = 10;
            }
            else  if (DataForBD.Iter == 1)
            {
                progressBar1.Value = 25;
            }
            else if (DataForBD.Iter == 2)
            {
                progressBar1.Value = 40;
            }
            else if (DataForBD.Iter == 3)
            {
                progressBar1.Value = 55;
            }
            else if (DataForBD.Iter == 4)
            {
                progressBar1.Value = 70;
            }
            else if (DataForBD.Iter == 5)
            {
                progressBar1.Value = 90;
            }
            else if (DataForBD.Iter == 6)
            {
                timer1.Stop();
                progressBar1.Value = 100;
                DialogResult result1 = MessageBox.Show("Открыть папку?", "Диаграмма в Excel построена", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result1 == DialogResult.Yes)
                {
                    Process.Start("explorer", @"/select , " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\book.xlsx");
                }
            }
        }
    }
}
