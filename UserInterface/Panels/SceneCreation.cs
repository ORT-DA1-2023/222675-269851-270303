using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
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
    public partial class SceneCreation : Form
    {
        public SceneCreation(DataWarehouse data)
        {
            InitializeComponent();
            GraphicMotor g = new GraphicMotor();
            pBoxRender.Image = data.Models[0].Preview;
        }
    }
}
