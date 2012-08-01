<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <h2 style="margin-left:4%">Welcome!</h2>
    <div id="lists">
    
       <div id="firstList" style="margin-left:30px;margin-bottom:30px">
        <h6>Choose your movie:
        </h6>
        
        <%= Html.DropDownList("movieList") %>
       </div>


  
        <!-- SECOND LIST -->
       <div id="secondList" style="margin-left:30px;margin-bottom:30px">
         
        <h6>Choose filming location:</h6>
        <select id="locationList" name="locationList"></select>
        
      
        

        <h6 >Choose restaurant proximity:</h6>
        <select id="radiusList" name="radiusList">
            <option>1km</option>
            <option>2km</option>
            <option>3km</option>
            <option>4km</option>
            <option>5km</option>
        </select>
       </div>

    </div>

    
      <div id="retInf">
        <h4>Your selection of restaurants:</h4>
        <p></p>
      </div>
    </form>
</asp:Content>
