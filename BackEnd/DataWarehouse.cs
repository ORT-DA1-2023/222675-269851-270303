using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System.Collections.Generic;

namespace Render3D.BackEnd
{
    public class DataWarehouse
    {
        public DataWarehouse() { }

        private readonly List<Client> _clientsCreated = new List<Client>();
        private readonly List<Figure> _figuresCreated = new List<Figure>();
        private readonly List<Material> _materialsCreated = new List<Material>();
        private readonly List<Model> _modelsCreated = new List<Model>();

        public List<Client> Clients { get => _clientsCreated; }
        public List<Figure> Figures { get => _figuresCreated; }
        public List<Material> Materials { get => _materialsCreated; }
        public List<Model> Models { get => _modelsCreated; }



    }
}
