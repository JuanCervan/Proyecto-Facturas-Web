<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebDetalleLinea.aspx.cs" Inherits="InterfazWeb.WebDetalleLinea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <div class="cabecera">
    <div class="cabe">
        <br />
&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="85px" ImageUrl="~/img/editaLineBig.png" Width="88px" />
&nbsp;
        <asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Añadir Línea de Factura"></asp:Label>
        <br />
        <br />
    </div>
    </div>
    <div class="central">
        <form id="form1" runat="server" class="centro">
        
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Concepto:"></asp:Label>
&nbsp;&nbsp;&nbsp;
&nbsp;
            <asp:DropDownList ID="cbConcepto" runat="server" Width="326px" AutoPostBack="True" OnSelectedIndexChanged="cbConcepto_SelectedIndexChanged" OnTextChanged="cbConcepto_TextChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txbConceptoE" runat="server" Visible="False" Width="326px" MaxLength="30"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnConcepto" runat="server" Text="Conceptos..." ToolTip="Añadir y Editar Conceptos" Width="112px" CausesValidation="False" OnClick="btnConcepto_Click" CssClass="btn-warning" />
        &nbsp;
            &nbsp;</p>
        <p class="auto-style1">
&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="txbCantidad" runat="server" Width="91px" MaxLength="3"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbCantidad" Display="Dynamic" ErrorMessage="Debe indicar una cantidad" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbCantidad" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe introducir un número" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
&nbsp;</p>
        <p class="auto-style1">
&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Precio €:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbPrecio" runat="server" OnTextChanged="txbPrecio_TextChanged" Width="151px" MaxLength="6"></asp:TextBox>
&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbPrecio" Display="Dynamic" ErrorMessage="Debe indicar un precio" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        &nbsp;<asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txbPrecio" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe introducir un número" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
&nbsp;</p>
        <p class="auto-style1">
&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Tipo de IVA:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="cbIva" runat="server" Width="66px">
                <asp:ListItem Selected="True" Value="21">21%</asp:ListItem>
                <asp:ListItem Value="10">10%</asp:ListItem>
                <asp:ListItem Value="4">4%</asp:ListItem>
            </asp:DropDownList>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbIva" Display="Dynamic" ErrorMessage="Debe indicar el tipo de IVA" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        </p>
        <p class="auto-style1">
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredCbConcepto" runat="server" ControlToValidate="cbConcepto" Display="Dynamic" ErrorMessage="Debe indicar un concepto" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="cbConcepto" CssClass="alert-danger" ErrorMessage="Concepto no válido" ForeColor="Red" OnServerValidate="CustomValidator5_ServerValidate"></asp:CustomValidator>
            </p>
        <p class="auto-style1">
            &nbsp;
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
&nbsp;
            <asp:Button ID="btnVolver" runat="server" CssClass="btn-danger" PostBackUrl="~/WebDetalle.aspx" Text="Volver" CausesValidation="False" />
        &nbsp;
            <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-info"></asp:Label>
            <asp:TextBox ID="txbCompara" runat="server" Visible="False">Seleccione un Concepto...</asp:TextBox>
        </p>
        <p class="auto-style1">
            &nbsp;</p>
            
    </form>
       </div>
</body>
</html>
