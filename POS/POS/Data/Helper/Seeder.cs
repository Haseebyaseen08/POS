using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POS.Data.Entities;

namespace POS.Data.Helper
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Create & Seed Roles

            List<ApplicationRoles> roles = new List<ApplicationRoles>();
            roles.Add(new ApplicationRoles
            {
                Id = 1,
                Name = "User",
                NormalizedName = "USER",
            });
            roles.Add(new ApplicationRoles
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "Manager",
            });

            modelBuilder.Entity<ApplicationRoles>().HasData(roles);

            // Seed Users (SuperAdmin)

            PasswordHasher<ApplicationUser> Hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser users = new ApplicationUser
            {
                Id = 1,
                Email = "haseeb.yaseen08@gmail.com",
                NormalizedEmail = "HASEEB.YASEEN08@GMAIL.COM",
                UserName = "Haseeb08",
                NormalizedUserName = "Haseeb08",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            users.PasswordHash = Hasher.HashPassword(users, "Project@123");
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            // Seed UserRoles

            List<IdentityUserRole<int>> userRoles = new List<IdentityUserRole<int>>();
            userRoles.Add(new IdentityUserRole<int>
            {
                UserId = users.Id,
                RoleId = roles.First(q => q.Name == "Manager").Id
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);
        }
    }
}
