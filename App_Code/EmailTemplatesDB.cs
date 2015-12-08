using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EmailTemplatesDB
/// </summary>
public class EmailTemplatesDB
{
    string connectionStr = ConfigurationManager.ConnectionStrings["CrossFileConn"].ToString();

    public EmailTemplatesDB()
    {

    }

    #region Select

       public DataTable GetEmailTemplates()
    {
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            SqlCommand cmd = new SqlCommand("emt_GetEmailTemplates", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt;
        }
    }


       public DataRow GetEmailTemplate(int TemplateNameID)
    {
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            SqlCommand cmd = new SqlCommand("emt_GetEmailTemplate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@TemplateNameID", TemplateNameID));

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }
    }


    #endregion

    #region Update

    public void InsertOrUpdateDirectory(EmailTemplateType objEmailTemplateType)
    {
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("emt_InsertOrUpdateEmailTemplate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@TemplateNameID", objEmailTemplateType.TemplateNameID));
            cmd.Parameters.Add(new SqlParameter("@From", objEmailTemplateType.From));
            cmd.Parameters.Add(new SqlParameter("@FromTitle", objEmailTemplateType.FromTitle));
            cmd.Parameters.Add(new SqlParameter("@CC", objEmailTemplateType.CC));
            cmd.Parameters.Add(new SqlParameter("@CCTitle", objEmailTemplateType.CCTitle));
            cmd.Parameters.Add(new SqlParameter("@BCC", objEmailTemplateType.BCC));
            cmd.Parameters.Add(new SqlParameter("@BCCTitle", objEmailTemplateType.BCCTitle));
            cmd.Parameters.Add(new SqlParameter("@Subject", objEmailTemplateType.Subject));
            cmd.Parameters.Add(new SqlParameter("@Body", objEmailTemplateType.Body));
            cmd.Parameters.Add(new SqlParameter("@ConfirmationPage", objEmailTemplateType.ConfirmationPage));
          //  cmd.Parameters.Add(new SqlParameter("@PortalID", objEmailTemplateType.PortalID));

            cmd.ExecuteNonQuery();
        }
    }

    #endregion
}