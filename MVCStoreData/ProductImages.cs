﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class ProductImage : EntityBase
    {
       
        public Guid ProductId { get; set; }
        public byte[] Image { get; set; }

        public virtual Product? Product { get; set; }
    }

    public class ProductImageEntityTypeConfigration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder
                .Property(p => p.Image)
                .IsRequired();
                
           
        }
    }
}
