<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebPassword.aspx.cs" Inherits="InterfazWeb.WebPassword" %>

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
    <div>
    
        <br />
        <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/img/password.png" />
    
    &nbsp;<asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Recuperar Contraseña"></asp:Label>
    
    </div>
        <p>
&nbsp;
        </p>
        <p>
&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Indique el correo electrónico con el que se registró:"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;<asp:TextBox ID="txbMail" runat="server" Width="335px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="Debe indicar una dirección de correo electrónico" CssClass="alert-danger" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbMail" CssClass="alert-danger" Display="Dynamic" ErrorMessage="El formato de correo electrónico no es correcto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </p>
        <p>
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Responda a la pregunta de seguridad..."></asp:Label>
&nbsp;<asp:Label ID="lbPregunta" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;<asp:TextBox ID="txbRespuesta" runat="server" Width="333px" EnableViewState="False"></asp:TextBox>
&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbRespuesta" Display="Dynamic" ErrorMessage="Debe responder a la pregunta de seguridad" CssClass="alert-danger" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;<asp:Button ID="btnEnviar" runat="server" CssClass="btn-primary" OnClick="btnEnviar_Click" Text="Enviar" Width="73px" />
&nbsp;
            <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebLogin.aspx" Text="Volver" OnClick="btnVolver_Click" />
&nbsp;
            <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-info"></asp:Label>
        </p>
        <p>
            <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
    </form>
</body>
</html>
