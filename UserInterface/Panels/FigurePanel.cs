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


        private void BtnCreateFigure_Click(object sender, EventArgs e)
        {
            string figureName= txtFigureName.Text;
            string figureRadiusString = txtFigureRadius.Text;
            double figureRadius;
            if (TryToParse(figureRadiusString)!=-1)
            {
                figureRadius = Convert.ToDouble(figureRadiusString);
                try
                {
                    render.figureController.AddFigure(render.clientName, figureName, figureRadius);
                }catch(Exception ex)
                {
                    lblExceptionError.Text= ex.Message;
                }
                creation.ShowFigureList();
            }
            else
            {
                lblExceptionError.Text = "the radius must be a number";
            }
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
        }

        private decimal TryToParse(string figureRadiusString)
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

        private void VariablesInitialize(object sender, EventArgs e)
        {
            creation = (CreationMenu)this.Parent.Parent;
            render = (Render3DIU)creation.Parent.Parent;
            lblExceptionError.Text = "";
        }
    }
}
