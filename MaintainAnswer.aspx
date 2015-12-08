<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainAnswer.aspx.cs" Inherits="MaintainAnswer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    <div class="PageWrapForAdmin">
        <br />
        <br />
        <asp:Label runat="server" ID="AnswerCategoryLbl" font-size="18pt" Text="" Visible="false"></asp:Label>
        <br />
        <br />


        <div style="margin-top:0px">
        <table>
            <tr>
                <asp:RequiredFieldValidator runat="server" ID="contentvalidator" ControlToValidate="AnswerContenttxt" ErrorMessage="Enter The Answer" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                <td><telerik:RadTextBox runat="server" ID="AnswerContenttxt" Width="685" Height="170" TextMode="MultiLine" ForeColor="Red" Font-Size="24pt"></telerik:RadTextBox></td>
                <td>
                    <div style="margin-top:0px">
                     <asp:label runat="server" ID="orderlbl" text="Order: " ForeColor="Black"></asp:label>
                       <br />
                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ordertxt"
                              ErrorMessage="Enter The Order" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator Id="RegularExpressionValidator3" RunAt="server" ControlToValidate="ordertxt"
                                             ValidationExpression="^[-+]?[0-9]*\.?[0-9]*([eE][-+]?[0-9]+)?$" ErrorMessage="Enter the Number for Order!"
                                             ValidationGroup="requiredgroup" ForeColor="Red">*</asp:RegularExpressionValidator>
                     <telerik:RadTextBox runat="server" ID="ordertxt" Width="50px" Height="50px"></telerik:RadTextBox>
                       <br />
                       
                     <asp:Label runat="server" ID="idlbl" text="ID: " ForeColor="Black" ></asp:Label>
                       <br />
                       <br />
                     <telerik:RadTextBox runat="server" ID="idtxt" Width="50px" Height="50px" Enabled="false"></telerik:RadTextBox>
                      
                   </div>
               </td>
            </tr>
        </table>
        </div>


        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Score:" Width="65px" ForeColor="Black"></asp:Label>
                    <br />   
                    <br />
                     <telerik:RadTextBox runat="server" ID="Scoretxt" Width="60px"></telerik:RadTextBox>
                     <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="Scoretxt"
                          ErrorMessage="Enter The Score" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator Id="RegularExpressionValidator4" RunAt="server" ControlToValidate="Scoretxt"
                                             ValidationExpression="^-?[0-9]{1,12}(?:\.[0-9]{1,4})?$" ErrorMessage="Enter the Number for Order!"
                                             ValidationGroup="requiredgroup" ForeColor="Red">*</asp:RegularExpressionValidator>   
               </td>
                <td style="width:30px"></td>
                
               <td>
                    <asp:Label ID="Label3" runat="server" Text="RGB Colour:"  ForeColor="Black"></asp:Label> 
                    <br />      
                   <br /> 
                   
                   <telerik:RadTextBox runat="server" ID="Rcolourtxt" Width="40px" MaxLength="3"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="Rcolourtxt"
                                   ErrorMessage="Enter Red Colour" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Id="vldRegex" RunAt="server" ControlToValidate="Rcolourtxt"
                                             ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$" ErrorMessage="Enter the  Number from 0 to 255!"
                                             ValidationGroup="requiredgroup" ForeColor="Red">*</asp:RegularExpressionValidator>
                    <telerik:RadTextBox runat="server" ID="Gcolourtxt"  Width="40px" MaxLength="3"></telerik:RadTextBox>  
                               <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="Gcolourtxt"
                                   ErrorMessage="Enter Green Colour" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Id="RegularExpressionValidator1" RunAt="server" ControlToValidate="Gcolourtxt"
                                     ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$"  ErrorMessage="Enter the  Number from 0 to 255!"
                                    ValidationGroup="requiredgroup" ForeColor="Red">*</asp:RegularExpressionValidator>
                    <telerik:RadTextBox runat="server" ID="bColourtxt"  Width="40px" MaxLength="3"></telerik:RadTextBox>   
                               <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="bColourtxt"
                                   ErrorMessage="Enter Blue Colour" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator Id="RegularExpressionValidator2" RunAt="server" ControlToValidate="bColourtxt"
                                    ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$"  ErrorMessage="Enter the  Number from 0 to 255!"
                                    ValidationGroup="requiredgroup" ForeColor="Red" >*</asp:RegularExpressionValidator>
                      
                </td>
            </tr>
        </table>
                    
          
        <br />
        <asp:label runat="server" text="Help: " forecolor="Black"></asp:label>
        <br />
        <telerik:RadTextBox runat="server" ID="Helptxt" Width="750" Height="80px" TextMode="MultiLine"></telerik:RadTextBox>
        <br /><br />
        <div style="margin-left:10px">
            
           <asp:ValidationSummary ID="ValidationSummary_overhead_estimate" runat="server" ForeColor="Red"
                                   DisplayMode="BulletList" HeaderText=""  ValidationGroup="requiredgroup" />
         </div>
        <br />
        <div style="margin-left:600px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click" ValidationGroup="requiredgroup" ></asp:LinkButton>
       </div>
        
       
    </div>
</asp:Content>

