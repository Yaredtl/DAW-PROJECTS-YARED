using System;
using System.Collections.Generic;
using Jardineria_Gabriel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Jardineria_Gabriel.Data
{
    public class GabrielContext : IdentityDbContext<JardinUser>
    {
        public GabrielContext(DbContextOptions<GabrielContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<JardinUser> users = new List<JardinUser>()
        {
                new JardinUser
                {
                    UserName="basic@jardin.com",
                    NormalizedUserName="BASIC@JARDIN.COM",
                    Email="basic@jardin.com",
                    NormalizedEmail="BASIC@JARDIN.COM",
                    EmailConfirmed=true,
                    FullName = "BasicoJardineria",
                    Address = "BasicHome",
                    PostalCode = 12345,
                    Phone = 123456789
                  
                },
                 new JardinUser
                {
                    UserName="premium@jardin.com",
                    NormalizedUserName="PREMIUM@JARDIN.COM",
                    Email="premium@jardin.com",
                    NormalizedEmail="PREMIUM@JARDIN.COM",
                    EmailConfirmed=true,
                    FullName = "PremiumJardineria",
                    Address = "PremiumHome",
                    PostalCode = 12345,
                    Phone = 123456789
                },
                 new JardinUser
                {
                    UserName="admin@jardin.com",
                    NormalizedUserName="ADMIN@JARDIN.COM",
                    Email="admin@jardin.com",
                    NormalizedEmail="ADMIN@JARDIN.COM",
                    EmailConfirmed=true,
                    FullName = "AdminJardineria",
                    Address = "AdminHome",
                    PostalCode = 12345,
                    Phone = 123456789
                }
            };
            modelBuilder.Entity<JardinUser>().HasData(users);
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Basic",
                    NormalizedName ="BASIC"
                },
                 new IdentityRole
                {
                    Name = "Premium",
                    NormalizedName ="PREMIUM"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName ="ADMIN"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            List<IdentityUserRole<string>> usrol = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = roles[0].Id,
                    UserId = users[0].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = roles[1].Id,
                    UserId = users[1].Id
                },
                 new IdentityUserRole<string>
                {
                    RoleId = roles[2].Id,
                    UserId = users[2].Id
                },
            };
            var passwordHasher = new PasswordHasher<JardinUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Asdf1234!");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Asdf1234!");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Asdf1234!");
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(usrol);
        }
    }
}
