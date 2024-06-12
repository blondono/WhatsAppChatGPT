using Newtonsoft.Json;

namespace WhatsAppNet.Api.Models.WhatsappCloud
{
    public class WhatsappCloudSendMessage
    {
        public WhatsappCloudSendMessage(string number)
        {
            Number = number;
        }

        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; } = "whatsapp";

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("to")]
        public string Number { get; set; }

        [JsonProperty("text")]
        public WhatsappCloudSendMessageText? Text { get; set; }

        [JsonProperty("image")]
        public WhatsappCloudSendMessageMedia? Image { get; set; }

        [JsonProperty("audio")]
        public WhatsappCloudSendMessageMedia? Audio { get; set; }

        [JsonProperty("document")]
        public WhatsappCloudSendMessageDocument? Document { get; set; }

        [JsonProperty("video")]
        public WhatsappCloudSendMessageMedia? Video { get; set; }

        [JsonProperty("location")]
        public WhatsappCloudSendMessageLocation? Location { get; set; }

        [JsonProperty("interactive")]
        public WhatsappCloudSendMessageInteractive? Interactive { get; set; }
    }

    public class WhatsappCloudSendMessageText
    {

        [JsonProperty("body")]
        public string Body { get; set; }
    }
    public class WhatsappCloudSendMessageMedia
    {

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("caption")]
        public string? Caption { get; set; }
    }

    public class WhatsappCloudSendMessageDocument : WhatsappCloudSendMessageMedia
    {
        [JsonProperty("filename")]
        public string FileName { get; set; }
    }
    public class WhatsappCloudSendMessageLocation
    {

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }
    }

    public class WhatsappCloudSendMessageInteractive
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public WhatsappCloudSendMessageInteractiveBody Body { get; set; }

        [JsonProperty("action")]
        public WhatsappCloudSendMessageInteractiveAction Action { get; set; }
    }
    public class WhatsappCloudSendMessageInteractiveBody
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class WhatsappCloudSendMessageInteractiveAction
    {
        [JsonProperty("buttons")]
        public List<WhatsappCloudSendMessageInteractiveActionButtons> Buttons { get; set; }
    }
    public class WhatsappCloudSendMessageInteractiveActionButtons
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("reply")]
        public WhatsappCloudSendMessageInteractiveActionButtonsReply Reply { get; set; }
    }
    public class WhatsappCloudSendMessageInteractiveActionButtonsReply
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
