<%@ Page Title="TECHSERV - Manage Links" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="ManageLinks.aspx.vb" Inherits="TECHSERV.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table class="tablecenter tablenospacing tablewidth100 content_text">
        <tr>
            <td class="tabletitle Title">Manage Links</td>
        </tr>
        <tr>
            <td>

                <table class="tablecenter tablenospacing tablewidth100">
                    <tr>
                        <td style="width: 70%;vertical-align:top;">
                            <asp:Panel ID="pnlList" runat="server" style="text-align:left;">
                                <asp:GridView ID="gvLinks" runat="server" CellPadding="2" CssClass="content_text" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="96%" HorizontalAlign="Right" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                        <asp:BoundField DataField="link_description" HeaderText="Link" SortExpression="link_description"/>
                                        <asp:BoundField DataField="link_url" HeaderText="URL" Visible="False" SortExpression="link_url" />
                                        <asp:BoundField DataField="link_category" HeaderText="Category" SortExpression="link_category"/>
                                        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <EditRowStyle BackColor="#66CCFF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </asp:Panel>
                            <br />
                        </td>
                        <td style="text-align: center; vertical-align:top;width:30%;">
                            <br />
                            <asp:Button ID="btnStartNewLink" runat="server" Text="Add Link" />
                            <asp:Panel ID="pnlEditLinks" runat="server" Visible="False">

                            <table class="tablenospacing tablewidth90 tablecenter" style="text-align:right;">
                                <tr>
                                    <td>
                                        Description
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtLinkDescription" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        URL
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtLinkURL" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Category
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:DropDownList ID="ddlLinkCategory" runat="server" style="text-align: left">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                            </asp:Panel>
                            <asp:Label ID="lblDeleteMessage" runat="server" CssClass="content_text" style="text-align: center" Visible="False"></asp:Label>
                            <br />
                                <asp:Button ID="btnLinkAdd" runat="server" Text="Add" Visible="False" />
                                <asp:Button ID="btnLinkUpdate" runat="server" Text="Update" Visible="False" />
                                <asp:Button ID="btnDelete" runat="server" style="height: 26px; width: 55px;" Text="Delete" Visible="False" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" />
                            <br />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

    </asp:Content>
