﻿using RenderLogic.DataTransferObjects;
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
            List<FigureDto> figureList = render.modelController.GetFigures();
            List<MaterialDto> materialList = render.modelController.GetMaterials();
            foreach (FigureDto figure in figureList)
            {
                    lstFigure.Items.Add(figure);
            }
            foreach (MaterialDto material in materialList)
            {
                    lstMaterial.Items.Add(material);
            }
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
                    render.modelController.AddAModelWithPreview(modelName, figure, material);
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
                    render.modelController.AddAModelWithoutPreview(modelName, figure, material);
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
