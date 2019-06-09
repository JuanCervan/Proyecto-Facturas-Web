<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInformeUsuarios.aspx.cs" Inherits="InterfazWeb.WebInformeUsuarios" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
        .auto-style2 {
            margin-top: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
         <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebUsuarios.aspx" Text="Volver" Width="66px" />
        <br />
    
        <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="861px" CssClass="auto-style2" OnPreRender="ReportViewer1_PreRender">
                <LocalReport ReportPath="ListUsuarios.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetUsuarios" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InterfazWeb.DataSetUsuariosTableAdapters.ListaUsuariosTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LNegociosyADatos.DataSet1TableAdapters.UsuariosTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_IdUsuario" Type="Int32" />
                    <asp:Parameter Name="Original_Nombre" Type="String" />
                    <asp:Parameter Name="Original_Contraseña" Type="String" />
                    <asp:Parameter Name="Original_Acceso" Type="Byte" />
                    <asp:Parameter Name="Original_Tipo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Contraseña" Type="String" />
                    <asp:Parameter Name="Acceso" Type="Byte" />
                    <asp:Parameter Name="Tipo" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Contraseña" Type="String" />
                    <asp:Parameter Name="Acceso" Type="Byte" />
                    <asp:Parameter Name="Tipo" Type="String" />
                    <asp:Parameter Name="Original_IdUsuario" Type="Int32" />
                    <asp:Parameter Name="Original_Nombre" Type="String" />
                    <asp:Parameter Name="Original_Contraseña" Type="String" />
                    <asp:Parameter Name="Original_Acceso" Type="Byte" />
                    <asp:Parameter Name="Original_Tipo" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </asp:Panel>
    
    </div>
         &nbsp;&nbsp;&nbsp;&nbsp;
         </form>
</body>
</html>
