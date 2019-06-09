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
    public partial class WebDetalleUsuarios : System.Web.UI.Page
    {
        Usuario usu;
        //string tipoActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");
            if (!Page.IsPostBack)
            {
                CargaComboTipo();
                usu = (Usuario)Session["UsuarioEditar"];
                // tipoActual = usu.Tipo;//PRUEBA
                // tipoActual = LNyAD.TipoUsuario(usu.Acceso);
                // ddlTipo.SelectedValue = usu.Acceso.ToString();

                // Session["tipoAct"] = tipoActual;
                if (usu.IdUsuario != -1)
                {
                    CargaDatos();
                    btnGuardar.Text = "Actualizar";
                }
                else
                {
                    DatosVacios();
                    btnGuardar.Text = "Guardar";
                }
                
            }
        }

        private void DatosVacios()
        {
            txbNombre.Text = "";
            txbContrasenya.TextMode = TextBoxMode.Password;
            txbContrasenyaRep.TextMode = TextBoxMode.Password;
            //ddlTipo.Text = "Normal";
            txbEmail.Text = "";
            CargaComboTipo();

        }

        private void CargaComboTipo()
        {
            ddlTipo.DataSource = LNyAD.CargaAccesos();
            ddlTipo.DataValueField = "IdAcceso";
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataBind();
        }

        private void CargaDatos()
        {
            int numAdm = Convert.ToInt32(Session["NumAdmin"]);
            txbNombre.Text = usu.Nombre;
            txbContrasenya.Text = usu.Contrasenya;
            txbContrasenya.Attributes["type"] = "password";
            txbContrasenyaRep.Text = usu.Contrasenya;
            txbContrasenyaRep.Attributes["type"] = "password";
            //ddlTipo.Text = usu.Tipo;
            //string tipo = LNyAD.TipoUsuario(usu.Acceso);
            //ddlTipo.Text = tipo;
            ddlTipo.SelectedValue = usu.Acceso.ToString();
            string tipo = ddlTipo.Text;
            Session["tipoAct"] = tipo;
            txbEmail.Text = usu.Email;
            if (tipo=="Administrador"&&numAdm == 1)
                ddlTipo.Enabled = false;
            else
                ddlTipo.Enabled = true;

           
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
           // Timer1.Enabled = false;
            int acc=3;
            //if (ddlTipo.Text == "Administrador")
            if(Convert.ToInt32(ddlTipo.SelectedValue)==1)
                acc = 1;
           // else if (ddlTipo.Text == "Normal")
           else if(Convert.ToInt32(ddlTipo.SelectedValue) == 2)
                acc = 2;
           // else if (ddlTipo.Text == "Deshabilitado")
           else if(Convert.ToInt32(ddlTipo.SelectedValue) == 3)
                acc = 3;
            usu = new Usuario(((Usuario)Session["UsuarioEditar"]).IdUsuario, txbNombre.Text, txbContrasenya.Text, acc,txbEmail.Text, ((Usuario)Session["UsuarioEditar"]).Pregunta, ((Usuario)Session["UsuarioEditar"]).Respuesta);//RECORDAR
            if (usu.IdUsuario == -1)
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Usuario " + txbNombre.Text + " añadido correctamente";
                LNyAD.AddUsuario(usu);
                txbNombre.Text = String.Empty;
                txbEmail.Text = String.Empty;
               
            }
            else
            {
                lbAviso.Visible = true;
                lbAviso.Text = "Usuario " + txbNombre.Text + " editado correctamente";
                LNyAD.ModificarUsuario(usu);
                
            }
            String tipoAct = (string)Session["tipoAct"];
            string tipo = LNyAD.TipoUsuario(usu.Acceso);
            if (tipoAct == "3" && tipo != "Deshabilitado")
            {
                MailMessage correo = new MailMessage();
                correo.To.Add(usu.Email);
                correo.Subject = "Cambio de Tipo de Usuario en Facturas Web v0.2";
                correo.Body = "Estimado Usuario "+usu.Nombre+", ya ha sido habilitado. Puede acceder a la aplicación.\n\nGracias por usar Facturas Web v0.2";
                correo.From = new MailAddress("facturasweb@j2c.es","Facturas Web");
                SmtpClient cliente = new SmtpClient("smtp.ionos.es");
                cliente.Credentials = new System.Net.NetworkCredential("facturasweb@j2c.es", "Proyecto2019@");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                try
                {
                    cliente.Send(correo);
                    lbAviso.Text = "Enviado a " + usu.Email + " el nuevo Tipo de acceso";
                    lbAviso.CssClass = "alert-info";
                    lbAviso.Visible = true;

                    
                }
                catch
                {
                    lbAviso.Text = "Usuario "+usu.Nombre+" editado correctamente. No se ha podido enviar el correo a " + usu.Email + ",la dirección de Email es incorrecta";
                    lbAviso.CssClass = "alert-danger";
                    lbAviso.Visible = true;
                    
                }
            }
            btnCancelar.Text = "Volver";
            //Timer1.Enabled = true;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            byte acc = 0;
            if (ddlTipo.Text == "Administrador")
                acc = 1;
            else if (ddlTipo.Text == "Normal")
                acc = 2;
            else if (ddlTipo.Text == "Deshabilitado")
                acc = 0;
            usu = new Usuario(((Usuario)Session["UsuarioEditar"]).IdUsuario, txbNombre.Text, txbContrasenya.Text, acc,txbEmail.Text, ((Usuario)Session["UsuarioEditar"]).Pregunta, ((Usuario)Session["UsuarioEditar"]).Respuesta);//RECORDAR

            if (LNyAD.UsuarioActivo(txbNombre.Text).Count > 0&&txbNombre.Text==LNyAD.UsuarioActivo(txbNombre.Text)[0].Nombre&&LNyAD.UsuarioActivo(txbNombre.Text)[0].IdUsuario!=usu.IdUsuario)
            {
                    args.IsValid = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //lbAviso.Visible = false;
            //Timer1.Enabled = false;
        }
    }
}