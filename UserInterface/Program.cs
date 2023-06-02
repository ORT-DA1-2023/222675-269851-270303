using RenderLogic.RepoInterface;
using System;
using System.Windows.Forms;

namespace Render3D.UserInterface
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Render3DIU());
        }
    }
}
