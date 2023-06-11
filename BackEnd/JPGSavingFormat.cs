using System.Drawing;
using System.Drawing.Imaging;


namespace Render3D.BackEnd
{
    public class JPGSavingFormat : ISavingFormat
    {
        public void Save(Bitmap ppmImage, string jpgFilePath)
        {
                ppmImage.Save(jpgFilePath, ImageFormat.Jpeg);
        }
    }
}
