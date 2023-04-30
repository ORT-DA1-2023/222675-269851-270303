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
using UserInterface;

namespace Render3D.UserInterface
{
    public partial class Login : Form
    {
        Render3DIU render;
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            String clientName= txtClientName.Text;
            String clientPassword= txtClientPassword.Text;
            if (render.dataTransferObject.AlreadyExistsThisClient(clientName,clientPassword)) 
            {
                txtClientName.Text = "";
                txtClientPassword.Text = "";
                render.clientName = clientName;
                render.enterMenu();
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            render.userWantsToSignIn();
        }


        private void variablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
        }
    }
}
