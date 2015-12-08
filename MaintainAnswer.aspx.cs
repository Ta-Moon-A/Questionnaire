using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

public partial class MaintainAnswer : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    public int? AnswerID
    {
        get
        {
            int ID;
            if (Int32.TryParse(Request.QueryString["AnswID"].ToString(), out ID))
            {
                return ID;
            }
            else return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }

    public void Fill()
    {
        if (AnswerID!=null)
        {
            DataTable answer = dba.GetAnswersByID(AnswerID);
            DataRow row = answer.Rows[0];
            AnswerCategoryLbl.Visible = true;
            AnswerCategoryLbl.Text = row["categoryname"].ToString();
        }


        else if (Session["AnswerCategoryID"] != null)
        { 
            DataTable answers = dba.GetAnswerCategoryName((int)Session["AnswerCategoryID"]);
            if (answers.Rows.Count>0)
            {
                 DataRow row = answers.Rows[0];
                 AnswerCategoryLbl.Visible = true;
                 AnswerCategoryLbl.Text = row["Name"].ToString();
            }
           
           
        }

        if (AnswerID!=null)
        {
            DataTable answer = dba.GetAnswersByID(AnswerID);
            DataRow row = answer.Rows[0];
            AnswerContenttxt.Text = row["Content"].ToString();
            ordertxt.Text = row["AnswerOrder"].ToString();
            idtxt.Text = row["ID"].ToString();
            Scoretxt.Text = row["Score"].ToString();

            string Colour = row["Color"].ToString();
            string[] rgb = Colour.Split('.');

            Rcolourtxt.Text = rgb[0];
            Gcolourtxt.Text = rgb[1];
            bColourtxt.Text = rgb[2];

            
         }


    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {   
        int catid;
        if (AnswerID != null)
        {
            DataTable answer = dba.GetAnswersByID(AnswerID);
            DataRow row = answer.Rows[0];
             catid = Convert.ToInt32(row["categoryid"].ToString());
        }
        else {
            catid = (int)Session["AnswerCategoryID"];
            }

        Response.Redirect("MaintainAnswerCategory.aspx?CatID=" + catid);
    }

    protected void savebtn_Click(object sender, EventArgs e)
    {
        int catid;
        if (AnswerID != null)
        {
            DataTable answer = dba.GetAnswersByID(AnswerID);
            DataRow row = answer.Rows[0];
            catid = Convert.ToInt32(row["categoryid"].ToString());
        }
        else
        {
            catid = (int)Session["AnswerCategoryID"];
        }


        if (dba.InsertAnswer(AnswerID, AnswerContenttxt.Text, Convert.ToDouble(Scoretxt.Text), catid,  Rcolourtxt.Text + "." + Gcolourtxt.Text + "." + bColourtxt.Text, Convert.ToInt32(ordertxt.Text)))
        {
            Response.Redirect("MaintainAnswerCategory.aspx?CatID=" + catid);
        }

        else Response.Write("Error !");
    }

   
}