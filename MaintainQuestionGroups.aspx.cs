using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainQuestionGroups : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillQuestionGroupRG();
           
        }
    }

    public void FillQuestionGroupRG()
    {
        QuestionGroupRG.DataSource = null;
        QuestionGroupRG.DataSource = dba.GetQuestionGroups();
        QuestionGroupRG.DataBind();
    }

    protected void QuestionGroupRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainQuestionGroup.aspx?GroupID=");                    
                    break;
                }
            case "Update":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainQuestionGroup.aspx?GroupID="+e.CommandArgument); 
                    break;
                }
            case "Delete":
                {
                    if (dba.DeleteQuestionGroup(Convert.ToInt32(e.CommandArgument)))
                    {
                        FillQuestionGroupRG();
                    }
                    else
                    {
                        errorlbl.Text = "This  row  can't  be removed from the database.";
                        FillQuestionGroupRG();
                    }
                    break;
                }
        }
    }
}