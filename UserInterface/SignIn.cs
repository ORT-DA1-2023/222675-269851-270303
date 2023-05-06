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
                    render.clientController.SignIn(clientName, clientPassword);
                }
                catch (Exception ex)
                {
                    lblExceptionError.Text = ex.Message;
                    return;
                }
                render.clientName = clientName;
                render.EnterMenu();
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
            if ((clientPassword != ""))
            {
                try
                {
                    render.clientController.CheckPassword(clientPassword);
                }catch (Exception ex)
                {
                    lblWrongPasswordMessage.Text = ex.Message;
                    return;
                }
                
            }
            lblWrongPasswordMessage.Text = "";
        }

        private void UsernameKeyUpCheck(object sender, KeyEventArgs e)
        {
            String clientName = txtClientName.Text;
            if ((clientName != ""))
            {
                try
                {
                    render.clientController.CheckName(clientName);
                }catch(Exception ex)
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
