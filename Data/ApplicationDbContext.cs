using Microsoft.EntityFrameworkCore;
using LTMKarur.Models;

namespace LTMKarur.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<ItemMaster> ItemMasters { get; set; }

    public DbSet<CountMaster> CountMasters { get; set; }
    public DbSet<Certification> Certifications { get; set; }


}
