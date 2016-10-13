namespace HorseDelux.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HorseDelux.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HorseDelux.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(HorseDelux.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "ilonka@equiavia.com",
            };
            ir = um.Create(user, "P@ssw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(HorseDelux.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Horses.AddOrUpdate(p => p.Name,
                new Horse
                {
                    Name = "Gryphon Hill",
                    Breed = "New Zealand Warmblood",
                    DateOfBirth = DateTime.Parse("2010-11-08")
                }
            );
        }
    }
}
