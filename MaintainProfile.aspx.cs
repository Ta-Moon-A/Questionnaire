using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainProfile : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    public int? userID
    {
        get
        {
            int userID;
            if (Int32.TryParse(Request.QueryString["ID"], out userID))
            {
                return userID;
            }
            else return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (userID>0)
        {
           if (!IsPostBack)
            {
               passwordtxt.Attributes["onclick"] = "this.value=''";
               Fill(userID);
               BindUserGroups();
            }
        } 
        else
           {
               BindUserGroups();
           }
    }

    public void Fill(int? UID)
    {
        
        DataTable tbuser = dba.GetUsers(UID);
        DataRow row = tbuser.Rows[0];
        surnametxt.Text = row["Surname"].ToString();
        firstnametxt.Text = row["Firstname"].ToString();
        Emailtxt.Text=row["Email"].ToString();

        passwordtxt.Attributes.Add("value", row["Password"].ToString());
        salutationtxt.Text = row["Salutation"].ToString();
        organisationtxt.Text = row["Organization"].ToString();

        if (Convert.ToInt32(row["ReferenceProfile"])==1)
        {
            refProfilechk.Checked = true;
        }
        
        groupDDL.SelectedIndex = Convert.ToInt32(row["GroupID"].ToString())-2;
        
        
    }

    protected void BindUserGroups()
        {
            groupDDL.DataSource = dba.UserGroups();
            groupDDL.DataTextField = "Name";
            groupDDL.DataValueField = "ID";
            groupDDL.DataBind();

        }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {

        if (Session["BackToMaintainCountries"]!=null && (bool)Session["BackToMaintainCountries"] == true)
        {
            Session["BackToMaintainCountries"] = null;
            Response.Redirect("MaintainCountries.aspx");
        }
        Response.Redirect("FindProfile.aspx");
    }

    protected void savebtn_Click(object sender, EventArgs e)
    {

        if (userID == null)
        {
            if (dba.CheckUserOnRegistration(Emailtxt.Text) > 0)
            {
                errorlbl.Text = "User already exists with this email address!";
            }

            else
            {
                errorlbl.Text = "";
                dba.InsertUser(userID, Emailtxt.Text, passwordtxt.Text, firstnametxt.Text, surnametxt.Text, organisationtxt.Text, salutationtxt.Text, true, refProfilechk.Checked, DateTime.Now, DateTime.Now, DateTime.Now, null, groupDDL.SelectedIndex + 2, 1);

                if (Session["BackToMaintainCountries"] != null && (bool)Session["BackToMaintainCountries"] == true)
                {
                    Session["BackToMaintainCountries"] = null;
                    Response.Redirect("MaintainCountries.aspx");
                }
                Response.Redirect("FindProfile.aspx");
            }
        }
        else
        {
            

              dba.InsertUser(userID, Emailtxt.Text, passwordtxt.Text, firstnametxt.Text, surnametxt.Text, organisationtxt.Text, salutationtxt.Text, true, refProfilechk.Checked, DateTime.Now, DateTime.Now, DateTime.Now, null, groupDDL.SelectedIndex + 2, 1);
           

            if (Session["BackToMaintainCountries"] != null && (bool)Session["BackToMaintainCountries"] == true)
            {
                Session["BackToMaintainCountries"] = null;
                Response.Redirect("MaintainCountries.aspx");
            }
            Response.Redirect("FindProfile.aspx");
        }
        
    }

    
}