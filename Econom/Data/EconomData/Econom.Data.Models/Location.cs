namespace Econom.Data.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;

    public class Location : IDeletableEntity
    {
        [Key]
        public int ID { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Address { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
