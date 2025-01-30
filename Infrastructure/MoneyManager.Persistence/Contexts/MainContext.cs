using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyManager.Application.Services.Log;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Entities.Common;
using MoneyManager.Domain.Entities.Identity;
using MoneyManager.Persistence.Interceptors;

namespace MoneyManager.Persistence.Contexts;

public class MainContext(DbContextOptions<MainContext> options, ILogService logService) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Cashback> Cashbacks { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionProduct> TransactionProducts { get; set; }
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

        modelBuilder.Entity<Media>()
            .HasMany(m => m.Products)
            .WithOne(p => p.Media)
            .HasForeignKey(m => m.Image)
            .HasPrincipalKey(m => m.Path)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Media>()
            .HasMany(m => m.PaymentMethods)
            .WithOne(p => p.Media)
            .HasForeignKey(m => m.Image)
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

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Cashbacks)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Transactions)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PaymentMethod>()
            .HasMany(p => p.Cashbacks)
            .WithOne(c => c.PaymentMethod)
            .HasForeignKey(c => c.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<PaymentMethod>()
            .HasMany(p => p.Transactions)
            .WithOne(c => c.PaymentMethod)
            .HasForeignKey(c => c.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Stock>()
            .HasMany(s => s.Cashbacks)
            .WithOne(c => c.Stock)
            .HasForeignKey(c => c.StockId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Stock>()
            .HasMany(s => s.Transactions)
            .WithOne(c => c.Stock)
            .HasForeignKey(c => c.StockId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cashback>()
            .Property(c => c.CategoryId)
            .IsRequired(false);

        modelBuilder.Entity<Cashback>()
            .Property(c => c.StockId)
            .IsRequired(false);
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.TransactionProducts)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Transaction>()
            .HasMany(t => t.TransactionProducts)
            .WithOne(t => t.Transaction)
            .HasForeignKey(t => t.TransactionId)
            .OnDelete(DeleteBehavior.Restrict);

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new EfCoreLogInterceptor(logService));
    }
}