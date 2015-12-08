using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class CompleteQuestionnaire : System.Web.UI.Page
{
    public int userID
    {
        get
        {
            int uID;
            if (Int32.TryParse(Request.QueryString["uid"], out uID))
            {
               
                return uID;
            }
            else return (Int32)Session["ID"];
         
        }
    }
   
    public int? QuestID
    {
        get
        {
            int QuestID;
            if (Int32.TryParse(Request.QueryString["QuestID"], out QuestID))
            {
                return QuestID;
            }
            else return null;
        }
    }
   
    DBAdapter dba = new DBAdapter();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {

        #region checkEmaillink



        if (Request.QueryString["sid"] != null && ViewState["EntryQuantity"] == null)
        {


            ViewState.Add("EntryQuantity", 1);

            if (dba.CheckEmailLink(Convert.ToInt32(Request.QueryString["uid"]), Convert.ToInt32(Request.QueryString["QuestID"]), Request.QueryString["sid"].ToString()) > 0)
            {
                Session["ID"] = Convert.ToInt32(Request.QueryString["uid"]);
                Session["RoleId"] = (int)Enums.UserRoles.User;
                dba.DeleteUserInfoForEmail(Convert.ToInt32(Request.QueryString["uid"]), Convert.ToInt32(Request.QueryString["QuestID"]), Request.QueryString["sid"].ToString());

            }
            else
            {
               Response.Redirect("default.aspx");
            }
         }


        #endregion

      QuestionQuantity.Text = "of " + dba.QuestionQuantity.ToString();

        if (QuestID < 1)
        {
            Response.Redirect("ViewQuestionnaireIntro.aspx");
        }
        else if (QuestID > dba.QuestionQuantity)
        {
            Response.Redirect("ViewDashboard.aspx");
        }
        else
        {
            Fill(QuestID);
        }
    }

    public void Fill(int? questionID)
    {
        DataTable question = dba.QuestionContent(questionID);
        DataRow row1 = question.Rows[0];

        QuestionContentLBL.Text = row1["Content"].ToString();
        AnswerNumberLBL.Text =(questionID).ToString();


        DataTable answers = dba.AnswerContent(Convert.ToInt32(row1["ID"]));
        Panel pnl = new Panel();
        
        foreach (DataRow row in answers.Rows)
        {
            Button bt = new Button();
            bt.Text = row["Content"].ToString();
            bt.ID = row["ID"].ToString();
            bt.CssClass = "btn2";

            string[] rgb = row["Color"].ToString().Split('.');
            bt.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]),Convert.ToInt32(rgb[1]),Convert.ToInt32(rgb[2]));
           
            bt.BorderStyle = BorderStyle.None;
            bt.Attributes.Add("style", "margin-bottom:5px;");
            bt.Click += new EventHandler(btnAnswer_Click);
            pnl.Controls.Add(bt);
          
        }
         plHolder1.Controls.Add(pnl);
       
    }

    protected void Prevbtn_Click(object sender, EventArgs e)
    {
        if (QuestID==null)
        {
            
        }
        else
        {
            int questionId = Convert.ToInt32(AnswerNumberLBL.Text);
            Response.Redirect("CompleteQuestionnaire.aspx?QuestID=" + (questionId - 1));
        }
        
    }

    protected void btnAnswer_Click(object sender, EventArgs e)
    {
        DateTime? datecreated = new DateTime();
        DateTime? dateupdated = new DateTime();
        Button button = sender as Button;
        int answerID = Convert.ToInt32(button.ID);

        DataTable question = dba.QuestionContent(QuestID);
        DataRow row1 = question.Rows[0];

        int questionId = Convert.ToInt32(row1["ID"]);

        if (dba.QuestionMaxId(userID) == 0)
        {
            datecreated = DateTime.Now;
            dateupdated = null;
        }
        else
        {
            dateupdated = DateTime.Now;
            datecreated = null;
        }

        int result = dba.CheckLastQuestion(userID);

        bool insertResult = dba.InsertQuestionnaire(userID, questionId, answerID, datecreated, dateupdated);




        if (dba.QuestionMaxId(userID) + 1 > dba.QuestionQuantity && result < 1)
        {
            Response.Redirect("FinishQuestionnaire.aspx");
        }

        else if (dba.QuestionMaxId(userID) < dba.QuestionQuantity)
        {

            Response.Redirect("CompleteQuestionnaire.aspx?QuestID=" + (dba.QuestionMaxId(userID) + 1));

        }
        Response.Redirect("ViewQuestionList.aspx");
    }

    protected void Listbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewQuestionList.aspx");
    }
}
