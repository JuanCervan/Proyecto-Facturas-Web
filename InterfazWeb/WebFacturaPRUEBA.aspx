<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFacturaPRUEBA.aspx.cs" Inherits="InterfazWeb.WebFacturaPRUEBA" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <title>Facturas Web 0.2</title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            margin-right: 0px;
        }
        .auto-style2 {
            margin-left: 40px;
            height: 56px;
        }
        .auto-style3 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <br />
            <asp:Button ID="Button1" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebFacturas.aspx" Text="Volver" OnClick="Button1_Click" />
        </div>
        &nbsp;
        <div class="auto-style3">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="847px" CssClass="auto-style1" Height="519px" OnPreRender="ReportViewer1_PreRender">
                <LocalReport ReportPath="1Factura.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet1Factura" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="InterfazWeb.DataSet1FacturaTableAdapters.FacturasPrintTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txbIdFactura" Name="IdFactura" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetDataPRUEBA" TypeName="InterfazWeb.Proyecto_CDataSetPRUEBATableAdapters.Clientes_ConsultaTableAdapter" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txbIdFactura" Name="IdFactura" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataPRUEBA" TypeName="InterfazWeb.Proyecto_CDataSetPRUEBATableAdapters.Clientes_ConsultaTableAdapter" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txbIdFactura" Name="IdFactura" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:TextBox ID="txbIdFactura" runat="server" Visible="False"></asp:TextBox>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
    </form>
</body>
</html>
