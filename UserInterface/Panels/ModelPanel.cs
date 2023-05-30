using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{

    public partial class ModelPanel : Form
    {
        private CreationMenu creation;
        private Render3DIU render;
        public ModelPanel()
        {
            InitializeComponent();
        }

        private void VariableInitialize(object sender, EventArgs e)
        {
            creation = (CreationMenu)this.Parent.Parent;
            render = ((Render3DIU)creation.Parent.Parent);
            lstFigure.Items.Clear();
            lstMaterial.Items.Clear();
            List<Figure> figureList = render.dataWarehouse.Figures;
            List<Material> materialList = render.dataWarehouse.Materials;
            foreach (Figure figure in figureList)
            {
                if (figure.Client.Name.Equals(render.clientName))
                {
                    lstFigure.Items.Add(figure);
                }

            }
            foreach (Material material in materialList)
            {
                if (material.Client.Name.Equals(render.clientName))
                {
                    lstMaterial.Items.Add(material);
                }
            }
            lblExceptionError.Text = "";
        }

        private void BtnCreateFigure_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text;
            Figure figure = lstFigure.SelectedItem as Figure;
            Material material = lstMaterial.SelectedItem as Material;
            if (figure == null || material == null)
            {
                return;
            }

            if (checkGeneratePreview.Checked)
            {
                try
                {
                    render.modelController.AddAModelWithPreview(render.clientName, modelName, figure, material);
                }
                catch (Exception ex)
                {
                    lblExceptionError.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    render.modelController.AddAModelWithoutPreview(render.clientName, modelName, figure, material);
                }
                catch (Exception ex)
                {
                    lblExceptionError.Text = ex.Message;
                }

            }

            creation.ShowModelList();
            txtModelName.Text = "";

        }
    }
}
