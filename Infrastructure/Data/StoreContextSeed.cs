using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var TypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.Products.Any())
            {
                var ProductData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                context.Products.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
