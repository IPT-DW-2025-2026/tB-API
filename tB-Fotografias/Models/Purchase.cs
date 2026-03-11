using Mono.TextTemplating;

namespace tB_Fotografias.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
    }

    public enum State
    {
        Pending,
        Paid,
        Sent,
        Delivered,
        Closed
    }

}
