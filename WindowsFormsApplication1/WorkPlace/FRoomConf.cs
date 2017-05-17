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
using LibDataForBD;

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
            tBHeigth.Text = (room.height/2).ToString();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                room.length = 2 * Convert.ToDouble(tBLength.Text);
                room.width = 2 * Convert.ToDouble(tBWidth.Text);
                room.height = 2*Convert.ToDouble(tBHeigth.Text);

                /*-------------Взаимодействие с БД (тем классом)------------------*/
                DataForBD.Length = Convert.ToInt32(room.length/2 * 100);
                DataForBD.Width = Convert.ToInt32(room.width/2 * 100);
                DataForBD.Height = Convert.ToInt32(room.height * 100);
                /*----------------------------------------------------------------*/

                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRoomConf_Load(object sender, EventArgs e)
        {

        }
    }
}
