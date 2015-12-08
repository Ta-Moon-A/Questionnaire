<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainScoreDifference.aspx.cs" Inherits="MaintainScoreDifference" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">

    <div  class="PageWrapForAdmin">
      <br />
        <br />
         <telerik:RadTextBox runat="server" ID="leveltxt"  Height="40px" Width="100%" Font-Size="18pt" forecolor="Red"></telerik:RadTextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="leveltxt"
                                     ValidationGroup="requiredGroup" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
          <br />
        <br />
        <table>
            <tr>
                <td  style="width:10%">
                    <asp:Label ID="Label1" runat="server" Text="From:" ForeColor="Black"></asp:Label>
                </td>
                <td style="width:10%">
                    <asp:Label ID="Label2" runat="server" Text="To(inclusive):" ForeColor="Black"></asp:Label>
                </td>
                
                <td style="width:70%;text-align:center">
                    <asp:Label ID="Label3" runat="server" Text="Style:" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:10%">
                    <telerik:RadTextBox runat="server" ID="fromtxt" Height="40px" Width="60px"></telerik:RadTextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fromtxt" 
                                                 ValidationGroup="requiredGroup" ValidationExpression="^(\+|-)?\d+$"
                                                 ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td style="width:10%">
                    <telerik:RadTextBox runat="server" ID="totxt" Height="40px" Width="60px"></telerik:RadTextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="totxt" 
                                                 ValidationGroup="requiredGroup" ValidationExpression="^(\+|-)?\d+$"
                                                 ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td style="width:70%;text-align:right">
                     <telerik:RadTextBox runat="server" ID="CSStxt"  Width="300px"></telerik:RadTextBox>
                </td>
            </tr>
            </Table>
           <br />
        <br />
            <Table>
            <tr>
                    <td colspan="2" style="width:250px; color:black"">
                        Primary Prefix:
                        <br />
                        <telerik:RadTextBox runat="server" ID="Primarytxt" Width="200px"></telerik:RadTextBox>
                    </td>
                    <td style="width:250px; color:black"">
                       Secondary Prefix:
                        <br />
                        <telerik:RadTextBox runat="server" ID="Secondarytxt" Width="200px"></telerik:RadTextBox>
                    </td>
                </tr>

            </table>
        <br /><br />
        <br />
        <asp:Label ID="Label4" runat="server" text="Help:" ForeColor="Black"></asp:Label>
        <telerik:RadTextBox runat="server" ID="helptxt" Width="100%" Height="150px"></telerik:RadTextBox>
        <br />
        <br />
         <div style="margin-left:600px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click" ValidationGroup="requiredGroup" ></asp:LinkButton>
       </div>

    </div>
</asp:Content>

