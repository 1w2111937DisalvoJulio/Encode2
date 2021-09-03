using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class SuscriptorBLL
    {
        private SuscriptorBLL nuevo = new SuscriptorBLL();
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = nuevo.Mostrar();
            return tabla;
        }

        public void Insertar(string nombre, string apellido, string numeroDocumento, string tipoDocumento, string telefono, string email, string nombreUsuario, string pass)
        {
            nuevo.Insertar(nombre, apellido, numeroDocumento, tipoDocumento, telefono, email, nombreUsuario, pass);
        }




    }
}
