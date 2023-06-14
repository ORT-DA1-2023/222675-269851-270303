using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Panels
{
    public partial class ScenePanel : Form
    {
        SceneController sceneController = SceneController.GetInstance();
        private SceneDto _sceneDto;
        public ScenePanel()
        {
            InitializeComponent();
            lblError.Text = "";


        }

        private void BtnCreateScene_Click(object sender, EventArgs e)
        {

            CreationMenu creation = (CreationMenu)this.Parent.Parent;
            string name;
            NameChanger nameChanger = new NameChanger("");
            DialogResult result = nameChanger.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                name = nameChanger.newName;
                try
                {
                    sceneController.AddScene(name);
                    _sceneDto = new SceneDto() { Name = name };
                    SceneDto camera = sceneController.ClientController.GetCamera();
                    if (int.Parse(camera.Id) != 0)
                    {
                        string lookAt = "(" + camera.LookAt[0] + ";" + camera.LookAt[1] + ";" + camera.LookAt[2] + ")";
                        string lookFrom = "(" + camera.LookFrom[0] + ";" + camera.LookFrom[1] + ";" + camera.LookFrom[2] + ")";
                        sceneController.EditCamera(sceneController.GetScene(name), lookAt, lookFrom, camera.Fov, camera.Aperture.ToString());
                    }
                    SceneCreation scene = new SceneCreation(_sceneDto);
                    DialogResult res = scene.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        creation.Refresh("Scene");
                    }
                    if (res == DialogResult.Cancel)
                    {
                        scene.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }



        }

    }
}
