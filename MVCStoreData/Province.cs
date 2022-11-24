using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class Province 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();


    }

    public class ProvinceEntityTypeConfigration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(50);
                
            builder
                .HasIndex(p => new { p.Name })
                .IsUnique();

            builder
                .HasMany(p => p.Cities)
                .WithOne(p => p.Province)
                .HasForeignKey(p => p.ProvienceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasData(
                new Province { Id = 1, Name = "Adana" }
                );
        }
    }
}
