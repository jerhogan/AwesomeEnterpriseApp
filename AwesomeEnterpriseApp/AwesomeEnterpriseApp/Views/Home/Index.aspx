<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <div>
        <h6>Choose your movie:
        </h6><br />
        <%= Html.DropDownList("movieList") %>
        <h6>Choose filming location:</h6><br />
        <%= Html.DropDownList("locationList") %>
        <h6>Choose restaurant proximity:</h6><br />
        <%= Html.DropDownList("radiusList") %>
        <br/>
        <input type="submit" value="Submit" />

        <div id="retInf"><p>Your selection of restaurants</p>
        </div>

    </div>
    </form>
</asp:Content>
