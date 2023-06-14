using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.Services;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class FigureController
    {
        public static FigureController figureController;
        public FigureService FigureService { get; set; }
        public ClientController ClientController = ClientController.GetInstance();

        public static FigureController GetInstance()
        {
            if(figureController == null)
            {
                figureController = new FigureController();
            }
            return figureController;
        }
        public void AddFigure(FigureDto figureDto)
        {
            try
            {
                FigureService.GetFigureByNameAndClient(figureDto.Name,int.Parse(ClientController.Client.Id));    
            }
            catch (Exception)
            {
                CreateSphere(figureDto);
                return;
            }
            throw new BackEndException("Figure already exists");

        }
        private void CreateSphere(FigureDto figureDto)
        {
            Figure figure = new Sphere() 
            { 
                Client = ClientController.Client,
                Name = figureDto.Name, 
                Radius = figureDto.Radius
            };
            FigureService.AddFigure(figure);
        }
        public void Delete(FigureDto figureDto)
        {
            FigureService.RemoveFigure(int.Parse(figureDto.Id));
        }

        public List<FigureDto> GetFigures()
        {
          List<Figure> figureList;
          figureList = FigureService.GetFigureOfClient(int.Parse(ClientController.Client.Id));
          List<FigureDto> figureDtos = new List<FigureDto>();
            foreach(Figure fig in figureList)
            {
                FigureDto figDto = new FigureDto()
                {
                    Id = fig.Id,
                    Name = fig.Name,
                    Radius = ((Sphere)fig).Radius
                };
                figureDtos.Add(figDto);
            }
            return figureDtos;
        }

        public void ChangeName(FigureDto figureDto, string newName)
        {
            try
            {
                Figure figure = FigureService.GetFigureByNameAndClient(newName, int.Parse(ClientController.Client.Id));
                
            }
            catch
            {
                Figure tryName = new Sphere() { Name = newName };
                FigureService.UpdateName(int.Parse(figureDto.Id), newName);
                return;
            }
            throw new Exception("That Name is already in use");
           
        }
    }
}
