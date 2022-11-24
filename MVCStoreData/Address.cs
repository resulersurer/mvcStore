﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class Address : EntityBase
    {
        public Guid ApplicationUserId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
       
    }

    //Eager
    //Lazy

    public class AddressEntityTypeConfigration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasMany(p=>p.Orders)
                .WithOne(p=>p.DeliveryAddress)
                .HasForeignKey(p=>p.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
