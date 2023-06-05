using Render3D.RenderLogic.Controllers;
using System.Windows.Forms;
using RenderLogic;
using RenderLogic.RepoInterface;

namespace Render3D.UserInterface
{
    public partial class Render3DIU : Form
    {
        public ClientController clientController = ClientController.GetInstance();
        public FigureController figureController = new FigureController();
        public MaterialController materialController = new MaterialController();
        public ModelController modelController = new ModelController();
        public SceneController sceneController = new SceneController();
        public Render3DIU()
        {
            figureController.ClientController = clientController;
            materialController.ClientController = clientController;
            modelController.ClientController = clientController;
            sceneController.ClientController = clientController;
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
