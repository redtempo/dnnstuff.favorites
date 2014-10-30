<%@ Control Language="vb" CodeBehind="ViewOptions.ascx.vb" AutoEventWireup="false"
    Explicit="True" Inherits="DNNStuff.Favorites.ViewOptions" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnClear">
    <div id="editsettings" class="tabslayout">
        <ul id="editsettings-nav" class="tabslayout">
            <li><a href="#tab1"><span>
                <%= Localization.GetString("TabCaption_Tab1", LocalResourceFile)%></span></a></li>
            <li><a href="#help"><span>
                <%=Localization.GetString("TabCaption_Help", LocalResourceFile)%></span></a></li>
        </ul>
        <div class="tabs-container">
            <div class="tab" id="tab1">
                <div class="dnnFormItem">
                    <dnn:Label ID="plHeader" runat="server" ControlName="txtHeader" Suffix=":" />
                    <asp:TextBox ID="txtHeader" runat="server" CssClass="dnnMaxWidth" Rows="4" TextMode="MultiLine" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plBody" runat="server" ControlName="txtBody" Suffix=":" />
                    <asp:TextBox ID="txtBody" runat="server" CssClass="dnnMaxWidth" Rows="8" TextMode="MultiLine" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plFooter" runat="server" ControlName="txtFooter" Suffix=":" />
                    <asp:TextBox ID="txtFooter" runat="server" CssClass="dnnMaxWidth" Rows="4" TextMode="MultiLine" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plEmpty" runat="server" ControlName="txtEmpty" Suffix=":" />
                    <asp:TextBox ID="txtEmpty" runat="server" CssClass="dnnMaxWidth" Rows="4" TextMode="MultiLine" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plUnathenticated" runat="server" ControlName="txtUnathenticated" Suffix=":" />
                    <asp:TextBox ID="txtUnathenticated" runat="server" CssClass="dnnMaxWidth" Rows="4" TextMode="MultiLine" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plUseFullUrl" runat="server" ControlName="chkUseFullUrl" Suffix=":" />
                    <asp:CheckBox ID="chkUseFullUrl" runat="server" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plMaxTitleChars" runat="server" ControlName="txtMaxTitleChars" Suffix=":" />
                    <asp:TextBox ID="txtMaxTitleChars" runat="server" Width="5%" CssClass="dnnNoMinWidth" />
                </div>
            </div>
            <div class="tab" id="help">
                <div>
                    <%=Localization.GetString("DocumentationHelp.Text", LocalResourceFile)%></div>
                <div>
                    <span>Tokens for Body:</span>
                    <ul>
                        <li>[IMAGEURL] - url to the site images folder</li>
                        <li>[TITLE] - this is a safe page title which displays the page title if it contains
                            text, otherwise it displays the page name</li>
                        <li>[NAME] - displays the page name</li>
                        <li>[URL] - the page url</li>
                        <li>[LINKNAME] - shows a link to the page using the safe title as the link title (tool
                            tip) and the page name as the link text</li>
                        <li>[LINKTITLE] - shows a link to the page using the safe title as the link title (tool
                            tip) and the page title as the link text</li>
                        <li>[LINK] - functionally equivalent to [LINKNAME]</li>
                        <li>[DELETEACTION] - shows the delete link so the favorite can be removed from the list</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <ul class="dnnActions dnnClear">
        <li>
            <asp:LinkButton ID="cmdUpdate" Text="Update" resourcekey="cmdUpdate" CausesValidation="True"
                runat="server" CssClass="dnnPrimaryAction" /></li>
        <li>
            <asp:LinkButton ID="cmdCancel" Text="Cancel" resourcekey="cmdCancel" CausesValidation="False"
                runat="server" CssClass="dnnSecondaryAction" /></li>
    </ul>
</div>
<script type="text/javascript">
    var tabber1 = new Yetii({
        id: 'editsettings',
        persist: true
    });
</script>
