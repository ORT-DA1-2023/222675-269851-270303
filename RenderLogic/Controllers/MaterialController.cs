using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class MaterialController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }

        public void AddLambertianMaterial(MaterialDto materialDto)
        {
            try
            {
                GetMaterialByNameAndClient(materialDto.Name);

            }
            catch (Exception)
            {
                Colour colour = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f);
                CreateLambertianMaterial(ClientController.Client, materialDto.Name, colour);
                return;
            }
            throw new BackEndException("material already exists");
        }
        private void CreateLambertianMaterial(Client client, string materialName, Colour colour)
        {
            Material material = new LambertianMaterial() { Client = client, Name = materialName, Attenuation = colour };
            DataWarehouse.Materials.Add(material);
        }

        public Material GetMaterialByNameAndClient(string materialName)
        {
            Client client = ClientController.Client;
            foreach (Material material in DataWarehouse.Materials)
            {
                if (material.Name == materialName && material.Client.Equals(client))
                {
                    return material;
                }
            }
            throw new BackEndException("material doesnt exist");
        }
        public void ChangeMaterialName(string oldName, string newName)
        {
            Material material;
            try
            {
                material = GetMaterialByNameAndClient(oldName);
                Material checkMaterialName = new LambertianMaterial() { Name = newName };
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                GetMaterialByNameAndClient(newName);
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
                Material material = GetMaterialByNameAndClient(materialName);
                DataWarehouse.Materials.Remove(material);
            }
            catch (Exception)
            {
            }

        }

        public List<MaterialDto> GetMaterials()
        {
            throw new NotImplementedException();
        }
    }
}
