using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainGroups : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GroupsRG.DataSource = null;
            GroupsRG.DataSource = dba.UserGroups();
            GroupsRG.DataBind();
        }
    }
    protected void GroupsRG_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    errorlbl.Text = "";
                    InsertUpdateDiv.Visible = true;
                    break;
                }
            case "Update":
                {
                    errorlbl.Text = "";
                    e.Canceled = true;
                    InsertUpdateDiv.Visible = true;
                    DataTable usergroup = dba.GetUserGroup(Convert.ToInt32(e.CommandArgument));
                    DataRow row = usergroup.Rows[0];
                    Descriptiontxt.Text = row["Name"].ToString();
                    datetxt.Text =Convert.ToDateTime(row["Date"]).ToString("MM/dd/yyyy");

                    ViewState.Add("UserGroupID", e.CommandArgument);
                    break;
                }
            case "Delete":
                {

                    if (dba.DeleteUserGroup(Convert.ToInt32(e.CommandArgument)))
                    {
                        Response.Redirect("MaintainGroups.aspx");
                    }
                    else
                    {
                        errorlbl.Text = "This  row  can't  be removed from the database.";
                     GroupsRG.DataSource = dba.UserGroups();
                     GroupsRG.DataBind();
                    }
                    break;
                }
        }
    }

    protected void Savebtn_Click(object sender, EventArgs e)
    {
        if (ViewState["UserGroupID"]==null)
        {
             dba.InsertUserGroup(null, Descriptiontxt.Text, Convert.ToDateTime(datetxt.Text));
             Response.Redirect("MaintainGroups.aspx");
        }
        else
        {
            dba.InsertUserGroup(Convert.ToInt32(ViewState["UserGroupID"]), Descriptiontxt.Text, Convert.ToDateTime(datetxt.Text));
            Response.Redirect("MaintainGroups.aspx");
        }
    }

    protected void Cancelbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainGroups.aspx");
    }
}