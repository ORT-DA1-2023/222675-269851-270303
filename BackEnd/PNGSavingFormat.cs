using System.Drawing;
using System.Drawing.Imaging;

namespace Render3D.BackEnd
{
    public class PNGSavingFormat : ISavingFormat
    {
        public void Save(Bitmap ppmImage, string FilePath)
        {
            ppmImage.Save(FilePath, ImageFormat.Png);
        }
    }
}

