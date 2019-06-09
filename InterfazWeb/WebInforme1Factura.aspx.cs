using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.Entidades;
using Microsoft.Reporting.WebForms;

namespace InterfazWeb
{
    public partial class WebInforme1Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            Factura fact = (Factura)Session["FacturaPrint"];
            int idFactura = fact.IdFactura;
            txbIdFactura.Text = idFactura.ToString();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("bin/1Factura.rdlc");
        }

       

        
    }
}