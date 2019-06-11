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
    
    public partial class WebPassword : System.Web.UI.Page
    {
        Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("WebLogin.aspx");
            //if (!Page.IsPostBack)
            //{

                user = (Usuario)Session["User"];
                lbCabecera.Text = "Recuperar Contraseña de " + user.Nombre;
                lbPregunta.Text = user.Pregunta;
            //}
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //Timer1.Enabled = false;
            if (LNyAD.UsuarioActivo(user.Nombre)[0].Email != txbMail.Text)
            {
                lbAviso.Text = "La dirección de correo electrónico no es correcta...";
                lbAviso.Visible = true;
                lbAviso.CssClass = "alert-danger";
                txbMail.Focus();
            }
            else if (LNyAD.UsuarioActivo(user.Nombre)[0].Respuesta != txbRespuesta.Text)
            {
                lbAviso.Text = "La respuesta a la pregunta de seguridad es incorrecta...";
                lbAviso.CssClass = "alert-danger";
                lbAviso.Visible = true;
                txbRespuesta.Focus();

            }
            else
            {

                MailMessage correo = new MailMessage();
                correo.To.Add(user.Email);
                correo.Subject = "Recuperación Contraseñas Facturas Web v0.2";
                correo.Body = "Datos de Acceso a Facturas Web v0.2\n\nUsuario: " + user.Nombre + "\nContraseña: " + user.Contrasenya;
                correo.From = new MailAddress("facturasweb@j2c.es","Facturas Web");
                SmtpClient cliente = new SmtpClient("smtp.ionos.es");
                cliente.Credentials = new System.Net.NetworkCredential("facturasweb@j2c.es", "Proyecto2019");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                try
                {
                    cliente.Send(correo);
                    lbAviso.Text = "Se ha enviado a " + user.Email + " sus datos de acceso";
                    lbAviso.CssClass = "alert-info";
                    lbAviso.Visible = true;
                    txbMail.Text = String.Empty;
                    txbRespuesta.Text = String.Empty;
                }
                catch
                {
                    lbAviso.Text = "No se ha podido enviar el correo a " + user.Email;
                    lbAviso.CssClass = "alert-danger";
                    lbAviso.Visible = true;
                    txbMail.Text = String.Empty;
                    txbRespuesta.Text = String.Empty;
                }
            }
            //Timer1.Enabled = true;
        }

        protected void txbUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (txbRespuesta.TextMode == TextBoxMode.Password)
            {
                txbRespuesta.TextMode = TextBoxMode.SingleLine;
            }
            else if (txbRespuesta.TextMode == TextBoxMode.SingleLine)
            {
                txbRespuesta.TextMode = TextBoxMode.Password;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //lbAviso.Visible = false;
            //Timer1.Enabled = false;
        }
    }
}