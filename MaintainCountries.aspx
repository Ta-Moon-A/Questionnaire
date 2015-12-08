<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainCountries.aspx.cs" Inherits="MaintainCountries" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">

    <div class="PageWrapForAdmin">
        <br />
        <br />

        <telerik:RadGrid ID="CountriesRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="500" OnItemCommand="CountriesRG_ItemCommand" >
        <MasterTableView >
            <HeaderStyle/>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Name"  >
                    <HeaderTemplate>
                        <asp:Label ID="Name" runat="server" Text="Name"  Font-Bold="true" Font-Underline="true"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:Label ID="Namelbl" runat="server"  Text='<%# Bind("Surname") %>' Font-Underline="true" ></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
                <telerik:GridTemplateColumn UniqueName="People" >
                    <HeaderTemplate>
                        <asp:label ID="People" runat="server" Text="People"  Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Peoplelbl" Enabled="false" runat="server"    text='<%# Bind("Salutation") %>'   style="text-align:center" Font-Underline="true"></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Profile" >
                    <HeaderTemplate>
                        <asp:label ID="Profile" runat="server" Text="Profile" Enabled="false" Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="Profilelbl" Enabled="true" runat="server" text='<%# Bind("Organization") %>' 
                                        style="text-align:center" Font-Underline="true"
                                        CommandArgument='<%# Bind("ID") %>' CommandName="Update"></asp:LinkButton>
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
</asp:Content>

