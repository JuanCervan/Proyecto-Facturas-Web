using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;

namespace InterfazWeb
{
    public partial class WebConceptos : System.Web.UI.Page
    {
        int numConceptos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            if(!Page.IsPostBack)
            CargaConceptos();
        }

        private void CargaConceptos()
        {
            dgv.Columns[1].Visible = true;
            dgv.DataSource = LNyAD.CargaConceptos();
            numConceptos = LNyAD.CuentaConceptos();
            if (Session["pagC"] != null)
            {
                int pagina = (int)Session["pagC"];
                dgv.PageIndex = pagina;
            }
            dgv.DataBind();
            dgv.Columns[1].Visible = false;
            foreach (GridViewRow f in dgv.Rows)
            {
                double precio =Convert.ToDouble(f.Cells[3].Text);
                f.Cells[3].Text = precio.ToString("0.00 €");
                f.Cells[4].Text = f.Cells[4].Text + "%";
            }
            }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idConcepto = Convert.ToInt32(dgv.Rows[e.NewEditIndex].Cells[1].Text);
            Concepto conceptoEdit = LNyAD.DevuelveConcepto(idConcepto);
            Session["conceptoE"] = conceptoEdit;
            Response.Redirect("WebDetalleConcepto.aspx");
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
            lbConfirmacion.Text = "¿Desea eliminar el concepto seleccionado?";
            lbConfirmacion.Visible = mostrar;
            btnSi.Visible = mostrar;
            btnNo.Visible = mostrar;
            Panel1.Visible = mostrar;
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idConcepto = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);
            LNyAD.DeleteConcepto(idConcepto);
            CargaConceptos();
            //Response.Redirect("WebFacturas.aspx");
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
        }

        protected void btnAnyadir_Click(object sender, EventArgs e)
        {
            Concepto conceptoAdd = new Concepto();
            Session["conceptoE"] = conceptoAdd;
            Response.Redirect("WebDetalleConcepto.aspx");
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                /*if (dgv.Rows.Count == 1)
                    e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Concepto";
                else
                    e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Conceptos";*/

                if (numConceptos == 1)
                    e.Row.Cells[0].Text = numConceptos.ToString() + " Concepto";// Total";
                else
                    e.Row.Cells[0].Text = numConceptos.ToString() + " Conceptos";// Totales";

            if (dgv.PageCount > 1)
                    e.Row.Cells[2].Text = "Página " + (dgv.PageIndex + 1).ToString() + " de " + dgv.PageCount;

            }
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;//FUNCIONA!!!
            Session["pagC"] = e.NewPageIndex;
            CargaConceptos();
        }
    }
}