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
            decimal figureRadius;
            if (tryToParse(figureRadiusString)!=-1)
            {
                figureRadius = tryToParse(figureRadiusString);
                render.dataTransferObject.TryToAddAfigure(render.clientName, figureName, figureRadius);
                creation.showFigureList();
                lblRadiusNotValid.Text = "";
                lblNameNotValid.Text = "";
            }
            else
            {
                alertFigureRadiusIsNotANumber();
            }
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
        }

        private void alertFigureRadiusIsNotANumber()
        {
            lblRadiusNotValid.Text = "the radius must be a number";
        }

        private decimal tryToParse(string figureRadiusString)
        {
            try
            {
               decimal radius= Decimal.Parse(figureRadiusString);
                return radius; 
            }catch 
            { 
                return -1; 
            }
        }

        private void variablesInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
            render = ((Render3DIU)creation.Parent.Parent);
        }
    }
}
