using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewProfile : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

        rptr.ItemDataBound += rptr_ItemDataBound;
        rptr.DataSource = dba.getQuestionGroupAttributes(Convert.ToInt32(Session["ID"]));
        rptr.DataBind();
        
        
    }

    protected void rptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
            double result = 0;
            result= 50 + (Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "percentage"))/2);


            if (result > 97)
            {
                result = 97;
            }
            else if (result < 0)
            {
                result = 0;
            }
            
        ((HtmlControl)e.Item.FindControl("TEST")).Attributes.Add("style", "top:-40%;left:" +result+ "%;");
     }
    
    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewDashboard.aspx");
    }
}