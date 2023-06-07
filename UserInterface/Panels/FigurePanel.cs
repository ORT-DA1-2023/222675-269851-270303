using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
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
            string figureRadiusString = txtFigureRadius.Text;
            double figureRadius;
            if (TryToParse(figureRadiusString) != -1)
            {
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
                }
                creation.ShowFigureList();
            }
            else
            {
                lblExceptionError.Text = "the radius must be a number";
            }
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
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
    }
}
