﻿using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using Store.Data.Entities.Brands;
using Store.Data.Entities.DelivtyMethods;
using Store.Data.Entities.Order;
using Store.Data.Entities.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Data.Contexts
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrands> ProductBrands { get; set; }
        public DbSet<DeliveryMethods> DeliveryMethod { get; set; }
        public DbSet<Orders> Oredrs { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
