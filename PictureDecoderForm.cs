using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving {
    public partial class PictureDecoderForm : StartForm {
        public PictureDecoderForm() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {
            this.Hide();
            HelpWindowHandler.ShowPictureCodeForm();
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

        private void PictureDecoderForm_Load(object sender, EventArgs e) {
            pictureBox1.AllowDrop = true;
            pictureBox5.AllowDrop = true;
            this.AllowDrop = true;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropPicture;
            pictureBox5.Image = Properties.Resources.DragAndDropKeys;
        }

        private void PictureDecoderForm_DragEnter(object sender, DragEventArgs e) {
            pictureBox1.Image = Properties.Resources.DragAndDropPicture;
            pictureBox5.Image = Properties.Resources.DragAndDropKeys;


        }
        public Image img = null;
        public bool keyStatus = false;

        private void PictureDecoderForm_DragLeave(object sender, EventArgs e) {
            pictureBox1.Image = img;
            if (!keyStatus) {
                pictureBox5.Image = Properties.Resources.DragAndDropKeyIsMissing;

            }
            else {
                pictureBox5.Image = Properties.Resources.DragAndDropKeyIsLoaded;
            }
        }


        private void pictureBox1_DragDrop(object sender, DragEventArgs e) {



            if (!keyStatus) {
                pictureBox5.Image = Properties.Resources.DragAndDropKeyIsMissing;
            }
            else {
                pictureBox5.Image = Properties.Resources.DragAndDropKeyIsLoaded;
            }


            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null) {
                var fileNames = data as string[];
                if (fileNames.Length > 0) {
                    pictureBox1.Image = Image.FromFile(fileNames[0]);
                    img = pictureBox1.Image;
                }

            }
        }
        private void pictureBox5_DragEnter(object sender, DragEventArgs e) {
            pictureBox5.Image = Properties.Resources.DragAndDropKeys;
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropPicture;


        }
        public string keys = "";
        private void pictureBox5_DragDrop(object sender, DragEventArgs e) {
            if (pictureBox1.Image != null) {

            }



            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null) {
                var fileNames = data as string[];
                if (fileNames.Length > 0) {


                    pictureBox5.Image = Properties.Resources.DragAndDropKeyIsLoaded;
                    keyStatus = true;
                    pictureBox1.Image = img;
                    using (StreamReader sr = new StreamReader(fileNames[0])) {

                        keys = sr.ReadToEnd();
                    }

                }
            }




        }

        private void label3_Click(object sender, EventArgs e) {

            if (pictureBox1.Image != null && keyStatus) {



                Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();
                Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
                string[] stringKeys = keys.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int[] intKeys = new int[stringKeys.Length];
                for (int i = 0; i < intKeys.Length; i++) {
                    intKeys[i] = Convert.ToInt32(stringKeys[i]);

                }



                int pos = 0;
                for (int i = 0; i < intKeys.Length; i++) {

                    for (int j = 0; j < bmp.Width; j++) {

                        Color pix = bmp.GetPixel(j, pos);

                        bmp2.SetPixel(j, intKeys[i], pix);



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


                }
            }
        }
    }
}
