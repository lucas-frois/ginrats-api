namespace Ginrats.API.Models.Entities
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Code { get; set; }
        public string? HeaderPhotoS3Key { get; set; }
        public bool RequiresPhoto { get; set; }
        public Guid GroupGoalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? EndDate { get; set; }

        // nav properties
        public virtual GroupGoalEntity GroupGoal { get; set; } = null!;
        public virtual ICollection<GroupMembershipEntity> GroupMemberships { get; set; } = new List<GroupMembershipEntity>();
        public virtual ICollection<PostGroupEntity> PostGroups { get; set; } = new List<PostGroupEntity>();
    }
}
