using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class ProveedorBLL
    {
        // VALIDAR CAMPOS OBLIGATORIOS
        private static string ValidarProveedor(Proveedor p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                return "El nombre del proveedor es obligatorio.";

            if (string.IsNullOrWhiteSpace(p.Telefono))
                return "El teléfono es obligatorio.";

            if (string.IsNullOrWhiteSpace(p.TipoProducto))
                return "Debe seleccionar un tipo de producto.";

            return ""; // OK
        }

        // GUARDAR
        public static string Guardar(Proveedor p)
        {
            string error = ValidarProveedor(p);
            if (error != "") return error;

            // limpiar espacios
            p.Nombre = p.Nombre.Trim();
            p.Telefono = p.Telefono.Trim();
            p.Email = p.Email?.Trim();
            p.Direccion = p.Direccion?.Trim();
            p.TipoProducto = p.TipoProducto.Trim();

            bool resultado = ProveedorDAL.InsertarProveedor(p);

            return resultado ? "OK" : "Error al guardar en la base de datos.";
        }

        // ACTUALIZAR
        public static string Actualizar(Proveedor p)
        {
            string error = ValidarProveedor(p);
            if (error != "") return error;

            if (p.ProveedorID <= 0)
                return "ID de proveedor inválido.";

            bool resultado = ProveedorDAL.ActualizarProveedor(p);

            return resultado ? "OK" : "Error al actualizar el proveedor.";
        }

        // ELIMINAR
        public static string Eliminar(int id)
        {
            if (id <= 0)
                return "ID inválido para eliminar.";

            bool resultado = ProveedorDAL.EliminarProveedor(id);

            return resultado ? "OK" : "Error al eliminar el proveedor.";
        }

        // BUSCAR
        public static DataTable Buscar(string nombre, string tipo)
        {
            nombre = nombre?.Trim() ?? "";
            tipo = tipo?.Trim() ?? "";

            return ProveedorDAL.Buscar(nombre, tipo);
        }
        // Añade este método para retornar lista de Proveedores al combo
        public static List<Proveedor> ObtenerProveedores()
        {
            return ProveedorDAL.ObtenerProveedores();
        }
    }
}

