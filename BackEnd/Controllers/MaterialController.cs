using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Utilities;


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
           try
            {
                GetMaterialByNameAndClient(clientName, materialName);
               
            }catch(Exception)
            {
                CreateAndAddMaterial(ClientController.GetClientByName(clientName), materialName, materialColors);
                return;
            } 
            throw new BackEndException("material already exists");
        }
        private void CreateAndAddMaterial(Client client, string materialName, int[] materialColors)
        {
            Colour color = new Colour(materialColors[0], materialColors[1], materialColors[2]);
            Material material = new LambertianMaterial() { Client = client, Name = materialName, Attenuation = color };
            _dataWarehouse.Materials.Add(material);
        }

        public Material GetMaterialByNameAndClient(string clientName, string materialName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Material material in _dataWarehouse.Materials)
            {
                if (material.Name == materialName && material.Client.Equals(client))
                {
                    return material;
                }
            }
            throw new BackEndException("material doesnt exist");
        }
        public void ChangeMaterialName(string clientName, string oldName, string newName)
        { 
            Material material;
            try
            {
                material = GetMaterialByNameAndClient(clientName, oldName);
            }
            catch (Exception)
            {
                return;
            }
            try{
                GetMaterialByNameAndClient(clientName, newName);
            }catch (Exception)
            {
              material.Name = newName;
            }        
        }
        public void DeleteMaterialInList(string clientName, string materialName)
        {
            try
            {
                Material material=GetMaterialByNameAndClient(clientName, materialName);
                _dataWarehouse.Materials.Remove(material);
            }
            catch(Exception) 
            {
            }
            
        }
    }
}
