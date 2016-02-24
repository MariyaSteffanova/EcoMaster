namespace Econom.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Econom.Data.EconomDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Econom.Data.EconomDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(EconomDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "User" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new User
                {
                    Email = "admin@econom.com",
                    UserName = "admin",
                    FirstName = "Eco",
                    LastName = "Admin"
                };

                try
                {
                    userManager.Create(user, "password1");
                }
                catch(System.Exception ex)
                {

                }

                userManager.AddToRoles(user.Id, "User", "Admin");
            }
        }
    }
}
