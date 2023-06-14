using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class RandomSingleton
    {
        private static RandomSingleton instance;
        private readonly Random _random;

        private RandomSingleton()
        {
            _random = new Random();
        }

        public static RandomSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomSingleton();
                }
                return instance;
            }
        }
        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}
