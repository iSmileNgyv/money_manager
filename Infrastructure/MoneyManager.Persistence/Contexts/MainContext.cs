using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Persistence.Contexts;

public class MainContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Media> Medias { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();
        foreach (EntityEntry<BaseEntity> data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Media>()
            .HasMany(m => m.Categories)
            .WithOne(c => c.Media)
            .HasForeignKey(c => c.Image)
            .HasPrincipalKey(m => m.Path) 
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryId)
            .IsRequired(false);
        
        modelBuilder.Entity<Category>()
            .HasOne(c => c.ParentCategory) 
            .WithMany()                  
            .HasForeignKey(c => c.CategoryId) 
            .OnDelete(DeleteBehavior.Restrict);
    }
}