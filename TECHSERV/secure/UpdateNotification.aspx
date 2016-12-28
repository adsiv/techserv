<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.master" CodeBehind="UpdateNotification.aspx.vb" Inherits="TECHSERV.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style17 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            font-weight: bold;
            font-style: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-align: left;
            height: 22px;
            width: 90%;
        }
        .auto-style19 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: normal;
            font-style: normal;
            color: #000000;
        }
        .auto-style20 {
            width: 508px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table cellpadding="0" cellspacing="0" class="auto-style1" style="margin: 0px; padding: 0px; border-width: 0px; width: 90%;">
        <tr>
            <td style='border-bottom:solid navy 2pt' class="auto-style17">Update Notification</td>
        </tr>
        <tr>
            <td style="text-align: left">

                <asp:Panel ID="pnlEditNotification" runat="server" Visible="False" Width="100%" style="text-align: center">
                                <asp:TextBox ID="txtNotificationText" runat="server" Height="100px" TextMode="MultiLine" Width="75%"></asp:TextBox>
                                <br />
                                <asp:CheckBox ID="chkActive" runat="server" CssClass="content_text" Text="Display Notification" />
                                <br />
                                <asp:Button ID="btnSave" runat="server" Text="Save" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </asp:Panel>
                            <asp:Panel ID="pnlViewNotification" runat="server" Width="100%" style="text-align: center">
                                <asp:Label ID="lblNotificationText" runat="server" CssClass="content_text"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="lblActive" runat="server" CssClass="auto-style19"></asp:Label>
                                <br />
                                <asp:Button ID="btnEditNotification" runat="server" Text="Edit" />
                                <br />
                            </asp:Panel>


                </td>
        </tr>
    </table>
</asp:Content>
