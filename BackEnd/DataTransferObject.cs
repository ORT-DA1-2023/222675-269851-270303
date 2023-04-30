﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Figures;

namespace Render3D.BackEnd
{
    public class DataTransferObject
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();

        public DataWarehouse DataWareHouse { get => _dataWarehouse; }

        public bool AlreadyExistsThisClient(string clientName, string clientPassword)
        {
            foreach (Client client in _dataWarehouse.Clients)
            {
                if (client.Name == clientName && client.Password == clientPassword)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ifPosibleSignIn(string clientName, string clientPassword)
        {
            try
            {
                if (AlreadyExistsThisClient(clientName, clientPassword))
                {
                    return false;
                }
                transferClientForCreation(clientName, clientPassword);
                return true;
            }catch (Exception ex) {
                return false;
            } 
        }
        public bool TryToAddAfigure(String clientName, string figureName, int figureRadius)
        {
            Client client=getClientGivenAName(clientName);
            try
            {
                transferFigureForCreation(client, figureName, figureRadius);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
           
        }

        private void transferClientForCreation(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }

        private void transferFigureForCreation(Client client, string figureName, int figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            _dataWarehouse.Figures.Add(figure);
        }
        private Client getClientGivenAName(String clientName)
        {
            foreach (Client client in _dataWarehouse.Clients)
            {
                if (client.Name == clientName)
                {
                    return client;
                }
            }
            return null;
        }

        public bool checkName(string clientName)
        {
            try
            {
                Client client = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkPassword(string clientPassword)
        {
            try
            {
                Client client = new Client() { Name = "validName", Password = clientPassword };
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public void ifPosibleChangeFigureName(string oldName, string newName)
        {
            foreach (Figure figure in _dataWarehouse.Figures)
            {
                if (figure.Name == oldName)
                {
                   figure.Name = newName;
                }
            }
        }

        public bool alreadyExistsThisFigure(string figureName)
        {
            foreach (Figure figure in _dataWarehouse.Figures)
            {
                if (figure.Name == figureName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}