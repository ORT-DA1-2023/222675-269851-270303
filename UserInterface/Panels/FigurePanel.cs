using Render3D.BackEnd;
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
    
    public partial class FigurePanel : Form
    {
        private CreationMenu creation;
        private Render3DIU render;
        public FigurePanel()
        {
            InitializeComponent();
        }


        private void btnCreateFigure_Click(object sender, EventArgs e)
        {
            String figureName= txtFigureName.Text;
            String figureRadiusString = txtFigureRadius.Text;
            int figureRadius;
            if(figureRadiusString!="")
            {
                figureRadius = Int32.Parse(figureRadiusString);
                render.dataTransferObject.TryToAddAfigure(render.clientName, figureName, figureRadius);
                creation.showFigureList();
            }
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
        }

        private void variablesInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
            render = ((Render3DIU)creation.Parent.Parent);
        }
    }
}
