<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ToggleViewOptions.ascx.vb"
    Inherits="DNNStuff.Favorites.ToggleViewOptions" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnClear">
    <div id="editsettings" class="tabslayout">
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

