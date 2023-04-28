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
        private String _client;
        private DataTransferObject _dataTransferObject;
        public FigurePanel(String clientName,DataTransferObject dto)
        {
            InitializeComponent();
            _client= clientName;
            _dataTransferObject= dto;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateFigure_Click(object sender, EventArgs e)
        {
            String figureName= txtFigureName.Text;
            String figureRadiusString = txtFigureRadius.Text;
            int figureRadius;
            if(figureRadiusString!="")
            {
                figureRadius = Int32.Parse(figureRadiusString);
                _dataTransferObject.TryToAddAfigure(_client, figureName, figureRadius);
            }
            txtFigureName.Text = "";
            txtFigureRadius.Text = "";
        }
    }
}
