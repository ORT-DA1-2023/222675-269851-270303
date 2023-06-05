using System.Drawing;
using System.Drawing.Imaging;

namespace Render3D.BackEnd
{
    public class PNGSavingFormat : SavingFormat
    {
        public override void Save(Bitmap ppmImage, string FilePath)
        {
            ppmImage.Save(FilePath, ImageFormat.Png);
        }
    }
}

