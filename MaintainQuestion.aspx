<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainQuestion.aspx.cs" Inherits="MaintainQuestion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    <div class="PageWrapForAdmin">
        <div style="margin-top:0px">
        <table>
            <tr>
                <asp:RequiredFieldValidator runat="server" ID="contentvalidator" ControlToValidate="Questiontxt" ErrorMessage="Enter The Answer" ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                <td><telerik:RadTextBox runat="server" ID="Questiontxt" Width="685" Height="170" TextMode="MultiLine" ForeColor="Red" Font-Size="24pt"></telerik:RadTextBox></td>
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
                       
                     <%--<asp:Label runat="server" ID="Weightlbl" text="Weight: " ForeColor="Black" ></asp:Label>
                       <br />
                       <br />
                     <telerik:RadTextBox runat="server" ID="weighttxt" Width="50px" Height="50px" ></telerik:RadTextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="weighttxt"
                               ForeColor="Red" ValidationGroup="requiredgroup">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" RunAt="server" ControlToValidate="weighttxt"
                                             ValidationExpression="^-?[0-9]{1,12}(?:\.[0-9]{1,4})?$" ValidationGroup="requiredgroup" ForeColor="Red">*</asp:RegularExpressionValidator>
                     --%>
                   </div>
               </td>
            </tr>
        </table>
        </div>

        <div>
            <table>
                <tr>
                    <td>
                        Type of Answers:
                    </td>
                    <td></td>
                   <%-- <td>
                        Question Groups:
                    </td>--%>
                </tr>
                <tr>
                    <td>
                        <telerik:RadDropDownList runat="server" ID="answerCategoryDDL"></telerik:RadDropDownList>
                    </td>
                    <td></td>
                    <%--<td>
                        <telerik:RadDropDownList runat="server" ID="QuestionGroupDDL"></telerik:RadDropDownList>
                    </td>--%>
                </tr>
            </table>



        </div>
        <br />
        <br />
        <div style="margin-left:450px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click" ValidationGroup="requiredgroup"></asp:LinkButton>
                 </div>



    </div>


</asp:Content>

