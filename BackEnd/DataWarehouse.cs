using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class DataWarehouse
    {
        public DataWarehouse() { }

        private List<Figure> _figuresCreated = new List<Figure>();
        private List<Material> _materialsCreated = new List<Material>();
        private List<Model> _modelsCreated = new List<Model>();
        private List<Client> _clientsCreated = new List<Client>();

        public List<Figure> Figures { get => _figuresCreated; }
        public List<Material> Materials { get => _materialsCreated; }
        public List<Model> Models { get => _modelsCreated; }
        public List<Client> Clients { get => _clientsCreated; }
   
    
    }
}
