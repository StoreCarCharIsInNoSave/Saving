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
    public partial class TextDecodeForm : StartForm
    {
        private string filePath="";
        public TextDecodeForm()
        {
            InitializeComponent();
        }
        private Image img = null;
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpWindowHandler.ShowTextCodeForm();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.ButtonOn;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.ButtonOff;
        }

        private void TextDecodeForm_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            this.AllowDrop = true;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            pictureBox1.Image = Properties.Resources.DragAndDropAnonFile;
        }

        private void TextDecodeForm_DragEnter(object sender, DragEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.DragAndDropAnonFile;
        }

        private void TextDecodeForm_DragLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = img;
        }

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


        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }


        private void label3_Click(object sender, EventArgs e)
        {
            if (filePath!="")
            {
                string[] temp = File.ReadAllText(filePath).Split('\n');

                byte[] key = new byte[temp[0].Split(' ').Length-1];
                byte[] vector = new byte[temp[1].Split(' ').Length - 1];
                byte[] word = new byte[temp[2].Split(' ').Length - 1];
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = Convert.ToByte(temp[0].Split(' ')[i]);
                    
                }
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = Convert.ToByte(temp[1].Split(' ')[i]);

                }
                for (int i = 0; i < word.Length; i++)
                {
                    word[i] = Convert.ToByte(temp[2].Split(' ')[i]);

                }


                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName =  Path.GetFileName(filePath).Replace("[Crypted]_", "[Decrypted]_");
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, DecryptStringFromBytes(word, key, vector));
                }

            }
        }
    }
}
