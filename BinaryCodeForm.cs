using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving {
    public partial class BinaryCodeForm : StartForm {
        public BinaryCodeForm() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowAllFilesCodeForm();
        }

        private void label3_MouseEnter(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label3_MouseLeave(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void label4_MouseEnter(object sender, EventArgs e) {
            panel3.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label4_MouseLeave(object sender, EventArgs e) {
            panel3.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void label2_MouseEnter(object sender, EventArgs e) {
        }

        private void label2_MouseLeave(object sender, EventArgs e) {
        }

        private void label4_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowBinaryEncoderForm();
        }
       
    }
}
