<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebRegistroUsuario.aspx.cs" Inherits="InterfazWeb.WebRegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 353px">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" Height="78px" ImageUrl="~/img/userBig.png" Width="87px" />
&nbsp;
        <asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Registro Usuario"></asp:Label>
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txbNombre" runat="server" Width="180px"></asp:TextBox>
&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbNombre" CssClass="alert-danger" ErrorMessage="El nombre de Usuario ya existe" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="txbContrasenya" runat="server" MaxLength="5"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbContrasenya" ErrorMessage="La contraseña no puede estar vacia" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Repita la contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="txbContrasenyaRep" runat="server" MaxLength="5"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbContrasenyaRep" Display="Dynamic" ErrorMessage="Debe repetir la contraseña" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbContrasenya" ControlToValidate="txbContrasenyaRep" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" CssClass="alert-danger"></asp:CompareValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Correo Electrónico:"></asp:Label>
&nbsp;<asp:TextBox ID="txbEmail" runat="server" Width="255px"></asp:TextBox>
&nbsp;
        <asp:Image ID="Image2" runat="server" Height="25px" ImageUrl="~/img/info.png" ToolTip="Si no indica una dirección real, no podrá recuperar automáticamente su contraseña en caso de olvido ni será notificado de su acceso a la aplicación..." Width="33px" />
&nbsp;&nbsp;
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbEmail" CssClass="alert-danger" Display="Dynamic" ErrorMessage="El correo no puede estar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" CssClass="alert-danger" ErrorMessage="El formato del correo no es válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Pregunta de seguridad:"></asp:Label>
&nbsp;<asp:TextBox ID="txbPregunta" runat="server" Width="277px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbPregunta" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe introducir una pregunta de seguridad" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Respuesta:
        <asp:TextBox ID="txbRespuesta" runat="server" Width="216px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txbRespuesta" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe indicar una respuesta" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-primary" />
    
    &nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Volver" CssClass="btn-danger" OnClick="btnCancelar_Click" />
    
    &nbsp;
        <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-success"></asp:Label>
    
        <br />
        <br />
        <br />
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">
        </asp:Timer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
    </form>
</body>
</html>
