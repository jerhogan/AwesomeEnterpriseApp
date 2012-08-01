<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AwesomeEnterpriseApp.DataAccessLayer.RestaurantDAL>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RestaurantDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="restForm">
     <h2>Set up your restaurant profile</h2>
    <p>
        
    </p>

    <form id="myform" method="post" action='<%= Url.Action("RestaurantDetails/callRestaurantDetails") %>'>

    
        <%: Html.ValidationSummary(true, "Profile creation was unsuccessful. Please correct the errors and try again.") %>
        
            <fieldset>
                <legend>Restaurant Information</legend>
                
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
                   <input class="radio" type="radio" name="fanciness" value="1" />
                 
                    <input class="radio" type="radio" name="fanciness" value="2" />
                  
                     <input class="radio" type="radio" name="fanciness" value="3" />
                     
                      <input class="radio" type="radio" name="fanciness" value="4" />
                     
                       <input type="radio" class="radio" name="fanciness" value="5" />
                </div>
                <br />
                <br />
                <div class="editor-label">
                    <label>Restaurant website</label>
                </div>
                
                <div class="editor-field">
                    <input type="text" name="websiteURL" />
                </div>
                   <br />
                <div class="editor-label">
                    <label>Restaurant address</label>
                </div>
             
                <div class="editor-field">
                   <label>House number</label>
                    <input type="text" name="houseNumber" /><br />
                   <label>Street 1</label>
                    <input type="text" name="streetAddress1" /><br />
                   <label>Street 2</label> 
                    <input type="text" name="streetAddress2" /><br />
                   <label>City</label> 
                    <input type="text" name="zipCode" /><br />
                   <label>Zip code</label>
                    <input type="text" name="city" /><br />

                   <label>Latitude</label> 
                    <input type="text" name="x" /><br />
                   <label>Longtitude</label>
                    <input type="text" name="y" />

                </div>
                <p>
                    <input type="submit" value="Register" />
                    <script type="text/javascript">
                    
                        $(document).ready(function () {
                          $('input[type="submit"]').click(function(){
                            $("#info").fadeIn().delay(15000).fadeOut();
                            });
                        });
                    
                    </script>

                </p>
                <p id="info">Your restaurant profile has been saved.</p>
            </fieldset>
            </form>
        </div>
    
</asp:Content>
