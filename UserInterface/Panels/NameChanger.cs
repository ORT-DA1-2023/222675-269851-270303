using System;
using System.Windows.Forms;

namespace UserInterface.Panels
{
    public partial class NameChanger : Form
    {
        public string newName;
        public NameChanger(string name)
        {
            InitializeComponent();
            txtName.Text = name;

        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            newName = txtName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
