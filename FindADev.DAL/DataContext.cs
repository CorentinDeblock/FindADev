using FindADev.DAL.Configuration;
using FindADev.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=DESKTOP-C1EJAU3;Database=FindAJob;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeInfoConfiguration());
            modelBuilder.ApplyConfiguration(new RateConfiguration());
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<KnowledgeInfo> knowledgeInfos { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
