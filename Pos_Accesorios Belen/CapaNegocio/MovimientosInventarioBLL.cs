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
    public class MovimientosInventarioBLL
    {
        private MovimientosInventarioDAL dal = new MovimientosInventarioDAL();
        private ProductoDAL2 productoDal = new ProductoDAL2(); // tu DAL existente

        // Registrar entrada: actualiza stock y guarda movimiento
        public int RegistrarEntrada(int idProducto, int cantidad, string proveedor = null, DateTime? fecha = null)
        {
            if (idProducto <= 0) throw new ArgumentException("Producto inválido.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");

            DateTime fechaMov = fecha ?? DateTime.Now;

            // 1) Actualizar stock (sumar)
            // Primeramente obtener el producto actual (usamos ProductoDAL2.Listar y filtrar)
            var dtProducto = productoDal.Listar();
            DataRow[] filas = dtProducto.Select($"Id = {idProducto}");
            if (filas.Length == 0) throw new Exception("Producto no encontrado.");

            Producto p = new Producto
            {
                Id = Convert.ToInt32(filas[0]["Id"]),
                Nombre = filas[0]["Nombre"].ToString(),
                Precio = Convert.ToDecimal(filas[0]["Precio"]),
                Stock = Convert.ToInt32(filas[0]["Stock"]),
                Estado = Convert.ToBoolean(filas[0]["Estado"]),
                Id_Categoria = Convert.ToInt32(filas[0]["Id_Categoria"])
            };

            p.Stock += cantidad;

            bool actualizado = productoDal.Actualizar(p);
            if (!actualizado) throw new Exception("No se pudo actualizar el stock del producto.");

            // 2) Insertar movimiento (ENTRADA)
            MovimientoInventario mov = new MovimientoInventario
            {
                IdProducto = idProducto,
                Cantidad = cantidad,
                Tipo = "ENTRADA",
                Fecha = fechaMov,
                Detalle = proveedor ?? "Entrada manual"
            };

            return dal.InsertarMovimiento(mov);
        }

        // Registrar salida: restar stock y registrar movimiento
        public int RegistrarSalida(int idProducto, int cantidad, string detalle = null, DateTime? fecha = null)
        {
            if (idProducto <= 0) throw new ArgumentException("Producto inválido.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");

            DateTime fechaMov = fecha ?? DateTime.Now;

            // Obtener producto
            var dtProducto = productoDal.Listar();
            DataRow[] filas = dtProducto.Select($"Id = {idProducto}");
            if (filas.Length == 0) throw new Exception("Producto no encontrado.");

            Producto p = new Producto
            {
                Id = Convert.ToInt32(filas[0]["Id"]),
                Nombre = filas[0]["Nombre"].ToString(),
                Precio = Convert.ToDecimal(filas[0]["Precio"]),
                Stock = Convert.ToInt32(filas[0]["Stock"]),
                Estado = Convert.ToBoolean(filas[0]["Estado"]),
                Id_Categoria = Convert.ToInt32(filas[0]["Id_Categoria"])
            };

            if (p.Stock < cantidad) throw new Exception("No hay suficiente stock para realizar la salida.");

            p.Stock -= cantidad;

            bool actualizado = productoDal.Actualizar(p);
            if (!actualizado) throw new Exception("No se pudo actualizar el stock del producto.");

            MovimientoInventario mov = new MovimientoInventario
            {
                IdProducto = idProducto,
                Cantidad = cantidad,
                Tipo = "SALIDA",
                Fecha = fechaMov,
                Detalle = detalle ?? "Salida manual"
            };

            return dal.InsertarMovimiento(mov);
        }

        // Métodos para consulta
        public DataTable ListarMovimientos() => dal.ListarTodos();

        public DataTable ListarMovimientosPorProducto(int idProducto) => dal.ListarPorProducto(idProducto);

        public DataTable BuscarMovimientos(DateTime? desde, DateTime? hasta, string tipo, string textoProducto)
            => dal.Buscar(desde, hasta, tipo, textoProducto);

        public DataTable ListarEntradasRecientes(int top = 20) => dal.ListarEntradasRecientes(top);
    }
}

