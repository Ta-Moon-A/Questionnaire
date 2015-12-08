using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class ViewQuestionList : System.Web.UI.Page
{
    DBAdapter DBA = new DBAdapter();
    int i = 0;

    public int? userID
    {
        get
        {
            int Id;
            if (Int32.TryParse(Request.QueryString["ID"], out Id))
            {
                return Id;
            }
            else return (int?)null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (userID==(int?)null)
        {
            rptr1.DataSource = DBA.GetQuestionList((int)Session["ID"]);
            rptr1.DataBind();
            FillNoneAnswerQuestion((int)Session["ID"]);
        }

        else
        {
            rptr1.DataSource = DBA.GetQuestionList((int)userID);
            rptr1.DataBind();
            FillNoneAnswerQuestion((int)userID);
        }
    }
    
    protected void backbtn_Click(object sender, EventArgs e)
    {
        if (Session["BackToAdmin"] != null)
        {


            if ((bool)Session["BackToAdmin"] == true)
            {
                Session.Remove("BackToAdmin");
                Response.Redirect("FindProfile.aspx");
            }
            else Response.Redirect("viewdashboard.aspx");
        }
        Response.Redirect("viewdashboard.aspx");
    }
    
    public Color ConvertFromHexToColor(string color)
    {
        string[] rgb = color.ToString().Split('.');
        return System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
    }

    public void FillNoneAnswerQuestion(int? userID)
    {
        if (DBA.QuestionMaxId((int)userID) + 1 > DBA.QuestionQuantity )
        {
            HPlinkNoAnswer.Visible = false;
            btnNoAnswer.Visible = false;
        }
        else
        {
            DataTable table = DBA.QuestionContent(DBA.QuestionMaxId((int)userID) + 1);
            DataRow row = table.Rows[0];

            HPlinkNoAnswer.Text = row["Content"].ToString();
            HPlinkNoAnswer.NavigateUrl = "~/CompleteQuestionnaire.aspx?QuestID=" + (DBA.QuestionMaxId((int)userID) + 1);
    
        }
      }

    protected void rptr1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
       // ((HtmlControl)e.Item.FindControl("HPlinkAmendAnswer")).Attributes.Add("style", "top:-40%;left:" + result + "%;");
        i++;
        HyperLink Questionlnk = e.Item.FindControl("HPlinkAmendAnswer") as HyperLink;
        Questionlnk.NavigateUrl = "~/CompleteQuestionnaire.aspx?QuestID=" + i;

    }
}