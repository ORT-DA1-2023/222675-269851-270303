using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.UserInterface.Panels;
using UserInterface;
using UserInterface.Controls;

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
                FigureControl figureControl = new FigureControl(figure);
                flObjectList.Controls.Add(figureControl);
            }
        }

        public void ShowMaterialList()
        {
            flObjectList.Controls.Clear();
            List<Material> materialList = render.dataWarehouse.Materials;
            foreach (Material material in materialList)
            {
                MaterialControl materialControl = new MaterialControl(material);
                flObjectList.Controls.Add(materialControl);
            }
        }
        public void ShowModelList()
        {
            flObjectList.Controls.Clear();
            List<Model> models = render.dataWarehouse.Models;
            foreach (Model model in models)
            {
                ModelControl modelControl = new ModelControl(model);
                flObjectList.Controls.Add(modelControl);
            }
        }


        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            render.userWantsToLogIn();
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

        

        private void showObjectCreationPanel(object formSon)
        {
            if(this.pnlObjectCreation.Controls.Count >0)
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
            showObjectCreationPanel(new FigurePanel());
            ShowFigureList();
        }
        public void Refresh(String toShow)
        {
            if(toShow=="Material")
            {
                showObjectCreationPanel(new MaterialPanel());
                ShowMaterialList();
            }
            if (toShow == "Figure")
            {
                showObjectCreationPanel(new FigurePanel());
                ShowFigureList();
            }
            if(toShow == "Model")
            {
                showObjectCreationPanel(new ModelPanel());
                ShowModelList();
            }
            
        }
        public bool FigureNameHasBeenChanged(String oldName,string newName)
        {
           render.figureController.ChangeFigureName(render.clientName,oldName, newName);
            if (render.figureController.GetFigureByNameAndClient(render.clientName, newName).Name != null)
            {
                return true;
            }
            return false;   
        }

        public void DeleteFigure(string figureName)
        {
          render.figureController.DeleteFigureInList(render.clientName,figureName);
        }

        internal bool MaterialNameHasBeenChanged(string oldName, string newName)
        {
             render.materialController.ChangeMaterialName(render.clientName, oldName, newName);
            if (render.materialController.GetMaterialByNameAndClient(render.clientName, newName) != null)
            {
                return true;
            }
            return false;
        }

        internal void DeleteMaterial(string materialName)
        {
          render.materialController.DeleteMaterialInList(render.clientName, materialName);
        }

        internal bool ModelNameHasBeenChanged(string oldName, string newName)
        {
             render.modelController.ChangeModelName(render.clientName,oldName,newName);
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
    }
}
