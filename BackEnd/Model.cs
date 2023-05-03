using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;

namespace Render3D.BackEnd
{
    public class Model
    {
        private String _name;
        private Figure _figure;
        private Client _client;
        private Material _material;


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

        private bool IsAValidName(string Name)
        {
            if(HelperValidator.IsAnEmptyString(Name))throw new BackEndException("Name must not be empty");
            if(HelperValidator.IsTrimmable(Name)) throw new BackEndException("Name must not start or end with spaces");

            return true;
        }

      


        public Figure Figure { get=>_figure; set=>_figure =value; }
        public Client Client { get=>_client; set=>_client =value; }
        public Material Material { get=>_material; set=>_material =value; }
    }
}