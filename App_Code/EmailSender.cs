using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for EmailSender
/// </summary>
public class EmailSender
{
    public EmailSender()
    {

    }

    public void SendEmail(EmailTemplateType objEmailTemplateType)
    {
        MailAddress addressFrom = new MailAddress(objEmailTemplateType.From.ToLower().Trim(), objEmailTemplateType.FromTitle.ToLower().Trim(), Encoding.UTF8);
        MailAddress addressTo = new MailAddress(objEmailTemplateType.EmailTo);

        MailAddress addressCC = !string.IsNullOrEmpty(objEmailTemplateType.CC) ? new MailAddress(objEmailTemplateType.CC, objEmailTemplateType.CCTitle) : null;
        MailAddress addressBCC = !string.IsNullOrEmpty(objEmailTemplateType.BCC) ? new MailAddress(objEmailTemplateType.BCC, objEmailTemplateType.BCCTitle) : null;

        MailMessage message = new MailMessage(addressFrom, addressTo);
        message.Priority = MailPriority.Normal;
        message.SubjectEncoding = Encoding.UTF8;
        //message.IsBodyHtml = true;
        message.BodyEncoding = Encoding.UTF8;

        if (addressCC != null)
            message.CC.Add(addressCC);
        if (addressBCC != null)
            message.Bcc.Add(addressBCC);

        message.Subject = DoReplacement(objEmailTemplateType, objEmailTemplateType.Subject);
        message.Body = DoReplacement(objEmailTemplateType, objEmailTemplateType.Body);

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "127.0.0.1";


        //smtp.Port = 587;
        //smtp.Host = "smtp.gmail.yahoo.com";
        //smtp.EnableSsl = true;
        //smtp.Timeout = 10000;
        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //smtp.UseDefaultCredentials = false;
        //smtp.Credentials = new System.Net.NetworkCredential("tamar.tkhlashidze@saatec.com", "test");



        smtp.Send(message);
    }

    private string DoReplacement(EmailTemplateType objEmailTemplateType, string strBody)
    {
        strBody = strBody.Replace("{first name}", objEmailTemplateType.Firstname);
        strBody = strBody.Replace("{surname}", objEmailTemplateType.Surname);
        strBody = strBody.Replace("{salutation}", objEmailTemplateType.Salutation);
        strBody = strBody.Replace("{email}", objEmailTemplateType.Email);
        strBody = strBody.Replace("{password}", objEmailTemplateType.Password);
        strBody = strBody.Replace("{organisation}", objEmailTemplateType.Organisation);
        strBody = strBody.Replace("{profilelink}", objEmailTemplateType.ProfileLink);


        return strBody;
    }

}