
using Render3D.RenderLogic.Controllers;
using Render3D.UserInterface.Controls;
using Render3D.UserInterface.Panels;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Render3D.UserInterface
{
    public partial class CreationMenu : Form
    {
        private Render3DIU render;
        private readonly ClientController clientController;
        private readonly FigureController figureController;
        private readonly MaterialController materialController;
        private readonly ModelController modelController;
        private readonly SceneController sceneController;
        public CreationMenu()
        {
            InitializeComponent();
            clientController = ClientController.GetInstance();
            figureController = FigureController.GetInstance();
            materialController = MaterialController.GetInstance();
            modelController = ModelController.GetInstance();
            sceneController = SceneController.GetInstance();
        }

        public void ShowFigureList()
        {
            flObjectList.Controls.Clear();
            List<FigureDto> figureList;
            figureList=figureController.GetFigures();     
            foreach (FigureDto figure in figureList)
            {
                    FigureControl figureControl = new FigureControl(figure);
                    flObjectList.Controls.Add(figureControl);
            }
        }

        public void ShowMaterialList()
        {
            flObjectList.Controls.Clear();
            List<MaterialDto> materialList = materialController.GetMaterials();
            foreach (MaterialDto material in materialList)
            {
                    if(material.Blur ==0)
                    {
                        LambertianMaterialControl materialControl = new LambertianMaterialControl(material);
                        flObjectList.Controls.Add(materialControl);
                    }
                    else 
                    {
                        MetallicMaterialControl materialControl = new MetallicMaterialControl(material);
                        flObjectList.Controls.Add(materialControl);
                    }
                    
                    


            }
        }
        public void ShowModelList()
        {
            flObjectList.Controls.Clear();
            List<ModelDto> models = modelController.GetModels();
            foreach (ModelDto model in models)
            {
                    ModelControl modelControl = new ModelControl(model);
                    flObjectList.Controls.Add(modelControl);
            }
        }

        public void ShowSceneList()
        {
            flObjectList.Controls.Clear();
            List<SceneDto> scenes = sceneController.GetScenes();
            scenes.Sort((scene1, scene2) => scene2.LastModificationDate.CompareTo(scene1.LastModificationDate));
            foreach (SceneDto scene in scenes)
            {
                SceneControl sceneControl = new SceneControl(scene);
                flObjectList.Controls.Add(sceneControl);
            }
        }


        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            clientController.LogOut();
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
            lblShowClientName.Text = "Welcome back \n" + clientController.GetClient() + "!!";
            ShowObjectCreationPanel(new FigurePanel());
            ShowFigureList();
        }
        public void Refresh(string toShow)
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
        public bool ChangeFigureName(FigureDto figureDto, string newName)
        {
            try
            {
                figureController.ChangeName(figureDto,newName);
                return true;
            }
            catch
            {
                return false;
            }
        }


        internal bool MaterialNameHasBeenChange(MaterialDto materialDto,string newName)
        {
            try
            {
                materialController.ChangeName(materialDto,newName);
                return true;
            }
            catch
            {
                return false;
            }
            

        }

        internal void DeleteMaterial(MaterialDto materialDto)
        {
            materialController.Delete(materialDto);
        }

        internal bool ModelNameHasBeenChanged(ModelDto modelDto, string newName)
        {
            try
            {
                modelController.ChangeName(modelDto, newName);
                return true;
            }
            catch
            {
                return false;
            }
            
            
        }

        private void BtnScene_Click(object sender, EventArgs e)
        {
            Refresh("Scene");
        }
    }
}
