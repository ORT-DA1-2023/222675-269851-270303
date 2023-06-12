using Microsoft.SqlServer.Server;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;

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
            try
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
                    Camera camera = new Camera(
                        new Vector3D(lookFrom[0], lookFrom[1], lookFrom[2]),
                   
                        new Vector3D(lookAt[0], lookAt[1], lookAt[2]),
                        fov,
                        sceneNewCamera.Aperture);
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
            if (!Array.Equals(scene.LookFrom, sceneNewCamera.LookFrom)) return false;
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
                Scene scene = new Scene() { Name = sceneName };
            }
            catch (BackEndException ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                SceneService.GetSceneByNameAndClient(sceneName, int.Parse(ClientController.Client.Id));

            }
            catch
            {
                CreateAndAddBlankScene(sceneName);
                return;
            }
            throw new Exception("scene already exists");
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
            Model model = ModelService.GetModel(int.Parse(modelDto.Id));
            double[] pos = GetArrayFromString(position);
            Vector3D positionVector = new Vector3D(pos[0], pos[1], pos[2]);
            model.Figure.Position = positionVector;
            model.Id = null;
            model.Figure.Id = null;
            model.Material.Id = null;
            SceneService.AddModel(int.Parse(scene.Id), model);
        }

        public void RemoveModel(ModelDto modelDto)
        {
            int modelId = int.Parse(modelDto.Id);
            int figureId = int.Parse(modelDto.Figure.Id);
            int materialId = int.Parse(modelDto.Material.Id);
            ModelService.RemoveModel(modelId);
            FigureService.RemoveFigure(figureId);
            MaterialService.RemoveMaterial(materialId);
        }

        public void RenderScene(SceneDto sceneDto, bool useBlur)
        {
            Scene scene = SceneService.GetScene(int.Parse(sceneDto.Id));
            scene.Preview = GraphicMotor.Render(scene, useBlur);
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
        public MaterialDto ConvertMaterial(Material material)
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

            // Save the image as a PNG or JPEG
            if (savingFormat == "png") { s.Preview.Save(directory + "\\render.png", ImageFormat.Png); return; }
            if (savingFormat == "jpg") { s.Preview.Save(directory + "\\render.jpg", ImageFormat.Jpeg); return; }
            if (savingFormat == "ppm")
            {

                using (StreamWriter writer = new StreamWriter(directory))
                {
                    // Write the PPM file header
                    writer.WriteLine("P3");  // Magic number for PPM
                    writer.WriteLine($"{bitmap.Width} {bitmap.Height}");  // Width and height
                    writer.WriteLine("255");  // Maximum color value

                    // Write the pixel data
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Color pixelColor = bitmap.GetPixel(x, y);
                            writer.Write($"{pixelColor.R} {pixelColor.G} {pixelColor.B} ");
                        }
                        writer.WriteLine();  // Move to the next line after each row
                    }
                }

                return;
            }

            throw new Exception("error");
        }

    }
}
