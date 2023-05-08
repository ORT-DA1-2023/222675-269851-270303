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
using UserInterface.Panels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Render3D.UserInterface.Controls
{
    
    public partial class FigureControl : UserControl
    {
        private string _oldName;
        public FigureControl(Figure figure)
        {
            InitializeComponent();
            this.lblFigureName.Text = figure.Name;
            _oldName=figure.Name;
            this.lblFigureRadius.Text = ""+((Sphere)figure).Radius;
        }

        private void ChecksForCorrectEdit(string newName)
        {

            if (!_oldName.Equals(newName))
            {

                if (((CreationMenu)this.Parent.Parent.Parent).FigureNameHasBeenChanged(_oldName, newName))
                {
                    lblFigureName.Text=newName;
                    _oldName = newName;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
        ((CreationMenu)this.Parent.Parent.Parent).DeleteFigure(lblFigureName.Text);
        ((CreationMenu)this.Parent.Parent.Parent).Refresh("Figure");
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_oldName))
            {
                var result = nameChanger.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string name = nameChanger.newName;
                    ChecksForCorrectEdit(name);
                }
            }

        }
    }
}
