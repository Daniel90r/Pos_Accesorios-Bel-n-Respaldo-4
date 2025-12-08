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
    public class MovimientosInventarioDAL
    {
        // Insertar un movimiento (entrada o salida)
        public int InsertarMovimiento(MovimientoInventario m)
        {
            string sql = @"INSERT INTO MovimientosInventario (ProductoID, Cantidad, Tipo, Fecha)
                       VALUES (@ProductoID, @Cantidad, @Tipo, @Fecha);
                       SELECT SCOPE_IDENTITY();";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@ProductoID", m.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", m.Cantidad);
                cmd.Parameters.AddWithValue("@Tipo", m.Tipo);
                cmd.Parameters.AddWithValue("@Fecha", m.Fecha);

                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Listar todos los movimientos (recientes primero)
        public DataTable ListarTodos()
        {
            string sql = @"SELECT m.MovimientoID, m.ProductoID, p.Nombre AS Producto, m.Cantidad, m.Tipo, m.Fecha
                       FROM MovimientosInventario m
                       LEFT JOIN Producto p ON p.Id = m.ProductoID
                       ORDER BY m.Fecha DESC";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Listar movimientos por producto
        public DataTable ListarPorProducto(int idProducto)
        {
            string sql = @"SELECT m.IdMovimiento, m.ProductoID, p.Nombre AS Producto, m.Cantidad, m.Tipo, m.Fecha
                       FROM MovimientosInventario m
                       LEFT JOIN Producto p ON p.Id = m.ProductoID
                       WHERE m.ProductoID = @ProductoID
                       ORDER BY m.Fecha DESC";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@ProductoID", idProducto);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Buscar por filtros: texto de producto, tipo, fecha rango
        public DataTable Buscar(DateTime? fechaDesde, DateTime? fechaHasta, string tipo, string textoProducto)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append(@"SELECT m.MovimientoID, m.ProductoID, p.Nombre AS Producto, m.Cantidad, m.Tipo, m.Fecha
                      FROM MovimientosInventario m
                      LEFT JOIN Producto p ON p.Id = m.ProductoID
                      WHERE 1=1 ");

            var parametros = new List<SqlParameter>();

            if (fechaDesde.HasValue)
            {
                sql.Append(" AND m.Fecha >= @fechaDesde");
                parametros.Add(new SqlParameter("@fechaDesde", fechaDesde.Value));
            }
            if (fechaHasta.HasValue)
            {
                sql.Append(" AND m.Fecha <= @fechaHasta");
                parametros.Add(new SqlParameter("@fechaHasta", fechaHasta.Value));
            }
            if (!string.IsNullOrWhiteSpace(tipo))
            {
                sql.Append(" AND m.Tipo = @tipo");
                parametros.Add(new SqlParameter("@tipo", tipo));
            }
            if (!string.IsNullOrWhiteSpace(textoProducto))
            {
                sql.Append(" AND p.Nombre LIKE @textoProducto");
                parametros.Add(new SqlParameter("@textoProducto", "%" + textoProducto + "%"));
            }

            sql.Append(" ORDER BY m.Fecha DESC");

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql.ToString(), cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (parametros.Count > 0)
                    cmd.Parameters.AddRange(parametros.ToArray());

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Listar solo entradas recientes (últimos N)
        public DataTable ListarEntradasRecientes(int top = 20)
        {
            string sql = $@"SELECT TOP({top}) m.MovimientoID, m.ProductoID, p.Nombre AS Producto, m.Cantidad, m.Tipo, m.Fecha
                        FROM MovimientosInventario m
                        LEFT JOIN Producto p ON p.Id = m.ProductoID
                        WHERE m.Tipo = 'ENTRADA'
                        ORDER BY m.Fecha DESC";

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
