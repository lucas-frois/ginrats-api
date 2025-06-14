namespace Ginrats.API.Models.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public required string DrinkName { get; set; } 

        public decimal AbvPercentage { get; set; }
        public decimal VolumeML { get; set; }

        public string? PhotoS3Key { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual UserEntity User { get; set; } = null!;
        public virtual ICollection<PostGroupEntity> PostGroups { get; set; } = new List<PostGroupEntity>();
    }
}
