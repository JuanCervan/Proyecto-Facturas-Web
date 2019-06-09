using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class WebInformeClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] == null)
                Response.Redirect("WebLogin.aspx");

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("bin/ListaClientes.rdlc");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}