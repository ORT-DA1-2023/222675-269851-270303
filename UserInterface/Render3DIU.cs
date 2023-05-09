using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.Utilities;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class Render3DIU : Form
    {
        public string clientName = "";
        public DataWarehouse dataWarehouse = new DataWarehouse();
        public ClientController clientController = new ClientController();
        public FigureController figureController = new FigureController();
        public MaterialController materialController = new MaterialController();
        public ModelController modelController = new ModelController();
        public Render3DIU()
        {
            clientController.DataWarehouse = dataWarehouse;
            figureController.DataWarehouse = dataWarehouse;
            figureController.ClientController = clientController;
            materialController.DataWarehouse = dataWarehouse;
            materialController.ClientController = clientController;
            modelController.DataWarehouse = dataWarehouse;
            modelController.ClientController = clientController;
            InitializeComponent();
            UserWantsToLogIn();
        }
        public void UserWantsToLogIn()
        {
            ShowObjectCreationPanel(new Login());
        }

        public void EnterMenu()
        {
            ShowObjectCreationPanel(new CreationMenu());
        }

        public void UserWantsToSignIn()
        {
            ShowObjectCreationPanel(new SignIn());
        }

        private void ShowObjectCreationPanel(object formSon)
        {
            if (this.pnLayout.Controls.Count > 0)
            {
                this.pnLayout.Controls.RemoveAt(0);
            }
            Form form = formSon as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnLayout.Controls.Add(form);
            this.pnLayout.Tag = form;
            form.Show();
        }
    }
}
