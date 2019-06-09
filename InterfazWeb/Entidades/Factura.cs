using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazWeb.Entidades
{
    public class Factura
    {
        int idFactura;
        int idCliente;
        string fecha;
        int numero;
        //string concepto;
        //double importe;
        //string tipoIva;

        //constructor
        public Factura(int idFactura, int idCliente, string fecha, int numero)//, string concepto, double importe, string tipoIva)
        {
            this.idFactura = idFactura;
            this.idCliente = idCliente;
            this.fecha = fecha;
            this.numero = numero;
            //this.concepto = concepto;
            //this.importe = importe;
            //this.tipoIva = tipoIva;
        }
        //constructor vacio
        public Factura()
        {
            this.idFactura = -1;
        }
        //constructor con registro
        public Factura(DataSet1.FacturasRow regFactura)
        {
           
            this.idFactura = regFactura.IdFactura;
            this.idCliente = regFactura.IdCliente;
            this.fecha = regFactura.Fecha;
            this.numero = regFactura.Numero;
           // this.concepto = regFactura.Concepto;
            //this.importe = Convert.ToDouble(regFactura.Importe);
            //this.tipoIva = regFactura.TipoIva;
           
        }



        //get y set
        public int IdFactura
        {
            get
            {
                return idFactura;
            }

            set
            {
                idFactura = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        /*public string Concepto
        {
            get
            {
                return concepto;
            }

            set
            {
                concepto = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }

        public string TipoIva
        {
            get
            {
                return tipoIva;
            }

            set
            {
                tipoIva = value;
            }
        }*/
    }
}
