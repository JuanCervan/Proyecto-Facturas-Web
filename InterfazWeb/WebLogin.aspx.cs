using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebLogin : System.Web.UI.Page
    {
        Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsuarioActivo"] = null;
            Session["User"] = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            Session["UsuarioActivo"] = usu;
            Response.Redirect("WebRegistroUsuario.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LNyAD.UsuarioActivo(txbUsuario.Text).Count != 0 && LNyAD.UsuarioActivo(txbUsuario.Text)[0].Nombre.Equals(txbUsuario.Text))
            {
                if (LNyAD.UsuarioActivo(txbUsuario.Text)[0].Contraseña.Equals(txbContrasenya.Text))
                {
                    if (LNyAD.UsuarioActivo(txbUsuario.Text)[0].Acceso != 3)
                    {
                        Usuario usuActivo = new Usuario(LNyAD.UsuarioActivo(txbUsuario.Text)[0].IdUsuario, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Nombre, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Contraseña, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Acceso,LNyAD.UsuarioActivo(txbUsuario.Text)[0].Email,LNyAD.UsuarioActivo(txbUsuario.Text)[0].Pregunta,LNyAD.UsuarioActivo(txbUsuario.Text)[0].Respuesta);
                        Session["UsuarioActivo"] = usuActivo;
                        Response.Redirect("WebClientes.aspx");
                    }
                    else
                    {
                        lbAviso.Text = "El usuario " + txbUsuario.Text + " está deshabilitado, contacte con el Administrador";
                        lbAviso.Visible = true;
                        txbUsuario.Text = String.Empty;
                    }
                }else
                {
                    lbAviso.Text = "La contraseña no es válida";
                    lbAviso.Visible = true;
                }
            }
            else {

                lbAviso.Text = "El usuario " + txbUsuario.Text + " no existe en el sistema";
                lbAviso.Visible = true;
                txbUsuario.Text = String.Empty;
                // Response.Redirect("Weblogin.aspx");
            }
                
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("WebPassword.aspx");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.UsuarioActivo(txbUsuario.Text).Count != 0)
            {
                 user = new Usuario(LNyAD.UsuarioActivo(txbUsuario.Text)[0].IdUsuario, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Nombre, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Contraseña, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Acceso, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Email, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Pregunta, LNyAD.UsuarioActivo(txbUsuario.Text)[0].Respuesta);
                Session["User"] = user;
            }
            else if(LNyAD.UsuarioActivo(txbUsuario.Text).Count==0)
            {
                //user = new Usuario();
                args.IsValid = false;
            }

        }
    }
}