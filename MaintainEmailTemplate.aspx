<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainEmailTemplate.aspx.cs" Inherits="MaintainEmailTemplate" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    <br />
    <div class="PageWrapForAdmin">
    <table style="width: 70%" cellpadding="5" cellspacing="5" border="0">
    <tr>
        <td>
            <asp:Label ID="TemplateLabel" runat="server" Text="Template:"></asp:Label>
            <asp:Label ID="ReqTemplateLabel" runat="server" Text="*" ForeColor="Red"></asp:Label>
        </td>
        <td>
            <telerik:RadDropDownList ID="TemplateDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TemplateDropDownList_SelectedIndexChanged"></telerik:RadDropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
           
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="FromLabel" runat="server" Text="From:"></asp:Label>
            <asp:Label ID="ReqFromLabel" runat="server" Text="*" ForeColor="Red"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="FromEmailTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <telerik:RadTextBox ID="FromEmailTitleTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="FromEmailRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="FromEmailTextBox" ValidationGroup="EmailTemplateVG" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="FromEmailRegex" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="FromEmailTextBox" ErrorMessage="*" Display="Dynamic" ValidationGroup="EmailTemplateVG"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="CCLabel" runat="server" Text="CC:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="CCTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <telerik:RadTextBox ID="CCTitleTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <asp:RegularExpressionValidator ID="CCRegex" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="CCTextBox" ErrorMessage="*" Display="Dynamic" ValidationGroup="EmailTemplateVG"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="BCCLabel" runat="server" Text="BCC:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="BCCTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <telerik:RadTextBox ID="BCCTitleTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <asp:RegularExpressionValidator ID="BCCRegex" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="BCCTextBox" ErrorMessage="*" Display="Dynamic" ValidationGroup="EmailTemplateVG"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="SubjectLabel" runat="server" Text="Subject:"></asp:Label>
            <asp:Label ID="ReqSubjectLabel" runat="server" Text="*" ForeColor="Red"></asp:Label>
        </td>
        <td colspan="2">
            <telerik:RadTextBox ID="SubjectTextBox" runat="server" Width="100%"></telerik:RadTextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="SubjectTextBox" ValidationGroup="EmailTemplateVG"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="BodyLabel" runat="server" Text="Body:"></asp:Label>
            <asp:Label ID="ReqBodyLabel" runat="server" Text="*" ForeColor="Red"></asp:Label>
        </td>
        <td></td>
        <td></td>

    </tr>
    <tr>
        <td colspan="3">
             <telerik:RadTextBox ID="BodyTextBox" runat="server" TextMode="MultiLine" Style="overflow:hidden"
                  Width="100%" Height="300"></telerik:RadTextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="BodyRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="BodyTextBox" ValidationGroup="EmailTemplateVG"></asp:RequiredFieldValidator></td>
    </tr>
</table>

        <table style="width: 50%">


            <tr>
                <td>
                    <asp:Label ID="FirstnameLabel" runat="server" Text="{first name}"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Surname" runat="server" Text="{surname}"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="salutation" runat="server" Text="{salutation}"></asp:Label></td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="organisation" runat="server" Text="{organisation}"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="profilelink" runat="server" Text="{profilelink}"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Email" runat="server" Text="{email}"></asp:Label></td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="password" runat="server" Text="{password}"></asp:Label></td>
            </tr>
 </table>
<table style="width: 70%">
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            <asp:Label ID="ConfirmationPageLabel" runat="server" Text="Confirmation page:" Font-Italic="true"></asp:Label>
         </td>
        <td>
           <telerik:RadTextBox  ID="ConfirmationPageTextBox" runat="server" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td>
        <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="CancelButton_Click"></asp:LinkButton>
                    
        <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="SaveButton_Click" ValidationGroup="requiredgroup" ></asp:LinkButton>
      
   </td> </tr>
</table>

</div>





</asp:Content>

