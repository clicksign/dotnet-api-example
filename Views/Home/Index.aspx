<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <p>
        Para Iniciar, clique no botao abaixo. Irei fazer uma série de requests. 
    </p>
     <input type='button' id='iniciar' name='Iniciar' value='Iniciar'  />
     <div id='discussion' />
</asp:Content>
