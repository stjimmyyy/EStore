namespace E_Store.Classes
{
    public class FlashMessage
    {
        public string Message { get; set; }
        public FlashMessageType Type { get; set; }

        public FlashMessage(string message, FlashMessageType type)
        {
            this.Message = message;
            this.Type = type;
        }
    }
}