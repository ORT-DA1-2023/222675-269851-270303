using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{

    public partial class ModelPanel : Form
    {
        private CreationMenu creation;
        private readonly FigureController figureController;
        private readonly MaterialController materialController;
        private readonly ModelController modelController;
        public ModelPanel()
        {
            InitializeComponent();
            figureController = FigureController.GetInstance();
            materialController = MaterialController.GetInstance();
            modelController = ModelController.GetInstance();
        }

        private void VariableInitialize(object sender, EventArgs e)
        {
            creation = (CreationMenu)this.Parent.Parent;
            lstFigure.Items.Clear();
            lstMaterial.Items.Clear();
            List<FigureDto> figureList = figureController.GetFigures();
            List<MaterialDto> materialList = materialController.GetMaterials();
            foreach (FigureDto figure in figureList)
            {
                    lstFigure.Items.Add(figure);
            }
            lstFigure.DisplayMember = "Name";
            foreach (MaterialDto material in materialList)
            {
                    lstMaterial.Items.Add(material);
            }
            lstMaterial.DisplayMember = "Name";
            lblExceptionError.Text = "";
        }

        private void BtnCreateModel_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text;
            if (!(lstFigure.SelectedItem is FigureDto figure) || !(lstMaterial.SelectedItem is MaterialDto material))
            {
                return;
            }

            if (checkGeneratePreview.Checked)
            {
                try
                {
                    modelController.AddAModelWithPreview(modelName, figure, material);
                    txtModelName.Text = "";
                    label6.Visible = true;
                    label6.Update();
                }
                catch (Exception ex)
                {
                    label6.Visible = false;
                    label6.Update();
                    lblExceptionError.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    modelController.AddAModelWithoutPreview(modelName, figure, material);
                    label6.Visible = true;
                    label6.Update();
                }
                catch (Exception ex)
                {
                    label6.Visible = false;
                    label6.Update();
                    lblExceptionError.Text = ex.Message;

                }

            }

            creation.ShowModelList();
            

        }
    }
}
