<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <h2></h2>
    <div id="lists">
        <div id="firstList">
        <h6>Choose your movie:
        </h6>
        <br />
        <%= Html.DropDownList("movieList") %>
        </div>


  
        <!-- SECEOND LIST -->
        <div id="secondList">
         
        <h6>Choose filming location:</h6><br />
        <select id="locationList" name="locationList"></select>
        </div>
        


        <h6>Choose restaurant proximity:</h6><br />
        <%= Html.DropDownList("radiusList") %>
        <br/>

       <br />
        <button name="send" id="send">Check to send</button>

        <h4>Your selection of restaurants:</h4>
        <div id="retInf"><p>Something</p>
        </div>

    </div>
    </form>
</asp:Content>
