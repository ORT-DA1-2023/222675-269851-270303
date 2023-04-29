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
        public Login()
        {
            InitializeComponent();
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void lblClientPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblClientPassword_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String clientName= txtClientName.Text;
            String clientPassword= txtClientPassword.Text;
            if (((Render3DIU)this.Parent.Parent).dataTransferObject.AlreadyExistsThisClient(clientName,clientPassword)) 
            {
                txtClientName.Text = "";
                txtClientPassword.Text = "";
                ((Render3DIU)this.Parent.Parent).clientName = clientName;
                ((Render3DIU)this.Parent.Parent).enterMenu();
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientPassword.Text = "";
            ((Render3DIU)this.Parent.Parent).userWantsToSignIn();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
