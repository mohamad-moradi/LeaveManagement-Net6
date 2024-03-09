using LeaveManagement.Common.Constatnts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace LeaveManagement.Data.Configurations.entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "4aee24cd-d60e-42ac-9544-7a1e04859756",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper(),
                }
            );
        }
    }
}