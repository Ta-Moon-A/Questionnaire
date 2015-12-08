using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ChangePassword : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    public int? userID
    {  
        get
        {
            int userID;
            if (Int32.TryParse(Session["ID"].ToString(), out userID))
            {
                return userID;
            }
            else return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (userID > 0)
        {
            if (!IsPostBack)
            {
                Fill(userID);
                password1.Attributes["onclick"] = "this.value=''";
                password2.Attributes["onclick"] = "this.value=''";
            }
        }
    }

    public void Fill(int? UID)
    {
        DataTable tbuser = dba.GetUsers(UID);
        DataRow row = tbuser.Rows[0];
        emailtxt.Text=row["Email"].ToString();
        salutationtxt.Text = row["Salutation"].ToString();
        password1.Attributes.Add("value", row["Password"].ToString());
        password2.Attributes.Add("value", row["Password"].ToString());
    }

    protected void Savebtn_Click(object sender, EventArgs e)
    {
        bool updateResult = dba.ChangePassowrd(userID, emailtxt.Text, password1.Text, salutationtxt.Text);
        if (!updateResult)
        {
            Response.Write("Error !");
        }
        Response.Redirect("ViewDashboard.aspx");
    }

    protected void Cancelbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewDashboard.aspx");
    }
    
}