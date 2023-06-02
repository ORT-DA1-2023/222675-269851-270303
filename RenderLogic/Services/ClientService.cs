using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using RenderLogic.RepoInterface;
using System;

namespace RenderLogic.Services
{
    public class ClientService
    {
        private readonly IClientRepo _clientRepo;


        public ClientService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
          
        }

        public void AddClient(Client client)
        {
            _clientRepo.Add(client);
        }
        public Client GetClient(int id)
        {
            try
            {
                Client client = _clientRepo.Get(id);
                return client;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Client GetClientWithName(string name)
        {
            try
            {
                return _clientRepo.GetClientByName(name);
            }catch (Exception ex)
            {
                throw ex;
            }
            
        }
       
    }
}
