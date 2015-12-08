<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainAnswerCategories.aspx.cs" Inherits="MaintainAnswerCategories" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    <div class="PageWrapForAdmin">
        <br />
        <div style="float:left; margin-top:10px;">
            <asp:Label ID="Label1" runat="server" Text="Types of Answers" font-name="Franklin Gothic Medium Cond" Font-Size="24pt" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <br />
        <br />
         <div >
          <table>
              <tr>
                   <td >
                        <asp:Label runat="server" ID="AnsCategorylbl" Text="Description" ForeColor="Black" Visible="false"></asp:Label>
                     
                  </td>
                  <td>
                     <telerik:RadTextBox runat="server" ID="AnswerCategoryNametxt" Visible="false" ></telerik:RadTextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" controltovalidate="AnswerCategoryNametxt" forecolor="Red" ValidationGroup="requiredGroup"  >*</asp:RequiredFieldValidator>               </td>
                  <td>
                      <telerik:RadButton runat="server" ID="Savebtn" Text="Save" Visible="false" OnClick="Savebtn_Click" ValidationGroup="requiredGroup"></telerik:RadButton>
                  </td>
                  <td>
                      <telerik:RadButton runat="server" ID="Cancelbtn" Text="Cancel" Visible="false" OnClick="Cancelbtn_Click"></telerik:RadButton>
                  </td>
              </tr>
          </table>
        </div>
        
        <div style="margin-top:30px">
        <telerik:RadGrid ID="AnswerCategoryRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="300" OnItemCommand="AnswerCategoryRG_ItemCommand">
        <MasterTableView >
            <HeaderStyle/>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Description" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:LinkButton ID="Description" runat="server" Text="Description" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="QuestionGroupLnkBtn" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Update" Text='<%# Bind("Name") %>'  ></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

          <Columns>
               <telerik:GridTemplateColumn UniqueName="Delete" ItemStyle-Width="25px">
                    <HeaderTemplate>
                        <asp:ImageButton ID="AddImageButton" CommandName="Add" runat="server" ImageUrl="~/img/Add.png"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteimageButton" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="Delete" ImageUrl="~/img/Delete.png" />
                     </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            
        </MasterTableView>
         
    </telerik:RadGrid>
        </div>
     

     </div>
</asp:Content>

