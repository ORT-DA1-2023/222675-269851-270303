using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class FigureController
    {
        public DataWarehouse DataWarehouse { get; set; }
        public FigureService FigureService { get; set; }
        public ClientController ClientController { get; set; }
        public void AddFigure(FigureDto figureDto)
        {
            try
            {
                FigureService.GetFigureByNameAndClient(ClientController.Client, figureDto.Name);

            }
            catch (Exception)
            {
                CreateSphere(figureDto);
                return;
            }
            throw new BackEndException("figure already exists");

        }
        private void CreateSphere(FigureDto figureDto)
        {
            Figure figure = new Sphere() { Client = ClientController.Client, Name = figureDto.Name, Radius = figureDto.Radius };
            DataWarehouse.Figures.Add(figure);
        }
        public Figure GetFigureByNameAndClient(string figureName)
        {
            foreach (Figure figure in DataWarehouse.Figures)
            {
                if (figure.Name == figureName && figure.Client.Equals(""))
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
                Figure figure = GetFigureByNameAndClient(clientName, figureName);
                DataWarehouse.Figures.Remove(figure);
            }
            catch (Exception)
            {
            }

        }
        public void ChangeFigureName(string clientName, string oldName, string newName)
        {
            Figure figure;
            try
            {
                figure = GetFigureByNameAndClient(clientName, oldName);
                Figure correctNameCheck = new Sphere() { Name = newName };
            }
            catch (Exception)
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

        public List<FigureDto> GetFigures()
        {
            throw new NotImplementedException();
        }
    }
}
