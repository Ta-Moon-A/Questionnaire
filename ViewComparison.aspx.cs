using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewComparison : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

        ViewProfileName(Convert.ToInt32(Request.QueryString["CountryID"]));

        UserInfoRPTR.ItemDataBound += UserInfoRPTR_ItemDataBound;
        UserInfoRPTR.DataSource = dba.GetComparison(Convert.ToInt32(Session["ID"]), Convert.ToInt32(Request.QueryString["CountryID"]));
        UserInfoRPTR.DataBind();
    }

    protected void UserInfoRPTR_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

      #region UserProfileInfo


        DataTable ScoreDifferenceAttributes = dba.GetScoreDifferenceByScore(Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "UserScore")));
        DataRow row = ScoreDifferenceAttributes.Rows[0];

        if (Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "UserScore")) > 0)
        {
            Label test = (Label)e.Item.FindControl("PersonChoicelbl");
            test.Text = row["PrimaryPrefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeB").ToString();
            test.Attributes.Add("style", row["Style"].ToString());

            Label test1 = (Label)e.Item.FindControl("PersonDifferencelbl");
            test1.Text = row["Secondary Prefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeA").ToString();
            test1.Attributes.Add("style", row["Style"].ToString());
        }

        else
        {
            Label test = (Label)e.Item.FindControl("PersonChoicelbl");
            test.Text = row["PrimaryPrefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeA").ToString();
            test.Attributes.Add("style", row["Style"].ToString());

            Label test1 = (Label)e.Item.FindControl("PersonDifferencelbl");
            test1.Text = row["Secondary Prefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeB").ToString();
            test1.Attributes.Add("style", row["Style"].ToString());
        }

   #endregion

      #region CountryProfileInfo

        DataTable ScoreDifferenceAttributes1 = dba.GetScoreDifferenceByScore(Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "CountryScore")));
        DataRow row1 = ScoreDifferenceAttributes1.Rows[0];



        if (Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "CountryScore")) > 0)
        {
            Label test = (Label)e.Item.FindControl("CountryChoicelbl");
            test.Text = row1["PrimaryPrefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeB").ToString();

            Label test1 = (Label)e.Item.FindControl("CountryDifferencelbl");
            test1.Text = row1["Secondary Prefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeA").ToString();
        }

        else
        {
            Label test = (Label)e.Item.FindControl("CountryChoicelbl");
            test.Text = row1["PrimaryPrefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeA").ToString();


            Label test1 = (Label)e.Item.FindControl("CountryDifferencelbl");
            test1.Text = row1["Secondary Prefix"].ToString() + " " + DataBinder.Eval(e.Item.DataItem, "AttributeB").ToString();
        }

        #endregion

      #region DifferenceImage


        double proffileDifference = Math.Abs(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserScore"))  - Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CountryScore")));

        Image difImage = (Image)e.Item.FindControl("DifferenceImage");
        difImage.ImageUrl = "~/IconHandler.ashx?id=" + dba.GetIconByScore(proffileDifference);

     #endregion

    }

    public void ViewProfileName(int UID)
    {
        DBAdapter dba = new DBAdapter();
        DataTable tbuser = dba.GetUsers(UID);
        DataRow row = tbuser.Rows[0];
        Peoplelbl.Text = row["Organization"].ToString()+"<br/>" + "generally prefer ";
    }


   
}