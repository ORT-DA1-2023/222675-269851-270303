using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Render3D.BackEnd;


namespace Render3D.BackEnd
{
    public class Scene
    {
        private DateTime _registerDate;
        private DateTime _lastModificationDate;
        private Client _client;
        private String _name;
        private List<Model> _positionedModels;
      
        private Camera _camera;

        public Scene()
        {
            _camera = new Camera();
            _registerDate = DateTimeProvider.Now;
        }

        public Client Client { get => _client; set => _client = value; }
        public Camera Camera { get; set; }
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

        public DateTime LastModificationDate
        {
            get => _lastModificationDate;
            private set => _lastModificationDate = value;
        }
  
        public void UpdateLastModificationDate()
        {
            LastModificationDate = DateTimeProvider.Now;
        }
        private bool IsAValidName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
            return true;
        }
        
    }
}
