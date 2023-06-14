using Render3D.BackEnd.IODrivers.Output;
using System.Drawing;
using System.IO;

namespace Render3D.BackEnd.Output.FileFormat
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
