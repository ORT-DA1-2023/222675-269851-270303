using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.GraphicMotorUtility
{
    public class GraphicMotor
    {
        private int _resolution;

        public int Resolution
        {

            get { return _resolution; }
            set
            {
                if (IsAValidResolution(value))
                {
                    _resolution = value;
                }
            }
        }

        private bool IsAValidResolution(int value)
        {
            if (value<=0)
            {
                throw new BackEndException("The resolution must be greater than 0.");
            }
            return true;
        }

    }
}
