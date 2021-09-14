using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace DAL
{
    public class SuscripcionDAL
    {
        private Conexion conexion = new Conexion();
        SqlDataReader leer = null;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //REGISTRAR SUSCRIPCION
        public Suscripcion RegistrarSuscripcion(Suscriptor suscriptor)
        {
            Suscripcion suscripcion = new Suscripcion();
            if (!VerificarSuscripcion(suscriptor))
            {
                string procedure = "sp_RegistrarSuscripcion";
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IdSuscriptor", suscriptor.IdSuscriptor);
                comando.ExecuteNonQuery();

                return suscripcion;
            }
            else
            {
                return null;
            }
            
        }

        //VERIFICAR SUSCRIPCION
        public  bool VerificarSuscripcion(Suscriptor suscriptor)
        {
            try
            {
                string procedure = "sp_VerificarSuscripcion";
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IdSuscriptor", suscriptor.IdSuscriptor);
                comando.ExecuteNonQuery();
                leer = comando.ExecuteReader();

                if (leer.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


    }
}
