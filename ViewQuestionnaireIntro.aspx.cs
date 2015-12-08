using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewQuestionnaireIntro : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

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
    }

    protected void ContBTN_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("CompleteQuestionnaire.aspx?QuestID=" + (dba.QuestionMaxId(userID)+1));
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("ViewDashboard.aspx");
    }
}