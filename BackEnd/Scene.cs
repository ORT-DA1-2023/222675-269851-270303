using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Render3D.BackEnd
{
    public class Scene
    {
        private DateTime _registerDate;
        private DateTime _lastModificationDate;
        private Client _client;
        private String _name;
        private List<Model> _positionedModels;
        private decimal[] _cameraPosition;
        private decimal[] _objectPosition;
        private int _fieldOfView;
        public Scene()
        {
            _registerDate = DateTime.Now;
            _cameraPosition = new decimal[3] { 0, 2, 0 };
            _objectPosition = new decimal[3] { 0, 2, 5 };
            _fieldOfView = 30;
        }

        public Client Client { get => _client; set => _client = value; }
        public string Name
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


        public ArrayList PositionedModels { get; set; }
        public decimal[] CameraPosition { get => _cameraPosition; set => _cameraPosition = value; }
        public decimal[] ObjectPosition { get => _objectPosition; set => _objectPosition = value; }
        public int FieldOfView { get => _fieldOfView; set => _fieldOfView = value; }


        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
            return true;
        }
        public bool equalsCameraPosition(decimal[] newCamera)
        {
            for (int i = 0; i < newCamera.Length; i++)
            {
                if (this.CameraPosition[i] != newCamera[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool equalsObjectPosition(decimal[] newObject)
        {
            for (int i = 0; i < newObject.Length; i++)
            {
                if (this.ObjectPosition[i] != newObject[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
