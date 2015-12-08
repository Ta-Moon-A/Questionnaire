<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" MasterPageFile="~/UserPage.master" %>

<asp:Content ID="myContent" ContentPlaceHolderID="someContent" runat="server">
    <!DOCTYPE html>
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <html xmlns="http://www.w3.org/1999/xhtml">
    <%--<head runat="server">
    <title></title>
</head>--%>
    <body>
        <div class="siteWrap viewProfile">


            <br />

            <asp:Repeater ID="rptr" runat="server" OnItemDataBound="rptr_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <img src="img/lineWithDots.gif" class="lineWithDots" />


                        <div class="point" id="TEST" runat="server"></div>
                        <div class="item1">
                            <asp:Label ID="item1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AttributeA") %>'></asp:Label>
                        </div>

                        <div class="item2">
                            <asp:Label ID="item2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AttributeB") %>'></asp:Label>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>

          <asp:Button runat="server" ID="backbtn" Text="Back" CssClass="btn" OnClick="backbtn_Click" />

        </div>

    </body>
    </html>
</asp:Content>


