using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd;
using Render3D.UserInterface.Panels;
using UserInterface;

namespace Render3D.UserInterface
{
    public partial class CreationMenu : Form
    {
        private String _client;
        DataTransferObject _dataTransferObject;
        public CreationMenu()
        {
            InitializeComponent();
            showObjectCreationPanel(new FigurePanel(_client,_dataTransferObject));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new MaterialPanel(_client));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ((Render3DIU)this.Parent.Parent).userWantsToLogIn();
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new FigurePanel(_client, _dataTransferObject));
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new ModelsPanel(_client,_dataTransferObject));
        }

        private void showObjectCreationPanel(object formSon)
        {
            if(this.pnlObjectCreation.Controls.Count >0)
            {
                this.pnlObjectCreation.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlObjectCreation.Controls.Add(form);
            this.pnlObjectCreation.Tag = form;
            form.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            lblShowClientName.Text = "Welcome back \n" + ((Render3DIU)this.Parent.Parent).clientName + "!!";
        }
    }
}
