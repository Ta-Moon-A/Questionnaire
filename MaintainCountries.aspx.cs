using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainCountries : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CountriesRG.DataSource = null;
            CountriesRG.DataSource = dba.GetCountries();
            CountriesRG.DataBind();
        }
    }


    protected void CountriesRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    Session["BackToMaintainCountries"] = true;
                    Response.Redirect("MaintainProfile.aspx?ID=");
                    break;
                }
            case "Update":
                {
                    Session["BackToMaintainCountries"] = true;
                    Response.Redirect("MaintainProfile.aspx?ID=" + e.CommandArgument);
                    break;
                }
            case "Delete":
                {
                    dba.DeleteCountry(Convert.ToInt32(e.CommandArgument));
                    CountriesRG.DataSource = dba.GetCountries();
                    CountriesRG.DataBind();
                    break;
                }
        }
    }
}