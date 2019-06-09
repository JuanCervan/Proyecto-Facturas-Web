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
    public partial class WebFacturaPRUEBA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            Cliente client = (Cliente)Session["ClienteFactura"];
            Factura factPrint = (Factura)Session["FacturaPrint"];
            int idFactura =factPrint.IdFactura;
            int numFact = factPrint.Numero;
            string nombreCli = client.Nombre;
            txbIdFactura.Text = idFactura.ToString();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("bin/1Factura.rdlc");
            ReportViewer1.LocalReport.DisplayName = "Factura " + numFact.ToString()+" "+nombreCli;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        private void SuppressExportButton(ReportViewer rv, string optionToSuppress)
        {
            var reList = rv.LocalReport.ListRenderingExtensions();
            foreach (var re in reList)
            {
                if (re.Name.Trim().ToUpper() == optionToSuppress.Trim().ToUpper()) // Hide the option
                {
                    re.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance).SetValue(re, false);
                }
            }
        }

        protected void ReportViewer1_PreRender(object sender, EventArgs e)
        {
            SuppressExportButton(ReportViewer1, "PDF");
        }
    }
}