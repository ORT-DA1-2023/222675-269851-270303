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
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
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
                ModelService.GetModelByNameAndClient(modelName,ClientController.Client);
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
        public MaterialDto ConvertMaterial(Material material)
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
            Model model = ModelService.GetModelByNameAndClient(modelName,ClientController.Client);
            model.Preview = GraphicMotor.RenderModelPreview(model);
            ModelService.UpdatePreview(model);
        }
        public void ChangeName(ModelDto modelDto, string newName)
        {
            try
            {
                Model material = ModelService.GetModelByNameAndClient(newName, ClientController.Client);
                throw new Exception("There is already a material with that name");
            }
            catch
            {
                ModelService.UpdateName(modelDto.Id, newName);
            }
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
                Modellist = ModelService.GetModelsOfClient(ClientController.Client);
            }
            catch
            {
                throw new Exception("The client does not have any figures");
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
                };
                modelDtos.Add(modDto);
            }
            return modelDtos;
        }

        public bool CheckIfFigureIsInAModel(FigureDto figure)
        {
            try
            {
                ModelService.GetModelsWithFigure(ConvertFigureDto(figure));
                return false;
            }catch
            {
                return true; 
            }
        }
        public bool CheckIfMaterialIsInAModel(MaterialDto material)
        {
            try
            {
                ModelService.GetModelsWithMaterial(ConvertMaterialDto(material));
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
