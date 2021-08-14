namespace E_Store.Data.Classes
{
    public enum OrderState: byte
    {
        Created,
        Completed,
        Accepted,
        Sent,
        Suspend,
        Canceled
    }
}