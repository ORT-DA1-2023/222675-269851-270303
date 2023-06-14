using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.Services;
using System;

namespace Render3D.RenderLogic.Controllers
{
    public class ClientController
    {
        private const string _passwordSafe = "ThisPasswordIsS4fe";
        private const string _validName = "validName";
        protected static ClientController clientController;
        public Client Client { get; set; }
        public ClientService ClientService { get; set; }
        public static ClientController GetInstance()
        {
            if (clientController == null)
            {
                clientController = new ClientController();
            }
            return clientController;
        }

        public void SignIn(string clientName, string clientPassword)
        {
            try
            {
                GetClientByName(clientName);
            }
            catch
            {
                CreateAndAddClient(clientName, clientPassword);
                return;
            }
            throw new Exception("Client already exists");

        }
        private void CreateAndAddClient(string clientName, string clientPassword)
        {
            Client = new Client() { Name = clientName, Password = clientPassword };
            ClientService.AddClient(Client);

        }
        public void CheckName(string clientName)
        {
            _ = new Client() { Name = clientName, Password = _passwordSafe };
        }

        public void CheckPassword(string clientPassword)
        {
            _ = new Client() { Name = _validName, Password = clientPassword };
        }

        public Client GetClientByName(string clientName)
        {
            return ClientService.GetClientWithName(clientName);
        }

        public void Login(string clientName, string clientPassword)
        {
            Client client;
            try
            {
                client = ClientService.GetClientWithName(clientName);
            }
            catch
            {
                throw new Exception("A Client with that name does not exist");
            }
            if (client.Password == clientPassword)
            {
                Client = client;
            }
            else
            {
                throw new Exception("Password Incorrect");
            }
        }

        public void LogOut()
        {
            Client = null;
        }

        public string GetClient()
        {
            return Client.Name;
        }
        public void RemoveClient(string name)
        {
            ClientService.RemoveClient(name);
        }
        public void AddCamera(string stringLookFrom, string stringLookAt, int fov, string aperture)
        {
            Vector3D lookAt = GetVectorFromString(stringLookAt);
            Vector3D lookFrom = GetVectorFromString(stringLookFrom);
            double apertureDouble = double.Parse(aperture);
            Camera sceneNewCamera;
            if (apertureDouble > 0)
            {
                sceneNewCamera = new Camera(lookFrom, lookAt, fov, apertureDouble);
            }
            else
            {
                sceneNewCamera = new Camera(lookFrom, lookAt, fov);
            }

            ClientService.AddCamera(int.Parse(Client.Id), sceneNewCamera);
        }
        public SceneDto GetCamera()
        {
            Camera camera = ClientService.GetCamera(int.Parse(Client.Id));
            if (CameraIsDefault(camera))
            {
                return new SceneDto()
                {
                    Id = "" + 0
                };
            }
            return new SceneDto()
            {
                Id = Client.Id,
                LookAt = new double[] { camera.LookAt.X, camera.LookAt.Y, camera.LookAt.Z },
                LookFrom = new double[] { camera.LookFrom.X, camera.LookFrom.Y, camera.LookFrom.Z },
                Fov = camera.Fov,
                Aperture = camera.LensRadius * 2,
            };
        }

        private bool CameraIsDefault(Camera camera)
        {
            if (!camera.LookAt.Equals(new Vector3D(0, 0, 0))) { return false; }
            if (!camera.LookFrom.Equals(new Vector3D(0, 0, 0))) { return false; }
            if (camera.Fov != 0 && camera.LensRadius != 0) { return false; }
            return true;
        }

        private Vector3D GetVectorFromString(string stringLookAt)
        {
            string[] values = stringLookAt.Substring(1, stringLookAt.Length - 2).Split(';');
            double[] valuesInDouble = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                valuesInDouble[i] = double.Parse(values[i]);
            }
            return new Vector3D(valuesInDouble[0], valuesInDouble[1], valuesInDouble[2]);
        }
    }
}
