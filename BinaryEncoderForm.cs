using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving {
    public partial class BinaryEncoderForm : StartForm {





        public BinaryEncoderForm() {
            InitializeComponent();
        }



        public byte[] ReadAllBytes(string fileName) {
            byte[] buffer = null;
            using (System.IO.FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
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
        
        private void pictureBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropAnonFile;
        }
        public bool fileInjectStatus = false;
        
        private void label2_Click(object sender, EventArgs e) {

            if (fileInjectStatus) {
                string fileExt = Path.GetExtension(filePath);
                byte[] appByteArray = ReadAllBytes(filePath);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(filePath)+fileExt;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    Array.Reverse(appByteArray);
                    File.WriteAllBytes(saveFileDialog1.FileName, appByteArray);
                }
            }











        }

        private void pictureBox1_DragLeave(object sender, EventArgs e) {
            if (!fileInjectStatus) {
                pictureBox1.Image = null;
            }
            else {
                pictureBox1.Image = Properties.Resources.DragAndDropAnonFileUploaded;
            }
        }
        public string filePath="";
        private void pictureBox1_DragDrop(object sender, DragEventArgs e) {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null) {
                var fileNames = data as string[];
                if (fileNames.Length > 0) {
                    filePath = fileNames[0];
                    fileInjectStatus = true;
                    pictureBox1.Image = Properties.Resources.DragAndDropAnonFileUploaded;
                }
            }
        }

        private void BinaryEncoderForm_Load(object sender, EventArgs e) {
            pictureBox1.AllowDrop = true;
        }

        private void label2_MouseEnter(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label2_MouseLeave(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;
        }
    }
}
