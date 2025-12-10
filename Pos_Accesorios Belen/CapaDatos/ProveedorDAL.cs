using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaDatos
{
    public class ProveedorDAL
    {
        // INSERTAR
        public static bool InsertarProveedor(Proveedor p)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = @"INSERT INTO Proveedores (Nombre, Telefono, Email, Direccion, 
                           TipoProducto, Estado)
                           VALUES (@Nombre, @Telefono, @Email, @Direccion, @TipoProducto, @Estado)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@Direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@TipoProducto", p.TipoProducto);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ACTUALIZAR
        public static bool ActualizarProveedor(Proveedor p)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = @"UPDATE Proveedores SET 
                                Nombre=@Nombre, Telefono=@Telefono, Email=@Email,
                                Direccion=@Direccion, TipoProducto=@TipoProducto,
                                Estado=@Estado
                             WHERE ProveedorID=@ID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@Direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@TipoProducto", p.TipoProducto);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);
                cmd.Parameters.AddWithValue("@ID", p.ProveedorID);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ELIMINAR
        public static bool EliminarProveedor(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "DELETE FROM Proveedores WHERE ProveedorID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // BUSQUEDA
        public static DataTable Buscar(string nombre, string tipo)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = @"SELECT * FROM Proveedores 
                             WHERE Nombre LIKE @Nombre AND 
                                   (@Tipo = '' OR TipoProducto = @Tipo)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                cmd.Parameters.AddWithValue("@Tipo", tipo);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // (Asumo que ya tienes Insertar/Actualizar/Eliminar/Buscar).
        // Agregamos este método para poblar combos.
        public static List<Proveedor> ObtenerProveedores()
        {
            var lista = new List<Proveedor>();

            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT ProveedorID, Nombre FROM Proveedores WHERE Estado = 1 ORDER BY Nombre";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            ProveedorID = Convert.ToInt32(dr["ProveedorID"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
