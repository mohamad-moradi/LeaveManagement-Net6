using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                    UserId = "429f46f1-569b-4f3c-bc41-7b23a5ca38f2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "4aee24cd-d60e-42ac-9544-7a1e04859756",
                    UserId = "429f46f1-569b-4f3c-bc41-7b23a5ca38f8"
                }
            );
        }
    }
}