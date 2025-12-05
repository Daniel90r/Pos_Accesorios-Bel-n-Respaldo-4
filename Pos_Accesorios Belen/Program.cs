using Pos_Accesorios_Belen.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Accesorios_Belen
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMenuPrincipal());
            //Application.Run(new FrmClientes());
            //Application.Run(new FrmProductos());
            //Application.Run(new FrmCategoria());
            Application.Run(new FrmLogin());
            //Application.Run(new FrmReporteVentas());
        }
    }
}
