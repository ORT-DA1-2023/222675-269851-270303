using Render3D.RenderLogic.Controllers;
using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class SignIn : Form
    {
        private Render3DIU render;
        private ClientController clientController;
        public SignIn()
        {
            InitializeComponent();
            clientController = ClientController.GetInstance();
            lblPasswordsDontMatch.Text = "";
            lblWrongPasswordMessage.Text = "";
            lblWrongUsernameMessage.Text = "";
            lblExceptionError.Text = "";

        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            render.UserWantsToLogIn();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text;
            string clientPassword = txtClientPassword.Text;
            string clientPasswordRepeated = txtClientRepeatedPassword.Text;

            if (clientPassword == clientPasswordRepeated)
            {
                try
                {
                    clientController.SignIn(clientName, clientPassword);
                }
                catch (Exception ex)
                {
                    lblExceptionError.Text = ex.Message;
                    return;
                }
                render.EnterMenu();
            }
        }


        private void RepeatedPasswordKeyUpCheck(object sender, KeyEventArgs e)
        {
            string clientPassword = txtClientPassword.Text;
            string repeatedPassword = txtClientRepeatedPassword.Text;
            if (!clientPassword.Equals(repeatedPassword) && (repeatedPassword != ""))
            {
                lblPasswordsDontMatch.Text = "The password don't match";
            }
            else
            {
                lblPasswordsDontMatch.Text = "";
            }
        }

        private void ClientPasswordKeyUpCheck(object sender, KeyEventArgs e)
        {
            string clientPassword = txtClientPassword.Text;
            if ((clientPassword != ""))
            {
                try
                {
                    clientController.CheckPassword(clientPassword);
                }
                catch (Exception ex)
                {
                    lblWrongPasswordMessage.Text = ex.Message;
                    return;
                }

            }
            RepeatedPasswordKeyUpCheck(sender, e);
            lblWrongPasswordMessage.Text = "";
        }

        private void UsernameKeyUpCheck(object sender, KeyEventArgs e)
        {
            string clientName = txtClientName.Text;
            if ((clientName != ""))
            {
                try
                {
                    clientController.CheckName(clientName);
                }
                catch (Exception ex)
                {
                    lblWrongUsernameMessage.Text = ex.Message;
                    return;
                }

            }
            lblWrongUsernameMessage.Text = "";

        }

        private void VariableInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblExceptionError.Text = "";
        }
    }
}
