﻿using System;
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
    public partial class Profit : Form
    {
        public Profit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ManagerBD mbd = new ManagerBD();
            mbd.Connection();
            DataTable dt = mbd.selectionquery("select count(*) from zakaz where month_zakaz = " + Convert.ToString(comboBox1.SelectedItem));
            if (Convert.ToInt32( dt.Rows[0][0] ) !=0) {
                ProfitAnalysis pa = new ProfitAnalysis();
                textBox1.Text = pa.Analis(Convert.ToInt32(comboBox1.SelectedItem));
            } else
            {
                textBox1.Text = "В этом месяце не было заказов";
            }
        }

        private void Profit_Load(object sender, EventArgs e)
        {
            for(int i=1;i<=12;i++)
            {
                comboBox1.Items.Add(i);
            }
        }
    }
}
