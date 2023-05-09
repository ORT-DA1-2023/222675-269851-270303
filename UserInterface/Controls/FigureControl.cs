using Render3D.BackEnd.Figures;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Render3D.UserInterface.Controls
{

    public partial class FigureControl : UserControl
    {
        private string _oldName;
        public FigureControl(Figure figure)
        {
            InitializeComponent();
            this.txtFigureName.Text = figure.Name;
            this.lblFigureRadius.Text = "" + ((Sphere)figure).Radius;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _oldName = txtFigureName.Text;
            txtFigureName.ReadOnly = false;
            txtFigureName.BackColor = Color.Green;
        }

        private void ClientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                ChecksForCorrectEdit();
            }


        }

        private void ClientLeaves(object sender, EventArgs e)
        {
            ChecksForCorrectEdit();

        }
        private void ChecksForCorrectEdit()
        {
            txtFigureName.ReadOnly = true;
            if (!_oldName.Equals(txtFigureName.Text))
            {

                if (((CreationMenu)this.Parent.Parent.Parent).FigureNameHasBeenChanged(_oldName, txtFigureName.Text))
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ((CreationMenu)this.Parent.Parent.Parent).DeleteFigure(txtFigureName.Text);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Figure");
        }
    }
}
