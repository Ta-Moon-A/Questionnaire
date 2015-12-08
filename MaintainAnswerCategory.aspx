<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainAnswerCategory.aspx.cs" Inherits="MaintainAnswerCategory" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
     <div class="PageWrapForAdmin">
         <br />
         <br />
          <telerik:RadTextBox runat="server" ID="AnswerCategoryNametxt" Width="750"  Height="50" ForeColor="Red" Font-Size="24pt"></telerik:RadTextBox>
          <br />
          <br />
         <p style="color:black">Help :</p>

         <telerik:RadTextBox runat="server" ID="helptxt" Width="750" Height="80" TextMode="MultiLine"></telerik:RadTextBox>
         <br />
         <br />
         <br />
         <br />
       <telerik:RadGrid ID="AnswersRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="300" OnItemCommand="AnswersRG_ItemCommand">
        <MasterTableView >
            <HeaderStyle/>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="ID" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:label ID="Answer" runat="server" Text="ID" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="answerIDlbl" runat="server"  Text='<%# Bind("ID") %>'  ></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Answer" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:LinkButton ID="AnswerContent" runat="server" Text="Answer" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="AnswerContentLnkBtn" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Update" Text='<%# Bind("Content") %>'  ></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Order" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:label ID="Orderlbl" runat="server" Text="Order" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="orderlbl" runat="server"  Text='<%# Bind("AnswerOrder") %>'  ></asp:label>
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
          <div style="margin-left:600px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click"  ></asp:LinkButton>
       </div>
     
     
     </div>
</asp:Content>

