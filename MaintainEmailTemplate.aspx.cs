using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MaintainEmailTemplate : System.Web.UI.Page
{
    EmailTemplatesDB objEmailTemplates = new EmailTemplatesDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TemplateDropDownList.DataSource = objEmailTemplates.GetEmailTemplates();
            TemplateDropDownList.DataTextField = "Name";
            TemplateDropDownList.DataValueField = "ID";
            TemplateDropDownList.DataBind();

            BindEmailTemplateToControls();
        }
    }

    private void BindEmailTemplateToControls()
    {
        DataRow dr = objEmailTemplates.GetEmailTemplate(Convert.ToInt32(TemplateDropDownList.SelectedItem.Value));

        if (dr != null)
        {
            FromEmailTextBox.Text = dr["From"].ToString();
            FromEmailTitleTextBox.Text = dr["FromTitle"].ToString();
            CCTextBox.Text = dr["CC"].ToString();
            CCTitleTextBox.Text = dr["CCTitle"].ToString();
            BCCTextBox.Text = dr["BCC"].ToString();
            BCCTitleTextBox.Text = dr["BCCTitle"].ToString();
            SubjectTextBox.Text = dr["Subject"].ToString();
            BodyTextBox.Text = dr["Body"].ToString();
            ConfirmationPageTextBox.Text = dr["ConfirmationPage"].ToString();
        }
        else
        {
            FromEmailTextBox.Text = string.Empty;
            FromEmailTitleTextBox.Text = string.Empty;
            CCTextBox.Text = string.Empty;
            CCTitleTextBox.Text = string.Empty;
            BCCTextBox.Text = string.Empty;
            BCCTitleTextBox.Text = string.Empty;
            SubjectTextBox.Text = string.Empty;
            BodyTextBox.Text = string.Empty;
            ConfirmationPageTextBox.Text = string.Empty;
        }
    }

    private void InsertOrUpdateEmailTemplate()
    {
        EmailTemplateType objEmailTemplateType = new EmailTemplateType();

        objEmailTemplateType.TemplateNameID = Convert.ToInt32(TemplateDropDownList.SelectedItem.Value);
        objEmailTemplateType.From = FromEmailTextBox.Text;
        objEmailTemplateType.FromTitle = string.IsNullOrEmpty(FromEmailTitleTextBox.Text) ? null : FromEmailTitleTextBox.Text;
        objEmailTemplateType.CC = string.IsNullOrEmpty(CCTextBox.Text) ? null : CCTextBox.Text;
        objEmailTemplateType.CCTitle = string.IsNullOrEmpty(CCTitleTextBox.Text) ? null : CCTitleTextBox.Text;
        objEmailTemplateType.BCC = string.IsNullOrEmpty(BCCTextBox.Text) ? null : BCCTextBox.Text;
        objEmailTemplateType.BCCTitle = string.IsNullOrEmpty(BCCTitleTextBox.Text) ? null : BCCTitleTextBox.Text;
        objEmailTemplateType.Subject = SubjectTextBox.Text;
        objEmailTemplateType.Body = BodyTextBox.Text;
        objEmailTemplateType.ConfirmationPage = string.IsNullOrEmpty(ConfirmationPageTextBox.Text) ? null : ConfirmationPageTextBox.Text;
        // objEmailTemplateType.PortalID = portalSettings.PortalID;

        objEmailTemplates.InsertOrUpdateDirectory(objEmailTemplateType);
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            InsertOrUpdateEmailTemplate();
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        // Rainbow.Security.PortalSecurity.PortalHome();
    }

    protected void TemplateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmailTemplateToControls();
    }

}