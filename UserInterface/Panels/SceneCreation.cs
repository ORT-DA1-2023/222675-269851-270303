using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserInterface.Panels
{
    public partial class SceneCreation : Form
    {
        private readonly SceneDto _sceneDto;
        public SceneController sceneController;
        public SceneCreation(SceneDto selectedScene)
        {
            InitializeComponent();
            sceneController = SceneController.GetInstance();
            _sceneDto = selectedScene;
            if (_sceneDto == null)
            {
                GenerateDefaultScene();
            }
            LoadScene();
        }

        private void GenerateDefaultScene()
        {
            string name = sceneController.GetNextValidName();
            sceneController.AddScene(name);
        }

        private void LoadScene()
        {
            txtSceneName.Text = _sceneDto.Name;
            txtLookAt.Text = "(" + _sceneDto.LookAt[0] + ";" + _sceneDto.LookAt[1] + ";" + _sceneDto.LookAt[2] + ")";
            txtLookFrom.Text = "(" + _sceneDto.LookFrom[0] + ";" + _sceneDto.LookFrom[1] + ";" + _sceneDto.LookFrom[2] + ")";
            nrFov.Value = _sceneDto.Fov;
            cBoxAvailableModels.Items.Clear();
            cBoxPositionedModels.Items.Clear();
            //all models
            //positioned Models
            pBoxRender.Image = _sceneDto.Preview;
            lblCamera.Text = "";
            lblName.Text = "";
            lblAddModel.Text = "";
            lblRemoveModel.Text = "";
            LastModifcationDateRefresh();
            if (_sceneDto.LastRenderizationDate != null)
            {
                LastRenderDateRefresh();
            }
            else
            {
                lblLastRenderDate.Text = "this scene has not been rendered yet";
            }
            CheckRenderOutDated();
        }

        private void LastRenderDateRefresh()
        {
            lblLastRenderDate.Text = "" + ((DateTime)_sceneDto.LastRenderizationDate).Month + "/" + ((DateTime)_sceneDto.LastRenderizationDate).Day + "/" + ((DateTime)_sceneDto.LastRenderizationDate).Year + " " + ((DateTime)_sceneDto.LastRenderizationDate).Hour + ":" + ((DateTime)_sceneDto.LastRenderizationDate).Minute;
        }

        private void LastModifcationDateRefresh()
        {
            lblLastModificationDate.Text = "" + _sceneDto.LastModificationDate.Month + "/" + _sceneDto.LastModificationDate.Day + "/" + _sceneDto.LastModificationDate.Year + " " + _sceneDto.LastModificationDate.Hour + ":" + _sceneDto.LastModificationDate.Minute;
        }

        private void CheckRenderOutDated()
        {
            if (_sceneDto.LastRenderizationDate == null || _sceneDto.LastRenderizationDate < (_sceneDto.LastModificationDate))
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
            Regex vectorFormat = new Regex(@"^\(\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*\)$");
            return vectorFormat.IsMatch(input);
        }

        public bool IsValidFormatAperture(string input)
        {
            Regex vectorFormat = new Regex(@"^(\d+(\.\d+)?),(\d+(\.\d+)?)$");
            return vectorFormat.IsMatch(input);
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void BtnChangeCamera_Click(object sender, EventArgs e)
        {
            if (IsValidFormat(txtLookFrom.Text) && IsValidFormat(txtLookAt.Text))
            {
                
                    try
                    {
                        if (cmbBlur.Checked)
                        {
                            //sceneController.EditCamera(_sceneDto, txtLookAt.Text, txtLookFrom.Text, (int)nrFov.Value, txtAperture.Text);
                        }
                        string apertureNegative = "-1";
                        //sceneController.EditCamera(_sceneDto, txtLookAt.Text, txtLookFrom.Text, (int)nrFov.Value, apertureNegative);
                        LoadScene();
                        lblCamera.ForeColor = Color.Green;
                        lblCamera.Text = "Camera settings change correctly";
                    }
                    catch (Exception ex)
                    {
                        lblCamera.ForeColor = Color.Red;
                        lblCamera.Text = ex.Message;
                    }
                
              

            }
            else
            {
                lblCamera.ForeColor = Color.Red;
                lblCamera.Text = "Format not valid";
            }
        }

        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            try
            {
                sceneController.ChangeSceneName(_sceneDto, txtSceneName.Text);
                LoadScene();
                lblName.ForeColor = Color.Green;
                lblName.Text = "Name change correctly";
            }
            catch (Exception ex)
            {
                lblName.ForeColor = Color.Red;
                lblName.Text = ex.Message;
            }
        }

        private void BtnAddModel_Click(object sender, EventArgs e)
        {
          
        }

        private void BtnRemoveModel_Click(object sender, EventArgs e)
        {
        }

        private void BtnRender_Click(object sender, EventArgs e)
        {
            if (cmbBlur.Checked)
            {
                //sceneController.RenderSceneBlur(_sceneDto);
            }
            else
            {

                //sceneController.RenderScene(_sceneDto);
            }
            LoadScene();
        }

        private void CmbBlur_CheckedChanged(object sender, EventArgs e)
        {
            //_sceneDto.UpdateLastModificationDate();
            LoadScene();
            if (!cmbBlur.Checked)
            {
                txtAperture.Enabled = false;
                lblAperture.Enabled = false;
            }
            else
            {
                txtAperture.Enabled = true;
                lblAperture.Enabled = true;
            }
        }
    }
}
