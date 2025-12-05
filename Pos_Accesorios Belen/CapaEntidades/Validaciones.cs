using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaEntidades
{
    public static class Validaciones
    {
        //valida la cadena que recibe si es tipo decimal
        public static bool EsDecimal(string s)
        {
            decimal d;
            return decimal.TryParse(s, out d);
        }

        //valida la cadena que recibe si es tipo decimal
        public static bool EsEntero(string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        //valida el correo cumpla con la estructura
        public static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var patron = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, patron);
        }
    }
}
