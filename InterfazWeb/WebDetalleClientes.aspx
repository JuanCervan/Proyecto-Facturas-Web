<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebDetalleClientes.aspx.cs" Inherits="InterfazWeb.WebDetalleClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
</head>
<body>
    <div class="central">
    <form id="form1" runat="server" class="centro">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/img/contacto.png" Width="81px" />
&nbsp;
        <asp:Label ID="lbClientes" runat="server" Font-Size="XX-Large" Text="Detalle Clientes"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txbNombre" runat="server" Width="288px" MaxLength="30"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="Debe indicar un nombre" ForeColor="Red" Display="Dynamic" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="Ya existe un cliente con ese nombre" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" CssClass="alert-danger" Display="Dynamic"></asp:CustomValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="NIF:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txbNif" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbNif" ErrorMessage="Debe indicar un NIF" ForeColor="Red" Display="Dynamic" CssClass="alert-danger"></asp:RequiredFieldValidator>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txbNif" ErrorMessage="El formato correcto de NIF es Letra Mayúscula-XXXXXXXX" ForeColor="Red" ValidationExpression="^[A-Z]-{1}\d{7}[a-zA-Z0-9]{1}$" Display="Dynamic" CssClass="alert-danger"></asp:RegularExpressionValidator>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txbNif" ErrorMessage="Ya existe un cliente con ese NIF" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" CssClass="alert-danger" Display="Dynamic"></asp:CustomValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Dirección:"></asp:Label>
&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txbDireccion" runat="server" Width="295px" MaxLength="30"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Ciudad:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txbCiudad" runat="server" Width="295px" MaxLength="30"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Teléfono:"></asp:Label>
&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txbTelefono" runat="server" MaxLength="9" Width="128px"></asp:TextBox>
&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txbTelefono" ErrorMessage="El télefono debe comenzar por 8 ó 9 y tener 9 cifras" ForeColor="Red" MaximumValue="999999999" MinimumValue="800000000" CssClass="alert-danger" Display="Dynamic"></asp:RangeValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txbEmail" runat="server" Width="293px" MaxLength="30"></asp:TextBox>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" ErrorMessage="El formato de Email no es correcto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="alert-danger" Display="Dynamic"></asp:RegularExpressionValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Contacto:"></asp:Label>
&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txbContacto" runat="server" Width="292px" MaxLength="30"></asp:TextBox>
        &nbsp;
        <asp:Label ID="lbUsuario" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:DropDownList ID="cbUser" runat="server" Width="167px">
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-primary" />
    
    &nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/WebClientes.aspx" Text="Volver" CssClass="btn-danger" />
    
    &nbsp;
        <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-success"></asp:Label>
    
        <br />
        <br />
    
    </div>
    </form>
        </div>
</body>
</html>
