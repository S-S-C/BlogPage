using BlogPage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BlogPage.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogPage.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        //Personnel login assigned to admin role//
        protected override void Seed(BlogPage.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "sathya.sk2011@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "sathya.sk2011@gmail.com",
                    Email = "sathya.sk2011@gmail.com",
                    FirstName = "Smaru",
                    LastName = "Skali",
                    DisplayName = "SS"
                }, "Bposts!");
            }

            var userId = userManager.FindByEmail("sathya.sk2011@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            //Create moderator role
            var roleModerator = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleModerator.Create(new IdentityRole { Name = "Moderator" });
            }

            var userModerator = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "araynor@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "araynor@coderfoundry.com",
                    Email = "araynor@coderfoundry.com",
                    FirstName = "Antonio",
                    LastName = "Raynor",
                    DisplayName = "AR"
                }, "Mposts!");
            }

            var userId2 = userManager.FindByEmail("araynor@coderfoundry.com").Id;
            userManager.AddToRole(userId2, "Moderator");

            context.BlogPosts.AddOrUpdate(
                  p => p.Title,
                  new BlogPost { Id = 10010, Title = "First Blog Post", Slug = "First-Blog-Post", MediaURL = "/Uploads/BlogPageimage1.jpg", Created = DateTime.Now, Published = true, Body = "The bpdy of my first blog post." },
                  new BlogPost { Id = 10020, Title = "Second Blog Post", Slug = "Second-Blog-Post", MediaURL = "/Uploads/BlogPageimage2.jpg", Created = DateTime.Now, Published = true, Body = "Body of my second blog post." }
                );
        }
    }
}
    
   


      
