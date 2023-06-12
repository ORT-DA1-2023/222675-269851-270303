using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Render3D.BackEnd
{
    public class PNGSavingFormat : ISavingFormat
    {
        public void Save(Bitmap image, string FilePath)
        {
 
            image.Save(FilePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

