using System.Drawing;
using System.Drawing.Imaging;


namespace Render3D.BackEnd
{
    public class JPGSavingFormat : SavingFormat
    {
        public override void Save(Bitmap ppmImage, string jpgFilePath)
        {
                ppmImage.Save(jpgFilePath, ImageFormat.Jpeg);
        }
    }
}
