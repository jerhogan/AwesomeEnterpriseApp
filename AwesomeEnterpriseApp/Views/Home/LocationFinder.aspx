<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LocationFinder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
    <h2></h2>
    <div id="lists">
        <div id="firstList">
        <h6>Choose your movie:
        </h6>
        
        <%= Html.DropDownList("movieList") %>
        </div>


  
        <!-- SECEOND LIST -->
         <div id="secondList">
         
        <h6>Choose filming location:</h6>
        <%= Html.DropDownList("locationList") %>
        </div>
        
        <br/>
       

        <h6>Choose restaurant proximity:</h6>
        <select id="radiusList" name="radiusList">
            <option>1km</option>
            <option>2km</option>
            <option>3km</option>
            <option>4km</option>
            <option>5km</option>
        </select>
        <br/>

       <br />
        

        <h4>Your selection of restaurants:</h4>
        <div id="retInf"><p></p>
        </div>

    </div>
    </form>



    



</asp:Content>
