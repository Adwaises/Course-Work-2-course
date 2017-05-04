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
    public partial class FormFrame : Form
    {
        public FormFrame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            Frame fr = new Frame();

            pictureBox1.Image = fr.drawStruct(pictureBox1.Width, pictureBox1.Height);

        }
    }
}
