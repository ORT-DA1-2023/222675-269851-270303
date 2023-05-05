using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.BackEnd.Materials
{

    public class LambertianMaterial : Material
    {
        private Vector3D _color;
        public override string Name
        {
            get => _name;
            set
            {
                if (IsAValidName(value))
                {
                    _name = value;
                }
            }
        }
        public override Client Client
        {
            get => _client;
            set => _client = value;
        }
        public Vector3D Color
        {
            get => _color;
            set
            {
                if (IsAValidColor(value))
                {
                    _color = value;
                }
            }
        }

        private bool IsAValidColor(Vector3D value)
        {
            if (!HelperValidator.IsANumberInRange(value.X, 0, 255) || !HelperValidator.IsANumberInRange(value.Y, 0, 255) ||
                !HelperValidator.IsANumberInRange(value.Z, 0, 255))
            {
                throw new BackEndException("Color must be between 0 and 255");
            }

            return true;
        }

    }
}
