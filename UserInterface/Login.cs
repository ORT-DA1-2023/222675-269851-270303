using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserInterface;

namespace Render3D.UserInterface
{
    public partial class Login : Form
    {
        private Render3DIU render;
        private readonly ClientController clientController;
        public Login()
        {
            clientController = ClientController.GetInstance();
            InitializeComponent();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text;
            string clientPassword = txtClientPassword.Text;

            label5.Visible = true;
            label5.Update();

            try
            {
               
             clientController.Login(clientName,clientPassword);
            }
            catch (Exception ex)
            {
                lblExceptionError.Text = ex.Message;
                label5.Visible = false;
                label5.Update();
                return;
            }
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            label5.Visible = false;
            label5.Update();
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

        private void BtnLog_Click(object sender, EventArgs e)
        {
            var window = new LogUI();
            window.Show();
        }
    }
}
