using Org.BouncyCastle.Cmp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Render3D.BackEnd
{
    public class OutputSaver
    {
        private Bitmap _bitmap;
        private string _destinationPath;
        private SavingFormat _format;

        public OutputSaver(Bitmap ppm, string destinationPath,SavingFormat format) { 
            _bitmap = ppm;
            _destinationPath = destinationPath;
            _format = format;
        }
       
        public void Save()
        {
            try
            {
                _format.Save(_bitmap, _destinationPath);
            }
            catch (Exception) {
                throw new BackEndException("Could not save the file");
            }
        }

    }
}
