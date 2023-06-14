using System.Drawing;

namespace Render3D.BackEnd.IODrivers.Output
{
    public interface ISavingFormat
    {
        void Save(Bitmap ppm, string directory);
    }
}
