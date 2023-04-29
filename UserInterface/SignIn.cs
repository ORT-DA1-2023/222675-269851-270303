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
        public SignIn()
        {
            InitializeComponent();
            lblPasswordsDontMatch.Text = "";
            lblWrongPasswordMessage.Text = "";
            lblWrongUsernameMessage.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ((Render3DIU)this.Parent.Parent).userWantsToLogIn();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String clientName = txtClientName.Text;
            String clientPassword = txtClientPassword.Text;
            String clientPasswordRepeated = txtClientRepeatedPassword.Text;

            if (clientPassword== clientPasswordRepeated && ((Render3DIU)this.Parent.Parent).dataTransferObject.ifPosibleSignIn(clientName,clientPassword))
            {
                ((Render3DIU)this.Parent.Parent).clientName = clientName;
                ((Render3DIU)this.Parent.Parent).enterMenu();
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
            if (!clientPassword.Equals(repeatedPassword))
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
            if (!((Render3DIU)this.Parent.Parent).dataTransferObject.checkPassword(clientPassword))
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
            if (!((Render3DIU)this.Parent.Parent).dataTransferObject.checkName(clientName))
            {
                lblWrongUsernameMessage.Text = "this username is not valid";
            }
            else
            {
                lblWrongUsernameMessage.Text = "";
            }
        }
    }
}
