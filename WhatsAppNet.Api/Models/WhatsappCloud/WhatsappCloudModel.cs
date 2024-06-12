namespace WhatsAppNet.Api.Models.WhatsappCloud
{
    public class WhatsappCloudModel
    {
        public string Object { get; set; }
        public List<Entry> Entry { get; set; }
    }
    public class Entry
    {
        public string Id { get; set; }
        public List<Changes> Changes { get; set; }
    }
    public class Changes
    {
        public string? Field { get; set; }
        public Value? Value { get; set; }
    }
    public class Value
    {
        public string Messaging_Product { get; set; }
        public Metadata? Metadata { get; set; }
        public List<Contacts>? Contacts { get; set; }
        public List<Messages>? Messages { get; set; }
    }
    public class Metadata
    {
        public string? Display_PhoneNumber { get; set; }
        public string? Phone_Number_Id { get; set; }
    }
    public class Contacts
    {
        public Profile? Profile { get; set; }
        public string? Wa_Id { get; set; }
    }
    public class Profile
    {
        public string? Name { get; set; }
    }
    public class Messages
    {
        public string? From { get; set; }
        public string? Id { get; set; }
        public string? TimeStamp { get; set; }
        public string? Type { get; set; }
        public Text? Text { get; set; }
        public Interactive? Interactive { get; set; }
    }
    public class Text
    {
        public string? Body { get; set; }
    }

    public class Interactive
    {
        public string? Type { get; set; }
        public ListReply? List_Reply { get; set; }
        public ButtonReply? Button_Reply { get; set; }
    }
    public class ListReply
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class ButtonReply
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
    }
}
