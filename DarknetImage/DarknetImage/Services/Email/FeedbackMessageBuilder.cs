using Ratul.Utility.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarknetImage.Services.Email
{
    public class FeedbackMessageBuilder : MessageBuilder, IFeedbackMessageBuilder
    {
        private string _message;

        public void Build(string message)
        {
            _message = message;
        }

        protected override string GetSubject()
        {
            return "Feedback From Darknet Image";
        }

        protected override string GetBody()
        {
            string body = "<h3>Knife found</h3> <br>" + _message;
            return body;
        }

        protected override NameWithEmail GetFrom()
        {
            return base.GetSystemNameWithEmail();
        }

        protected override List<NameWithEmail> GetToList()
        {
            // TODO: Provide receiver's email address
            List<NameWithEmail> nameWithEmails = new List<NameWithEmail>()
            {
                new NameWithEmail("Asraf Uddin Ahmed", "13ratul@gmail.com")
            };
            return nameWithEmails;
        }

        protected override List<NameWithEmail> GetReplyToList()
        {
            return new List<NameWithEmail>() { base.GetSystemNameWithEmail() };
        }

    }
}
