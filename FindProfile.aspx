<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FindProfile.aspx.cs" Inherits="FindProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="Server">
     
    <div class="PageWrapForAdmin">
        <br />
        <br />
        
         
         <div style="float: left; margin-top: 15px">
                 <telerik:RadDropDownList runat="server" ID="UserGroupDDL" DefaultMessage="Select Group" Font-Italic="false"
                                          autopostback="true"  OnSelectedIndexChanged="UserGroupDDL_SelectedIndexChanged" OnItemSelected="UserGroupDDL_ItemSelected" >
                 </telerik:RadDropDownList>
         </div>
                     


        <div style="float: right; margin-top: 15px">
               <telerik:RadButton runat="server" ID="EmailAllbtn" Text="Email to All " Enabled="false" OnClick="EmailAllbtn_Click"  ></telerik:RadButton>
               <telerik:RadButton runat="server" ID="EmailNewbtn" Text="Email to New" Enabled="false" onclick="EmailNewbtn_Click" ></telerik:RadButton>
          </div>     
           
                                        
        
        <br />
        <br />
        <div style="margin-top: 30px">
            
                    <telerik:RadGrid runat="server" ID="UserInfoRG" AutoGenerateColumns="False" OnItemCommand="UserInfoRG_ItemCommand"
                                     AllowPaging="true" PageSize="50" AllowSorting="true"
                                     OnPageIndexChanged="UserInfoRG_PageIndexChanged" OnNeedDataSource="UserInfoRG_NeedDataSource"
                                  
                                     OnSortCommand="RadGrid1_SortCommand" >
                        <HeaderStyle  Font-Underline="true" />
                         <MasterTableView  >
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="Name" SortExpression="Name">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="IDHeader" runat="server" Text="Name" CommandName="Sort" CommandArgument="Name"  ></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="MintainProfile" runat="server" Text='<%# Bind("Name") %>'  CommandName="GoToQuestionList"
                                                        CommandArgument='<%# Bind("ID") %>'>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                             
                            <Columns>
                                <telerik:GridBoundColumn DataField="Organization" HeaderText="Organisation" ReadOnly="true" />
                            </columns>
                             <Columns>
                                <telerik:GridTemplateColumn UniqueName="Emailed" ItemStyle-Font-Underline="true" SortExpression="Emailed">
                                    <HeaderTemplate>
                                        <asp:linkButton ID="emailedlbl" runat="server" Text="Emailed" CommandName="Sort" CommandArgument="Emailed" ></asp:linkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Linkbutton ID="Emailed" runat="server" Text='<%# Bind("Emailed","{0:dd/MM/yyyy}") %>'
                                                        CommandArgument='<%# Bind("ID") %>' CommandName="EmailToPerson"
                                                        OnClientClick='<%# Eval("confirm", "return confirm(\"Please confirm you wish to email {0}?\");") %>'/>
                                       
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>
                            </Columns>
                           <Columns>
                                <telerik:GridTemplateColumn UniqueName="Updated"   ItemStyle-Font-Underline="false" SortExpression="Updated"  >
                                    <HeaderTemplate >
                                        <asp:LinkButton  runat="server" Text="Updated" CommandName="Sort" CommandArgument="Updated"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Updated" Font-Underline="false" runat="server" Text='<%# Bind("Updated","{0:dd/MM/yyyy}") %>'   ></asp:Label>
                                    </ItemTemplate>

                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Answers" HeaderText="Answers" ReadOnly="true" />
                                <telerik:GridBoundColumn DataField="Group" HeaderText="Group" ReadOnly="true" />
                                
                           <telerik:GridTemplateColumn  ItemStyle-Width="80px">
                                <HeaderTemplate>
                                    <asp:ImageButton ID="AddImageButton" CommandName="Add" runat="server" ImageUrl="~/img/Add.png"/>
                                </HeaderTemplate>
                                <ItemTemplate>
                                     <asp:ImageButton ID="EditImageButton" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="Update" ImageUrl="~/img/edit.png" />
                                     <asp:ImageButton ID="DisableUser" runat="server" ImageUrl="~/img/Add.png" Visible='<%# Eval("IsActive").ToString() == "True" ? false : true%>' CommandName="DisableUser" CommandArgument='<%# Eval ("ID") %>' />
                                     <asp:ImageButton ID="EnableUser" runat="server" ImageUrl="~/img/Delete.png" Visible='<%# Eval("IsActive").ToString() == "True" ? true : false%>' CommandName="EnableUser" CommandArgument='<%# Eval ("ID") %>' />
                                     
                                     </ItemTemplate>
                            </telerik:GridTemplateColumn>
           
                            </Columns>

                            
                        </MasterTableView>
                   </telerik:RadGrid>
           
        </div>
        </div>
    


</asp:Content>


 <%-- OnClientClick='<%#Eval("confirm", "confirmation(\"{0}\");")%>'--%>

