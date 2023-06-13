using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class PNGsavingDriver : ISavingFormat
    {
        public void Save(Bitmap bmp, string directory)
        {
            bmp.Save(directory, ImageFormat.Png);
        }
    }
}
