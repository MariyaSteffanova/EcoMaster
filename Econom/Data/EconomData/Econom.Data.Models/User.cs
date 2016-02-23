namespace Econom.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Econom.Common;

    public class User : IdentityUser
    {
        private ICollection<User> flatmates;

        public User()
            : base()
        {
            this.flatmates = new HashSet<User>();
        }

        [Required]
        [MaxLength(GlobalConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("HomeStorage")]
        public int? HomeStorageID { get; set; }

        public virtual HomeStorage HomeStorage { get; set; }

        public ICollection<User> Flatmates
        {
            get { return this.flatmates; }
            set { this.flatmates = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
