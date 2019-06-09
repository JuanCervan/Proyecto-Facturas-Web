<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="WebDetalleConcepto.aspx.cs" Inherits="InterfazWeb.WebDetalleConcepto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <br />
&nbsp;
            <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/img/concepto2.png" Width="81px" />
&nbsp;
            <asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Editar Conceptos de Facturación"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Concepto:"></asp:Label>
&nbsp;<asp:TextBox ID="txbConcepto" runat="server" Width="357px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbConcepto" Display="Dynamic" ErrorMessage="Debe indicar un concepto" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txbConcepto" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ya existe un concepto con ese nombre" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        </p>
        <p>
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Precio:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbPrecio" runat="server" Width="118px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbPrecio" Display="Dynamic" ErrorMessage="Debe indicar un precio" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        &nbsp;<asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txbPrecio" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Debe introducir un número" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
        &nbsp;</p>
        <p>
            &nbsp;&nbsp; Tipo de IVA:
            <asp:DropDownList ID="cbTipoIva" runat="server">
                <asp:ListItem Selected="True" Value="21">21%</asp:ListItem>
                <asp:ListItem Value="10">10%</asp:ListItem>
                <asp:ListItem Value="4">4%</asp:ListItem>
            </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbTipoIva" ErrorMessage="Debe indicar un tipo de IVA" ForeColor="Red" CssClass="alert-danger"></asp:RequiredFieldValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp; &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
&nbsp;
            <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="btn-danger" PostBackUrl="~/WebConceptos.aspx" Text="Volver" />
        &nbsp;
            <asp:Label ID="lbAviso" runat="server" Text="Label" Visible="False" CssClass="alert-info"></asp:Label>
        </p>
        <p>
            <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <p>
            &nbsp;</p>
    <div>
    
    </div>
    </form>
</body>
</html>
