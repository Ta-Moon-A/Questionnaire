<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainProfile.aspx.cs" Inherits="MaintainProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="Server">
    <br />
  
    <div class="PageWrapForAdmin">

        <div style="float:left; margin-top:10px;">
            <asp:Label ID="Label1" runat="server" Text="Maintain Profile" font-name="Franklin Gothic Medium Cond"
                       Font-Size="24pt" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <br />
        <br />

        <table>
            
                <tr>
                    <telerik:RadTextBox runat="server" ID="surnametxt" Width="500px" Height="50px" font-size="24pt"
                                        placeholder="Surname" ForeColor="Red" MaxLength="50"></telerik:RadTextBox>
                </tr>
                <br />
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="First Name:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                    <br />
                    <telerik:RadTextBox runat="server" ID="firstnametxt"></telerik:RadTextBox>
                </tr>
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="Salutation:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                    <br />
                    <telerik:RadTextBox runat="server" ID="salutationtxt"></telerik:RadTextBox>
                </tr>
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="Organisation:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                    <br />
                    <telerik:RadTextBox runat="server" ID="organisationtxt"></telerik:RadTextBox>
                </tr>
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="Email:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                    <br />
                    <telerik:RadTextBox runat="server" ID="Emailtxt"></telerik:RadTextBox>
                     <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Emailtxt" ForeColor="Red" ValidationGroup="requiredGroup"> * </asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                     ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Emailtxt"
                                                     ErrorMessage="Invalid Email Format!" ForeColor="Red" ValidationGroup="requiredGroup" Display="Dynamic" />
                </tr>
                
                <tr>
                    <br />
                <br />
                    <asp:Label runat="server" Text="Password:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana" TextMode="Password"></asp:Label>
                    <br />
                   <asp:TextBox runat="server" ID="passwordtxt" TextMode="Password" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="passwordtxt" ForeColor="Red" ValidationGroup="requiredGroup"> * </asp:RequiredFieldValidator>
                </tr>
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="Group:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                    <br />
                    <telerik:RadDropDownList runat="server" ID="groupDDL"></telerik:RadDropDownList>
                </tr>
                <br />
                <br />
                <tr>
                    <asp:Label runat="server" Text="Reference Profile:" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                 </tr>
            </table>
                    <asp:CheckBox runat="server" ID="refProfilechk"  />
                 <br />
             
            
            <br />
            <br />
                <div style="margin-left:350px">
                    <telerik:RadButton runat="server" ID="cancelBtn" Text="Cancel"  OnClick="cancelBtn_Click"></telerik:RadButton>
                    
                    <telerik:RadButton runat="server" ID="savebtn" Text="Save"  OnClick="savebtn_Click" ValidationGroup="requiredGroup"></telerik:RadButton>
                 </div>
                
           


        
        
    </div>

</asp:Content>

