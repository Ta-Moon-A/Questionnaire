<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainProfileDifferences.aspx.cs" Inherits="MaintainProfileDifferences" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">
 
      <div class="PageWrapForAdmin">
        <br />
        <div style="float:left; margin-top:10px;">
            <asp:Label ID="Label1" runat="server" Text="Profile Differences" font-name="Franklin Gothic Medium Cond" Font-Size="24pt" ForeColor="Red"></asp:Label>
        </div>

        <div style="margin-top:60px">
            <br />
            <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
            <br />
        <telerik:RadGrid ID="ProfileDifferencesRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="300" OnItemCommand="ProfileDifferencesRG_ItemCommand">
        <MasterTableView >
            <HeaderStyle/>

             <Columns>
                <telerik:GridTemplateColumn UniqueName="From" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:Label ID="From" runat="server" Text="From" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:Label ID="Fromlbl" runat="server" Text='<%# Bind("From") %>'  ></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

             <Columns>
                <telerik:GridTemplateColumn UniqueName="To" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:Label ID="To" runat="server" Text="To" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:Label ID="Tolbl" runat="server" Text='<%# Bind("To") %>'  ></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Level" ItemStyle-Width="150px" >
                    <HeaderTemplate>
                        <asp:LinkButton ID="Level" runat="server" Text="Level" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="LevelLnkBtn" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Update" Text='<%# Bind("Level") %>'  ></asp:LinkButton>
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
     <br />
     <br />
</div>



</asp:Content>

