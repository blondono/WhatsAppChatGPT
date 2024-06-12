namespace WhatsAppNet.Api.Interfaces
{
    public interface IWhatsappCloudSendMessage
    {
        Task<bool> Execute(object model);
    }
}
