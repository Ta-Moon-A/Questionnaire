using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class CrossFileMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (Convert.ToInt32(Session["RoleId"]) == (int)Enums.UserRoles.Supervisor)
            {
                MainMenu.Items.FindItemByValue("AdminItems").Visible = false;
            }
            else
            {
                MainMenu.Items.FindItemByValue("SupervisorItems").Visible = false;
            }
        }
      
       
    }

    protected void MainMenu_ItemClick(object sender, RadMenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "LogOut":
                //Session["RoleId"] = null;
                //Session["ID"] = null;
                Session.Abandon();
                Response.Redirect("Default.aspx");
                break;
           
        }
    }
}
