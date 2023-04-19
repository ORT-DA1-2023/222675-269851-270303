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

        private ArrayList _figuresCreated = new ArrayList();
        private ArrayList _materialsCreated = new ArrayList();
        private ArrayList _modelsCreated = new ArrayList();

        public ArrayList Figures { get => _figuresCreated; }
        public ArrayList Materials { get => _materialsCreated; }
        public ArrayList Models { get => _modelsCreated; }
   
    
    }
}
