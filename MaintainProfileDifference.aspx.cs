using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainProfileDifference : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();
    public int? userID
    {
        get
        {
            int ID;
            if (Int32.TryParse(Request.QueryString["id"].ToString(), out ID))
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
        if (userID!=null)
        {
        
        DataTable ProfileDifference = dba.GetProfileDifference(userID);
        if (ProfileDifference.Rows.Count > 0)
        {
            DataRow row = ProfileDifference.Rows[0];
            leveltxt.Text = row["Level"].ToString();
            fromtxt.Text = row["From"].ToString();
            totxt.Text = row["To"].ToString();


            if (row["Icon"] == DBNull.Value)
            {
                iconImage.Visible = false;

            }
            else
            {
                iconImage.Visible = true;
                iconImage.ImageUrl = "~/IconHandler.ashx?id=" +userID;
            }


        }
       }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainProfileDifferences.aspx");
    }
    protected void savebtn_Click(object sender, EventArgs e)
    {
        var from = String.IsNullOrEmpty(fromtxt.Text) ? (int?)null : Convert.ToInt32(fromtxt.Text);
        var to = String.IsNullOrEmpty(totxt.Text) ? (int?)null : Convert.ToInt32(totxt.Text);



        dba.InsertProfileDefference(userID, from, to, leveltxt.Text, Upload());
        Response.Redirect("MaintainProfileDifferences.aspx");
    
    }

    protected byte[] Upload()
    {
        if (IconUpl.HasFile)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(IconUpl.PostedFile.InputStream);
          

            
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    return memoryStream.ToArray();
                }
            
        }
        else return null;
    }

    public bool ThumbnailCallback()
    {
        return false;
    }

}