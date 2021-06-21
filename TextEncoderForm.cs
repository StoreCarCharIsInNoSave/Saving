using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving
{
    public partial class TextEncoderForm : StartForm
    {
        public TextEncoderForm()
        {
            InitializeComponent();
        }
        private Image img = null;
        private void TextEncoderForm_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            this.AllowDrop = true;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.ButtonOn;

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.ButtonOff;
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;

        }

        public string encText = "";
        private void label3_Click(object sender, EventArgs e)
        {
            if (filePath!="")
            {

                using (RijndaelManaged rm = new RijndaelManaged())
                {
                    byte [] key = rm.Key;
                    byte [] vector = rm.IV;
                    byte [] enc = EncryptStringToBytes(File.ReadAllText(filePath) ,key, vector);

                    foreach (byte obj in key)
                    {
                        encText += obj + " ";

                    }
                    encText += Environment.NewLine;
                    foreach (byte obj in vector)
                    {
                        encText += obj + " ";

                    }
                    encText += Environment.NewLine;
                    foreach (byte obj in enc)
                    {
                        encText += obj + " ";

                    }
                    encText += Environment.NewLine;

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.FileName = "[Crypted]_" + Path.GetFileName(filePath);
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName,encText);
                    }
                }

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpWindowHandler.ShowTextCodeForm();
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropAnonFile;
        }

        private void TextEncoderForm_DragEnter(object sender, DragEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.DragAndDropAnonFile;
        }

        private void TextEncoderForm_DragLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = img;
        }
        public string filePath ="";

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    filePath = fileNames[0];
                    pictureBox1.Image = Properties.Resources.DragAndDropAnonFileUploaded;
                    img = pictureBox1.Image;
                }
            }
        }
    }
}
