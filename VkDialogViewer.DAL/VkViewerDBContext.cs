using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using VkDialogViewer.Core.Entities;

namespace VkDialogViewer.DAL
{
    public class VkViewerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<VkMessage> VkMessages { get; set; }

        public VkViewerDbContext() : base("name=VkViewerConnectionsString")
        {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<VkViewerDbContext, Migrations.Configuration>("VkViewerConnectionsString"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            InitializeUsersTable(modelBuilder);
            InitializeMessagesTable(modelBuilder);
            InitializeVkMessagesTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void InitializeVkMessagesTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VkMessage>().HasKey(u => u.Id);
        }

        private static void InitializeUsersTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void InitializeMessagesTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasKey(u => u.Id);
            modelBuilder.Entity<Message>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.FromUser)
                        .WithMany(t => t.InboxMessages)
                        .HasForeignKey(m => m.FromUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.ToUser)
                        .WithMany(t => t.OutboxMessages)
                        .HasForeignKey(m => m.ToUserId)
                        .WillCascadeOnDelete(false);
        }
    }
}