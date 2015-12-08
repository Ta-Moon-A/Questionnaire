using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

public partial class MaintainQuestionGroup : System.Web.UI.Page
{
    public int? GroupID
    {
        get
        {
            int grID;
            if (Int32.TryParse(Request.QueryString["GroupID"].ToString(), out grID))
            {
                return grID;
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
            BindQuestions();
        }
    }

    public void Fill()
    {

        if (GroupID != null)
        {
            DataTable QuestionGroupInfo = dba.GetQuestionGroupInfo(GroupID);
            if (QuestionGroupInfo.Rows.Count > 0)
            {
                DataRow row = QuestionGroupInfo.Rows[0];
                Nametxt.Text = row["Name"].ToString();
                Descriptiontxt.Text = row["Description"].ToString();
                ordertxt.Text = row["QuestionGroupOrder"].ToString();
                MaxScoretxt.Text = row["MaximumAnswerScore"].ToString();

                string Colour = row["Color"].ToString();
                string[] rgb = Colour.Split('.');

                Rcolourtxt.Text = rgb[0];
                Gcolourtxt.Text = rgb[1];
                bColourtxt.Text = rgb[2];


                AttributeAtxt.Text = row["AttributeA"].ToString();
                AttributeBtxt.Text = row["AttributeB"].ToString();
            }

           QuestionsRG.DataSource = null;
           QuestionsRG.DataSource = dba.GetQuestionInfo(GroupID);
           QuestionsRG.DataBind();


        }
        else QuestionsRG.Visible = false;
    
    
    
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainQuestionGroups.aspx");
    }

    protected void savebtn_Click(object sender, EventArgs e)
    {

        dba.InsertQuestionGroupInfo(GroupID, Nametxt.Text, Descriptiontxt.Text, AttributeAtxt.Text, AttributeBtxt.Text,Convert.ToInt32(ordertxt.Text),Convert.ToDouble(MaxScoretxt.Text), Rcolourtxt.Text+"." + Gcolourtxt.Text +"."+ bColourtxt.Text);
        Response.Redirect("MaintainQuestionGroups.aspx");
    }

    #region Paging

    protected void QuestionsRG_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        QuestionsRG.CurrentPageIndex = e.NewPageIndex;
        QuestionsRG.DataSource = dba.GetQuestionInfo(GroupID);
    }
    
    protected void QuestionsRG_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        QuestionsRG.DataSource = dba.GetQuestionInfo(GroupID);
    }
    
    #endregion

    protected void BindAnswerCategories()
    {
        AnswerCategoryDDL.DataSource = dba.GetAnswerCategories(null);
        AnswerCategoryDDL.DataTextField = "Name";
        AnswerCategoryDDL.DataValueField = "ID";
        AnswerCategoryDDL.DataBind();

    }

    protected void BindQuestions()
    {
        QuestionDDL.DataSource = dba.GetQuestionInfo(null);
        QuestionDDL.DataTextField = "Content";
        QuestionDDL.DataValueField = "ID";
        QuestionDDL.DataBind();

    }

    protected void QuestionsRG_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    AnswerCategorylbL.Visible = true;
                    AnswerCategoryDDL.Visible = true;
                    QuestionDDL.SelectedIndex = 0;
                    QuestionWghtUpdatetxt.Text = "";
                    QuestionOrdertxt.Text = "";
                    InsertUpdateDiv.Visible = true;
                    BindAnswerCategories();


                    break;
                }
            case "Update":
                {
                    AnswerCategorylbL.Visible = false;
                    AnswerCategoryDDL.Visible = false;
                    DataTable question = dba.GetQuestionForGroup(Convert.ToInt32(e.CommandArgument));
                    DataRow row = question.Rows[0];

                    e.Canceled = true;
                    InsertUpdateDiv.Visible = true;

                    QuestionOrdertxt.Text = row["QuestionOrder"].ToString();
                    QuestionDDL.SelectedIndex = Convert.ToInt32(row["ID"]) - 1;
                    QuestionWghtUpdatetxt.Text = row["Weight"].ToString();

                    ViewState.Add("QuestionId", e.CommandArgument);

                    break;
                }
            case "Delete":
                {
                    dba.DeleteQuestion(Convert.ToInt32(e.CommandArgument));
                    break;
                }
        }
    }

    protected void UpdateSave_Click(object sender, EventArgs e)
    {
       if (ViewState["QuestionId"] != null)
        {
            int id = Convert.ToInt32(ViewState["QuestionId"]);

            dba.InsertQuestion(id, Convert.ToDouble(QuestionWghtUpdatetxt.Text), null, Convert.ToInt32(QuestionOrdertxt.Text), QuestionDDL.SelectedText, null);

            Response.Redirect("MaintainQuestionGroup.aspx?GroupID=" + GroupID);


        }
        else
        {
            
                dba.UpdateEmptyQuestion(QuestionDDL.SelectedIndex + 1, Convert.ToDouble(QuestionWghtUpdatetxt.Text), GroupID, Convert.ToInt32(QuestionOrdertxt.Text), AnswerCategoryDDL.SelectedIndex + 1);
                Response.Redirect("MaintainQuestionGroup.aspx?GroupID=" + GroupID);
            

        }
    }

    protected void CancelUpdate_Click(object sender, EventArgs e)
    {
        if (GroupID!=null)
        {
            InsertUpdateDiv.Visible = false;
            Response.Redirect("MaintainQuestionGroup.aspx?GroupID=" + GroupID); 
        }
        
            
        
        
    }
}