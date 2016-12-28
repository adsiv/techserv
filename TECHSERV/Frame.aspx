<%@ Page Title="TECHSERV - Hardware Setup" Language="vb" AutoEventWireup="false" MasterPageFile="~/TechservM.Master" CodeBehind="Frame.aspx.vb" Inherits="TECHSERV.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
  
    <table class="tablecenter tablenospacing tablewidth100">
        <tr>
            <td style="vertical-align:top; width: 50px;">
   
                <a href="javascript:iPrint(frame1);">
                    <img src="images/print.png" alt="Print instructions without TECHSERV menu." border="0" style="float: left" />
                </a>
            </td>
            <td style="min-width: 600px;">
                    <iframe id="frame1" style="border-style:none; margin-top:0px;min-width:600px;" class="tablewidth100" src="<%=strPageLoad%>" onload="javascript:resizeIframe(this);" scrolling="no"></iframe>
            </td>
        </tr>
    </table>
   
        
    
    
    <script language="javascript" type="text/javascript">
        function resizeIframe(obj)
        {
            obj.style.height = obj.contentWindow.document.body.scrollHeight + 20 + 'px';
        }

        function iPrint(ptarget)
        {
            ptarget.focus();
            ptarget.print();
        }
    </script>

</asp:Content>
