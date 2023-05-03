using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd.Figures;
using Render3D.UserInterface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserInterface.Controls
{
    
    public partial class FigureControl : UserControl
    {
        private String oldName;
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
            oldName= txtFigureName.Text;
            txtFigureName.ReadOnly = false;
            txtFigureName.BackColor = Color.Green;
        }

        private void clientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                checksForCorrectEdit();
            }
            
            
        }

        private void clientLeaves(object sender, EventArgs e)
        {
            checksForCorrectEdit();

        }
        private void checksForCorrectEdit()
        {
            txtFigureName.ReadOnly = true;
            if (!oldName.Equals(txtFigureName.Text))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).figureNameHasBeenChanged(oldName, txtFigureName.Text))
                {
                    txtFigureName.BackColor = Color.White;
                }
                else
                {
                    txtFigureName.BackColor = Color.Red;
                }
            }
            else
            {
                txtFigureName.BackColor = Color.White;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(((CreationMenu)this.Parent.Parent.Parent).figureNameHasBeenDeleted(txtFigureName.Text)){
                ((CreationMenu)this.Parent.Parent.Parent).refresh("Figure");
            }

        }
    }
}
