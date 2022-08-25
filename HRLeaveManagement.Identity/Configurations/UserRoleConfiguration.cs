using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRLeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>    // admin
                {
                    RoleId = "38b576ad-5cf4-4ece-83b9-cfe1f4c31f90",
                    UserId = "3579d67e-4f01-459e-b87d-b6372a2541a4"
                },
                new IdentityUserRole<string>    // user
                {
                    RoleId = "73f62636-6f53-4f46-aed3-4b7f19f412f9",
                    UserId = "a85ace79-39c6-42f2-9cc2-0385b40e211d"
                }
            );
        }
    }
}
