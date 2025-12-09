using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaDatos
{
    public class CompraDAL
    {
        public static List<Compra> ObtenerCompras()
        {
            List<Compra> lista = new List<Compra>();

            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = @"SELECT c.CompraID, c.ProveedorID, c.Fecha, c.TotalCompra,
                                    c.MetodoPago, c.Observaciones,
                                    p.Nombre AS NombreProveedor
                             FROM Compras c
                             INNER JOIN Proveedores p ON p.ProveedorID = c.ProveedorID
                             ORDER BY c.CompraID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Compra()
                    {
                        CompraID = Convert.ToInt32(dr["CompraID"]),
                        ProveedorID = Convert.ToInt32(dr["ProveedorID"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        TotalCompra = Convert.ToDecimal(dr["TotalCompra"]),
                        MetodoPago = dr["MetodoPago"].ToString(),
                        Observaciones = dr["Observaciones"].ToString(),
                        NombreProveedor = dr["NombreProveedor"].ToString()
                    });
                }
            }
            return lista;
        }

        public static int RegistrarCompra(Compra compra)
        {
            int compraID = 0;

            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = @"INSERT INTO Compras (ProveedorID, Fecha, TotalCompra, MetodoPago, Observaciones)
                             VALUES (@ProveedorID, @Fecha, @TotalCompra, @MetodoPago, @Observaciones);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID);
                cmd.Parameters.AddWithValue("@Fecha", compra.Fecha);
                cmd.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                cmd.Parameters.AddWithValue("@MetodoPago", compra.MetodoPago);
                cmd.Parameters.AddWithValue("@Observaciones", compra.Observaciones);

                conn.Open();
                compraID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return compraID;
        }

        public static bool ActualizarCompra(Compra compra)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = @"UPDATE Compras 
                             SET ProveedorID=@ProveedorID, Fecha=@Fecha, TotalCompra=@TotalCompra,
                                 MetodoPago=@MetodoPago, Observaciones=@Observaciones
                             WHERE CompraID=@CompraID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompraID", compra.CompraID);
                cmd.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID);
                cmd.Parameters.AddWithValue("@Fecha", compra.Fecha);
                cmd.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                cmd.Parameters.AddWithValue("@MetodoPago", compra.MetodoPago);
                cmd.Parameters.AddWithValue("@Observaciones", compra.Observaciones);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarCompra(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = "DELETE FROM Compras WHERE CompraID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
