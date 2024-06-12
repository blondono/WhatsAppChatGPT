using Microsoft.AspNetCore.Mvc;
using WhatsAppNet.Api.Interfaces;
using WhatsAppNet.Api.Models.WhatsappCloud;
using WhatsAppNet.Api.Util;

namespace WhatsAppNet.Api.Controllers
{
    [ApiController]
    [Route("api/whatsapp")]
    public class WhatsappController : Controller
    {
        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;

        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Sample()
        {
            return Ok("running...");
        }

        [HttpGet]
        public async Task<IActionResult> VerifyToken()
        {
            string AccessToken = "6a2cf5a7-2f44-4268-8a46-83a601d26531";

            var token = Request.Query["hub.verify_token"].ToString();
            var challenge = Request.Query["hub.challenge"].ToString();

            if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrEmpty(challenge)
                && token == AccessToken)
            {
                return Ok(challenge);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]

        public async Task<IActionResult> ReceiveMessage([FromBody] WhatsappCloudModel model)
        {
            try
            {
                var message = model.Entry.FirstOrDefault()?.Changes.FirstOrDefault()?.Value.Messages.FirstOrDefault();
                if (message is not null)
                {
                    var userNumber = message.From;
                    var userText = GetUserText(message);

                    var sendMessage = new WhatsappCloudSendMessage(userNumber);

                    switch (userText.ToUpper())
                    {
                        case "ESPAÑA":
                        case "FRANCIA":
                        case "ALEMANIA":
                            sendMessage.SetText($"Seleccionaste {userText}");
                            break;
                        case "TEXT":
                            sendMessage.SetText("Hola desde la API");
                            break;
                        case "IMAGE":
                            sendMessage.SetMedia(WhatsappMessageType.Image, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRU3TimMVsdJ9qFZjKPk8zB4jM05K5LefaEnQ&s", "Imagen desde la API");
                            break;
                        case "VIDEO":
                            sendMessage.SetMedia(WhatsappMessageType.Video, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", "Video desde la API");
                            break;
                        case "AUDIO":
                            sendMessage.SetMedia(WhatsappMessageType.Audio, "https://projects.skratchdot.com/audio-files/loops/loop354.mp3", "Audio desde la API");
                            break;
                        case "DOCUMENT":
                            sendMessage.SetDocument("https://www.orimi.com/pdf-test.pdf", "API Document", "Bryan Document");
                            break;
                        case "LOCATION":
                            sendMessage.SetLocation("6.256937632552716", "-75.58970083435027", "EL ANASTASIO", "Cra. 74 #48010, Laureles");
                            break;
                        case "BUTTON":
                            Dictionary<string, string> buttons = new Dictionary<string, string>();
                            buttons.Add("ES", "España");
                            buttons.Add("FR", "Francia");
                            buttons.Add("DE", "Alemania");
                            sendMessage.SetButtons("¿What country would you like to visit?", buttons);
                            break;
                        default:
                            sendMessage.SetText("Sorry! I don't undestand you");
                            break;
                    }

                    var result = await _whatsappCloudSendMessage.Execute(sendMessage);
                }
                return Ok("EVENT_RECEIVED");
            }
            catch (Exception ex)
            {
                return Ok("EVENT_RECEIVED");
            }
        }

        private string GetUserText(Messages messages)
        {
            string typeMessage = messages.Type;

            if (typeMessage.ToUpper() == "TEXT")
                return messages.Text.Body;
            else if (typeMessage.ToUpper() == "INTERACTIVE")
            {
                var interactiveType = messages.Interactive.Type;
                if (interactiveType.ToUpper() == "LIST_REPLY")
                    return messages.Interactive.List_Reply?.Title;
                else if (interactiveType.ToUpper() == "BUTTON_REPLY")
                    return messages.Interactive.Button_Reply?.Title;
                else return string.Empty;
            }
            else return string.Empty;
        }
    }
}
