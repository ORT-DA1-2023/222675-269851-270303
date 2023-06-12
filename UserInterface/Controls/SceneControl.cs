using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class SceneControl : UserControl
    {
        private readonly SceneDto _sceneDto;
        private readonly SceneController sceneController;
        public SceneControl(SceneDto selectedScene)
        {
            InitializeComponent();
            _sceneDto = selectedScene;
            lblSceneName.Text = _sceneDto.Name;
            sceneController = SceneController.GetInstance();
            lblSceneModificationDate.Text = "" + _sceneDto.LastModificationDate.Month + "/" + _sceneDto.LastModificationDate.Day + "/" + _sceneDto.LastModificationDate.Year + " " + _sceneDto.LastModificationDate.Hour + ":" + _sceneDto.LastModificationDate.Minute;
            if (_sceneDto.Preview != null)
            {
                pBoxPreview.Image = _sceneDto.Preview;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            sceneController.Delete(_sceneDto);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Scene");

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CreationMenu creation = (CreationMenu)this.Parent.Parent.Parent;
            using (var scene = new SceneCreation(_sceneDto))
            {
                var result = scene.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    creation.Refresh("Scene");
                }
            }
        }
    }
}
