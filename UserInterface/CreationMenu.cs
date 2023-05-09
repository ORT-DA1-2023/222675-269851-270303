using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.UserInterface.Controls;
using Render3D.UserInterface.Panels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class CreationMenu : Form
    {
        private Render3DIU render;
        public CreationMenu()
        {
            InitializeComponent();
        }

        public void ShowFigureList()
        {
            flObjectList.Controls.Clear();
            List<Figure> figureList = render.dataWarehouse.Figures;
            foreach (Sphere figure in figureList)
            {
                if(figure.Client.Name.Equals(render.clientName))
                {
                    FigureControl figureControl = new FigureControl(figure);
                    flObjectList.Controls.Add(figureControl);
                }
            }
        }

        public void ShowMaterialList()
        {
            flObjectList.Controls.Clear();
            List<Material> materialList = render.dataWarehouse.Materials;
            foreach (Material material in materialList)
            {
                if(material.Client.Name.Equals(render.clientName))
                {
                    MaterialControl materialControl = new MaterialControl(material);
                    flObjectList.Controls.Add(materialControl);
                }

 
            }
        }
        public void ShowModelList()
        {
            flObjectList.Controls.Clear();
            List<Model> models = render.dataWarehouse.Models;
            foreach (Model model in models)
            {
                if (model.Client.Name.Equals(render.clientName))
                {
                    ModelControl modelControl = new ModelControl(model);
                    flObjectList.Controls.Add(modelControl);
                }
            }
        }

        public void ShowSceneList()
        {
            flObjectList.Controls.Clear();
            List<Scene> scenes =render.dataWarehouse.Scenes;
            foreach(Scene scene in scenes)
            {
                if (scene.Client.Name.Equals(render.clientName))
                {
                   SceneControl sceneControl= new SceneControl(scene);
                   flObjectList.Controls.Add(sceneControl);

                }
            }
        }


        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            render.UserWantsToLogIn();
        }
        private void BtnMaterial_Click(object sender, EventArgs e)
        {
            Refresh("Material");
        }

        private void BtnFigure_Click(object sender, EventArgs e)
        {
            Refresh("Figure");
        }

        private void BtnModel_Click(object sender, EventArgs e)
        {
            Refresh("Model");
        }



        private void ShowObjectCreationPanel(object formSon)
        {
            if (this.pnlObjectCreation.Controls.Count > 0)
            {
                this.pnlObjectCreation.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlObjectCreation.Controls.Add(form);
            this.pnlObjectCreation.Tag = form;
            form.Show();
        }

        private void VariablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblShowClientName.Text = "Welcome back \n" + render.clientName + "!!";
            ShowObjectCreationPanel(new FigurePanel());
            ShowFigureList();
        }
        public void Refresh(String toShow)
        {
            if (toShow == "Material")
            {
                ShowObjectCreationPanel(new MaterialPanel());
                ShowMaterialList();
            }
            if (toShow == "Figure")
            {
                ShowObjectCreationPanel(new FigurePanel());
                ShowFigureList();
            }
            if (toShow == "Model")
            {
                ShowObjectCreationPanel(new ModelPanel());
                ShowModelList();
            }
            if (toShow == "Scene")
            {
                ShowObjectCreationPanel(new ScenePanel());
                ShowSceneList();
            }

        }
        public bool FigureNameHasBeenChanged(string oldName,string newName)
        {
            try
            {
                render.figureController.GetFigureByNameAndClient(render.clientName, newName);
                return false;
            }
            catch (Exception)
            {
            }
            render.figureController.ChangeFigureName(render.clientName,oldName, newName);
            try
            {
                render.figureController.GetFigureByNameAndClient(render.clientName, newName);
                return true;
            }
            catch (Exception) 
            { 
                return false;
            }
        }

        public void DeleteFigure(string figureName)
        {
            render.figureController.DeleteFigureInList(render.clientName, figureName);
        }

        internal bool MaterialNameHasBeenChanged(string oldName, string newName)
        {
            try
            {
                render.materialController.GetMaterialByNameAndClient(render.clientName, newName);
                return false;
            }
            catch (Exception)
            {
            }
            render.materialController.ChangeMaterialName(render.clientName, oldName, newName);
            try
            {
                render.materialController.GetMaterialByNameAndClient(render.clientName, newName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        internal void DeleteMaterial(string materialName)
        {
            render.materialController.DeleteMaterialInList(render.clientName, materialName);
        }

        internal bool ModelNameHasBeenChanged(string oldName, string newName)
        {
            render.modelController.ChangeModelName(render.clientName, oldName, newName);
            if (render.modelController.GetModelByNameAndClient(render.clientName, newName) != null)
            {
                return true;
            }
            return false;
        }

        internal void DeleteModel(string modelName)
        {
            render.modelController.DeleteModelInList(render.clientName, modelName);
        }

        private void BtnScene_Click(object sender, EventArgs e)
        {
            Refresh("Scene");
        }

        internal void DeleteScene(string sceneName)
        {
           render.sceneController.DeleteSceneInList(render.clientName, sceneName);
        }
    }
}
