using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class PPMSavingDriver : ISavingFormat
    {
        public void Save(Bitmap bitmap, string directory)
        {
            using (StreamWriter writer = new StreamWriter(directory))
            {
                // Write the PPM file header
                writer.WriteLine("P3");  // Magic number for PPM
                writer.WriteLine($"{bitmap.Width} {bitmap.Height}");  // Width and height
                writer.WriteLine("255");  // Maximum color value

                // Write the pixel data
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        writer.Write($"{pixelColor.R} {pixelColor.G} {pixelColor.B} ");
                    }
                    writer.WriteLine();  // Move to the next line after each row
                }
            }
        }
    }
}
