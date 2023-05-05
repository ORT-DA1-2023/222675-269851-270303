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


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string clientName= txtClientName.Text;
            string clientPassword= txtClientPassword.Text;
            Client client= render.clientController.GetClientByName(clientName);
            if (client.Name!=null && client.Password.Equals(clientPassword))
            {
                txtClientName.Text = "";
                txtClientPassword.Text = "";
                render.clientName = clientName;
                render.enterMenu();
            }
            else
            {
                if (client.Name == null)
                {
                    lblExceptionError.Text = "There are no clients with that name";
                }
                else {
                    lblExceptionError.Text = "Password is incorrect";
                }
            }
        }
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            render.userWantsToSignIn();
        }


        private void VariablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblExceptionError.Text = "";
        }
    }
}
