using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Login;
using Configuration;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigurationVariables.Iniciar();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
