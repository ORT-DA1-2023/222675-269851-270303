using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;
using UserInterface.Panels;


namespace Render3D.UserInterface.Controls
{

    public partial class FigureControl : UserControl
    {
        private FigureDto _figureDto;
        public FigureControl(FigureDto figure)
        {
            InitializeComponent();
            this.lblFigureName.Text = figure.Name;
            _figureDto = figure;
            this.lblFigureRadius.Text = "" + figure.Radius;
            lblErrorDeleteFigure.Text = "";
        }

        private void ChecksForCorrectEdit(string newName)
        {

            if (!_figureDto.Name.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ChangeFigureName(_figureDto.Id, newName))
                {
                    lblFigureName.Text = newName;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!((CreationMenu)this.Parent.Parent.Parent).FigureIsPartOfModel(lblFigureName.Text))
            {
                ((CreationMenu)this.Parent.Parent.Parent).DeleteFigure(_figureDto);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Figure");
            }
            else
            {
                lblErrorDeleteFigure.Text = "A model is using this figure";
            }

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_oldName))
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
