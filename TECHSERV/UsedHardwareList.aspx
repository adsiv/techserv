<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="UsedHardwareList.aspx.vb" Inherits="TECHSERV.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <table class="tablecenter tablenospacing tablewidth100 content_text">
        <tr>
            <td class="tabletitle Title">Used Hardware Lookup</td>
        </tr>
        <tr>
            <td> 

                <table class="tablecenter tablenospacing tablewidth100">
                    <tr>
                        <td style="min-width:275px;width: 33%; vertical-align: top; text-align: left;">

                            <br />
                            <asp:GridView ID="gvUsedCategoryList" runat="server" CellPadding="2" CssClass="content_text" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="95%" ShowHeader="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CategoryType" HeaderText="Item Type"/>
                                    <asp:BoundField DataField="CategoryCount" HeaderText="Count" />
                                    <asp:CommandField ShowSelectButton="True" SelectText="View Items" />
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
                        <td style="width: 33%; vertical-align: top; text-align: left;">
                            <asp:Label ID="lblSelectedItemType" runat="server" CssClass="content_text"></asp:Label>
                            <asp:GridView ID="gvFilteredItems" runat="server" CellPadding="2" CssClass="content_text" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="95%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="used_serial" HeaderText="Serial Number"/>
                                    <asp:BoundField DataField="used_price" HeaderText="Price" />
                                    <asp:CommandField ShowSelectButton="True" SelectText="View" />
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

                        <td style="vertical-align: top; text-align: left">
                            <asp:Label ID="lblSelectedItemDetails" runat="server" CssClass="content_text"></asp:Label>
                        </td>
                    </tr>
                </table>
                
            </td>

        </tr>
        <tr>
            <td colspan="3">
                <hr />
                <asp:HyperLink ID="hlEditUsedHardwareList" runat="server" NavigateUrl="~/secure/ManageUsedHardware.aspx">Edit Used Hardware List</asp:HyperLink>
            </td>
        </tr>
        

    </table>

    
</asp:Content>
