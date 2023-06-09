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
            Client client;
            try
            {
                client = render.clientController.GetClientByName(clientName);
            }
            catch(Exception ex)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
