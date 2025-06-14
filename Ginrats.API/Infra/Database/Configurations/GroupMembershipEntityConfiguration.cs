using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ginrats.API.Infra.Database.Configurations
{
    public class GroupMembershipEntityConfiguration : IEntityTypeConfiguration<GroupMembershipEntity>
    {
        public void Configure(EntityTypeBuilder<GroupMembershipEntity> builder)
        {
            builder.ToTable("group_memberships");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.GroupId)
                .HasColumnName("group_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
               .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(e => e.Group)
                  .WithMany(g => g.GroupMemberships)
                  .HasForeignKey(e => e.GroupId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                  .WithMany(u => u.GroupMemberships)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.GroupId, e.UserId }).IsUnique();
        }
    }
}
