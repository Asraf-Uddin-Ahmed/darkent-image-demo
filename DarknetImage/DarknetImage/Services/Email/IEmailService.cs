using Ratul.Utility.Email;
namespace DarknetImage.Services.Email
{
    // Director for MessageBuilder
    public interface IEmailService
    {
        void SendText(IMessageBuilder messageBuilder);
        void SendHtml(IMessageBuilder messageBuilder);
        void SendTextAsync(IMessageBuilder messageBuilder);
        void SendHtmlAsync(IMessageBuilder messageBuilder);
        void SendTextAsync(IMessageBuilder messageBuilder, EmailSender.SendCompletedCallback sendCompletedCallback);
        void SendHtmlAsync(IMessageBuilder messageBuilder, EmailSender.SendCompletedCallback sendCompletedCallback);
        void SendAsyncCancel();
    }
}
