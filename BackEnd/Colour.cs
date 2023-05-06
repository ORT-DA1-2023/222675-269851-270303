using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class Colour
    {
        private double _percentageRed;
        private double _percentageGreen;
        private double _percentageBlue;
        public Colour(double v1, double v2, double v3)
        {
            PercentageRed = v1;
            PercentageGreen = v2;
            PercentageBlue = v3;
        }
        public double PercentageRed { 
            get => _percentageRed;
            set {
               ValidateColour(value);
               _percentageRed = value;
                
            } 
        }
        public double PercentageGreen
        {
            get => _percentageGreen;
            set
            {
                ValidateColour(value);
                _percentageGreen = value;

            }
        }
        public double PercentageBlue
        {
            get => _percentageBlue;
            set
            {
                ValidateColour(value);
                _percentageBlue = value;

            }
        }
        public int Red()
        {
            return (int)Math.Abs(PercentageRed * 255);
        }
        public int Green()
        {
            return (int)Math.Abs(PercentageGreen * 255);
        }
        public int Blue()
        {
            return (int)Math.Abs(PercentageBlue * 255);
        }
        public bool Equals(Colour other)
        {
            return PercentageRed==other.PercentageRed && PercentageGreen==other.PercentageGreen && PercentageBlue==other.PercentageBlue; 
        }
        private void ValidateColour(double num)
        {
            if (!HelperValidator.IsANumberInRange(num, 0, 1)) throw new BackEndException("Colour percentage must be between 0 and 1");
        }

    }

}
