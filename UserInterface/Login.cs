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

namespace Render3D.UserInterface
{
    public partial class Login : Form
    {
        DataTransferObject dataTransferObject = new DataTransferObject();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            String clientName= boxClientName.Text;
            String clientPassword= boxClientPassword.Text;
            if (dataTransferObject.AlreadyExistsThisClient(clientName,clientPassword)) 
            {
                boxClientName.Text = "";
                boxClientPassword.Text = "";
                Menu userMenu = new Menu(clientName);
                this.Hide();
                userMenu.Show();
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String clientName = boxClientName.Text;
            String clientPassword = boxClientPassword.Text;
            if (dataTransferObject.ifPosibleSignIn(clientName,clientPassword)) //create user
            {
                boxClientName.Text = "";
                boxClientPassword.Text = "";
                Menu userMenu = new Menu(clientName) ;
                this.Hide();
                userMenu.Show();
            }
            else
            {
                //mirar cambios de letra sobre esto
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
