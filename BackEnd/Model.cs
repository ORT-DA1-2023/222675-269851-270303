using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Drawing;

namespace Render3D.BackEnd
{
    public class Model
    {
        private String _name;
        private Figure _figure;
        private Client _client;
        private Material _material;
        private Bitmap _preview;

        public Client Client { get => _client; set => _client = value; }

        public string Name { 
            get=>_name;
            set
            {
                if (IsAValidName(value))
                {
                    _name = value;
                }
            } 
        }

        public Figure Figure { get => _figure; set => _figure = value; }

        public Bitmap Preview
        {
            get=>_preview;
            set
            {
                if (value != null)
                {
                    _preview = value;
                }
            }
        }
        public Material Material { get => _material; set => _material = value; }

        private bool IsAValidName(string Name)
        {
            if(HelperValidator.IsAnEmptyString(Name))throw new BackEndException("Name must not be empty");
            if(HelperValidator.IsTrimmable(Name)) throw new BackEndException("Name must not start or end with spaces");
            return true;
        }   
    }
}