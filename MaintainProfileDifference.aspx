<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainProfileDifference.aspx.cs" Inherits="MaintainProfileDifference" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    
  <script>
      function showpreview(input) {

          if (input.files && input.files[0]) {

              var reader = new FileReader();
              reader.onload = function (e) {
                  $('#<%=iconImage.ClientID %>').css('visibility', 'visible');
                $('#<%=iconImage.ClientID %>').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }

    }
   </script>
    
      <div  class="PageWrapForAdmin">
      <br />
        <br />
         <telerik:RadTextBox runat="server" ID="leveltxt"  Height="40px" Width="100%" Font-Size="18pt" forecolor="Red"></telerik:RadTextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="leveltxt"
                                                ValidationGroup="requiredGroup" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
          <br />
        <br />
        <table>
            <tr>
                <td  style="width:80px">
                    <asp:Label runat="server" Text="From:"></asp:Label>
                </td>
                <td style="width:80px">
                    <asp:Label runat="server" Text="To(inclusive):"></asp:Label>
                </td>
                <td style="width:80px"></td>
                <td style="width:80px">
                    <asp:Label runat="server" Text="Icon:"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width:80px">
                    <telerik:RadTextBox runat="server" ID="fromtxt" Height="40px" Width="60px"></telerik:RadTextBox>
                   <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="fromtxt"
                                                ValidationGroup="requiredGroup" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fromtxt" 
                                                 ValidationGroup="requiredGroup" ValidationExpression="^(\+|-)?\d+$"
                                                 ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td style="width:80px">
                    <telerik:RadTextBox runat="server" ID="totxt" Height="40px" Width="60px"></telerik:RadTextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="totxt"
                                                ValidationGroup="requiredGroup" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="totxt" 
                                                 ValidationGroup="requiredGroup" ValidationExpression="^(\+|-)?\d+$"
                                                 ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td style="width:80px"></td>
                <td style="width:80px">
                    <asp:Image runat="server" ID="iconImage"  />
                </td>
                <td><asp:FileUpload runat="server" ID="IconUpl" onchange="showpreview(this);"/></td>
            </tr>
        </table>
        <br /><br />
        <br />
        <asp:Label runat="server" text="Help:"></asp:Label>
        <telerik:RadTextBox runat="server" ID="helptxt" Width="100%" Height="150px"></telerik:RadTextBox>
        <br />
        <br />
         <div style="margin-left:600px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click" ValidationGroup="requiredGroup" ></asp:LinkButton>
       </div>

    </div>



</asp:Content>

