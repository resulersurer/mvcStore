using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCStoreData
{
    public class City 
    {
        public int Id { get; set; }
        public int ProvienceId { get; set; }
        public string Name { get; set; }
        public virtual Province? Province { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();


    }

    public class CityEntityTypeConfigration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(50);
                
            builder
                .HasIndex(p => new { p.Name, p.ProvienceId })
                .IsUnique();
            builder
               .HasMany(p => p.Addresses)
               .WithOne(p => p.City)
               .HasForeignKey(p => p.CityId)
               .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasData(
                new City { Id=1, Name = "Seyahan", ProvienceId=1}
                );

        }
    }
}
