using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainAnswerCategories : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAnswerCategoryRG();

        }
    }

    public void FillAnswerCategoryRG()
    {
        AnswerCategoryRG.DataSource = null;
        AnswerCategoryRG.DataSource = dba.GetAnswerCategories(1);
        AnswerCategoryRG.DataBind();
    }

    protected void AnswerCategoryRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    AnswerCategoryNametxt.Visible = true;
                    Savebtn.Visible = true;
                    AnsCategorylbl.Visible = true;
                    Cancelbtn.Visible = true;
                    break;
                }
            case "Update":
                {
                    Response.Redirect("MaintainAnswerCategory.aspx?CatID=" + e.CommandArgument);
                   
                    break;
                }
            case "Delete":
                {
                    if (dba.DeleteAnswerCategory(Convert.ToInt32(e.CommandArgument)))
                    {
                        FillAnswerCategoryRG();
                    }
                    else  Response.Redirect("MaintainAnswerCategories.aspx");
                    break;
                }
        }
    }

    protected void Savebtn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(AnswerCategoryNametxt.Text))
        {
            dba.InsertAnswerCategory(AnswerCategoryNametxt.Text);
            Response.Redirect("MaintainAnswerCategories.aspx");
        }
        else Response.Redirect("MaintainAnswerCategories.aspx");
        
    }
    protected void Cancelbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainAnswerCategories.aspx");
    }
}