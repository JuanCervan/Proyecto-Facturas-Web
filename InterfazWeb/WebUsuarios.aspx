<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebUsuarios.aspx.cs" Inherits="InterfazWeb.WebUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        table{
            text-align:center;
        }
        .dgv{
            margin-left:25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" Height="71px" ImageUrl="~/img/usuariosf.png" Width="77px" />
&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Usuarios"></asp:Label>
        <br />
        &nbsp;
        <br />
        <asp:GridView ID="dgv" runat="server" class="dgv" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowEditing="dgv_RowEditing" OnRowDeleting="dgv_RowDeleting" OnRowDataBound="dgv_RowDataBound" ShowFooter="True" EmptyDataText="No existen Usuarios" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="dgv_PageIndexChanging" PageSize="4">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/img/editar2.png" ShowEditButton="True" HeaderText="Editar" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
                <asp:BoundField DataField="Email" HeaderText="E-Mail" />
                <asp:BoundField DataField="Acceso" HeaderText="Acceso" />
                <asp:BoundField HeaderText="Tipo de Acceso" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/del.png" HeaderText="Eliminar" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
    </div>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbAviso" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="alert-danger"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Usuario..." OnClick="Button1_Click" CssClass="btn-primary" />
    &nbsp;&nbsp;
        <asp:Button ID="btnPrint" runat="server" CssClass="btn-primary" PostBackUrl="~/WebInformeUsuarios.aspx" Text="Imprimir..." ToolTip="Imprimir listado de Usuarios" />
&nbsp;
        <asp:Button ID="btnCancelar" runat="server" PostBackUrl="~/WebClientes.aspx" Text="Volver" CssClass="btn-danger" />
        <br />
        <br />
&nbsp;
        <br />
        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="87px" Visible="False">
            <table style="width:100%; height: 78px;">
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Label ID="lbConfirmacion" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" CssClass="btn-outline-success" Width="35px" />
                        &nbsp;
                        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" CssClass="btn-outline-danger" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
