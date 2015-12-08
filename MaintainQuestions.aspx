<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainQuestions.aspx.cs" Inherits="MaintainQuestions" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">

    <div class="PageWrapForAdmin">
    <br />
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="24pt" Text="Questions"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
    <telerik:RadGrid ID="QuestionsRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="500" OnItemCommand="QuestionsRG_ItemCommand" >
        <MasterTableView >
            <HeaderStyle/>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="ID" ItemStyle-Width="25px"  >
                    <HeaderTemplate>
                        <asp:label ID="ID" runat="server" Text="ID" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Question" runat="server" Text='<%# Bind("ID") %>'  ></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Description"  >
                    <HeaderTemplate>
                        <asp:LinkButton ID="Description" runat="server" Text="Description" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="QuestionGroupLnkBtn" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Update" Text='<%# Bind("Content") %>'  ></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
                <telerik:GridTemplateColumn UniqueName="QuestionGroupOrder" ItemStyle-Width="25px">
                    <HeaderTemplate>
                        <asp:label ID="Orderlbl" runat="server" Text="Order"  Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Order" Enabled="false" runat="server"  Text='<%# Bind("QuestionOrder") %>' style="text-align:center"></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
               <telerik:GridTemplateColumn UniqueName="Delete" ItemStyle-Width="25px">
                    <HeaderTemplate>
                        <asp:ImageButton ID="AddImageButton" CommandName="Add" runat="server" ImageUrl="~/img/Add.png"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteimageButton" runat="server"
                             CommandArgument='<%# Bind("ID") %>' CommandName="Delete" 
                            ImageUrl="~/img/Delete.png" 
                           OnClientClick="return confirm('Are you sure you want to delete this record?');"/>
                     </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            
        </MasterTableView>
         
    </telerik:RadGrid>
        
   </div>



</asp:Content>

