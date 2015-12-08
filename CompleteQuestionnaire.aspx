<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompleteQuestionnaire.aspx.cs" Inherits="CompleteQuestionnaire"  %>


<!DOCTYPE html>
<link href="Styles/styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>--%>
    


<body>
       <form runat="server">
       
        <div class="siteWrap">
            <div class="row">
                <img src="img/logoSml.gif" class="logoSml" />
                <div class="logoSideTxt">
                  <h2>  
                      <asp:Label runat="server" ID="QuestionContentLBL" Text="Question Content from database."/>
                  </h2>
                    
                </div>
                <br />
            </div>

            <div class="contWrap1">
                <div class="buttonsWrap">
                    <asp:PlaceHolder runat="server" ID="plHolder1"></asp:PlaceHolder>
                </div>
               
                <div class="paging">
                   <asp:Label runat="server" ID="AnswerNumberLBL" ></asp:Label> 
                     <asp:Label runat="server" ID="QuestionQuantity" ></asp:Label> 
                </div>
          </div>
                <div class="inpWrap1">
                    <asp:Button runat="server" ID="Prevbtn" Text="Previous" CssClass="btn fleft margRhs15" OnClick="Prevbtn_Click"/>
                    <asp:Button runat="server" ID="Listbtn" Text="List" CssClass="btn fright orange" OnClick="Listbtn_Click" />
                </div>
       </div>
    </form> 
</body>
</html>













<%--<div class="buttonsWrap" >
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.aspx" class="btn2 grn3">Strongly Agree</a>
                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 grn2">Agree</a>

                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 grn2">Somewhat Agree</a>

                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 grn1">Possibly Agree</a>
                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 grey1">Neither Agree or Disagree</a>
                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 red1">Possibly  Disagree</a>
                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 red2">Somewhat Disagree</a>
                    </div>

                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.html" class="btn2 red2">Disagree</a>
                    </div>
                    <div class="btn2Wrap">
                        <a href="CompleteNextQuestion1.aspx" class="btn2 red3">Strongly Disagree</a>

                    </div>
                </div>--%>


      <%-- <input name="" type="button" value="Previous" class="btn fleft margRhs15" onclick="location.href = 'ViewQuestionnaireIntro.aspx'" />
           <input name="" type="button" value="List" class="btn fright orange" onclick="location.href = 'ViewQuestionList.aspx'" />--%>

<%--<div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans1" value="" CssClass="btn2 grn3" />
                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans2" value="" CssClass="btn2 grn2" /> 

                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans3" value="" CssClass="btn2 grn2" />
                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server"  ID="ans4" value="" CssClass="btn2 grn1" /> 
                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans5" value="" CssClass="btn2 grey1" /> 
                    </div>
                    <div class="btn2Wrap">
                       <asp:Button runat="server" ID="ans6" value="" CssClass="btn2 red1" />
                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans7" value="" CssClass="btn2 red2" />
                    </div>
                    <div class="btn2Wrap">
                       <asp:Button runat="server" ID="ans8" value="" CssClass="btn2 red2" />
                    </div>
                    <div class="btn2Wrap">
                        <asp:Button runat="server" ID="ans9" value="" CssClass="btn2 red3" />
                    </div>--%>