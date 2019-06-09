<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFacturas.aspx.cs" Inherits="InterfazWeb.WebFacturas"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style>
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
    
        <asp:Image ID="Image1" runat="server" Height="85px" ImageUrl="~/img/factura.png" Width="88px" />
        &nbsp;<asp:Label ID="lbCabecera" runat="server" Font-Size="XX-Large" Text="Facturas"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="dgv" class="dgv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="dgv_RowDataBound" OnRowEditing="dgv_RowEditing" OnRowDeleting="dgv_RowDeleting" ShowFooter="True" OnRowCommand="print" OnSelectedIndexChanged="dgv_SelectedIndexChanged" ShowHeaderWhenEmpty="True" EmptyDataText="No existen Facturas para este cliente" AllowPaging="True" OnPageIndexChanging="dgv_PageIndexChanging" PageSize="4">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/img/editar2.png" ShowEditButton="True" HeaderText="Editar" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" />
                <asp:BoundField DataField="IdFactura" HeaderText="IdFactura" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Numero" HeaderText="Número" />
                <asp:BoundField HeaderText="Total">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="det" HeaderText="Detalle" ImageUrl="~/img/detalles24otro.png" Text="Botón" />
                <asp:ButtonField ButtonType="Image" CommandName="print" HeaderText="Imprimir" ImageUrl="~/img/printer24.png" Text="Botón">
                <ItemStyle HorizontalAlign="Center" />
                </asp:ButtonField>
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
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAnyadirFactura" runat="server" Text="Añadir Factura" OnClick="btnAnyadirFactura_Click" CssClass="btn-primary" />
&nbsp;
        <asp:Button ID="btnCancelar" runat="server" PostBackUrl="~/WebClientes.aspx" Text="Volver" CssClass="btn-danger" />
        <br />
        <br />
&nbsp;
        <br />
        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="87px" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lbConfirmacion"  runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" CssClass="btn-outline-success" Width="33px" />
                        &nbsp;
                        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" CssClass="btn-outline-danger" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    
    </div>
    </form>
</body>
</html>
