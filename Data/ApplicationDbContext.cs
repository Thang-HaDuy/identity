using identity.Areas.User.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using identity.Models;


namespace identity.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }

    }

    // public override int SaveChanges()
    // {
    //     ChangeTracker.DetectChanges();

    //     var modifiedEntries = ChangeTracker.Entries()
    //         .Where(e => e.State == EntityState.Modified);

    //     foreach (var entry in modifiedEntries)
    //     {
    //         if (entry.Entity is BaseModel basemodel)
    //         {
    //             basemodel.UpdatedAt = DateTime.UtcNow;
    //         }

    //         if (entry.Entity is AppUser appuser)
    //         {
    //             appuser.UpdatedAt = DateTime.UtcNow;
    //         }
    //     }

    //     return base.SaveChanges();
    // }
}
