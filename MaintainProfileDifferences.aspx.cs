using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainProfileDifferences : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProfileDifferencesRG.DataSource = null;
            ProfileDifferencesRG.DataSource = dba.GetProfileDifferences(null);
            ProfileDifferencesRG.DataBind();


        }
    }
    protected void ProfileDifferencesRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainProfileDifference.aspx?id=");

                    break;
                }
            case "Update":
                {
                    errorlbl.Text = "";
                    Response.Redirect("MaintainProfileDifference.aspx?id="+e.CommandArgument);

                    break;
                }
            case "Delete":
                {
                    if (dba.DeleteProfileDifferences(Convert.ToInt32(e.CommandArgument)))
                    {
                        ProfileDifferencesRG.DataSource = dba.GetProfileDifferences(null);
                    }
                    else
                    {
                        errorlbl.Text = "This  row  can't  be removed from the database.";
                        ProfileDifferencesRG.DataSource = dba.GetProfileDifferences(null);
                        ProfileDifferencesRG.DataBind();

                    }
                    break;
                }
        }


    }
}