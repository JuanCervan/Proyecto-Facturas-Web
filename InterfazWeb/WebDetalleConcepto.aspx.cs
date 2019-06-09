using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebDetalleConcepto : System.Web.UI.Page
    {
        Concepto concepto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            concepto = (Concepto)Session["conceptoE"];
            if (!Page.IsPostBack)
            {
                if (concepto.IdConcepto != -1)
                {
                    lbCabecera.Text = "Editar Concepto de Facturación";
                    CargaConcepto();
                    btnGuardar.Text = "Actualizar";

                }
                else
                {
                    lbCabecera.Text = "Añadir Concepto de Facturación";
                    btnGuardar.Text = "Guardar";
                }
            }
        }

        private void CargaConcepto()
        {
            txbConcepto.Text = concepto.Nombre;
            txbPrecio.Text = concepto.Precio.ToString();
            // cbTipoIva.SelectedItem.Text = concepto.TipoIva;
            cbTipoIva.Text = concepto.TipoIva.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            //Timer1.Enabled = false;

            concepto = new Concepto(((Concepto)Session["conceptoE"]).IdConcepto,txbConcepto.Text,Convert.ToDouble(txbPrecio.Text),cbTipoIva.SelectedValue);//, txbConcepto.Text,Convert.ToDouble(txbImporte.Text), ddlTipoIva.Text);

            if (concepto.IdConcepto != -1)
            {
                LNyAD.ModificarConcepto(concepto);
                lbAviso.Visible = true;
                lbAviso.Text = "Concepto editado correctamente";
               
            }
            else
            {
                lbAviso.Visible = true;
                LNyAD.AddConcepto(concepto);
                lbAviso.Text = "Concepto añadido correctamente";
                txbConcepto.Text = String.Empty;
                txbPrecio.Text = String.Empty;
            }

            //Timer1.Enabled = true;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                concepto = new Concepto(((Concepto)Session["conceptoE"]).IdConcepto, txbConcepto.Text, Convert.ToDouble(txbPrecio.Text), cbTipoIva.SelectedValue);

                if (LNyAD.ConceptoPorNombre(txbConcepto.Text).Count > 0 && txbConcepto.Text == LNyAD.ConceptoPorNombre(txbConcepto.Text)[0].Nombre && LNyAD.ConceptoPorNombre(txbConcepto.Text)[0].IdConcepto != concepto.IdConcepto)
                    args.IsValid = false;
            }
            catch
            {
                CustomValidator2.IsValid = false;
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
           // lbAviso.Visible = false;
           // Timer1.Enabled = false;
        }
    }
}