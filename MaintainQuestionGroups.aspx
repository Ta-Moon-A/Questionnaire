<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainQuestionGroups.aspx.cs" Inherits="MaintainQuestionGroups" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
    
    <div class="PageWrapForAdmin">
        <br />
        <div style="float:left; margin-top:10px;">
            <asp:Label runat="server" Text="Question Groups" font-name="Franklin Gothic Medium Cond"
                       Font-Size="24pt" ForeColor="Red"></asp:Label>
        </div>

        <div style="margin-top:60px">
            <br />
            <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
        <telerik:RadGrid ID="QuestionGroupRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="300" OnItemCommand="QuestionGroupRG_ItemCommand" >
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
                <telerik:GridTemplateColumn UniqueName="QuestionGroupOrder" ItemStyle-Width="25px">
                    <HeaderTemplate>
                        <asp:label ID="Orderlbl" runat="server" Text="Order"  Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Order" Enabled="false" runat="server"  Text='<%# Bind("QuestionGroupOrder") %>' style="text-align:center"></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
               <telerik:GridTemplateColumn UniqueName="Delete" ItemStyle-Width="25px">
                    <HeaderTemplate>
                        <asp:ImageButton ID="AddImageButton" CommandName="Add" runat="server" ImageUrl="~/img/Add.png"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteimageButton" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Delete" ImageUrl="~/img/Delete.png"
                                        OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                     </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            
        </MasterTableView>
         
    </telerik:RadGrid>
        
        </div>
    </div>

</asp:Content>

