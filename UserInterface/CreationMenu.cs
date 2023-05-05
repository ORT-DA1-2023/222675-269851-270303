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

        public void showFigureList()
        {
            flObjectList.Controls.Clear();
            DataWarehouse listConteiners = render.dataTransferObject.DataWarehouse;
            List<Figure> figureList = listConteiners.Figures;
            foreach (Sphere figure in figureList)
            {
                FigureControl figureControl = new FigureControl(figure);
                flObjectList.Controls.Add(figureControl);
            }
        }

        public void showMaterialList()
        {
            flObjectList.Controls.Clear();
            DataWarehouse listConteiners = render.dataTransferObject.DataWarehouse;
            List<Material> materialList = listConteiners.Materials;
            foreach (Material material in materialList)
            {
                MaterialControl materialControl = new MaterialControl(material);
                flObjectList.Controls.Add(materialControl);
            }
        }
        public void showModelList()
        {
            flObjectList.Controls.Clear();
            DataWarehouse listConteiners = render.dataTransferObject.DataWarehouse;
            List<Model> models = listConteiners.Models;
            foreach (Model model in models)
            {
                ModelControl modelControl = new ModelControl(model);
                flObjectList.Controls.Add(modelControl);
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            render.userWantsToLogIn();
        }
        private void btnMaterial_Click(object sender, EventArgs e)
        {
            refresh("Material");
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            refresh("Figure");
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            refresh("Model");
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

        private void variablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblShowClientName.Text = "Welcome back \n" + render.clientName + "!!";
            showObjectCreationPanel(new FigurePanel());
            showFigureList();
        }
        public void refresh(String toShow)
        {
            if(toShow=="Material")
            {
                showObjectCreationPanel(new MaterialPanel());
                showMaterialList();
            }
            if (toShow == "Figure")
            {
                showObjectCreationPanel(new FigurePanel());
                showFigureList();
            }
            if(toShow == "Model")
            {
                showObjectCreationPanel(new ModelPanel());
                showModelList();
            }
            
        }
        public bool figureNameHasBeenChanged(String oldName,string newName)
        {
            return (render.dataTransferObject.ifPosibleChangeFigureName(render.clientName,oldName, newName));
        }

        public void deleteFigure(string figureName)
        {
          render.dataTransferObject.deleteFigureInList(render.clientName,figureName);
        }

        internal bool materialNameHasBeenChanged(string oldName, string newName)
        {
            return (render.dataTransferObject.ifPosibleChangeMaterialName(render.clientName, oldName, newName));
        }

        internal void deleteMaterial(string materialName)
        {
          render.dataTransferObject.deleteMaterialInList(render.clientName, materialName);
        }

        internal bool modelNameHasBeenChanged(string oldName, string newName)
        {
            return (render.dataTransferObject.ifPosibleChangeModelName(render.clientName,oldName,newName));
        }

        internal void deleteModel(string modelName)
        {
         render.dataTransferObject.deleteModelInList(render.clientName, modelName);
        }
    }
}
