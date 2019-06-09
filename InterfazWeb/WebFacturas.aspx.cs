using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebFacturas : System.Web.UI.Page
    {
        Cliente clienteF;
        double sumaTotal;
        double importeTot;
        double totalAc;
        int idCliente;
        double sumaGlobal;
        double importeGlobal;
        int numFacturas;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            // if (!Page.IsPostBack)
            //{
            clienteF = (Cliente)Session["ClienteFactura"];
            idCliente = clienteF.IdCliente;
                CargaFacturas();
            
               

                /*int iDCliente = Convert.ToInt32(Session["IdCliente"]);
                TextBox1.Text = Session["IdCliente"].ToString();
                dgv.DataSource = LNyAD.CargaFacturasCliente(iDCliente);
                dgv.DataBind();
                dgv.HeaderRow.Cells[1].Visible = false;
                dgv.HeaderRow.Cells[2].Visible = false;
                foreach (GridViewRow fila in dgv.Rows)
                {
                    fila.Cells[1].Visible = false;
                    fila.Cells[2].Visible = false;
                }*/
                
            //}
        }

        private void CargaFacturas()
        {

            dgv.Columns[1].Visible = true;
            dgv.Columns[2].Visible = true;
            dgv.DataSource = LNyAD.CargaFacturasCliente(clienteF.IdCliente);
            numFacturas = LNyAD.CuentaFacturas(idCliente);
            if (Session["pagF"] != null)
            {
                int pagina = (int)Session["pagF"];
                dgv.PageIndex = pagina;
            }
            dgv.DataBind();
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;

           lbCabecera.Text = "Facturas emitidas a " + clienteF.Nombre;
            /*if (dgv.Rows.Count == 1)
                lbTotalF.Text = dgv.Rows.Count.ToString() + " Factura";
            else
                lbTotalF.Text = dgv.Rows.Count.ToString() + " Facturas";*/
            MostrarTotales();
            
        }

        private void MostrarTotales()
        {
            sumaTotal = 0;
            sumaGlobal = 0;
            foreach (GridViewRow f in dgv.Rows)
            {

                int idFactura = Convert.ToInt32(f.Cells[2].Text);

                importeTot = LNyAD.TotalFactura(idFactura);
                //importeTot = Convert.ToDouble(f.Cells["Cantidad"].Value) * Convert.ToDouble(f.Cells["Precio"].Value);
                f.Cells[5].Text =importeTot.ToString("0.00 €");
                //valorCuota = Convert.ToDouble(f.Cells["subtotal"].Value) * Convert.ToDouble(f.Cells["TipoIva"].Value) / 100;
                // f.Cells["cuotaIva"].Value = valorCuota;
                //valorTotal = Convert.ToDouble(f.Cells["subtotal"].Value) * (1 + (Convert.ToDouble(f.Cells["TipoIva"].Value) / 100));
                //f.Cells["total"].Value = valorTotal;
                //sumaSubtotal += valorSub;
                //sumaCuota += valorCuota;
                sumaTotal += importeTot;
            }
            //tlsSubtotal.Text = "Subtotal: " + sumaSubtotal.ToString() + "€";
            //tlsCuota.Text = "Cuota de IVA: " + sumaCuota.ToString() + "€";
            //tlsTotal.Text = "Total Factura: " + sumaTotal.ToString() + "€";
            //tlsFacturado.Text = "Total Facturado: " + sumaTotal.ToString() + "€";
            if(dgv.Rows.Count!=0)
            dgv.FooterRow.Cells[5].Text="Total Pág: "+sumaTotal.ToString("0.00 €");

            
        }

        protected void print(object sender, GridViewCommandEventArgs e)
        {

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "print")
            {
                int idFactura = Convert.ToInt32(dgv.Rows[fila].Cells[2].Text);
                Factura facturaPrint = LNyAD.FacturaSeleccionada(idFactura);
                Session["FacturaPrint"] = facturaPrint;
                // Response.Redirect("WebInforme1Factura.aspx");
                Response.Redirect("WebFacturaPrueba.aspx");
            }else if (e.CommandName == "det")
            {
                
                    int idFactura = Convert.ToInt32(dgv.Rows[fila].Cells[2].Text);
                    Factura facturaDet = LNyAD.DevuelveFactura(idFactura);
                    Session["FacturaDet"] = facturaDet;
                    Response.Redirect("WebDetalle.aspx");
                
            }
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            //Para calcular el subtotal
            if (e.Row.RowType == DataControlRowType.DataRow)
               
            {
                //double import = Convert.ToDouble(e.Row.Cells[6].Text);
                //double importR = Math.Round(import, 2);
                //double tIva = Convert.ToDouble(e.Row.Cells[7].Text) / 100;
                //double cuotaIva = importR * tIva;
                //double cuotaIvaR = Math.Round(cuotaIva, 2);
                //imporTotal += importR;
                //e.Row.Cells[8].Text = cuotaIvaR.ToString("0.00")+"€";
                //cuotaTotal += cuotaIvaR;
                //double total = cuotaIvaR + importR;
                //totalAc += total;
                //e.Row.Cells[9].Text = total.ToString("0.00")+"€";
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (numFacturas == 1)
                    // e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Factura";
                    e.Row.Cells[0].Text = numFacturas + " Factura";

                else
                    //e.Row.Cells[0].Text= dgv.Rows.Count.ToString() + " Facturas";
                    e.Row.Cells[0].Text = numFacturas + " Facturas";

                //  e.Row.Cells[8].Text = LNyAD.TotalImporteConIva(idCliente).ToString("0.00 €");

                //e.Row.Cells[6].Text = imporTotal.ToString("0.00") + "€";
                //e.Row.Cells[8].Text = cuotaTotal.ToString("0.00") + "€";
                //e.Row.Cells[9].Text = totalAc.ToString("0.00") + "€";
                e.Row.Cells[8].Text = "Total: " + LNyAD.TotalGlobal(idCliente).ToString("0.00 €");
                if (dgv.PageCount > 1)
                    e.Row.Cells[3].Text = "Página " + (dgv.PageIndex + 1).ToString() + " de " + dgv.PageCount;

            }


            }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idFactura = Convert.ToInt32(dgv.Rows[e.NewEditIndex].Cells[2].Text);
            Factura facturaEditar = LNyAD.DevuelveFactura(idFactura);
            Session["FacturaEdit"] = facturaEditar;
            Response.Redirect("WebDetalleFacturas.aspx");

        }

        protected void btnAnyadirFactura_Click(object sender, EventArgs e)
        {
            Factura facturaN = new Factura(-1, ((Cliente)Session["ClienteFactura"]).IdCliente, "", 0);
            if (LNyAD.CuentaFact() == 0)
            {
                facturaN.Numero = 1;
            }
            else
            {
                facturaN.Numero = LNyAD.MaxNumero();
            }
            Session["FacturaEdit"] = facturaN;
            Response.Redirect("WebDetalleFacturas.aspx");
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgv.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        private void MostrarConfirmacion(bool mostrar)
        {
            dgv.Enabled = !mostrar;
            btnAnyadirFactura.Visible = !mostrar;
            btnCancelar.Visible = !mostrar;
            //btnPrint.Visible = !mostrar;

            if (mostrar)
                lbConfirmacion.Text = "¿Desea eliminar la factura " + dgv.SelectedRow.Cells[4].Text + "?";
            lbConfirmacion.Visible = mostrar;
            btnSi.Visible = mostrar;
            btnNo.Visible = mostrar;
            Panel1.Visible = mostrar;
            
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idFactura = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[2].Text);
            LNyAD.DeleteFactura(idFactura);
            //CargaFacturas();
            Response.Redirect("WebFacturas.aspx");
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
           
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;//FUNCIONA!!!
            Session["pagF"] = e.NewPageIndex;
            CargaFacturas();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}