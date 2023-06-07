using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class ModelControl : UserControl
    {
       private readonly ModelDto _modelDto;
        private readonly SceneController sceneController;
        public ModelControl(ModelDto model)
        {
            InitializeComponent();
            lblModelName.Text = model.Name;
            _modelDto = model;
            sceneController = SceneController.GetInstance();
            lblModelFigure.Text = model.Figure.Name;
            lblModelMaterial.Text = model.Material.Name;
            lblErrorDeleteModel.Text = "";
            if (model.Preview != null)
            {
                pBoxPreview.Image = model.Preview;
            }
        }

        private void BtnEditModelName_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_modelDto.Name))
            {
                var result = nameChanger.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string name = nameChanger.newName;
                    ChecksForCorrectEdit(name);
                }
            }
        }


        private void ChecksForCorrectEdit(string newName)
        {
            if (!_modelDto.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ModelNameHasBeenChanged(_modelDto, newName))
                {
                    lblModelName.Text = newName;
                    _modelDto.Name = newName;
                }
            }
        }

        private void BtnDeleteModel_Click(object sender, EventArgs e)
        {
            if (!sceneController.CheckIfModelIsInAScene(_modelDto))
            {

                ((CreationMenu)this.Parent.Parent.Parent).DeleteModel(_modelDto);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Model");
            }
            else
            {
                lblErrorDeleteModel.Text = "A scene is using this model";
            }

        }
    }
}
