using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class MaterialController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController = ClientController.GetInstance();
        protected static MaterialController materialController;
        public MaterialService MaterialService { get; set; }
        public static MaterialController GetInstance()
        {
            if (materialController == null)
            {
                materialController = new MaterialController();
            }
            return materialController;
        }

        public void AddLambertianMaterial(MaterialDto materialDto)
        {
            try
            {
                MaterialService.GetMaterialByNameAndClient(materialDto.Name,ClientController.Client);
                throw new BackEndException("material already exists");
            }
            catch (Exception)
            {
                Colour colour = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f);
                CreateLambertianMaterial(ClientController.Client, materialDto.Name, colour);
                return;
            }          
        }
        private void CreateLambertianMaterial(Client client, string materialName, Colour colour)
        {
            Material material = new LambertianMaterial() 
            { 
                Client = client,
                Name = materialName, 
                Attenuation = colour };
            MaterialService.AddMaterial(material);
        }

        public void ChangeName(MaterialDto materialDto, string newName)
        {
            try
            {
                Material material = MaterialService.GetMaterialByNameAndClient(newName, ClientController.Client);
                throw new Exception("There is already a material with that name");
            }
            catch
            {
            }
            Material tryName = new LambertianMaterial() { Name = newName };
            MaterialService.UpdateName(materialDto.Id, newName);
        }
        public void Delete(MaterialDto materialDto)
        {
            MaterialService.RemoveMaterial(int.Parse(materialDto.Id));
        }

        public List<MaterialDto> GetMaterials()
        {

            List<Material> MaterialList;
            try
            {
                MaterialList = MaterialService.GetMaterialsOfClient(ClientController.Client);
            }
            catch
            {
                throw new Exception("The client does not have any figures");
            }

            List<MaterialDto> materialDtos = new List<MaterialDto>();
            foreach (Material mat in MaterialList)
            {
                MaterialDto matDto = new MaterialDto()
                {
                    Id = mat.Id,
                    Name = mat.Name,
                    Red = mat.Attenuation.Red(),
                    Green = mat.Attenuation.Green(),
                    Blue = mat.Attenuation.Blue()
                };
               materialDtos.Add(matDto);
            }
            return materialDtos;
        }
    }
}
