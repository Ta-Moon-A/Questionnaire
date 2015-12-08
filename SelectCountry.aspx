<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCountry.aspx.cs" Inherits="SelectCountry" MasterPageFile="~/UserPage.master" %>

<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">

<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>--%>
<body>
    
        
         <div class="siteWrap">
        	<h2 style="font-size:14pt; font-family:'Segoe UI'">Please select the country you wish to compare.</h2>
                         <br/>
                         <br/>
              <asp:Repeater ID="rptr1" runat="server">
                 <ItemTemplate>
                        <div class="row">
                            <div class="col1">
                                    <asp:HyperLink runat="server" ID="HPlinkCountry" Text='<%# DataBinder.Eval(Container, "DataItem.Surname") %>'
                                        Font-Underline="false" 
                                        NavigateUrl='<%# Eval("ID","~/ViewComparison.aspx?CountryID={0}" ) %>'
                                        font-size="14pt" font-name="Segoe UI"></asp:HyperLink>
                            </div>
                        </div>
                 </ItemTemplate>
              </asp:Repeater>

             <asp:Button runat="server" ID="backbtn" Text="Back" CssClass="btn" OnClick="backbtn_Click" /> 
             
                
        </div> 
  
</body>
</html>
    </asp:content>
