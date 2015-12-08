using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmailTemplateType
/// </summary>
public class EmailTemplateType
{
	public EmailTemplateType()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public const string DirectoryRegistrationConfirmation = "Directory Registration Confirmation";
    public const string ApprovalConfirmation = "Approval Confirmation";
    public const string RejectionConfirmation = "Rejection Confirmation";
    public const string ResetPassword = "Reset Password";
    public const string EventBookingConfirmation = "Event Booking Confirmation";
    public const string InterestinEventConfirmation = "Interest in Event Confirmation";
    public const string NewsletterSubscription = "Newsletter Subscription";
    public const string Confirmation = "Confirmation";
    public const string WarningforEvent = "Warning for Event";
    public const string PasswordConfirmation = "Password Confirmation";


    public int TemplateNameID { get; set; }
    public string From { get; set; }
    public string FromTitle { get; set; }
    public string CC { get; set; }
    public string CCTitle { get; set; }
    public string BCC { get; set; }
    public string BCCTitle { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string ConfirmationPage { get; set; }
   

    public string EmailTo { get; set; }

    public int ID { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Salutation { get; set; }
    public string Organisation { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ProfileLink { get; set; }
    
}