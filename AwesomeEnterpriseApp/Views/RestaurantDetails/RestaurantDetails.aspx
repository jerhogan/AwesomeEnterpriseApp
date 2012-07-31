<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AwesomeEnterpriseApp.DataAccessLayer.RestaurantDAL>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RestaurantDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="restForm">
     <h2>Set up your restaurant profile:</h2>
    <p>
        
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Restaurant Infromtion</legend>
                
                <div class="editor-label">
                    <label>Restaurant name</label>
                   
                </div>
                <div class="editor-field">
                    <input type="text" name="name"/>
                </div>
                
                <div class="editor-label">
                   <label>Restaurant cuisine</label>
                </div>
                <div class="editor-field">
                    <select name="cuisine">
                        <option>Italian</option>
                        <option>Mexican</option>
                        <option>Turkish</option>
                        <option>Chinese</option>
                        <option>Russian</option>
                        <option>Carribean</option>
                        
                    </select>
                </div>
                
                <div class="editor-label">
                    <label>Take Away ------------------------> Fine Dining</label>
                </div>
                <div class="editor-field">
                   <input class="radio" type="radio" name="fancy" value="1" />
                    <input class="radio" type="radio" name="fancy" value="2" />
                     <input class="radio" type="radio" name="fancy" value="3" />
                      <input class="radio" type="radio" name="fancy" value="4" />
                       <input type="radio" class="radio" name="fancy" value="5" />
                </div>
                <br />
                <br />
                <div class="editor-label">
                    <label>Restaurant website</label>
                </div>
                
                <div class="editor-field">
                    <input type="text" name="website" />
                </div>
                   <br />
                <div class="editor-label">
                    <label>Restaurant address</label>
                </div>
             
                <div class="editor-field">
                    <input type="text" name="line1" /><br />
                    <input type="text" name="line2" /><br />
                    <input type="text" name="line3" />

                </div>
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
    </div>

</asp:Content>
