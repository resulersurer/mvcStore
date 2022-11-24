using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class Category : EntityBase
    {
        public Guid RayonId { get; set; }
        public string Name { get; set; }
        public virtual Rayon Rayon { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }

    public class CategoryEntityTypeConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(50);
                
            builder
                .HasIndex(p => new { p.Name, p.RayonId})
                .IsUnique();
           

        }
    }
}
