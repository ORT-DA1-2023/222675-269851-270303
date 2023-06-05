using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class ModelController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
        public GraphicMotor GraphicMotor { get; set; } = new GraphicMotor();
        public void AddAModelWithoutPreview(string modelName, FigureDto figureDto, MaterialDto materialDto)
        {

            try
            {
                GetModelByNameAndClient(modelName);

            }
            catch (Exception)
            {
                
                CreateAndAddModel(ClientController.Client, modelName, ConvertFigureDto(figureDto), ConvertMaterialDto(materialDto));
                return;
            }
            throw new BackEndException("model already exists");
        }

        private Material ConvertMaterialDto(MaterialDto materialDto)
        {
            Material material;
            if (materialDto.Blur == 0)
            {
                material = new LambertianMaterial()
                {
                    Client = ClientController.Client,
                    Name = materialDto.Name,
                    Attenuation = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f),
                };
            }
            else
            {
                material = new MetallicMaterial()
                {
                    Client = ClientController.Client,
                    Name = materialDto.Name,
                    Attenuation = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f),
                    //Blur=materialDto.Blur,
                };
            }
            return material;
           
        }
        public FigureDto ConvertFigure(Figure figure)
        {
            return new FigureDto()
            {
                Name = figure.Name,
                Radius = ((Sphere)figure).Radius
            };
        }
        public MaterialDto convertMaterial(Material material)
        {
            int blur=0;
            try
            {
                //blur = ((MetallicMaterial)material).Blur;
            }catch (Exception e)
            {
            }
            return new MaterialDto()
            {
                Name = material.Name,
                Red = material.Attenuation.Red(),
                Green = material.Attenuation.Green(),
                Blue = material.Attenuation.Blue(),
                Blur = blur,
            };
        }

        private Figure ConvertFigureDto(FigureDto figureDto)
        {
            Figure figure = new Sphere()
            {
                Client = ClientController.Client,
                Name= figureDto.Name,
                Radius = figureDto.Radius,
            };
            return figure;
        }

        public void AddAModelWithPreview(string modelName, FigureDto figure, MaterialDto material)
        {
            AddAModelWithoutPreview(modelName, figure, material);
            AddPreviewToTheModel(modelName);
        }
        private void CreateAndAddModel(Client client, string modelName, Figure figure, Material material)
        {
            Model model = new Model() { Client = client, Name = modelName, Figure = figure, Material = material };
            DataWarehouse.Models.Add(model);
        }
        public Model GetModelByNameAndClient(string modelName)
        {
            Client client = ClientController.Client;
            foreach (Model model in DataWarehouse.Models)
            {
                if (model.Name == modelName && model.Client.Equals(client))
                {
                    return model;
                }
            }
            throw new BackEndException("model doesnt exist");
        }
        private void AddPreviewToTheModel(string modelName)
        {
            Model model = GetModelByNameAndClient(modelName);
            model.Preview = GraphicMotor.RenderModelPreview(model);
        }
        public void ChangeModelName(string oldName, string newName)
        {
            Model model;
            try
            {
                model = GetModelByNameAndClient(oldName);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                GetModelByNameAndClient(newName);
            }
            catch (Exception)
            {
                model.Name = newName;
            }
        }

        public void DeleteModelInList(string modelName)
        {
            try
            {
                Model model = GetModelByNameAndClient(modelName);
                DataWarehouse.Models.Remove(model);
            }
            catch (Exception)
            {
            }

        }
       
        public List<FigureDto> GetFigures()
        {
            List<FigureDto> figureDtos = new List<FigureDto>();
            return figureDtos;
        }
        public List<MaterialDto> GetMaterials() 
        {
            List<MaterialDto> materialDtos = new List<MaterialDto>();
            return materialDtos;
        }

        public List<ModelDto> GetModels()
        {
            throw new NotImplementedException();
        }
    }

}
