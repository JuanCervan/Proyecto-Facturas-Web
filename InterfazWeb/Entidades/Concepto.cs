using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazWeb.Entidades
{
    public class Concepto
    {
        int idConcepto;
        string nombre;
        double precio;
        string tipoIva;

        //Constructor
        public Concepto(int idConcepto,string nombre,double precio,string tipoIva)
        {
            this.idConcepto = idConcepto;
            this.nombre = nombre;
            this.precio = precio;
            this.tipoIva = tipoIva;
        }

        public Concepto(DataSet1.ConceptosRow regConcepto)
        {
            this.idConcepto = regConcepto.IdConcepto;
            this.nombre = regConcepto.Nombre;
            this.precio = regConcepto.Precio;
            this.tipoIva = regConcepto.TipoIva;
        }
        public Concepto()
        {
            this.idConcepto = -1;
        }
        public int IdConcepto
        {
            get { return idConcepto; }
            set { idConcepto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string TipoIva
        {
            get { return tipoIva; }
            set { tipoIva = value; }
        }

    }
}
