using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using LibraryManagerBD;
using LibReports;


namespace WorkPlace
{
    public partial class FormPDF : Form
    {
        Reports report = new Reports();
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        public FormPDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                report.blank(Convert.ToInt32(dt.Rows[comboBox1.SelectedIndex][0]));
                DialogResult result = MessageBox.Show("Открыть?", "Отчет сформирован", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Process.Start("Document.pdf");
                }
            } else
            {
                MessageBox.Show("Выберите заказ","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormPDF_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add("Заказ №" + dt.Rows[i][0] + "" + " Размеры:" + Convert.ToDouble(dt.Rows[i][1]) / 100 
                    + "*" + Convert.ToDouble(dt.Rows[i][2]) / 100 +
                    "*" + Convert.ToDouble(dt.Rows[i][3]) / 100 + " Сумма:" + dt.Rows[i][6]);
            }
        }
    }
}
