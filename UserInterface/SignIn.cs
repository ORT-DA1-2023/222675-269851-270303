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
using Render3D.UserInterface;
using Menu = Render3D.UserInterface.Menu;

namespace UserInterface
{
    public partial class SignIn : Form
    {
        private DataTransferObject _dataTransferObject;
        public SignIn(DataTransferObject dto)
        {
            InitializeComponent();
            _dataTransferObject = dto;
            lblPasswordsDontMatch.Text = "";
            lblWrongPasswordMessage.Text = "";
            lblWrongUsernameMessage.Text = "";
            this.FormClosed += new FormClosedEventHandler(Form_FormClosed);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (login != null)
            {
                login.Show();
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String clientName = txtClientName.Text;
            String clientPassword = txtClientPassword.Text;
            String clientPasswordRepeated = txtClientRepeatedPassword.Text;

            if (clientPassword== clientPasswordRepeated && _dataTransferObject.ifPosibleSignIn(clientName,clientPassword))
            {
                txtClientName.Text = "";
                txtClientPassword.Text = "";
                txtClientRepeatedPassword.Text = "";
                Menu userMenu = new Menu(clientName,_dataTransferObject) ;
                this.Hide();
                userMenu.Show();
            }
            else
            {
                //mirar cambios de letra sobre esto
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameKeyPressCheck(object sender, KeyPressEventArgs e)
        {
            String clientName = txtClientName.Text;
            if(!_dataTransferObject.checkName(clientName))
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
