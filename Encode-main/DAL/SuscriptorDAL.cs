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
        SqlDataReader leer = null;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();       

        public Suscriptor BuscarSuscriptor(string tipoDoc, string nroDoc)
        {
            try
            {
                Suscriptor suscriptor = new Suscriptor();
                conexion.AbrirConexion();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "select * " +
                                     "from Suscriptor" +
                                     " where TipoDocumento = '" + tipoDoc + "' and NumeroDocumento = '" + nroDoc + "'";
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    if (!leer.IsDBNull(0))
                    {
                        suscriptor.IdSuscriptor = leer.GetInt32(0);
                    }
                    if (!leer.IsDBNull(1))
                    {
                        suscriptor.NombreSuscriptor = leer.GetString(1);
                    }
                    if (!leer.IsDBNull(2))
                    {
                        suscriptor.ApellidoSuscriptor = leer.GetString(2);
                    }
                    if (!leer.IsDBNull(3))
                    {
                        suscriptor.NumeroDocumento = leer.GetString(3);
                    }
                    if (!leer.IsDBNull(4))
                    {
                        suscriptor.TipoDocumento = leer.GetString(4);
                    }
                    if (!leer.IsDBNull(5))
                    {
                        suscriptor.Direccion = leer.GetString(5);
                    }
                    if (!leer.IsDBNull(6))
                    {
                        suscriptor.NroTelefono = leer.GetString(6);
                    }
                    if (!leer.IsDBNull(7))
                    {
                        suscriptor.Email = leer.GetString(7);
                    }
                    if (!leer.IsDBNull(8))
                    {
                        suscriptor.NombreUsuario = leer.GetString(8);
                    }
                    if (!leer.IsDBNull(9))
                    {
                        suscriptor.Contrasenia = leer.GetString(9);
                    }
                    return suscriptor;
                }
                return suscriptor = null;
            }

            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public bool InsertarSuscriptor(Suscriptor suscriptor)
        {
            try
            {
            string procedure = "sp_insertarSuscriptor";    
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = procedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@nombre", suscriptor.NombreSuscriptor);
            comando.Parameters.AddWithValue("@apellido", suscriptor.ApellidoSuscriptor);
            comando.Parameters.AddWithValue("@nroDocumento", suscriptor.NumeroDocumento);
            comando.Parameters.AddWithValue("@tipoDocumento", suscriptor.TipoDocumento);
            comando.Parameters.AddWithValue("@telefono", suscriptor.NroTelefono);
            comando.Parameters.AddWithValue("@email", suscriptor.Email);
            comando.Parameters.AddWithValue("@direccion", suscriptor.Direccion);
            comando.Parameters.AddWithValue("@nomUsuario", suscriptor.NombreUsuario);
            comando.Parameters.AddWithValue("@pass", suscriptor.Contrasenia);
            comando.ExecuteNonQuery();
            
                return true;    
            }
            catch (Exception)
            {                
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public bool ModificarSuscriptor(Suscriptor suscriptor)
        {
            try
            {
                string procedure = "sp_modificarSuscriptor";
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", suscriptor.NombreSuscriptor);
                comando.Parameters.AddWithValue("@apellido", suscriptor.ApellidoSuscriptor);                
                comando.Parameters.AddWithValue("@telefono", suscriptor.NroTelefono);
                comando.Parameters.AddWithValue("@email", suscriptor.Email);
                comando.Parameters.AddWithValue("@direccion", suscriptor.Direccion);               
                comando.Parameters.AddWithValue("@pass", suscriptor.Contrasenia);
                comando.Parameters.AddWithValue("@nroDocumento", suscriptor.NumeroDocumento);
                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                conexion.CerrarConexion();
                return false;
            }
        }
        
        


    }
}
