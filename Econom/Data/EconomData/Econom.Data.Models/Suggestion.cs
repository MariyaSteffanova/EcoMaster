namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Suggestion : AuditInfo
    {
        private ICollection<Notification> notifications;

        public Suggestion()
        {
            this.notifications = new HashSet<Notification>();
        }

        [Key]
        public int ID { get; set; }

        public int Approvals { get; set; }

        public bool IsApproved { get; set; }

        public string Notes { get; set; }

        public string SenderID { get; set; }

        [ForeignKey("SenderID")]
        public virtual User Sender { get; set; }

        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public virtual Recipe Recipe { get; set; }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}
