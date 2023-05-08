using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd;
using Render3D.UserInterface;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class ModelControl : UserControl
    {
        private string _oldName;
        public ModelControl(Model model)
        {
            InitializeComponent();
            lblModelName.Text = model.Name;
            _oldName = model.Name;
            lblModelFigure.Text= model.Figure.Name;
            lblModelMaterial.Text= model.Material.Name;
            if (model.Preview != null)
            {
                pBoxPreview.Image = model.Preview;
            }
        }

        private void BtnEditModelName_Click(object sender, EventArgs e)
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


        private void ChecksForCorrectEdit(string newName)
        {
            if (!_oldName.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ModelNameHasBeenChanged(_oldName, newName))
                {
                    lblModelName.Text = newName;
                    _oldName=newName;
                }
            }
        }

        private void BtnDeleteModel_Click(object sender, EventArgs e)
        {
            ((CreationMenu)this.Parent.Parent.Parent).DeleteModel(lblModelName.Text);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Model");
        }
    }
}
