using System.Windows.Forms;

namespace Render3D.UserInterface
{
    public partial class Render3DIU : Form
    {
        public Render3DIU()
        {       
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
