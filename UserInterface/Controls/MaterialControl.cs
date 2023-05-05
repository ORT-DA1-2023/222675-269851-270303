using Render3D.BackEnd.Materials;
using Render3D.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Controls
{
    public partial class MaterialControl : UserControl
    {
        private Material _material;
        private string _oldName;
        public MaterialControl(Material material)
        {
            _material = material;
            InitializeComponent();
            txtMaterialName.Text = material.Name;
            lblRedColor.Text ="Red: "+ _material.Color.X;
            lblGreenColor.Text = "Green: " + _material.Color.Y;
            lblBlueColor.Text = "Blue: " + _material.Color.Z;
            pBoxMaterial.BackColor = Color.FromArgb((int)_material.Color.X,(int)_material.Color.Y,(int)_material.Color.Z);
        }

        private void btnEditMaterialName_Click(object sender, EventArgs e)
        {
            _oldName = txtMaterialName.Text;
            txtMaterialName.ReadOnly = false;
            txtMaterialName.BackColor = Color.Green;
        }


        
        private void ClientLeaves(object sender, EventArgs e)
        {
            checksForCorrectEdit();
        }

        private void clientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                checksForCorrectEdit();
            }
        }
        private void checksForCorrectEdit()
        {
            txtMaterialName.ReadOnly = true;
            if (!_oldName.Equals(txtMaterialName.Text))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).MaterialNameHasBeenChanged(_oldName, txtMaterialName.Text))
                {
                    txtMaterialName.BackColor = Color.White;
                }
                else
                {
                    txtMaterialName.BackColor = Color.Red;
                }
            }
            else
            {
                txtMaterialName.BackColor = Color.White;
            }
        }

        private void BtnDeleteMaterial_Click(object sender, EventArgs e)
        {
         ((CreationMenu)this.Parent.Parent.Parent).DeleteMaterial(txtMaterialName.Text);
         ((CreationMenu)this.Parent.Parent.Parent).Refresh("Material");

        }

    }
}
