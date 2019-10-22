using Ratul.Utility.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarknetImage.Services.Email
{
    public abstract class MessageBuilder : IMessageBuilder
    {
        public MessageSettings GetText()
        {
            MessageSettings messageSettings = this.GetMessageSettings();
            messageSettings.IsBodyHtml = false;
            return messageSettings;
        }

        public MessageSettings GetHtml()
        {
            MessageSettings messageSettings = this.GetMessageSettings();
            messageSettings.IsBodyHtml = true;
            return messageSettings;
        }



        protected abstract string GetSubject();
        protected abstract string GetBody();
        protected abstract NameWithEmail GetFrom();
        protected abstract List<NameWithEmail> GetToList();
        protected abstract List<NameWithEmail> GetReplyToList();
        protected NameWithEmail GetSystemNameWithEmail()
        {
            string systemEmail = "darknet@image.net";
            string systemName = "DarknetImage";
            NameWithEmail systemNameWithEmail = new NameWithEmail(systemName, systemEmail);
            return systemNameWithEmail;
        }



        private MessageSettings GetMessageSettings()
        {
            MessageSettings messageSettings = new MessageSettings();
            messageSettings.Subject = this.GetSubject();
            messageSettings.Body = this.GetBody();
            messageSettings.IsBodyHtml = true;
            messageSettings.From = this.GetFrom();
            messageSettings.ReplyToList = this.GetReplyToList();
            messageSettings.ToList = this.GetToList();
            return messageSettings;
        }

    }
}
