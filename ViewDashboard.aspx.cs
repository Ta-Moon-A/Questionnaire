using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewDashboard : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewSalutation((int)Session["ID"]);
        }
    }

    protected void AmendProfile_Click(object sender, EventArgs e)
    {
        if (dba.QuestionMaxId((int)Session["ID"]) > 23)
        {
            Response.Redirect("ViewQuestionList.aspx");
        }
        else
        {
            Response.Redirect("CompleteQuestionnaire.aspx?QuestID=" + (dba.QuestionMaxId((int)Session["ID"]) + 1));
           // Response.Redirect("ViewQuestionnaireIntro.aspx");  
        }
    }

    protected void ProfileResults_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProfile.aspx");
    }

    protected void CountryProfiles_Click(object sender, EventArgs e)
    {
        Response.Redirect("SelectCountry.aspx");
    }

    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }

    public void ViewSalutation(int UID)
    {
        DBAdapter dba = new DBAdapter();
        DataTable tbuser = dba.GetUsers(UID);
        DataRow row = tbuser.Rows[0];
        salutationLBL.Text ="Hello "+ row["Firstname"].ToString();
    }
}