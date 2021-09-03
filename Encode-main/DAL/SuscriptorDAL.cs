using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class SuscriptorDAL
    {
        private Conexion conexion = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Suscriptor";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public bool Insertar(Suscriptor suscriptor)
        {
            try
            {
            string procedure = "sp_insertarSuscriptor";    
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = procedure;            
            comando.Parameters.AddWithValue("@nombre", suscriptor.Nombre);
            comando.Parameters.AddWithValue("@apellido", suscriptor.Apellido);
            comando.Parameters.AddWithValue("@numeroDocumento", suscriptor.NumeroDocumento);
            comando.Parameters.AddWithValue("@tipoDocumento", suscriptor.TipoDocumento);
            comando.Parameters.AddWithValue("@telefono", suscriptor.Telefono);
            comando.Parameters.AddWithValue("@email", suscriptor.Email);
            comando.Parameters.AddWithValue("@nombreUsuario", suscriptor.NombreUsuario);
            comando.Parameters.AddWithValue("@pass", suscriptor.Pass);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
                return true;    
            }
            catch (Exception)
            {
                conexion.CerrarConexion();
                return false;
            }
        }


        //string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaBD"].ConnectionString;
        //SqlConnection cn = new SqlConnection(cadenaConexion);

        //public void Insertar(Suscriptor nuevo)
        //{
        //    try
        //    {





        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



    }
}
