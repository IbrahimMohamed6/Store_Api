using Microsoft.Extensions.Logging;
using Store.Data.Data.Contexts;
using Store.Data.Entities;
using Store.Data.Entities.Brands;
using Store.Data.Entities.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreDbContextSeed
    {
        public static async Task StoreSeedAsync(StoreDbContext Context,ILoggerFactory LoggerFactory)
        {
			try
			{
				if (Context.ProductBrands is not null && !Context.ProductBrands.Any())
                {
					var BrandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
					var Brands=JsonSerializer.Deserialize<List<ProductBrands>>(BrandsData);

					if(Brands is not null ) 
						await Context.ProductBrands.AddRangeAsync(Brands);

                }
                if (Context.ProductTypes is not null && !Context.ProductTypes.Any())
                {
                    var TypesData = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    if (Types is not null)
                        await Context.ProductTypes.AddRangeAsync(Types);

                }
                if (Context.Products is not null && !Context.Products.Any())
                {
                    var ProductData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                    if (Products is not null)
                        await Context.Products.AddRangeAsync(Products);

                }
                await Context.SaveChangesAsync();   


            }
            catch (Exception ex)
			{
                var Logger=LoggerFactory.CreateLogger<StoreDbContextSeed>();
                Logger.LogError(ex.Message);
				
			}
        }
    }
}
