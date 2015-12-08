<%@ WebHandler Language="C#" Class="IconHandler" %>

using System;
using System.Web;
using System.Data;


public class IconHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Data.SqlClient.SqlConnection conn = null;
        System.Data.SqlClient.SqlCommand cmd = null;
        try
        {
            conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CrossFileConn"].ConnectionString);
            cmd = new System.Data.SqlClient.SqlCommand("GetIcon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id",context.Request.QueryString["id"]);
            conn.Open();
            System.Data.SqlClient.SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                if (rdr["Icon"] != DBNull.Value)
                {
                    context.Response.ContentType = "image/jpg";
                    context.Response.BinaryWrite((byte[])rdr["Icon"]);
                }

            }
            if (rdr != null)
                rdr.Close();
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}