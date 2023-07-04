using Core.Abstractions.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ContactsDbContext : DbContext, IContactsDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<UserSkill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Contact)
                .WithOne(c => c.User)
                .HasForeignKey<Contact>(c => c.UserId);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithOne(u => u.Contact)
                .HasForeignKey<User>(u => u.ContactId);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.SkillId, us.ContactId });

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Contact)
                .WithMany(c => c.Skills)
                .HasForeignKey(us => us.ContactId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany()
                .HasForeignKey(us => us.SkillId);
        }

        public int SaveChanges(CancellationToken cancellationToken = default)
        {
            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
    }
}