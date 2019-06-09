using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
 

namespace InterfazWeb
{
    public partial class WebDetalleClientes : System.Web.UI.Page
    {
        Cliente cliente;
       //int idUsuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            if (!Page.IsPostBack)
            {
               
                cliente = (Cliente)Session["ClienteE"];
                if (cliente.IdCliente != -1)
                {
                    CargaDatos();
                    lbClientes.Text = "Editar Cliente";
                }
                else
                {
                    DatosVacios();
                    lbClientes.Text = "Añadir Cliente";
                }

                Usuario usu = (Usuario)Session["UsuarioActivo"];
                if (usu.Acceso == 1)
                {
                    lbUsuario.Visible = true;
                    cbUser.Visible = true;
                }
                else
                {
                    lbUsuario.Visible = false;
                    cbUser.Visible = false;
                }

                int idUsuarioA;
                if (cliente.IdCliente != -1)
                    idUsuarioA = LNyAD.IdUsuarioCliente(cliente.IdCliente);
                else idUsuarioA = LNyAD.IdUsuarioMinimo();
                CargaCombo(idUsuarioA);
            }
        }

        private void DatosVacios()
        {
            txbNombre.Text = "";
            txbNif.Text = "";
            txbDireccion.Text = "";
            txbCiudad.Text = "";
            txbTelefono.Text = "";
            txbEmail.Text = "";
            txbContacto.Text = "";
            btnGuardar.Text = "Guardar";
        }

        private void CargaDatos()
        {
                txbNombre.Text = cliente.Nombre;
                txbNif.Text = cliente.Cif;
                txbDireccion.Text = cliente.Direccion;
                txbCiudad.Text = cliente.Ciudad;
                txbTelefono.Text = cliente.Telefono;
                txbEmail.Text = cliente.Email;
                txbContacto.Text = cliente.Persona;
           
            btnGuardar.Text = "Actualizar";
        }

        private void CargaCombo(int idUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = LNyAD.CargaComboUsuarios();
            cbUser.DataSource = listaUsuarios;
            cbUser.DataValueField = "IdUsuario";
            cbUser.DataTextField = "Nombre";
            cbUser.DataBind();
            if (cliente.IdCliente != -1)
                cbUser.SelectedValue = LNyAD.IdUsuarioCliente(cliente.IdCliente).ToString();
            else cbUser.SelectedValue = idUsuario.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Usuario usu = (Usuario)Session["UsuarioActivo"];
            int idUsuario = usu.IdUsuario;
            //Timer1.Enabled = false;
            int idCliente = ((Cliente)Session["ClienteE"]).IdCliente;
            if(idCliente!=-1)
            cliente = new Cliente(idCliente,txbNombre.Text,txbNif.Text,txbDireccion.Text,txbCiudad.Text,txbTelefono.Text,txbEmail.Text,txbContacto.Text,Convert.ToInt32(cbUser.SelectedValue));
            else cliente = new Cliente(idCliente, txbNombre.Text, txbNif.Text, txbDireccion.Text, txbCiudad.Text, txbTelefono.Text, txbEmail.Text, txbContacto.Text,usu.IdUsuario);

            if (cliente.IdCliente == -1)
            {

                
                lbAviso.Visible = true;
                lbAviso.Text = "Cliente " + txbNombre.Text + " añadido correctamente";
                LNyAD.AddCliente(cliente);
                txbNombre.Text = "";
                txbTelefono.Text = "";
                txbNif.Text = "";
                txbCiudad.Text = "";
                txbContacto.Text = "";
                txbDireccion.Text = "";
                txbEmail.Text = "";


            }
            else
            {
                
                lbAviso.Visible = true;
                lbAviso.Text = "Cliente " + txbNombre.Text + " editado correctamente";
                LNyAD.ModificarCliente(cliente);
            }

            btnCancelar.Text = "Volver";
           // Timer1.Enabled = true;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Usuario usu = (Usuario)Session["UsuarioActivo"];
            int idUsuario = usu.IdUsuario;
            cliente = new Cliente(((Cliente)Session["ClienteE"]).IdCliente, txbNombre.Text, txbNif.Text, txbDireccion.Text, txbCiudad.Text, txbTelefono.Text, txbEmail.Text, txbContacto.Text,idUsuario);

            if (LNyAD.ClientePorNombre(txbNombre.Text).Count > 0 && txbNombre.Text == LNyAD.ClientePorNombre(txbNombre.Text)[0].Nombre&&LNyAD.ClientePorNombre(txbNombre.Text)[0].IdCliente!=cliente.IdCliente)
                args.IsValid = false;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Usuario usu = (Usuario)Session["UsuarioActivo"];
            int idUsuario = usu.IdUsuario;
            cliente = new Cliente(((Cliente)Session["ClienteE"]).IdCliente, txbNombre.Text, txbNif.Text, txbDireccion.Text, txbCiudad.Text, txbTelefono.Text, txbEmail.Text, txbContacto.Text,idUsuario);

            if (LNyAD.BuscaClienteNif(txbNif.Text).Count > 0&&txbNif.Text==LNyAD.BuscaClienteNif(txbNif.Text)[0].Cif&&LNyAD.BuscaClienteNif(txbNif.Text)[0].IdCliente!=cliente.IdCliente)
            {
                    args.IsValid = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
           /* lbAviso.Visible = false;
            Timer1.Enabled = false;*/
        }
    }
}