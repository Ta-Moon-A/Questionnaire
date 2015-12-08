using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainQuestions : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QuestionsRG.DataSource = null;
            QuestionsRG.DataSource = dba.GetQuestions();
            QuestionsRG.DataBind();
        }
    }

    protected void QuestionsRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    Response.Redirect("MaintainQuestion.aspx?QID=");
                    break;
                }
            case "Update":
                {
                    errorlbl.Text = "";
                    e.Canceled = true;
                    Response.Redirect("MaintainQuestion.aspx?QID=" + e.CommandArgument);
                    break;
                }
            case "Delete":
                {
                   
                    if (dba.DeleteQuestion(Convert.ToInt32(e.CommandArgument)))
                    {
                        Response.Redirect("MaintainQuestions.aspx");
                    }
                    else
                    {
                        errorlbl.Text = "This  row  can't  be removed from the database.";
                        QuestionsRG.DataSource = dba.GetQuestions();
                        QuestionsRG.DataBind();
                    }
                    break;
                }
        }

    }
}