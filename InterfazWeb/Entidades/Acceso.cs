using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazWeb.Entidades
{
    public class Acceso
    {
        int idAcceso;
        string nombre;

        //Constructor
        public Acceso(int idAcceso,string nombre)
        {
            this.idAcceso = idAcceso;
            this.nombre = nombre;
        }
        //vacio
        public Acceso()
        {

        }
        //con registro
        public Acceso(DataSet1.AccesoRow regAcceso)
        {
            this.idAcceso = regAcceso.idAcceso;
            this.nombre = regAcceso.Nombre;
        }
        

        

        public int IdAcceso
        {
            get
            {
                return idAcceso;
            }

            set
            {
                idAcceso = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

    }
}