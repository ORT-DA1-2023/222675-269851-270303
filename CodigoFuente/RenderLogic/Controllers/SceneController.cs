﻿using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.IODrivers;
using Render3D.BackEnd.IODrivers.Output;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Output.FileFormat;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Render3D.RenderLogic.Controllers
{
    public class SceneController
    {
        public ClientController ClientController = ClientController.GetInstance();
        public GraphicMotor GraphicMotor = new GraphicMotor();
        public SceneService SceneService { get; set; }
        public ModelService ModelService { get; set; }
        public FigureService FigureService { get; set; }
        public MaterialService MaterialService { get; set; }
        public LogController LogController = LogController.GetInstance();

        protected static SceneController sceneController;

        public static SceneController GetInstance()
        {
            if (sceneController == null)
            {
                sceneController = new SceneController();
            }
            return sceneController;
        }

        public void EditCamera(SceneDto sceneDto, string stringLookAt, string stringLookFrom, int fov, string aperture)
        {
            double[] lookAt = GetArrayFromString(stringLookAt);
            double[] lookFrom = GetArrayFromString(stringLookFrom);
            double apertureDouble = double.Parse(aperture);
            SceneDto sceneNewCamera = new SceneDto()
            {
                LookAt = lookAt,
                LookFrom = lookFrom,
                Fov = fov,
                Aperture = apertureDouble
            };
            if (!CameraAreEqual(sceneDto, sceneNewCamera))
            {
                Camera camera;
                if (apertureDouble > 0)
                {
                    camera = new Camera(
                      new Vector3D(lookFrom[0], lookFrom[1], lookFrom[2]),

                      new Vector3D(lookAt[0], lookAt[1], lookAt[2]),
                      fov,
                      sceneNewCamera.Aperture);
                }
                else
                {
                    camera = new Camera(
                      new Vector3D(lookFrom[0], lookFrom[1], lookFrom[2]),

                      new Vector3D(lookAt[0], lookAt[1], lookAt[2]),
                      fov);
                }
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

        private bool CameraAreEqual(SceneDto scene, SceneDto sceneNewCamera)
        {
            if (scene.LookAt[0] != sceneNewCamera.LookAt[0]
                || scene.LookAt[1] != sceneNewCamera.LookAt[1]
                || scene.LookAt[2] != sceneNewCamera.LookAt[2])
            {
                return false;
            }
            if (scene.LookFrom[0] != sceneNewCamera.LookFrom[0]
                || scene.LookFrom[1] != sceneNewCamera.LookFrom[1]
                || scene.LookFrom[2] != sceneNewCamera.LookFrom[2])
            {
                return false;
            }
            if (scene.Aperture != sceneNewCamera.Aperture) return false;
            if (scene.Fov != sceneNewCamera.Fov) return false;
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
                SceneService.GetSceneByNameAndClient(sceneName, int.Parse(ClientController.Client.Id));
            }
            catch
            {
                CreateAndAddBlankScene(sceneName);
                return;
            }
            throw new Exception("The scene already exists");
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

        public void Delete(SceneDto sceneDto)
        {
            List<ModelDto> models = GetPositionedModels(sceneDto);
            foreach (ModelDto modelDto in models)
            {
                RemoveModel(sceneDto, modelDto);
            }
            SceneService.RemoveScene(int.Parse(sceneDto.Id));
        }

        public void ChangeSceneName(SceneDto sceneDto, string newName)
        {
            try
            {
                SceneService.GetSceneByNameAndClient(newName, int.Parse(ClientController.Client.Id));
            }
            catch
            {
                Scene tryName = new Scene() { Name = newName };
                SceneService.UpdateName(int.Parse(sceneDto.Id), newName);
                return;
            }
            throw new Exception("Name already in use");

        }

        public void AddModel(SceneDto sceneDto, ModelDto modelDto, string position)
        {
            Scene scene = SceneService.GetScene(int.Parse(sceneDto.Id));
            scene.Client = ClientController.Client;
            Model model = ModelService.GetModel(int.Parse(modelDto.Id));
            double[] pos = GetArrayFromString(position);
            Vector3D positionVector = new Vector3D(pos[0], pos[1], pos[2]);
            model.Figure.Position = positionVector;
            model.Id = null;
            model.Figure.Id = null;
            model.Material.Id = null;
            scene.UpdateLastModificationDate();
            SceneService.AddModel(scene, model);

        }

        public void RemoveModel(SceneDto sceneDto, ModelDto modelDto)
        {
            Scene s = new Scene
            {
                Id = sceneDto.Id,
            };
            s.UpdateLastModificationDate();
            Model m = new Model
            {
                Id = modelDto.Id,
                Figure = new Sphere { Id = modelDto.Figure.Id, },
                Material = new LambertianMaterial { Id = modelDto.Material.Id, }
            };
            SceneService.RemoveModel(s, m);
        }

        public void RenderScene(SceneDto sceneDto, bool useBlur)
        {
            Scene scene = SceneService.GetScene(int.Parse(sceneDto.Id));
            DateTime renderStarts = DateTime.Now;
            scene.Preview = GraphicMotor.Render(scene, useBlur);
            LogController.AddLogFromScene(scene, renderStarts);
            scene.UpdateLastRenderizationDate();
            SceneService.UpdatePreview(scene);
        }



        public List<SceneDto> GetScenes()
        {
            List<Scene> scenes = SceneService.GetScenesOfClient(int.Parse(ClientController.Client.Id));
            return ScenesIntoDtos(scenes);
        }

        private List<SceneDto> ScenesIntoDtos(List<Scene> scenes)
        {
            List<SceneDto> sceneDtos = new List<SceneDto>();
            foreach (Scene scene in scenes)
            {
                DateTime lastRenderizationDate;
                try
                {
                    lastRenderizationDate = ((DateTime)scene.LastRenderizationDate);
                }
                catch
                {
                    lastRenderizationDate = DateTime.MinValue;
                }
                double[] lookAt = new double[] { scene.Camera.LookAt.X, scene.Camera.LookAt.Y, scene.Camera.LookAt.Z };
                double[] lookFrom = new double[] { scene.Camera.LookFrom.X, scene.Camera.LookFrom.Y, scene.Camera.LookFrom.Z };
                SceneDto sceneDto = new SceneDto()
                {
                    Id = scene.Id,
                    Name = scene.Name,
                    Preview = scene.Preview,
                    LastModificationDate = scene.LastModificationDate,
                    LastRenderizationDate = lastRenderizationDate,
                    Models = ModelsIntoDtos(scene.PositionedModels),
                    Aperture = scene.Camera.LensRadius * 2,
                    LookAt = lookAt,
                    LookFrom = lookFrom,
                    Fov = scene.Camera.Fov
                };
                sceneDtos.Add(sceneDto);
            }
            return sceneDtos;
        }

        public List<ModelDto> GetAvailableModels()
        {
            List<Model> models = ModelService.GetModelsOfClient(int.Parse(ClientController.Client.Id));
            return ModelsIntoDtos(models);
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
        private MaterialDto ConvertMaterial(Material material)
        {
            double blur = 0;
            try
            {
                blur = ((MetallicMaterial)material).Blur;
            }
            catch (Exception)
            {
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
                Id = modelDto.Id,
                Name = modelDto.Name,
                Client = ClientController.Client
            };
            List<Scene> ExpectedEmptyList = SceneService.GetScenesWithModel(model);
            if (ExpectedEmptyList.Count == 0)
            {
                return false;
            }
            return true;
        }

        public SceneDto GetScene(string name)
        {
            Scene scene = SceneService.GetSceneByNameAndClient(name, int.Parse(ClientController.Client.Id));
            DateTime lastRenderizationDate;
            try
            {
                lastRenderizationDate = ((DateTime)scene.LastRenderizationDate);
            }
            catch
            {
                lastRenderizationDate = DateTime.MinValue;
            }
            double[] lookAt = new double[] { scene.Camera.LookAt.X, scene.Camera.LookAt.Y, scene.Camera.LookAt.Z };
            double[] lookFrom = new double[] { scene.Camera.LookFrom.X, scene.Camera.LookFrom.Y, scene.Camera.LookFrom.Z };
            SceneDto sceneDto = new SceneDto()
            {
                Id = scene.Id,
                Name = scene.Name,
                Preview = scene.Preview,
                LastModificationDate = scene.LastModificationDate,
                LastRenderizationDate = lastRenderizationDate,
                Models = ModelsIntoDtos(scene.PositionedModels),
                Aperture = scene.Camera.LensRadius * 2,
                LookAt = lookAt,
                LookFrom = lookFrom,
                Fov = scene.Camera.Fov
            };
            return sceneDto;
        }

        public void ExportRender(SceneDto s, string directory, string savingFormat)
        {

            Bitmap bitmap = s.Preview;
            ISavingFormat format;

            switch (savingFormat)
            {
                case "png":
                    format = new PNGSavingDriver();
                    break;
                case "jpg":
                    format = new JPGSavingDriver();
                    break;
                case "ppm":
                    format = new PPMSavingDriver();
                    break;
                default:
                    throw new Exception("invalid format");
            }

            OutputDriver o = new OutputDriver(format);
            o.Save(bitmap, directory);

        }

        public bool IsValidDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
