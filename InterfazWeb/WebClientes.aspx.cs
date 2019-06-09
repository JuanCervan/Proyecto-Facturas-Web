using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;


namespace InterfazWeb
{
    public partial class WebClientes : System.Web.UI.Page
    {
        Usuario usuarioActivo;
        Usuario usuEdit;
        int numClientes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            if (!Page.IsPostBack)
            {
                // if (Session["UsarioActivo"] == null)
                //Response.Redirect("WebLogin.aspx");

                usuEdit = (Usuario)Session["UsuarioActivo"];
                CargaUsuarios();
               
                usuarioActivo = (Usuario)Session["UsuarioActivo"];
                if (usuarioActivo.Acceso == 1)
                {
                    btnUsuarios.Visible = true;
                    dgv.Columns[12].Visible = true;
                    lbMostrar.Visible = true;
                    ddlUsuario.Visible = true;
                }
                else
                {
                    dgv.Columns[12].Visible = false;
                    btnUsuarios.Visible = false;
                    lbMostrar.Visible = false;
                    ddlUsuario.Visible = false;
                }
               
               
            }
            CargaClientes();
        }

        private void CargaUsuarios()//ok
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = LNyAD.CargaComboUsuarios();
            List<Usuario> listaTodosUsuarios = new List<Usuario>(listaUsuarios);
            listaTodosUsuarios.Insert(0, new Usuario(0, "Todos los Usuarios","",0,"","",""));
            listaTodosUsuarios.Add(new Usuario(-2, "Sin Asignar", "", 0, "", "", ""));
            ddlUsuario.DataSource = listaTodosUsuarios;
            ddlUsuario.DataTextField = "Nombre";
            ddlUsuario.DataValueField = "IdUsuario";
            ddlUsuario.DataBind();
        }

        private void CargaClientes()
        {
            
            dgv.Columns[1].Visible = true;
            dgv.Columns[2].Visible = true;
            usuarioActivo = (Usuario)Session["UsuarioActivo"];
            if (usuarioActivo.Acceso == 1)
            {
                int idDDL = Convert.ToInt32(ddlUsuario.SelectedValue);
                dgv.DataSource = LNyAD.CargaClientes(idDDL);
                //if (idDDL != 0)
                if(idDDL>0)
                {
                    numClientes = LNyAD.CuentaClientes(idDDL);
                    dgv.Columns[12].Visible = false; ;
                }
                else if(idDDL==0)
                {
                    numClientes = LNyAD.CuentaTodosClientes();
                    dgv.Columns[12].Visible = true;
                }
                else
                {
                    dgv.DataSource = LNyAD.SinAsignar();
                    numClientes =LNyAD.NumClientesSinAsignar();
                    dgv.Columns[12].Visible = false;
                
                }
            }
            else
            {
                dgv.DataSource = LNyAD.CargaClientesUsuario(usuarioActivo.IdUsuario);
                //dgv.DataSource = LNyAD.CargaClientesUsuario(Convert.ToInt32(ddlUsuario.SelectedValue));
                 numClientes = LNyAD.CuentaClientesUsuario(usuarioActivo.IdUsuario);
                //numClientes = LNyAD.CuentaClientesUsuario(Convert.ToInt32(ddlUsuario.SelectedValue));
            }
            if (Session["pag"] != null)
                {
                int pagina = (int)Session["pag"];
                dgv.PageIndex = pagina;
                }
            if(usuarioActivo.Acceso==1)
            dgv.EmptyDataText = "No existen clientes para el usuario seleccionado";
            else
                dgv.EmptyDataText = "No existen clientes para el usuario "+usuarioActivo.Nombre;
            dgv.DataBind();
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFacturas.aspx");
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
            btnUsuarios.Visible = !mostrar;
            btnCerrar.Visible = !mostrar;
            txbBuscar.Visible = !mostrar;
            btnBuscar.Visible = !mostrar;
            btnTodos.Visible = !mostrar;
            btnPrint.Visible = !mostrar;
            btnPerfil.Visible = !mostrar;
            if (usuarioActivo.Acceso == 1)
            {
                lbMostrar.Visible = !mostrar;
                ddlUsuario.Visible = !mostrar;
            }
            else
            {
                lbMostrar.Visible = false;
                ddlUsuario.Visible = false;
            }


            if (mostrar)
            {
                lbConfirmacion.Text = "¿Desea eliminar al cliente " + dgv.SelectedRow.Cells[3].Text + " y todas sus facturas?";
            }
            lbConfirmacion.Visible = mostrar;
            btnSi.Visible = mostrar;
            btnNo.Visible = mostrar;
            Panel4.Visible = mostrar;
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebUsuarios.aspx");
        }

        protected void ver(object sender, GridViewCommandEventArgs e)
        {

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ver")
            {
                int idCliente = Convert.ToInt32(dgv.Rows[fila].Cells[1].Text);
                Cliente clienteFactura = LNyAD.DevuelveCliente(idCliente);
                Session["ClienteFactura"] = clienteFactura;
                Response.Redirect("WebFacturas.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebFacturas.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idCliente = Convert.ToInt32(dgv.Rows[e.NewEditIndex].Cells[1].Text);
            Cliente clienteEdit = LNyAD.DevuelveCliente(idCliente);
            Session["ClienteE"] = clienteEdit;
            Response.Redirect("WebDetalleClientes.aspx");
        }

        protected void btnAnyadir_Click(object sender, EventArgs e)
        {
            Cliente clienteN = new Cliente(-1, "", "", "", "", "", "", "",0);
            Session["ClienteE"] = clienteN;
            Response.Redirect("WebDetalleClientes.aspx");
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);
            LNyAD.BorrarCliente(idCliente);
            MostrarConfirmacion(false);
            CargaClientes();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            usuarioActivo = (Usuario)Session["UsuarioActivo"];
            foreach (GridViewRow u in dgv.Rows)
            {
                try
                {
                    u.Cells[12].Text = LNyAD.NombreUsuario(Convert.ToInt32(u.Cells[2].Text));
                }
                catch
                {
                    u.Cells[12].Text = "No asignado";
                    u.Cells[12].ForeColor = System.Drawing.Color.Red;
                }
            }
           
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               
                e.Row.Cells[4].Text = "Usuario: " + usuarioActivo.Nombre;
                /* if (dgv.Rows.Count == 1)
                 {
                     e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Cliente";

                 }
                 else
                 {
                     e.Row.Cells[0].Text = dgv.Rows.Count.ToString() + " Clientes";

                 }*/
                if (numClientes == 1)
                    e.Row.Cells[0].Text = numClientes.ToString() + " Cliente";// Total";
                else
                    e.Row.Cells[0].Text = numClientes.ToString() + " Clientes";// Totales";

                if(dgv.PageCount>1)
                e.Row.Cells[3].Text = "Página " + (dgv.PageIndex+1).ToString() + " de " + dgv.PageCount;//FUNCIONA
            }

           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txbBuscar.Text != "")
            {
                dgv.Columns[1].Visible = true;
                dgv.DataSource=LNyAD.BuscaClientes(txbBuscar.Text);
                dgv.DataBind();
                dgv.Columns[1].Visible = false;
                lbBuscar.Visible = false;
                if (dgv.Rows.Count == 0)
                     {
                    CargaClientes();
                    lbBuscar.Visible = true;
                     }
            }
            else
                {
                lbBuscar.Visible = false;
                }
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            txbBuscar.Text = "";
            lbBuscar.Visible = false;
            CargaClientes();
        }

        protected void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            lbBuscar.Visible = false;
        }

        protected void btnCerrar_Click1(object sender, EventArgs e)
        {
            //Session["UsuarioActivo"] = null;
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;//FUNCIONA!!!
            Session["pag"] = e.NewPageIndex;
            CargaClientes();
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
          // int idUsuario=((Usuario)Session["UsuarioActivo"]).IdUsuario;
            //usuEdit = LNyAD.DevuelveUsuario(idUsuario);
          // Session["UsuarioEditPerfil"] = usuEdit;
            Response.Redirect("WebPerfilUsuario.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            /*int pag = dgv.PageIndex;
            Session["pag"] = pag;
            Response.Redirect("WebInformeClientes.aspx");*/
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
                  
        }
    }
}