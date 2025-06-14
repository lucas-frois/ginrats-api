using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ginrats.API.Infra.Database.Configurations
{
    public class GroupGoalEntityConfiguration : IEntityTypeConfiguration<GroupGoalEntity>
    {
        public void Configure(EntityTypeBuilder<GroupGoalEntity> builder)
        {
            builder.ToTable("group_goals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
