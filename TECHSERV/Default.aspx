<%@ Page Title="TECHSERV" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="Default.aspx.vb" Inherits="TECHSERV.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Panel ID="pnlNotification" runat="server" Visible="False">

        <table class="tablenotification">
            <tr>
                <td>
                    <asp:Label ID="lblNotification" runat="server" CssClass="content_text"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlLinksOnly" runat="server">

        <table class="tablenospacing tablewidth70 tablecenter content_text">
            <tr>
                <td aria-sort="none" style="width:50%;vertical-align: top; text-align: left;">
                    <asp:Label ID="lblList1" runat="server"></asp:Label>
                </td>
                <td aria-sort="none" style="width:50%;vertical-align: top; text-align: left;">
                    <asp:Label ID="lblList2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlSmallLinks" runat="server" Visible="False" CssClass ="content_text">
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </asp:Panel>

    <br />
        
</asp:Content>
