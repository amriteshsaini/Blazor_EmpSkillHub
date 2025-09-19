using Microsoft.EntityFrameworkCore;
using EmpSkillHub.Data.Models;

namespace EmpSkillHub.Data
{
    public class EmpSkillHubDbContext : DbContext
    {
        public EmpSkillHubDbContext(DbContextOptions<EmpSkillHubDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmpSkill> EmpSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.RecId);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.FirstName, e.LastName, e.PhoneNumber })
                .IsUnique();

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.RecId);

            modelBuilder.Entity<EmpSkill>()
                .HasIndex(es => new { es.EmpId, es.SkillId })
                .IsUnique();

            modelBuilder.Entity<EmpSkill>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmpSkills)
                .HasForeignKey(es => es.EmpId);

            modelBuilder.Entity<EmpSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.EmpSkills)
                .HasForeignKey(es => es.SkillId);

            base.OnModelCreating(modelBuilder);
        }
    }
}