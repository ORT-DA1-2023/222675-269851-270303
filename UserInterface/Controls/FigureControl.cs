using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;
using UserInterface.Panels;


namespace Render3D.UserInterface.Controls
{

    public partial class FigureControl : UserControl
    {
        private readonly FigureDto _figureDto;
        private readonly FigureController figureController;
        private readonly ModelController modelController;
        public FigureControl(FigureDto figure)
        {
            InitializeComponent();
            this.lblFigureName.Text = figure.Name;
            _figureDto = figure;
            figureController = FigureController.GetInstance();
            modelController = ModelController.GetInstance();
            this.lblFigureRadius.Text = "" + figure.Radius;
            lblErrorDeleteFigure.Text = "";
        }

        private void ChecksForCorrectEdit(string newName)
        {

            if (!_figureDto.Name.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ChangeFigureName(_figureDto, newName))
                {
                    lblFigureName.Text = newName;
                    _figureDto.Name = newName;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!modelController.CheckIfFigureIsInAModel(_figureDto))
            {
                figureController.Delete(_figureDto);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Figure");
            }
            else
            {
                lblErrorDeleteFigure.Text = "A model is using this figure";
            }

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_figureDto.Name))
            {
                var result = nameChanger.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string name = nameChanger.newName;
                    ChecksForCorrectEdit(name);
                }
            }

        }
    }
}
