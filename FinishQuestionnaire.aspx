<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinishQuestionnaire.aspx.cs" Inherits="FinishQuestionnaire" MasterPageFile="~/UserPage.Master" %>

<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">
    <!DOCTYPE html>
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <html xmlns="http://www.w3.org/1999/xhtml">
    <%--<head runat="server">
    <title></title>
</head>--%>
    <body>


        <div class="siteWrap">
            <br />
            <br />
            <h2>Thank you for completing this questionnaire.<br />
                <br />

                Please tap or click below to view your cultural profile.</h2>
            <br />
            <asp:Button runat="server" ID="ContBTN" Text="Continue" CssClass="btn orange" OnClick="ContBTN_Click" />
        </div>

    </body>
    </html>
</asp:Content>
