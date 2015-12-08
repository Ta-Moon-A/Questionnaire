using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainQuestion : System.Web.UI.Page
{
    public int? QuestionID
    {
        get
        {
            int QID;
            if (Int32.TryParse(Request.QueryString["QID"].ToString(), out QID))
            {
                return QID;
            }
            else return null;
        }
    }

    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
            BindAnswerCategories();
           
        }
    }

    public void Fill()
    {
        if (QuestionID != null)
        {

            DataTable question = dba.GetQuestion(QuestionID);
            DataRow row = question.Rows[0];

            Questiontxt.Text = row["Content"].ToString();
            ordertxt.Text = row["QuestionOrder"].ToString();
        
            answerCategoryDDL.SelectedIndex = Convert.ToInt32(row["AnswerCategoryID"]) - 1;
           
        }


    }

    protected void BindAnswerCategories()
    {
        answerCategoryDDL.DataSource = dba.GetAnswerCategories(null);
        answerCategoryDDL.DataTextField = "Name";
        answerCategoryDDL.DataValueField = "ID";
        answerCategoryDDL.DataBind();

    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainQuestions.aspx");
    }

    protected void savebtn_Click(object sender, EventArgs e)
    {
        if (QuestionID != null)
        {
            dba.UpdateQuestion(QuestionID, Questiontxt.Text, answerCategoryDDL.SelectedIndex+1, Convert.ToInt32(ordertxt.Text));
            Response.Redirect("MaintainQuestions.aspx");
            
        }

        else
        {
            dba.UpdateQuestion(null, Questiontxt.Text, answerCategoryDDL.SelectedIndex + 1, Convert.ToInt32(ordertxt.Text));
            Response.Redirect("MaintainQuestions.aspx");  

        }
     }
}