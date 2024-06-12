using WhatsAppNet.Api.Models.WhatsappCloud;

namespace WhatsAppNet.Api.Util
{
    public static class WhatsappUtils
    {
        public static void SetMedia(this WhatsappCloudSendMessage message, WhatsappMessageType type, string link, string? caption = null)
        {
            SetPrimaryFields(message, type);
            var mediaObject = new WhatsappCloudSendMessageMedia { Link = link, Caption = caption };
            switch (type)
            {
                case WhatsappMessageType.Image:
                    message.Image = mediaObject;
                    break;
                case WhatsappMessageType.Audio:
                    message.Audio = mediaObject;
                    break;
                default:
                    message.Video = mediaObject;
                    break;

            }
        }
        public static void SetDocument(this WhatsappCloudSendMessage message, string link, string filename, string? caption = null)
        {
            SetPrimaryFields(message, WhatsappMessageType.Document);
            var documentObject = new WhatsappCloudSendMessageDocument { Link = link, Caption = caption, FileName = filename };
            message.Document = documentObject;
        }
        public static void SetText(this WhatsappCloudSendMessage message, string text)
        {
            SetPrimaryFields(message, WhatsappMessageType.Text);
            var textObject = new WhatsappCloudSendMessageText { Body = text };
            message.Text = textObject;
        }
        public static void SetLocation(this WhatsappCloudSendMessage message, string latitude, string longitude, string name, string address)
        {
            SetPrimaryFields(message, WhatsappMessageType.Location);
            var locationObject = new WhatsappCloudSendMessageLocation { Address = address, Latitude = latitude, Longitude = longitude, Name = name };
            message.Location = locationObject;
        }
        public static void SetButtons(this WhatsappCloudSendMessage message, string question, Dictionary<string, string> buttons)
        {
            SetPrimaryFields(message, WhatsappMessageType.Interactive);
            List<WhatsappCloudSendMessageInteractiveActionButtons> listButtons = buttons.Select(x => new WhatsappCloudSendMessageInteractiveActionButtons()
            {
                type = WhatsappMessageType.Reply.ToString().ToLower(),
                Reply = new() { Id = x.Key, Title = x.Value }
            }).ToList();

            WhatsappCloudSendMessageInteractive interactiveObject = new()
            {
                Type = WhatsappMessageType.Button.ToString().ToLower(),
                Body = new() { Text = question },
                Action = new() { Buttons = listButtons }
            };
            message.Interactive = interactiveObject;
        }

        private static void SetPrimaryFields(this WhatsappCloudSendMessage message, WhatsappMessageType type) =>
            message.Type = type.ToString().ToLower();
    }
}
