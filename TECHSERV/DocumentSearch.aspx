<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.master" CodeBehind="DocumentSearch.aspx.vb" Inherits="TECHSERV.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <table class="tablecenter tablenospacing tablewidth100">
        <tr>
            <td class="Title tabletitle">
                Document Search
            </td>
        </tr>
        <tr>
            <td style="text-align:center;" class="content_text">
                <br />

                <table class="tablecenter tablenospacing tablewidth100">
                    <tr>
                        <td style="text-align: right;" class="tablewidth50">
                            Client Number:
                        </td>
                        <td style="text-align: left;" class="tablewidth50">
                            <asp:TextBox ID="txtClientNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;" class="tablewidth50">
                            Account Number:
                        </td>
                        <td style="text-align: left;" class="tablewidth50">
                            <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                <br />
                <br />

                <table class="tablecenter tablenospacing tablewidth30">
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblResults" runat="server" CssClass="content_text"></asp:Label>
                        </td>
                    </tr>
                </table>

                <br />
                <br />
            </td>
        </tr>
    </table>

</asp:Content>
