<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewQuestionnaireIntro.aspx.cs" Inherits="ViewQuestionnaireIntro" %>



<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
    
<body>
   <form runat="server">
        <div class="topBanner" id="bannerDiv" runat="server">
            <img src="img/logo.gif" />
        </div>
         <div class="siteWrap">
        		<h2>In order to determine your cultural profile, please answer the following 24 questions.<br/><br/>
                 Your answers are saved after every question and if you do not complete the questionnaire in one session, the next time you logon or use the email link, the next unanswered question will be displayed.</h2><br/>
              <asp:button runat="server" ID="ContBTN" Text="Continue" CssClass="btn orange" OnClick="ContBTN_Click" />
              <asp:Button runat="server" ID="backbtn" Text="Back" CssClass="btn" OnClick="backbtn_Click" />
         </div> 
   </form>
</body>
</html>
 
