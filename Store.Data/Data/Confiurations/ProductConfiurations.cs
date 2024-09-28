using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Data.Confiurations
{
    public class ProductConfiurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.Property(P => P.Name).IsRequired().HasColumnType("VarChar(50)");
            //builder.Property(D => D.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
