<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AwesomeEnterpriseApp.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="genForm">
    <h2>Create a New Account</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>
                
                <p>
                    <input type="submit" value="Save" />
                </p>
            </fieldset>
        </div>
    <% } %>

    </div>

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
                    <label>Take Away -------------------------------> Fine Dining</label>
                </div>
                <div class="editor-field">
                   <input class="radio" type="radio" name="fancy" value="1" />
                    <input class="radio" type="radio" name="fancy" value="2" />
                     <input class="radio" type="radio" name="fancy" value="3" />
                      <input class="radio" type="radio" name="fancy" value="4" />
                       <input type="radio" class="radio" name="fancy" value="5" />
                </div>
                
                <div class="editor-label">
                    <label>Restaurant website</label>
                </div>
                <div class="editor-field">
                    <input type="text" name="website" />
                </div>

                <div class="editor-label">
                    <label>Restaurant address</label>
                </div>
                <div class="editor-field">
                    <input type="text" name="line1" />
                    <input type="text" name="line2" />
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
