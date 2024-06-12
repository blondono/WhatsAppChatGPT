using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using WhatsAppNet.Api.Interfaces;

namespace WhatsAppNet.Api.Services.WhatsappCloud
{
    public class WhatsappCloudSendMessage : IWhatsappCloudSendMessage
    {
        public async Task<bool> Execute(object model)
        {
            var client = new HttpClient();
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            using (var content = new ByteArrayContent(byteData))
            {
                string endpoint = "https://graph.facebook.com/";
                string phoneNumberId = "356993247493647";
                string accessToken = "EAAKlUAZA1VX8BO1DAgsGXnb0ITuEmKyuXrkaQtzeoUMMMGBjWcBhgdc1y5j4VNcn1ZBwELtid02tzY9ba7e4GyjBTafy2MDtmvNKP646JYLxDauUj9Rdbz5SRYN1LmZAlZAGsggBNNjluiHbFA4ng5E3nsjiH6UqfKMLOnGcjqRdpPYWXgpPit69dSklTX8c";
                string uri = $"{endpoint}/v19.0/{phoneNumberId}/messages";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                var response = await client.PostAsync(uri, content);

                return response.IsSuccessStatusCode;

            }
        }
    }
}
