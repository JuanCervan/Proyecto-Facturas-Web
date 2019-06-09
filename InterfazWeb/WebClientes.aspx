<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebClientes.aspx.cs" Inherits="InterfazWeb.WebClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>
    <title>Facturas Web v0.2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 33px;
        }
        .auto-style3 {
            height: 42px;
            width: 806px;
        }
        .auto-style4 {
            height: 33px;
            width: 806px;
        }
        .auto-style6 {
            height: 42px;
        }
        .borrar{
            text-align:center;
            
            
        }
        
        .auto-style8 {
            margin-top: 8px;
        }
        .auto-style10 {
            width: 640px;
        }
        .panel{
            margin-left:20px;
        }
        .auto-style11 {
            height: 634px;
        }
        .auto-style12 {
            text-align: center;
            width: 100%;
            height: 75px;
        }
        .auto-style13 {
            width: 100%;
            height: 135px;
        }
        </style>
</head>
<body>
    <div>

       <div>
           <form id="form1" runat="server">
    <div class="auto-style11">
    
        <%--<br />--%>
       
        
         <asp:Panel ID="Panel1" class="panel" runat="server" Height="337px" ScrollBars="Auto">
            &nbsp;<asp:Image ID="Image1" runat="server" Height="85px" ImageUrl="~/img/gente.png" Width="88px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Clientes"></asp:Label>
            &nbsp;<br />
            <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="151px" OnRowCommand="ver" OnRowDataBound="dgv_RowDataBound" OnRowDeleting="dgv_RowDeleting" OnRowEditing="dgv_RowEditing" ShowFooter="True" PageSize="4" ShowHeaderWhenEmpty="True" EmptyDataText="No existen Clientes" AllowPaging="True" OnPageIndexChanging="dgv_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Image" EditImageUrl="~/img/editar2.png" EditText="Edit" HeaderText="Editar" ShowEditButton="True">
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" />
                    <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                    <ItemStyle Wrap="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cif" HeaderText="NIF" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="Persona" HeaderText="Persona de Contacto" />
                    <asp:ButtonField ButtonType="Image" CommandName="ver" HeaderText="Facturas" ImageUrl="~/img/facturasmall.png" ShowHeader="True" Text="Botón">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/del.png" HeaderText="Eliminar" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField HeaderText="Usuario" />
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
        </asp:Panel>
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbMostrar" runat="server" Text="Clientes de:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" Width="182px">
        </asp:DropDownList>
&nbsp;<asp:Panel ID="Panel5" runat="server" Height="52px">
            <table class="auto-style13">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txbBuscar" runat="server" CssClass="auto-style8" OnTextChanged="txbBuscar_TextChanged" Width="161px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn-outline-primary" OnClick="btnBuscar_Click" Text="Buscar" ToolTip="Buscar Cliente por Nombre" />
                        &nbsp;
                        <asp:Button ID="btnTodos" runat="server" CssClass="btn-outline-primary" OnClick="btnTodos_Click" Text="Mostrar Todos" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp; </td>
                    <td class="auto-style6">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbBuscar" runat="server" Text="No hay Clientes que coincidan con la búsqueda" Visible="False" CssClass="alert-danger"></asp:Label>
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAnyadir" runat="server" CssClass="btn-primary" OnClick="btnAnyadir_Click" Text="Añadir Cliente..." Width="123px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnPrint" runat="server" PostBackUrl="~/WebInformeClientes.aspx" Text="Imprimir..." CssClass="btn-primary" ToolTip="Imprimir listado de Clientes" OnClick="btnPrint_Click" />
                    &nbsp;
                        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/WebUsuarios.aspx" Text="Administrar Usuarios..." CssClass="btn-primary" Width="173px" />
                    &nbsp;&nbsp;
                        <asp:Button ID="btnPerfil" runat="server" CssClass="btn-primary" OnClick="btnPerfil_Click" Text="Editar Perfil..." />
                    &nbsp;<asp:Button ID="btnCerrar" runat="server" PostBackUrl="~/WebLogin.aspx" Text="Cerrar Sesion" OnClick="btnCerrar_Click1" CssClass="btn-dark" Height="31px" />
                    &nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    <td class="auto-style2"></td>
                </tr>
                </table>
        <br />
        
        <asp:Panel ID="Panel4" runat="server" BackColor="Silver" Height="65px" Visible="False">
            <table class="auto-style12">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lbConfirmacion" runat="server" Text="Label" Visible="False"></asp:Label>
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
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
&nbsp;
        &nbsp;&nbsp;
        &nbsp;
        <br />
        <br />
&nbsp;
        
    </div>
    </form>
    </div>
    </div>
</body>
</html>
