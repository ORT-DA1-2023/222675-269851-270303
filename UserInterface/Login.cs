using Render3D.BackEnd;
using System;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class Login : Form
    {
        private Render3DIU render;
        public Login()
        {
            InitializeComponent();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text;
            string clientPassword = txtClientPassword.Text;
            Client client;
            try
            {
                client = render.clientController.GetClientByName(clientName);
            }
            catch (Exception ex)
            {
                lblExceptionError.Text = ex.Message;
                return;
            }

            if (!client.Password.Equals(clientPassword))
            {
                lblExceptionError.Text = "Password is incorrect";
                return;
            }
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            render.clientName = clientName;
            render.EnterMenu();
        }
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            render.UserWantsToSignIn();
        }


        private void VariablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblExceptionError.Text = "";
        }
    }
}
