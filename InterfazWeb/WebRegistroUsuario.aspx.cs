using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
using System.Net.Mail;

namespace InterfazWeb
{
    public partial class WebRegistroUsuario : System.Web.UI.Page
    {
        Usuario usuarioActivo;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioActivo"] == null)
                    Response.Redirect("WebLogin.aspx");//Seguridad

                usuarioActivo = (Usuario)Session["UsuarioActivo"];

                if (usuarioActivo.IdUsuario == -1)
                {
                    btnGuardar.Text = "Guardar";
                    lbCabecera.Text = "Registrar Usuario";
                    
                    txbContrasenya.Attributes["type"] = "password";
                    txbContrasenyaRep.Attributes["type"] = "password";
                }
                
            }  
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Timer1.Enabled = false;
               // usuNuevo = new Usuario(-1, txbNombre.Text, txbContrasenya.Text, 0, "Deshabilitado", txbEmail.Text, txbPregunta.Text, txbRespuesta.Text);
                //if (btnGuardar.Text=="Guardar") {
                    usuarioActivo = new Usuario(-1, txbNombre.Text, txbContrasenya.Text,3, txbEmail.Text, txbPregunta.Text, txbRespuesta.Text);
                    LNyAD.AddUsuario(usuarioActivo);
                    lbAviso.Text = "El usuario " + usuarioActivo.Nombre + " ha sido añadido correctamente, recibirá un email del Administrador cuando sea habilitado";
                    lbAviso.Visible = true;
                    txbNombre.Text = String.Empty;
                    txbContrasenya.Text = String.Empty;
                    txbContrasenya.TextMode = TextBoxMode.SingleLine;
                    txbContrasenya.Attributes["type"] = "password";
                    txbContrasenyaRep.Text = String.Empty;
                    txbContrasenyaRep.TextMode = TextBoxMode.SingleLine;
                    txbContrasenyaRep.Attributes["type"] = "password";
                    txbEmail.Text = String.Empty;
                    txbPregunta.Text = String.Empty;
                    txbRespuesta.Text = String.Empty;

                    btnCancelar.Text = "Volver";
                    //btnGuardar.Enabled = false;
                    MailMessage correo = new MailMessage();
                    correo.To.Add("jcervan@gmx.es");
                    correo.Subject = "Registro de nuevo Usuario en Facturas Web v0.2";
                    correo.Body = "Se ha registrado un nuevo Usuario:\n\nUsuario: " + usuarioActivo.Nombre;
                    correo.From = new MailAddress("facturasweb@j2c.es","Facturas Web");
                    SmtpClient cliente = new SmtpClient("smtp.ionos.es");
                    cliente.Credentials = new System.Net.NetworkCredential("facturasweb@j2c.es", "Proyecto2019@");
                    cliente.Port = 587;
                    cliente.EnableSsl = true;
                    try
                    {
                        cliente.Send(correo);
                        //lbAviso.Text = "Se ha enviado a " + user.Email + " sus datos de acceso, compruebe su carpeta de spam ó correo no deseado si no recibe el mail";
                        //lbAviso.CssClass = "alert-info";
                        //lbAviso.Visible = true;


                    }
                    catch { }
                Timer1.Enabled = true;
              


            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.CheckUser(txbNombre.Text))
                args.IsValid = false;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebLogin.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbAviso.Visible = false;
            Timer1.Enabled = false;
        }
    }
}