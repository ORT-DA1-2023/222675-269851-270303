using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class SceneController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
        public GraphicMotor GraphicMotor = new GraphicMotor();
        public SceneService SceneService { get; set; }

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
                double[] lookAt= GetVectorFromString(stringLookAt);
                double[] lookFrom = GetVectorFromString(stringLookFrom);
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

        private double[] GetVectorFromString(string stringLookAt)
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
        public void DeleteSceneInList(string clientName, string sceneName)
        {
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
            SceneService.UpdateName(sceneDto.Id, newName);
        }

        public void AddModel(Scene scene, Model model, string position)
        {
        }

        public void RemoveModel(Scene scene, Model model)
        {
            scene.PositionedModels.Remove(model);
        }

        public void RenderScene(Scene scene)
        {
            bool blur = false;
            scene.Preview = GraphicMotor.Render(scene, blur);
            scene.UpdateLastRenderizationDate();
        }

        public List<Scene> GetSceneWithModel(string modelName)
        {
            List<Scene> sceneWithModel = new List<Scene>();
            foreach (Scene scene in DataWarehouse.Scenes)
            {
                foreach (Model model in scene.PositionedModels)
                {
                    if (model.Name.Equals(modelName))
                    {
                        sceneWithModel.Add(scene);
                    }
                }

            }
            if (sceneWithModel.Count == 0)
            {
                throw new BackEndException("No scene found");
            }
            return sceneWithModel;
        }

        public void RenderSceneBlur(Scene scene)
        {
            bool blur = true;
            scene.Preview = GraphicMotor.Render(scene, blur);
            scene.UpdateLastRenderizationDate();
        }

        public List<SceneDto> GetScenes()
        {
            throw new NotImplementedException();
        }
    }
}
