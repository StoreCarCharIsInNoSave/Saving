using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving
{
    public partial class MainChoseForm : StartForm
    {

        public MainChoseForm()
        {
            InitializeComponent();
        }

      
      

        private void panel1_MouseEnter(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void panel1_MouseLeave(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;

        }

        private void panel2_MouseEnter(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOn;

        }

        private void panel2_MouseLeave(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOff;

        }

        private void panel3_MouseEnter(object sender, EventArgs e) {
            panel3.BackgroundImage = Properties.Resources.ButtonOn;

        }

        private void panel3_MouseLeave(object sender, EventArgs e) {
            panel3.BackgroundImage = Properties.Resources.ButtonOff;

        }

        private void label2_MouseEnter(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label2_MouseLeave(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;
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

        private void panel2_Click(object sender, EventArgs e) {
            this.Hide();
             HelpWindowHandler.ShowPictureCodeForm();
        }

        private void label3_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowPictureCodeForm();
            
          
        }

        private void label4_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowAllFilesCodeForm();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpWindowHandler.ShowTextCodeForm();
        }
    }
}
