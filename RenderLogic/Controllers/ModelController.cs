using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class ModelController
    {
        public ClientController ClientController = ClientController.GetInstance();
        public GraphicMotor GraphicMotor = new GraphicMotor();
        public ModelService ModelService { get; set; }
        protected static ModelController modelController;

        public static ModelController GetInstance()
        {
            if (modelController == null)
            {
                modelController = new ModelController();
            }
            return modelController;
        }
        public void AddAModelWithoutPreview(string modelName, FigureDto figureDto, MaterialDto materialDto)
        {
            try
            {
                ModelService.GetModelByNameAndClient(modelName,int.Parse(ClientController.Client.Id));
                throw new BackEndException("model already exists");
            }
            catch (Exception)
            {              
                CreateAndAddModel(modelName, ConvertFigureDto(figureDto), ConvertMaterialDto(materialDto));
            }         
        }

        private Material ConvertMaterialDto(MaterialDto materialDto)
        {
            Material material;
            if (materialDto.Blur == 0)
            {
                material = new LambertianMaterial()
                {
                    Id = materialDto.Id,
                    Client = ClientController.Client,
                    Name = materialDto.Name,
                    Attenuation = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f),
                };
            }
            else
            {
                material = new MetallicMaterial()
                {
                    Id = materialDto.Id,
                    Client = ClientController.Client,
                    Name = materialDto.Name,
                    Attenuation = new Colour(materialDto.Red / 255f, materialDto.Green / 255f, materialDto.Blue / 255f),
                    Blur=materialDto.Blur,
                };
            }
            return material;
           
        }
        public FigureDto ConvertFigure(Figure figure)
        {
            return new FigureDto()
            {
                Id = figure.Id,
                Name = figure.Name,
                Radius = ((Sphere)figure).Radius
            };
        }
        public MaterialDto ConvertMaterial(Material material)
        {
            double blur;
            try
            {
                blur = ((MetallicMaterial)material).Blur;
            }catch
            {
                blur=0;
            }
            return new MaterialDto()
            {
                Id = material.Id,
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
                Id = figureDto.Id,
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
        private void CreateAndAddModel(string modelName, Figure figure, Material material)
        {
            Model model = new Model()
            {
                Client=ClientController.Client,
                Name = modelName,
                Figure = figure, 
                Material = material };
            ModelService.AddModel(model);
        }
        private void AddPreviewToTheModel(string modelName)
        {
            Model model = ModelService.GetModelByNameAndClient(modelName,int.Parse(ClientController.Client.Id));
            model.Preview = GraphicMotor.RenderModelPreview(model);
            ModelService.UpdatePreview(model);
        }
        public void ChangeName(ModelDto modelDto, string newName)
        {
            try
            {
                Model material = ModelService.GetModelByNameAndClient(newName, int.Parse(ClientController.Client.Id));
                throw new Exception("There is already a material with that name");
            }
            catch
            {
            }
            Model tryName = new Model() { Name = newName };
            ModelService.UpdateName(int.Parse(modelDto.Id), newName);
        }

        public void Delete(ModelDto modelDto)
        {
            ModelService.RemoveModel(int.Parse(modelDto.Id));
        }
        public List<ModelDto> GetModels()
        {

            List<Model> Modellist;
            try
            {
                Modellist = ModelService.GetModelsOfClient(int.Parse(ClientController.Client.Id));
            }
            catch
            {
                throw new Exception("The client does not have any models");
            }

            List<ModelDto> modelDtos = new List<ModelDto>();
            foreach (Model mod in Modellist)
            {
                ModelDto modDto = new ModelDto()
                {
                    Id = mod.Id,
                    Name = mod.Name,
                    Figure= ConvertFigure(mod.Figure),
                    Material = ConvertMaterial(mod.Material),
                    Preview = mod.Preview,
                };
                modelDtos.Add(modDto);
            }
            return modelDtos;
        }

        public bool CheckIfFigureIsInAModel(FigureDto figureDto)
        {
               List<Model> expectedEmptyList = ModelService.GetModelsWithFigure(int.Parse(figureDto.Id));
            if(expectedEmptyList.Count == 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckIfMaterialIsInAModel(MaterialDto materialDto)
        {
            List<Model> expectedEmptyList = ModelService.GetModelsWithMaterial(int.Parse(materialDto.Id));
            if (expectedEmptyList.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
