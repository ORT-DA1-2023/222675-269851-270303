using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
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
    
    public partial class ModelPanel : Form
    {
        CreationMenu creation;
        Render3DIU render;
        public ModelPanel()
        {
            InitializeComponent();
        }

        private void variableInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
            render = ((Render3DIU)creation.Parent.Parent);
            lstFigure.Items.Clear();
            lstMaterial.Items.Clear();
            List<Figure> figureList= render.dataTransferObject.DataWarehouse.Figures;
            List <Material> materialList=render.dataTransferObject.DataWarehouse.Materials;
            foreach (Figure figure in figureList)
            {
                lstFigure.Items.Add(figure);
            }
            foreach (Material material in materialList) 
            { 
                lstMaterial.Items.Add(material);
            }

        }

        private void btnCreateFigure_Click(object sender, EventArgs e)
        {

        }
    }
}
