namespace BeeWee.DiscogsDotNet.Models
{
    public class Refund
    {
        public int amount { get; set; }
        public Order order { get; set; }
    }
}