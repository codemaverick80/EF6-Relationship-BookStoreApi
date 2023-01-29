using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Entities.Config;

public class EntitiesConfiguration
{
    private readonly ModelBuilder _modelBuilder;

    public EntitiesConfiguration(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Configure()
    {
        _modelBuilder.ApplyConfiguration(new AuthorConfig());
        _modelBuilder.ApplyConfiguration(new BookAuthorConfig());
        _modelBuilder.ApplyConfiguration(new BookConfig());
        _modelBuilder.ApplyConfiguration(new LanguageConfig());
        _modelBuilder.ApplyConfiguration(new PublisherConfig());
        
        _modelBuilder.ApplyConfiguration(new CustomerConfig());
        _modelBuilder.ApplyConfiguration(new CountryConfig());
        _modelBuilder.ApplyConfiguration(new AddressConfig());
        _modelBuilder.ApplyConfiguration(new CustomerAddressConfig());
        _modelBuilder.ApplyConfiguration(new AddressStatusConfig());
        
        _modelBuilder.ApplyConfiguration(new OrderConfig()); 
        _modelBuilder.ApplyConfiguration(new OrderHistoryConfig());
        _modelBuilder.ApplyConfiguration(new OrderStatusConfig());

        _modelBuilder.ApplyConfiguration(new OrderLineConfig());
        _modelBuilder.ApplyConfiguration(new ShippingMethodConfig());
    }
}