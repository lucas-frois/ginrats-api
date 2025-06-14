using Ginrats.API.Infra.Database.Configurations;
using Ginrats.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ginrats.API.Infra.Database
{
    public class GinRatsContext : DbContext
    {
        public GinRatsContext(DbContextOptions<GinRatsContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GroupEntity> Groups { get; set; } 
        public DbSet<GroupGoalEntity> GroupGoals { get; set; } 
        public DbSet<GroupMembershipEntity> GroupMemberships { get; set; } 
        public DbSet<PostEntity> Posts { get; set; } 
        public DbSet<PostGroupEntity> PostGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        }
    }
}
