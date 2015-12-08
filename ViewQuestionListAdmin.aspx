<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.master" AutoEventWireup="true" CodeFile="ViewQuestionListAdmin.aspx.cs" Inherits="ViewQuestionListAdmin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="SomeContent" Runat="Server">
    <div class="siteWrap ViewQuestionList">

            <div class="alignRhs">
                <h4><a href="FindProfile.aspx">Back</a></h4>
            </div>

            <asp:Repeater ID="rptr1" runat="server" OnItemDataBound="rptr1_ItemDataBound">
                 <ItemTemplate>
                        <div class="row">
                            <div class="col1">
                                    <asp:HyperLink runat="server" ID="HPlinkAmendAnswer" Text='<%# DataBinder.Eval(Container, "DataItem.Qcontent") %>'
                                       
                                        Font-Underline="false" 
                                        style="font-weight: normal; font-size:1.2em; margin:3px 0;"></asp:HyperLink>
                            </div>
                            <div class="col2">
                                    <asp:LinkButton ID="btn" runat="server" cssclass="btn3" style="display:table-cell"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.Acontent") %>'
                                        BackColor='<%# ConvertFromHexToColor( Eval("Color").ToString()) %>'
                                        BorderStyle="None" Enabled="false" ></asp:LinkButton>
                            </div>
                        </div>
                 </ItemTemplate>
              </asp:Repeater>
                 <div class="row">
                            <div class="col1">
                                  <asp:HyperLink runat="server" ID="HPlinkNoAnswer"
                                        Font-Underline="false" style="font-weight: normal; font-size:1.2em; margin:3px 0;" ></asp:HyperLink>
                            </div>
                            <div class="col2">
                                    <asp:LinkButton ID="btnNoAnswer" runat="server" text="No answer" CssClass="btn3 white" 
                                        BackColor="White" Enabled="false">
                                        </asp:LinkButton>
                            </div>
                 </div>

                 <div class="row">
                   <asp:Button runat="server" ID="Backbtn" Text="Back" CssClass="btn" OnClick="backbtn_Click" />
                </div>
        </div>
  



</asp:Content>

