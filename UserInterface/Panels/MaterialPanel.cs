using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{
    public partial class MaterialPanel : Form
    {
        private int rgbLength =3;
        private CreationMenu creation;
        private Render3DIU render;
        public MaterialPanel()
        {
            InitializeComponent();
            
        }

        private void btnCreateFigure_Click(object sender, EventArgs e)
        {
            String materialName= txtMaterialName.Text;
            int[] materialColors= new int[rgbLength];
            materialColors[0] = Convert.ToInt32(Math.Round(nrRedColor.Value));
            materialColors[1] = Convert.ToInt32(Math.Round(nrGreenColor.Value));
            materialColors[2] = Convert.ToInt32(Math.Round(nrBlueColor.Value));
            render.dataTransferObject.tryToAddAMaterial(render.clientName,materialName, materialColors);
        }

        private void variablesInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
            render = ((Render3DIU)creation.Parent.Parent);
        }
    }
}
