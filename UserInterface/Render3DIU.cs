using Render3D.BackEnd;
using Render3D.UserInterface.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class Render3DIU : Form
    {
        public String clientName= "";
        public DataTransferObject dataTransferObject= new DataTransferObject();
        public Render3DIU()
        {
            InitializeComponent();
            userWantsToLogIn();
        }
        public void userWantsToLogIn()
        {
            showObjectCreationPanel(new Login());
        }

        public void enterMenu()
        {
            showObjectCreationPanel(new CreationMenu());
        }

        public void userWantsToSignIn()
        {
            showObjectCreationPanel(new SignIn());
        }

        private void showObjectCreationPanel(object formSon)
        {
            if (this.pnLayout.Controls.Count > 0)
            {
                this.pnLayout.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnLayout.Controls.Add(form);
            this.pnLayout.Tag = form;
            form.Show();
        }
    }
}
