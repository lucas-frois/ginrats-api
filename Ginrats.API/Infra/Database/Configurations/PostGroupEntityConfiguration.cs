using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ginrats.API.Infra.Database.Configurations
{
    public class PostGroupEntityConfiguration : IEntityTypeConfiguration<PostGroupEntity>
    {
        public void Configure(EntityTypeBuilder<PostGroupEntity> builder)
        {
            builder.ToTable("post_groups");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.PostId)
                .HasColumnName("post_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.GroupId)
                .HasColumnName("group_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(e => e.Post)
                  .WithMany(p => p.PostGroups)
                  .HasForeignKey(e => e.PostId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Group)
                  .WithMany(g => g.PostGroups)
                  .HasForeignKey(e => e.GroupId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.PostId, e.GroupId }).IsUnique();
        }
    }
}
