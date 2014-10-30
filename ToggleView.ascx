<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ToggleView.ascx.vb" Inherits="DNNStuff.Favorites.ToggleView" %>
<%@ Register TagPrefix="dnnstuff" TagName="ToggleControl" Src="ToggleControl.ascx" %>
<dnnstuff:ToggleControl ID="lbToggle" Runat="server"></dnnstuff:ToggleControl>
<input type="hidden" value="" id="favorite_title" name="favorite_title" />