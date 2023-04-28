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
        public FigurePanel(String clientName)
        {
            InitializeComponent();
            _client= clientName;
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

            }

        }

        private void txtFigureRadius_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
