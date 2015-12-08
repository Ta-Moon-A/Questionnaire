using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    DBAdapter dba = new DBAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void logonbtn_Click(object sender, EventArgs e)
    {
        DataTable tbuser = dba.CheckUser(emailtxt.Text, passwordtxt.Text);

        if (tbuser.Rows.Count != 0)
        {
            DataRow row = tbuser.Rows[0];

            if (Convert.ToInt32(row["UserRoleID"]) == (int)Enums.UserRoles.User)
            {
                Session["RoleId"] = (int)Enums.UserRoles.User;
                Session["ID"] = row["ID"];


                if (dba.QuestionMaxId(Convert.ToInt32(row["ID"])) > 0)
                {

                    Response.Redirect("CompleteQuestionnaire.aspx?QuestID=" + (dba.QuestionMaxId(Convert.ToInt32(row["ID"]))+1));
                }
                else
                {
                    Response.Redirect("ViewQuestionnaireIntro.aspx");
                }

            }
            else if (Convert.ToInt32(row["UserRoleID"]) == (int)Enums.UserRoles.Admin)
            {
                Session["RoleId"] = (int)Enums.UserRoles.Admin;
                Session["ID"] = row["ID"];
                Response.Redirect("AdminDefault.aspx");
            }
            else
            {
                Session["RoleId"] = (int)Enums.UserRoles.Supervisor;
                Session["ID"] = row["ID"];
                Response.Redirect("AdminDefault.aspx");
            }
        }
        else
        {
            errorlbl.Text = "Invalid Email or Password!";
            emailtxt.Text = "";
            passwordtxt.Text = "";

        }
    }


    public void EmailLnkBtn_Click(object sender, EventArgs e)
    {

        if (dba.GetUserByEmail(emailtxt.Text) == null)
        {
            errorlbl.Text = "Email Address is invalid!";
        }
        else
        {

            EmailTemplateType user = GetUser(emailtxt.Text);
            EmailSender es = new EmailSender();
            es.SendEmail(user);

        }
    }


    private EmailTemplateType GetUser(string Email)
    {
        EmailTemplatesDB emDb = new EmailTemplatesDB();
        DataRow row = emDb.GetEmailTemplate(1);

        EmailTemplateType emtObject = new EmailTemplateType();
        emtObject.BCC = row["BCC"].ToString();
        emtObject.BCCTitle = row["BCCTitle"].ToString();
        emtObject.Body = row["Body"].ToString();
        emtObject.Subject = row["Subject"].ToString();
        emtObject.CC = row["CC"].ToString();
        emtObject.CCTitle = row["CCTitle"].ToString();
        emtObject.ConfirmationPage = row["ConfirmationPage"].ToString();
        emtObject.From = row["From"].ToString();
        emtObject.FromTitle = row["FromTitle"].ToString();

        emtObject.EmailTo = Email;

        DataRow user = dba.GetUserByEmail(Email);

        emtObject.ID = Convert.ToInt32(user["ID"]);
        emtObject.Firstname = user["Firstname"].ToString();
        emtObject.Surname = user["Surname"].ToString();
        emtObject.Salutation = user["Salutation"].ToString();
        emtObject.Organisation = user["Organization"].ToString();
        emtObject.Password = user["Password"].ToString();
        emtObject.Email = Email;

        Guid g = Guid.NewGuid();
        dba.InsertUserInfoForEmail(Convert.ToInt32(user["ID"]), dba.QuestionMaxId(Convert.ToInt32(user["ID"]))+1, g.ToString());


        if (dba.QuestionMaxId(Convert.ToInt32(user["ID"])) > 0)
        {
            emtObject.ProfileLink = "http://"+Request.Url.Authority+"/CompleteQuestionnaire.aspx?uid=" + Convert.ToInt32(user["ID"]) + "&QuestID=" + (dba.QuestionMaxId(Convert.ToInt32(user["ID"]))+1) + "&sid=" + g;

        }
        else
        {
          
            emtObject.ProfileLink = "http://" + Request.Url.Authority + "/ViewQuestionnaireIntro.aspx?uid=" + Convert.ToInt32(user["ID"]) + "&QuestID=" + 1 + "&sid=" + g;
        }
        

        return emtObject;
    }
}
























//MailAddress addressFrom = new MailAddress("progproger@gmail.com", "progproger@gmail.com", Encoding.UTF8);
//MailAddress addressTo = new MailAddress("tamar.tkhlashidze@saatec.com");



//MailMessage message = new MailMessage(addressFrom, addressTo);
//message.Priority = MailPriority.Normal;
//message.SubjectEncoding = Encoding.UTF8;
////message.IsBodyHtml = true;
//message.BodyEncoding = Encoding.UTF8;


//message.Subject = "just testing";
//message.Body = "this is a body";

//SmtpClient smtp = new SmtpClient();
//smtp.Host = "127.0.0.1";

//smtp.Send(message);