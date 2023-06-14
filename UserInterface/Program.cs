using RepositoryFactory;
using System;
using System.Threading;
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
            RepoFactory repoFactory = new RepoFactory();
            repoFactory.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
            Application.Run(new Render3DIU());
        }
        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "An error occurred, please try again later");
        }
    }
}
