using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ginrats.API.Infra.Database.Configurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("posts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.DrinkName)
                .HasColumnName("drink_name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.AbvPercentage)
                .HasColumnName("abv_percentage")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(e => e.VolumeML)
                .HasColumnName("volume_ml")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(e => e.PhotoS3Key)
                .HasColumnName("photo_s3_key")
                .HasColumnType("varchar(255)")
                .IsRequired(false);

            builder.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasOne(e => e.User)
                  .WithMany(u => u.Posts)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.CreatedAt);
        }
    }
}
