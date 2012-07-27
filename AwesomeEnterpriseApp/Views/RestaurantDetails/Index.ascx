<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeEnterpriseApp.Models.Restaurant>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                name
            </th>
            <th>
                cuisine
            </th>
            <th>
                fanciness
            </th>
            <th>
                websiteUrl
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.name %>
            </td>
            <td>
                <%: item.cuisine %>
            </td>
            <td>
                <%: item.fanciness %>
            </td>
            <td>
                <%: item.websiteUrl %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


