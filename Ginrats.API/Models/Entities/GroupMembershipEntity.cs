namespace Ginrats.API.Models.Entities
{
    public class GroupMembershipEntity
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

        // nav properties
        public virtual GroupEntity Group { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}
