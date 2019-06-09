using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebDetalle : System.Web.UI.Page
    {
        Factura facturaDet;
        Cliente clienteDet;
        double sumaSubtotal;
        double sumaCuota;
        double sumaTotal;
        double valorSub;
        double valorCuota;
        double valorTotal;
        int numLineas;
        int idFactura;
        string subTotalGlobal;
        string cuotaIvaGlobal;
        string totalGlobal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            facturaDet = (Factura)Session["FacturaDet"];
            clienteDet = (Cliente)Session["ClienteFactura"];
            idFactura = facturaDet.IdFactura;
            CargaLineas();
            CargaGlobal();
        }

        private void CargaGlobal()
        {
            //idFactura = facturaDet.IdFactura;
            subTotalGlobal = LNyAD.SubTotalGlobal(idFactura);
            cuotaIvaGlobal = LNyAD.CuotaIvaGlobal(idFactura);
            totalGlobal = LNyAD.TotalGlobalLineas(idFactura);
            /*if (numLineas > 4)
            {
                lbGlobal.Visible = true;
                lbGlobal.Text = "Subtotal: " + subTotalGlobal + " Cuota Iva: " + cuotaIvaGlobal + " Total: " + totalGlobal;
            }
            else lbGlobal.Visible = false;*/
        }

        private void CargaLineas()
        {
            dgv.Columns[1].Visible = true;
            dgv.Columns[2].Visible = true;
            dgv.DataSource = LNyAD.CargaLineasFactura(facturaDet.IdFactura);
            numLineas = LNyAD.CuentaLineas(idFactura);
            CargaGlobal();
            if (Session["pagL"] != null)
            {
                int pagina = (int)Session["pagL"];
                dgv.PageIndex = pagina;
            }
            dgv.DataBind();
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            MostrarCalculos();
            


            lbCabecera.Text = "Detalle de la Factura " + facturaDet.Numero + " de " + clienteDet.Nombre;
        }

        private void MostrarCalculos()
        {
            sumaSubtotal = 0;
            sumaCuota = 0;
            sumaTotal = 0;
            foreach (GridViewRow f in dgv.Rows)
            {
                int quitar = f.Cells[5].Text.Length;
                
                valorSub = Convert.ToDouble(f.Cells[4].Text) * Convert.ToDouble(f.Cells[5].Text.Substring(0, quitar- 1));
                f.Cells[6].Text = valorSub.ToString();
                valorCuota = Convert.ToDouble(f.Cells[6].Text) * Convert.ToDouble(f.Cells[7].Text) / 100;
                f.Cells[8].Text = valorCuota.ToString();
                valorTotal = Convert.ToDouble(f.Cells[6].Text) * (1 + (Convert.ToDouble(f.Cells[7].Text) / 100));
                f.Cells[6].Text = valorSub.ToString("0.00 €");
                f.Cells[8].Text = valorCuota.ToString("0.00 €");
                f.Cells[9].Text = valorTotal.ToString("0.00 €");
                f.Cells[7].Text = f.Cells[7].Text + "%";


                sumaSubtotal += valorSub;
                sumaCuota += valorCuota;
                sumaTotal += valorTotal;
            }
            //tlsSubtotal.Text = "Subtotal: " + sumaSubtotal.ToString() + "€";
            //tlsCuota.Text = "Cuota de IVA: " + sumaCuota.ToString() + "€";
            //tlsTotal.Text = "Total Factura: " + sumaTotal.ToString() + "€";
            if (dgv.Rows.Count > 0)
            {
                dgv.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                dgv.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                dgv.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                dgv.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                /* if (dgv.Rows.Count == 1)
                     dgv.FooterRow.Cells[0].Text = dgv.Rows.Count.ToString() + " Línea";
                 else
                     dgv.FooterRow.Cells[0].Text = dgv.Rows.Count.ToString() + " Líneas";*/

                if (numLineas == 1)
                    dgv.FooterRow.Cells[0].Text = numLineas + " Línea";
                else
                    dgv.FooterRow.Cells[0].Text = numLineas + " Líneas";

                if (numLineas > 4)
                {
                    dgv.FooterRow.Cells[5].Text = "Total Pág.:" + "<br>Total:";
                    dgv.FooterRow.Cells[6].Text = sumaSubtotal.ToString("0.00 €") + "<br>" + subTotalGlobal;
                    dgv.FooterRow.Cells[8].Text = sumaCuota.ToString("0.00 €") + "<br>" + cuotaIvaGlobal;
                    dgv.FooterRow.Cells[9].Text = sumaTotal.ToString("0.00 €") + "<br>" + totalGlobal;
                }
                else
                {
                    dgv.FooterRow.Cells[5].Text = "Total:";
                    dgv.FooterRow.Cells[6].Text = sumaSubtotal.ToString("0.00 €");
                    dgv.FooterRow.Cells[8].Text = sumaCuota.ToString("0.00 €");
                    dgv.FooterRow.Cells[9].Text = sumaTotal.ToString("0.00 €");

                }

                //dgv.TopPagerRow.Cells[0].Text = "Prueba"; INVESTIGAR
            }





        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgv.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        private void MostrarConfirmacion(bool mostrar)
        {
            dgv.Enabled = !mostrar;
            btnAnyadir.Visible = !mostrar;
            btnVolver.Visible = !mostrar;
            //btnPrint.Visible = !mostrar;

            if (mostrar)
                lbConfirmacion.Text = "¿Desea eliminar la línea seleccionada?";
            lbConfirmacion.Visible = mostrar;
            btnSi.Visible = mostrar;
            btnNo.Visible = mostrar;
            Panel1.Visible = mostrar;
            CargaGlobal();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idLinea = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[2].Text);
            LNyAD.DeleteLinea(idLinea);
            CargaLineas();
            //Response.Redirect("WebFacturas.aspx");
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
        }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idLinea = Convert.ToInt32(dgv.Rows[e.NewEditIndex].Cells[2].Text);
            Linea lineaEdit = LNyAD.DevuelveLinea(idLinea);
            Session["lineaE"] = lineaEdit;
            Response.Redirect("WebDetalleLinea.aspx");
        }

        protected void btnAnyadir_Click(object sender, EventArgs e)
        {
            Linea lineaN = new Linea(-1, facturaDet.IdFactura, "", 0, 0, 0);
            Session["lineaE"] = lineaN;
            Response.Redirect("WebDetalleLinea.aspx");
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (dgv.PageCount > 1)
                    e.Row.Cells[3].Text = "Página " + (dgv.PageIndex + 1).ToString() + " de " + dgv.PageCount;
            }
        }
        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;//FUNCIONA!!!
            Session["pagL"] = e.NewPageIndex;
            CargaLineas();
        }
    }

}