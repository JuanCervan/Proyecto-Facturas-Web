using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 


namespace InterfazWeb
{
    public partial class WebDetalleFacturas : System.Web.UI.Page
    {
        Factura fact;
        Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            if (!Page.IsPostBack)
            {
                fact = (Factura)Session["FacturaEdit"];
                cliente = (Cliente)Session["ClienteFactura"];

                if (fact.IdFactura != -1)
                {
                    CargaControles();
                }
                else
                {
                    lbCabecera.Text = "Añadir Factura de " + cliente.Nombre;
                    txbNumero.Text = fact.Numero.ToString();
                }
               
            }
        }

        private void CargaControles()
        {
            int dia =Convert.ToInt32( fact.Fecha.Substring(0, 2));
            int mes =Convert.ToInt32( fact.Fecha.Substring(3, 2));
            int anyo =Convert.ToInt32(fact.Fecha.Substring(6));
            DateTime date = new DateTime(anyo,mes,dia);
            txbFechaNueva.Text = String.Format("{0:yyyy-MM-dd}", date);

            txbNumero.Text = fact.Numero.ToString();
            //txbConcepto.Text = fact.Concepto;
            //txbImporte.Text = fact.Importe.ToString("0.00");
            //ddlTipoIva.Text = fact.TipoIva;
            /*double cuota = Convert.ToDouble(txbImporte.Text) * (Convert.ToDouble(ddlTipoIva.Text)) / 100;
            double cuotaR = Math.Round(cuota, 2);
            txbCuota.Text = cuotaR.ToString("0.00");
            double total = Convert.ToDouble(txbImporte.Text) + cuota;
            double totalR = Math.Round(total, 2);
            txbTotal.Text = totalR.ToString("0.00");*/
            lbCabecera.Text = "Editar Factura de " + cliente.Nombre;
        }

        /*protected void ddlTipoIva_TextChanged(object sender, EventArgs e)
        {
            double cuota = Convert.ToDouble(txbImporte.Text) * (Convert.ToDouble(ddlTipoIva.SelectedValue))/100;
            double cuotaR = Math.Round(cuota, 2);
            txbCuota.Text = cuotaR.ToString("0.00")+"€";
            double total = Convert.ToDouble(txbImporte.Text) + cuota;
            double totalR = Math.Round(total, 2);
            txbTotal.Text = totalR.ToString("0.00")+"€";
       
        }*/

        /*protected void txbImporte_TextChanged(object sender, EventArgs e)
        {
            lbImporte.Visible = false;
            if (txbImporte.Text.Contains('.'))
            {
                txbImporte.Text = txbImporte.Text.Replace('.', ',');
            }
                try
            {
               
                double cuota = Convert.ToDouble(txbImporte.Text) * Convert.ToDouble(ddlTipoIva.SelectedValue) / 100;
                double cuotaR = Math.Round(cuota, 2);
                txbCuota.Text = cuotaR.ToString("0.00") + "€";
                double total = Convert.ToDouble(txbImporte.Text) + cuota;
                double totalR = Math.Round(total, 2);
                txbTotal.Text = totalR.ToString("0.00") + "€";
            }
            catch
            {
                lbImporte.Visible = true;
                txbImporte.Text = "";
                txbImporte.Focus();

            }
        }*/

        

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Timer1.Enabled = false;
            string anyo = txbFechaNueva.Text.Substring(0, 4);
            string mes = txbFechaNueva.Text.Substring(5, 2);
            string dia = txbFechaNueva.Text.Substring(8, 2);
            string fecha = dia + "/" + mes + "/" + anyo;
            fact = new Factura(((Factura)Session["FacturaEdit"]).IdFactura, ((Factura)Session["FacturaEdit"]).IdCliente, fecha,Convert.ToInt32(txbNumero.Text));//, txbConcepto.Text,Convert.ToDouble(txbImporte.Text), ddlTipoIva.Text);

            if (fact.IdFactura != -1)
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Factura " + txbNumero.Text + " editada correctamente";
                btnCancelar.Text = "Cancelar";
                LNyAD.ModificarFactura(fact);
            }
            else
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Factura " + txbNumero.Text + " añadida correctamente";
                btnCancelar.Text = "Volver";
                LNyAD.AddFactura(fact);
                txbFechaNueva.Text = "";
                txbNumero.Text = "";
            }

            btnCancelar.Text = "Volver";
            Timer1.Enabled = true;
            txbNumero.Text = LNyAD.MaxNumero().ToString();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string anyo = txbFechaNueva.Text.Substring(0, 4);
            string mes = txbFechaNueva.Text.Substring(5, 2);
            string dia = txbFechaNueva.Text.Substring(8, 2);
            string fecha = dia + "/" + mes + "/" + anyo;
            fact = new Factura(((Factura)Session["FacturaEdit"]).IdFactura, ((Factura)Session["FacturaEdit"]).IdCliente, fecha,Convert.ToInt32(txbNumero.Text));//, txbConcepto.Text, Convert.ToDouble(txbImporte.Text), ddlTipoIva.Text);

            
                if (LNyAD.FacturaWebPorNumero(txbNumero.Text).Count>0&&txbNumero.Text==LNyAD.FacturaWebPorNumero(txbNumero.Text)[0].Numero.ToString()&&LNyAD.FacturaWebPorNumero(txbNumero.Text)[0].IdFactura!=fact.IdFactura)
            {
                args.IsValid = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbAviso.Visible = false;
            Timer1.Enabled = false;
        }

        /*  protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
          {
              double valor;
              if(!double.TryParse(txbImporte.Text,out valor))
              {
                  args.IsValid = false;
              }
          }*/
    }
}