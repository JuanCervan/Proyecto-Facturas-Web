<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebDetalleFacturas.aspx.cs" Inherits="InterfazWeb.WebDetalleFacturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <style>
        .moneda{
            text-align:right;
        }
    </style>
</head>
<body>
    <div class="central">
    <form id="form1" runat="server" class="centro">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" Height="73px" ImageUrl="~/img/facturaguay.png" Width="79px" />
&nbsp;
        <asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Editar Factura"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Fecha de factura:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txbFechaNueva" runat="server" TextMode="Date" Width="167px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbFechaNueva" ErrorMessage="Debe indicar una fecha" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Número de factura:"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txbNumero" runat="server" ReadOnly="True" Width="168px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbNumero" ErrorMessage="El número de factura no puede estar vacio" ForeColor="Red" Display="Dynamic" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbNumero" ErrorMessage="El número de factura ya existe" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" CssClass="alert-danger"></asp:CustomValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-primary" />
        &nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/WebFacturas.aspx" Text="Volver" CssClass="btn-danger" />
        &nbsp;
        <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-success"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
        </div>
</body>
</html>
