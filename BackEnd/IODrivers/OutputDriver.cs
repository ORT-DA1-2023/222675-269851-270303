using Render3D.BackEnd.IODrivers.Output;
using System.Drawing;

namespace Render3D.BackEnd.IODrivers
{
    public class OutputDriver
    {
        private readonly ISavingFormat _format;
        public OutputDriver (ISavingFormat format)
        {
            _format = format;
        }
        public void Save(Bitmap bitmap, string directory)
        {
         _format.Save(bitmap, directory);
        }
    }
}
