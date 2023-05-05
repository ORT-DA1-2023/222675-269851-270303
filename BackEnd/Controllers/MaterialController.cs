using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class MaterialController
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;

        public DataWarehouse DataWarehouse { get => _dataWarehouse; set { _dataWarehouse = value; } }
        public ClientController ClientController { get => _clientController; set => _clientController = value; }

        public void AddMaterial(string clientName, string materialName, int[] materialColors)
        {
            if (GetMaterialByNameAndClient(clientName,materialName).Name==null)
            {
                try
                {
                    CreateAndAddMaterial(ClientController.GetClientByName(clientName), materialName, materialColors);
                }
                catch (Exception e)
                {

                }
            }
        }
        private void CreateAndAddMaterial(Client client, string materialName, int[] materialColors)
        {
            Vector3D color = new Vector3D(materialColors[0], materialColors[1], materialColors[2]);
            Material material = new LambertianMaterial() { Client = client, Name = materialName, Color = color };
            _dataWarehouse.Materials.Add(material);
        }

        private Material GetMaterialByNameAndClient(string clientName, string materialName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Material material in _dataWarehouse.Materials)
            {
                if (material.Name == materialName && material.Client.Equals(client))
                {
                    return material;
                }
            }
            return new LambertianMaterial();
        }
        public void ChangeMaterialName(string clientName, string oldName, string newName)
        {
            Material material = GetMaterialByNameAndClient(clientName, oldName);
            if (material.Name == null)
            {
                return;
            }
            if (GetMaterialByNameAndClient(clientName, newName).Name != null)
            {
                return;
            }
            material.Name = newName;
        }
        public void DeleteMaterialInList(string clientName, string materialName)
        {
            Material material = GetMaterialByNameAndClient(clientName, materialName);
            if (material.Name != null)
            {
                _dataWarehouse.Materials.Remove(material);
            }
            
        }
    }
}
