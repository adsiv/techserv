<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="ManageUsedHardware.aspx.vb" Inherits="TECHSERV.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
    <table class="tablewidth100 tablecenter tablenospacing content_text">
        <tr>
            <td class="tabletitle Title" colspan="2">
                Manage Used Hardware
            </td>
        </tr>
        <tr>
            <td>

                <table class="tablewidth100 tablenospacing">
                    <tr>
                        <td style="vertical-align:top; text-align:center; width:45%;">
                            <asp:GridView ID="gvUsedItemList" runat="server" CellPadding="2" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="90%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="used_type" HeaderText="Item Type"/>
                                    <asp:BoundField DataField="used_serial" HeaderText="Serial Number" />
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
                        </td>
                        <td style="vertical-align: top; text-align: center">
                            <asp:Button ID="btnNewEntry" runat="server" Text="New Entry" />
                            <asp:Panel ID="pnlEditItem" runat="server" Visible="False">

                            <table class="tablenospacing tablewidth100" style="text-align:right;">
                                <tr>
                                    <td style="vertical-align:top;">
                                        Item Type
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:DropDownList ID="ddlUsedItemType" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align:top;">
                                        Serial Number
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtUsedItemSerialNumber" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align:top;">
                                        Price
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtUsedItemPrice" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align:top;">
                                        Description
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtUsedItemDescription" runat="server" Height="100px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            </asp:Panel>
                            <br />
                            <asp:Label ID="lblDeleteMessage" runat="server"></asp:Label>
                            <br />
                            <asp:Button ID="btnItemAdd" runat="server" Text="Add" Visible="False" />
                            <asp:Button ID="btnItemUpdate" runat="server" Text="Update" Visible="False" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

    <br />
    <asp:HyperLink ID="hlViewUsedHardwareList" runat="server" CssClass="content_text" NavigateUrl="~/UsedHardwareList.aspx">View Used Hardware List</asp:HyperLink>
</asp:Content>
