<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="HardwareList.aspx.vb" Inherits="TECHSERV.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
    <script language="javascript" type="text/javascript">

        function printDiv(divID)
        {
            var divElements = document.getElementById(divID).innerHTML;
            var oldPage = document.body.innerHTML;
            document.body.innerHTML = "<html><head><title></title></head><body>" + divElements + "</body>";
            window.print();
            document.body.innerHTML = oldPage;
        }
        </script>

    <table class="tablecenter tablenospacing tablewidth100 content_text" >
        <tr>
            <td style="vertical-align: top; width: 50px">
                <a href="javascript: printDiv('printablediv')">
                    <img src="images/print.png" border ="0"/>
                </a>
            </td>
            <td>

                <div id="printablediv">

                    <table class="tablenospacing tablewidth100 tablecenter" style="text-align: left; vertical-align: top;">
                        <tr>
                            <td style="width: 33%; vertical-align: top;">
                                <asp:Label ID="lblCheckinList" runat="server"></asp:Label>
                            </td>
                            <td style="width: 33%; vertical-align: top;">
                                <asp:Label ID="lblPOSList" runat="server"></asp:Label>
                            </td>
                            <td style="width: 33%; vertical-align: top;">
                                <asp:Label ID="lblOtherList" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <br />

                </div>

            </td>
        </tr>
    </table>
    
</asp:Content>
