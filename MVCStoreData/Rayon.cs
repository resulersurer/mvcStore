using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class Rayon : EntityBase
    {
       
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }

    public class RayonEntityTypeConfigration : IEntityTypeConfiguration<Rayon>
    {
        public void Configure(EntityTypeBuilder<Rayon> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(50);
                
            builder
                .HasIndex(p => new { p.Name })
                .IsUnique();
            builder
                .HasMany(p => p.Categories)
                .WithOne(p=>p.Rayon)
                .HasForeignKey(p => p.RayonId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
