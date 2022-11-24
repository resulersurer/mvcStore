﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public enum Gender
    {
        Male, Famale
    }

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
    public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasMany(p => p.Comments)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.ShoppingCartItems)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(p => p.Orders)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
