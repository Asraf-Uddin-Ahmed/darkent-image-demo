using Ratul.Utility.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarknetImage.Services.Email
{
    public class EmailService : IEmailService
    {
        private EmailSender _emailSender;


        public EmailService()
        {
            this.InitializeEmailSender();
        }



        public void SendText(IMessageBuilder messageBuilder)
        {
            _emailSender.Send(messageBuilder.GetText());
        }
        public void SendHtml(IMessageBuilder messageBuilder)
        {
            _emailSender.Send(messageBuilder.GetHtml());
        }
        public void SendTextAsync(IMessageBuilder messageBuilder)
        {
            _emailSender.SendAsync(messageBuilder.GetText());
        }
        public void SendHtmlAsync(IMessageBuilder messageBuilder)
        {
            _emailSender.SendAsync(messageBuilder.GetHtml());
        }
        public void SendTextAsync(IMessageBuilder messageBuilder, EmailSender.SendCompletedCallback sendCompletedCallback)
        {
            _emailSender.SendAsync(messageBuilder.GetText(), sendCompletedCallback);
        }
        public void SendHtmlAsync(IMessageBuilder messageBuilder, EmailSender.SendCompletedCallback sendCompletedCallback)
        {
            _emailSender.SendAsync(messageBuilder.GetHtml(), sendCompletedCallback);
        }
        public void SendAsyncCancel()
        {
            _emailSender.SendAsyncCancel();
        }


        private void InitializeEmailSender()
        {
            // TODO: Change email settings
            EmailSettings emailSettings = new EmailSettings();
            emailSettings.Host = "mail.host";
            emailSettings.UserName = "username@mail.com";
            emailSettings.Password = "password";
            emailSettings.Port = 587;
            emailSettings.EnableSsl = false;
            _emailSender = new EmailSender(emailSettings);
        }

    }
}