<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ToggleViewOptions.ascx.vb"
    Inherits="DNNStuff.Favorites.ToggleViewOptions" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnClear">
    <div id="editsettings" class="tabslayout">
        <ul id="editsettings-nav" class="tabslayout">
            <li><a href="#tab1"><span>
                <%= Localization.GetString("TabCaption_Tab1", LocalResourceFile)%></span></a></li>
            <li><a href="#help"><span>
                <%= Localization.GetString("TabCaption_Help", LocalResourceFile)%></span></a></li>
        </ul>
        <div class="tabs-container">
            <div class="tab" id="tab1">
                <div class="dnnFormItem">
                    <dnn:Label ID="plAddMessage" runat="server" ControlName="txtAddMessage" Suffix=":" />
                    <asp:TextBox ID="txtAddMessage" runat="server" CssClass="dnnMaxWidth"></asp:TextBox>
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="plRemoveMessage" runat="server" ControlName="txtRemoveMessage" Suffix=":" />
                    <asp:TextBox ID="txtRemoveMessage" runat="server" CssClass="dnnMaxWidth"></asp:TextBox>
                </div>
            </div>
            <div class="tab" id="help">
                <div>
                    <%=Localization.GetString("DocumentationHelp.Text", LocalResourceFile)%></div>
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
