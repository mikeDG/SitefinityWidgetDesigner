<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SampleUserControl.ascx.cs" Inherits="Sample.SampleUserControl" %>

<h1>
    <asp:Label ID="HeadingLabel" runat="server" />
</h1>
<br />

<div>
    Intro: <br />
    <asp:Label ID="IntroLabel" runat="server" /> 
</div>
<br />

<div>
    Groups: <asp:Label ID="GroupsLabel" runat="server" />
</div>
<br />

<h3>Columns</h3>
<asp:Repeater ID="ColRepeater" runat="server">
    <HeaderTemplate>
        <table class="Table1">
        <tr>
            <th>ID</th>
            <th>Visible</th>
            <th>Heading</th>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("ID") %></td>
            <td><%#Eval("Visible") %></td>
            <td><%#Eval("Heading") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<style type="text/css">
.Table1 th, .Table1 td
{
    padding:5px;
}
</style>