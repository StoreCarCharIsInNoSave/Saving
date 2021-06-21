using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving {
    public partial class PictureEncoderForm : StartForm {
        public PictureEncoderForm() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowPictureCodeForm();
        }

        private void panel1_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowPictureCodeForm();
        }

        private void label2_MouseEnter(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label2_MouseLeave(object sender, EventArgs e) {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;
        }

        public Image img = null;
        private void pictureBox1_DragDrop(object sender, DragEventArgs e) {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    pictureBox1.Image =Image.FromFile(fileNames[0]);
                    img = pictureBox1.Image;
                }
            }
        }

        private void PictureEncoderForm_Load(object sender, EventArgs e) {
            pictureBox1.AllowDrop = true;
            this.AllowDrop = true;
        }
        
        private void pictureBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropPicture;

        }

        private void PictureEncoderForm_DragEnter(object sender, DragEventArgs e) {
            pictureBox1.Image = Properties.Resources.DragAndDropPicture;
        }

        private void PictureEncoderForm_DragLeave(object sender, EventArgs e) {
            pictureBox1.Image = img;
        }

        private void label3_MouseEnter(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void label3_MouseLeave(object sender, EventArgs e) {
            panel2.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void label3_Click(object sender, EventArgs e) {
            if (pictureBox1.Image!=null) {

            


            string text = "";
            Random rnd = new Random();
            Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();

            int[] masOfPix = new int[bmp.Height];
            for (int i = 0; i < masOfPix.Length; i++) {
                masOfPix[i] = i;
            }

            masOfPix = masOfPix.OrderBy(x => rnd.Next()).ToArray();
            foreach (int obj in masOfPix) {
                text += obj + Environment.NewLine;
            }
        
            Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
            int pos = 0;
            for (int i = 0; i < masOfPix.Length; i++) {

                for (int j = 0; j < bmp2.Width; j++) {

                    Color pix = bmp.GetPixel(j, masOfPix[i]);

                    bmp2.SetPixel(j, pos, pix);



                }
                pos++;
            }


            pictureBox4.Image = bmp2;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext) {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox4.Image.Save(sfd.FileName, format);







                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = "keys.txt";
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    File.WriteAllText(saveFileDialog1.FileName, text);
                }



            }



            }






        }
    }
}
