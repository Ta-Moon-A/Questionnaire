using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainScoreDifferences : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScoreDifferencesRG.DataSource = null;
            ScoreDifferencesRG.DataSource = dba.GetScoreDifferences(null);
            ScoreDifferencesRG.DataBind();


        }
    }

    protected void ScoreDifferencesRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainScoreDifference.aspx?id=");

                    break;
                }
            case "Update":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainScoreDifference.aspx?id=" + e.CommandArgument);

                    break;
                }
            case "Delete":
                {
                    if (dba.DeleteScoreDifferences(Convert.ToInt32(e.CommandArgument)))
                    {
                        ScoreDifferencesRG.DataSource = dba.GetScoreDifferences(null);
                    }
                    else
                    {

                        errorlbl.Text = "This  row  can't  be removed from the database.";
                        ScoreDifferencesRG.DataSource = dba.GetScoreDifferences(null);
                        ScoreDifferencesRG.DataBind();
                    }
                    break;
                }
        }
    }
}