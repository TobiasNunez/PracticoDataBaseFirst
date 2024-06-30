<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LibroPagina.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <div class="row">
        <section class="col-md-4" aria-labelledby="gettingStartedTitle">
            <form id="searchForm1">
                <label id="lblSeleccionar1" for="seleccionar">Seleccionar:</label>
             <select id="slcAutor1" value="Autor" runat="server">
               <option id="opAutor1" value="Autor">Autor</option>
               <option id="opTitulo1" value="Titulo">Titulo</option>
               <option id="opAño1" value="Año">Año</option>
             </select><br><br>
                <input type="text" id="txtData1" runat="server" name="searchData" placeholder="Ingresar dato a buscar">
                 <asp:Button ID="txtButton" runat="server" Text="Buscar" OnClick="button1_Click" />
            </form>  
        </section>
    <div class="row">
        <div class="col-12">
            <h3>Lista de libros</h3>
            <asp:GridView ID="gvLibros1" runat="server" Width="80%" BorderWidth="2px" CellSpacing="15"
                AutoGenerateColumns="true">             
            </asp:GridView>
        </div>
    </div>
             
</main>
</asp:Content>
