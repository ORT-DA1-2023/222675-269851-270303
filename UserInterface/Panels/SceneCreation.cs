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
            sceneController.AddScene(client, name);
            scene = sceneController.GetSceneByNameAndClient(client, name);
        }

        private void LoadScene()
        {
            txtSceneName.Text = scene.Name;
            Camera cam = scene.Camera;
            txtLookAt.Text = "(" + cam.LookAt.X + ";" + cam.LookAt.Y + ";" + cam.LookAt.Z + ")";
            txtLookFrom.Text = "(" + cam.LookFrom.X + ";" + cam.LookFrom.Y + ";" + cam.LookFrom.Z  + ")";
            nrFov.Value = cam.Fov;
            cBoxAvailableModels.Items.Clear();
            cBoxPositionedModels.Items.Clear();
            foreach (Model model in sceneController.DataWarehouse.Models)
            {
                cBoxAvailableModels.Items.Add(model);
            }
            foreach(Model model in scene.PositionedModels)
            {
                cBoxPositionedModels.Items.Add(model);
            }
            pBoxRender.Image = scene.Preview;
            lblCameraError.Text = "";
            lblNameError.Text = "";
            lblLastModificationDate.Text = "" + scene.LastModificationDate.Month + "/" + scene.LastModificationDate.Day + "/" + scene.LastModificationDate.Year + " " + scene.LastModificationDate.Hour + ":" + scene.LastModificationDate.Minute;
            if(scene.LastRenderizationDate != null)
            {
                lblLastRenderDate.Text = "" + ((DateTime)scene.LastRenderizationDate).Month + "/" + ((DateTime)scene.LastRenderizationDate).Day + "/" + ((DateTime)scene.LastRenderizationDate).Year + " " + ((DateTime)scene.LastRenderizationDate).Hour + ":" + ((DateTime)scene.LastRenderizationDate).Minute;
            }
            else
            {
                lblLastRenderDate.Text = "this scene has not been rendered yet";
            }
            CheckRenderOutDated();
        }

        private void CheckRenderOutDated()
        {
            if (scene.LastRenderizationDate==null  || scene.LastRenderizationDate < (scene.LastModificationDate))
            {
                lblRenderOutDated.Text = "WARNING this render is outdated";
            }
            else
            {
                lblRenderOutDated.Text = "";
            }
        }

        public bool IsValidFormat(string input)
        {
            Regex vectorFormat = new Regex(@"^\(\s*-?\d+(\.\d+)?\s*;\s*-?\d+(\.\d+)?\s*;\s*-?\d+(\.\d+)?\s*\)$");
            return vectorFormat.IsMatch(input);
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

     
        private void BtnChangeCamera_Click(object sender, EventArgs e)
        {
            if(IsValidFormat(txtLookFrom.Text) && IsValidFormat(txtLookAt.Text))
            {
                try
                {
                    sceneController.EditCamera(scene, txtLookAt.Text, txtLookFrom.Text, (int)nrFov.Value);
                    LoadScene();
                }catch (Exception ex)
                {
                    lblCameraError.Text = ex.Message;
                }
               
            }
        }

        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            try
            {
                sceneController.ChangeSceneName(scene.Client.Name, scene.Name, txtSceneName.Text);
                lblCameraError.Text = "";
            }
            catch(Exception ex)
            {
                lblNameError.Text = ex.Message;
            }
        }

        private void BtnAddModel_Click(object sender, EventArgs e)
        {
            string position = txtPosition.Text;
            if (!(cBoxAvailableModels.SelectedItem is Model model))
            {
                return;
            }
            sceneController.AddModel(scene,model,position);
            scene.UpdateLastModificationDate();
            LoadScene();
            cBoxAvailableModels.SelectedItem = null;
        }

        private void BtnRemoveModel_Click(object sender, EventArgs e)
        {
            if (!(cBoxPositionedModels.SelectedItem is Model model))
            {
                return;
            }
            sceneController.RemoveModel(scene,model);
            scene.UpdateLastModificationDate();
            LoadScene();
            cBoxPositionedModels.SelectedItem = null;
        }

        private void BtnRender_Click(object sender, EventArgs e)
        {
            sceneController.RenderScene(scene);
            LoadScene();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
