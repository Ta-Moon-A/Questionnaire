<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="loginForm" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="topBanner">
            <img src="img/logo.gif" />
        </div>

        <div class="siteWrap">
            <img src="img/culturalDiagnostics.gif" class="slogan" />
            <br />
            <br />
            <br />
            <br />
            <div>
                   <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailtxt"
                        ErrorMessage="Invalid Email Format!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="emailtxt"
                        ErrorMessage="Enter the email!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />
            </div>
                     <asp:TextBox runat="server" ID="emailtxt" CssClass="standInp" placeholder="email" />
            <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passwordtxt"
                        ErrorMessage="Enter the password!" ForeColor="Red" ValidationGroup="RequiredGroup" Display="Dynamic" />
            </div>
                    <asp:TextBox runat="server" ID="passwordtxt" CssClass="standInp" placeholder="password" TextMode="Password" />

                    <asp:Button runat="server" ID="logonbtn" Text="logon" CssClass="btn1" ValidationGroup="RequiredGroup" OnClick="logonbtn_Click" />
                    <asp:Button runat="server" ID="EmailLnkBtn" Text="Email me a new link" Font-Names="Verdana" Font-Size="10pt" CssClass="btn1 orange" OnClick="EmailLnkBtn_Click" />
             </div>

    </form>
</body>
</html>












