using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd.Figures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserInterface.Controls
{
    public partial class FigureControl : UserControl
    {
        private Figure figure;

        public FigureControl(Figure figure)
        {
            this.figure = figure;
            InitializeComponent();
            this.txtFigureName.Text = figure.Name;
            this.lblFigureRadius.Text = ""+((Sphere)figure).Radius;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFigureName.ReadOnly = false;
        }

        private void clientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFigureName.ReadOnly = true; 
                e.Handled = true; 
            }
        }

        private void clientLeaves(object sender, EventArgs e)
        {
            txtFigureName.ReadOnly = true;

        }
    }
}
