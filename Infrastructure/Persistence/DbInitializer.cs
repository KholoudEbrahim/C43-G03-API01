
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence
{
    public class DbInitializer(StoreDbContext context) : IDbInitializer
    {
        public async Task InitializerAsync()
        {
            try
            {
                Console.WriteLine("Starting DB Initialization...");

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var seedingPath = Path.Combine(basePath, "Data", "Seeding");

                // Seed Product Brands
                if (!context.Set<ProductBrand>().Any())
                {
                    Console.WriteLine("Seeding Product Brands...");
                    var filePath = Path.Combine(seedingPath, "brands.json");

                    var data = await File.ReadAllTextAsync(filePath);
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Brands seeded.");
                    }
                }

                // Seed Product Types
                if (!context.Set<ProductType>().Any())
                {
                    Console.WriteLine("Seeding Product Types...");
                    var filePath = Path.Combine(seedingPath, "types.json");

                    var data = await File.ReadAllTextAsync(filePath);
                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data);

                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Types seeded.");
                    }
                }

                // Seed Products
                if (!context.Set<Product>().Any())
                {
                    Console.WriteLine("Seeding Products...");
                    var filePath = Path.Combine(seedingPath, "products.json");

                    var data = await File.ReadAllTextAsync(filePath);
                    var objects = JsonSerializer.Deserialize<List<Product>>(data);

                    if (objects is not null && objects.Any())
                    {
                        context.Set<Product>().AddRange(objects);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Products seeded.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during DB seeding: {ex.Message}");
            }
        }
    }
}//..Infrastructure\Persistence\Data\Seeding\brands.json
