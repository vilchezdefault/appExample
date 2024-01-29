<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="appEmpresaHH.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">Clientes</h1>

    <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="false" PageSize="5" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged1" align="center" >
        <Columns>
            <asp:BoundField DataField="id_cliente_prop" HeaderText="ID Cliente"/>
            <asp:BoundField DataField="nombre_completo_prop" HeaderText="Nombre"/>
            <asp:BoundField DataField="apellido_prop" HeaderText="apellido_prop"/>
            <asp:BoundField DataField="apellido2_prop" HeaderText="apellido2_prop"/>
            <asp:BoundField DataField="tipo_identificacion_prop" HeaderText="Tipo de Identificación"/>
            <asp:BoundField DataField="numero_identificacion_prop" HeaderText="Número de Identificación"/>
            
            <asp:BoundField DataField="idUsuarioRGT_prop" HeaderText="idUsuarioRGT_prop"/>
            <asp:BoundField DataField="fecha_registro_prop" HeaderText="fecha_registro_prop"/>
            <asp:BoundField DataField="id_usuarioMDC_prop" HeaderText="id_usuarioMDC_prop"/>
            <asp:BoundField DataField="fecha_modificacion_prop" HeaderText="fecha_modificacion_prop"/>
          <%--  <asp:BoundField DataField="fechaMProp" HeaderText="Fecha Modifica"/>
            <%--Para agregar el boton de seleccionar --%>
            <asp:CommandField ShowSelectButton="true" HeaderStyle-Width="60px" ControlStyle-ForeColor="Black"/>
        </Columns>
    </asp:GridView>

    <%-- Se agrega el div de Detalle de Usuarios --%>
    <div>
       <p class="Titulos" align="center">Detalle de Clientes</p>
        <center>
        <table>
            
            <tr>
               <th>
                   <asp:Label ID="lblid_cliente_prop" runat="server" Text="Id Cliente"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtid_cliente_prop" runat="server"></asp:TextBox>
               </th>
            </tr>
            <tr>
                <th>
                   <asp:Label ID="lblnombre_completo_prop" runat="server" Text="Nombre completo"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtnombre_completo_prop" runat="server"></asp:TextBox>
               </th>
            </tr>
            <tr>
                <th>
                   <asp:Label ID="lblapellido_prop" runat="server" Text="Apellido"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtapellido_prop" runat="server"></asp:TextBox>
               </th>
            </tr>
            <tr>
               <th>
                   <asp:Label ID="lblapellido2_prop" runat="server" Text="apellido2"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtapellido2_prop" runat="server"></asp:TextBox>
               </th>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lbltipo_identificacion_prop" runat="server" Text="Tipo de Identificación"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txttipo_identificacion_prop" runat="server"></asp:TextBox>
               </th>  
            </tr> 
            <tr>
               <th>
                    <asp:Label ID="lblnumero_identificacion_prop" runat="server" Text="Número de Identificación"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtnumero_identificacion_prop" runat="server"></asp:TextBox>
               </th>  
            </tr>
            <tr>
               <th>
                    <asp:Label ID="lblidUsuarioRGT_prop" runat="server" Text="idUsuarioRGT"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtidUsuarioRGT_prop" runat="server"></asp:TextBox>
               </th>  
            </tr>
            <tr>
               <th>
                    <asp:Label ID="lblfecha_registro_prop" runat="server" Text="fecha registro"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtfecha_registro_prop" runat="server"></asp:TextBox>
               </th>  
            </tr>
<%--            <th>
                    <asp:Label ID="lblidUsuarioRProp" runat="server" Text="Usuario Registra"></asp:Label>
               </th>
                <th>
                    <asp:Label ID="lblidUsuarioMProp" runat="server" Text="Usuario Modifica"></asp:Label>
                </th>
                <th>
                    <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList>
               </th>
            <tr>--%>
               <th>
                    <asp:Label ID="lblid_usuarioMDC_prop" runat="server" Text="id_usuarioMDC"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtid_usuarioMDC_prop" runat="server"></asp:TextBox>
               </th>  
            </tr>
            <tr>
               <th>
                    <asp:Label ID="lblfecha_modificacion_prop" runat="server" Text="fecha_modificacion_prop"></asp:Label>
               </th>
                <th>
                    <asp:TextBox ID="txtfecha_modificacion_prop" runat="server"></asp:TextBox>
               </th>  
            </tr>

            <tr>
                <th>
                    <asp:Button ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" runat="server"/>

               </th>
                <th>
                    <asp:Button ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click"  runat="server"/>                 
               </th> 
                <th>
                    <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" OnClick="btnEliminarUsuario_Click"/>
               </th>               
            </tr>
        </table>
         </center>
    </div>
</asp:Content>
