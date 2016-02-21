namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        [Key]
        public int ID { get; set; }

        public string SenderID { get; set; }

        [ForeignKey("SenderID")]
        public User Sender { get; set; }

        public string ReceiverID { get; set; }

        [ForeignKey("ReceiverID")]
        public User Receiver { get; set; }

        public int SuggestionID { get; set; }

        [ForeignKey("SuggestionID")]
        public Suggestion Suggestion { get; set; }
    }
}
