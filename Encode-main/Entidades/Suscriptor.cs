using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Suscriptor
    {
        //Conexion conexion = new Conexion();

        private int idSuscriptor;
        private string nombre;
        private string apellido;
        private int numeroDocumento;
        private string tipoDocumento;
        private string direccion;
        private int telefono;
        private string email;
        private string nombreUsuario;
        private string pass;

        public Suscriptor()
        {
        }

        public Suscriptor(int idSuscriptor, string nombre, string apellido, int numeroDocumento, string tipoDocumento, string direccion, int telefono, string email, string nombreUsuario, string pass)
        {
            this.idSuscriptor = idSuscriptor;
            this.nombre = nombre;
            this.apellido = apellido;
            this.numeroDocumento = numeroDocumento;
            this.tipoDocumento = tipoDocumento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.nombreUsuario = nombreUsuario;
            this.pass = pass;
        }

        public int IdSuscriptor { get => idSuscriptor; set => idSuscriptor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
