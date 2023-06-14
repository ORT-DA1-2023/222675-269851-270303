using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{

    public partial class FigurePanel : Form
    {
        private CreationMenu creation;
        private readonly FigureController figureController;
        public FigurePanel()
        {
            InitializeComponent();
            figureController = FigureController.GetInstance();
            lblExceptionError.Text = "";
        }


        private void BtnCreateFigure_Click(object sender, EventArgs e)
        {
            lblExceptionError.Text = "";
            string figureRadiusString = txtFigureRadius.Text;
            double figureRadius;
            if (TryToParse(figureRadiusString) == -1)
            {
                lblExceptionError.Text = "the radius must be a number";
                return;
            }
            figureRadius = Convert.ToDouble(figureRadiusString);
            try
            {
                FigureDto figureDto = new FigureDto()
                {
                    Name = txtFigureName.Text,
                    Radius = figureRadius,
                };
                figureController.AddFigure(figureDto);
            }
            catch (Exception ex)
            {
                lblExceptionError.Text = ex.Message;
                return;
            }
            creation.ShowFigureList();
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
            lblCorrectlyAdded.Visible = true;
            lblCorrectlyAdded.Update();


        }

        private double TryToParse(string figureRadiusString)
        {
            try
            {
                double radius = double.Parse(figureRadiusString);
                return radius;
            }
            catch
            {
                return -1;
            }
        }

        private void VariablesInitialize(object sender, EventArgs e)
        {
            creation = (CreationMenu)this.Parent.Parent;
        }

        private void txtFigureName_TextChanged(object sender, EventArgs e)
        {
            lblCorrectlyAdded.Visible = false;
            lblCorrectlyAdded.Update();
        }

        private void txtFigureRadius_TextChanged(object sender, EventArgs e)
        {
            lblCorrectlyAdded.Visible = false;
            lblCorrectlyAdded.Update();
        }
    }
}
