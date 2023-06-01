using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public abstract class SavingFormat
    {
        public abstract void Save(Bitmap ppm, string directory);
    }
}
