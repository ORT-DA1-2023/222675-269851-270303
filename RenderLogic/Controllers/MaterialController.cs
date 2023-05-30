using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using System;


namespace Render3D.RenderLogic.Controllers
{
    public class MaterialController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }

        public void AddLambertianMaterial(string clientName, string materialName, int[] materialColors)
        {
            try
            {
                GetMaterialByNameAndClient(clientName, materialName);

            }
            catch (Exception)
            {
                Colour colour = new Colour(materialColors[0] / 255f, materialColors[1] / 255f, materialColors[2] / 255f);
                CreateLambertianMaterial(ClientController.GetClientByName(clientName), materialName, colour);
                return;
            }
            throw new BackEndException("material already exists");
        }
        private void CreateLambertianMaterial(Client client, string materialName, Colour colour)
        {
            Material material = new LambertianMaterial() { Client = client, Name = materialName, Attenuation = colour };
            DataWarehouse.Materials.Add(material);
        }

        public Material GetMaterialByNameAndClient(string clientName, string materialName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Material material in DataWarehouse.Materials)
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
                Material checkMaterialName = new LambertianMaterial() { Name = newName };
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                GetMaterialByNameAndClient(clientName, newName);
            }
            catch (Exception)
            {
                material.Name = newName;
            }
        }
        public void DeleteMaterialInList(string clientName, string materialName)
        {
            try
            {
                Material material = GetMaterialByNameAndClient(clientName, materialName);
                DataWarehouse.Materials.Remove(material);
            }
            catch (Exception)
            {
            }

        }
    }
}
