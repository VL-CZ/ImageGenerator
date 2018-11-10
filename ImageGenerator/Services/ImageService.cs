using ImageGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGenerator.Services
{
    public class ImageService : IImageService
    {
        private const int blockSize = 32;

        public byte[] GenerateImage(int width, int height)
        {
            Image image = new Bitmap(width, height);
            Color color = GetColor();
            Random random = new Random();

            for (int i = 0; i < image.Width; i += blockSize)
            {
                for (int j = 0; j < image.Height; j += blockSize)
                {
                    bool colored = random.Next(0, 2) == 1;

                    for (int k = 0; k < blockSize; k++)
                    {
                        for (int l = 0; l < blockSize; l++)
                        {
                            if (colored)
                                ((Bitmap)image).SetPixel(i + k, j + l, color);
                            else
                                ((Bitmap)image).SetPixel(i + k, j + l, Color.WhiteSmoke);
                        }
                    }
                }
            }
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            return memoryStream.ToArray();
        }

        private Color GetColor()
        {
            Color color;
            Random random = new Random();
            int x = random.Next(1, 10);

            switch (x)
            {
                case 1:
                    color = Color.Blue;
                    break;
                case 2:
                    color = Color.Green;
                    break;
                case 3:
                    color = Color.FromArgb(255, 244, 233, 26); // Yellow
                    break;
                case 4:
                    color = Color.Red;
                    break;
                case 5:
                    color = Color.Black;
                    break;
                case 6:
                    color = Color.Brown;
                    break;
                case 7:
                    color = Color.Purple;
                    break;
                case 8:
                    color = Color.Orange;
                    break;
                case 9:
                    color = Color.Gray;
                    break;
            }

            return color;
        }
    }
}
