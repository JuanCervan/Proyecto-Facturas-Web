using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;

namespace InterfazWeb
{
    public partial class WebUsuarios : System.Web.UI.Page
    {
        int numUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario seguridad = (Usuario)Session["UsuarioActivo"];
            if(seguridad==null)
                Response.Redirect("WebLogin.aspx");
            else if (seguridad.Acceso!= 1)
                Response.Redirect("WebLogin.aspx");
            int numAdm = LNyAD.NumeroAdm();//esta consulta me devuelve el numero de Adm
            Session["NumAdmin"] = numAdm;
            if (!Page.IsPostBack)
            {
                CargaUsuarios();
            }

        }

        private void CargaUsuarios()
        {
            dgv.Columns[3].Visible = true;
            dgv.Columns[4].Visible = true;
            dgv.Columns[5].Visible = true;
            dgv.DataSource = LNyAD.CargaUsuarios();
            numUsuarios = LNyAD.NumeroUsuarios();
            if (Session["pagU"] != null)
            {
                int pagina = (int)Session["pagU"];
                dgv.PageIndex = pagina;
            }
            dgv.DataBind();
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = true;
            dgv.Columns[5].Visible = false;
            
            //oculto cabeceras
            //dgv.HeaderRow.Cells[3].Visible = false;
            //dgv.HeaderRow.Cells[4].Visible = false;
            //oculto celdas
           /* foreach(GridViewRow fila in dgv.Rows)
            {
                fila.Cells[3].Visible = false;
                fila.Cells[4].Visible = false;
            }*/

            //lbCabecera.Text = dgv.Rows.Count + " Usuarios";
        }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgv.Rows[e.NewEditIndex].Cells[1].Text);
            Usuario usuarioE = LNyAD.DevuelveUsuario(idUsuario);
            Session["UsuarioEditar"] = usuarioE;
            Response.Redirect("WebDetalleUsuarios.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UsuarioEditar"] = new Usuario(-1, "", "", 3, "","","");
            Response.Redirect("WebDetalleUsuarios.aspx");
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgv.SelectedIndex = e.RowIndex;
            int numAdm = LNyAD.NumeroAdm();//esta consulta me devuelve el numero de Adm
            lbAviso.Visible = false;
            if (dgv.Rows[e.RowIndex].Cells[4].Text == "1")
            {
                lbAviso.Text = numAdm.ToString();

                if (numAdm !=1) {
                    MostrarConfirmacion(true);
                }
                else
                {
                    lbAviso.Text="No puede eliminar al usuario "+dgv.Rows[e.RowIndex].Cells[2].Text+", es el único Administrador";
                    lbAviso.Visible = true;
                }
            }

            else
            MostrarConfirmacion(true);
        }

        private void MostrarConfirmacion(bool mostrar)
        {
            dgv.Enabled = !mostrar;
            btnNuevo.Visible = !mostrar;
            btnCancelar.Visible = !mostrar;
            btnPrint.Visible = !mostrar;

            if (mostrar)
            lbConfirmacion.Text = "¿Desea eliminar al usuario " + dgv.SelectedRow.Cells[2].Text + "?";
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
            
            int idUsuario = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);
            LNyAD.DeleteUsuario(idUsuario);
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
            CargaUsuarios();
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow f in dgv.Rows)
            {
                f.Cells[6].Text = LNyAD.TipoUsuario(Convert.ToInt32(f.Cells[5].Text));
            }


                if (e.Row.RowType == DataControlRowType.Footer)
            {

                //e.Row.Cells[2].Text = "Usuario: " + usuarioActivo.Nombre;
                /* if (dgv.Rows.Count == 1)
                     e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Usuario";
                 else
                     e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Usuarios";*/
                if (numUsuarios == 1)
                    e.Row.Cells[0].Text = numUsuarios.ToString() + " Usuario";// Total";
                else
                    e.Row.Cells[0].Text = numUsuarios.ToString() + " Usuarios";// Totales";


                if (dgv.PageCount > 1)
                    e.Row.Cells[1].Text = "Página " + (dgv.PageIndex + 1).ToString() + " de " + dgv.PageCount;

            }
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;//FUNCIONA!!!
            Session["pagU"] = e.NewPageIndex;
            CargaUsuarios();
        }
    }
}