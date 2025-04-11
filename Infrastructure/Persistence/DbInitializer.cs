
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer (StoreDbContext context) : IDbInitializer
    {
        public async Task InitializerAsync()
        {
            try
            {
                /// Production => Create Db + Seeding

                /// Dev => Seeding

                //if ((await context.Database.GetPendingMigrationsAsync()).Any())

                //await context.Database.MigrateAsync();

                if (!context.Set<ProductBrand>().Any())

                {

                    // Read From the file

                    var data = await File.ReadAllTextAsync(@"..Infrastructure\Persistence\Data\Seeding\brands.json");

                    // Convert to C# objects [Deserialize]
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);
                    // Save to DB
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Set<ProductType>().Any())

                {
                    // Read From the file
                    var data = await File.ReadAllTextAsync(@"..Infrastructure\Persistence\Data\Seeding\types.json");
                    // Convert to C# objects [Deserialize]
                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data);
                    // Save to DB
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }



                }

                if (!context.Set<Product>().Any())

                {

                    // Read From the file

                    var data = await File.ReadAllTextAsync(@"..Infrastructure\Persistence\Data\Seeding\products.json");

                    // Convert to C# objects [Deserialize]
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);
                    // Save to DB
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }



                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
//..Infrastructure\Persistence\Data\Seeding\brands.json
