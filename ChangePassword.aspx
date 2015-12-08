<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" MasterPageFile="~/UserPage.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">
    <!DOCTYPE html>
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <html xmlns="http://www.w3.org/1999/xhtml">
    <%--<head runat="server">
    <title></title>
</head>--%>
      
    <body>

        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div class="siteWrap">

            <asp:TextBox runat="server" ID="salutationtxt" CssClass="standInp" ForeColor="Red" Font-Italic="false" />

            <asp:RegularExpressionValidator ID="Emailvalidator" runat="server"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailtxt"
                ErrorMessage="Invalid Email Format!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />

            <asp:RequiredFieldValidator ID="RequiredEmailvalidator" runat="server" ControlToValidate="emailtxt"
                ErrorMessage="Enter the email!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />

            <asp:TextBox runat="server" ID="emailtxt" CssClass="standInp" Font-Italic="false" />


            <br />
            <asp:Label runat="server" Text="If you do not wish to change your password, leave these fields blank" />
            <br />
            <br />

            <asp:RequiredFieldValidator ID="Requiredpassword1validator" runat="server" ControlToValidate="password1"
                ErrorMessage="Enter the Password!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />
           
             <asp:TextBox runat="server" ID="password1" TextMode="Password"  CssClass="standInp"   />


            <asp:RequiredFieldValidator ID="Requiredpassword2Validator" runat="server" ControlToValidate="password2"
                ErrorMessage="Enter the Password!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />
            <asp:CompareValidator ID="ComparePasswords" runat="server" ForeColor="Red" ErrorMessage="Password does not match!"
                ControlToCompare="password1" ControlToValidate="password2" ValidationGroup="RequiredGroup"></asp:CompareValidator>
           
             <asp:TextBox runat="server" ID="password2" TextMode="Password" CssClass="standInp"  />



            <asp:Button runat="server" ID="Savebtn" Text="Save" CssClass="btn orange" ValidationGroup="RequiredGroup" OnClick="Savebtn_Click" />
            <asp:Button runat="server" ID="Cancelbtn" Text="Cancel" CssClass="btn" OnClick="Cancelbtn_Click" />

        </div>


    </body>
    </html>
</asp:Content>
