using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazWeb.Entidades
{
    public class Linea
    {
        int idLinea;
        int idFactura;
        string concepto;
        double cantidad;
        double precio;
        int tipoIva;

        //constructor
        public Linea(int idLinea,int idFactura,string concepto,double cantidad,double precio,int tipoIva)
        {
            this.idLinea = idLinea;
            this.idFactura = idFactura;
            this.concepto = concepto;
            this.cantidad = cantidad;
            this.precio = precio;
            this.tipoIva = tipoIva;
        }
        //constructor vacio
        public Linea()
        {
            this.idLinea = -1;
        }
        //constructor con registro
        public Linea(DataSet1.LineasRow regLinea)
        {
            this.idLinea = regLinea.IdLinea;
            this.idFactura = regLinea.IdFactura;
            this.concepto = regLinea.Concepto;
            this.cantidad = regLinea.Cantidad;
            this.precio = regLinea.Precio;
            this.tipoIva = regLinea.TipoIva;
        }

        //get y set

        public int IdLinea
        {
            get { return idLinea; }
            set { idLinea = value; }
        }

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public int TipoIva
        {
            get { return tipoIva; }
            set { tipoIva = value; }
        }
    }
}
