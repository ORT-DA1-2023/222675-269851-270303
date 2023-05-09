using Render3D.BackEnd;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Render3D.UserInterface.Controls
{
    public partial class ModelControl : UserControl
    {
        private string oldName;
        public ModelControl(Model model)
        {
            InitializeComponent();
            txtModelName.Text = model.Name;
            lblModelFigure.Text = model.Figure.Name;
            lblModelMaterial.Text = model.Material.Name;
            if (model.Preview != null)
            {
                pBoxPreview.Image = model.Preview;
            }
        }

        private void BtnEditModelName_Click(object sender, EventArgs e)
        {
            oldName = txtModelName.Text;
            txtModelName.ReadOnly = false;
            txtModelName.BackColor = Color.Green;
        }

        private void ClientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                ChecksForCorrectEdit();
            }
        }

        private void ClientLeaves(object sender, EventArgs e)
        {
            ChecksForCorrectEdit();
        }

        private void ChecksForCorrectEdit()
        {
            txtModelName.ReadOnly = true;
            if (!oldName.Equals(txtModelName.Text))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ModelNameHasBeenChanged(oldName, txtModelName.Text))
                {
                    txtModelName.BackColor = Color.White;
                }
                else
                {
                    txtModelName.BackColor = Color.Red;
                }
            }
            else
            {
                txtModelName.BackColor = Color.White;
            }
        }

        private void BtnDeleteModel_Click(object sender, EventArgs e)
        {
            ((CreationMenu)this.Parent.Parent.Parent).DeleteModel(txtModelName.Text);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Model");
        }
    }
}
