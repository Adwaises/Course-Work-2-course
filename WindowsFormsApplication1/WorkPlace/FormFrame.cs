using LibInformation;
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
            Frame fr = new Frame();
            if (radioButton1.Checked)
            {
                pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 1);
            } else if (radioButton2.Checked)
            {
                pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 2);
            }
            else if (radioButton3.Checked)
            {
                pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 3);
            }
            else if (radioButton4.Checked)
            {
                pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 4);
            }
            else if (radioButton5.Checked)
            {
                pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 5);
            }


        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            Frame fr = new Frame();
            pictureBox1.Image = fr.draw(pictureBox1.Width, pictureBox1.Height, 0);
        }
    }
}
