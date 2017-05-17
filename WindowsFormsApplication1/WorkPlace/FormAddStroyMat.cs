using LibraryManagerBD;
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
    public partial class FormAddStroyMat : Form
    {
        ManagerBD mbd = new ManagerBD();
        public FormAddStroyMat()
        {
            InitializeComponent();
        }

        private void FormAddStroyMat_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select * from StroyMaterial; ");
            dataGridView1.DataSource = dt;
            cbType.Items.Add("plitka");
            cbType.Items.Add("oboi");
            cbType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbId.Text);
                string type = cbType.SelectedItem.ToString();
                string naz = tbNaz.Text;
                int w = Convert.ToInt32( tbW.Text);
                int price = Convert.ToInt32(tbPrice.Text);

                mbd.controlquery("Insert into StroyMaterial values (" + id + ", '" + type + "', '" + naz + "', " + w + ", " + price + ");");
                MessageBox.Show("Добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mbd.selectionquery("select * from StroyMaterial; ");
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbId2.Text);
                mbd.controlquery("Delete from StroyMaterial where id_stroy_mater  = " + id + ";");
                MessageBox.Show("Удалено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mbd.selectionquery("select * from StroyMaterial; ");
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
