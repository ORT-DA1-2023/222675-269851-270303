using Render3D.BackEnd.IODrivers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.FileFormat
{
    public class PPMSavingDriver : ISavingFormat
    {
        public void Save(Bitmap bitmap, string directory)
        {
            using (StreamWriter writer = new StreamWriter(directory))
            {
                writer.WriteLine("P3");
                writer.WriteLine($"{bitmap.Width} {bitmap.Height}");
                writer.WriteLine("255");
  
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        writer.Write($"{pixelColor.R} {pixelColor.G} {pixelColor.B} ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
