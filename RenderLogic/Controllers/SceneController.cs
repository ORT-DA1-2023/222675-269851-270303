using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class SceneController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
        public GraphicMotor GraphicMotor { get; } = new GraphicMotor();

        protected static SceneController sceneController;
        
        public static SceneController GetInstance()
        {
            if(sceneController == null)
            {
                sceneController = new SceneController();
            }
            return sceneController;
        }

        public void EditCamera(Scene scene, string stringLookAt, string stringLookFrom, int fov, string aperture)
        {
            try
            {
                Camera camera;
                Vector3D lookAtVector = GetVectorFromString(stringLookAt);
                Vector3D lookFromVector = GetVectorFromString(stringLookFrom);
                Vector3D vectorUp = new Vector3D(0, 1, 0);
                double apertureDouble = double.Parse(aperture);
                if (apertureDouble > 0)
                {
                    camera = new Camera(lookFromVector, lookAtVector, vectorUp, fov, GraphicMotor.AspectRatio(), apertureDouble);
                }
                else
                {
                    camera = new Camera(lookFromVector, lookAtVector, vectorUp, fov, GraphicMotor.AspectRatio());
                }
                if (!scene.Camera.Equals(camera))
                {
                    scene.Camera = camera;
                    scene.UpdateLastModificationDate();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vector3D GetVectorFromString(string stringLookAt)
        {
            string[] values = stringLookAt.Substring(1, stringLookAt.Length - 2).Split(';');
            double[] valuesInDouble = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                valuesInDouble[i] = double.Parse(values[i]);
            }
            Vector3D vector = new Vector3D(valuesInDouble[0], valuesInDouble[1], valuesInDouble[2]);
            return vector;
        }

        public void AddScene(string sceneName)
        {
         
        }

        private void CreateAndAddBlankScene(string sceneName)
        {
         
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

        public void ChangeSceneName(string oldName, string newName)
        {
          
        }

        public void AddModel(Scene scene, Model model, string position)
        {
            Vector3D positionVector = GetVectorFromString(position);
            Sphere sphere = (Sphere)model.Figure;
            Figure newFigure = new Sphere() { Position = sphere.Position, Client = sphere.Client, Name = sphere.Name, Radius = sphere.Radius };
            Model newModel = new Model() { Client = model.Client, Name = model.Name, Figure = newFigure, Material = model.Material };
            newModel.Figure.Position = positionVector;
            scene.PositionedModels.Add(newModel);
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
