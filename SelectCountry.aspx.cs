using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectCountry : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptr1.DataSource = dba.GetCountries();
            rptr1.DataBind();
        }
    }
    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewDashboard.aspx");
    }
}