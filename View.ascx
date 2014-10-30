<%@ Control Language="vb" AutoEventWireup="false" Inherits="DNNStuff.Favorites.View" CodeBehind="View.ascx.vb" %>
<asp:PlaceHolder id="phText" runat="server" />
<asp:Repeater ID="dlUrls" Runat="server">
    <HeaderTemplate />
	<ItemTemplate />
    <FooterTemplate />
</asp:Repeater>
