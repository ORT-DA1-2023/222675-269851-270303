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
using Render3D.UserInterface.Panels;

namespace Render3D.UserInterface
{
    public partial class Menu : Form
    {
        private String _client;
        DataTransferObject _dataTransferObject;
        public Menu(String ClientName, DataTransferObject dto)
        {
            InitializeComponent();
            _client = ClientName;
            _dataTransferObject = dto;
            lblShowClientName.Text = "Welcome back \n" + _client + "!!";
            showObjectCreationPanel(new FigurePanel(_client,_dataTransferObject));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new MaterialPanel(_client));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (login != null)
            {
                login.Show();
            }
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Form_FormClosed);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new FigurePanel(_client, _dataTransferObject));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnModel_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new ModelsPanel(_client,_dataTransferObject));
        }

        private void showObjectCreationPanel(object formSon)
        {
            if(this.pnlObjectCreation.Controls.Count >0)
            {
                this.pnlObjectCreation.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlObjectCreation.Controls.Add(form);
            this.pnlObjectCreation.Tag = form;
            form.Show();
        }

       
    }
}
