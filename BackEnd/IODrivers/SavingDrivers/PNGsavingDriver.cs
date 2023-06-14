﻿using Render3D.BackEnd.IODrivers.Output;
using System.Drawing;
using System.Drawing.Imaging;

namespace Render3D.BackEnd.Output.FileFormat
{
    public class PNGSavingDriver : ISavingFormat
    {
        public void Save(Bitmap bmp, string directory)
        {
            bmp.Save(directory, ImageFormat.Png);
        }
    }
}
