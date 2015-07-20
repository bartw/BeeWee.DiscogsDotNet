namespace BeeWee.DiscogsDotNet.Models
{
    public class Message
    {
        public Refund refund { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public Order order { get; set; }
        public string subject { get; set; }
        public From from { get; set; }
        public int? status_id { get; set; }
        public Actor actor { get; set; }
        public int? original { get; set; }
        public int? @new { get; set; }
    }
}