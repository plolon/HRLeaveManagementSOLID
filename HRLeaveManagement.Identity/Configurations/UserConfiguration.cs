using HRLeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRLeaveManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "3579d67e-4f01-459e-b87d-b6372a2541a4",
                    Email = "admin@localhost.pl",
                    NormalizedEmail = "ADMIN@LOCALHOST.PL",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.pl",
                    NormalizedUserName = "ADMIN@LOCALHOST.PL",
                    PasswordHash = hasher.HashPassword(null, "zaq1@WSX"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "a85ace79-39c6-42f2-9cc2-0385b40e211d",
                    Email = "user@localhost.pl",
                    NormalizedEmail = "USER@LOCALHOST.PL",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@localhost.pl",
                    NormalizedUserName = "USER@LOCALHOST.PL",
                    PasswordHash = hasher.HashPassword(null, "zaq1@WSX"),
                    EmailConfirmed = true
                }
                );
        }
    }
}
