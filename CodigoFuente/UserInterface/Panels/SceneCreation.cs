﻿using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserInterface.Panels
{
    public partial class SceneCreation : Form
    {
        private SceneDto _sceneDto;
        public SceneController sceneController;
        public SceneCreation(SceneDto selectedScene)
        {
            InitializeComponent();
            sceneController = SceneController.GetInstance();
            _sceneDto = selectedScene;
            LoadScene();
        }


        private void LoadScene()
        {
            _sceneDto = sceneController.GetScene(_sceneDto.Name);
            txtSceneName.Text = _sceneDto.Name;
            XLookAt.Text = $"{_sceneDto.LookAt[0]}";
            YLookAt.Text = $"{_sceneDto.LookAt[1]}";
            ZLookAt.Text = $"{_sceneDto.LookAt[2]}";
            XLookFrom.Text = $"{_sceneDto.LookFrom[0]}";
            YLookFrom.Text = $"{_sceneDto.LookFrom[1]}";
            ZLookFrom.Text = $"{_sceneDto.LookFrom[2]}";
            nrFov.Value = _sceneDto.Fov;
            cBoxAvailableModels.DataSource = sceneController.GetAvailableModels();
            cBoxAvailableModels.DisplayMember = "Name";
            cBoxPositionedModels.DataSource = sceneController.GetPositionedModels(_sceneDto);
            cBoxPositionedModels.DisplayMember = "Name";
            pBoxRender.Image = _sceneDto.Preview;
            lblCamera.Text = "";
            lblName.Text = "";
            lblAddModel.Visible = false;
            lblRemoveModel.Visible = false;
            if (_sceneDto.Aperture > 0)
            {
                cmbBlur.Checked = true;
                txtAperture.Text = _sceneDto.Aperture.ToString();
            }
            LastModifcationDateRefresh();
            if (_sceneDto.LastRenderizationDate != DateTime.MinValue)
            {
                LastRenderDateRefresh();
            }
            else
            {
                lblLastRenderDate.Text = "Never";
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

        public bool IsValidFormatAperture(string input)
        {
            Regex vectorFormat = new Regex(@"^(\d+(\.\d+)?|\d+,\d+)$");
            return vectorFormat.IsMatch(input);
        }

        public bool IsValidNumberAperture(string input)
        {
            double aperture = double.Parse(input);
            return aperture > 0.0 && aperture <= 3.0;
        }

        public bool IsValidFormatVector(string input)
        {
            Regex vectorFormat = new Regex(@"^\(\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*;\s*-?\d+(\,\d+)?\s*\)$");
            return vectorFormat.IsMatch(input);
        }


        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void BtnChangeCamera_Click(object sender, EventArgs e)
        {
            string lookFromText = $"({XLookFrom.Text};{YLookFrom.Text};{ZLookFrom.Text})";
            string lookAtText = $"({XLookAt.Text};{YLookAt.Text};{ZLookAt.Text})";
            if (IsValidFormatVector(lookFromText) && IsValidFormatVector(lookAtText))
            {

                try
                {
                    if (cmbBlur.Checked)
                    {
                        if (IsValidFormatAperture(txtAperture.Text) && IsValidNumberAperture(txtAperture.Text))
                        {
                            sceneController.EditCamera(_sceneDto, lookAtText, lookFromText, (int)nrFov.Value, txtAperture.Text);

                        }
                        else
                        {
                            lblCamera.Text = "Aperture format not valid";
                            lblCamera.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        string apertureZero = "0";
                        sceneController.EditCamera(_sceneDto, lookAtText, lookFromText, (int)nrFov.Value, apertureZero);

                    }
                    LoadScene();
                    lblCamera.ForeColor = Color.Green;
                    lblCamera.Text = "Camera settings change correctly";
                    if (boxSaveDefault.Checked)
                    {
                        sceneController.ClientController.AddCamera(lookFromText, lookAtText, (int)nrFov.Value, txtAperture.Text);
                    }
                    lblRenderOutDated.Text = "WARNING this render is outdated";

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
                _sceneDto.Name = txtSceneName.Text;
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

            ModelDto model = ((ModelDto)cBoxAvailableModels.SelectedItem);
            string position = "(" + XPositionModel.Text + ";" + YPositionModel.Text + ";" + ZPositionModel.Text + ")";
            sceneController.AddModel(_sceneDto, model, position);
            LoadScene();
            lblRenderOutDated.Text = "WARNING this render is outdated";
            lblAddModel.Visible = true;
            lblRemoveModel.Update();


        }

        private void BtnRemoveModel_Click(object sender, EventArgs e)
        {
            ModelDto model = ((ModelDto)cBoxPositionedModels.SelectedItem);
            sceneController.RemoveModel(_sceneDto, model);
            LoadScene();
            lblRenderOutDated.Text = "WARNING this render is outdated";
            lblRemoveModel.Visible = true;
            lblRemoveModel.Update();
        }

        private void BtnRender_Click(object sender, EventArgs e)
        {
            lblRenderingNotification.Visible = true;
            lblRenderingNotification.Update();
            if (cmbBlur.Checked)
            {
                sceneController.RenderScene(_sceneDto, true);
            }
            else
            {

                sceneController.RenderScene(_sceneDto, false);
            }

            LoadScene();
            lblRenderingNotification.Visible = false;
            lblRenderingNotification.Update();
        }

        private void CmbBlur_CheckedChanged(object sender, EventArgs e)
        {

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

        private void Button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label5.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            label28.Visible = false;
            label28.Update();
            label27.Text = "";

            if (textBox1.Text == "") { label27.Text = "Select a name for the file"; return; }
            if (label5.Text == "None") { label27.Text = "Select a directory"; return; }
            if (comboBox1.SelectedIndex == -1) { label27.Text = "Select a format"; return; }

            bool dirExists = sceneController.IsValidDirectory(label5.Text);

            if (!dirExists) { label27.Text = "Could not access the directory"; return; }

            if (sceneController.FileExists(label5.Text + "\\" + textBox1.Text + "." + comboBox1.Text))
            {
                label27.Text = "There is a file with that name"; return;
            }


            lblExporting.Visible = true;
            lblExporting.Update();
            BtnRender_Click(sender, e);
            _sceneDto.Preview = new Bitmap(pBoxRender.Image);
            try
            {
                sceneController.ExportRender(_sceneDto, label5.Text + "\\" + textBox1.Text + "." + comboBox1.Text, comboBox1.Text);
            }
            catch (Exception)
            {
                label27.Text = "Could not save the file";
                return;
            }

            lblExporting.Visible = false;
            lblExporting.Update();

            label28.Visible = true;
            label28.Update();
        }

    }
}
