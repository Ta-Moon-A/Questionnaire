<%@ Page Title="" Language="C#" MasterPageFile="~/CrossFileMaster.master" AutoEventWireup="true" CodeFile="MaintainQuestionGroup.aspx.cs" Inherits="MaintainQuestionGroup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="Server">
    <div class="PageWrapForAdmin">
        <br />
        <div style="float: right; margin-right: 40px; color:black">
            Order:
            <asp:RequiredFieldValidator runat="server" ID="OrderValidate" ControlToValidate="ordertxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup" ErrorMessage="Enter The order">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="ordertxt"
                                        ErrorMessage="Enter the Number For Order"  ValidationGroup="RequiredGroup" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
            
        </div>
       
        <div>
            <asp:RequiredFieldValidator runat="server" ID="Namevalidator" ControlToValidate="Nametxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup" ErrorMessage="Enter The Question Group name">*</asp:RequiredFieldValidator>
            <br />
            <telerik:RadTextBox runat="server" ID="Nametxt" Width="650px" Height="45px" TextMode="MultiLine" ForeColor="Red" Font-Size="18pt"></telerik:RadTextBox>
            
            
            <telerik:RadTextBox runat="server" ID="ordertxt" Width="80px" Height="45px" Style="float: right"></telerik:RadTextBox>
        </div>
        <br />
        <br />
        <div style="float: left; color:black"">
            Description:
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="Descriptiontxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup" ErrorMessage="Enter The Question Group Description">*</asp:RequiredFieldValidator>
        </div>
        <div style="float: right; margin-right: 140px; color:black"">
            Colour:
            
        </div>

        
        <br />
        <div style="height: 50px">
            <table>
                <tr>
                    <td>
                        
                        <telerik:RadTextBox runat="server" ID="Descriptiontxt" Width="510px" Height="48px" TextMode="MultiLine"></telerik:RadTextBox>

                    </td>
                    <td>
                       <div style="margin-top:inherit">  
                           <asp:Label runat="server" Text="RGB:" Width="29px" ForeColor="Black"></asp:Label>  
                           
                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="Rcolourtxt"
                                   ErrorMessage="Enter Red Colour" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Id="vldRegex" RunAt="server" ControlToValidate="Rcolourtxt"
                                             ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$" ErrorMessage="Enter the  Number from 0 to 255!"
                                             ValidationGroup="RequiredGroup" ForeColor="Red">*</asp:RegularExpressionValidator>
                                   
                    <telerik:RadTextBox runat="server" ID="Rcolourtxt" Width="40px" MaxLength="3"></telerik:RadTextBox>

                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="Gcolourtxt"
                                   ErrorMessage="Enter Green Colour" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator  RunAt="server" ControlToValidate="Gcolourtxt"
                                     ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$"  ErrorMessage="Enter the  Number from 0 to 255!"
                                    ValidationGroup="RequiredGroup" ForeColor="Red">*</asp:RegularExpressionValidator>

                   <telerik:RadTextBox runat="server" ID="Gcolourtxt"  Width="40px" MaxLength="3"></telerik:RadTextBox>
                           
                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="bColourtxt"
                                   ErrorMessage="Enter Blue Colour" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  RunAt="server" ControlToValidate="bColourtxt"
                                    ValidationExpression="^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$"  ErrorMessage="Enter the  Number from 0 to 255!"
                                    ValidationGroup="RequiredGroup" ForeColor="Red" >*</asp:RegularExpressionValidator>

                    <telerik:RadTextBox runat="server" ID="bColourtxt"  Width="40px" MaxLength="3"></telerik:RadTextBox>

                           
                           <br />
                           <asp:Label runat="server" Text="Maximum Answer Score:" ForeColor="Black"></asp:Label>
                           
                           <asp:RequiredFieldValidator runat="server"  ControlToValidate="MaxScoretxt"
                          ErrorMessage="Enter The Score" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator  RunAt="server" ControlToValidate="MaxScoretxt"
                                             ValidationExpression="^[-+]?[0-9]*\.?[0-9]*([eE][-+]?[0-9]+)?$" ErrorMessage="Enter the Number for Order!"
                                             ValidationGroup="RequiredGroup" ForeColor="Red">*</asp:RegularExpressionValidator>

                            <telerik:RadTextBox runat="server" ID="MaxScoretxt"  Width="40px" Height="22"></telerik:RadTextBox>
                       </div>
                    </td>
                </tr>
            </table>
       </div>
        <br />

        <div>
            <table>
                <tr>
                    <td style="width:250px; color:black"">
                        Attribute A (negative score)
                        <br />
                        <telerik:RadTextBox runat="server" ID="AttributeAtxt" Width="200px"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator runat="server"  ControlToValidate="AttributeAtxt"
                                                    ErrorMessage="Enter Attribute A" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width:250px; color:black"">
                        Attribute B (positive score)
                        <br />
                        <telerik:RadTextBox runat="server" ID="AttributeBtxt" Width="200px"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator  runat="server"  ControlToValidate="AttributeBtxt"
                                                    ErrorMessage="Enter Attribute B" ForeColor="Red" ValidationGroup="RequiredGroup">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        
        <p>
            <asp:Label runat="server" Text=" Help:" ForeColor="Black"></asp:Label>
           
        </p>
        
        <div>
            <telerik:RadTextBox runat="server" ID="Helptxt" width="740px" Height="80px" TextMode="MultiLine"></telerik:RadTextBox>
        </div>
        <br />
        <br />
        <br />
            
        <telerik:RadGrid ID="QuestionsRG" runat="server" CellSpacing="0"  GridLines="Both" AutoGenerateHierarchy="True" 
                         AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True"
                         OnPageIndexChanged="QuestionsRG_PageIndexChanged"  OnNeedDataSource="QuestionsRG_NeedDataSource"
                         AutoGenerateColumns="False"   AllowPaging="true" PageSize="5" ShowStatusBar="true"
                         OnItemCommand="QuestionsRG_ItemCommand">
                        
        <MasterTableView >
           <Columns>
                <telerik:GridTemplateColumn UniqueName="ID" ItemStyle-Width="25px" >
                    <HeaderTemplate>
                        <asp:label ID="ID" runat="server" Text="ID"  Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="QuestionId" runat="server" Text='<%# Bind("ID") %>'></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
                <telerik:GridTemplateColumn UniqueName="Content" ItemStyle-Width="400px" >
                    <HeaderTemplate>
                        <asp:LinkButton ID="Contentlb" runat="server" Text="Content" enabled="false" Font-Bold="true" Font-Underline="true" style="text-align:center"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:LinkButton ID="Content"  runat="server"  Text='<%# Bind("Content") %>' CommandName="Update" CommandArgument='<%# Bind("ID") %>' style="text-align:center"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="Weight" ItemStyle-Width="30px" >
                    <HeaderTemplate>
                        <asp:label ID="Weightlbl" runat="server" Text="Wght"  Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Wght" runat="server" Text='<%# Bind("Weight") %>'></asp:label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>


            <Columns>
                <telerik:GridTemplateColumn UniqueName="Order" ItemStyle-Width="30px" >
                    <HeaderTemplate>
                        <asp:label ID="Order" runat="server" Text="Order"  Font-Bold="true" Font-Underline="true"></asp:label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:label ID="Orderlbl" runat="server" Text='<%# Bind("QuestionOrder") %>'></asp:label>
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
                             OnClientClick="return confirm('Are you sure you want to delete all records connected to this question ?');"/>
                     </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            
        </MasterTableView>
         
    </telerik:RadGrid>
        
        
        <br />
         <div runat="server" id="InsertUpdateDiv" visible="false">
           
             <table>
                 <tr>
                     <td> <asp:Label ID="Label1" runat="server" Text="Question" ></asp:Label></td>
                     <td>
                          <%--<telerik:RadTextBox runat="server" ID="QuestionUpdatetxt" Width="300px" Height="40px" TextMode="MultiLine" ></telerik:RadTextBox>--%>
                         <telerik:RadDropDownList runat="server" ID="QuestionDDL" Width="350px" DefaultMessage="Select Question"></telerik:RadDropDownList>
                     </td>
                    <td>
                        <%-- <asp:RequiredFieldValidator  runat="server"  ControlToValidate="QuestionUpdatetxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup1" >*</asp:RequiredFieldValidator>--%>
                    </td>
                 </tr>
                 <tr>
                     <td><asp:Label ID="Label2" runat="server" Text="Weight"></asp:Label></td>
                     <td> <telerik:RadTextBox runat="server" ID="QuestionWghtUpdatetxt"  Width="50px"></telerik:RadTextBox></td>
                    <td>
                        <asp:RequiredFieldValidator  runat="server"  ControlToValidate="QuestionWghtUpdatetxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup1">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator   runat="server" ForeColor="Red" ControlToValidate="QuestionWghtUpdatetxt"
                                        ValidationGroup="RequiredGroup1" ValidationExpression="^-?[0-9]{1,12}(?:\.[0-9]{1,4})?$">*</asp:RegularExpressionValidator>
                    </td>
                 </tr>
                 <tr>
                     <td><asp:Label ID="Label4" runat="server" Text="Order" ></asp:Label></td>
                    <td> <telerik:RadTextBox runat="server" ID="QuestionOrdertxt" Width="50px"></telerik:RadTextBox></td>
                    <td>
                         <asp:RequiredFieldValidator runat="server"  ControlToValidate="QuestionOrdertxt" forecolor="Red"
                                        ValidationGroup="RequiredGroup1">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator  runat="server" ForeColor="Red" ControlToValidate="QuestionOrdertxt"
                                        ValidationGroup="RequiredGroup1" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
                       </td>
                     
                 </tr>
                 <tr>
                    <td><asp:Label ID="AnswerCategorylbL" runat="server" Text=" Answer Category" ></asp:Label></td>
                     <td colspan="2" > <telerik:RadDropDownList runat="server" ID="AnswerCategoryDDL" ></telerik:RadDropDownList></td>

                 </tr>
             </table>
             <div style="margin-left:115px">
             <telerik:RadButton runat="server" ID="UpdateSave" Text="Save" onclick="UpdateSave_Click" ValidationGroup="RequiredGroup1"></telerik:RadButton>
             <telerik:RadButton runat="server" ID="CancelUpdate" Text="Cancel" OnClick="CancelUpdate_Click"></telerik:RadButton>
            </div> 

        </div>
        
        <br />
        <br/>


        <div style="margin-left:600px">
                    <asp:LinkButton runat="server" ID="cancelBtn" Text="Cancel  " Font-Underline="false" Font-Size="Large" OnClick="cancelBtn_Click"></asp:LinkButton>
                    
                    <asp:LinkButton runat="server" ID="savebtn" Text="  Save" Font-Underline="false" Font-Size="Large" OnClick="savebtn_Click" ValidationGroup="RequiredGroup" ></asp:LinkButton>
       </div>
    </div>
</asp:Content>

