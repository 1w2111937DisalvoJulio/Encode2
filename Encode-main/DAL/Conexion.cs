using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-SLTD1HU\SQLEXPRESS;Initial Catalog=Suscripciones;Integrated Security=True");
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }



        //*****************************************************************
        //    public SqlConnection conexion;
        //    public SqlCommand comando;
        //    public SqlDataReader lector = null;

        //    public string conexionString = @"Data Source=DESKTOP-SLTD1HU\SQLEXPRESS;Initial Catalog=Suscripciones;Integrated Security=True";

        //    public Conexion()
        //    {
        //        conexion.ConnectionString = conexionString;
        //    }
        //    public void conectar()
        //    {

        //        conexion.Open();
        //        comando.Connection = conexion;
        //        //comando.CommandType = CommandType.Text;
        //    }
        //    public void desconectar()
        //    {
        //        conexion.Close();
        //        conexion.Dispose();
        //    }
        //    public void leerTabla(string nombreTabla)
        //    {
        //        conectar();
        //        comando.CommandText = $"select * from {nombreTabla}";
        //        lector = comando.ExecuteReader();
        //    }

        //    public DataTable recuperarTabla(string nombreTabla) // recupera los datos de la consulta
        //    {
        //        conectar();

        //        comando.CommandText = $"select * from {nombreTabla}";
        //        DataTable tabla = new DataTable();
        //        tabla.Load(comando.ExecuteReader());



        //        desconectar();
        //        return tabla;
        //    }
        //    public void actualizar(string consulta)// consultas que modifica registros
        //    {
        //        conectar();
        //        comando.CommandText = consulta;
        //        comando.ExecuteNonQuery();
        //        desconectar();
        //    }
    }
}
