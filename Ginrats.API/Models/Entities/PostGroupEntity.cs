namespace Ginrats.API.Models.Entities
{
    public class PostGroupEntity
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid GroupId { get; set; }

        // navproperties
        public virtual PostEntity Post { get; set; } = null!;
        public virtual GroupEntity Group { get; set; } = null!;
    }
}
