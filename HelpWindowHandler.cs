using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving {
    static class HelpWindowHandler {
        static private HelpForm helpForm;
        static private MainChoseForm mainChoseForm;
        static private PictureCodeForm pictureCodeForm;
        static private PictureEncoderForm pictureEncoderForm;
        static private PictureDecoderForm pictureDecoderForm;
        static private AllFilesCodeForm allFilesCodeForm;
        static private BinaryEncoderForm binaryEncoderForm;
        static private Base64CodeForm base64CodeForm;
        static private Base64EncoderForm base64EncoderForm;
        static private Base64DecodeForm base64DecoderForm;
        static private TextCodeForm textCodeForm;
        static private TextEncoderForm textEncoderForm;
        static private TextDecodeForm textDecodeForm;

     
        static public void ShowTextDecodeForm()
        {
            if (textDecodeForm == null)
            {
                textDecodeForm = new TextDecodeForm();
                textDecodeForm.Show();
            }
            else
            {
                textDecodeForm.Show();
            }
        }

        static public void ShowTextEncoderForm()
        {
            if (textEncoderForm == null)
            {

                textEncoderForm = new TextEncoderForm();
                textEncoderForm.Show();


            }
            else
            {

                textEncoderForm.Show();
            }
        }



        static public void ShowTextCodeForm()
        {
            if (textCodeForm == null)
            {

                textCodeForm = new TextCodeForm();
                textCodeForm.Show();


            }
            else
            {

                textCodeForm.Show();
            }
        }


        static public void ShowBase64DecodeForm() {
            if (base64DecoderForm == null) {

                base64DecoderForm = new Base64DecodeForm();
                base64DecoderForm.Show();


            }
            else {

                base64DecoderForm.Show();
            }
        }

        static public void ShowBase64EncoderForm() {
            if (base64EncoderForm == null) {

                base64EncoderForm = new Base64EncoderForm();
                base64EncoderForm.Show();


            }
            else {

                base64EncoderForm.Show();
            }
        }


        static public void ShowBase64CodeForm() {
            if (base64CodeForm == null) {

                base64CodeForm = new Base64CodeForm();
                base64CodeForm.Show();


            }
            else {

                base64CodeForm.Show();
            }
        }


        static public void ShowBinaryEncoderForm() {
            if (binaryEncoderForm == null) {

                binaryEncoderForm = new BinaryEncoderForm();
                binaryEncoderForm.Show();


            }
            else {

                binaryEncoderForm.Show();
            }
        }

        
        static public void ShowAllFilesCodeForm() {


            
                if (allFilesCodeForm == null)
                {

                    allFilesCodeForm = new AllFilesCodeForm();
                    allFilesCodeForm.Show();


                }
                else
                {

                    allFilesCodeForm.Show();
                }
          


            
        }

        static public void ShowPictureDecoderForm() {
            if (pictureDecoderForm == null) {

                pictureDecoderForm = new PictureDecoderForm();
                pictureDecoderForm.Show();


            }
            else {

                pictureDecoderForm.Show();
            }
        }


        static public void ShowPictureEncoderForm() {
            if (pictureEncoderForm == null) {

                pictureEncoderForm = new PictureEncoderForm();
                pictureEncoderForm.Show();


            }
            else {

                pictureEncoderForm.Show();
            }
        }



        static public void ShowPictureCodeForm() {
            if (pictureCodeForm == null) {

                pictureCodeForm = new PictureCodeForm();
                pictureCodeForm.Show();


            }
            else {

                pictureCodeForm.Show();
            }
        }


        static public void ShowMainChoseForm() {
            if (mainChoseForm == null) {

                mainChoseForm = new MainChoseForm();
                mainChoseForm.Show();


            }
            else {

                mainChoseForm.Show();
            }
        }


        static public void ShowHelpWindow() {
            if (helpForm == null) {

                helpForm = new HelpForm();
                helpForm.Show();


            }
            else {

                helpForm.Show();
            }
        }


    }
}
