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
    public partial class Semantic : Form
    {
        public Semantic()
        {
            InitializeComponent();
        }

        private void Semantic_Load(object sender, EventArgs e)
        {
            SemanticNetworks sn = new SemanticNetworks();
            textBox1.Text =  sn.analis();
            textBox1.SelectionStart = textBox1.Text.Length ;
            textBox1.ScrollBars = ScrollBars.Vertical;
        }
    }
}
