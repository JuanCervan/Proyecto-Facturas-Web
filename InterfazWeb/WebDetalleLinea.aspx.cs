using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebDetalleLinea : System.Web.UI.Page
    {
        Linea linea;
        Factura factura;
        Cliente cliente;
        //double cantidadSQL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            linea = (Linea)Session["lineaE"];
            factura = (Factura)Session["FacturaDet"];
            cliente = (Cliente)Session["ClienteFactura"];
            
            if (!IsPostBack)
            {
                if (linea.IdLinea != -1)
                {
                    lbCabecera.Text = "Editar Línea de la Factura " + factura.Numero + " de " + cliente.Nombre;
                    // cbConcepto.Text = linea.Concepto;
                    cbConcepto.Visible = false;
                    txbConceptoE.Text = linea.Concepto;
                    txbConceptoE.Visible = true;
                    btnConcepto.Visible = false;
                    txbCantidad.Text = linea.Cantidad.ToString();
                    txbPrecio.Text = linea.Precio.ToString();
                    cbIva.Text = linea.TipoIva.ToString();
                    RequiredCbConcepto.ControlToValidate = "txbConceptoE";
                }
                else
                {
                    CargaConceptoLineas();
                    lbCabecera.Text = "Añadir Línea a la Factura " + factura.Numero + " de " + cliente.Nombre;
                }
            }


        }

        private void CargaConceptoLineas()
        {
            cbConcepto.Visible = true;
            RequiredCbConcepto.ControlToValidate = "cbConcepto";
            txbConceptoE.Visible = false;
            List<Concepto> listaTodosConceptos;
            listaTodosConceptos = LNyAD.CargaComboConceptos();
            listaTodosConceptos.Insert(0, new Concepto(0, "Seleccione un Concepto...", 0, ""));
            cbConcepto.DataSource = listaTodosConceptos;
            cbConcepto.DataValueField = "IdConcepto";
            cbConcepto.DataTextField = "Nombre";
            cbConcepto.DataBind();
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Timer1.Enabled = false;
            if (cbConcepto.Visible==true)
             linea = new Linea(((Linea)Session["lineaE"]).IdLinea, factura.IdFactura, cbConcepto.SelectedItem.Text,Convert.ToDouble(txbCantidad.Text), Convert.ToDouble(txbPrecio.Text), Convert.ToInt32(cbIva.SelectedValue));
           else linea = new Linea(((Linea)Session["lineaE"]).IdLinea, factura.IdFactura, txbConceptoE.Text,Convert.ToDouble(txbCantidad.Text), Convert.ToDouble(txbPrecio.Text), Convert.ToInt32(cbIva.SelectedValue));

            if (linea.IdLinea != -1)
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Línea editada correctamente";
               // Timer1.Enabled = true;
                LNyAD.ModificarLinea(linea);
            }
            else
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Línea añadida correctamente";
                //Timer1.Enabled = true;
                LNyAD.AddLinea(linea);
                CargaConceptoLineas();
                txbCantidad.Text = "";
                txbPrecio.Text = "";
                cbIva.Text = "";
            }
            Timer1.Enabled = true;
            
        }

        protected void btnConcepto_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebConceptos.aspx");
        }

        protected void cbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                txbCantidad.Focus();
            //int idConcepto = Convert.ToInt32(cbConcepto.SelectedIndex);//este es el indice en el combo no en la tabla... hay que cambiarlo
            string Concepto = cbConcepto.SelectedItem.Text;
            txbPrecio.Text = LNyAD.PrecioPorNombre(Concepto);
                cbIva.Text = LNyAD.TipoIvaPorNombre(Concepto);
            
        }

        protected void cbConcepto_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txbCantidad.Text.Contains('.'))
            {
                
                txbCantidad.Text = txbCantidad.Text.Replace('.', ',');
            }

            try
            {
                double cantidadOK = Convert.ToDouble(txbCantidad.Text);
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txbPrecio.Text.Contains('.'))
                txbPrecio.Text = txbPrecio.Text.Replace('.', ',');
            try
            {
                double precioOK = Convert.ToDouble(txbPrecio.Text);
            }
            catch
            {
                args.IsValid = false;
            }

        }

        protected void txbPrecio_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
          /*  if (txbPrecio.Text.Contains("."))
            {
                //txbPrecio.Text.Replace(".", ",");
                args.IsValid = false;
            }*/
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
          /*  if (txbCantidad.Text.Contains("."))
            {
                args.IsValid = false;
            }*/
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(cbConcepto.SelectedIndex==0)
            {
                args.IsValid = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbAviso.Visible = false;
            Timer1.Enabled = false;
        }
    }
}