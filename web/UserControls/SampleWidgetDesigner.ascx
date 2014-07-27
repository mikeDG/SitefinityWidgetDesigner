<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Modules.Forms.Web.UI.Fields" TagPrefix="sfForms" %>
<%@ Register TagPrefix="UC" Namespace="Sample" Assembly="App_Code" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>

<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="width:500px">
    <ol>
        
        <li class="sfFormCtrl">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Heading" CssClass="sfTxtLbl">Heading</asp:Label>
            <asp:TextBox ID="Heading" runat="server" CssClass="sfTxt" MaxLength="500" Width="95%" />
            <div class="sfExample">Widget heading</div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Intro" CssClass="sfTxtLbl">Introduction</asp:Label>
            <sfFields:HtmlField ID="Intro" runat="server" Width="95%" Height="150px" DisplayMode="Write" FixCursorIssue="True" EditorToolsConfiguration="Minimal" />
            <div class="sfExample"></div>
        </li>

         <li class="sfFormCtrl">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="GroupIDs" CssClass="sfTxtLbl">Groups</asp:Label>
            <asp:CheckBoxList ID="GroupIDs" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="ColumnConfig" CssClass="sfTxtLbl"> Columns </asp:Label>
            <UC:ColumnSettingsField ID="ColumnConfig" runat="server" />
            <div class="sfExample">Control columns heading and visibility</div>
        </li>

    </ol>
</div>
