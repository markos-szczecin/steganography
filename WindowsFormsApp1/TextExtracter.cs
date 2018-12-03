using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TextExtracter
    {
        Bitmap bmp = null;
        String encryptedText = "";
        String keySecurity = "";
        Boolean startLoadText = false;

        public TextExtracter setBitmap(Bitmap bitmap)
        {
            bmp = bitmap;

            return this;
        }

        public TextExtracter setKeySecurity(String text)
        {
            keySecurity = text;

            return this;
        }


        public string extractText()
        {
            int colorUnitIndex = 0;
            int charValue = 0;
           
            string extractedText = String.Empty;
            
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    
                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    //Dodajmey jeden bit do obecnego znaku i podmienimy LSB
                                    charValue = charValue * 2 + pixel.R % 2;
                                }
                                break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                }
                                break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                }
                                break;
                        }

                        colorUnitIndex++;

                        // mamy osiem bitów = jeden znak
                        if (colorUnitIndex % 8 == 0)
                        {
                            // odracamy - tekst był ładowany od tyłu
                            charValue = reverseBits(charValue);

                            // znak końca (8 zer)
                            if (charValue == 0)
                            {
                                return new Encryptor().setEncryptedText(extractedText).setKey(keySecurity).getDecrypted();
                            }
                            
                            char c = (char)charValue;
                            if (startLoadText)
                            {
                                extractedText += c.ToString();
                            }
                            if (c.ToString().Equals("#"))
                            {
                                startLoadText = true;
                            }
                        }
                    }
                }
            }

            return new Encryptor().setEncryptedText(extractedText).setKey(keySecurity).getDecrypted();
        }

        public static int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
    }
}
