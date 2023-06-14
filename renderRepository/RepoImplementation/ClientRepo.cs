using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.RenderLogic.RepoInterface;
using renderRepository.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace renderRepository.RepoImplementation
{
    public class ClientRepo : IClientRepo
    {
        public ClientRepo() { }
        public void Add(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = ClientEntity.FromDomain(client);

                dbContext.ClientEntities.Add(entity);

                dbContext.SaveChanges();
                client.Id = entity.Id.ToString();
            }
        }

        public Client Get(int id)
        {
            using (var dbContext = new RenderContext())
            {
                try
                {
                    ClientEntity clientEntity = dbContext.ClientEntities.Find(id);
                    return clientEntity.ToDomain();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public Client GetClientByName(string name)
        {
            try
            {
                using (var dbContext = new RenderContext())
                {
                    var ClientEntites = dbContext.ClientEntities
                        .Where(f => f.Name == name)
                        .ToList();
                    List<Client> clients = new List<Client>();
                    foreach (var m in ClientEntites)
                    {
                        clients.Add(m.ToDomain());
                    }
                    return clients[0];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remove(string name)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ClientEntities
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
                dbContext.ClientEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }
        public void AddCamera(int id, Camera camera)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ClientEntities.Find(id);
                entity.Aperture = camera.LensRadius;
                entity.LookFromX = camera.LookFrom.X;
                entity.LookFromY = camera.LookFrom.Y;
                entity.LookFromZ = camera.LookFrom.Z;
                entity.LookAtX = camera.LookAt.X;
                entity.LookAtY = camera.LookAt.Y;
                entity.LookAtZ = camera.LookAt.Z;
                entity.Fov = camera.Fov;
                dbContext.SaveChanges();
            }
        }
        public Camera GetCamera(int id)
        {
            ClientEntity clientEntity = null;
            using (var dbContext = new RenderContext())
            {
                clientEntity = dbContext.ClientEntities.Find(id);
            }
            try
            {
                return new Camera(
                     new Vector3D(clientEntity.LookFromX, clientEntity.LookFromY, clientEntity.LookFromZ),
                     new Vector3D(clientEntity.LookAtX, clientEntity.LookAtY, clientEntity.LookAtZ),
                     clientEntity.Fov,
                     clientEntity.Aperture);
            }
            catch
            {
                return new Camera();
            }
        }
    }
}
