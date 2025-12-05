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
    public class ClienteDAL
    {
        //Traer todos los registros
        public DataTable Listar()
        {
            DataTable dt = new DataTable();//tabla memoria
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            //Sqlconection para conectar a la base de datos
            {
                string sql = "SELECT Id, Nombre, Dui, Telefono, Correo, Estado FROM Cliente";
                // sentencia sql para traer los datos de la tabla clientes
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                //sqlcomand para ejecutar la sentencia sql
                {
                    cn.Open();//abrir la conexion
                    new SqlDataAdapter(cmd).Fill(dt);
                    //sqldataadapter para llenar la tabla de memoria con los datos de la tabla clientes
                }
            }
            return dt;//retornar la tabla con los registros
        }

        //insertar un nuevo y actualizar un registro de la tabla clientes
        public int Insertar(Clientes c)
        {
            string sql = "INSERT INTO Cliente (Nombre, Dui, Telefono, Correo, Estado) VALUES (@Nombre, @Dui, @Telefono, @Correo, @Estado); SELECT SCOPE_IDENTITY();";
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Dui", c.Dui);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                    //ExecuteScalar: ejecuta la secuensio y devuelve
                    //el primer valor de la primera fila del conjunto de resultados
                }
            }
        }

        //Actualizar un registro de tabla clientes
        public bool Actualizar(Clientes c)
        {
            string sql = "UPDATE Cliente SET Nombre = @Nombre, Dui = @Dui, Telefono = @Telefono, Correo = @Correo, Estado = @Estado WHERE ID = @ID";
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ID", c.Id);
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Dui", c.Dui);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cn.Open();//abrir la conexion
                    return cmd.ExecuteNonQuery() > 0;
                    //ExecuteNonQuery: ejecuta la sentencia y devuelve
                    //el número de filas afectadas
                }
            }
        }
        //Eliminar un registro de la tabla clientes
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM Cliente WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cn.Open();//abrir la conexion
                    return cmd.ExecuteNonQuery() > 0;
                    //ExecuteNonQuery: ejecuta la sentencia y devuelve
                    //el número de filas afectadas
                }
            }
        }
        //Filtrar registros por nombre y telefono
        public DataTable Buscar(string filtro)
        {
            DataTable dt = new DataTable();//tabla memoria
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT ID, Nombre, Dui, Telefono, Correo, Estado FROM Cliente WHERE Nombre LIKE @Filtro OR Telefono LIKE @Filtro";
                // sentencia sql para traer los datos de la tabla clientes
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                //sqlcomand para ejecutar la sentencia sql
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                    cn.Open();//abrir la conexion
                    new SqlDataAdapter(cmd).Fill(dt);
                    //sqldataadapter: ejecuta el comando y llena la tabla de memoria
                }
            }
            return dt;//retornar la tabla con los registros 
        }
        // Este método sirve para llenar el ComboBox de clientes.
        public static List<Clientes> ListarActivos()
        {
            List<Clientes> lista = new List<Clientes>();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT * FROM Cliente WHERE Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Clientes
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Dui = dr["Dui"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }

            }
            return lista;

        }
    }
}
