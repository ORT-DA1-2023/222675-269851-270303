using Render3D.BackEnd.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class FigureController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
        public void AddFigure(string clientName, string figureName, double figureRadius)
        {
            try
            {
                GetFigureByNameAndClient(clientName, figureName);
                
            }
            catch (Exception)
            {
               CreateAndAddFigure(ClientController.GetClientByName(clientName), figureName, figureRadius);
                return;
            }
         throw new BackEndException("figure already exists");

        }
        private void CreateAndAddFigure(Client client, string figureName, double figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            DataWarehouse.Figures.Add(figure);
        }
        public Figure GetFigureByNameAndClient(string clientName, string figureName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Figure figure in DataWarehouse.Figures)
            {
                if (figure.Name == figureName && figure.Client.Equals(client))
                {
                    return figure;
                }
            }
            throw new BackEndException("figure doesnt exist");
        }
        public void DeleteFigureInList(string clientName, string figureName)
        {
            try
            {
                Figure figure =GetFigureByNameAndClient(clientName, figureName); 
                DataWarehouse.Figures.Remove(figure);
            }catch (Exception)
            {
            }

        }
        public void ChangeFigureName(string clientName, string oldName, string newName)
        {
            Figure figure;
            try
            {
                figure=GetFigureByNameAndClient(clientName, oldName);
                Figure correctNameCheck = new Sphere() { Name = newName};
            }
            catch(Exception)
            {
                return;
            }
          
            try
            {
                GetFigureByNameAndClient(clientName, newName);

            }
            catch (Exception)
            {
                figure.Name = newName;
            }
            
        }

    }
}
