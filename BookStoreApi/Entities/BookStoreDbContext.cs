using BookStoreApi.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Entities;

public class BookStoreDbContext:DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        :base(options){ }


    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Language> Languages { get; set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Address> Addresses { get; set; }
    //public DbSet<AddressStatus> AddressStatus { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       new EntitiesConfiguration(modelBuilder).Configure();
        //
        // modelBuilder.ApplyConfiguration(new AuthorConfig());
        // modelBuilder.ApplyConfiguration(new BookAuthorConfig());
        // modelBuilder.ApplyConfiguration(new BookConfig());
        // modelBuilder.ApplyConfiguration(new LanguageConfig());
        // modelBuilder.ApplyConfiguration(new PublisherConfig());
        //
        // modelBuilder.ApplyConfiguration(new CustomerConfig());
        // modelBuilder.ApplyConfiguration(new CountryConfig());
        // modelBuilder.ApplyConfiguration(new AddressConfig());
        // modelBuilder.ApplyConfiguration(new CustomerAddressConfig());
        // modelBuilder.ApplyConfiguration(new AddressStatusConfig());
        
        SetGlobalQueryFilters(modelBuilder);
    }

    #region "Soft Delete Configuration"

    private void SetGlobalQueryFilters(ModelBuilder modelBuilder)
    {
        //This feature was introduced in EF Core 2.0
        //https://docs.microsoft.com/en-us/ef/core/querying/filters
        modelBuilder.Entity<Author>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<Book>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<Language>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<Publisher>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<BookAuthor>().HasQueryFilter(q => !q.IsDeleted);

        modelBuilder.Entity<Customer>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<Country>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<Address>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<CustomerAddress>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<AddressStatus>().HasQueryFilter(q => !q.IsDeleted);
        
        modelBuilder.Entity<Order>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<OrderHistory>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<OrderStatus>().HasQueryFilter(q => !q.IsDeleted);
        
        modelBuilder.Entity<OrderLine>().HasQueryFilter(q => !q.IsDeleted);
        modelBuilder.Entity<ShippingMethod>().HasQueryFilter(q => !q.IsDeleted);
        
    }
    
    
    public override int SaveChanges()
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChanges();
    }
    
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    private void UpdateSoftDeleteStatuses()
    {
        foreach (var entity in ChangeTracker.Entries())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.CurrentValues["IsDeleted"] = false;
                    break;
                case EntityState.Deleted:
                    entity.State = EntityState.Modified;
                    entity.CurrentValues["IsDeleted"] = true;
                    break;
            } 
        }
    }
   
    #endregion
    
}