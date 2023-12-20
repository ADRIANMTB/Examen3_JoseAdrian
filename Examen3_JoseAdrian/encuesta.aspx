<%@ Page Title="" Language="C#" MasterPageFile="~/Encuesta.Master" AutoEventWireup="true" CodeBehind="encuesta.aspx.cs" Inherits="Examen3_JoseAdrian.encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Encuesta</h2>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Required="true"></asp:TextBox>
        </div>
        <div>
            <label>Fecha de Nacimiento (YYYY-MM-DD):</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" Required="true"></asp:TextBox>
        </div>
        <div>
            <label>Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" Required="true"></asp:TextBox>
        </div>
        <div>
            <label>Partido Político:</label>
            <asp:DropDownList ID="ddlPartido" runat="server" Required="true" OnSelectedIndexChanged="ddlPartido_SelectedIndexChanged">
                <asp:ListItem Text="PLN" Value="PLN" />
                <asp:ListItem Text="PUSC" Value="PUSC" />
                <asp:ListItem Text="PAC" Value="PAC" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnGEncuesta" runat="server" Text="Guardar Encuesta" OnClick="btnGuardarEncuesta_Click" />
            
        </div>

        <asp:GridView ID="gvEncuestas" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NumeroEncuesta" HeaderText="Número de Encuesta" SortExpression="NumeroEncuesta" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="FechaNacimiento" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:BoundField DataField="PartidoPolitico" HeaderText="Partido Político" SortExpression="PartidoPolitico" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>