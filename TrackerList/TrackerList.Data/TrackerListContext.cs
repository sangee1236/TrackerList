using TrackerList.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace TrackerList.Data
{
    public class TrackerListContext : DbContext
    {
        // Resource table dbset
        public DbSet<Users> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<GroupListItems> GroupListItems { get; set; }
        public DbSet<Group_User> Group_User { get; set; }
        public DbSet<Messages> Messages { get; set; }

        public TrackerListContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region EngagementResource

            //modelBuilder.Entity<EngagementResource>()
            //    .Property(u => u.ProjectId)
            //    .HasColumnName("ProjectId");

            //modelBuilder.Entity<EngagementResource>()
            //    .Property(u => u.ResourceId)
            //    .HasColumnName("ResourceId");
            #endregion

            #region TimesheetEntry
            //modelBuilder.Entity<TimeSheetEntry>()
            //                .Property(u => u.ResourceInfoId)
            //                .HasColumnName("ResourceId");

            //modelBuilder.Entity<TimeSheetEntry>()
            //              .Property(u => u.TimeSheetInfoId)
            //              .HasColumnName("TimeSheetInfoId");
            #endregion
        }
    }
}
