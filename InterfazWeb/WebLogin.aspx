<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="InterfazWeb.WebLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facturas Web v0.2</title>
      <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style3 {
            width: 100%;
            height: 212px;
        }
        table{
            text-align:center;
            width:100%;
            padding-top:25px;
        }
        .auto-style4 {
            width: 67%;
            text-align:left;
        }
        .auto-style6 {
            width: 33%;
            height: 71px;
        }
        .auto-style7 {
            width: 67%;
            text-align: left;
            height: 71px;
        }
        .auto-style8 {
            height: 71px;
        }
        .auto-style9 {
            width: 33%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="205px" Width="100%">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style9">
                        &nbsp;</td>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image4" runat="server" Height="62px" ImageUrl="~/img/login.png" Width="69px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="Login"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7">
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Usuario:"></asp:Label>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txbUsuario" runat="server" MaxLength="25" Width="226px"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUsuario" ErrorMessage="Debe especificar un usuario" ForeColor="Red" CssClass="alert-danger" Display="Dynamic" ValidationGroup="login"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbUsuario" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe especificar un usuario" ForeColor="Red" ValidationGroup="pass"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbUsuario" CssClass="alert-danger" Display="Dynamic" ErrorMessage="El usuario especificado no existe" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="pass"></asp:CustomValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Contraseña:"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="txbContrasenya" runat="server" TextMode="Password" MaxLength="5" Width="227px"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbContrasenya" ErrorMessage="Debe especificar una contraseña" ForeColor="Red" CssClass="alert-danger" ValidationGroup="login"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style8">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="btnPassword" runat="server" Font-Size="Small" ForeColor="Blue" OnClick="btnPassword_Click" ValidationGroup="pass">He olvidado mi contraseña</asp:LinkButton>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEntrar" runat="server" CssClass="btn-primary" OnClick="Button1_Click" Text="Entrar" Width="70px" ValidationGroup="login" />
                        &nbsp;
                        <asp:Button ID="btnRegistro" runat="server" CausesValidation="False" OnClick="Button2_Click" Text="Registro" Width="75px" CssClass="btn-success" />
&nbsp;
                        <asp:Label ID="lbAviso" runat="server" ForeColor="Blue" Text="Label" Visible="False" CssClass="alert-info"></asp:Label>
                        <br />
                        &nbsp; &nbsp;
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Image ID="Image5" runat="server" Height="44px" ImageUrl="~/img/ico.png" Width="51px" />
                            Facturas v0.2 <span class="badge badge-secondary">WEB</span></h4>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Size="Small" ForeColor="#0033CC" Text="© J2C 2019" ToolTip="Juan Cerván Cano"></asp:Label>
                        &nbsp; </td>
                    <td>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;
        <br />
        <br />
&nbsp;
        &nbsp; 
        <br />
        <br />
&nbsp;
        &nbsp;
            
        </div>
    </form>
    
</body>
</html>
