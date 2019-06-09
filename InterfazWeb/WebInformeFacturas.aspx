<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInformeFacturas.aspx.cs" Inherits="InterfazWeb.WebInformeFacturas" %>

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
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="493px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="994px"><LocalReport ReportPath="ListadoFacturas.rdlc"><DataSources><rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" /></DataSources></LocalReport></rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LNegociosyADatos.DataSet1TableAdapters.FacturasTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_IdFactura" Type="Int32" />
                    <asp:Parameter Name="Original_IdCliente" Type="Int32" />
                    <asp:Parameter Name="Original_Fecha" Type="String" />
                    <asp:Parameter Name="Original_Numero" Type="String" />
                    <asp:Parameter Name="Original_Importe" Type="String" />
                    <asp:Parameter Name="Original_TipoIva" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="IdCliente" Type="Int32" />
                    <asp:Parameter Name="Fecha" Type="String" />
                    <asp:Parameter Name="Numero" Type="String" />
                    <asp:Parameter Name="Concepto" Type="String" />
                    <asp:Parameter Name="Importe" Type="String" />
                    <asp:Parameter Name="TipoIva" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="IdCliente" Type="Int32" />
                    <asp:Parameter Name="Fecha" Type="String" />
                    <asp:Parameter Name="Numero" Type="String" />
                    <asp:Parameter Name="Concepto" Type="String" />
                    <asp:Parameter Name="Importe" Type="String" />
                    <asp:Parameter Name="TipoIva" Type="String" />
                    <asp:Parameter Name="Original_IdFactura" Type="Int32" />
                    <asp:Parameter Name="Original_IdCliente" Type="Int32" />
                    <asp:Parameter Name="Original_Fecha" Type="String" />
                    <asp:Parameter Name="Original_Numero" Type="String" />
                    <asp:Parameter Name="Original_Importe" Type="String" />
                    <asp:Parameter Name="Original_TipoIva" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    
    </div>
         <p>
&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebFacturas.aspx" Text="Volver" />
         </p>
    </form>
</body>
</html>
