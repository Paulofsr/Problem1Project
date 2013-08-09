<%@ Page Title="Cadastrar Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Cadastrar Cliente.</h2>
            </hgroup>
            <p>
                Informe os dados do Cliente que deseja cadastrar.
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>CLIENTE</h3>
        Nome: <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox><br />
        Email: <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><br />
        Data de Nascimento: <asp:TextBox ID="TextBoxData" runat="server"></asp:TextBox><br />
        Celular: <asp:TextBox ID="TextBoxCelular" runat="server"></asp:TextBox><br />
        Telefone Residencial: <asp:TextBox ID="TextBoxTelefone" runat="server"></asp:TextBox><br />
        <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" OnClick="ButtonEnviar_Click" /><br />
        <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
</asp:Content>