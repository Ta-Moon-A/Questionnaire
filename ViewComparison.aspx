<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewComparison.aspx.cs" Inherits="ViewComparison" MasterPageFile="~/UserPage.master" %>


<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">
<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>--%>
<body>
   
        
   <div class="siteWrap">
                 <img src="img/line1.gif" class="line1" />
        <div class="row">
                <h2 class="fleft">You prefer</h2>
        
                <h2 class="fright alignRhs">
                    <asp:Label runat="server" ID="Peoplelbl" Text="People"></asp:Label><br />
                    </h2>
         </div> 
    <br/><br/>

     <asp:Repeater ID="UserInfoRPTR" runat="server" OnItemDataBound="UserInfoRPTR_ItemDataBound">
         <ItemTemplate>

            <h1 style="font-size:20pt">
                <asp:Label runat="server" ID="PersonChoicelbl" ></asp:Label>
            </h1>
            <h3 style="font-size:12pt">
                <asp:Label runat="server" ID="PersonDifferencelbl" ></asp:Label>
            </h3>
            
            <br />
       
              
               <asp:Image runat="server" ID="DifferenceImage" CssClass="alignCenterImg" width="42" height="42" />
      
         
             <h1 class="alignRhs grayTxt" style="font-size:20pt">
                 <asp:Label runat="server" ID="CountryChoicelbl" ></asp:Label>    
            </h1>
            <h3 class="alignRhs" style="font-size:12pt">
                <asp:Label runat="server" ID="CountryDifferencelbl" ></asp:Label>
            </h3>
          </ItemTemplate>
        </asp:Repeater>
         



    <%--<h1>egalistarianism</h1>
     <h3>over hierarchical</h3><br/><img src="img/faceIcoRed.png" width="42" height="42" class="alignCenterImg" />
     <h1 class="alignRhs grayTxt">hierarchical</h1>
     <h3 class="alignRhs">strongly over egalitarian</h3>
     
     <hr/>
      <h1>group</h1>
       <h3 >strongly over individual</h3><br/>
       <img src="img/faceIcoGreen.png" width="42" height="42" class="alignCenterImg" />
       
         <h1 class="alignRhs grayTxt">group</h1>
     <h3 class="alignRhs">strongly over individual</h3>
     
     <hr/>
       
       
       
       <h1>task</h1>
        <h3>strongly over relationship</h3><br/>
        <img src="img/faceIcoGreen.png" width="42" height="42" class="alignCenterImg" />
        <h1 class="alignRhs grayTxt">task</h1>
     <h3 class="alignRhs">strongly over relationship</h3>
     
      
     <hr/>
     
     
       <h2>neither uncertainty<br/>
        nor certainty</h2><br/>
        <img src="img/faceIcoGray.png" width="42" height="42" class="alignCenterImg" />
        <h1 class="alignRhs grayTxt">certainty</h1>
     <h3 class="alignRhs">strongly over uncertainty</h3>
     
      
     <hr/>
     
     
      <h1>polychronic</h1>
       <h3>over monochronic</h3><br/>
        <img src="img/faceIcoGray.png" width="42" height="42" class="alignCenterImg" />
        <h1 class="alignRhs grayTxt">monochronic</h1>
     <h3 class="alignRhs">over polychronic</h3>
     
     
     <hr/>
     
     <h1>direct</h1>
       <h3>over indirect</h3><br/>
       <img src="img/faceIcoRed.png" alt="" width="42" height="42" class="alignCenterImg" />
       <h1 class="alignRhs grayTxt">indirect</h1>
     <h3 class="alignRhs">strongly over direct</h3>
     --%>
      
      <br/><br/>
     
        <input name="" type="button" value="Back" class="btn"  onclick="location.href = 'SelectCountry.aspx'"/>
   </div> 
    
</body>
</html>
</asp:Content>
