<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LibroPagina.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
     <section class="col-md-4" aria-labelledby="gettingStartedTitle">
        <div>
            <h2>Ingresar Datos</h2>
            <asp:Label ID="LabelTitulo" runat="server" Text="Título:"></asp:Label>
            <asp:TextBox ID="TextBoxTitulo" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LabelDescripcion" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LabelAutor" runat="server" Text="ID de Autor:"></asp:Label>
            <asp:TextBox ID="TextBoxIdAutor" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LabelAnio" runat="server" Text="Año:"></asp:Label>
            <asp:TextBox ID="TextBoxAnio" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Enviar" OnClick="ButtonSubmit_Click" />
        </div>
     </section>
     
</asp:Content>
