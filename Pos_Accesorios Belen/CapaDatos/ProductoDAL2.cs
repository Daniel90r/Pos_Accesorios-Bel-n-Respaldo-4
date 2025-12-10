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
    public class ProductoDAL2
    {
        // LISTAR TODOS LOS PRODUCTOS
        public DataTable Listar()
        {
            string sql = @"SELECT Id, Nombre, Precio, Stock, Estado, Id_Categoria 
                       FROM Producto";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // INSERTAR PRODUCTO
        public int Insertar(Producto p)
        {
            string sql = @"INSERT INTO Producto (Nombre, Precio, Stock, Estado, Id_Categoria)
                       VALUES (@Nombre, @Precio, @Stock, @Estado, @Id_Categoria);
                       SELECT SCOPE_IDENTITY();";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);

                // CORRECTO para BIT:
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = p.Estado ? 1 : 0;

                cmd.Parameters.AddWithValue("@Id_Categoria", p.Id_Categoria);

                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ACTUALIZAR PRODUCTO
        public bool Actualizar(Producto p)
        {
            string sql = @"UPDATE Producto SET 
                        Nombre = @Nombre,
                        Precio = @Precio,
                        Stock = @Stock,
                        Estado = @Estado,
                        Id_Categoria = @Id_Categoria
                       WHERE Id = @Id";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);

                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = p.Estado ? 1 : 0;

                cmd.Parameters.AddWithValue("@Id_Categoria", p.Id_Categoria);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ELIMINAR PRODUCTO
        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM Producto WHERE Id = @Id";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // BUSCAR PRODUCTO
        public DataTable Buscar(string filtro)
        {
            string sql = @"SELECT Id, Nombre, Precio, Stock, Estado, Id_Categoria
                       FROM Producto
                       WHERE Nombre LIKE '%' + @filtro + '%'";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@filtro", filtro);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static List<Producto> ObtenerProductos()
        {
            var lista = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT Id, Nombre, Precio FROM Producto WHERE Estado = 1 ORDER BY Nombre";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Precio = dr["Precio"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Precio"])
                        });
                    }
                }
            }

            return lista;
        }
        public static bool AumentarStock(int productoID, int cantidad)
        {
            bool resultado = false;

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "UPDATE Productos SET Stock = Stock + @Cantidad WHERE ProductoID = @ProductoID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@ProductoID", productoID);

                con.Open();
                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }
    }
}
