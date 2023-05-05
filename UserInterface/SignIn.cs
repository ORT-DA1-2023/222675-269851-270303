using System;
using System.Windows.Forms;

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
            lblExceptionError.Text = "";

        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            render.userWantsToLogIn();

        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            String clientName = txtClientName.Text;
            String clientPassword = txtClientPassword.Text;
            String clientPasswordRepeated = txtClientRepeatedPassword.Text;

            if (clientPassword == clientPasswordRepeated)
            {
                try
                {
                    render.clientController.SignIn(clientName, clientPassword);
                }
                catch (Exception ex)
                {
                    lblExceptionError.Text = ex.Message;
                    return;
                }
                render.clientName = clientName;
                render.enterMenu();
            }
        }


        private void RepeatedPasswordKeyUpCheck(object sender, KeyEventArgs e)
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
            if (!render.clientController.CheckPassword(clientPassword) && (clientPassword != ""))
            {
                lblWrongPasswordMessage.Text = "this password is not valid";
            }
            else
            {
                lblWrongPasswordMessage.Text = "";
            }
        }

        private void UsernameKeyUpCheck(object sender, KeyEventArgs e)
        {
            String clientName = txtClientName.Text;
            if (!render.clientController.CheckName(clientName) && (clientName != ""))
            {
                lblWrongUsernameMessage.Text = "this username is not valid";
            }
            else
            {
                lblWrongUsernameMessage.Text = "";
            }
        }

        private void VariableInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblExceptionError.Text = "";
        }
    }
}
