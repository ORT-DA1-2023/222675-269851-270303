﻿using Render3D.BackEnd.Figures;
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
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;

        public DataWarehouse DataWarehouse { get => _dataWarehouse; set { _dataWarehouse = value; } }
        public ClientController ClientController { get => _clientController; set => _clientController = value; }
        public void AddFigure(string clientName, string figureName, double figureRadius)
        {
            if (GetFigureByNameAndClient(clientName, figureName).Name == null)
            {
                    CreateAndAddFigure(ClientController.GetClientByName(clientName), figureName, figureRadius);
            }
            else
            {
                throw new BackEndException("figure already exists");
            }

        }
        private void CreateAndAddFigure(Client client, string figureName, double figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            _dataWarehouse.Figures.Add(figure);
        }
        public Figure GetFigureByNameAndClient(string clientName, string figureName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Figure figure in _dataWarehouse.Figures)
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

            Figure figure = GetFigureByNameAndClient(clientName, figureName);
            if (figure.Name != null)
            {
                _dataWarehouse.Figures.Remove(figure);
            }
        }
        public void ChangeFigureName(string clientName, string oldName, string newName)
        {
            Figure figure = GetFigureByNameAndClient(clientName, oldName);
            if (figure == null)
            {
                return;
            }
            if (GetFigureByNameAndClient(clientName, newName).Name == "")
            {
                return;
            }
            figure.Name = newName;
        }

    }
}
