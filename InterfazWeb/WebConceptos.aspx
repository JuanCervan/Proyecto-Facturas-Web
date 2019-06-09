<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebConceptos.aspx.cs" Inherits="InterfazWeb.WebConceptos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Facturas Web 0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style7 {
            width: 4px;
            height: 16px;
        }
        .auto-style8 {
            width: 467px;
            height: 16px;
        }
        .auto-style9 {
            height: 16px;
        }
        .auto-style10 {
            width: 4px;
        }
        .auto-style12 {
            width: 467px;
        }
    </style>
</head>
<body>
    <div class="central">
    <form id="form1" runat="server" class="centro">
        <p>
            <br />
&nbsp;
            <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/img/concepto1.png" Width="81px" />
        &nbsp;
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Conceptos de Facturación"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp; <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="dgv_RowDeleting" OnRowEditing="dgv_RowEditing" OnRowDataBound="dgv_RowDataBound" ShowFooter="True" EmptyDataText="No hay Conceptos de Facturación" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="4" OnPageIndexChanging="dgv_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Image" EditImageUrl="~/img/editar2.png" HeaderText="Editar" ShowEditButton="True">
                    <HeaderStyle CssClass="text-center" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="IdConcepto" HeaderText="IdConcepto" />
                    <asp:BoundField DataField="Nombre" HeaderText="Concepto" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TipoIva" HeaderText="Tipo de IVA">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/del.png" HeaderText="Eliminar" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Strikeout="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </p>
        <p>
            &nbsp;<asp:Button ID="btnAnyadir" runat="server" CssClass="btn-primary" Text="Añadir Concepto..." OnClick="btnAnyadir_Click" />
&nbsp;
            <asp:Button ID="btnVolver" runat="server" CssClass="btn-danger" PostBackUrl="~/WebDetalleLinea.aspx" Text="Volver" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="87px" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:Label ID="lbConfirmacion"  runat="server" Text="Label" Visible="False" Font-Bold="True"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" CssClass="btn-outline-success" Width="33px" />
                        &nbsp;
                        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" CssClass="btn-outline-danger" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        </p>
    <div>
    
    </div>
    </form>
        </div>
</body>
</html>
