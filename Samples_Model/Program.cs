using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Sample
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            GenericModel.GenericModel.SET("pcei7cBalji9G5TiGy92vQ==");

            AppDomain.CurrentDomain.AssemblyResolve += _HandleAssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static Assembly _HandleAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var firstOrDefault = args.Name.Split(',').FirstOrDefault();
            return Assembly.Load(firstOrDefault);
        }
    }
}