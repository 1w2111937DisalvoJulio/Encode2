using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class SuscriptorBLL
    {
        public SuscriptorDAL nuevo = new SuscriptorDAL();
        //public DataTable Buscar()
        //{
        //    DataTable tabla = new DataTable();
        //    tabla = nuevo.Buscar();
        //    return tabla;
        //}

        public bool Insertar(Suscriptor suscriptor)
        {
            return nuevo.InsertarSuscriptor(suscriptor);
        }

        public Suscriptor BuscarSuscriptor(string tipoDoc, string nroDoc)
        {
            return nuevo.BuscarSuscriptor(tipoDoc, nroDoc);
        }

        public bool ModificarSuscriptor(Suscriptor suscriptor)
        {
            return nuevo.ModificarSuscriptor(suscriptor);
        }

    }
}
