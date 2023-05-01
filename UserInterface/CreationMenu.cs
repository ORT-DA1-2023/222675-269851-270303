using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.UserInterface.Panels;
using UserInterface;
using UserInterface.Controls;

namespace Render3D.UserInterface
{
    public partial class CreationMenu : Form
    {
        private String show = "figure";
        private String _client;
        private DataTransferObject _dataTransferObject;
        private Render3DIU render;
        public CreationMenu()
        {
            InitializeComponent();
        }

        public void showFigureList()
        {
            flObjectList.Controls.Clear();
            DataWarehouse listConteiners = render.dataTransferObject.DataWareHouse;
            List<Figure> figureList = listConteiners.Figures;
            foreach (Sphere figure in figureList)
            {
                FigureControl figureControl = new FigureControl(figure);
                flObjectList.Controls.Add(figureControl);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new MaterialPanel(_client));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            render.userWantsToLogIn();
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            showObjectCreationPanel(new FigurePanel());
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

        private void variablesInitialize(object sender, EventArgs e)
        {
            render = (Render3DIU)this.Parent.Parent;
            lblShowClientName.Text = "Welcome back \n" + render.clientName + "!!";
            showObjectCreationPanel(new FigurePanel());
            showFigureList();
        }
        public void refreshLists()
        {
            showObjectCreationPanel(new FigurePanel());
            showFigureList();
        }
        public bool figureNameHasBeenChanged(String oldName,string newName)
        {
            return (render.dataTransferObject.ifPosibleChangeFigureName(render.clientName,oldName, newName));
        }

        public bool figureNameHasBeenDeleted(string figureName)
        {
            return render.dataTransferObject.ifPosibleDeleteFigure(render.clientName,figureName);
        }
    }
}
