using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainScoreDifference : System.Web.UI.Page
{

    DBAdapter dba = new DBAdapter();
    public int? ScoreDifferenceID
    {
        get
        {
            int ID;
            if (Int32.TryParse(Request.QueryString["ID"].ToString(), out ID))
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
            Fill(ScoreDifferenceID);
        }
    }

    public void Fill(int? id)
    {

        if (ScoreDifferenceID != null)
        {
            DataTable Scoredifference = dba.GetScoreDifferences(id);
            DataRow row = Scoredifference.Rows[0];

            leveltxt.Text = row["Level"].ToString();
            fromtxt.Text = row["From"].ToString();
            totxt.Text = row["To"].ToString();
            CSStxt.Text = row["Style"].ToString();
            Primarytxt.Text = row["PrimaryPrefix"].ToString();
            Secondarytxt.Text = row["Secondary Prefix"].ToString();


        }


    }

    protected void savebtn_Click(object sender, EventArgs e)
    {
        #region from-to

        int? from;
        int? to;

        if (string.IsNullOrEmpty(fromtxt.Text))
        {
            from = null;
        }
        else from = Convert.ToInt32(fromtxt.Text);


        if (string.IsNullOrEmpty(totxt.Text))
        {
            to = null;
        }
        else to = Convert.ToInt32(totxt.Text);


        #endregion

        dba.InsertScoreDefference(ScoreDifferenceID, from, to, leveltxt.Text, CSStxt.Text, Primarytxt.Text, Secondarytxt.Text);
        Response.Redirect("MaintainScoreDifferences.aspx");



    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainScoreDifferences.aspx");

    }

}