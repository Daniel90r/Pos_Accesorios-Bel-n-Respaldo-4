using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_Accesorios_Belen.CapaDatos
{
    public class DetalleCompraDAL
    {
        public static List<DetalleCompra> ObtenerDetallePorCompra(int compraID)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();

            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = @"SELECT d.DetalleCompraID, d.CompraID, d.ProductoID, 
                                    d.Cantidad, d.PrecioCompra, d.SubTotal,
                                    p.Nombre AS NombreProducto
                             FROM DetalleCompras d
                             INNER JOIN Producto p ON p.Id = d.ProductoID
                             WHERE d.CompraID = @CompraID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompraID", compraID);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new DetalleCompra()
                    {
                        DetalleCompraID = Convert.ToInt32(dr["DetalleCompraID"]),
                        CompraID = Convert.ToInt32(dr["CompraID"]),
                        ProductoID = Convert.ToInt32(dr["ProductoID"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                        SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                        NombreProducto = dr["NombreProducto"].ToString()
                    });
                }
            }
            return lista;
        }

        public static bool InsertarDetalle(DetalleCompra d)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = @"INSERT INTO DetalleCompras 
                            (CompraID, ProductoID, Cantidad, PrecioCompra)
                             VALUES (@CompraID, @ProductoID, @Cantidad, @PrecioCompra)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompraID", d.CompraID);
                cmd.Parameters.AddWithValue("@ProductoID", d.ProductoID);
                cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioCompra", d.PrecioCompra);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarDetalle(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string query = "DELETE FROM DetalleCompras WHERE DetalleCompraID=@ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
