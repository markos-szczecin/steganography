using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PictureLoader
    {
        private static Form1 form = null;
        private static String picturePath = "";
       
        public static void setPicturePath(String path)
        {
            picturePath = path;
        }

        public static PictureBox loadPicture()
        {
            if (form == null)
            {
                throw new Exception("Brak forma");
            }
            PictureBox pb = form.Controls.Find("pictureBefore", true).FirstOrDefault() as PictureBox;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Image.FromFile(picturePath);

            return pb;
        }

        public static void setForm(Form1 f)
        {
            form = f;
        }
    }
}
