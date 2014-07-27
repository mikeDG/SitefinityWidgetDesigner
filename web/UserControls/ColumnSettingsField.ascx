<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sfFields"  %>
<asp:Label ID="titleLabel" runat="server" CssClass="sfTxtLbl" />


<asp:HiddenField ID="ValueField" runat="server" Value="" />

<asp:Panel ID="FieldPanel" runat="server">
    <asp:Repeater ID="FieldRepeater"  runat="server">
        <HeaderTemplate>
            <table class="Table1">
            <tr>
                <th></th>
                <th>Visible</th>
                <th>Heading</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr runat="server" id="FieldTr">
                <td>
                    <asp:label ID="IDLabel" runat="server" Font-Bold="true" />
                </td>
                <td>
                   <input type="checkbox" class="_Visible" /> 
                </td>
                <td>
                    <input type="text" class="_Heading" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>

  
<sf:SitefinityLabel ID="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel ID="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />

<style type="text/css">
.Table1 td, .Table1 th
{
    padding:5px;
}
</style>
