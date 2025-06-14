using Microsoft.Extensions.Hosting;

namespace Ginrats.API.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? ProfilePictureS3Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // nav properties
        public virtual ICollection<GroupMembershipEntity> GroupMemberships { get; set; } = [];
        public virtual ICollection<PostEntity> Posts { get; set; } = [];
    }
}
