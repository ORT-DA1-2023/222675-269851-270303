using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class SceneController
    {
        private DataWarehouse _dataWarehouse;
        public DataWarehouse DataWarehouse { get => _dataWarehouse; set => _dataWarehouse = value; }

        private void CreateAndAddScene(string sceneName, double[] lookFrom, double[] lookAt, int fov)
        {
            Vector3D lookFromVector = new Vector3D(lookFrom[0], lookFrom[1], lookFrom[2]);
            Vector3D lookAtVector = new Vector3D(lookAt[0], lookAt[1], lookAt[2]);
            Camera camera= new Camera() { LookAt=lookAtVector, Fov=fov, LookFrom=lookFromVector};
            Scene scene = new Scene() {Name=sceneName,Camera=camera};
            DataWarehouse.Scenes.Add(scene);
        }
    }
}
