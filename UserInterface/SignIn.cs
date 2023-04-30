using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd;

namespace Render3D.UserInterface
{
    public partial class SignIn : Form
    {
        private Render3DIU render;
        public SignIn()
        {
            InitializeComponent();
            lblPasswordsDontMatch.Text = "";
            lblWrongPasswordMessage.Text = "";
            lblWrongUsernameMessage.Text = "";
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
           render.userWantsToLogIn();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String clientName = txtClientName.Text;
            String clientPassword = txtClientPassword.Text;
            String clientPasswordRepeated = txtClientRepeatedPassword.Text;

            if (clientPassword== clientPasswordRepeated && render.dataTransferObject.ifPosibleSignIn(clientName,clientPassword))
            {
                render.clientName = clientName;
                render.enterMenu();
            }
            else
            {
                //mirar cambios de letra sobre esto
            }
        }


        private void repeatedPasswordKeyUpCheck(object sender, KeyEventArgs e)
        {
            String clientPassword = txtClientPassword.Text;
            String repeatedPassword = txtClientRepeatedPassword.Text;
            if (!clientPassword.Equals(repeatedPassword) && (repeatedPassword != ""))
            {
                lblPasswordsDontMatch.Text = "the password don't match";
            }
            else
            {
                lblPasswordsDontMatch.Text = "";
            }
        }

        private void ClientPasswordKeyUpCheck(object sender, KeyEventArgs e)
        {
            String clientPassword = txtClientPassword.Text;
            if (!render.dataTransferObject.checkPassword(clientPassword) && (clientPassword!=""))
            {
                lblWrongPasswordMessage.Text = "this password is not valid";
            }
            else
            {
                lblWrongPasswordMessage.Text = "";
            }
        }

        private void usernameKeyUpCheck(object sender, KeyEventArgs e)
        {
            String clientName = txtClientName.Text;
            if (!render.dataTransferObject.checkName(clientName) && (clientName != ""))
            {
                lblWrongUsernameMessage.Text = "this username is not valid";
            }
            else
            {
                lblWrongUsernameMessage.Text = "";
            }
        }

        private void variableInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
        }
    }
}
