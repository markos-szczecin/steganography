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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureLoader.setForm(this);
        }

        private void loadPicture_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureLoader.setPicturePath(openFileDialog.FileName);
                PictureLoader.loadPicture();
            }
        }

        private void insertText_Click(object sender, EventArgs e)
        {
            TextEmbedder te = new TextEmbedder();
            pictureAfter.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureAfter.Image = te
                .setText(textToInsert.Text)
                .setKeySecurity(keySecurity.Text)
                .setBitmap((Bitmap)pictureBefore.Image)
                .embedText();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
           
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Console.WriteLine(dialog.FileName);

                    pictureAfter.Image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                } catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Wystąpił błąd... Prawdpodobnie próbujesz zapisać zakodowany obrazek w miejscu oryginału", "Błąd zapisu");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = (Bitmap)pictureBefore.Image;
                TextExtracter te = new TextExtracter();
                insertedText.Text = te
                    .setKeySecurity(keySecurity.Text)
                    .setBitmap(bmp)
                    .extractText();
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Wczytaj fotkę");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
