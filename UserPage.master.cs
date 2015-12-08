using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
       if (Session["ID"] == null || Session["RoleId"]==null)
        {
            Response.Redirect("Default.aspx");
        }

    }
}
