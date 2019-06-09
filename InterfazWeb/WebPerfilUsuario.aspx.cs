using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;

namespace InterfazWeb
{
    public partial class WebPerfilUsuario : System.Web.UI.Page
    {
        Usuario usuEdit;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            if (!Page.IsPostBack)
            {

                int idUsuario = ((Usuario)Session["UsuarioActivo"]).IdUsuario;
                CargaDatos(idUsuario);
            }
        }



        private void CargaDatos(int idUsuario)
        {
            
           // usuEdit = new Usuario(LNyAD.UsuarioPerfil(idUsuario)[0].IdUsuario, LNyAD.UsuarioPerfil(idUsuario)[0].Nombre, LNyAD.UsuarioPerfil(idUsuario)[0].Contraseña, LNyAD.UsuarioPerfil(idUsuario)[0].Acceso, LNyAD.UsuarioPerfil(idUsuario)[0].Tipo, LNyAD.UsuarioPerfil(idUsuario)[0].Email, LNyAD.UsuarioPerfil(idUsuario)[0].Pregunta, LNyAD.UsuarioPerfil(idUsuario)[0].Respuesta);
            lbCabecera.Text = "Perfil de Usuario " + LNyAD.UsuarioPerfil(idUsuario)[0].Nombre;
            txbNombre.Text = LNyAD.UsuarioPerfil(idUsuario)[0].Nombre;
            txbContrasenya.Text = LNyAD.UsuarioPerfil(idUsuario)[0].Contraseña;
            txbContrasenya.Attributes["type"] = "password";
            txbContrasenyaRep.Text= LNyAD.UsuarioPerfil(idUsuario)[0].Contraseña;
            txbContrasenyaRep.Attributes["type"] = "password";
            txbEmail.Text = LNyAD.UsuarioPerfil(idUsuario)[0].Email;
            txbPregunta.Text = LNyAD.UsuarioPerfil(idUsuario)[0].Pregunta;
            txbRespuesta.Text=LNyAD.UsuarioPerfil(idUsuario)[0].Respuesta;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (!Page.IsValid)
            //  return;
            Timer1.Enabled = false;
            usuEdit = new Usuario(((Usuario)Session["UsuarioActivo"]).IdUsuario, txbNombre.Text, txbContrasenya.Text, ((Usuario)Session["UsuarioActivo"]).Acceso, txbEmail.Text, txbPregunta.Text, txbRespuesta.Text);
            lbAviso.Visible = true;
            lbAviso.Text = "Usuario " + txbNombre.Text + " editado correctamente";
            LNyAD.ModificarUsuarioPerfil(usuEdit);
            //Session["UsuarioActivo"] = usuEdit;
            btnCancelar.Text = "Volver";
            Timer1.Enabled = true;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
           /* byte acc = 0;
            if (ddlTipo.Text == "Administrador")
                acc = 1;
            else if (ddlTipo.Text == "Normal")
                acc = 2;
            else if (ddlTipo.Text == "Deshabilitado")
                acc = 0;*/
            Usuario usuC = new Usuario(((Usuario)Session["UsuarioActivo"]).IdUsuario, txbNombre.Text, txbContrasenya.Text, ((Usuario)Session["UsuarioActivo"]).Acceso,txbEmail.Text,txbPregunta.Text,txbRespuesta.Text);//RECORDAR

            if (LNyAD.UsuarioActivo(txbNombre.Text).Count > 0&&txbNombre.Text==LNyAD.UsuarioActivo(txbNombre.Text)[0].Nombre&&LNyAD.UsuarioActivo(txbNombre.Text)[0].IdUsuario!=usuC.IdUsuario)
            {

                //if (txbNombre.Text == LNyAD.UsuarioActivo(txbNombre.Text)[0].Nombre)
                //{
                    args.IsValid = false;
                //}
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbAviso.Visible = false;
            Timer1.Enabled = false;
        }
    }
}