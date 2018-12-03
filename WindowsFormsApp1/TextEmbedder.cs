using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TextEmbedder
    {
        String textToEmbed = "";
        String encryptedText = null;
        String keySecurity = "";
        Bitmap bmp = null;

        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };

        public TextEmbedder setText(String text)
        {
            textToEmbed = text;

            return this;
        }

        public TextEmbedder setKeySecurity(String text)
        {
            keySecurity = text;

            return this;
        }
        public TextEmbedder setBitmap(Bitmap bitmap)
        {
            bmp = bitmap;

            return this;
        }

      

        private void encryptedTextToBits()
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(encryptedText);
        }
        public Bitmap embedText()
        {
            encryptedText = new Encryptor()
                .setDecryptedText(textToEmbed)
                .setKey(keySecurity)
                .getEncrypted();
            encryptedText = encryptedText.Length.ToString() + "#" + encryptedText;
            Byte[] bytes = Encoding.UTF8.GetBytes(encryptedText);
            // czy ukrywamy tekst czy kończymy wypełniając zerami
            State state = State.Hiding;

            // idex aktualnie przetwarzanego znaku
            int charIndex = 0;

            // wartość znaku w postaci inta
            int charValue = 0;

            // który subpixel
            long pixelElementIndex = 0;

            // liczba ustawionych zer 
            int zeros = 0;

            int R = 0, G = 0, B = 0, a1 = 0, a2 = 0, a3 = 0;

            //wiersze
            for (int i = 0; i < bmp.Height; i++)
            {
                // kolumny
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    // czyszczenie LSB 
                    R = pixel.R - pixel.R % 2;
                    G = pixel.G - pixel.G % 2;
                    B = pixel.B - pixel.B % 2;

                    a1 = R & 1;
                    a2 = G & 1;
                    a3 = B & 1;
                
                    // iterujemy się po R G B
                    for (int n = 0; n < 3; n++)
                    {
                        // czy przetowrzyliśmy 8 bitów
                        if (pixelElementIndex % 8 == 0)
                        {
                            //skończyliśmy ukrywać tekst
                            if (state == State.Filling_With_Zeros && zeros == 8)
                            {
                                // na wypadek gdyby tekst nie zmieścił się - raczej mało prawdopodbne :)
                                if ((pixelElementIndex - 1) % 3 < 2)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                
                                return bmp;
                            }

                            // Czy ukryliśmy cały tekst
                            if (charIndex >= encryptedText.Length)
                            {
                                // dodajemy zera
                                state = State.Filling_With_Zeros;
                            }
                            else
                            {
                                // kolejny znak
                                charValue = encryptedText[charIndex++];
                            }
                        }

                        // który subpixel
                        switch (pixelElementIndex % 3)
                        {
                            case 0:
                                {
                                    if (state == State.Hiding)
                                    {
                                        // Bierzemy prawy bit znaku i podstawiamy zamiast LSB (wcześniej wyzerowany_
                                        R += charValue % 2;
                                        //Przesuwamy w prawo
                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (state == State.Hiding)
                                    {
                                        G += charValue % 2;

                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (state == State.Hiding)
                                    {
                                        B += charValue % 2;

                                        charValue /= 2;
                                    }
                                    //Wstawiamy zmodyfikowany pixel
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                break;
                        }

                        pixelElementIndex++;

                        if (state == State.Filling_With_Zeros)
                        {
                            // wypełniamy zerami aż osiągniemy 8 bitów
                            zeros++;
                        }
                    }
                }
            }

            return bmp;
        }
    }
}
