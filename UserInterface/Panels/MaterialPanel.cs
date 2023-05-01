using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{
    public partial class MaterialPanel : Form
    {
        private String _client;
        public MaterialPanel(String clientName)
        {
            InitializeComponent();
            _client= clientName;
        }

        private void btnCreateFigure_Click(object sender, EventArgs e)
        {

        }
    }
}
