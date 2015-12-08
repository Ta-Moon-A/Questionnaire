using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;


public partial class FindProfile : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            FillUserInfoRG(null);
            BindUserGroups();
            
        }
    }

    protected void BindUserGroups()
    {
       
        UserGroupDDL.DataSource = dba.UserGroups();
        UserGroupDDL.DataTextField = "Name";
        UserGroupDDL.DataValueField = "ID";
        UserGroupDDL.DataBind();
        UserGroupDDL.Items.Insert(0, new DropDownListItem("Select Group", "0"));
        UserGroupDDL.SelectedIndex = 0;
       
    }

    public void FillUserInfoRG(int? Groupid)
    {
        UserInfoRG.DataSource = null;
        UserInfoRG.DataSource = dba.GetUserInfo(Groupid);
        UserInfoRG.DataBind();
    }

    private EmailTemplateType GetUser(string Email)
    {
        EmailTemplatesDB emDb = new EmailTemplatesDB();
        DataRow row = emDb.GetEmailTemplate(1);

        EmailTemplateType emtObject = new EmailTemplateType();
        emtObject.BCC = row["BCC"].ToString();
        emtObject.BCCTitle = row["BCCTitle"].ToString();
        emtObject.Body = row["Body"].ToString();
        emtObject.Subject = row["Subject"].ToString();
        emtObject.CC = row["CC"].ToString();
        emtObject.CCTitle = row["CCTitle"].ToString();
        emtObject.ConfirmationPage = row["ConfirmationPage"].ToString();
        emtObject.From = row["From"].ToString();
        emtObject.FromTitle = row["FromTitle"].ToString();

        emtObject.EmailTo = Email;

        DataRow user = dba.GetUserByEmail(Email);

        emtObject.ID = Convert.ToInt32(user["ID"]);
        emtObject.Firstname = user["Firstname"].ToString();
        emtObject.Surname = user["Surname"].ToString();
        emtObject.Salutation = user["Salutation"].ToString();
        emtObject.Organisation = user["Organization"].ToString();
        emtObject.Password = user["Password"].ToString();
        emtObject.Email = Email;

        Guid g = Guid.NewGuid();
        dba.InsertUserInfoForEmail(Convert.ToInt32(user["ID"]), dba.QuestionMaxId(Convert.ToInt32(user["ID"])) + 1, g.ToString());


        if (dba.QuestionMaxId(Convert.ToInt32(user["ID"])) > 0)
        {
            emtObject.ProfileLink = "http://" + Request.Url.Authority + "/CompleteQuestionnaire.aspx?uid=" + Convert.ToInt32(user["ID"]) + "&QuestID=" + (dba.QuestionMaxId(Convert.ToInt32(user["ID"])) + 1) + "&sid=" + g;

        }
        else
        {
            emtObject.ProfileLink = "http://" + Request.Url.Authority + "/ViewQuestionnaireIntro.aspx?uid=" + Convert.ToInt32(user["ID"]) + "&QuestID="  + 1 + "&sid=" + g;

        }


        return emtObject;
    }

    #region Events

    protected void EmailAllbtn_Click(object sender, EventArgs e)
    {

        DataTable users = dba.GetAllUserByGroupId(UserGroupDDL.SelectedIndex + 2);
        foreach (DataRow row in users.Rows)
        {
            EmailSender es = new EmailSender();
            es.SendEmail(GetUser(row["Email"].ToString()));
            dba.UpdateUserEmailedDate(Convert.ToInt32(row["ID"]), DateTime.Now);
        }
        if (UserGroupDDL.SelectedIndex < 0)
        {
            FillUserInfoRG(null);
        }
        else
            FillUserInfoRG(UserGroupDDL.SelectedIndex + 1);

    }

    protected void EmailNewbtn_Click(object sender, EventArgs e)
    {
        DataTable users = dba.GetUserByGroupId(UserGroupDDL.SelectedIndex + 2);
        foreach (DataRow row in users.Rows)
        {
            EmailSender es = new EmailSender();
            es.SendEmail(GetUser(row["Email"].ToString()));
            dba.UpdateUserEmailedDate(Convert.ToInt32(row["ID"]), DateTime.Now);
        }
        if (UserGroupDDL.SelectedIndex < 0)
        {
            FillUserInfoRG(null);
        }
        else
            FillUserInfoRG(UserGroupDDL.SelectedIndex + 1);

    }

    protected void UserGroupDDL_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
    {
        if (UserGroupDDL.SelectedIndex==0)
        {
             FillUserInfoRG(null);
             EmailAllbtn.Enabled = false;
             EmailNewbtn.Enabled = false;
        }
        else
        {

        
       FillUserInfoRG(UserGroupDDL.SelectedIndex+1);
       EmailAllbtn.Enabled = true;
       EmailNewbtn.Enabled = true;
        }
    }
   
    protected void UserGroupDDL_ItemSelected(object sender, Telerik.Web.UI.DropDownListEventArgs e)
    {
        EmailAllbtn.Enabled = true;
        EmailNewbtn.Enabled = true;
    }

    protected void UserInfoRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
     {
         switch (e.CommandName)
         {
             //case "Sort":
             //    {
             //        GridSortExpression sortExpr = new GridSortExpression();
             //        sortExpr.FieldName = "Name";
             //        sortExpr.SortOrder = GridSortOrder.Ascending;
             //        //Add sort expression, which will sort against first column
             //        UserInfoRG.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
             //        if (UserGroupDDL.SelectedIndex < 0)
             //        {
             //            FillUserInfoRG(null);
             //        }
             //        else
             //            FillUserInfoRG(UserGroupDDL.SelectedIndex + 2);
             //        break;
             //    }
             case "GoToQuestionList":
                 {
                     Session["BackToAdmin"] = true;
                     Response.Redirect("ViewQuestionListAdmin.aspx?ID="+Convert.ToInt32(e.CommandArgument));
                     break;
                 }
             case "EmailToPerson":
                 {

                    
                     DataTable tbuser = dba.GetUsers(Convert.ToInt32(e.CommandArgument));
                     DataRow row = tbuser.Rows[0];
                     EmailSender es = new EmailSender();

                     es.SendEmail(GetUser(row["Email"].ToString()));
                     dba.UpdateUserEmailedDate(Convert.ToInt32(e.CommandArgument), DateTime.Now);
                     FillUserInfoRG(null);
                     break;
                 }
             case "Add":
                 {
                    
                     Response.Redirect("MaintainProfile.aspx?ID=");
                     break;
                 }
             case "Update":
                 {
                     e.Canceled = true;
                   
                     Response.Redirect("MaintainProfile.aspx?ID=" + e.CommandArgument);
                     break;
                 }
             case "EnableUser":
                 {
                     dba.EnableUser(Convert.ToInt32(e.CommandArgument), false);
                     if (UserGroupDDL.SelectedIndex < 0)
                     {
                         FillUserInfoRG(null);
                     }
                     else
                         FillUserInfoRG(UserGroupDDL.SelectedIndex + 2);

                     break;
                 }
             case "DisableUser":
                 {
                     dba.EnableUser(Convert.ToInt32(e.CommandArgument), true);
                     if (UserGroupDDL.SelectedIndex < 0)
                     {
                         FillUserInfoRG(null);
                     }
                     else
                         FillUserInfoRG(UserGroupDDL.SelectedIndex + 2);

                     break;
                 }
         }
     }
 
    protected void UserInfoRG_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        UserInfoRG.CurrentPageIndex = e.NewPageIndex;
       
        if (UserGroupDDL.SelectedIndex < 0)
        {
            FillUserInfoRG(null);
        }
        else
            FillUserInfoRG(UserGroupDDL.SelectedIndex + 2);
    }

    protected void UserInfoRG_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string gridSortString = this.UserInfoRG.MasterTableView.SortExpressions.GetSortString();
       // this.SortLabel.Text = "Grid sort expression: " + gridSortString;

        DataSourceSelectArguments args = new DataSourceSelectArguments(gridSortString);



        if (UserGroupDDL.SelectedIndex < 0)
        {
            UserInfoRG.DataSource = dba.GetUserInfo(null);
        }
        else
            UserInfoRG.DataSource = dba.GetUserInfo(UserGroupDDL.SelectedIndex + 2);
           
    }

    protected void RadGrid1_SortCommand(object source, GridSortCommandEventArgs e)
    {
        

        if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
        {
            GridSortExpression sortExpr = new GridSortExpression();
            sortExpr.FieldName = e.SortExpression;
            sortExpr.SortOrder = GridSortOrder.Ascending;

            e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
        }
    }

   

    #endregion



}















