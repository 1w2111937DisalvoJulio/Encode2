using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class SuscripcionBLL
    {
        public SuscripcionDAL nuevo = new SuscripcionDAL();
        public Suscripcion RegistrarSuscripcion(Suscriptor sus)
        {
            return nuevo.RegistrarSuscripcion(sus);
        }

       public bool VerificarSus (Suscriptor suscriptor)
        {
            return nuevo.VerificarSuscripcion(suscriptor);
        }


    }
}
