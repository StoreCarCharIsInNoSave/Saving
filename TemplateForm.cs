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

    

    public partial class StartForm : Form
    {

        

        public StartForm()
        {
            InitializeComponent();
           
        }

        public void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        public void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.Name!= "HelpForm") {
                Application.Exit();
            }
            else {
                this.Hide();
            }
            
            
        }

        public void StartForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(684, 411);
            this.label1.Text = "Saving is the best way to protect your data...";

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.ExitON;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.ExitOFF;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.HelpON;

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.HelpOFF;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            HelpWindowHandler.ShowHelpWindow();

        }
    }
}
