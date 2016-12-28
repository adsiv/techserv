<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="ManageHardwareList.aspx.vb" Inherits="TECHSERV.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <table class="tablenospacing tablecenter tablewidth100 content_text">
        <tr>
            <td class="tabletitle Title">Manage Hardware</td>
        </tr>
        <tr>
            <td>

                <table class="tablenospacing tablecenter tablewidth100">
                    <tr>
                        <td style="vertical-align: top; width:45%;">
                            <asp:GridView ID="gvItemList" runat="server" CellPadding="2" CssClass="content_text" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="95%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID"/>
                                    <asp:BoundField DataField="hardware_name" HeaderText="Item" />
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
                        <td style="vertical-align: top; text-align: center;">
                            <asp:Button ID="btnStartNewItem" runat="server" Text="Add Item" />

                            <asp:Panel ID="pnlEditItem" runat="server" Visible="False">

                                <table class="tablecenter tablenospacing tablewidth100">
                                    <tr>
                                        <td style="text-align: right; vertical-align: top;">
                                            Name
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:TextBox ID="txtItemName" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; vertical-align: top;">
                                            US Price $
                                        </td>

                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtItemUSPrice" runat="server" Width="75px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right; width:82px; vertical-align: top;">
                                            CAN Price $
                                        </td>
                                        <td style="vertical-align: top; text-align: left;">
                                            <asp:TextBox ID="txtItemCANPrice" runat="server" Width="75px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; vertical-align: top;">
                                            Interface
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:TextBox ID="txtItemInterface" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; vertical-align: top;">
                                            Additional Charges<br /><i>(leave blank to hide)</i>
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:TextBox ID="txtItemAdditionalCharges" runat="server" Width="250px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; vertical-align: top;">
                                            Type
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:DropDownList ID="ddlItemType" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; text-align: right;">
                                            Category
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:DropDownList ID="ddlItemCategory" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  style="text-align: right; vertical-align: top;">
                                            Details<br /><i>(leave blank to hide)</i>
                                        </td>
                                        <td style="text-align:left;" colspan="3">
                                            <asp:TextBox ID="txtItemDetails" runat="server" Height="100px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>

                            <asp:Label ID="lblDeleteMessage" runat="server" CssClass="content_text"></asp:Label>
                            <br />
                            <asp:Button ID="btnItemAdd" runat="server" Text="Add" Visible="False" />
                            <asp:Button ID="btnItemUpdate" runat="server" Text="Update" Visible="False" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" style="height: 26px" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

</asp:Content>
