using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ProjectNameContext : DbContext
  {
    public DbSet<ClassName> ClassNames { get; set; }

    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}