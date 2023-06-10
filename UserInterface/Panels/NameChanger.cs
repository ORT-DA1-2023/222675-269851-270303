using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
