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
    public class ProductoDAL
    {
        // OPCIONAL pero muy útil para el formulario de venta
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"
                    SELECT p.Id, p.Nombre, p.Precio, p.Stock, c.Nombre AS Categoria
                    FROM Producto p
                    INNER JOIN Categoria c ON p.Id_Categoria = c.Id
                    WHERE p.Estado = 1;";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }

            return tabla;
        }


        //===============================
        // Insertar un nuevo producto
        //===============================
        public int Insertar(Producto p)
        {
            string sql = @"INSERT INTO Producto (Nombre, Precio, Stock, Estado, Id_Categoria) 
                   VALUES (@Nombre, @Precio, @Stock, @Estado, @Id_Categoria);
                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", p.Precio);
                    cmd.Parameters.AddWithValue("@Stock", p.Stock);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    cmd.Parameters.AddWithValue("@Id_Categoria", p.Id_Categoria);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        //===============================
        // Actualizar producto
        //===============================
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
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", p.Precio);
                    cmd.Parameters.AddWithValue("@Stock", p.Stock);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    cmd.Parameters.AddWithValue("@Id_Categoria", p.Id_Categoria);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        //===============================
        // Eliminar un producto
        //===============================
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM Producto WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cn.Open(); //abrir la conexión
                    return cmd.ExecuteNonQuery() > 0;
                    //ExecuteNonQuery devuelve cuántas filas fueron eliminadas
                }
            }
        }

        //===============================
        // Buscar por nombre o categoría
        //===============================
        public DataTable Buscar(string filtro)
        {
            DataTable dt = new DataTable(); //tabla memoria

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT Id, Nombre, Precio, Stock, Estado, Id_Categoria 
                           FROM Producto 
                           WHERE Nombre LIKE @Filtro";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    cn.Open(); //abrir la conexión
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        //===============================
        // Listar productos activos (Estado = 1)
        // Ideal para llenar ComboBox
        //===============================
        public static List<Producto> ListarActivos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT * FROM Producto WHERE Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
        public static int ObtenerStock(int idProducto)
        {
            int stock = 0;

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT Stock FROM Producto WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idProducto);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        stock = Convert.ToInt32(result);
                }
            }

            return stock;
        }
       

        
    }
}
