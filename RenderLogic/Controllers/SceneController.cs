using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Render3D.RenderLogic.Controllers
{
    public class SceneController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController = ClientController.GetInstance();
        public GraphicMotor GraphicMotor = new GraphicMotor();
        public SceneService SceneService { get; set; }
        public ModelService ModelService { get; set; }

        protected static SceneController sceneController;
        
        public static SceneController GetInstance()
        {
            if(sceneController == null)
            {
                sceneController = new SceneController();
            }
            return sceneController;
        }

        public void EditCamera(SceneDto sceneDto, string stringLookAt, string stringLookFrom, int fov, string aperture)
        {
            try
            {
                double[] lookAt= GetArrayFromString(stringLookAt);
                double[] lookFrom = GetArrayFromString(stringLookFrom);
                double apertureDouble = double.Parse(aperture);
                SceneDto sceneNewCamera = new SceneDto() 
                {
                    LookAt= lookAt, 
                    LookFrom = lookFrom, 
                    Fov =fov, 
                    Aperture = apertureDouble };
                if (!CameraAreEqual(sceneDto, sceneNewCamera))
                {
                    Camera camera = new Camera(
                        new Vector3D(lookAt[0], lookAt[1], lookAt[2]),
                        new Vector3D(lookFrom[0], lookFrom[1], lookFrom[2]),
                        fov,
                        sceneDto.Aperture);
                    Scene scene = new Scene()
                    {
                        Id = sceneDto.Id,
                        Name = sceneDto.Name,
                        LastModificationDate = sceneDto.LastModificationDate,
                        LastRenderizationDate = sceneDto.LastRenderizationDate,
                        Camera = camera,
                    };
                    scene.UpdateLastModificationDate();
                    SceneService.UpdateCamera(scene);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CameraAreEqual(SceneDto scene, SceneDto sceneNewCamera)
        {
            if (!Array.Equals(scene.LookAt, sceneNewCamera.LookAt)) return false;
            if(!Array.Equals(scene.LookFrom, sceneNewCamera.LookFrom)) return false;
            if(scene.Aperture != sceneNewCamera.Aperture) return false;
            if(scene.Fov != sceneNewCamera.Fov) return false;
            return true;
        }

        private double[] GetArrayFromString(string stringLookAt)
        {
            string[] values = stringLookAt.Substring(1, stringLookAt.Length - 2).Split(';');
            double[] valuesInDouble = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                valuesInDouble[i] = double.Parse(values[i]);
            }
            return valuesInDouble;
        }

        public void AddScene(string sceneName)
        {
            try
            {
                SceneService.GetSceneByNameAndClient(sceneName, ClientController.Client);
                throw new Exception("scene already exists");
            }
            catch
            {
                CreateAndAddBlankScene(sceneName);
            }
        }

        private void CreateAndAddBlankScene(string sceneName)
        {
            Scene scene = new Scene
            {
                Name = sceneName,
                Client = ClientController.Client,
            };
            SceneService.AddScene(scene);
        }

        public string GetNextValidName()
        {
            string posibleName = "Blank_name_";
            int i = 1;
            bool found = false;
            while (!found)
            {
                bool validName = true;
                foreach (Scene scene in DataWarehouse.Scenes)
                {
                    if (scene.Name == posibleName + i)
                    {
                        validName = false;
                    }
                }
                if (validName)
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            return posibleName + i;

        }
        public void Delete(SceneDto sceneDto)
        {
            SceneService.RemoveScene(int.Parse(sceneDto.Id));
        }

        public void ChangeSceneName(SceneDto sceneDto, string newName)
        {
            try
            {
                SceneService.GetSceneByNameAndClient(newName, ClientController.Client);
                throw new Exception("Name already in use");
            }
            catch 
            {
            }
            Scene tryName = new Scene() { Name = newName };
            SceneService.UpdateName(int.Parse(sceneDto.Id), newName);
        }

        public void AddModel(SceneDto sceneDto, ModelDto modelDto, string position)
        {
            Scene scene = SceneService.GetScene(int.Parse(sceneDto.Id));
            Model model = ModelService.GetModel(int.Parse(modelDto.Id));
            double[] pos = GetArrayFromString(position);
            Vector3D positionVector = new Vector3D(pos[0], pos[1], pos[2]);
            model.Figure.Id = null;
            model.Figure.Position = positionVector;
            model.Id = null;
            SceneService.AddModel(int.Parse(scene.Id), model);
        }

        public void RemoveModel(string sceneId, ModelDto modelDto)
        {
            Model model = ModelService.GetModel(int.Parse(modelDto.Id));
            SceneService.RemoveModel(int.Parse(sceneId), model);
        }

        public void RenderScene(SceneDto sceneDto, bool useBlur)
        {
            Camera camera = new Camera(
                new Vector3D(sceneDto.LookFrom[0], sceneDto.LookFrom[1], sceneDto.LookFrom[2]),
                new Vector3D(sceneDto.LookAt[0], sceneDto.LookAt[1], sceneDto.LookAt[2]),
                sceneDto.Fov,
                sceneDto.Aperture
                );
            Scene scene = new Scene()
            {
                Id = sceneDto.Id,
                Name = sceneDto.Name,
                Camera = camera,
                LastModificationDate = sceneDto.LastModificationDate,
                LastRenderizationDate = sceneDto.LastRenderizationDate,
            };
            scene.Preview = GraphicMotor.Render(scene, useBlur);
            scene.UpdateLastRenderizationDate();
            SceneService.UpdatePreview(scene);
        }



        public List<SceneDto> GetScenes()
        {
            throw new NotImplementedException();
        }

        public List<ModelDto> GetAvailableModels()
        {
            List <Model> models= ModelService.GetModelsOfClient(int.Parse(ClientController.Client.Id));
            return ModelsIntoDtos(models);
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
            int blur = 0;
            try
            {
                //blur = ((MetallicMaterial)material).Blur;
            }
            catch (Exception e)
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

        public List<ModelDto> GetPositionedModels(SceneDto sceneDto)
        {
            Scene scene = SceneService.GetScene(int.Parse(sceneDto.Id));
            return ModelsIntoDtos(scene.PositionedModels);
        }

        private List<ModelDto> ModelsIntoDtos(List<Model> positionedModels)
        {
            List<ModelDto> modelDtos = new List<ModelDto>();
            foreach (Model model in positionedModels)
            {
                ModelDto modelDto = new ModelDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Figure = ConvertFigure(model.Figure),
                    Material = ConvertMaterial(model.Material),
                    Preview = model.Preview,
                };
                modelDtos.Add(modelDto);
            }
           return modelDtos;
        }

        public bool CheckIfModelIsInAScene(ModelDto modelDto)
        {
            Model model = new Model()
            {
                Id =modelDto.Id,
                Name = modelDto.Name,
                Client = ClientController.Client
            };
            try
            {
                List<Scene> ExpectedEmptyList = SceneService.GetScenesWithModel(model);
                return false;
            }
            catch
            {
                return true;
            }
        }

    }
}
