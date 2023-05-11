using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using System.Drawing;


namespace Render3D.BackEnd
{
    public class Model
    {
        private string _name;
        private Bitmap _preview;

        public Client Client { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public Figure Figure { get; set; }
        public Material Material { get; set; }
        public Bitmap Preview
        {
            get => _preview;
            set
            {
                if (value != null)
                {
                    _preview = value;
                }
            }
        }

        private void ValidateName(string Name)
        {
            if (HelperValidator.IsAnEmptyString(Name)) throw new BackEndException("Name must not be empty");
            if (HelperValidator.IsTrimmable(Name)) throw new BackEndException("Name must not start or end with spaces");
        }
        override
        public string ToString()
        {
            return _name + "(" + Figure.Position.X + "," + Figure.Position.Y + "," + Figure.Position.Z + ")";
        }
    }
}