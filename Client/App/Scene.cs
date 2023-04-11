using System;
using System.Collections;
using System.Xml.Linq;

namespace App
{
    public class Scene
    {
        private DateTime registerDate;
        private DateTime lastModificationDate;
        private Client client;
        private String name;
        private ArrayList positionedModels;
        private decimal[] cameraPosition;
        private int fieldOfView;
        public Scene()
        {
            registerDate = DateTime.Now;
        }

        public Client Client { get => client; set => client = value; }
        public string Name
        {
            get => name;
            set
            {
                if (isAValidName(value))
                {
                    name = value;
                }
            }
        }


        public ArrayList PositionedModels { get; set; }
        public decimal[] CameraPosition { get; set; }
        public int FieldOfView { get; set; }
    
    private bool isAValidName(string value)
    {
        if (value == "")
        {
            throw new BackEndException("Name cant be empty");
        }
        if (value != value.Trim())
        {
            throw new BackEndException("Name cant start or end with blank");
        }
        return true;
    }
}
}
