using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFACADESTRUC;
using CFACADEFUN;

namespace PRESENTACIONES
{
    /*
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CEstructura ep = new CEstructura();

            ep.Ip = "192.168.1.232";
            ep.BaseDeDatos = "almacenLESP";
            ep.Usuario = "almacen";
            ep.IpMaquina = CFuncionesGral.consultarsIp();
            ep.Opcion = 0;
            ep.Puerto = 5432;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPresentacion(ep));
        }
    }
    //*/
}
