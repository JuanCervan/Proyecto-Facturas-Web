<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="WebInformeClientes.aspx.cs" Inherits="InterfazWeb.WebInformeClientes" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js" language="javascript" type="text/javascript"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <style type="text/css">
        .auto-style1 {
            height: 75px;
            margin-left: 40px;
        }
        </style>
</head>
<body>
   
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
&nbsp;<asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebClientes.aspx" Text="Volver" />
         &nbsp;<br />
        &nbsp;&nbsp;
        <br />
        &nbsp;
        <br />
    
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Height="100%" Width="99%">
            &nbsp;&nbsp;&nbsp;
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1082px" Font-Names="Verdana" Font-Size="8pt" Height="529px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" OnPreRender="ReportViewer1_PreRender"><LocalReport ReportPath="ListaClientes.rdlc"><DataSources><rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetListaClientes" /></DataSources></LocalReport></rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InterfazWeb.DataSet1TableAdapters.ClientesTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LNegociosyADatos.DataSet1TableAdapters.ClientesTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_IdCliente" Type="Int32" />
                    <asp:Parameter Name="Original_Nombre" Type="String" />
                    <asp:Parameter Name="Original_Cif" Type="String" />
                    <asp:Parameter Name="Original_Direccion" Type="String" />
                    <asp:Parameter Name="Original_Ciudad" Type="String" />
                    <asp:Parameter Name="Original_Telefono" Type="String" />
                    <asp:Parameter Name="Original_email" Type="String" />
                    <asp:Parameter Name="Original_Persona" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Cif" Type="String" />
                    <asp:Parameter Name="Direccion" Type="String" />
                    <asp:Parameter Name="Ciudad" Type="String" />
                    <asp:Parameter Name="Telefono" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="Persona" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Cif" Type="String" />
                    <asp:Parameter Name="Direccion" Type="String" />
                    <asp:Parameter Name="Ciudad" Type="String" />
                    <asp:Parameter Name="Telefono" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="Persona" Type="String" />
                    <asp:Parameter Name="Original_IdCliente" Type="Int32" />
                    <asp:Parameter Name="Original_Nombre" Type="String" />
                    <asp:Parameter Name="Original_Cif" Type="String" />
                    <asp:Parameter Name="Original_Direccion" Type="String" />
                    <asp:Parameter Name="Original_Ciudad" Type="String" />
                    <asp:Parameter Name="Original_Telefono" Type="String" />
                    <asp:Parameter Name="Original_email" Type="String" />
                    <asp:Parameter Name="Original_Persona" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
         <p>
&nbsp;&nbsp;&nbsp;
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         </p>
    </form>
</body>
</html>
