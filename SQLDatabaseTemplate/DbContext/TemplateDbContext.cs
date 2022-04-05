using Microsoft.EntityFrameworkCore;
using SQLDatabaseTemplate.Models;
namespace SQLDatabaseTemplate.DatabaseContext
{
  public class TemplateDbContext : DbContext
  {
    public DbSet<ModelOne> ModelOne { get; set; }
    public DbSet<ModelTwo> ModelTwo { get; set; }

    public TemplateDbContext(DbContextOptions options): base(options) { }

    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ModelOne>()
        .HasData(new ModelOne { Id = 1, Text = "Test 1" });
      modelBuilder.Entity<ModelTwo>()
        .HasData(new ModelTwo { Id = 1, isThereTruth = false, Text = "Text" });
    }


  }
}
