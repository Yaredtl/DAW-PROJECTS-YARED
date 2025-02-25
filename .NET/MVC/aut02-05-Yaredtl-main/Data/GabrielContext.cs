using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AUT02_05.Data;

public class GabrielContext : IdentityDbContext
{
    public GabrielContext(DbContextOptions<GabrielContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Name="Basic",
                NormalizedName="BASIC"
            },
            new IdentityRole
            {
                Name="Premium",
                NormalizedName="PREMIUM"
            },
            new IdentityRole
            {
                Name="Admin",
                NormalizedName="ADMIN"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        List<IdentityUser> users = new List<IdentityUser>()
        {
            new IdentityUser
            {
                UserName="basic@diccionario.com",
                NormalizedUserName="BASIC@DICCIONARIO.COM",
                Email="basic@diccionario.com",
                NormalizedEmail="BASIC@DICCIONARIO.COM",
                EmailConfirmed=true
            },
            new IdentityUser
            {
                UserName="premium@diccionario.com",
                NormalizedUserName="PREMIUM@DICCIONARIO.COM",
                Email="premium@diccionario.com",
                NormalizedEmail="PREMIUM@DICCIONARIO.COM",
                EmailConfirmed=true
            },
            new IdentityUser
            {
                UserName="admin@diccionario.com",
                NormalizedUserName="ADMIN@DICCIONARIO.COM",
                Email="admin@diccionario.com",
                NormalizedEmail="ADMIN@DICCIONARIO.COM",
                EmailConfirmed=true
            }
        };
        builder.Entity<IdentityUser>().HasData(users);
        var passwordHasher = new PasswordHasher<IdentityUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Basic123!");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Premium123!");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Admin123!");
        List<IdentityUserRole<string>> roluser = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>()
            {
                UserId=users[0].Id,
                RoleId=roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId=users[1].Id,
                RoleId=roles[1].Id
            },
            new IdentityUserRole<string>()
            {
                UserId =users[2].Id,
                RoleId=roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(roluser);
    }
}
