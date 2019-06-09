<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInforme1Factura.aspx.cs" Inherits="InterfazWeb.WebInforme1Factura" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="452px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="929px" OnPreRender="ReportViewer1_PreRender"><LocalReport ReportPath="Listado1Factura.rdlc"><DataSources><rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" /></DataSources></LocalReport></rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataFacturasConCliente" TypeName="LNegociosyADatos.DataSet1TableAdapters.FacturasTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txbIdFactura" Name="IdFactura" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    
    </div>
         <asp:TextBox ID="txbIdFactura" runat="server" Visible="False" Width="71px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebFacturas.aspx" Text="Volver" />
    </form>
</body>
</html>
