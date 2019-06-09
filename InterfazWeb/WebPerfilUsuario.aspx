<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebPerfilUsuario.aspx.cs" Inherits="InterfazWeb.WebPerfilUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 394px">
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" Height="72px" ImageUrl="~/img/userBig.png" Width="70px" />
&nbsp;
        <asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Perfil Usuarios"></asp:Label>
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Nombre de usuario:"></asp:Label>
&nbsp;<asp:TextBox ID="txbNombre" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" Display="Dynamic" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="Ya existe un usuario con ese nombre" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" CssClass="alert-danger"></asp:CustomValidator>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="txbContrasenya" runat="server" MaxLength="5" Width="111px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbContrasenya" ErrorMessage="La contraseña no puede estar vacia" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Repita la contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="txbContrasenyaRep" runat="server" MaxLength="5" Width="114px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbContrasenyaRep" Display="Dynamic" ErrorMessage="Debe repetir la contraseña" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbContrasenya" ControlToValidate="txbContrasenyaRep" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" CssClass="alert-danger"></asp:CompareValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Correo Electrónico:"></asp:Label>
&nbsp;<asp:TextBox ID="txbEmail" runat="server" Width="216px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbEmail" CssClass="alert-danger" Display="Dynamic" ErrorMessage="El correo no puede estar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" CssClass="alert-danger" ErrorMessage="El formato no es correcto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pregunta de seguridad:
        <asp:TextBox ID="txbPregunta" runat="server" Width="293px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbPregunta" CssClass="alert-danger" Display="Dynamic" ErrorMessage="La pregunta de seguridad no puede estar vacia" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Respuesta:"></asp:Label>
&nbsp;<asp:TextBox ID="txbRespuesta" runat="server" Width="242px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="alert-danger" Display="Dynamic" ErrorMessage="La respuesta no puede estar vacia" ForeColor="Red" ControlToValidate="txbRespuesta"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-primary" />
    
    &nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/WebClientes.aspx" Text="Volver" CssClass="btn-danger" />
    
    &nbsp;
        <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-success"></asp:Label>
    
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
