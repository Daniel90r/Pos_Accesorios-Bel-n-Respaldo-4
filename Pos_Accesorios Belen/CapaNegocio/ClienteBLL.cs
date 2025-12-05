using Pos_Accesorios_Belen.CapaDatos;
using Pos_Accesorios_Belen.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Accesorios_Belen.CapaNegocio
{
    public class ClienteBLL
    {
        //Aqui va la logica de negocio
        ClienteDAL dAl = new ClienteDAL();
        //Creamos un opjeto de la clase ClienteDAl para poder acceder a sus metodos

        //metodo para listar todos los registros de la tabla clientes
        public DataTable Listar()
        {
            return dAl.Listar();
            //la bll no toca SQL, solo llama a los metodos de la Dall
        }
        //metodo para insertar un nuevo registro en la tabla clientes
        public int Guardar(Clientes c)
        {
            //validaciones de negocio
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");
            //si el Id es 0, es un nuevo registro insert
            if (c.Id == 0)
            {
                return dAl.Insertar(c);
            }
            else
            {
                //si el Id es diferente de 0, es una actualizacion
                dAl.Actualizar(c);
                MessageBox.Show("Registro actualizado correctamente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return c.Id;
            }
        }
        //METODO PARA ELIMINAR UN REGISTRO DE LA TABLA CLIENTES
        public bool Eliminar(int id)
        {
            return dAl.Eliminar(id);
            MessageBox.Show("Registro eliminado correctamente.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //METODO PARA BUSCAR UN REGISTRO EN LA TABLA CLIENTES POR NOMBRE Y TELEFONO
        public DataTable Buscar(string filtro)
        {
            return dAl.Buscar(filtro);
        }
    }
}
