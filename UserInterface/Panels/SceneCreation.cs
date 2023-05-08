using Render3D.BackEnd;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Panels
{
    public partial class SceneCreation : Form
    {
        public Scene scene;
        public SceneController sceneController;
        string client;
        public SceneCreation(SceneController newSceneController, string clientName, Scene selectedScene)
        {
            InitializeComponent();
            sceneController = newSceneController;
            client= clientName;
            scene =selectedScene;
            if(scene==null )
            {
              GenerateDefaultScene();
            }        
              LoadScene();
        }

        private void GenerateDefaultScene()
        {
            string name = sceneController.GetNextValidName();
            sceneController.CreateAndAddBlankScene(client, name);
            scene = sceneController.GetSceneByNameAndClient(client, name);
        }

        private void LoadScene()
        {
            txtSceneName.Text = scene.Name;
            Camera cam = scene.Camera;
            txtLookAt.Text = "(" + cam.LookAt.X + "," + cam.LookAt.Y + "," + cam.LookAt.Z + "," + ")";
            txtLookFrom.Text = "(" + cam.LookFrom.X + "," + cam.LookFrom.Y + "," + cam.LookFrom.Z + "," + ")";
            nrFov.Value = cam.Fov;
        }

        public bool IsValidFormat(string input)
        {
            Regex vectorFormat = new Regex(@"^\(\s*-?\d+(\.\d+)?\s*,\s*-?\d+(\.\d+)?\s*,\s*-?\d+(\.\d+)?\s*\)$");
            return vectorFormat.IsMatch(input);
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnChangeCamera_Click(object sender, EventArgs e)
        {
            if(IsValidFormat(txtLookFrom.Text) && IsValidFormat(txtLookAt.Text))
            {
                sceneController.EditCamera(scene,txtLookAt.Text, txtLookFrom.Text,(int)nrFov.Value);
            }
        }

        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            sceneController.ChangeSceneName(scene.Client.Name,scene.Name, txtSceneName.Text);
        }
    }
}
