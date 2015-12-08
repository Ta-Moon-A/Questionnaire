using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainAnswerCategory : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    public int? CategoryID
    {
        get
        {
            int ID;
            if (Int32.TryParse(Request.QueryString["CatID"].ToString(), out ID))
            {
                return ID;
            }
            else return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["AnswerCategoryID"] = CategoryID;
            FillAnswersRG();

        }
    }

    public void FillAnswersRG()
    {
        DataTable answers = dba.GetAnswerCategoryName(CategoryID);
        if (answers.Rows.Count>0)
        {
            DataRow row = answers.Rows[0];
            AnswerCategoryNametxt.Text = row["Name"].ToString();
        }
        

        AnswersRG.DataSource = null;
        AnswersRG.DataSource = dba.GetAnswers(CategoryID);
        AnswersRG.DataBind();
        
    }

    protected void AnswersRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    if (CategoryID != null)
                    {
                        Response.Redirect("MaintainAnswer.aspx?AnswID=");
                    }
                    else Response.Redirect("MaintainAnswerCategories.aspx");
                    
                    break;
                }
            case "Update":
                {
                    Response.Redirect("MaintainAnswer.aspx?AnswID=" + e.CommandArgument);
                    break;
                }
            case "Delete":
                {
                    if (dba.DeleteAnswer(Convert.ToInt32(e.CommandArgument)))
                    {
                        FillAnswersRG();
                    }
                    else Response.Redirect("MaintainAnswerCategory.aspx?CatID="+CategoryID);
                    break;
                }
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainAnswerCategories.aspx");
    }

    protected void savebtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainAnswerCategories.aspx");
    }
}