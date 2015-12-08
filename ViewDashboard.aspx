<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDashboard.aspx.cs" Inherits="ViewDashboard" MasterPageFile="~/UserPage.Master"%>

<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">
<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>--%>
<body>
    <%--<form id="form1" runat="server">
    <div class="topBanner">
        		<img src="img/logo.gif" />
        </div>--%>
        
         <div class="siteWrap">
        		<h2>
                    <asp:Label runat="server" ID="salutationLBL"></asp:Label>
        		</h2>
       
        
        
             
            <br />

           
             <asp:Button runat="server" ID="AmendProfile" CssClass="btn1 orange" OnClick="AmendProfile_Click" text="AMEND PROFILE" />
             <asp:Button runat="server" ID="ProfileResults" CssClass="btn1" OnClick="ProfileResults_Click" text="PROFILE RESULTS"/>
             <asp:Button runat="server" ID="CountryProfiles" CssClass="btn1 orange" OnClick="CountryProfiles_Click" Text="COUNTRY PROFILES" />
             <asp:Button runat="server" ID="ChangePassword" CssClass="btn1" OnClick="ChangePassword_Click" text="CHANGE PASSWORD"/>
               
          
        </div> 
    <%--</form>--%>
</body>
</html>
 </asp:Content>
