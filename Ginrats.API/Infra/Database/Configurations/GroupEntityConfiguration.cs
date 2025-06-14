using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ginrats.API.Infra.Database.Configurations
{
    public class GroupEntityConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("groups");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();


            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(255)")
                .IsRequired(false);

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.HeaderPhotoS3Key)
                .HasColumnName("header_photo_s3_key")
                .HasColumnType("varchar(255)")
                .IsRequired(false);

            builder.Property(e => e.RequiresPhoto)
                .HasColumnName("requires_photo")
                .HasColumnType("boolean")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.GroupGoalId)
                .HasColumnName("group_goal_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("update_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("timestamp")
                .IsRequired(false);

            builder.HasOne(e => e.GroupGoal)
                  .WithMany()
                  .HasForeignKey(e => e.GroupGoalId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}
