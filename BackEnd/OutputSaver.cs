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
        private ISavingFormat _format;

        public OutputSaver(Bitmap ppm, string destinationPath,ISavingFormat format) { 
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
            catch (Exception e) {
                throw new BackEndException("Could not save the file");
            }
        }

    }
}
