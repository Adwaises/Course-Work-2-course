using ObjectsControl;
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
    public partial class FRoomConf : Form
    {
        private Room room;
        public FRoomConf(ref Room room)
        {
            InitializeComponent();
            this.room = room;
            butCancle.Click += (object sender, EventArgs e) => { Close(); };

            tBLength.Text = (room.length/2).ToString();
            tBWidth.Text = (room.width/2).ToString();
            tBHeigth.Text = room.height.ToString();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                room.length = 2 * Convert.ToDouble(tBLength.Text);
                room.width = 2 * Convert.ToDouble(tBWidth.Text);
                room.height = Convert.ToDouble(tBHeigth.Text);
                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
