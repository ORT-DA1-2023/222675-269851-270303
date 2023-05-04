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

namespace UserInterface.Controls
{
    public partial class ModelControl : UserControl
    {
        Model model;
        public ModelControl(Model model)
        {
            model = model;
            InitializeComponent();
            txtModelName.Text = model.Name;
            lblModelFigure.Text= model.Figure.Name;
            lblModelMaterial.Text= model.Material.Name;
        }

        private void btnEditModelName_Click(object sender, EventArgs e)
        {

        }
    }
}
