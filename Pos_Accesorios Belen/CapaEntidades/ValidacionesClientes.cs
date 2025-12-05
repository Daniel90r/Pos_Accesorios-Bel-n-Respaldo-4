using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public class ValidacionesClientes
    {
        // validar nombre y apellido (solo letras y espacios)
        public static bool EsNombreValido(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                    Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");
        }

        // validar telefono (solo 8 numeros)
        public static bool EsTelefonoValido(string telefono)
        {
            return Regex.IsMatch(telefono, @"^[0-9]{8}$");
        }

        // validar correo electronico
        public static bool EsCorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }


        }
    }
}
