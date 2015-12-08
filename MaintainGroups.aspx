<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainGroups.aspx.cs" Inherits="MaintainGroups" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" Runat="Server">

    <div class="PageWrapForAdmin">
    <br />
        <div>
            <asp:Label  runat="server" ForeColor="Red" Font-Size="24pt" Text="Groups"></asp:Label>
        </div>
        <br />
        
        <div  runat="server" id="InsertUpdateDiv" visible="false">
        <table>
            <tr>
                <td>
                     <asp:Label ID="Label1" Text="Description" runat="server"></asp:Label>
                </td>
                <td>
                      <telerik:RadTextBox runat="server" ID="Descriptiontxt" ></telerik:RadTextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Descriptiontxt"
                                                  ErrorMessage="*" ForeColor="Red" ValidationGroup="requiredGroup"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td> <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label></td>
                <td> <telerik:RadTextBox runat="server" ID="datetxt" ></telerik:RadTextBox>
                <asp:CompareValidator id="dateValidator" runat="server" ForeColor="Red"
                                      Type="Date" Operator="DataTypeCheck" ControlToValidate="datetxt"
                                      ErrorMessage="Please Enter in the date in MM/dd/yyyy Format" ValidationGroup="requiredGroup">
                                     </asp:CompareValidator>
                
                
                </td>
                    </tr>
            <tr>
                <td></td>
                <td>
                    <telerik:RadButton runat="server" ID="Savebtn" Text="Save" OnClick="Savebtn_Click" ValidationGroup="requiredGroup"></telerik:RadButton>
                    <telerik:RadButton runat="server" ID="Cancelbtn" Text="Cancel" OnClick="Cancelbtn_Click"></telerik:RadButton>
                 </td>
            </tr>
        </table>
     </div>
        <br />
       
        <asp:Label runat="server" ID="errorlbl" ForeColor="Red" ></asp:Label>
        <br />
    <telerik:RadGrid ID="GroupsRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" AllowAutomaticDeletes="True"
                         AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" width="500" OnItemCommand="GroupsRG_ItemCommand" >
        <MasterTableView >
            <HeaderStyle/>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Description"  >
                    <HeaderTemplate>
                        <asp:LinkButton ID="Description" runat="server" Text="Description" Enabled="false" Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="Groups" runat="server"  Text='<%# Bind("Name") %>' Font-Underline="true" 
                                        CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Update" ></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
                <telerik:GridTemplateColumn UniqueName="Date" >
                    <HeaderTemplate>
                        <asp:label ID="Datelbl" runat="server" Text="Date"  Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Date" Enabled="false" runat="server"    text='<%# Bind("Date","{0:dd/MM/yyyy}") %>'   style="text-align:center" Font-Underline="true"></asp:label>
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
                            OnClientClick="return confirm('Are you sure you want to delete this record?');"
                             CommandName="Delete" ImageUrl="~/img/Delete.png" />
                     </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            
        </MasterTableView>
         
    </telerik:RadGrid>
        
   </div>
    <br />
    <br />
    




</asp:Content>

